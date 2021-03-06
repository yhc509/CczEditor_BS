#region using List

using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;


#endregion

namespace CczEditor.Data
{
    public class ExeData
    {
        private string _filePath;

        public ExeData(string filePath)
        {
            _filePath = filePath;
        }

        public bool IsLocked
        {
            get
            {
                try
                {
                    var CurrentFile = new FileInfo(_filePath);
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
        
        private FileStream Stream;

        public void Open(FileAccess accessType)
        {
            if (Stream != null) return;

            var CurrentFile = new FileInfo(_filePath);
            Stream = CurrentFile.Open(FileMode.Open, accessType, FileShare.ReadWrite);
        }

        public void Close()
        {
            if (Stream != null) {
                Stream.Flush();
                Stream.Close();
                Stream = null;
            }
        }

        public string GetText(int offset, int length)
        {
            byte[] text = new byte[length];

            if (Stream == null)
            {
                var CurrentFile = new FileInfo(_filePath);
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
                         
        public ushort ReadWord(int select,int offset)
        {
            var binary = new byte[2];

            if (Stream == null)
            {
                var CurrentFile = new FileInfo(_filePath);
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

        public void WriteWord(int value,int select,int offset)
        {
            var binary = BitConverter.GetBytes((short)value);
            if (Stream == null)
            {
                var CurrentFile = new FileInfo(_filePath);
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
        
        public byte ReadByte(int select, int offset)
        {
            var binary = new byte[1];
            if (Stream == null)
            {
                var CurrentFile = new FileInfo(_filePath);
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

        public void WriteByte(int value, int select, int offset)
        {
            var binary = BitConverter.GetBytes((short)value);
            if (Stream == null)
            {
                var CurrentFile = new FileInfo(_filePath);
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

        public void WriteText(string text, int offset, int length)
        {
            var binary = new byte[length];
            Utils.ChangeByteValue(binary, Utils.GetBytes(text), 0, length);
            if (Stream == null)
            {
                var CurrentFile = new FileInfo(_filePath);
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

        public void Write(byte[] values, int offset)
        {
            if (Stream == null)
            {
                var CurrentFile = new FileInfo(_filePath);
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
        
        public byte[] Read(int offset, int length)
        {
            var binary = new byte[length];
            if (Stream == null)
            {
                var CurrentFile = new FileInfo(_filePath);
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
