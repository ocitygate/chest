// Decompiled with JetBrains decompiler
// Type: JoyJoyFileServer.Properties.Resources
// Assembly: JoyJoyFileServer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 57CCF9A9-B579-4A8A-9152-530B789099A7
// Assembly location: C:\Users\Matthew\Downloads\JJFS_v100\forWin\JoyJoyFileServer.exe

using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

namespace JoyJoyFileServer.Properties
{
  [GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "15.0.0.0")]
  [DebuggerNonUserCode]
  [CompilerGenerated]
  internal class Resources
  {
    private static ResourceManager resourceMan;
    private static CultureInfo resourceCulture;

    [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
    internal Resources()
    {
    }

    [EditorBrowsable(EditorBrowsableState.Advanced)]
    internal static ResourceManager ResourceManager
    {
      get
      {
        if (JoyJoyFileServer.Properties.Resources.resourceMan == null)
          JoyJoyFileServer.Properties.Resources.resourceMan = new ResourceManager("JoyJoyFileServer.Properties.Resources", typeof (JoyJoyFileServer.Properties.Resources).Assembly);
        return JoyJoyFileServer.Properties.Resources.resourceMan;
      }
    }

    [EditorBrowsable(EditorBrowsableState.Advanced)]
    internal static CultureInfo Culture
    {
      get => JoyJoyFileServer.Properties.Resources.resourceCulture;
      set => JoyJoyFileServer.Properties.Resources.resourceCulture = value;
    }

    internal static byte[] INSTPROG => (byte[]) JoyJoyFileServer.Properties.Resources.ResourceManager.GetObject(nameof (INSTPROG), JoyJoyFileServer.Properties.Resources.resourceCulture);
  }
}
