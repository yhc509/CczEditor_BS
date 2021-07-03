using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CczEditor.Data.Wrapper
{
    public class UnitData
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
        public byte Cutin = 0x63;
        public byte Voice = 0x00;
        public byte Cost = 0x00;

        // Imsg
        public string Imsg;
        public string Retreat;


        #region Write
        public void Write(int index, GameData gameData, ImsgData imsgData, ExeData exeData, Config config)
        {
            WriteGameData(index, gameData, config);
            WriteImsgData(index, imsgData, config);
            WriteExeData(index, exeData, config);
        }

        public void WriteGameData(int index, GameData gameData, Config config)
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

            if (gameData.IsExist)
                gameData.UnitSet(index, result);
        }

        public void WriteImsgData(int index, ImsgData targetData, Config config)
        {
            if (targetData.IsExist)
            {
                if (Imsg != null)
                {
                    var msg = new byte[Program.IMSG_DATA_BLOCK_LENGTH];
                    Utils.ChangeByteValue(msg, Utils.GetBytes(Imsg), 0, Program.IMSG_DATA_BLOCK_LENGTH);
                    targetData.UnitExtensionSet(index, msg);
                }

                if (index < Program.IMSG_RETREAT_COUNT)
                {
                    if (Retreat != null)
                    {
                        var msg = new byte[Program.IMSG_DATA_BLOCK_LENGTH];
                        Utils.ChangeByteValue(msg, Utils.GetBytes(Retreat), 0, Program.IMSG_DATA_BLOCK_LENGTH);
                        targetData.RetreatSet(index, msg);
                    }
                }
            }
        }

        public void WriteExeData(int index, ExeData targetData, Config config)
        {
            if (!targetData.IsLocked)
            {
                targetData.WriteWord(Pmapobj, index, config.Exe.UnitPmapObjOffset);
                targetData.WriteWord(BattleObj, index, config.Exe.UnitBattleObjOffset);
                targetData.WriteByte(CharacterType, index, config.Exe.UnitCharacterOffset);
                if (index <= 255)
                {
                    if (config.CodeOptionContainer.UseVoice)
                        targetData.WriteByte(Voice, index, config.Exe.UnitVoiceOffset);
                    if (config.CodeOptionContainer.UseCost)
                        targetData.WriteByte(Cost, index, config.Exe.UnitCostOffset);
                    if (config.CodeOptionContainer.UseCutin)
                        targetData.WriteByte(Cutin, index, config.Exe.UnitCutinOffset);
                }
            }
        }
        
        #endregion

        #region Read
        public void Read(int index, GameData gameData, ImsgData imsgData, ExeData exeData, Config config)
        {
            ReadGameData(index, gameData, config);
            ReadImsgData(index, imsgData, config);
            ReadExeData(index, exeData, config);
        }

        public void ReadGameData(int index, GameData targetData, Config config)
        {
            if (targetData.IsExist)
            {
                var unit = targetData.UnitGet(index);
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
        }

        public void ReadImsgData(int index, ImsgData targetData, Config config)
        {
            if (targetData.IsExist)
            {
                Imsg = Utils.ByteToString(targetData.UnitExtensionGet(index), 0, Program.IMSG_DATA_BLOCK_LENGTH);
                if (index < Program.IMSG_RETREAT_COUNT)
                {
                    Retreat = Utils.ByteToString(targetData.RetreatGet(index), 0, Program.IMSG_DATA_BLOCK_LENGTH);
                }
            }
        }

        public void ReadExeData(int index, ExeData targetData, Config config)
        {
            if (!targetData.IsLocked)
            {
                Pmapobj = targetData.ReadWord(index, config.Exe.UnitPmapObjOffset);
                BattleObj = targetData.ReadWord(index, config.Exe.UnitBattleObjOffset);
                CharacterType = targetData.ReadByte(index, config.Exe.UnitCharacterOffset);
            }
            if (index <= 255)
            {
                if (config.CodeOptionContainer.UseVoice)
                    Voice = targetData.ReadByte(index, config.Exe.UnitVoiceOffset);
                if (config.CodeOptionContainer.UseCutin)
                    Cutin = targetData.ReadByte(index, config.Exe.UnitCutinOffset);
                if (config.CodeOptionContainer.UseCost)
                    Cost = targetData.ReadByte(index, config.Exe.UnitCostOffset);
            }
        }
        
        #endregion

    }
}
