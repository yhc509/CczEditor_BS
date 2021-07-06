using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CczEditor.Data.Wrapper
{
    public class SpecialEffectData
    {
        public string Name;
        public ushort[] Units;
        public byte Force;
        public byte Value;
        
        public void Read(int index, ExeData exeData, Config config)
        {
            ReadExeData(index, exeData, config);
        }

        public void ReadExeData(int index, ExeData targetData, Config config)
        {
            Name = ConfigUtils.GetSpecialEffectName(targetData, config, index);

            int offset = config.Exe.SpecialEffectOffset;
            targetData.Open(System.IO.FileAccess.ReadWrite);
            Units = new ushort[3];
            Units[0] = targetData.ReadWord(0, offset + index * 0x08);
            Units[1] = targetData.ReadWord(0, offset + index * 0x08 + 0x02);
            Units[2] = targetData.ReadWord(0, offset + index * 0x08 + 0x04);

            byte force = targetData.ReadByte(0, offset + index * 0x08 + 0x6);
            if (force == 0xFF) force = 0x50;
            Force = force;
            Value = targetData.ReadByte(0, offset + index * 0x08 + 0x7);

            targetData.Close();
        }
        
        public void Write(int index, ExeData targetData, Config config)
        {
            WriteExeData(index, targetData, config);
        }

        public void WriteExeData(int index, ExeData targetData, Config config)
        {
            var info = config.SpecialEffectNames.Find(x => x.Index == index);

            byte[] result = new byte[0x0D];
            targetData.WriteText(Name, info.Offset, 0x0D);

            int offset = config.Exe.SpecialEffectOffset;
            targetData.Open(System.IO.FileAccess.ReadWrite);
            targetData.WriteWord(Units[0], 0, offset + index * 0x08);
            targetData.WriteWord(Units[1], 0, offset + index * 0x08 + 0x02);
            targetData.WriteWord(Units[2], 0, offset + index * 0x08 + 0x04);
            
            if (Force == 0x50) Force = 0xFF;
            targetData.WriteByte(Force, 0, offset + index * 0x08 + 0x6);

            targetData.WriteByte(Value, 0, offset + index * 0x08 + 0x7);
            targetData.Close();
        }
        
    }
}
