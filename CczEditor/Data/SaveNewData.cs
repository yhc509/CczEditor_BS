using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace CczEditor.Data
{
    public class SaveNewData
    {
        
        private static string SavePath(int index)
        {
            var config = Config.Read(SystemConfig.Inst.CurrentConfig);
            var path = config.DirectoryPath;
            var fileName = Path.Combine(Program.CurrentConfig.DirectoryPath, "SV", $"SV{index:D3}.E5S");

            return Path.Combine(path, fileName);
        }

        public static bool IsLocked(int index)
        {
            try
            {
                var CurrentFile = new FileInfo(SavePath(index));
                using (FileStream stream = CurrentFile.Open(FileMode.Open, FileAccess.Read, FileShare.None))
                {
                    stream.Close();
                }
            }
            catch (IOException)
            {
                return true;
            }

            return false;
        }
        
        public static void Write(int saveIndex, byte[] binary, int offset, int length)
        {
            if (IsLocked(saveIndex)) return;
            var path = SavePath(saveIndex);
            var CurrentFile = new FileInfo(path);
            using (var stream = CurrentFile.Open(FileMode.Open, FileAccess.Write, FileShare.Write))
            {
                stream.Seek(offset, SeekOrigin.Begin);
                stream.Write(binary, 0, length);
                stream.Close();
            }
        }
        
    }
}
