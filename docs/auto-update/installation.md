# Installing the package

## What got installed

- **Autoupdater.NET.Official**, version `1.9.2`, from nuget.org.
- Its transitive dependency for `.NETFramework4.6.2`+ targets:
  **Microsoft.Web.WebView2**, version `1.0.2592.51` (used internally by
  AutoUpdater.NET to render the changelog in an embedded browser control in
  its update dialog).

Both are recorded in `packages.config`:

```xml
<package id="Autoupdater.NET.Official" version="1.9.2" targetFramework="net472" />
<package id="Microsoft.Web.WebView2" version="1.0.2592.51" targetFramework="net472" />
```

And referenced in the `.csproj` with `HintPath`s into `packages/`:

```xml
<Reference Include="AutoUpdater.NET, Version=1.9.2.0, ...">
  <HintPath>..\packages\Autoupdater.NET.Official.1.9.2\lib\net462\AutoUpdater.NET.dll</HintPath>
</Reference>
<Reference Include="Microsoft.Web.WebView2.Core, Version=1.0.2592.51, ...">
  <HintPath>..\packages\Microsoft.Web.WebView2.1.0.2592.51\lib\net462\Microsoft.Web.WebView2.Core.dll</HintPath>
</Reference>
<!-- ...plus Microsoft.Web.WebView2.WinForms and .Wpf, same pattern -->
```

The `.csproj` also imports WebView2's MSBuild targets file, which handles
copying native WebView2 loader binaries to the output directory at build
time:

```xml
<Import Project="..\packages\Microsoft.Web.WebView2.1.0.2592.51\build\Microsoft.Web.WebView2.targets" ... />
```

The project uses the `net462` lib folder from the package (not `net472`)
because the package doesn't ship a `net472`-specific build — `net462` is
the closest/lowest compatible target and .NET Framework assemblies are
forward-compatible within the 4.x line, so this is expected and correct.

## Why this was installed via Rider's NuGet UI, not by hand

This is a `packages.config`-style (non-SDK) project. Adding a package to
this format correctly means: adding the `<package>` entry, adding the
`<Reference>` with the right `HintPath`, and — critically — wiring up any
`.targets`/`.props` imports and native asset copying the package needs
(WebView2 ships native loader DLLs that must land next to the built `.exe`).
NuGet tooling (Rider's built-in NuGet client, or Visual Studio's) resolves
all of this automatically, including transitive dependencies.

There was no reliable way to hand-splice this into `packages.config` and
the `.csproj` and be confident it would actually build, without a way to
run MSBuild/NuGet restore to verify. So the package was installed directly
through Rider:

1. `View → Tool Windows → NuGet`
2. Searched `Autoupdater.NET.Official`
3. Selected the project, clicked **Install**

## Gotcha hit during install

The first search returned **zero results** ("Available Packages: Top 0").
The search box had a trailing period: `Autoupdater.NET.Official.` (note the
`.` after "Official"). NuGet's search does something close to an exact-ID
match for fully-qualified queries, so the stray trailing dot caused it to
match nothing. Removing the trailing dot fixed it immediately.

**Takeaway:** if a NuGet search in Rider (or Visual Studio) returns 0
results for a package you know exists on nuget.org, check the search box
text character-by-character before assuming a feed/connectivity problem.
