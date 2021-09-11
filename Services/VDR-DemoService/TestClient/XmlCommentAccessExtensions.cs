using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml;

namespace System.Reflection {

  //inspired by: https://docs.microsoft.com/en-us/archive/msdn-magazine/2019/october/csharp-accessing-xml-documentation-via-reflection

  /// <summary> extension methods to read summary and parameter documentation from the xml-file (if exsists) </summary>
  public static class XmlCommentAccessExtensions {

    internal static string[] RequireXmlDocForNamespaces = new string[] { };

    internal static HashSet<Assembly> loadedAssemblies = new HashSet<Assembly>();
    internal static Dictionary<string, string> loadedXmlDocumentation = new Dictionary<string, string>();

    /// <summary> reads summary and parameter documentation from the xml-file (if exsists) </summary>
    public static string GetDocumentation(this Type type, bool singleLine = true) {
      string rawDoc = GetRawXmlDocumentationForType(type);
      return PickSummaryFromXml(rawDoc, singleLine);
    }

    /// <summary> reads summary and parameter documentation from the xml-file (if exsists) </summary>
    public static string GetDocumentation(this PropertyInfo propertyInfo, bool singleLine = true) {
      string rawDoc = GetRawXmlDocumentationForProperty(propertyInfo);
      return PickSummaryFromXml(rawDoc, singleLine);
    }

    /// <summary> reads summary and parameter documentation from the xml-file (if exsists) </summary>
    public static string GetDocumentation(this MethodInfo methodInfo, bool singleLine = true) {
      string rawDoc = GetRawXmlDocumentationForMethod(methodInfo);
      return PickSummaryFromXml(rawDoc, singleLine);
    }

    /// <summary> reads summary and parameter documentation from the xml-file (if exsists) </summary>
    public static string GetDocumentation(this FieldInfo fieldInfo, bool singleLine = true) {
      string rawDoc = GetRawXmlDocumentationForField(fieldInfo);
      return PickSummaryFromXml(rawDoc, singleLine);
    }

    /// <summary> reads summary and parameter documentation from the xml-file (if exsists) </summary>
    public static string GetDocumentation(this EventInfo eventInfo, bool singleLine = true) {
      string rawDoc = GetRawXmlDocumentationForEvent(eventInfo);
      return PickSummaryFromXml(rawDoc, singleLine);
    }

    /// <summary> reads summary and parameter documentation from the xml-file (if exsists) </summary>
    public static string GetDocumentation(this ParameterInfo parameterInfo, bool singleLine = true) {
      LoadXmlDocumentation(parameterInfo.Member.DeclaringType.Assembly, parameterInfo.Member.DeclaringType.Namespace);
      if (parameterInfo.Member.MemberType.HasFlag(MemberTypes.Method)) {
        string rawDoc = GetRawXmlDocumentationForMethod((MethodInfo)parameterInfo.Member);
        return PickParamFromXml(rawDoc, parameterInfo.Name, singleLine);
      }
      return null;
    }

    /// <summary> reads summary and parameter documentation from the xml-file (if exsists) </summary>
    public static string GetDocumentation(this MemberInfo memberInfo, bool singleLine = true) {
      LoadXmlDocumentation(memberInfo.DeclaringType.Assembly, memberInfo.DeclaringType.Namespace);

      if (memberInfo.MemberType.HasFlag(MemberTypes.Property)) {
        return ((PropertyInfo)memberInfo).GetDocumentation(singleLine);
      }
      else if (memberInfo.MemberType.HasFlag(MemberTypes.Field)) {
        return ((FieldInfo)memberInfo).GetDocumentation(singleLine);
      }
      else if (memberInfo.MemberType.HasFlag(MemberTypes.Event)) {
        return ((EventInfo)memberInfo).GetDocumentation(singleLine);
      }
      else if (memberInfo.MemberType.HasFlag(MemberTypes.Method)) {
        return ((MethodInfo)memberInfo).GetDocumentation(singleLine);
      }
      else if (memberInfo.MemberType.HasFlag(MemberTypes.TypeInfo) || memberInfo.MemberType.HasFlag(MemberTypes.NestedType)) {
        //return ((TypeInfo)memberInfo).AsType().GetDocumentation(singleLine);
        return GetDocumentation(Type.GetType(((TypeInfo)memberInfo).AssemblyQualifiedName), singleLine);
      }
      else {
        return null;
      }

    }

    private static string GetRawXmlDocumentationForType(this Type type) {
      LoadXmlDocumentation(type.Assembly, type.Namespace);

      string key = "T:" + BuildMemberKeyString(type.FullName, null);
      loadedXmlDocumentation.TryGetValue(key, out string documentation);

      return documentation;
    }

    private static string GetRawXmlDocumentationForProperty(this PropertyInfo propertyInfo, bool singleLine = true) {
      LoadXmlDocumentation(propertyInfo.DeclaringType.Assembly, propertyInfo.DeclaringType.Namespace);
     
      string key = "P:" + BuildMemberKeyString(propertyInfo.DeclaringType.FullName, propertyInfo.Name);
      loadedXmlDocumentation.TryGetValue(key, out string documentation);

      return documentation;
    }

