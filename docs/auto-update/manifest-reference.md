# `update.xml` reference

Location: repo root (`update.xml`), served to running apps via:

```
https://raw.githubusercontent.com/tttaufiqqq/Library-System-EDP/main/update.xml
```

This is the file AutoUpdater.NET downloads on every app launch to decide
whether a newer version exists. Editing this file and pushing to `main` is
the actual "publish an update" action — nothing else about the running
apps in the field changes until this file says a newer version exists.

## Current contents

```xml
<?xml version="1.0" encoding="UTF-8"?>
<item>
  <version>1.0.0.0</version>
  <url>https://github.com/tttaufiqqq/Library-System-EDP/releases/download/v1.0.0/EDP-LibraryManagementSystem-Setup.exe</url>
  <changelog>https://github.com/tttaufiqqq/Library-System-EDP/releases</changelog>
  <mandatory>false</mandatory>
</item>
```

This currently matches the shipped `AssemblyVersion` (`1.0.0.0`), so no
update prompt fires yet — there is nothing newer to offer. See
[release-workflow.md](release-workflow.md) for how this changes when a real
update ships.

## Full field reference (from AutoUpdater.NET's docs)

| Field | Required | Meaning |
|---|---|---|
| `<version>` | Yes | Latest available version, in `X.X.X.X` format. Compared against the running app's `AssemblyVersion` (or a manually-provided version — see below). Must be *greater than* the installed version to trigger the prompt. |
| `<url>` | Yes | Direct download URL for the installer (or a `.zip`). AutoUpdater.NET downloads whatever's here and executes it. If it's a `.zip`, AutoUpdater.NET extracts it into the app directory instead of running it. |
| `<changelog>` | No | URL shown in the update dialog's changelog panel (rendered via the WebView2 dependency). Omit to hide the changelog panel entirely. |
| `<mandatory>` | No | `true`/`false`. If `true`, hides the "Skip"/"Remind Later" buttons — user must update. |
| `<mandatory mode="1">` | No | Attribute on `<mandatory>`. Mode `1` additionally hides the dialog's Close button (fully blocking). |
| `<mandatory mode="2">` | No | Mode `2` skips the dialog entirely and silently downloads + installs immediately. |
| `<mandatory minVersion="X.X.X.X">` | No | Attribute on `<mandatory>`. Only enforces mandatory behavior if the *installed* version is below `minVersion` — lets you force-update only users stuck on old, unsupported builds. |
| `<executable>` | No | Relative path to the app's `.exe` inside the install directory, if it changed in this update (rarely needed). |
| `<args>` | No | Command-line arguments passed to the installer when AutoUpdater.NET launches it. Supports an `%path%` token, replaced with the current install directory. Not currently used — see below. |
| `<checksum algorithm="...">` | No | Verifies the downloaded installer's checksum before running it. Supported algorithms: MD5, SHA1, SHA256, SHA384, SHA512. Not currently used — see [caveats-and-future-work.md](caveats-and-future-work.md). |

## Silent-install args (not currently set, documented for future use)

The installer is built with Inno Setup, which supports standard silent
command-line switches. If a fully-silent update (no installer wizard shown
to the user) is ever wanted, `update.xml` could add:

```xml
<args>/VERYSILENT /SUPPRESSMSGBOXES /NORESTART</args>
```

This is deliberately **not** set right now — the default (interactive
installer wizard) is simpler to reason about while this system is new, and
Rule 2 (Simplicity First) argues against adding untested behavior before
it's needed.

## Version format note

`AssemblyVersion` in `Properties/AssemblyInfo.cs` and `<version>` here must
both be valid `X.X.X.X` .NET `Version` strings, and are compared using
standard `Version` ordering (major, then minor, then build, then revision).
`1.0.10.0` is greater than `1.0.9.0`, for example — this is numeric
comparison per segment, not string comparison.
