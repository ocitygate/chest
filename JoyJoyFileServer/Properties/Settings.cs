// Decompiled with JetBrains decompiler
// Type: JoyJoyFileServer.Properties.Settings
// Assembly: JoyJoyFileServer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 57CCF9A9-B579-4A8A-9152-530B789099A7
// Assembly location: C:\Users\Matthew\Downloads\JJFS_v100\forWin\JoyJoyFileServer.exe

using System.CodeDom.Compiler;
using System.Configuration;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace JoyJoyFileServer.Properties
{
  [CompilerGenerated]
  [GeneratedCode("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "15.6.0.0")]
  internal sealed class Settings : ApplicationSettingsBase
  {
    private static Settings defaultInstance = (Settings) SettingsBase.Synchronized((SettingsBase) new Settings());

    public static Settings Default => Settings.defaultInstance;

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("")]
    public string AccessFolder
    {
      get => (string) this[nameof (AccessFolder)];
      set => this[nameof (AccessFolder)] = (object) value;
    }
  }
}
