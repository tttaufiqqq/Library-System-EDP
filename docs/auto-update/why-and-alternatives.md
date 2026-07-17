# Why this exists, and why AutoUpdater.NET

## The problem

This app is distributed as an Inno Setup installer (`installer/LibrarySystem.iss`),
built from a WinForms .NET Framework 4.7.2 project. Before this work, "shipping
an update" meant manually rebuilding, recompiling the installer, and telling
whoever runs the app to go download and run the new `Setup.exe` themselves.
There was no mechanism for the app to notice a new version exists.

There is no server-side "deploy" step for this project — the artifact is a
binary a user runs on their own PC, not a hosted service. So "CI/CD" here
only meaningfully applies to the "CD" of getting a new build *onto the
user's machine*, not to any infrastructure this project owns.

## Options considered

### ClickOnce
Built into .NET Framework, and the project's `.csproj` already had unused
stub properties for it (`UpdateEnabled`, `PublishUrl`, `ApplicationVersion`,
etc. — leftovers from the project template, never actually configured).
Visual Studio can publish a ClickOnce app with a few clicks and it handles
versioned installs and update checks natively.

**Rejected because:** ClickOnce owns the entire install/update lifecycle
itself. Adopting it would mean throwing away the existing Inno Setup
installer and its custom logic (the `.NET 4.7.2` presence check, desktop
icon task, custom install directory under `{localappdata}\Programs\`).
That's a bigger structural change than the problem warranted.

### Squirrel.Windows / Velopack
Modern auto-update tooling (used by apps like Slack/Discord-style
Electron/.NET apps). Supports binary delta updates so users only download
the diff between versions, not a full installer every time.

**Rejected because:** it's built primarily for .NET Core/5+ apps and expects
to own the packaging pipeline (its own installer format, not Inno Setup).
For a .NET Framework 4.7.2 project already using Inno Setup, adopting it
would mean re-architecting the build/package step for a benefit (delta
updates) this project doesn't need at its current scale — one maintainer,
infrequent releases.

### AutoUpdater.NET (Autoupdater.NET.Official on NuGet) — chosen
A small class library purpose-built for exactly this shape of project:
WinForms/WPF apps on .NET Framework or .NET Core/5+, already packaged with
a traditional installer. It does not replace the installer — it just
automates the "check version → prompt user → download → launch installer"
loop that a user would otherwise do by hand.

**Chosen because:**
- Keeps the existing Inno Setup installer untouched.
- The entire integration is one NuGet package + one line of code
  (`AutoUpdater.Start(url)`) + one small XML manifest file.
- Matches the project's existing scale: a solo-maintained app with
  infrequent releases doesn't need delta updates or a new packaging system,
  it needs the *existing* installer to reach users automatically.

See [installation.md](installation.md) for what installing it actually
involved (including an unexpected dependency).
