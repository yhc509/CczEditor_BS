using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CczEditor.Data.Wrapper
{
    public class CodeEffectData
    {
        public Dictionary<string, byte> CodeEffectContainer = new Dictionary<string, byte>();

        public bool[] AbilityAssistPercent = new bool[7];
        public byte[] SpecialAtkValue = new byte[3];
        public byte[,] StateEffectAttackAccValue = new byte[4,2];
        public bool MpDefenceRecover;
        public byte GoldDefence;

        public int AbilityAssistIndex = 0;
        public int SpecialAttackIndex = 0;
        public int AttackAccIndex = 0;
        public int MagicIndex = 0;
        public int StateEffectAttackIndex = 0;
        public int TurnCureIndex = 0;
        public int DeburfAttackIndex = 0;
        public int DecreaseDmgIndex = 0;
        public int DefenceIndex = 0;
        public int TerrainAssistIndex = 0;
        public int EtcIndex = 0;
        
        public void Read(ExeData exeData, Config config)
        {
            ReadExeData(exeData, config);
        }

        public void ReadExeData(ExeData targetData, Config config)
        {
            targetData.Open(System.IO.FileAccess.ReadWrite);
            foreach (var code in config.CodeEffects)
            {
                var value = targetData.ReadByte(0, code.Offset);
                CodeEffectContainer.Add(code.Description, value);
            }

            for (int i = 0; i < AbilityAssistPercent.Length; i++)
            {
                AbilityAssistPercent[i] = targetData.ReadByte(i, config.Exe.AbilityAssistPercentOffset) == 2;
            }

            SpecialAtkValue[0] = targetData.ReadByte(0, config.Exe.RangeAttack2TypeOffset);
            SpecialAtkValue[1] = targetData.ReadByte(0, config.Exe.RangeAttack3TypeOffset);
            SpecialAtkValue[2] = targetData.ReadByte(0, config.Exe.IgnoreDefenceOffset);

            GoldDefence = targetData.ReadByte(0, config.Exe.GoldDefenceRateOffset);


            StateEffectAttackAccValue[0, 0] = targetData.ReadByte(0, config.Exe.StateEffectAccOffset);
            StateEffectAttackAccValue[1, 0] = targetData.ReadByte(1, config.Exe.StateEffectAccOffset);
            StateEffectAttackAccValue[2, 0] = targetData.ReadByte(2, config.Exe.StateEffectAccOffset);
            StateEffectAttackAccValue[3, 0] = targetData.ReadByte(3, config.Exe.StateEffectAccOffset);
            StateEffectAttackAccValue[0, 1] = targetData.ReadByte(4, config.Exe.StateEffectAccOffset);
            StateEffectAttackAccValue[1, 1] = targetData.ReadByte(5, config.Exe.StateEffectAccOffset);
            StateEffectAttackAccValue[2, 1] = targetData.ReadByte(6, config.Exe.StateEffectAccOffset);
            StateEffectAttackAccValue[3, 1] = targetData.ReadByte(7, config.Exe.StateEffectAccOffset);

            targetData.Close();
        }
        
        public void Write(ExeData targetData, Config config)
        {
            targetData.Open(System.IO.FileAccess.ReadWrite);
            WriteExeData(targetData, Config.ConfigCodeEffectInfos.Type.AbilityAssist, AbilityAssistIndex, config);
            WriteExeData(targetData, Config.ConfigCodeEffectInfos.Type.SpecialAttack, SpecialAttackIndex, config);
            WriteExeData(targetData, Config.ConfigCodeEffectInfos.Type.AttackAcc, AttackAccIndex, config);
            WriteExeData(targetData, Config.ConfigCodeEffectInfos.Type.Magic, MagicIndex, config);
            WriteExeData(targetData, Config.ConfigCodeEffectInfos.Type.StateEffectAttack, StateEffectAttackIndex, config);
            WriteExeData(targetData, Config.ConfigCodeEffectInfos.Type.TurnCure, TurnCureIndex, config);
            WriteExeData(targetData, Config.ConfigCodeEffectInfos.Type.DeburfAttack, DeburfAttackIndex, config);
            WriteExeData(targetData, Config.ConfigCodeEffectInfos.Type.DecreaseDmg, DecreaseDmgIndex, config);
            WriteExeData(targetData, Config.ConfigCodeEffectInfos.Type.Defence, DefenceIndex, config);
            WriteExeData(targetData, Config.ConfigCodeEffectInfos.Type.TerrainAssist, TerrainAssistIndex, config);
            WriteExeData(targetData, Config.ConfigCodeEffectInfos.Type.Etc, EtcIndex, config);
            targetData.Close();
        }

        public void WriteAll(ExeData targetData, Config config)
        {
            targetData.Open(System.IO.FileAccess.ReadWrite);

            for(int t = (int)Config.ConfigCodeEffectInfos.Type.AbilityAssist; t <= (int)Config.ConfigCodeEffectInfos.Type.Etc; t++)
            {
                int length = config.CodeEffects.Count(x => x.TypeIndex == t);
                for (int i = 0; i < length; i++)
                {
                    WriteExeData(targetData,(Config.ConfigCodeEffectInfos.Type) t, i, config);
                }

            }
            targetData.Close();
        }
        
        private void WriteExeData(ExeData targetData, Config.ConfigCodeEffectInfos.Type type, int index, Config config)
        {
            if (targetData.IsLocked) return;

            var list = config.CodeEffects.Where(x => x.TypeIndex == (int)type).ToList();

            var effect = list[index];
            
            foreach(var code in CodeEffectContainer)
            {
                var info = config.CodeEffects.Find(x => x.Description == code.Key);
                if (info == null) continue;
                switch((Config.ConfigCodeEffectInfos.Type) info.TypeIndex)
                {
                    case Config.ConfigCodeEffectInfos.Type.AbilityAssist:
                        targetData.WriteByte(code.Value, 0, info.Offset);
                        if (info.SubEdit == 1)
                        {
                            var idx = config.CodeEffects
                                .Where(x => x.TypeIndex == (int) Config.ConfigCodeEffectInfos.Type.AbilityAssist)
                                .ToList().IndexOf(info);
                            targetData.WriteByte(AbilityAssistPercent[idx] ? 2 : 1, idx, config.Exe.AbilityAssistPercentOffset);
                        }
                        break;
                    case Config.ConfigCodeEffectInfos.Type.SpecialAttack:
                        targetData.WriteByte(code.Value, 0, info.Offset);
                        if (info.SubEdit == 1)
                        {
                            targetData.WriteByte(SpecialAtkValue[0], 0, config.Exe.RangeAttack2TypeOffset);
                        }
                        else if (info.SubEdit == 2)
                        {
                            targetData.WriteByte(SpecialAtkValue[1], 0, config.Exe.RangeAttack3TypeOffset);
                        }
                        else if (info.SubEdit == 3)
                        {
                            targetData.WriteByte(SpecialAtkValue[2], 0, config.Exe.IgnoreDefenceOffset);
                        }
                        break;
                    case Config.ConfigCodeEffectInfos.Type.StateEffectAttack:
                        targetData.WriteByte(code.Value, 0, info.Offset);
                        if (info.SubEdit == 1)
                        {
                            targetData.WriteByte(StateEffectAttackAccValue[0,0], 0, config.Exe.StateEffectAccOffset);
                            targetData.WriteByte(StateEffectAttackAccValue[1,0], 1, config.Exe.StateEffectAccOffset);
                            targetData.WriteByte(StateEffectAttackAccValue[2,0], 2, config.Exe.StateEffectAccOffset);
                            targetData.WriteByte(StateEffectAttackAccValue[3,0], 3, config.Exe.StateEffectAccOffset);
                            targetData.WriteByte(StateEffectAttackAccValue[0,1], 4, config.Exe.StateEffectAccOffset);
                            targetData.WriteByte(StateEffectAttackAccValue[1,1], 5, config.Exe.StateEffectAccOffset);
                            targetData.WriteByte(StateEffectAttackAccValue[2,1], 6, config.Exe.StateEffectAccOffset);
                            targetData.WriteByte(StateEffectAttackAccValue[3,1], 7, config.Exe.StateEffectAccOffset);
                        }
                        break;
                    case Config.ConfigCodeEffectInfos.Type.Defence:
                        targetData.WriteByte(code.Value, 0, info.Offset);
                        if (info.SubEdit == 1)
                        {
                            targetData.WriteByte(GoldDefence, 0, config.Exe.GoldDefenceRateOffset);
                        }
                        else if (info.SubEdit == 2)
                        {
                            var c = code.Value;
                            targetData.WriteByte(MpDefenceRecover ? c : 0x48, 0, config.Exe.MpDefenceRecoverOffest);
                        }
                        break;
                    case Config.ConfigCodeEffectInfos.Type.AttackAcc:
                    case Config.ConfigCodeEffectInfos.Type.Magic:
                    case Config.ConfigCodeEffectInfos.Type.TurnCure:
                    case Config.ConfigCodeEffectInfos.Type.DeburfAttack:
                    case Config.ConfigCodeEffectInfos.Type.DecreaseDmg:
                    case Config.ConfigCodeEffectInfos.Type.TerrainAssist:
                    case Config.ConfigCodeEffectInfos.Type.Etc:
                        targetData.WriteByte(code.Value, 0, info.Offset);
                        break;
                }
            }
            
        }
        
    }
}
