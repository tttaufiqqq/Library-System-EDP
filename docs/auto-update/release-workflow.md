# Release workflow — how to actually ship an update

There is no CI/CD pipeline automating any of this yet (see
[caveats-and-future-work.md](caveats-and-future-work.md)). Every step below
is manual today.

## Steps

1. **Bump the version in two places** (both must be updated, they are not
   linked to each other):
   - `Properties/AssemblyInfo.cs` — `AssemblyVersion` and
     `AssemblyFileVersion`, e.g. `1.0.0.0` → `1.0.1.0`.
   - `installer/LibrarySystem.iss` — `#define MyAppVersion "1.0.0"` →
     `"1.0.1"`. This is a separate, differently-formatted string (three
     segments, no build metadata) used only for the installer's own
     version display/registry entry — it is never read by AutoUpdater.NET.

2. **Build the Release configuration** in Rider (or
   `msbuild /p:Configuration=Release` if MSBuild is available on PATH).
   Output lands in `Library Management System project/bin/Release/`.

3. **Compile the installer** with Inno Setup's command-line compiler:
   ```
   ISCC.exe installer/LibrarySystem.iss
   ```
   Produces `installer/Output/EDP-LibraryManagementSystem-Setup.exe`.

4. **Create a GitHub Release**:
   - Tag it to match the version, e.g. `v1.0.1`.
   - Attach `EDP-LibraryManagementSystem-Setup.exe` as a release asset.
   - GitHub then serves it at a predictable URL:
     `https://github.com/tttaufiqqq/Library-System-EDP/releases/download/v1.0.1/EDP-LibraryManagementSystem-Setup.exe`

5. **Edit `update.xml`** at the repo root:
   - `<version>` → `1.0.1.0` (must match the new `AssemblyVersion` exactly,
     `X.X.X.X` format).
   - `<url>` → the release asset URL from step 4.
   - Commit and push to `main`.

6. **Done** — any running copy of the app still on `1.0.0.0` will, on its
   next launch, download `update.xml`, see `1.0.1.0` is newer, and show the
   AutoUpdater.NET dialog. Accepting downloads the new `Setup.exe` and runs
   it, same as a manual install/upgrade.

## Order matters

Step 5 (editing `update.xml`) must happen **after** step 4 (the release
asset actually exists at that URL). If `update.xml` is pushed first, any
user whose app happens to check in that window will get a "download" that
404s.

## Verifying a release before publishing `update.xml`

Before pointing `update.xml` at a new release, sanity-check the asset URL
resolves:

```
curl -sIL https://github.com/tttaufiqqq/Library-System-EDP/releases/download/v1.0.1/EDP-LibraryManagementSystem-Setup.exe
```

A `200` (after redirects) confirms the asset is live before any installed
app can be pointed at it.
