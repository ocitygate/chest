using System;
using System.Reflection;

[assembly: Obfuscation(Feature = "encrypt symbol names with password XXXXXXXX", Exclude = true)]
[assembly: Obfuscation(Feature = "rename symbol names with printable characters", Exclude = true)]
[assembly: Obfuscation(Feature = "string encryption", Exclude = false)]
[assembly: Obfuscation(Feature = "code control flow obfuscation", Exclude = false)]
//[assembly: Obfuscation(Feature = "merge with CS.dll", Exclude = false)]
[assembly: Obfuscation(Feature = "rename serializable symbols", Exclude = false)]
[assembly: Obfuscation(Feature = "encrypt serializable symbol names with password 'XXXXXXXX'", Exclude = true)]