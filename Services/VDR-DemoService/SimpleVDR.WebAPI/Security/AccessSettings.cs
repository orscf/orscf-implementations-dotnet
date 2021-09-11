using MedicalResearch.VisitData.WebAPI;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Text;
using System.Text.Json;
using WebAPI;

namespace Security {

  public class AccessSettings {

    #region deserialization

    private static AccessSettings _Current = null;
    public static AccessSettings Current {
      get {
        if (_Current == null) {
          string accessSettingsFileName = Startup.Configuration.GetValue<string>("AccessSettingsFileName");
          string rawFileContent = File.ReadAllText(accessSettingsFileName, Encoding.Default);
          _Current = JsonSerializer.Deserialize<AccessSettings>(rawFileContent);
        }
        return _Current;
      }
    }

    #endregion

    public SubjectProfileConfigurationEntry[] SubjectProfiles { get; set; }
    public string JwtSignKey { get; set; }
    public string[] JwtAllowedIssuers { get; set; }

  }

  public class SubjectProfileConfigurationEntry {

    public string SubjectName { get; set; }

    public string SubjectTitle { get; set; } = "";

    public bool Disabled { get; set; } = false;

    public String[] AllowedHosts { get; set; }

    public String[] Permissions { get; set; }

    public String[] DenyPermissions { get; set; }

    public string ScopeToStudyIdentifier { get; set; }

    public string ScopeToExecutingInstituteIdentifier { get; set; }

  }
}
