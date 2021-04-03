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
            
            Utils.ChangeByteValue(result, Utils.GetBytes(Name), 0, 12);
            Utils.ChangeByteValue(result, BitConverter.GetBytes(Face), 13);

            result[16] = CriticalIndex;

            result[17] = 0xFF;
            result[18] = Str;
            result[19] = Vit;
            result[20] = Int;
            result[21] = Avg;
            result[22] = Luk;
            Utils.ChangeByteValue(result, BitConverter.GetBytes(Hp), 23);

            result[25] = Mp;
            result[26] = Force;
            result[27] = Lv;

            result[29] = 0xFF;
            result[30] = 0xFF;
            result[31] = 0xFF;

            if (Program.GameData.IsExist)
            {
                Program.GameData.UnitSet(index, result);
            }

            if (!ExeData.IsLocked)
            {
                ExeData.WriteWord(Pmapobj, index, Program.CurrentConfig.Exe.UnitPmapObjOffset);
                ExeData.WriteWord(BattleObj, index, Program.CurrentConfig.Exe.UnitBattleObjOffset);
                ExeData.WriteByte(CharacterType, index, Program.CurrentConfig.Exe.UnitCharacterOffset);
                if (index <= 255)
                {
                    if(Program.CurrentConfig.CodeOptionContainer.UseVoice)
                        ExeData.WriteByte(Voice, index, Program.CurrentConfig.Exe.UnitVoiceOffset);
                    if (Program.CurrentConfig.CodeOptionContainer.UseCost)
                        ExeData.WriteByte(Cost, index, Program.CurrentConfig.Exe.UnitCostOffset);
                    if (Program.CurrentConfig.CodeOptionContainer.UseCutin)
                        ExeData.WriteByte(Cutin, index, Program.CurrentConfig.Exe.UnitCutinOffset);
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

                if (index < Program.IMSG_RETREAT_COUNT)
                {
                    if (Retreat != null)
                    {
                        var msg = new byte[Program.IMSG_DATA_BLOCK_LENGTH];
                        Utils.ChangeByteValue(msg, Utils.GetBytes(Retreat), 0, Program.IMSG_DATA_BLOCK_LENGTH);
                        Program.ImsgData.RetreatSet(index, msg);
                    }
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

            if(!ExeData.IsLocked)
            {
                Pmapobj = ExeData.ReadWord(index, Program.CurrentConfig.Exe.UnitPmapObjOffset);
                BattleObj = ExeData.ReadWord(index, Program.CurrentConfig.Exe.UnitBattleObjOffset);
                CharacterType = ExeData.ReadByte(index, Program.CurrentConfig.Exe.UnitCharacterOffset);
            }
            if (index <= 255)
            {
                if (Program.CurrentConfig.CodeOptionContainer.UseVoice)
                    Voice = ExeData.ReadByte(index, Program.CurrentConfig.Exe.UnitVoiceOffset);
                if (Program.CurrentConfig.CodeOptionContainer.UseCutin)
                    Cutin = ExeData.ReadByte(index, Program.CurrentConfig.Exe.UnitCutinOffset);
                if (Program.CurrentConfig.CodeOptionContainer.UseCost)
                    Cost = ExeData.ReadByte(index, Program.CurrentConfig.Exe.UnitCostOffset);
            }

            if (Program.ImsgData.IsExist)
            {
                Imsg = Utils.ByteToString(Program.ImsgData.UnitExtensionGet(index), 0, Program.IMSG_DATA_BLOCK_LENGTH);
                if (index < Program.IMSG_RETREAT_COUNT)
                {
                    Retreat = Utils.ByteToString(Program.ImsgData.RetreatGet(index), 0, Program.IMSG_DATA_BLOCK_LENGTH);
                }
            }
        }

        public UnitData Clone()
        {
            var result = this.Clone<UnitData>();
            return result;
        }

    }
}
