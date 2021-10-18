using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CczEditor.Data.Wrapper
{
    public class MagicData
    {
        public string Name;
        public byte ViewType;
        public byte TargetType;
        public byte HitArea;
        public byte EffArea;
        public byte MpCost;
        public byte Icon;
        public byte[] LearnLv;

        public string Imsg;

        public bool UseMagicType;
        public bool UseDmgType;
        public bool UseHealType;
        public bool UseMeff;
        public bool UseMcall;
        public bool UseAIType;
        public bool UseCondition;
        public bool UseLearnType;
        public bool UseDmgValue;
        public bool UseAccRate;
        public bool UseReflect;
        
        public byte MagicType;
        public byte DmgType;
        public byte HealType;
        public byte Meff;
        public byte Mcall;
        public byte AIType;
        public byte Condition;
        public byte LearnType;
        public byte DmgValue;
        public byte AccRate;
        public byte Reflect;

        public void Read(int index, GameData gameData, ImsgData imsgData, ExeData exeData, Config config)
        {
            ReadExeData(index, exeData, config);
            ReadGameData(index, gameData, config);
            ReadImsgData(index, imsgData, config);
        }

        public void ReadExeData(int index, ExeData targetData, Config config)
        {
            if (!targetData.IsLocked)
            {
                UseMagicType = UseDmgType = UseHealType = UseMeff = UseMcall = UseAIType
                = UseCondition = UseLearnType = UseDmgValue = UseAccRate = UseReflect = false;

                if (!targetData.IsLocked)
                {
                    var list = config.Exe.Magic.UseMagicTypeIndexes.ToList();
                    UseMagicType = list.Contains(index);
                    if (UseMagicType)
                        MagicType = targetData.ReadByte(list.IndexOf(index), config.Exe.Magic.MagicTypeOffset);

                    list = config.Exe.Magic.UseDamageTypeIndexes.ToList();
                    UseDmgType = list.Contains(index);
                    if (UseDmgType)
                        DmgType = targetData.ReadByte(list.IndexOf(index), config.Exe.Magic.DamageTypeOffset);

                    list = config.Exe.Magic.UseHealTypeIndexes.ToList();
                    UseHealType = list.Contains(index);
                    if (UseHealType)
                        HealType = targetData.ReadByte(list.IndexOf(index), config.Exe.Magic.HealTypeOffset);

                    list = config.Exe.Magic.UseMeffIndexes.ToList();
                    UseMeff = list.Contains(index);
                    if (UseMeff)
                        Meff = targetData.ReadByte(list.IndexOf(index), config.Exe.Magic.MeffOffset);

                    list = config.Exe.Magic.UseMcallIndexes.ToList();
                    UseMcall = list.Contains(index);
                    if (UseMcall)
                    {
                        Mcall = targetData.ReadByte(list.IndexOf(index), config.Exe.Magic.McallOffset);
                        /*if (config.CodeOptionContainer.UseMeffAfterMcallExtension && Mcall != 0xFF)
                            Mcall++;*/
                    }

                    list = config.Exe.Magic.UseAiTypeIndexes.ToList();
                    UseAIType = list.Contains(index);
                    if (UseAIType)
                        AIType = targetData.ReadByte(list.IndexOf(index), config.Exe.Magic.AiTypeOffset);

                    if (config.CodeOptionContainer.UseMagicCondition)
                    {
                        list = config.Exe.Magic.UseConditionIndexes.ToList();
                        UseCondition = list.Contains(index);
                        if (UseCondition)
                            Condition = targetData.ReadByte(list.IndexOf(index), config.Exe.Magic.UseConditionOffset);
                    }

                    list = config.Exe.Magic.UseLearnTypeIndexes.ToList();
                    UseLearnType = list.Contains(index);
                    if (UseLearnType)
                        LearnType = targetData.ReadByte(list.IndexOf(index), config.Exe.Magic.LearTypeOffset);


                    list = config.Exe.Magic.UseDamageValueIndexes.ToList();
                    UseDmgValue = list.Contains(index);
                    if (UseDmgValue)
                        DmgValue = targetData.ReadByte(list.IndexOf(index), config.Exe.Magic.DamageValueOffset);

                    list = config.Exe.Magic.UseAccRateIndexes.ToList();
                    UseAccRate = list.Contains(index);
                    if (UseAccRate)
                        AccRate = targetData.ReadByte(list.IndexOf(index), config.Exe.Magic.AccRateOffset);

                    if (config.CodeOptionContainer.MagicReflect)
                    {
                        list = config.Exe.Magic.UseReflectIndexes.ToList();
                        UseReflect = list.Contains(index);
                        if (UseReflect)
                            Reflect = targetData.ReadByte(list.IndexOf(index), config.Exe.Magic.ReflectTypeOffset);

                    }
                }
            }
        }

        public void ReadGameData(int index, GameData targetData, Config config)
        {
            if (targetData.IsExist)
            {
                var magic = targetData.MagicGet(index);
                Name = Utils.ByteToString(magic, 0, 10);
                ViewType = magic[11];
                TargetType = magic[12];
                HitArea = magic[13];
                EffArea = magic[14];
                MpCost = magic[15];
                Icon = magic[16];

                LearnLv = new byte[config.ForceNames.Count];
                Array.Copy(magic, 17, LearnLv, 0, LearnLv.Length);
            }
        }

        public void ReadImsgData(int index, ImsgData targetData, Config config)
        {
            if (targetData.IsExist) { 
                var msg = targetData.MagicGet(index);
                Imsg = Utils.ByteToString(msg, 0, Program.IMSG_DATA_BLOCK_LENGTH);
            }
        }

        public void Write(int index, GameData gameData, ImsgData imsgData, ExeData exeData, Config config)
        {
            WriteExeData(index, exeData, config);
            WriteGameData(index, gameData, config);
            WriteImsgData(index, imsgData, config);
        }

        public void WriteExeData(int index, ExeData targetData, Config config)
        {
            if (!targetData.IsLocked)
            {
                var list = config.Exe.Magic.UseMagicTypeIndexes.ToList();
                if (UseMagicType)
                    targetData.WriteByte(MagicType, list.IndexOf(index), config.Exe.Magic.MagicTypeOffset);

                list = config.Exe.Magic.UseDamageTypeIndexes.ToList();
                if (UseDmgType)
                    targetData.WriteByte(DmgType, list.IndexOf(index), config.Exe.Magic.DamageTypeOffset);

                list = config.Exe.Magic.UseHealTypeIndexes.ToList();
                if (UseHealType)
                {
                    targetData.WriteByte(HealType, list.IndexOf(index),  config.Exe.Magic.HealTypeOffset);
                }

                list = config.Exe.Magic.UseMeffIndexes.ToList();
                if (UseMeff)
                {
                    targetData.WriteByte(Meff, list.IndexOf(index), config.Exe.Magic.MeffOffset);
                }

                list = config.Exe.Magic.UseMcallIndexes.ToList();
                if (UseMcall)
                {
                    targetData.WriteByte(Mcall, list.IndexOf(index), config.Exe.Magic.McallOffset);
                }

                list = config.Exe.Magic.UseAiTypeIndexes.ToList();
                if (UseAIType)
                {
                    targetData.WriteByte(AIType, list.IndexOf(index),  config.Exe.Magic.AiTypeOffset);
                }

                list = config.Exe.Magic.UseConditionIndexes.ToList();
                if (UseCondition)
                {
                    targetData.WriteByte(Condition, list.IndexOf(index), config.Exe.Magic.UseConditionOffset);
                }

                list = config.Exe.Magic.UseLearnTypeIndexes.ToList();
                if (UseLearnType)
                {
                    targetData.WriteByte(LearnType, list.IndexOf(index), config.Exe.Magic.LearTypeOffset);
                }

                list = config.Exe.Magic.UseDamageValueIndexes.ToList();
                if (UseDmgValue)
                {
                    targetData.WriteByte(DmgValue, list.IndexOf(index), config.Exe.Magic.DamageValueOffset);
                }

                list = config.Exe.Magic.UseAccRateIndexes.ToList();
                if (UseAccRate)
                {
                    targetData.WriteByte(AccRate, list.IndexOf(index),  config.Exe.Magic.AccRateOffset);
                }

                if (config.CodeOptionContainer.MagicReflect)
                {
                    list = config.Exe.Magic.UseReflectIndexes.ToList();
                    UseReflect = list.Contains(index);
                    if (UseReflect)
                        targetData.WriteByte(Reflect, list.IndexOf(index), config.Exe.Magic.ReflectTypeOffset);

                }
            }
            
        }

        public void WriteGameData(int index, GameData targetData, Config config)
        {
            if (targetData.IsExist)
            {
                var length = config.Data.MagicLength;
                var magic = new byte[length];

                Utils.ChangeByteValue(magic, Utils.GetBytes(Name), 0, 10);

                magic[11] = ViewType;
                magic[12] = TargetType;
                magic[13] = HitArea;
                magic[14] = EffArea;
                magic[15] = MpCost;
                magic[16] = Icon;
                for (var i = 0; i < config.ForceNames.Count; i++)
                {
                    magic[17 + i] = LearnLv[i];
                }
                targetData.MagicSet(index, magic);
            }
        }

        public void WriteImsgData(int index, ImsgData targetData, Config config)
        {
            if (targetData.IsExist)
            {
                byte[] msg = new byte[Program.IMSG_DATA_BLOCK_LENGTH];
                Utils.ChangeByteValue(msg, Utils.GetBytes(Imsg), 0, Program.IMSG_DATA_BLOCK_LENGTH);
                targetData.MagicSet(index, msg);
            }

        }
    }
}
