using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CczEditor.Data.Wrapper
{
    public class ForceData
    {
        public byte HitArea;
        public byte Mov;
        public byte Atk;
        public byte Def;
        public byte Spr;
        public byte Cri;
        public byte Mor;
        public byte Hp;
        public byte Mp;

        public byte[] EquipTypeList;

        public string Imsg;

        public string ForceName;
        public string ForceCategoryName;
        public byte MoveSound;
        public byte MoveSpeed;
        public byte AtkSound;
        public byte RangeAtk;
        public byte ForceType;
        public byte MagicDmg;
        public byte AtkDelay;
        public byte AtkComm;
        public byte ForceAI;
        public byte EffArea;
        public byte SpecialSkillForce;

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
                var force = targetData.ForceGet(index);
                Mov = force[0];
                HitArea = force[1];
                Atk = force[2];
                Def = force[3];
                Spr = force[4];
                Cri = force[5];
                Mor = force[6];
                Hp = force[7];
                Mp = force[8];

                EquipTypeList = new byte[force.Length - 9];
                Array.Copy(force, 9, EquipTypeList, 0, force.Length - 9);
            }
        }

        public void ReadImsgData(int index, ImsgData targetData, Config config)
        {
            if (targetData.IsExist)
            {
                var msg = targetData.ForceGet(index);
                Imsg = Utils.ByteToString(msg, 0, Program.IMSG_DATA_BLOCK_LENGTH);
            }
        }

        public void ReadExeData(int index, ExeData targetData, Config config)
        {
            if (!targetData.IsLocked)
            {
                int forceCategoryIndex = 0;
                int ForceCount = config.ForceNames.Count;
                int ForceCategoryCount = config.ForceCategoryNames.Count;
                if (index < ((ForceCount - ForceCategoryCount) / 2) * 3 - 1)
                {
                    forceCategoryIndex = (index / 3);
                }
                else
                {
                    forceCategoryIndex = (index - ((ForceCount - ForceCategoryCount) / 2) * 3) + (ForceCount - ForceCategoryCount) / 2;
                }
                if (!targetData.IsLocked)
                {
                    ForceName = ConfigUtils.GetForceName(Program.ExeData, Program.CurrentConfig, index);
                    ForceCategoryName = ConfigUtils.GetForceCategoryName(Program.ExeData, Program.CurrentConfig, forceCategoryIndex);
                    MoveSound = targetData.ReadByte(forceCategoryIndex, config.Exe.Force.MoveSoundOffset);
                    MoveSpeed = targetData.ReadByte(forceCategoryIndex, config.Exe.Force.MoveSpeedOffset);
                    AtkSound = targetData.ReadByte(forceCategoryIndex, config.Exe.Force.AtkSoundOffset);
                    RangeAtk = targetData.ReadByte(forceCategoryIndex, config.Exe.Force.AtkTypeOffset);
                    ForceType = targetData.ReadByte(forceCategoryIndex, config.Exe.Force.TypeOffset);
                    MagicDmg = targetData.ReadByte(forceCategoryIndex, config.Exe.Force.MagicDamageOffset);
                    AtkDelay = targetData.ReadByte(forceCategoryIndex, config.Exe.Force.AtkDelayOffset);
                    AtkComm = targetData.ReadByte(forceCategoryIndex, config.Exe.Force.AtkPincOffset);
                    if (config.CodeOptionContainer.AIExtension)
                    {
                        ForceAI = targetData.ReadByte(forceCategoryIndex, config.Exe.Force.AiTypeOffset);
                    }
                    EffArea = targetData.ReadByte(index, config.Exe.Force.AtkEffectOffset);

                    SpecialSkillForce = targetData.ReadByte(forceCategoryIndex, config.Exe.SpecialSkillForceOffset);
                }
            }
        }



        public void Write(int index, GameData gameData, ImsgData imsgData, ExeData exeData, Config config)
        {
            // TODO 폐기 예정
            WriteGameData(index, gameData, config);
            WriteImsgData(index, imsgData, config);
            WriteExeData(index, exeData, config);
        }

        public void WriteExeData(int index, ExeData targetData, Config config)
        {
            //EXE
            if (!targetData.IsLocked)
            {
                targetData.Open(System.IO.FileAccess.ReadWrite);
                int forceCategoryIndex = 0;
                if (index < 60)
                {
                    forceCategoryIndex = (index / 3);
                }
                else
                {
                    forceCategoryIndex = (index - 59) + 19;
                }
                
                var forceInfo = config.ForceNames.Find(x => x.Index == index);
                ForceName = ForceName.Substring(0, Math.Min(ForceName.Length, forceInfo.Length));

                targetData.WriteText(ForceName, forceInfo.Offset, forceInfo.Length);
                
                var forceCategoryInfo = config.ForceCategoryNames.Find(x => x.Index == forceCategoryIndex);
                ForceCategoryName = ForceCategoryName.Substring(0, Math.Min(ForceCategoryName.Length, forceCategoryInfo.Length));

                targetData.WriteText(ForceCategoryName, forceCategoryInfo.Offset, forceCategoryInfo.Length);

                targetData.WriteByte(MoveSound, forceCategoryIndex, config.Exe.Force.MoveSoundOffset);
                targetData.WriteByte(MoveSpeed, forceCategoryIndex, config.Exe.Force.MoveSpeedOffset);
                targetData.WriteByte(AtkSound, forceCategoryIndex, config.Exe.Force.AtkSoundOffset);
                targetData.WriteByte(RangeAtk, forceCategoryIndex, config.Exe.Force.AtkTypeOffset);
                targetData.WriteByte(ForceType, forceCategoryIndex, config.Exe.Force.TypeOffset);
                targetData.WriteByte(MagicDmg, forceCategoryIndex, config.Exe.Force.MagicDamageOffset);
                targetData.WriteByte(AtkDelay, forceCategoryIndex, config.Exe.Force.AtkDelayOffset);
                targetData.WriteByte(AtkComm, forceCategoryIndex, config.Exe.Force.AtkPincOffset);
                if (config.CodeOptionContainer.AIExtension)
                {
                    targetData.WriteByte(ForceAI, forceCategoryIndex, config.Exe.Force.AiTypeOffset);
                }
                targetData.WriteByte(EffArea, index, config.Exe.Force.AtkEffectOffset);

                targetData.WriteByte(SpecialSkillForce, forceCategoryIndex, config.Exe.SpecialSkillForceOffset);

                targetData.Close();
            }

        }

        public void WriteGameData(int index, GameData targetData, Config config)
        {
            if (targetData.IsExist)
            {
                var force = targetData.ForceGet(index);
                force[0] = Mov;
                force[1] = HitArea;
                force[2] = Atk;
                force[3] = Def;
                force[4] = Spr;
                force[5] = Cri;
                force[6] = Mor;
                force[7] = Hp;
                force[8] = Mp;
                var di = 9;
                for (var i = 0; i < EquipTypeList.Length; i++, di++)
                {
                    force[di] = EquipTypeList[i];
                }
                targetData.ForceSet(index, force);
            }
        }

        public void WriteImsgData(int index, ImsgData targetData, Config config)
        {
            if (targetData.IsExist)
            {
                byte[] b = new byte[Program.IMSG_DATA_BLOCK_LENGTH];
                Utils.ChangeByteValue(b, Utils.GetBytes(Imsg), 0, Program.IMSG_DATA_BLOCK_LENGTH);
                targetData.ForceSet(index, b);
            }
        }
        
    }
}