    private static string GetRawXmlDocumentationForMethod(MethodInfo methodInfo) {
      LoadXmlDocumentation(methodInfo.DeclaringType.Assembly, methodInfo.DeclaringType.Namespace);

      var paramTypeNames = methodInfo.GetParameters().Select((p) => p.ParameterType.FullName).ToArray();
      string paramSignature = "";
      if (paramTypeNames.Length > 0) { //no () when no param!!!!
        paramSignature = "(" + String.Join(",", paramTypeNames) + ")";
      }

      string key = "M:" + BuildMemberKeyString(methodInfo.DeclaringType.FullName, methodInfo.Name) + paramSignature;
      loadedXmlDocumentation.TryGetValue(key, out string documentation);

      return documentation;
    }

    private static string GetRawXmlDocumentationForField(this FieldInfo fieldInfo, bool singleLine = true) {
      LoadXmlDocumentation(fieldInfo.DeclaringType.Assembly, fieldInfo.DeclaringType.Namespace);
     
      string key = "F:" + BuildMemberKeyString(fieldInfo.DeclaringType.FullName, fieldInfo.Name);
      loadedXmlDocumentation.TryGetValue(key, out string documentation);

      return documentation;
    }

    private static string GetRawXmlDocumentationForEvent(this EventInfo eventInfo, bool singleLine = true) {
      LoadXmlDocumentation(eventInfo.DeclaringType.Assembly, eventInfo.DeclaringType.Namespace);

      string key = "E:" + BuildMemberKeyString(eventInfo.DeclaringType.FullName, eventInfo.Name);
      loadedXmlDocumentation.TryGetValue(key, out string documentation);

      return documentation;
    }

    private static void LoadXmlDocumentation(Assembly assembly, string ns) {
      if (loadedAssemblies.Contains(assembly)) {
        return; // already loaded
      }
      string directoryPath = assembly.GetDirectoryPath();
      string xmlFilePath = Path.Combine(directoryPath, assembly.GetName().Name + ".xml");
      if (File.Exists(xmlFilePath)) {
        ReadXmlDocumentation(File.ReadAllText(xmlFilePath));
        loadedAssemblies.Add(assembly);
      }
      else {
        foreach (string n in RequireXmlDocForNamespaces) {
          if (ns.StartsWith(n)) {
            throw new Exception("Cannot find XML-Doc file '" + xmlFilePath + "'");
          }
        }
      }
    }

    private static void ReadXmlDocumentation(string xmlDocumentation) {
      using (XmlReader xmlReader = XmlReader.Create(new StringReader(xmlDocumentation))) {
        while (xmlReader.Read()) {
          if (xmlReader.NodeType == XmlNodeType.Element && xmlReader.Name == "member") {
            string raw_name = xmlReader["name"];
            loadedXmlDocumentation[raw_name] = xmlReader.ReadInnerXml();
          }
        }
      }
    }

    private static string GetDirectoryPath(this Assembly assembly) {
      string codeBase = assembly.Location;
      UriBuilder uri = new UriBuilder(codeBase);
      string path = Uri.UnescapeDataString(uri.Path);
      return Path.GetDirectoryName(path);
    }

    private static string BuildMemberKeyString(string typeFullNameString, string memberNameString) {
      string key = Regex.Replace(
        typeFullNameString, @"\[.*\]",
        string.Empty).Replace('+', '.'
      );
      if (memberNameString != null) {
        key += "." + memberNameString;
      }
      return key;
    }

    private static string PickParamFromXml(string documentation, string paramName, bool singleLine) {
      if (documentation != null) {
        string regexPattern =
          Regex.Escape(@"<param name=" + "\"" + paramName + "\"" + @">") +
          ".*?" +
          Regex.Escape(@"</param>");
        Match match = Regex.Match(documentation, regexPattern, RegexOptions.Singleline | RegexOptions.IgnoreCase);
        if (match.Success) {
          return MultiLineTrim(match.Value.Substring(15 + paramName.Length, match.Value.Length - 23 - paramName.Length), singleLine);
        }
      }
      return null;
    }

    private static string PickSummaryFromXml(string documentation, bool singleLine) {
      if (documentation != null) {
        string regexPattern =
          Regex.Escape(@"<summary>") +
          ".*?" +
          Regex.Escape(@"</summary>");
        Match match = Regex.Match(documentation, regexPattern, RegexOptions.Singleline | RegexOptions.IgnoreCase);
        if (match.Success) {
          return MultiLineTrim(match.Value.Substring(9, match.Value.Length - 19), singleLine);
        }
      }
      return null;
    }

    private static string MultiLineTrim(string comment, bool singleLine) {

      if(comment == null) {
        return null;
      }

      var result = new StringBuilder();
      var rdr = new StringReader(comment);
      var line = rdr.ReadLine();

      while (line != null) {
        line = line.Trim();
        if (!String.IsNullOrWhiteSpace(line)) {
          if (result.Length > 0) {
            if (singleLine) {
              result.Append(" ");
            }
            else {
              result.AppendLine();
            }
          }
          result.Append(line.Trim());
        }
        line = rdr.ReadLine();
      }

      return result.ToString();
    }


  }
}
