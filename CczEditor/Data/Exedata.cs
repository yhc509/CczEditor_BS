#region using List

using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;


#endregion

namespace CczEditor.Data
{
    public static class ExeData
    {
        private static string ExePath
        {
            get
            {
                var config = Config.Read(SystemConfig.Inst.CurrentConfig);
                var path = config.DirectoryPath;
                var exeFileName = config.ExeFileName;

                return Path.Combine(path, exeFileName);
            }
        }

        public static bool IsLocked
        {
            get
            {
                try
                {
                    var CurrentFile = new FileInfo(ExePath);
                    using (FileStream stream = CurrentFile.Open(FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
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
        
        private static FileStream Stream;

        public static void Open(FileAccess accessType)
        {
            var CurrentFile = new FileInfo(ExePath);
            Stream = CurrentFile.Open(FileMode.Open, accessType, FileShare.ReadWrite);
        }

        public static void Close()
        {
            if (Stream != null) {
                Stream.Flush();
                Stream.Close();
                Stream = null;
            }
        }

        public static string GetText(int offset, int length)
        {
            byte[] text = new byte[length];

            if (Stream == null)
            {
                var CurrentFile = new FileInfo(ExePath);
                using (var stream = CurrentFile.Open(FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                {
                    stream.Seek(offset, SeekOrigin.Begin);
                    stream.Read(text, 0, length);
                    stream.Close();
                }
            }
            else
            {
                Stream.Seek(offset, SeekOrigin.Begin);
                Stream.Read(text, 0, length);
            }
            return Utils.ByteToString(text);
        }
                         
        public static ushort ReadWord(int select,int offset)
        {
            var binary = new byte[2];

            if (Stream == null)
            {
                var CurrentFile = new FileInfo(ExePath);
                using (var stream = CurrentFile.Open(FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                {
                    stream.Seek(offset + select * 2, SeekOrigin.Begin);
                    stream.Read(binary, 0, 2);
                    stream.Close();
                }
            }
            else
            {
                Stream.Seek(offset + select * 2, SeekOrigin.Begin);
                Stream.Read(binary, 0, 2);
            }
            return (ushort) (binary[0] + binary[1] * 0x100);
        }

        public static void WriteWord(int value,int select,int offset)
        {
            var binary = BitConverter.GetBytes((short)value);
            if (Stream == null)
            {
                var CurrentFile = new FileInfo(ExePath);
                using (var stream = CurrentFile.Open(FileMode.Open, FileAccess.Write, FileShare.ReadWrite))
                {
                    stream.Seek(offset + select * 2, SeekOrigin.Begin);
                    stream.Write(binary, 0, 2);
                    stream.Flush();
                    stream.Close();
                }
            }
            else
            {
                Stream.Seek(offset + select * 2, SeekOrigin.Begin);
                Stream.Write(binary, 0, 2);
            }
        }
        
        public static byte ReadByte(int select, int offset)
        {
            var binary = new byte[1];
            if (Stream == null)
            {
                var CurrentFile = new FileInfo(ExePath);
                using (var stream = CurrentFile.Open(FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                {
                    stream.Seek(offset + select, SeekOrigin.Begin);
                    stream.Read(binary, 0, 1);
                    stream.Close();
                }
            }
            else
            {
                Stream.Seek(offset + select, SeekOrigin.Begin);
                Stream.Read(binary, 0, 1);
            }
            return (binary[0]);
        }

        public static void WriteByte(int value, int select, int offset)
        {
            var binary = BitConverter.GetBytes((short)value);
            if (Stream == null)
            {
                var CurrentFile = new FileInfo(ExePath);
                using (var stream = CurrentFile.Open(FileMode.Open, FileAccess.Write, FileShare.ReadWrite))
                {
                    stream.Seek(offset + select, SeekOrigin.Begin);
                    stream.Write(binary, 0, 1);
                    stream.Flush();
                    stream.Close();
                }
            }
            else
            {
                Stream.Seek(offset + select, SeekOrigin.Begin);
                Stream.Write(binary, 0, 1);
            }
        }

        public static void WriteText(string text, int offset, int length)
        {
            var binary = new byte[length];
            Utils.ChangeByteValue(binary, Utils.GetBytes(text), 0, length);
            if (Stream == null)
            {
                var CurrentFile = new FileInfo(ExePath);
                using (var stream = CurrentFile.Open(FileMode.Open, FileAccess.Write, FileShare.ReadWrite))
                {
                    stream.Seek(offset, SeekOrigin.Begin);
                    stream.Write(binary, 0, length);
                    stream.Flush();
                    stream.Close();
                }
            }
            else
            {
                Stream.Seek(offset, SeekOrigin.Begin);
                Stream.Write(binary, 0, length);
            }
        }

        public static void Write(byte[] values, int offset)
        {
            if (Stream == null)
            {
                var CurrentFile = new FileInfo(ExePath);
                using (var stream = CurrentFile.Open(FileMode.Open, FileAccess.Write, FileShare.ReadWrite))
                {
                    stream.Seek(offset, SeekOrigin.Begin);
                    stream.Write(values, 0, values.Length);
                    stream.Flush();
                    stream.Close();
                }
            }
            else
            {
                Stream.Seek(offset, SeekOrigin.Begin);
                Stream.Write(values, 0, values.Length);
            }

        }
        
        public static byte[] Read(int offset, int length)
        {
            var binary = new byte[length];
            if (Stream == null)
            {
                var CurrentFile = new FileInfo(ExePath);
                using (var stream = CurrentFile.Open(FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                {
                    stream.Seek(offset, SeekOrigin.Begin);
                    stream.Read(binary, 0, length);
                    stream.Close();
                }
            }
            else
            {
                Stream.Seek(offset, SeekOrigin.Begin);
                Stream.Read(binary, 0, length);
            }
            return binary;
        }

    }
}
