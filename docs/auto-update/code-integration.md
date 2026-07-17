# Code integration

## The change

`StartUpScreen.cs` (the splash screen shown at app launch) gained:

```csharp
using AutoUpdaterDotNET;
```

and, inside the constructor, after the existing `InitializeComponent()` /
icon / progress bar / drag-helper setup:

```csharp
AutoUpdater.Start("https://raw.githubusercontent.com/tttaufiqqq/Library-System-EDP/main/update.xml");
```

That's the entire integration. `AutoUpdater.Start` is fire-and-forget from
the caller's perspective: it kicks off an async download of the manifest
XML and, if it finds a newer version, shows its own update dialog later —
nothing else in the app needs to change.

## Why the splash screen constructor, specifically

AutoUpdater.NET's own documentation states the call "should be called from
the UI thread," and that it can go in "your main form constructor or in
`Form_Load` event... anywhere you like." That flexibility hides a real
constraint worth understanding:

- The update check runs asynchronously. When it completes, AutoUpdater.NET
  needs to marshal back onto the UI thread to show its dialog — it does
  this via the current `SynchronizationContext`.
- WinForms installs its `WindowsFormsSynchronizationContext` automatically
  the first time a control's window handle is created — which happens
  during `InitializeComponent()` inside a form's constructor. It does
  **not** require `Application.Run(...)`'s message loop to have started
  yet; the context just needs to exist so continuations have somewhere to
  queue themselves. They'll run once the message pump starts.

This app's `Program.cs` does:

```csharp
Application.Run(new StartUpScreen());
```

If `AutoUpdater.Start(...)` were called in `Program.Main()` *before* this
line, no form (and therefore no window handle, and therefore no
`WindowsFormsSynchronizationContext`) would exist yet — risking the
update-check callback having nowhere correct to marshal back to.

Placing the call inside `StartUpScreen`'s constructor, after
`InitializeComponent()`, guarantees the synchronization context already
exists by the time the async check can complete, regardless of exactly
when the HTTP response comes back relative to `Application.Run` starting
its pump.

## What was deliberately not changed

- No changes to `Program.cs`.
- No changes to how the splash screen transitions to `LoginForm` — the
  update dialog (if any) is a separate top-level window that AutoUpdater.NET
  manages entirely on its own; it doesn't block or interact with the
  existing splash → login flow.
