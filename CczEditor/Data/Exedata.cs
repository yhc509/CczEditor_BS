#region using List

using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;


#endregion

namespace CczEditor.Data
{
    public class ExeData : FileData
    {

        byte[] byte2 = new byte[2];
        byte[] byte1 = new byte[1];
        byte[] byte10 = new byte[0x10];

        public ExeData(string fileName) : base(fileName)
        {
        }
        //능력명
        public Dictionary<int, string> EffectsNames(bool hasFormater, Dictionary<int, string> list, int offset, int count)
        {
            var name = new byte[18];
            CurrentStream.Seek(offset, SeekOrigin.Begin);
            CurrentStream.Read(name, 0, 18);
            list.Add(count, hasFormater ? string.Format(Program.FORMATSTRING_KEYVALUEPAIR_HEX2, count, Utils.ByteToString(name)) : Utils.ByteToString(name));
            return list;
        }
        
        //계열명
        public List<string> ForceCategoryNames(bool hasFormater, List<string> list, int offset, int count)
        {
            var name = new byte[8];
            CurrentStream.Seek(offset, SeekOrigin.Begin);
            CurrentStream.Read(name, 0, 8);
            list.Add(hasFormater ? string.Format(Program.FORMATSTRING_KEYVALUEPAIR_HEX2, count, Utils.ByteToString(name)) : Utils.ByteToString(name));
            return list;
        }
        public string ForceCategoryNames2(int offset)
        {
            var name = new byte[8];
            CurrentStream.Seek(offset, SeekOrigin.Begin);
            CurrentStream.Read(name, 0, 8);            
            return Utils.ByteToString(name);
        }
        //병종명
        public List<string> ForceNames(bool hasFormater, List<string> list, int offset, int count)
           {
            var name = new byte[8];
            CurrentStream.Seek(offset, SeekOrigin.Begin);
            CurrentStream.Read(name, 0, 8);
            list.Add(hasFormater ? string.Format(Program.FORMATSTRING_KEYVALUEPAIR_HEX2, count, Utils.ByteToString(name)) : Utils.ByteToString(name));//i
            return list;
        }
        //보물도감
          public void bomulsave(int count)
          {
              var offset = 0x6FF8C;
              var temp = new byte[1];
              CurrentStream.Seek(offset, SeekOrigin.Begin);
              CurrentStream.WriteByte((byte)(count-1));
          }

        //2byte
          public ushort ReadWord(int select,int offset)
          {
              CurrentStream.Seek((int)offset + select * 2, SeekOrigin.Begin);
              CurrentStream.Read(byte2, 0, 2);
              return (ushort) (byte2[0] + byte2[1] * 0x100);
          }

          public void WriteWord(int value,int select,int offset)
          {
              byte2 = BitConverter.GetBytes((short)value);
              CurrentStream.Seek((int)offset + select * 2, SeekOrigin.Begin);
              CurrentStream.Write(byte2, 0, 2);
              
          }

        //1byte
          public byte ReadByte(int select, int offset)
          {
              CurrentStream.Seek((int)offset + select, SeekOrigin.Begin);
              CurrentStream.Read(byte1, 0, 1);
              return (byte1[0]);
          }
          public void WriteByte(int value, int select, int offset)
          {
              byte1 = BitConverter.GetBytes((byte)value);
              CurrentStream.Seek((int)offset + select, SeekOrigin.Begin);
              CurrentStream.Write(byte1, 0, 1);
          }

          //책략
          public byte magicload(int select,string choice)
          {
              int offset=Program.CurrentConfig.Offsets[choice];
              CurrentStream.Seek(offset + select, SeekOrigin.Begin);
              CurrentStream.Read(byte1, 0, 1);
              return byte1[0];
          }
          public void magicsave(int select, string choice, byte magic)
          {
              int offset = Program.CurrentConfig.Offsets[choice];
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
              int offset = Program.CurrentConfig.Offsets["Exe_Critical_Offset"] + SelectedIndex * 4;
              CurrentStream.Seek(offset, SeekOrigin.Begin);
              CurrentStream.Read(byte1, 0, 1);
              return byte1[0];
          }
          public void saveCritical(int SelectedIndex,int index)
          {
              int offset = Program.CurrentConfig.Offsets["Exe_Critical_Offset"] + SelectedIndex * 4;
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

        }	
    }
