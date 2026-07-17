# Auto-update system

How this app checks for, downloads, and installs new versions on end-user
machines. This is a from-scratch implementation for a self-distributed
WinForms desktop app — there is no app store and no deployment server
involved.

## Read in this order

1. [why-and-alternatives.md](why-and-alternatives.md) — why this exists and
   why AutoUpdater.NET was picked over ClickOnce / Squirrel-Velopack.
2. [installation.md](installation.md) — the exact NuGet package installed,
   its dependency chain, and how it was added via JetBrains Rider.
3. [code-integration.md](code-integration.md) — where the update check is
   wired into the app and why that specific location matters.
4. [manifest-reference.md](manifest-reference.md) — full field reference for
   `update.xml`, the file that tells running apps a new version exists.
5. [release-workflow.md](release-workflow.md) — the step-by-step process to
   actually ship an update to users.
6. [caveats-and-future-work.md](caveats-and-future-work.md) — known
   limitations, gotchas hit while setting this up, and ideas not yet built.

## One-paragraph summary

On launch, `StartUpScreen` calls `AutoUpdater.Start(...)` with a URL to
`update.xml` hosted at the repo root on GitHub. AutoUpdater.NET downloads
that file, compares its `<version>` to the running app's `AssemblyVersion`,
and — if newer — shows an update dialog. Accepting it downloads the
installer `.exe` linked in `update.xml` (a GitHub Release asset) and runs
it. The installer (Inno Setup) then does the actual file replacement, same
as a manual install. Shipping an update means: bump the version, build,
compile the installer, upload it as a GitHub Release asset, and point
`update.xml` at it.
