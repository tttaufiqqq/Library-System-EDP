# Caveats, gotchas, and future work

## Known limitations today

- **No checksum verification.** `update.xml` doesn't set `<checksum>`, so
  AutoUpdater.NET runs whatever it downloads from `<url>` without
  verifying its integrity. Acceptable today because the URL always points
  at a GitHub Release asset served over HTTPS from a repo this project
  controls, but it's a gap if that trust boundary ever changes (e.g.
  mirroring the installer elsewhere).

- **`raw.githubusercontent.com` is CDN-cached.** Pushing a change to
  `update.xml` on `main` is not guaranteed to be instantly visible —
  GitHub's raw-content CDN (Fastly) can serve a cached copy for a few
  minutes after a push. This means there can be a short window after
  step 5 of the release workflow where some clients still see the old
  manifest. Not a correctness problem (they'll just check again next
  launch), but worth knowing if "why didn't my test machine see the
  update immediately" comes up.

- **Depends on the repo staying public.** `raw.githubusercontent.com` URLs
  only resolve without authentication for public repos. If this repo ever
  goes private, `update.xml` would need to move to a different host (a
  GitHub Release asset URL also requires auth for private repos; a
  self-hosted URL, GitHub Pages on a public docs site, or an authenticated
  API call would all work as replacements).

- **Two separate version strings, manually kept in sync.**
  `AssemblyInfo.cs`'s `AssemblyVersion` (`X.X.X.X`) and
  `LibrarySystem.iss`'s `MyAppVersion` (`X.X.X`) are unrelated fields that
  both need bumping on every release. Nothing enforces they match. A
  mismatch wouldn't break the update check (which only reads
  `AssemblyVersion`), but would show a misleading version number in the
  installer UI/registry.

- **No CI/CD automation.** Every step in
  [release-workflow.md](release-workflow.md) is run by hand: build,
  compile installer, create GitHub Release, edit and push `update.xml`.
  This matches the project's current scale (solo maintainer, infrequent
  releases) — see [why-and-alternatives.md](why-and-alternatives.md) for
  why a heavier pipeline wasn't built preemptively.

## Things not verified

The assistant environment used to build this integration had no MSBuild,
Visual Studio, or `nuget.exe` available — package installation and any
build verification had to happen on the developer's actual machine (via
JetBrains Rider). If anything in this system misbehaves, the first thing
to check is a clean Rider build of the Release configuration, since that
step was never independently re-verified after the initial install.

## Ideas for later, not built

- **A GitHub Actions workflow** triggered on a version tag push that: runs
  MSBuild for the Release config, compiles the Inno Setup installer,
  creates the GitHub Release with the compiled `.exe` attached, and opens a
  PR (or commits directly) updating `update.xml` to match. Would turn the
  6-step manual workflow into "push a tag." Worth doing once releases
  become frequent enough that the manual steps are the bottleneck — not
  before.
- **Checksum in `update.xml`** once the release-build step is automated
  (a CI job can compute and inject the SHA256 of the artifact it just
  built more reliably than a manual step would).
- **A "latest" redirect** instead of a version-pinned Release URL in
  `update.xml`, so the URL itself never needs editing — only the tag
  changes. GitHub doesn't natively support a stable "latest release asset"
  URL by filename, so this would need either a small redirect service or
  a fixed non-versioned release name — not pursued since it adds moving
  parts for a problem (editing one line in `update.xml`) that isn't
  costly today.
