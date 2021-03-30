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
                var config = Config.New.Config.Read(Config.New.SystemConfig.Inst.CurrentConfig);
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

        public static string GetText(int offset, int length)
        {
            byte[] text = new byte[length];

            var CurrentFile = new FileInfo(ExePath);
            using (var stream = CurrentFile.Open(FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                stream.Seek(offset, SeekOrigin.Begin);
                stream.Read(text, 0, length);
                stream.Close();
            }
            return Utils.ByteToString(text);
        }
                         
        public static ushort ReadWord(int select,int offset)
        {
            var binary = new byte[2];
            var CurrentFile = new FileInfo(ExePath);
            using (var stream = CurrentFile.Open(FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                stream.Seek(offset + select * 2, SeekOrigin.Begin);
                stream.Read(binary, 0, 2);
                stream.Close();
            }
            return (ushort) (binary[0] + binary[1] * 0x100);
        }

        public static void WriteWord(int value,int select,int offset)
        {
            var binary = BitConverter.GetBytes((short)value);
            var CurrentFile = new FileInfo(ExePath);
            using (var stream = CurrentFile.Open(FileMode.Open, FileAccess.Write, FileShare.Write))
            {
                stream.Seek(offset + select * 2, SeekOrigin.Begin);
                stream.Write(binary, 0, 2);
                stream.Flush();
                stream.Close();
            }
        }
        
        public static byte ReadByte(int select, int offset)
        {
            var binary = new byte[1];
            var CurrentFile = new FileInfo(ExePath);
            using (var stream = CurrentFile.Open(FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                stream.Seek(offset + select, SeekOrigin.Begin);
                stream.Read(binary, 0, 1);
                stream.Close();
            }
            return (binary[0]);
        }

        public static void WriteByte(int value, int select, int offset)
        {
            var binary = BitConverter.GetBytes((short)value);
            var CurrentFile = new FileInfo(ExePath);
            using (var stream = CurrentFile.Open(FileMode.Open, FileAccess.Write, FileShare.Write))
            {
                stream.Seek(offset + select, SeekOrigin.Begin);
                stream.Write(binary, 0, 1);
                stream.Flush();
                stream.Close();
            }
        }

        /*
        public void bomulsave(int count)
        {
            
            var offset = 0x6FF8C;
            var temp = new byte[1];

            var CurrentFile = new FileInfo(ExePath);
            using (var CurrentStream = CurrentFile.Open(FileMode.Open, FileAccess.Write, FileShare.Write))
            {
                CurrentStream.Seek(offset, SeekOrigin.Begin);
                CurrentStream.WriteByte((byte)(count - 1));
            }
         }*/

        /*
          //책략
          public byte magicload(int select, int offset)
          {
            CurrentStream.Seek(offset + select, SeekOrigin.Begin);
                CurrentStream.Read(byte1, 0, 1);
                return byte1[0];
          }
          public void magicsave(int select, int offset, byte magic)
          {
              byte1[0] = magic;
              CurrentStream.Seek((int)offset + select, SeekOrigin.Begin);
              CurrentStream.Write(byte1, 0, 1);
          }

        // 책략세부
          public byte detailload(int select,int choice,int offset)
          {
              int magicoffset = offset + (choice*8) + (select*0xab);
              CurrentStream.Seek(magicoffset, SeekOrigin.Begin);
              CurrentStream.Read(byte1, 0, 1);
              return byte1[0];
          }
          public void detailsave(int select, int choice, int offset, byte value)
          {
              byte1[0] = value;
              int magicoffset = offset + (choice * 8) + (select * 0xab);
              CurrentStream.Seek(magicoffset, SeekOrigin.Begin);
              CurrentStream.Write(byte1, 0, 1);
          }
        //회심대사
          public byte readCritical(int SelectedIndex)
          {
              int offset = Program.CurrentConfig.Exe.CriticalOffset + SelectedIndex * 4;
              CurrentStream.Seek(offset, SeekOrigin.Begin);
              CurrentStream.Read(byte1, 0, 1);
              return byte1[0];
          }
          public void saveCritical(int SelectedIndex,int index)
          {
              int offset = Program.CurrentConfig.Exe.CriticalOffset + SelectedIndex * 4;
              byte1 = BitConverter.GetBytes((short)index);
              CurrentStream.Seek(offset, SeekOrigin.Begin);
              CurrentStream.Write(byte1, 0, 1);
          }
        //병종설정
          public byte forceload(int select, string choice)
          {
              int magicoffset = Program.CurrentConfig.Offsets[choice];              
              CurrentStream.Seek((int)magicoffset + select, SeekOrigin.Begin);
              CurrentStream.Read(byte1, 0, 1);
              return byte1[0];
            return 0;
          }
          public void forcesave(int select, string choice, byte magic)
          {
              int magicoffset = Program.CurrentConfig.Offsets[choice];  
              byte1[0] = magic;
              CurrentStream.Seek((int)magicoffset + select, SeekOrigin.Begin);
              CurrentStream.Write(byte1, 0, 1);
          }
          //유동적
          public void code(byte[] bytes,int offset,int length)
          {
              var temp = new byte[length];
              CurrentStream.Seek(offset, SeekOrigin.Begin);
              CurrentStream.Write(bytes, 0, length);
          }
        */
    }
}
