using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CczEditor.Data.Wrapper
{
    public class SpecialSkillData
    {
        public string Name;
        public ushort[] Units;
        public byte[] Levels;
        public byte Value;

        public void Read(int index, ExeData exeData, Config config)
        {
            ReadExeData(index, exeData, config);
        }

        public void ReadExeData(int index, ExeData targetData, Config config)
        {
            targetData.Open(System.IO.FileAccess.ReadWrite);

            Name = ConfigUtils.GetSpecialSkillName(Program.ExeData, Program.CurrentConfig, index);

            bool isPhysics = index <= config.Exe.SpecialSkillPhysicsCount;

            if (isPhysics)
            {
                int offset = config.Exe.SpecialSkillOffset;

                Units = new ushort[5];
                Levels = new byte[5];
                Units[0] = targetData.ReadWord(0, offset + index * 0x10);
                Levels[0] = targetData.ReadByte(0, offset + index * 0x10 + 0x02);
                Units[1] = targetData.ReadWord(0, offset + index * 0x10 + 0x03);
                Levels[1] = targetData.ReadByte(0, offset + index * 0x10 + 0x05);
                Units[2] = targetData.ReadWord(0, offset + index * 0x10 + 0x06);
                Levels[2] = targetData.ReadByte(0, offset + index * 0x10 + 0x08);
                Units[3] = targetData.ReadWord(0, offset + index * 0x10 + 0x09);
                Levels[3] = targetData.ReadByte(0, offset + index * 0x10 + 0x0B);
                Units[4] = targetData.ReadWord(0, offset + index * 0x10 + 0x0C);
                Levels[4] = targetData.ReadByte(0, offset + index * 0x10 + 0x0E);

                Value = targetData.ReadByte(0, offset + index * 0x10 + 0x0F);
            }
            targetData.Close();
        }
        
        public void Write(int index, ExeData exeData, Config config)
        {
            WriteExeData(index, exeData, config);
        }

        public void WriteExeData(int index, ExeData targetData, Config config)
        {
            var info = config.SpecialSkillNames.Find(x => x.Index == index);

            byte[] result = new byte[0x0E];
            targetData.Open(System.IO.FileAccess.ReadWrite);
            targetData.WriteText(Name, info.Offset, 0x0E);

            bool isPhysics = index <= config.Exe.SpecialSkillPhysicsCount;

            if (isPhysics)
            {
                int offset = config.Exe.SpecialSkillOffset;
                targetData.WriteWord(Units[0], 0, offset + index * 0x10);
                targetData.WriteByte(Levels[0], 0, offset + index * 0x10 + 0x02);
                targetData.WriteWord(Units[1], 0, offset + index * 0x10 + 0x03);
                targetData.WriteByte(Levels[1], 0, offset + index * 0x10 + 0x05);
                targetData.WriteWord(Units[2], 0, offset + index * 0x10 + 0x06);
                targetData.WriteByte(Levels[2], 0, offset + index * 0x10 + 0x08);
                targetData.WriteWord(Units[3], 0, offset + index * 0x10 + 0x09);
                targetData.WriteByte(Levels[3], 0, offset + index * 0x10 + 0x0C);
                targetData.WriteWord(Units[4], 0, offset + index * 0x10 + 0x0C);
                targetData.WriteByte(Levels[4], 0, offset + index * 0x10 + 0x0E);

                Program.ExeData.WriteByte(Value, 0, offset + index * 0x10 + 0x0F);
            }
            Program.ExeData.Close();
        }
        
    }
}
