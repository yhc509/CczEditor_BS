using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace CczEditor
{
    public static class ConfigManager
    {
        public static Dictionary<string, string> GetConfigs()
        {
            var prefixName = Path.GetFileNameWithoutExtension(Application.ExecutablePath);

            var files = Directory.GetFiles(Application.StartupPath, $"{prefixName}-*.json", SearchOption.TopDirectoryOnly).ToList();
            var typeNames = new Dictionary<string, string>();
            string displayName;
            Match match;
            var regex = new Regex(string.Format("{0}-(.*).json", Path.GetFileNameWithoutExtension(Application.ExecutablePath)));
            foreach (var filePath in files)
            {
                var config = Config.Read(filePath);
                var fileName = Path.GetFileName(filePath);
                displayName = config.DisplayName;

                if (!string.IsNullOrEmpty(displayName))
                {
                    typeNames.Add(fileName, displayName);
                }
            }
            return typeNames;
        }
        
    }
}
