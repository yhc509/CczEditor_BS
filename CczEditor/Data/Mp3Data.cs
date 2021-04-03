using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace CczEditor.Data
{
    public class Mp3Data
    {
        private static string FilePath
        {
            get
            {
                var config = Config.Read(SystemConfig.Inst.CurrentConfig);
                var path = config.DirectoryPath;
                var fileName = "mp3serv.dat";

                return Path.Combine(path, fileName);
            }
        }

        public static bool IsLocked
        {
            get
            {
                try
                {
                    var CurrentFile = new FileInfo(FilePath);
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
        }

        public static void WriteText(string text, int offset, int length)
        {
            var binary = new byte[length];
            Utils.ChangeByteValue(binary, Utils.GetBytes(text), 0, length);
            var CurrentFile = new FileInfo(FilePath);
            using (var stream = CurrentFile.Open(FileMode.Open, FileAccess.Write, FileShare.Write))
            {
                stream.Seek(offset, SeekOrigin.Begin);
                stream.Write(binary, 0, length);
                stream.Flush();
                stream.Close();
            }
        }

    }
}
