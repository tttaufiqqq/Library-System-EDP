; Inno Setup script for EDP - Library Management System.
; Build the Release configuration first, then compile this script with
; ISCC.exe to produce the distributable installer.

#define MyAppName "EDP - Library Management System"
#define MyAppVersion "1.0.0"
#define MyAppPublisher "tttaufiqqq"
#define MyAppURL "https://tttaufiqqq.com"
#define MyAppExeName "Library Management System project.exe"
#define ProjectDir "..\Library Management System project"
#define ReleaseDir ProjectDir + "\bin\Release"

[Setup]
AppId={{8F2326F4-A537-4B6B-980E-3A13BB532E9E}
AppName={#MyAppName}
AppVersion={#MyAppVersion}
AppPublisher={#MyAppPublisher}
AppPublisherURL={#MyAppURL}
DefaultDirName={localappdata}\Programs\{#MyAppName}
DefaultGroupName={#MyAppName}
UninstallDisplayIcon={app}\{#MyAppExeName}
PrivilegesRequired=lowest
OutputDir=Output
OutputBaseFilename=EDP-LibraryManagementSystem-Setup
SetupIconFile={#ProjectDir}\Resources\AppIcon.ico
Compression=lzma2
SolidCompression=yes
WizardStyle=modern
ArchitecturesInstallIn64BitMode=x64compatible
DisableProgramGroupPage=yes

[Languages]
Name: "english"; MessagesFile: "compiler:Default.isl"

[Tasks]
Name: "desktopicon"; Description: "{cm:CreateDesktopIcon}"; GroupDescription: "{cm:AdditionalIcons}"; Flags: unchecked

[Files]
Source: "{#ReleaseDir}\*"; DestDir: "{app}"; Excludes: "*.pdb"; Flags: ignoreversion recursesubdirs createallsubdirs

[Icons]
Name: "{group}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"
Name: "{group}\{cm:UninstallProgram,{#MyAppName}}"; Filename: "{uninstallexe}"
Name: "{autodesktop}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"; Tasks: desktopicon

[Run]
Filename: "{app}\{#MyAppExeName}"; Description: "{cm:LaunchProgram,{#StringChange(MyAppName, '&', '&&')}}"; Flags: nowait postinstall skipifsilent

[Code]
function IsDotNet472OrNewer(): Boolean;
var
  release: Cardinal;
begin
  Result := RegQueryDWordValue(HKLM, 'SOFTWARE\Microsoft\NET Framework Setup\NDP\v4\Full', 'Release', release)
    and (release >= 461808);
end;

function InitializeSetup(): Boolean;
begin
  Result := True;
  if not IsDotNet472OrNewer() then
  begin
    MsgBox('This app requires .NET Framework 4.7.2 or newer, which was not detected on this PC.' + #13#10 +
      'You can still continue, but the app may fail to start until you install it from:' + #13#10 +
      'https://dotnet.microsoft.com/download/dotnet-framework', mbInformation, MB_OK);
  end;
end;
