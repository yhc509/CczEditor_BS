using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CczEditor.Data.Wrapper
{
    public class ProjectData
    {

        public string TitleText;

        public byte[] AbilityGrades;
        public bool IsEven;

        public byte[] ClassUp = new byte[2];

        public byte MaxUnitLevel;
        public byte MaxUnitExp;
        public byte NormalEquipExp;
        public byte NormalEquipLevel;
        public byte SpecialEquipExp;
        public byte SpecialEquipLevel;
        public byte SecondEquipLevel;
        public byte NewUnitExploit;
        public byte EnemyUnitExploit;
        public byte NormalEquipUpLevel;
        public byte SpecialEquipUpLevel;

        public byte[] SpecialAppearForce;
        public byte KnockBackForce;
        public byte SpecialSkillDmgForce;

        public byte MagicBlockForce;
        public byte NeighborMorIncForce;
        public byte NeighborHpRecForce;
        public byte NeighborMpRecForce;
        public byte NeighborAwakenForce;

        public void ReadTitle(ExeData targetData, Config config)
        {
            if (config.Exe.TitleOffsets.Length == 1)
                TitleText = targetData.GetText(config.Exe.TitleOffsets[0], 12);
            else
                TitleText = targetData.GetText(config.Exe.TitleOffsets[1], 12);
        }

        public void ReadAbility(ExeData targetData, Config config)
        {
            var evenCode = config.Codes["Even"];
            var checkInfo = evenCode.Last();
            IsEven = targetData.ReadByte(0, checkInfo.offset) == Utils.GetCode(checkInfo.CodeArr)[0];

            AbilityGrades = new byte[config.Exe.AbilityGrades.Length];

            var grades = config.Exe.AbilityGrades;
            for (int i = 0; i < grades.Length; i++)
            {
                var info = grades[i];

                int value = 0;
                if (i != grades.Length - 1)
                {
                    AbilityGrades[i] = targetData.ReadByte(0, info.Offset);
                }
            }
            
        }

        public void ReadLevels(ExeData targetData, Config config)
        {
            targetData.Open(System.IO.FileAccess.ReadWrite);

            ClassUp[0] = targetData.ReadByte(0, config.Exe.ClassUpLevel1Offsets[0]);
            ClassUp[1] = targetData.ReadByte(0, config.Exe.ClassUpLevel2Offsets[0]);

            MaxUnitLevel = targetData.ReadByte(0, config.Exe.MaxUnitLevelOffsets[0]);
            MaxUnitExp = targetData.ReadByte(0, config.Exe.MaxUnitExpOffsets[0]);
            NormalEquipExp = targetData.ReadByte(0, config.Exe.NormalEquipExpOffsets[0]);
            SpecialEquipExp = targetData.ReadByte(0, config.Exe.SpecialEquipExpOffsets[0]);

            NormalEquipLevel = targetData.ReadByte(0, config.Exe.NormalEquipMaxLevelOffsets[0]);
            SpecialEquipLevel = targetData.ReadByte(0, config.Exe.SpecialEquipMaxLevelOffsets[0]);

            SecondEquipLevel = targetData.ReadByte(0, config.Exe.SecondEquipStartLevelOffsets[0]);

            NewUnitExploit = targetData.ReadByte(0, config.Exe.NewUnitExploitOffsets[0]);
            EnemyUnitExploit = targetData.ReadByte(0, config.Exe.EnemyUnitExploitOffsets[0]);

            NormalEquipUpLevel  = targetData.ReadByte(0, config.Exe.NormalEquipUpLevelOffsets[0]);
            SpecialEquipUpLevel  = targetData.ReadByte(0, config.Exe.SpecialEquipUpLevelOffsets[0]);

            targetData.Close();
        }

        public void ReadEtc(ExeData targetData, Config config)
        {
            targetData.Open(System.IO.FileAccess.ReadWrite);
            SpecialAppearForce = new byte[2];
            SpecialAppearForce[0] = targetData.ReadByte(0, config.Exe.SpecialAppear_ForceIndexOffset[0]);
            SpecialAppearForce[1] = targetData.ReadByte(0, config.Exe.SpecialAppear_ForceIndexOffset[1]);

            KnockBackForce = targetData.ReadByte(0, config.Exe.Knock_Back_ForceIndexOffset);

            MagicBlockForce = targetData.ReadByte(0, config.Exe.Magic_Block_ForceIndexOffset);
            NeighborAwakenForce = targetData.ReadByte(0, config.Exe.Neighbor_Awaken_ForceIndexOffset);
            NeighborHpRecForce = targetData.ReadByte(0, config.Exe.Neighbor_HpRecover_ForceIndexOffset);
            NeighborMpRecForce = targetData.ReadByte(0, config.Exe.Neighbor_MpRecover_ForceIndexOffset);
            NeighborMorIncForce = targetData.ReadByte(0, config.Exe.Neighbor_MorIncrease_ForceIndexOffset);

            SpecialSkillDmgForce = targetData.ReadByte(0, config.Exe.SpecialSkillDmg_ForceCategoryIndexOffset);
            targetData.Close();
        }

        public void WriteTitle(ExeData targetData, Config config)
        {
            if (!targetData.IsLocked)
            {
                targetData.Open(System.IO.FileAccess.ReadWrite);
                if (config.Exe.TitleOffsets.Length == 1)
                {
                    targetData.WriteText(TitleText, config.Exe.TitleOffsets[0], 12);
                }
                else
                {
                    targetData.WriteText($"「{TitleText}」", config.Exe.TitleOffsets[0], 16);
                    targetData.WriteText(TitleText, config.Exe.TitleOffsets[1], 12);
                    targetData.WriteText(TitleText, config.Exe.TitleOffsets[2], 12);
                    targetData.WriteText($"종료「{TitleText}」", config.Exe.TitleOffsets[3], 20);
                    targetData.WriteText($"정말「{TitleText}」종료?", config.Exe.TitleOffsets[4], 25);
                }
                targetData.Close();
            }

            if (config.CodeOptionContainer.UseMp3Serv && !Data.Mp3Data.IsLocked)
            {
                Data.Mp3Data.WriteText(TitleText, 0x5B9A, 12);
            }
        }

        public void WriteAbility(ExeData targetData, Config config)
        {
            targetData.Open(System.IO.FileAccess.ReadWrite);
            if (IsEven)
            {
                var codes = config.Codes["Even"];
                foreach (var code in codes)
                {
                    targetData.Write(Utils.GetCode(code.CodeArr), code.offset);
                }
            }
            else
            {
                var codes = config.Codes["Odd"];
                foreach (var code in codes)
                {
                    targetData.Write(Utils.GetCode(code.CodeArr), code.offset);
                }
            }


            var grades = config.Exe.AbilityGrades;
            for (int i = 0; i < grades.Length; i++)
            {
                var info = grades[i];

                if (i != grades.Length - 1)
                {
                    byte value = AbilityGrades[i];
                    if (IsEven) value /= 2;
                    targetData.WriteByte(value, 0, info.Offset);
                }
            }

            targetData.Close();
        }

        public void WriteLevel(ExeData targetData, Config config)
        {

            targetData.Open(System.IO.FileAccess.ReadWrite);

            var offsets = config.Exe.ClassUpLevel1Offsets;
            foreach (var offset in offsets)
            {
                targetData.WriteByte(ClassUp[0], 0, offset);
            }

            offsets = config.Exe.ClassUpLevel2Offsets;
            foreach (var offset in offsets)
            {
                targetData.WriteByte(ClassUp[1], 0, offset);
            }

            offsets = config.Exe.MaxUnitLevelOffsets;
            foreach (var offset in offsets)
            {
                if (offset == offsets.Last())
                    targetData.WriteByte(MaxUnitLevel + 1, 0, offset);
                else
                    targetData.WriteByte(MaxUnitLevel, 0, offset);
            }

            offsets = config.Exe.MaxUnitExpOffsets;
            foreach (var offset in offsets)
            {
                targetData.WriteByte(MaxUnitExp, 0, offset);
            }

            offsets = config.Exe.NormalEquipExpOffsets;
            foreach (var offset in offsets)
            {
                targetData.WriteByte(NormalEquipExp, 0, offset);
            }

            offsets = config.Exe.SpecialEquipExpOffsets;
            foreach (var offset in offsets)
            {
                targetData.WriteByte(SpecialEquipExp, 0, offset);
            }

            offsets = config.Exe.NormalEquipMaxLevelOffsets;
            foreach (var offset in offsets)
            {
                targetData.WriteByte(NormalEquipLevel, 0, offset);
            }

            offsets = config.Exe.SpecialEquipMaxLevelOffsets;
            foreach (var offset in offsets)
            {
                if (offset == offsets.Last())
                    targetData.WriteByte(SpecialEquipLevel + 1, 0, offset);
                else
                    targetData.WriteByte(SpecialEquipLevel, 0, offset);
            }

            offsets = config.Exe.SecondEquipStartLevelOffsets;
            foreach (var offset in offsets)
            {
                targetData.WriteByte(SecondEquipLevel, 0, offset);
            }

            offsets = config.Exe.NewUnitExploitOffsets;
            foreach (var offset in offsets)
            {
                targetData.WriteByte(NewUnitExploit, 0, offset);
            }

            offsets = config.Exe.EnemyUnitExploitOffsets;
            foreach (var offset in offsets)
            {
                targetData.WriteByte(EnemyUnitExploit, 0, offset);
            }

            offsets = config.Exe.NormalEquipUpLevelOffsets;
            foreach (var offset in offsets)
            {
                targetData.WriteByte(NormalEquipLevel, 0, offset);
            }

            offsets = config.Exe.SpecialEquipUpLevelOffsets;
            foreach (var offset in offsets)
            {
                targetData.WriteByte(SpecialEquipLevel, 0, offset);
            }

            targetData.Close();
        }

        public void WriteEtc(ExeData targetData, Config config)
        {
            targetData.Open(System.IO.FileAccess.ReadWrite);

            var offset = config.Exe.SpecialAppear_ForceIndexOffset[0];
            targetData.WriteByte(SpecialAppearForce[0], 0, offset);

            offset = config.Exe.SpecialAppear_ForceIndexOffset[1];
            targetData.WriteByte(SpecialAppearForce[1], 0, offset);

            offset = config.Exe.Knock_Back_ForceIndexOffset;
            targetData.WriteByte(KnockBackForce, 0, offset);

            offset = config.Exe.SpecialSkillDmg_ForceCategoryIndexOffset;
            targetData.WriteByte(SpecialSkillDmgForce, 0, offset);

            offset = config.Exe.Magic_Block_ForceIndexOffset;
            targetData.WriteByte(MagicBlockForce, 0, offset);

            offset = config.Exe.Neighbor_Awaken_ForceIndexOffset;
            targetData.WriteByte(NeighborAwakenForce, 0, offset);

            offset = config.Exe.Neighbor_HpRecover_ForceIndexOffset;
            targetData.WriteByte(NeighborHpRecForce, 0, offset);

            offset = config.Exe.Neighbor_MpRecover_ForceIndexOffset;
            targetData.WriteByte(NeighborMpRecForce, 0, offset);

            offset = config.Exe.Neighbor_MorIncrease_ForceIndexOffset;
            targetData.WriteByte(NeighborMorIncForce, 0, offset);

            targetData.Close();
        }
    }
}
