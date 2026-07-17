# Copies the gitignored real connection string over the placeholder App.config.
# Run this before building a Release you intend to distribute. Do not commit
# the result - App.config.local (the source of truth for secrets) stays gitignored.

$projectDir = Join-Path $PSScriptRoot "..\Library Management System project"
$source = Join-Path $projectDir "App.config.local"
$target = Join-Path $projectDir "App.config"

if (-not (Test-Path $source)) {
    Write-Error "App.config.local not found at $source - create it with your real connection string first."
    exit 1
}

Copy-Item -Path $source -Destination $target -Force
Write-Output "Applied App.config.local -> App.config"
