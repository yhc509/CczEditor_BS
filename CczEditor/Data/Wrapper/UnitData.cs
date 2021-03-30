using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CczEditor.Data.Wrapper
{
    public class UnitData : WrapperData<UnitData>
    {
        public string Name;
        public ushort Face;

        public byte CriticalIndex;

        public byte Str;
        public byte Vit;
        public byte Int;
        public byte Avg;
        public byte Luk;

        public ushort Hp;
        public byte Mp;
        public byte Force;

        public byte Lv = 1;

        // EXE
        public ushort Pmapobj;
        public ushort BattleObj;
        public byte CharacterType;
        public byte Cutin;
        public byte Voice;
        public byte Cost;

        // Imsg
        public string Imsg;
        public string Retreat;
        

        public void Write(int index)
        {
            byte[] result = new byte[0x48];

            if (Name.Length > 4)
                Name = Name.Substring(0, 4);

            Utils.ChangeByteValue(result, Utils.GetBytes(Name), 0, 12);
            Utils.ChangeByteValue(result, BitConverter.GetBytes(Face), 13);

            result[16] = CriticalIndex;
            
            result[18] = Str;
            result[19] = Vit;
            result[20] = Int;
            result[21] = Avg;
            result[22] = Luk;
            Utils.ChangeByteValue(result, BitConverter.GetBytes(Hp), 23);

            result[25] = Mp;
            result[26] = Force;
            result[27] = Lv;

            if (Program.GameData.IsExist)
            {
                Program.GameData.UnitSet(index, result);
            }

            if (Program.ExeData.IsExist)
            {
                Program.ExeData.WriteWord(Pmapobj, index, Program.CurrentConfig.Offsets["Unit_Pmapobj"]);
                Program.ExeData.WriteWord(BattleObj, index, Program.CurrentConfig.Offsets["Unit_Spc"]);
                Program.ExeData.WriteByte(CharacterType, index, Program.CurrentConfig.Offsets["Unit_Cha"]);
                if (index <= 255)
                {
                    Program.ExeData.WriteByte(Voice, index, Program.CurrentConfig.Offsets["Unit_Voice"]);
                    Program.ExeData.WriteByte(Cost, index, Program.CurrentConfig.Offsets["Unit_Cost"]);
                    Program.ExeData.WriteByte(Cutin, index, Program.CurrentConfig.Offsets["Unit_Cutin"]);
                }
            }
            
            if (Program.ImsgData.IsExist)
            {
                if (Imsg != null)
                {
                    var msg = new byte[Program.IMSG_DATA_BLOCK_LENGTH];
                    Utils.ChangeByteValue(msg, Utils.GetBytes(Imsg), 0, Program.IMSG_DATA_BLOCK_LENGTH);
                    Program.ImsgData.UnitExtensionSet(index, msg);
                }

                if (Retreat != null)
                {
                    var msg = new byte[Program.IMSG_DATA_BLOCK_LENGTH];
                    Utils.ChangeByteValue(msg, Utils.GetBytes(Retreat), 0, Program.IMSG_DATA_BLOCK_LENGTH);
                    Program.ImsgData.RetreatSet(index, msg);
                }
            }
        }

        public void Read(int index)
        {
            if (Program.GameData.IsExist)
            {
                var unit = Program.GameData.UnitGet(index);
                Name = Utils.ByteToString(unit, 0, 12);

                Face = BitConverter.ToUInt16(unit, 13);
                CriticalIndex = unit[16];

                Str = unit[18];
                Vit = unit[19];
                Int = unit[20];
                Avg = unit[21];
                Luk = unit[22];
                Hp = BitConverter.ToUInt16(unit, 23);
                Mp = unit[25];
                Force = unit[26];
                Lv = unit[27];
            }

            if (Program.ExeData.IsExist)
            {
                Pmapobj = Program.ExeData.ReadWord(index, Program.CurrentConfig.Offsets["Unit_Pmapobj"]);
                BattleObj = Program.ExeData.ReadWord(index, Program.CurrentConfig.Offsets["Unit_Spc"]);
                CharacterType = Program.ExeData.ReadByte(index, Program.CurrentConfig.Offsets["Unit_Cha"]);
                if (index <= 255)
                {
                    Voice = Program.ExeData.ReadByte(index, Program.CurrentConfig.Offsets["Unit_Voice"]);
                    Cutin = Program.ExeData.ReadByte(index, Program.CurrentConfig.Offsets["Unit_Cutin"]);
                    Cost = Program.ExeData.ReadByte(index, Program.CurrentConfig.Offsets["Unit_Cost"]);
                }
            }

            if (Program.ImsgData.IsExist)
            {
                Imsg = Utils.ByteToString(Program.ImsgData.UnitExtensionGet(index), 0, Program.IMSG_DATA_BLOCK_LENGTH);
                Retreat = Utils.ByteToString(Program.ImsgData.RetreatGet(index), 0, Program.IMSG_DATA_BLOCK_LENGTH);
            }
        }

        public UnitData Clone()
        {
            var result = this.Clone<UnitData>();
            return result;
        }

    }
}
