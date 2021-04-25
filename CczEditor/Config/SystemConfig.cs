using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using System.IO;

namespace CczEditor
{
    [Serializable]
    public class SystemConfig
    {
        private SystemConfig() { }
        public static SystemConfig Inst { get; private set; }

        public string CurrentConfig;

        public static string DefaultSystemConfigFileName = "CczEditor.json";
        public static readonly string DefaultConfigName = "CczEditor-Star 6.1.json";

        public static SystemConfig Read(string fileName)
        {
            if (File.Exists(fileName))
            {
                var json = File.ReadAllText(fileName);
                Inst = JsonConvert.DeserializeObject<SystemConfig>(json);
            }
            else
            {
                Inst = CreateDefaultSystemConfig();
                Write(DefaultSystemConfigFileName);
            }
            return Inst;
        }

        public static void Write(string fileName)
        {
            if(Inst == null)
                Inst = CreateDefaultSystemConfig();
            var json = JsonConvert.SerializeObject(Inst, Formatting.Indented);
            File.WriteAllText(fileName, json);
        }

        private static SystemConfig CreateDefaultSystemConfig()
        {
            var result = new SystemConfig();
            Config defaultConfig;
            if (File.Exists(DefaultConfigName))
                defaultConfig = Config.Read(DefaultConfigName);
            else
                defaultConfig = CreateDefaultConfig();

            Config.Write(defaultConfig, DefaultConfigName);

            result.CurrentConfig = DefaultConfigName;
            return result;
        }

        public static Config CreateDefaultConfig()
        {
            var handler = new Star61ConfigCreateHandler();
            return handler.Execute();
        }
        
    }
}
