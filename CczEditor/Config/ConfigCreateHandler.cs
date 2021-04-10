using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CczEditor.Config
{
    public class ConfigCreateHandler
    {
        Config result;
        public ConfigCreateHandler()
        {
            result = new Config();
        }

        public Config Execute()
        {
            result.VersionName = "BS 1.0";
            result.DisplayName = "비상조조전 1.0";
            result.DirectoryPath = string.Empty;
            result.ExeFileName = "Ekd5.exe";
            result.UseE5Directory = false;

            #region CodeOption Setting
            result.CodeOptionContainer.ItemCustomRange = false;
            result.CodeOptionContainer.MpExtension = false;
            result.CodeOptionContainer.AIExtension = true;
            result.CodeOptionContainer.MagicLearnExtension = true;
            result.CodeOptionContainer.SingularAttribute = false;
            result.CodeOptionContainer.MagicReflect = true;
            result.CodeOptionContainer.UseLargeFace = true;
            result.CodeOptionContainer.UseCutin = true;
            result.CodeOptionContainer.UseVoice = true;
            result.CodeOptionContainer.UseCost = true;
            #endregion

            #region Data Setting
            result.Data.UnitCount = 0x400;
            result.Data.UnitOffset = 0x18C;
            result.Data.UnitLength = 0x20;

            result.Data.ItemCount = 0x68;
            result.Data.ItemOffset = 0x818C;
            result.Data.ItemLength = 0x19;

            result.Data.ShopCount = 0x63;
            result.Data.ShopOffset = 0x8BB4;
            result.Data.ShopLength = 0x24;

            result.Data.ForceCount = 0x50;
            result.Data.ForceOffset = 0x9DB4;
            result.Data.ForceLength = 0x23;

            result.Data.MagicCount = 0x4A;
            result.Data.MagicOffset = 0xB204;
            result.Data.MagicLength = 0x61;

            result.Data.TerrainOffset = 0xA8A4;

            result.Data.StarItemCount = 0x9A;
            result.Data.StarItemOffset = 0x00;
            #endregion

            #region Imsg Setting
            result.Imsg.ItemOffset = 0x00;
            result.Imsg.MagicOffset = 0x7F58;
            result.Imsg.StageCount = 0x63;
            result.Imsg.StageOffset = 0xC350;
            result.Imsg.ForceOffset = 0x11170;
            result.Imsg.UnitOriginalOffset = 0x15F90;
            result.Imsg.UnitExtensionOffset = 0x2D050;
            result.Imsg.RetreatOffset = 0x1FBD0;
            result.Imsg.CriticalOffset = 0x222E0;
            result.Imsg.CriticalCount = 0x14;
            result.Imsg.StaffOffset = 0x27100;
            #endregion

            #region Item Setting
            result.Items.WeaponIndexMin = 0;
            result.Items.WeaponIndexMax = 19;
            result.Items.ArmorIndexMin = 20;
            result.Items.ArmorIndexMax = 25;
            result.Items.AuxiliaryIndexMin = 26;
            result.Items.AuxiliaryIndexMax = 116;
            result.Items.ConsumablesMin = 71;
            result.Items.ConsumablesMax = 84;
            result.Items.MineInstall = 85;
            result.Items.MineControl = 86;
            result.Items.Mine = 87;
            result.Items.Bomb = 88;
            #endregion

            #region Exe Setting
            result.Exe.BattleObjTripleTypeCount = 0x20;
            result.Exe.UnitCharacterOffset = 0xE2800;
            result.Exe.UnitBattleObjOffset = 0xD2800;
            result.Exe.UnitPmapObjOffset = 0xE1000;

            result.Exe.UnitCutinOffset = 0xF7F50;
            result.Exe.UnitCostOffset = 0xF9330;
            result.Exe.UnitVoiceOffset = 0xF80C0;

            result.Exe.CriticalOffset = 0x89C30;
            result.Exe.CriticalCount = 0x14;
            result.Exe.TreasureCountOffset = 0x6FF8C;

            result.Exe.SpecialSkillOffset = 0xDA000;
            result.Exe.SpecialSkillPhysicsCount = 0x1A;
            result.Exe.SpecialSkillForceOffset = 0xA3A00;

            result.Exe.SpecialEffectOffset = 0xDA1B0;
            result.Exe.AbilityAssistPercentOffset = 0x6170F;
            result.Exe.RangeAttack2TypeOffset = 0x3ED10;
            result.Exe.RangeAttack3TypeOffset = 0x3ED22;
            result.Exe.IgnoreDefenceOffset = 0x6170E;
            result.Exe.GoldDefenceRateOffset = 0xA140C;
            result.Exe.MpDefenceRecoverOffest = 0x38EFC;
            result.Exe.StateEffectAccOffset = 0xA0E88;
            result.Exe.TitleOffsets = new int[]
            {
                0x8A120,
                0x8B2D8,
                0x8D248,
                0x8D260,
                0x8D278
            };
            result.Exe.AbilityGrades = new Config.ConfigExeAbilityGradeInfos[]
            {
                new Config.ConfigExeAbilityGradeInfos { Name = "X", Offset = 0x6701 },
                new Config.ConfigExeAbilityGradeInfos { Name = "S", Offset = 0x6709 },
                new Config.ConfigExeAbilityGradeInfos { Name = "A", Offset = 0x6711 },
                new Config.ConfigExeAbilityGradeInfos { Name = "B", Offset = 0x6719 },
                new Config.ConfigExeAbilityGradeInfos { Name = "C", Offset = 0x0 },
            };
            result.Exe.ClassUpLevel1Offsets = new int[]
            {
                0x7E67, 0xB7BD, 0x1C7E3, 0x41D03, 0x41D39, 0x680B8
            };
            result.Exe.ClassUpLevel2Offsets = new int[]
            {
                0xB7AE, 0x41D21
            };
            result.Exe.MaxUnitLevelOffsets = new int[]
            {
                0x68F1, 0x7CD3, 0x116C8, 0x117CE, 0x1B98E, 0xB7D6
            };
            result.Exe.MaxUnitExpOffsets = new int[]
            {
                0x7CD6, 0x4F45A, 0x4FF33, 0x4FF48, 0x5001F, 0x5BAA3, 0x78958
            };
            result.Exe.NormalEquipExpOffsets = new int[]
            {
                0x771E, 0x1F61B, 0x1F648, 0x1F66B, 0x4F5A2, 0x4F609
            };
            result.Exe.SpecialEquipExpOffsets = new int[]
            {
                0x7719, 0x1F616, 0x1F643, 0x1F666, 0x4F59D, 0x4F604
            };
            result.Exe.NormalEquipMaxLevelOffsets = new int[]
            {
                0x71D9, 0x7409, 0x744C, 0x74E6, 0x772B, 0xA138F
            };
            result.Exe.SpecialEquipMaxLevelOffsets = new int[]
            {
                0x71AC, 0x7727, 0xA1378, 0xA138B
            };
            result.Exe.SecondEquipStartLevelOffsets = new int[]
            {
                0x71A9, 0x73DE
            };
            result.Exe.NewUnitExploitOffsets = new int[]
            {
                0xB788, 0x4C18E
            };
            result.Exe.EnemyUnitExploitOffsets = new int[]
            {
                0x2A13C
            };
            result.Exe.NormalEquipUpLevelOffsets = new int[]
            {
                0x73A3
            };
            result.Exe.SpecialEquipUpLevelOffsets = new int[]
            {
                0x7392
            };

            result.Exe.Force.AtkEffectOffset = 0x6C81;
            result.Exe.Force.MoveSoundOffset = 0xA38C0;
            result.Exe.Force.MoveSpeedOffset = 0xA38E8;
            result.Exe.Force.AtkSoundOffset = 0xA3910;
            result.Exe.Force.AtkTypeOffset = 0xA3938;
            result.Exe.Force.TypeOffset = 0xA3988;
            result.Exe.Force.MagicDamageOffset = 0xA39B0;
            result.Exe.Force.AtkDelayOffset = 0xA3960;
            result.Exe.Force.AtkPincOffset = 0xA39D8;
            result.Exe.Force.SynastryOffset = 0xA3280;
            result.Exe.Force.AiTypeOffset = 0x4D0CC;

            result.Exe.Magic.MeffStartIndex = 0x00;
            result.Exe.Magic.MeffEndIndex = 0x49;
            result.Exe.Magic.MeffOffset = 0x858BE;

            result.Exe.Magic.McallStartIndex = 0x03;
            result.Exe.Magic.McallEndIndex = 0x43;
            result.Exe.Magic.McallOffset = 0x20BBE;

            result.Exe.Magic.MagicTypeStartIndex = 0x00;
            result.Exe.Magic.MagicTypeEndIndex = 0x49;
            result.Exe.Magic.MagicTypeOffset = 0x24E53;

            result.Exe.Magic.DamageTypeStartIndex = 0x00;
            result.Exe.Magic.DamageTypeEndIndex = 0x49;
            result.Exe.Magic.DamageTypeOffset = 0x48FC3;

            result.Exe.Magic.HealTypeStartIndex = 0x26;
            result.Exe.Magic.HealTypeEndIndex = 0x43;
            result.Exe.Magic.HealTypeOffset = 0x3BB14;

            result.Exe.Magic.AiTypeStartIndex = 0x00;
            result.Exe.Magic.AiTypeEndIndex = 0x48;
            result.Exe.Magic.AiTypeOffset = 0x39580;

            result.Exe.Magic.UseConditionStartIndex = 0x00;
            result.Exe.Magic.UseConditionEndIndex = 0x49;
            result.Exe.Magic.UseConditionOffset = 0x1F47C;

            result.Exe.Magic.DamageValueStartIndex = 0x00;
            result.Exe.Magic.DamageValueEndIndex = 0x48;
            result.Exe.Magic.DamageValueOffset = 0x3B71E;

            result.Exe.Magic.AccRateStartIndex = 0x00;
            result.Exe.Magic.AccRateEndIndex = 0x49;
            result.Exe.Magic.AccRateOffset = 0x3AE07;

            result.Exe.Magic.LearTypeStartIndex = 0x00;
            result.Exe.Magic.LearTypeEndIndex = 0x49;
            result.Exe.Magic.LearTypeOffset = 0x65208;

            result.Exe.Magic.ReflectTypeStartIndex = 0x00;
            result.Exe.Magic.ReflectTypeEndIndex = 0x49;
            result.Exe.Magic.ReflectTypeOffset = 0xC465;
            #endregion

            #region Save Setting
            result.Save.SpecialSkillOffset = 0x7800;
            result.Save.SpecialEffectOffset = 0x79B0;
            result.Save.BattleObjOffset = 0x00;
            result.Save.FaceObjOffset = 0xE000;
            result.Save.PmapObjOffset = 0xE800;
            #endregion

            #region ItemEffName Setting
            result.ItemEffects.Add(new Config.ConfigItemEffectNameInfos { Index = 0, Length = 4, Offset = 0x8AC70 });
            result.ItemEffects.Add(new Config.ConfigItemEffectNameInfos { Index = 1, Length = 4, Offset = 0x8AC70 });
            result.ItemEffects.Add(new Config.ConfigItemEffectNameInfos { Index = 2, Length = 4, Offset = 0x8AC75 });
            result.ItemEffects.Add(new Config.ConfigItemEffectNameInfos { Index = 3, Length = 4, Offset = 0x8AC75 });
            result.ItemEffects.Add(new Config.ConfigItemEffectNameInfos { Index = 4, Length = 4, Offset = 0x8AC7A });
            result.ItemEffects.Add(new Config.ConfigItemEffectNameInfos { Index = 5, Length = 4, Offset = 0x8AC7A });
            result.ItemEffects.Add(new Config.ConfigItemEffectNameInfos { Index = 6, Length = 4, Offset = 0x8AC7F });
            result.ItemEffects.Add(new Config.ConfigItemEffectNameInfos { Index = 7, Length = 4, Offset = 0x8AC7F });
            result.ItemEffects.Add(new Config.ConfigItemEffectNameInfos { Index = 8, Length = 4, Offset = 0x8AC84 });
            result.ItemEffects.Add(new Config.ConfigItemEffectNameInfos { Index = 9, Length = 4, Offset = 0x8AC84 });
            result.ItemEffects.Add(new Config.ConfigItemEffectNameInfos { Index = 10, Length = 4, Offset = 0x8AC89 });
            result.ItemEffects.Add(new Config.ConfigItemEffectNameInfos { Index = 11, Length = 4, Offset = 0x8AC89 });
            result.ItemEffects.Add(new Config.ConfigItemEffectNameInfos { Index = 12, Length = 4, Offset = 0x8AC8E });
            result.ItemEffects.Add(new Config.ConfigItemEffectNameInfos { Index = 13, Length = 4, Offset = 0x8AC8E });
            result.ItemEffects.Add(new Config.ConfigItemEffectNameInfos { Index = 14, Length = 4, Offset = 0x8AC93 });
            result.ItemEffects.Add(new Config.ConfigItemEffectNameInfos { Index = 15, Length = 4, Offset = 0x8AC93 });
            result.ItemEffects.Add(new Config.ConfigItemEffectNameInfos { Index = 16, Length = 4, Offset = 0x8AC98 });
            result.ItemEffects.Add(new Config.ConfigItemEffectNameInfos { Index = 17, Length = 4, Offset = 0x8AC98 });
            result.ItemEffects.Add(new Config.ConfigItemEffectNameInfos { Index = 18, Length = 4, Offset = 0x8AC9D });
            result.ItemEffects.Add(new Config.ConfigItemEffectNameInfos { Index = 19, Length = 4, Offset = 0x8AC9D });
            result.ItemEffects.Add(new Config.ConfigItemEffectNameInfos { Index = 20, Length = 4, Offset = 0x8ACA2 });
            result.ItemEffects.Add(new Config.ConfigItemEffectNameInfos { Index = 21, Length = 4, Offset = 0x8ACA2 });
            result.ItemEffects.Add(new Config.ConfigItemEffectNameInfos { Index = 22, Length = 4, Offset = 0x8ACA7 });
            result.ItemEffects.Add(new Config.ConfigItemEffectNameInfos { Index = 23, Length = 4, Offset = 0x8ACA7 });
            result.ItemEffects.Add(new Config.ConfigItemEffectNameInfos { Index = 24, Length = 4, Offset = 0x8ACAC });
            result.ItemEffects.Add(new Config.ConfigItemEffectNameInfos { Index = 25, Length = 4, Offset = 0x8ACAC });

            result.ItemEffects.Add(new Config.ConfigItemEffectNameInfos { Index = 26, Length = 12, Offset = 0x8A9E8 });
            result.ItemEffects.Add(new Config.ConfigItemEffectNameInfos { Index = 27, Length = 12, Offset = 0x8A9F5 });
            result.ItemEffects.Add(new Config.ConfigItemEffectNameInfos { Index = 28, Length = 14, Offset = 0x8AA02 });
            result.ItemEffects.Add(new Config.ConfigItemEffectNameInfos { Index = 29, Length = 12, Offset = 0x8AA11 });

            result.ItemEffects.Add(new Config.ConfigItemEffectNameInfos { Index = 30, Length = 17, Offset = 0x8AA1E });
            result.ItemEffects.Add(new Config.ConfigItemEffectNameInfos { Index = 31, Length = 8, Offset = 0x8AA30 });
            result.ItemEffects.Add(new Config.ConfigItemEffectNameInfos { Index = 32, Length = 10, Offset = 0x8AA39 });
            result.ItemEffects.Add(new Config.ConfigItemEffectNameInfos { Index = 33, Length = 10, Offset = 0x8AA44 });
            result.ItemEffects.Add(new Config.ConfigItemEffectNameInfos { Index = 34, Length = 10, Offset = 0x8AA4F });
            result.ItemEffects.Add(new Config.ConfigItemEffectNameInfos { Index = 35, Length = 10, Offset = 0x8AA5A });
            result.ItemEffects.Add(new Config.ConfigItemEffectNameInfos { Index = 36, Length = 8, Offset = 0x8AA65 });
            result.ItemEffects.Add(new Config.ConfigItemEffectNameInfos { Index = 37, Length = 6, Offset = 0x8AA6E });
            result.ItemEffects.Add(new Config.ConfigItemEffectNameInfos { Index = 38, Length = 6, Offset = 0x8AA75 });
            result.ItemEffects.Add(new Config.ConfigItemEffectNameInfos { Index = 39, Length = 11, Offset = 0x8AA7C });
            result.ItemEffects.Add(new Config.ConfigItemEffectNameInfos { Index = 40, Length = 10, Offset = 0x8AA88 });

            result.ItemEffects.Add(new Config.ConfigItemEffectNameInfos { Index = 41, Length = 8, Offset = 0x8AA93 });
            result.ItemEffects.Add(new Config.ConfigItemEffectNameInfos { Index = 42, Length = 8, Offset = 0x8AA9C });
            result.ItemEffects.Add(new Config.ConfigItemEffectNameInfos { Index = 43, Length = 8, Offset = 0x8AAA5 });
            result.ItemEffects.Add(new Config.ConfigItemEffectNameInfos { Index = 44, Length = 8, Offset = 0x8AAAE });
            result.ItemEffects.Add(new Config.ConfigItemEffectNameInfos { Index = 45, Length = 8, Offset = 0x8AAB7 });
            result.ItemEffects.Add(new Config.ConfigItemEffectNameInfos { Index = 46, Length = 8, Offset = 0x8AAC0 });
            result.ItemEffects.Add(new Config.ConfigItemEffectNameInfos { Index = 47, Length = 12, Offset = 0x8AAC9 });
            result.ItemEffects.Add(new Config.ConfigItemEffectNameInfos { Index = 48, Length = 12, Offset = 0x8AAD6 });
            result.ItemEffects.Add(new Config.ConfigItemEffectNameInfos { Index = 49, Length = 12, Offset = 0x8AAE3 });
            result.ItemEffects.Add(new Config.ConfigItemEffectNameInfos { Index = 50, Length = 8, Offset = 0x8AAF0 });

            result.ItemEffects.Add(new Config.ConfigItemEffectNameInfos { Index = 51, Length = 8, Offset = 0x8AAF9 });
            result.ItemEffects.Add(new Config.ConfigItemEffectNameInfos { Index = 52, Length = 10, Offset = 0x8AB02 });
            result.ItemEffects.Add(new Config.ConfigItemEffectNameInfos { Index = 53, Length = 8, Offset = 0x8AB0D });
            result.ItemEffects.Add(new Config.ConfigItemEffectNameInfos { Index = 54, Length = 8, Offset = 0x8AB16 });
            result.ItemEffects.Add(new Config.ConfigItemEffectNameInfos { Index = 55, Length = 12, Offset = 0x8AB1F });
            result.ItemEffects.Add(new Config.ConfigItemEffectNameInfos { Index = 56, Length = 12, Offset = 0x8AB2C });
            result.ItemEffects.Add(new Config.ConfigItemEffectNameInfos { Index = 57, Length = 6, Offset = 0x8AB39 });
            result.ItemEffects.Add(new Config.ConfigItemEffectNameInfos { Index = 58, Length = 8, Offset = 0x8AB40 });
            result.ItemEffects.Add(new Config.ConfigItemEffectNameInfos { Index = 59, Length = 8, Offset = 0x8AB49 });
            result.ItemEffects.Add(new Config.ConfigItemEffectNameInfos { Index = 60, Length = 12, Offset = 0x8AB52 });

            result.ItemEffects.Add(new Config.ConfigItemEffectNameInfos { Index = 61, Length = 12, Offset = 0x8AB5F });
            result.ItemEffects.Add(new Config.ConfigItemEffectNameInfos { Index = 62, Length = 12, Offset = 0x8AB6C });
            result.ItemEffects.Add(new Config.ConfigItemEffectNameInfos { Index = 63, Length = 10, Offset = 0x8AB79 });
            result.ItemEffects.Add(new Config.ConfigItemEffectNameInfos { Index = 64, Length = 12, Offset = 0x8AB84 });
            result.ItemEffects.Add(new Config.ConfigItemEffectNameInfos { Index = 65, Length = 12, Offset = 0x8AB91 });
            result.ItemEffects.Add(new Config.ConfigItemEffectNameInfos { Index = 66, Length = 8, Offset = 0x8AB9E });
            result.ItemEffects.Add(new Config.ConfigItemEffectNameInfos { Index = 67, Length = 12, Offset = 0x8ABA7 });
            result.ItemEffects.Add(new Config.ConfigItemEffectNameInfos { Index = 68, Length = 10, Offset = 0x8ABB4 });
            result.ItemEffects.Add(new Config.ConfigItemEffectNameInfos { Index = 69, Length = 12, Offset = 0x8ABBF });
            result.ItemEffects.Add(new Config.ConfigItemEffectNameInfos { Index = 70, Length = 8, Offset = 0x8ABCC });

            result.ItemEffects.Add(new Config.ConfigItemEffectNameInfos { Index = 89, Length = 12, Offset = 0x8ABD5 });
            result.ItemEffects.Add(new Config.ConfigItemEffectNameInfos { Index = 90, Length = 8, Offset = 0x8ABE2 });

            result.ItemEffects.Add(new Config.ConfigItemEffectNameInfos { Index = 91, Length = 8, Offset = 0x8ABEB });
            result.ItemEffects.Add(new Config.ConfigItemEffectNameInfos { Index = 92, Length = 8, Offset = 0x8ABF4 });
            result.ItemEffects.Add(new Config.ConfigItemEffectNameInfos { Index = 93, Length = 8, Offset = 0x8ABFD });
            result.ItemEffects.Add(new Config.ConfigItemEffectNameInfos { Index = 94, Length = 12, Offset = 0x8AC06 });
            result.ItemEffects.Add(new Config.ConfigItemEffectNameInfos { Index = 95, Length = 8, Offset = 0x8AC13 });
            result.ItemEffects.Add(new Config.ConfigItemEffectNameInfos { Index = 96, Length = 8, Offset = 0x8AC1C });
            result.ItemEffects.Add(new Config.ConfigItemEffectNameInfos { Index = 97, Length = 8, Offset = 0x8AC25 });
            result.ItemEffects.Add(new Config.ConfigItemEffectNameInfos { Index = 98, Length = 8, Offset = 0x8AC2E });
            result.ItemEffects.Add(new Config.ConfigItemEffectNameInfos { Index = 99, Length = 8, Offset = 0x8AC37 });
            result.ItemEffects.Add(new Config.ConfigItemEffectNameInfos { Index = 100, Length = 8, Offset = 0x8AC40 });

            result.ItemEffects.Add(new Config.ConfigItemEffectNameInfos { Index = 101, Length = 8, Offset = 0xD1C10 });
            result.ItemEffects.Add(new Config.ConfigItemEffectNameInfos { Index = 102, Length = 8, Offset = 0xD1C19 });
            result.ItemEffects.Add(new Config.ConfigItemEffectNameInfos { Index = 103, Length = 8, Offset = 0xD1C22 });
            result.ItemEffects.Add(new Config.ConfigItemEffectNameInfos { Index = 104, Length = 8, Offset = 0xD1C2B });
            result.ItemEffects.Add(new Config.ConfigItemEffectNameInfos { Index = 105, Length = 8, Offset = 0xD1C34 });
            result.ItemEffects.Add(new Config.ConfigItemEffectNameInfos { Index = 106, Length = 8, Offset = 0xD1C3D });
            result.ItemEffects.Add(new Config.ConfigItemEffectNameInfos { Index = 107, Length = 8, Offset = 0xD1C46 });
            result.ItemEffects.Add(new Config.ConfigItemEffectNameInfos { Index = 108, Length = 8, Offset = 0xD1C4F });
            result.ItemEffects.Add(new Config.ConfigItemEffectNameInfos { Index = 109, Length = 8, Offset = 0xD1C58 });
            result.ItemEffects.Add(new Config.ConfigItemEffectNameInfos { Index = 110, Length = 8, Offset = 0xD1C61 });

            result.ItemEffects.Add(new Config.ConfigItemEffectNameInfos { Index = 111, Length = 8, Offset = 0xD1C6A });
            result.ItemEffects.Add(new Config.ConfigItemEffectNameInfos { Index = 112, Length = 8, Offset = 0xD1C73 });
            result.ItemEffects.Add(new Config.ConfigItemEffectNameInfos { Index = 113, Length = 8, Offset = 0xD1C7C });
            result.ItemEffects.Add(new Config.ConfigItemEffectNameInfos { Index = 114, Length = 8, Offset = 0xD1C85 });
            result.ItemEffects.Add(new Config.ConfigItemEffectNameInfos { Index = 115, Length = 8, Offset = 0xD1C8E });
            result.ItemEffects.Add(new Config.ConfigItemEffectNameInfos { Index = 116, Length = 8, Offset = 0x8AB6C });

            result.ItemEffects.Add(new Config.ConfigItemEffectNameInfos { Index = 71, Length = 6, Offset = 0x8ACC0 });
            result.ItemEffects.Add(new Config.ConfigItemEffectNameInfos { Index = 72, Length = 6, Offset = 0x8ACC7 });
            result.ItemEffects.Add(new Config.ConfigItemEffectNameInfos { Index = 73, Length = 8, Offset = 0x8ACCE });
            result.ItemEffects.Add(new Config.ConfigItemEffectNameInfos { Index = 74, Length = 8, Offset = 0x8ACD7 });
            result.ItemEffects.Add(new Config.ConfigItemEffectNameInfos { Index = 75, Length = 8, Offset = 0x8ACE0 });
            result.ItemEffects.Add(new Config.ConfigItemEffectNameInfos { Index = 76, Length = 8, Offset = 0x8ACE9 });
            result.ItemEffects.Add(new Config.ConfigItemEffectNameInfos { Index = 77, Length = 8, Offset = 0x8ACF2 });
            result.ItemEffects.Add(new Config.ConfigItemEffectNameInfos { Index = 78, Length = 8, Offset = 0x8ACFB });
            result.ItemEffects.Add(new Config.ConfigItemEffectNameInfos { Index = 79, Length = 8, Offset = 0x8AD04 });
            result.ItemEffects.Add(new Config.ConfigItemEffectNameInfos { Index = 80, Length = 10, Offset = 0x8AD0D });

            result.ItemEffects.Add(new Config.ConfigItemEffectNameInfos { Index = 81, Length = 8, Offset = 0x8AD18 });
            result.ItemEffects.Add(new Config.ConfigItemEffectNameInfos { Index = 82, Length = 8, Offset = 0x8AD21 });
            result.ItemEffects.Add(new Config.ConfigItemEffectNameInfos { Index = 83, Length = 8, Offset = 0x8AD2A });
            result.ItemEffects.Add(new Config.ConfigItemEffectNameInfos { Index = 84, Length = 8, Offset = 0x8AD33 });
            result.ItemEffects.Add(new Config.ConfigItemEffectNameInfos { Index = 85, Length = 8, Offset = 0x8AD3C });
            result.ItemEffects.Add(new Config.ConfigItemEffectNameInfos { Index = 86, Length = 8, Offset = 0x8AD45 });
            result.ItemEffects.Add(new Config.ConfigItemEffectNameInfos { Index = 87, Length = 8, Offset = 0x8AD4E });
            result.ItemEffects.Add(new Config.ConfigItemEffectNameInfos { Index = 88, Length = 6, Offset = 0x8AD4E });
            #endregion

            #region ForceName Setting
            result.ForceNames.Add(new Config.ConfigForceNameInfos { Index = 0, Length = 8, Offset = 0xD18D0 });
            result.ForceNames.Add(new Config.ConfigForceNameInfos { Index = 1, Length = 8, Offset = 0xD18D9 });
            result.ForceNames.Add(new Config.ConfigForceNameInfos { Index = 2, Length = 8, Offset = 0xD18E2 });
            result.ForceNames.Add(new Config.ConfigForceNameInfos { Index = 3, Length = 8, Offset = 0xD18EB });
            result.ForceNames.Add(new Config.ConfigForceNameInfos { Index = 4, Length = 8, Offset = 0xD18F4 });
            result.ForceNames.Add(new Config.ConfigForceNameInfos { Index = 5, Length = 8, Offset = 0xD18FD });
            result.ForceNames.Add(new Config.ConfigForceNameInfos { Index = 6, Length = 8, Offset = 0xD1906 });
            result.ForceNames.Add(new Config.ConfigForceNameInfos { Index = 7, Length = 8, Offset = 0xD190F });
            result.ForceNames.Add(new Config.ConfigForceNameInfos { Index = 8, Length = 8, Offset = 0xD1918 });
            result.ForceNames.Add(new Config.ConfigForceNameInfos { Index = 9, Length = 8, Offset = 0xD1921 });
            result.ForceNames.Add(new Config.ConfigForceNameInfos { Index = 10, Length = 8, Offset = 0xD192A });

            result.ForceNames.Add(new Config.ConfigForceNameInfos { Index = 11, Length = 8, Offset = 0xD1933 });
            result.ForceNames.Add(new Config.ConfigForceNameInfos { Index = 12, Length = 8, Offset = 0xD193C });
            result.ForceNames.Add(new Config.ConfigForceNameInfos { Index = 13, Length = 8, Offset = 0xD1945 });
            result.ForceNames.Add(new Config.ConfigForceNameInfos { Index = 14, Length = 8, Offset = 0xD194E });
            result.ForceNames.Add(new Config.ConfigForceNameInfos { Index = 15, Length = 8, Offset = 0xD1957 });
            result.ForceNames.Add(new Config.ConfigForceNameInfos { Index = 16, Length = 8, Offset = 0xD1960 });
            result.ForceNames.Add(new Config.ConfigForceNameInfos { Index = 17, Length = 8, Offset = 0xD1969 });
            result.ForceNames.Add(new Config.ConfigForceNameInfos { Index = 18, Length = 8, Offset = 0xD1972 });
            result.ForceNames.Add(new Config.ConfigForceNameInfos { Index = 19, Length = 8, Offset = 0xD197B });
            result.ForceNames.Add(new Config.ConfigForceNameInfos { Index = 20, Length = 8, Offset = 0xD1984 });

            result.ForceNames.Add(new Config.ConfigForceNameInfos { Index = 21, Length = 8, Offset = 0xD198D });
            result.ForceNames.Add(new Config.ConfigForceNameInfos { Index = 22, Length = 8, Offset = 0xD1996 });
            result.ForceNames.Add(new Config.ConfigForceNameInfos { Index = 23, Length = 8, Offset = 0xD199F });
            result.ForceNames.Add(new Config.ConfigForceNameInfos { Index = 24, Length = 8, Offset = 0xD19A8 });
            result.ForceNames.Add(new Config.ConfigForceNameInfos { Index = 25, Length = 8, Offset = 0xD19B1 });
            result.ForceNames.Add(new Config.ConfigForceNameInfos { Index = 26, Length = 8, Offset = 0xD19BA });
            result.ForceNames.Add(new Config.ConfigForceNameInfos { Index = 27, Length = 8, Offset = 0xD19C3 });
            result.ForceNames.Add(new Config.ConfigForceNameInfos { Index = 28, Length = 8, Offset = 0xD19CC });
            result.ForceNames.Add(new Config.ConfigForceNameInfos { Index = 29, Length = 8, Offset = 0xD19D5 });
            result.ForceNames.Add(new Config.ConfigForceNameInfos { Index = 30, Length = 8, Offset = 0xD19DE });

            result.ForceNames.Add(new Config.ConfigForceNameInfos { Index = 31, Length = 8, Offset = 0xD19E7 });
            result.ForceNames.Add(new Config.ConfigForceNameInfos { Index = 32, Length = 8, Offset = 0xD19F0 });
            result.ForceNames.Add(new Config.ConfigForceNameInfos { Index = 33, Length = 8, Offset = 0xD19F9 });
            result.ForceNames.Add(new Config.ConfigForceNameInfos { Index = 34, Length = 8, Offset = 0xD1A02 });
            result.ForceNames.Add(new Config.ConfigForceNameInfos { Index = 35, Length = 8, Offset = 0xD1A0B });
            result.ForceNames.Add(new Config.ConfigForceNameInfos { Index = 36, Length = 8, Offset = 0xD1A14 });
            result.ForceNames.Add(new Config.ConfigForceNameInfos { Index = 37, Length = 8, Offset = 0xD1A1D });
            result.ForceNames.Add(new Config.ConfigForceNameInfos { Index = 38, Length = 8, Offset = 0xD1A26 });
            result.ForceNames.Add(new Config.ConfigForceNameInfos { Index = 39, Length = 8, Offset = 0xD1A2F });
            result.ForceNames.Add(new Config.ConfigForceNameInfos { Index = 40, Length = 8, Offset = 0xD1A38 });

            result.ForceNames.Add(new Config.ConfigForceNameInfos { Index = 41, Length = 8, Offset = 0xD1A41 });
            result.ForceNames.Add(new Config.ConfigForceNameInfos { Index = 42, Length = 8, Offset = 0xD1A4A });
            result.ForceNames.Add(new Config.ConfigForceNameInfos { Index = 43, Length = 8, Offset = 0xD1A53 });
            result.ForceNames.Add(new Config.ConfigForceNameInfos { Index = 44, Length = 8, Offset = 0xD1A5C });
            result.ForceNames.Add(new Config.ConfigForceNameInfos { Index = 45, Length = 8, Offset = 0xD1A65 });
            result.ForceNames.Add(new Config.ConfigForceNameInfos { Index = 46, Length = 8, Offset = 0xD1A6E });
            result.ForceNames.Add(new Config.ConfigForceNameInfos { Index = 47, Length = 8, Offset = 0xD1A77 });
            result.ForceNames.Add(new Config.ConfigForceNameInfos { Index = 48, Length = 8, Offset = 0xD1A80 });
            result.ForceNames.Add(new Config.ConfigForceNameInfos { Index = 49, Length = 8, Offset = 0xD1A89 });
            result.ForceNames.Add(new Config.ConfigForceNameInfos { Index = 50, Length = 8, Offset = 0xD1A92 });

            result.ForceNames.Add(new Config.ConfigForceNameInfos { Index = 51, Length = 8, Offset = 0xD1A9B });
            result.ForceNames.Add(new Config.ConfigForceNameInfos { Index = 52, Length = 8, Offset = 0xD1AA4 });
            result.ForceNames.Add(new Config.ConfigForceNameInfos { Index = 53, Length = 8, Offset = 0xD1AAD });
            result.ForceNames.Add(new Config.ConfigForceNameInfos { Index = 54, Length = 8, Offset = 0xD1AB6 });
            result.ForceNames.Add(new Config.ConfigForceNameInfos { Index = 55, Length = 8, Offset = 0xD1ABF });
            result.ForceNames.Add(new Config.ConfigForceNameInfos { Index = 56, Length = 8, Offset = 0xD1AC8 });
            result.ForceNames.Add(new Config.ConfigForceNameInfos { Index = 57, Length = 8, Offset = 0xD1AD1 });
            result.ForceNames.Add(new Config.ConfigForceNameInfos { Index = 58, Length = 8, Offset = 0xD1ADA });
            result.ForceNames.Add(new Config.ConfigForceNameInfos { Index = 59, Length = 8, Offset = 0xD1AE3 });
            result.ForceNames.Add(new Config.ConfigForceNameInfos { Index = 60, Length = 8, Offset = 0xD1AEC });

            result.ForceNames.Add(new Config.ConfigForceNameInfos { Index = 61, Length = 8, Offset = 0xD1AF5 });
            result.ForceNames.Add(new Config.ConfigForceNameInfos { Index = 62, Length = 8, Offset = 0xD1AFE });
            result.ForceNames.Add(new Config.ConfigForceNameInfos { Index = 63, Length = 8, Offset = 0xD1B07 });
            result.ForceNames.Add(new Config.ConfigForceNameInfos { Index = 64, Length = 8, Offset = 0xD1B10 });
            result.ForceNames.Add(new Config.ConfigForceNameInfos { Index = 65, Length = 8, Offset = 0xD1B19 });
            result.ForceNames.Add(new Config.ConfigForceNameInfos { Index = 66, Length = 8, Offset = 0xD1B22 });
            result.ForceNames.Add(new Config.ConfigForceNameInfos { Index = 67, Length = 8, Offset = 0xD1B2B });
            result.ForceNames.Add(new Config.ConfigForceNameInfos { Index = 68, Length = 8, Offset = 0xD1B34 });
            result.ForceNames.Add(new Config.ConfigForceNameInfos { Index = 69, Length = 8, Offset = 0xD1B3D });
            result.ForceNames.Add(new Config.ConfigForceNameInfos { Index = 70, Length = 8, Offset = 0xD1B46 });

            result.ForceNames.Add(new Config.ConfigForceNameInfos { Index = 71, Length = 8, Offset = 0xD1B4F });
            result.ForceNames.Add(new Config.ConfigForceNameInfos { Index = 72, Length = 8, Offset = 0xD1B58 });
            result.ForceNames.Add(new Config.ConfigForceNameInfos { Index = 73, Length = 8, Offset = 0xD1B61 });
            result.ForceNames.Add(new Config.ConfigForceNameInfos { Index = 74, Length = 8, Offset = 0xD1B6A });
            result.ForceNames.Add(new Config.ConfigForceNameInfos { Index = 75, Length = 8, Offset = 0xD1B73 });
            result.ForceNames.Add(new Config.ConfigForceNameInfos { Index = 76, Length = 8, Offset = 0xD1B7C });
            result.ForceNames.Add(new Config.ConfigForceNameInfos { Index = 77, Length = 8, Offset = 0xD1B85 });
            result.ForceNames.Add(new Config.ConfigForceNameInfos { Index = 78, Length = 8, Offset = 0xD1B8E });
            result.ForceNames.Add(new Config.ConfigForceNameInfos { Index = 79, Length = 8, Offset = 0xD1B97 });
            #endregion
                                                            
            return result;
        }

        private void CreateForceCategoryName()
        {
            result.ForceCategoryNames.Add(new Config.ConfigForceCategoryNameInfos { Index = 0, Length = 8, Offset = 0x8B010 });
            result.ForceCategoryNames.Add(new Config.ConfigForceCategoryNameInfos { Index = 1, Length = 8, Offset = 0x8B019 });
            result.ForceCategoryNames.Add(new Config.ConfigForceCategoryNameInfos { Index = 2, Length = 8, Offset = 0x8B022 });
            result.ForceCategoryNames.Add(new Config.ConfigForceCategoryNameInfos { Index = 3, Length = 8, Offset = 0x8B02B });
            result.ForceCategoryNames.Add(new Config.ConfigForceCategoryNameInfos { Index = 4, Length = 8, Offset = 0x8B034 });
            result.ForceCategoryNames.Add(new Config.ConfigForceCategoryNameInfos { Index = 5, Length = 8, Offset = 0x8B03D });
            result.ForceCategoryNames.Add(new Config.ConfigForceCategoryNameInfos { Index = 6, Length = 8, Offset = 0x8B046 });
            result.ForceCategoryNames.Add(new Config.ConfigForceCategoryNameInfos { Index = 7, Length = 8, Offset = 0x8B04F });
            result.ForceCategoryNames.Add(new Config.ConfigForceCategoryNameInfos { Index = 8, Length = 8, Offset = 0x8B058 });
            result.ForceCategoryNames.Add(new Config.ConfigForceCategoryNameInfos { Index = 9, Length = 8, Offset = 0x8B061 });

            result.ForceCategoryNames.Add(new Config.ConfigForceCategoryNameInfos { Index = 10, Length = 8, Offset = 0x8B06A });
            result.ForceCategoryNames.Add(new Config.ConfigForceCategoryNameInfos { Index = 11, Length = 8, Offset = 0x8B073 });
            result.ForceCategoryNames.Add(new Config.ConfigForceCategoryNameInfos { Index = 12, Length = 8, Offset = 0x8B07C });
            result.ForceCategoryNames.Add(new Config.ConfigForceCategoryNameInfos { Index = 13, Length = 8, Offset = 0x8B085 });
            result.ForceCategoryNames.Add(new Config.ConfigForceCategoryNameInfos { Index = 14, Length = 8, Offset = 0x8B08E });
            result.ForceCategoryNames.Add(new Config.ConfigForceCategoryNameInfos { Index = 15, Length = 8, Offset = 0x8B097 });
            result.ForceCategoryNames.Add(new Config.ConfigForceCategoryNameInfos { Index = 16, Length = 8, Offset = 0x8B0A0 });
            result.ForceCategoryNames.Add(new Config.ConfigForceCategoryNameInfos { Index = 17, Length = 8, Offset = 0x8B0A9 });
            result.ForceCategoryNames.Add(new Config.ConfigForceCategoryNameInfos { Index = 18, Length = 8, Offset = 0x8B0B2 });
            result.ForceCategoryNames.Add(new Config.ConfigForceCategoryNameInfos { Index = 19, Length = 8, Offset = 0x8B0BB });

            result.ForceCategoryNames.Add(new Config.ConfigForceCategoryNameInfos { Index = 20, Length = 8, Offset = 0x8B0C4 });
            result.ForceCategoryNames.Add(new Config.ConfigForceCategoryNameInfos { Index = 21, Length = 8, Offset = 0x8B0CD });
            result.ForceCategoryNames.Add(new Config.ConfigForceCategoryNameInfos { Index = 22, Length = 8, Offset = 0x8B0D6 });
            result.ForceCategoryNames.Add(new Config.ConfigForceCategoryNameInfos { Index = 23, Length = 8, Offset = 0x8B0DF });
            result.ForceCategoryNames.Add(new Config.ConfigForceCategoryNameInfos { Index = 24, Length = 8, Offset = 0x8B0E8 });
            result.ForceCategoryNames.Add(new Config.ConfigForceCategoryNameInfos { Index = 25, Length = 8, Offset = 0x8B0F1 });
            result.ForceCategoryNames.Add(new Config.ConfigForceCategoryNameInfos { Index = 26, Length = 8, Offset = 0x8B0FA });
            result.ForceCategoryNames.Add(new Config.ConfigForceCategoryNameInfos { Index = 27, Length = 8, Offset = 0x8B103 });
            result.ForceCategoryNames.Add(new Config.ConfigForceCategoryNameInfos { Index = 28, Length = 8, Offset = 0x8B10C });
            result.ForceCategoryNames.Add(new Config.ConfigForceCategoryNameInfos { Index = 29, Length = 8, Offset = 0x8B115 });

            result.ForceCategoryNames.Add(new Config.ConfigForceCategoryNameInfos { Index = 30, Length = 8, Offset = 0x8B11E });
            result.ForceCategoryNames.Add(new Config.ConfigForceCategoryNameInfos { Index = 31, Length = 8, Offset = 0x8B127 });
            result.ForceCategoryNames.Add(new Config.ConfigForceCategoryNameInfos { Index = 32, Length = 8, Offset = 0x8B130 });
            result.ForceCategoryNames.Add(new Config.ConfigForceCategoryNameInfos { Index = 33, Length = 8, Offset = 0x8B139 });
            result.ForceCategoryNames.Add(new Config.ConfigForceCategoryNameInfos { Index = 34, Length = 8, Offset = 0x8B142 });
            result.ForceCategoryNames.Add(new Config.ConfigForceCategoryNameInfos { Index = 35, Length = 8, Offset = 0x8B14B });
            result.ForceCategoryNames.Add(new Config.ConfigForceCategoryNameInfos { Index = 36, Length = 8, Offset = 0x8B154 });
            result.ForceCategoryNames.Add(new Config.ConfigForceCategoryNameInfos { Index = 37, Length = 8, Offset = 0x8B15D });
            result.ForceCategoryNames.Add(new Config.ConfigForceCategoryNameInfos { Index = 38, Length = 8, Offset = 0x8B166 });
            result.ForceCategoryNames.Add(new Config.ConfigForceCategoryNameInfos { Index = 39, Length = 8, Offset = 0x8B16F });
        }

        private void CreateHitAreaName()
        {
            result.HitAreaNames.Add("군웅 경기병");
            result.HitAreaNames.Add("보병");
            result.HitAreaNames.Add("궁병 노기병");
            result.HitAreaNames.Add("노병");
            result.HitAreaNames.Add("연노병");
            result.HitAreaNames.Add("폭염");
            result.HitAreaNames.Add("몰우전");
            result.HitAreaNames.Add("경포차");
            result.HitAreaNames.Add("벽력차");
            result.HitAreaNames.Add("궁기병");
            result.HitAreaNames.Add("전체");
            result.HitAreaNames.Add("무공격");
            result.HitAreaNames.Add("대몰우전");
            result.HitAreaNames.Add("거대몰우전");
            result.HitAreaNames.Add("특수");
            result.HitAreaNames.Add("대방괴");
            result.HitAreaNames.Add("자객1");
            result.HitAreaNames.Add("자객2");
            result.HitAreaNames.Add("자객3");
            result.HitAreaNames.Add("대폭염");
            result.HitAreaNames.Add("방괴1");
            result.HitAreaNames.Add("방괴2");
            result.HitAreaNames.Add("방괴3");
            result.HitAreaNames.Add("교차일격");
            result.HitAreaNames.Add("교차이격");
            result.HitAreaNames.Add("청정");
            result.HitAreaNames.Add("운하");
            result.HitAreaNames.Add("등궁");
            result.HitAreaNames.Add("노");
            result.HitAreaNames.Add("참월");
            result.HitAreaNames.Add("사방죽궁");
            result.HitAreaNames.Add("남만궁");
            result.HitAreaNames.Add("12격");
        }

        private void CreateEffectAreaName()
        {
            result.EffAreaNames.Add("무");
            result.EffAreaNames.Add("십자");
            result.EffAreaNames.Add("구궁");
            result.EffAreaNames.Add("몰우전");
            result.EffAreaNames.Add("이격");
            result.EffAreaNames.Add("육격");
            result.EffAreaNames.Add("대몰우전");
            result.EffAreaNames.Add("삼격");
            result.EffAreaNames.Add("방괴");
        }

        private void CreateSpecialEffect()
        {
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 0, Length = 0x10, Offset = 0xF9430 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 1, Length = 0x10, Offset = 0xF9440 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 2, Length = 0x10, Offset = 0xF9450 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 3, Length = 0x10, Offset = 0xF9460 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 4, Length = 0x10, Offset = 0xF9470 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 5, Length = 0x10, Offset = 0xF9480 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 6, Length = 0x10, Offset = 0xF9490 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 7, Length = 0x10, Offset = 0xF94A0 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 8, Length = 0x10, Offset = 0xF94B0 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 9, Length = 0x10, Offset = 0xF94C0 });

            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 10, Length = 0x10, Offset = 0xF94D0 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 11, Length = 0x10, Offset = 0xF94E0 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 12, Length = 0x10, Offset = 0xF94F0 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 13, Length = 0x10, Offset = 0xF9500 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 14, Length = 0x10, Offset = 0xF9510 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 15, Length = 0x10, Offset = 0xF9520 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 16, Length = 0x10, Offset = 0xF9530 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 17, Length = 0x10, Offset = 0xF9540 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 18, Length = 0x10, Offset = 0xF9550 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 19, Length = 0x10, Offset = 0xF9560 });

            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 20, Length = 0x10, Offset = 0xF9570 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 21, Length = 0x10, Offset = 0xF9580 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 22, Length = 0x10, Offset = 0xF9590 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 23, Length = 0x10, Offset = 0xF95A0 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 24, Length = 0x10, Offset = 0xF95B0 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 25, Length = 0x10, Offset = 0xF95C0 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 26, Length = 0x10, Offset = 0xF95D0 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 27, Length = 0x10, Offset = 0xF95E0 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 28, Length = 0x10, Offset = 0xF95F0 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 29, Length = 0x10, Offset = 0xF9600 });

            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 30, Length = 0x10, Offset = 0xF9610 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 31, Length = 0x10, Offset = 0xF9620 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 32, Length = 0x10, Offset = 0xF9630 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 33, Length = 0x10, Offset = 0xF9640 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 34, Length = 0x10, Offset = 0xF9650 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 35, Length = 0x10, Offset = 0xF9660 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 36, Length = 0x10, Offset = 0xF9670 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 37, Length = 0x10, Offset = 0xF9680 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 38, Length = 0x10, Offset = 0xF9690 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 39, Length = 0x10, Offset = 0xF96A0 });

            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 40, Length = 0x10, Offset = 0xF96B0 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 41, Length = 0x10, Offset = 0xF96C0 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 42, Length = 0x10, Offset = 0xF96D0 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 43, Length = 0x10, Offset = 0xF96E0 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 44, Length = 0x10, Offset = 0xF96F0 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 45, Length = 0x10, Offset = 0xF9700 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 46, Length = 0x10, Offset = 0xF9710 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 47, Length = 0x10, Offset = 0xF9720 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 48, Length = 0x10, Offset = 0xF9730 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 49, Length = 0x10, Offset = 0xF9740 });

            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 50, Length = 0x10, Offset = 0xF9750 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 51, Length = 0x10, Offset = 0xF9760 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 52, Length = 0x10, Offset = 0xF9770 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 53, Length = 0x10, Offset = 0xF9780 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 54, Length = 0x10, Offset = 0xF9790 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 55, Length = 0x10, Offset = 0xF97A0 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 56, Length = 0x10, Offset = 0xF97B0 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 57, Length = 0x10, Offset = 0xF97C0 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 58, Length = 0x10, Offset = 0xF97D0 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 59, Length = 0x10, Offset = 0xF97E0 });

            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 60, Length = 0x10, Offset = 0xF97F0 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 61, Length = 0x10, Offset = 0xF9800 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 62, Length = 0x10, Offset = 0xF9810 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 63, Length = 0x10, Offset = 0xF9820 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 64, Length = 0x10, Offset = 0xF9830 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 65, Length = 0x10, Offset = 0xF9840 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 66, Length = 0x10, Offset = 0xF9850 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 67, Length = 0x10, Offset = 0xF9860 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 68, Length = 0x10, Offset = 0xF9870 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 69, Length = 0x10, Offset = 0xF9880 });

            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 70, Length = 0x10, Offset = 0xF9890 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 71, Length = 0x10, Offset = 0xF98A0 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 72, Length = 0x10, Offset = 0xF98B0 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 73, Length = 0x10, Offset = 0xF98C0 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 74, Length = 0x10, Offset = 0xF98D0 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 75, Length = 0x10, Offset = 0xF98E0 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 76, Length = 0x10, Offset = 0xF98F0 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 77, Length = 0x10, Offset = 0xF9900 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 78, Length = 0x10, Offset = 0xF9910 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 79, Length = 0x10, Offset = 0xF9920 });

            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 80, Length = 0x10, Offset = 0xF9930 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 81, Length = 0x10, Offset = 0xF9940 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 82, Length = 0x10, Offset = 0xF9950 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 83, Length = 0x10, Offset = 0xF9960 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 84, Length = 0x10, Offset = 0xF9970 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 85, Length = 0x10, Offset = 0xF9980 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 86, Length = 0x10, Offset = 0xF9990 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 87, Length = 0x10, Offset = 0xF99A0 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 88, Length = 0x10, Offset = 0xF99B0 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 89, Length = 0x10, Offset = 0xF99C0 });

            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 90, Length = 0x10, Offset = 0xF99D0 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 91, Length = 0x10, Offset = 0xF99E0 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 92, Length = 0x10, Offset = 0xF99F0 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 93, Length = 0x10, Offset = 0xF9A00 });
            result.SpecialEffectNames.Add(new Config.ConfigSpecialEffectNameInfos { Index = 94, Length = 0x10, Offset = 0xF9A10 });
        }

        private void CreateSpecialSkillName()
        {
            result.SpecialSkillNames.Add(new Config.ConfigSpecialSkillNameInfos { Index = 0, Length = 0x10, Offset = 0xD0F11, Description = "공격력상승" });
            result.SpecialSkillNames.Add(new Config.ConfigSpecialSkillNameInfos { Index = 1, Length = 0x10, Offset = 0xD0F21, Description = "방어력상승" });
            result.SpecialSkillNames.Add(new Config.ConfigSpecialSkillNameInfos { Index = 2, Length = 0x10, Offset = 0xD0F31, Description = "정신력상승" });
            result.SpecialSkillNames.Add(new Config.ConfigSpecialSkillNameInfos { Index = 3, Length = 0x10, Offset = 0xD0F41, Description = "순발력상승" });
            result.SpecialSkillNames.Add(new Config.ConfigSpecialSkillNameInfos { Index = 4, Length = 0x10, Offset = 0xD0F51, Description = "사기상승" });
            result.SpecialSkillNames.Add(new Config.ConfigSpecialSkillNameInfos { Index = 5, Length = 0x10, Offset = 0xD0F61, Description = "이동력상승" });
            result.SpecialSkillNames.Add(new Config.ConfigSpecialSkillNameInfos { Index = 6, Length = 0x10, Offset = 0xD0F71, Description = "전능력상승" });
            result.SpecialSkillNames.Add(new Config.ConfigSpecialSkillNameInfos { Index = 7, Length = 0x10, Offset = 0xD0F81, Description = "공격저하" });
            result.SpecialSkillNames.Add(new Config.ConfigSpecialSkillNameInfos { Index = 8, Length = 0x10, Offset = 0xD0F91, Description = "방어저하" });
            result.SpecialSkillNames.Add(new Config.ConfigSpecialSkillNameInfos { Index = 9, Length = 0x10, Offset = 0xD0FA1, Description = "정신저하" });

            result.SpecialSkillNames.Add(new Config.ConfigSpecialSkillNameInfos { Index = 10, Length = 0x10, Offset = 0xD0FB1, Description = "순발저하" });
            result.SpecialSkillNames.Add(new Config.ConfigSpecialSkillNameInfos { Index = 11, Length = 0x10, Offset = 0xD0FC1, Description = "사기저하" });
            result.SpecialSkillNames.Add(new Config.ConfigSpecialSkillNameInfos { Index = 12, Length = 0x10, Offset = 0xD0FD1, Description = "이동저하" });
            result.SpecialSkillNames.Add(new Config.ConfigSpecialSkillNameInfos { Index = 13, Length = 0x10, Offset = 0xD0FE1, Description = "속성이상공격" });
            result.SpecialSkillNames.Add(new Config.ConfigSpecialSkillNameInfos { Index = 14, Length = 0x10, Offset = 0xD0FF1, Description = "부동공격" });
            result.SpecialSkillNames.Add(new Config.ConfigSpecialSkillNameInfos { Index = 15, Length = 0x10, Offset = 0xD1001, Description = "금책공격" });
            result.SpecialSkillNames.Add(new Config.ConfigSpecialSkillNameInfos { Index = 16, Length = 0x10, Offset = 0xD1011, Description = "혼란공격" });
            result.SpecialSkillNames.Add(new Config.ConfigSpecialSkillNameInfos { Index = 17, Length = 0x10, Offset = 0xD1021, Description = "중독공격" });
            result.SpecialSkillNames.Add(new Config.ConfigSpecialSkillNameInfos { Index = 18, Length = 0x10, Offset = 0xD1031, Description = "상태이상공격" });
            result.SpecialSkillNames.Add(new Config.ConfigSpecialSkillNameInfos { Index = 19, Length = 0x10, Offset = 0xD1041, Description = "흡혈공격" });

            result.SpecialSkillNames.Add(new Config.ConfigSpecialSkillNameInfos { Index = 20, Length = 0x10, Offset = 0xD1051, Description = "방어무시" });
            result.SpecialSkillNames.Add(new Config.ConfigSpecialSkillNameInfos { Index = 21, Length = 0x10, Offset = 0xD1061, Description = "돌파공격" });
            result.SpecialSkillNames.Add(new Config.ConfigSpecialSkillNameInfos { Index = 22, Length = 0x10, Offset = 0xD1071, Description = "분전공격" });
            result.SpecialSkillNames.Add(new Config.ConfigSpecialSkillNameInfos { Index = 23, Length = 0x10, Offset = 0xD1081, Description = "범위공격1" });
            result.SpecialSkillNames.Add(new Config.ConfigSpecialSkillNameInfos { Index = 24, Length = 0x10, Offset = 0xD1091, Description = "범위공격2" });
            result.SpecialSkillNames.Add(new Config.ConfigSpecialSkillNameInfos { Index = 25, Length = 0x10, Offset = 0xD10A1, Description = "범위공격3" });
            result.SpecialSkillNames.Add(new Config.ConfigSpecialSkillNameInfos { Index = 26, Length = 0x10, Offset = 0xD10B1, Description = "범위공격4" });

            result.SpecialSkillNames.Add(new Config.ConfigSpecialSkillNameInfos { Index = 27, Length = 0x10, Offset = 0xD10C1, Description = "모든 아군 회복" });
            result.SpecialSkillNames.Add(new Config.ConfigSpecialSkillNameInfos { Index = 28, Length = 0x10, Offset = 0xD10D1, Description = "모든 아군 패기" });
            result.SpecialSkillNames.Add(new Config.ConfigSpecialSkillNameInfos { Index = 29, Length = 0x10, Offset = 0xD10E1, Description = "모든 적군 제압" });

            result.SpecialSkillNames.Add(new Config.ConfigSpecialSkillNameInfos { Index = 30, Length = 0x10, Offset = 0xD10F1, Description = "모든 적군 상태이상" });
            result.SpecialSkillNames.Add(new Config.ConfigSpecialSkillNameInfos { Index = 31, Length = 0x10, Offset = 0xD1101, Description = "모든 아군 기합" });
            result.SpecialSkillNames.Add(new Config.ConfigSpecialSkillNameInfos { Index = 32, Length = 0x10, Offset = 0xD1111, Description = "모든 적군 위압" });
            result.SpecialSkillNames.Add(new Config.ConfigSpecialSkillNameInfos { Index = 33, Length = 0x10, Offset = 0xD1121, Description = "모든 아군 강화회복" });
            result.SpecialSkillNames.Add(new Config.ConfigSpecialSkillNameInfos { Index = 34, Length = 0x10, Offset = 0xD1131, Description = "우화팔진도" });
            result.SpecialSkillNames.Add(new Config.ConfigSpecialSkillNameInfos { Index = 35, Length = 0x10, Offset = 0xD1141, Description = "모든 아군 회귀" });
            result.SpecialSkillNames.Add(new Config.ConfigSpecialSkillNameInfos { Index = 36, Length = 0x10, Offset = 0xD1151, Description = "랜덤" });
        }

        private void CreateCodeEffectName()
        {
            result.CodeEffects.Add(new Config.ConfigCodeEffectInfos { Offset = 0x5BF8, TypeIndex = (int)Config.ConfigCodeEffectInfos.Type.AbilityAssist, Description = "공격력보조", Editable = false, SubEdit = 1 });
            result.CodeEffects.Add(new Config.ConfigCodeEffectInfos { Offset = 0x5C00, TypeIndex = (int)Config.ConfigCodeEffectInfos.Type.AbilityAssist, Description = "방어력보조", Editable = false, SubEdit = 1 });
            result.CodeEffects.Add(new Config.ConfigCodeEffectInfos { Offset = 0x5C08, TypeIndex = (int)Config.ConfigCodeEffectInfos.Type.AbilityAssist, Description = "정신력보조", Editable = false, SubEdit = 1 });
            result.CodeEffects.Add(new Config.ConfigCodeEffectInfos { Offset = 0x5C10, TypeIndex = (int)Config.ConfigCodeEffectInfos.Type.AbilityAssist, Description = "순발력보조", Editable = false, SubEdit = 1 });
            result.CodeEffects.Add(new Config.ConfigCodeEffectInfos { Offset = 0x5C18, TypeIndex = (int)Config.ConfigCodeEffectInfos.Type.AbilityAssist, Description = "사기보조", Editable = false, SubEdit = 1 });
            result.CodeEffects.Add(new Config.ConfigCodeEffectInfos { Offset = 0x5C20, TypeIndex = (int)Config.ConfigCodeEffectInfos.Type.AbilityAssist, Description = "HP보조", Editable = false, SubEdit = 1 });
            result.CodeEffects.Add(new Config.ConfigCodeEffectInfos { Offset = 0x5C28, TypeIndex = (int)Config.ConfigCodeEffectInfos.Type.AbilityAssist, Description = "MP보조", Editable = false, SubEdit = 1 });
            result.CodeEffects.Add(new Config.ConfigCodeEffectInfos { Offset = 0x5C30, TypeIndex = (int)Config.ConfigCodeEffectInfos.Type.AbilityAssist, Description = "획득Exp보조", Editable = false, SubEdit = 0 });
            result.CodeEffects.Add(new Config.ConfigCodeEffectInfos { Offset = 0x5C38, TypeIndex = (int)Config.ConfigCodeEffectInfos.Type.AbilityAssist, Description = "이동력보조", Editable = false, SubEdit = 0 });
            result.CodeEffects.Add(new Config.ConfigCodeEffectInfos { Offset = 0x361F8, TypeIndex = (int)Config.ConfigCodeEffectInfos.Type.AbilityAssist, Description = "능력정화", Editable = false, SubEdit = 0 });
            result.CodeEffects.Add(new Config.ConfigCodeEffectInfos { Offset = 0x3B7D4, TypeIndex = (int)Config.ConfigCodeEffectInfos.Type.AbilityAssist, Description = "능력각성", Editable = true, SubEdit = 0 });
            result.CodeEffects.Add(new Config.ConfigCodeEffectInfos { Offset = 0x3BF56, TypeIndex = (int)Config.ConfigCodeEffectInfos.Type.AbilityAssist, Description = "일치단결", Editable = true, SubEdit = 0 });
            result.CodeEffects.Add(new Config.ConfigCodeEffectInfos { Offset = 0x782B3, TypeIndex = (int)Config.ConfigCodeEffectInfos.Type.AbilityAssist, Description = "일기당천", Editable = true, SubEdit = 0 });
            result.CodeEffects.Add(new Config.ConfigCodeEffectInfos { Offset = 0x5AA92, TypeIndex = (int)Config.ConfigCodeEffectInfos.Type.AbilityAssist, Description = "악전고투", Editable = true, SubEdit = 0 });
            result.CodeEffects.Add(new Config.ConfigCodeEffectInfos { Offset = 0x5A64, TypeIndex = (int)Config.ConfigCodeEffectInfos.Type.AbilityAssist, Description = "MP공격", Editable = true, SubEdit = 0 });

            result.CodeEffects.Add(new Config.ConfigCodeEffectInfos { Offset = 0x4EDB1, TypeIndex = (int)Config.ConfigCodeEffectInfos.Type.SpecialAttack, Description = "치명일격", Editable = true, SubEdit = 0 });
            result.CodeEffects.Add(new Config.ConfigCodeEffectInfos { Offset = 0x50EB, TypeIndex = (int)Config.ConfigCodeEffectInfos.Type.SpecialAttack, Description = "주동/연환공격", Editable = false, SubEdit = 0 });
            result.CodeEffects.Add(new Config.ConfigCodeEffectInfos { Offset = 0xA0BEA, TypeIndex = (int)Config.ConfigCodeEffectInfos.Type.SpecialAttack, Description = "인도/분전공격", Editable = false, SubEdit = 0 });
            result.CodeEffects.Add(new Config.ConfigCodeEffectInfos { Offset = 0x10489, TypeIndex = (int)Config.ConfigCodeEffectInfos.Type.SpecialAttack, Description = "강화/돌파공격", Editable = true, SubEdit = 0 });
            result.CodeEffects.Add(new Config.ConfigCodeEffectInfos { Offset = 0x6C5A, TypeIndex = (int)Config.ConfigCodeEffectInfos.Type.SpecialAttack, Description = "범위공격", Editable = false, SubEdit = 0 });
            result.CodeEffects.Add(new Config.ConfigCodeEffectInfos { Offset = 0x587C, TypeIndex = (int)Config.ConfigCodeEffectInfos.Type.SpecialAttack, Description = "무반격공격", Editable = true, SubEdit = 0 });
            result.CodeEffects.Add(new Config.ConfigCodeEffectInfos { Offset = 0x5820, TypeIndex = (int)Config.ConfigCodeEffectInfos.Type.SpecialAttack, Description = "반격후반격", Editable = true, SubEdit = 0 });
            result.CodeEffects.Add(new Config.ConfigCodeEffectInfos { Offset = 0x5F8A, TypeIndex = (int)Config.ConfigCodeEffectInfos.Type.SpecialAttack, Description = "흡혈공격", Editable = true, SubEdit = 0 });
            result.CodeEffects.Add(new Config.ConfigCodeEffectInfos { Offset = 0x5FDB, TypeIndex = (int)Config.ConfigCodeEffectInfos.Type.SpecialAttack, Description = "금전약탈", Editable = true, SubEdit = 0 });
            result.CodeEffects.Add(new Config.ConfigCodeEffectInfos { Offset = 0x10312, TypeIndex = (int)Config.ConfigCodeEffectInfos.Type.SpecialAttack, Description = "선제공격", Editable = true, SubEdit = 0 });
            result.CodeEffects.Add(new Config.ConfigCodeEffectInfos { Offset = 0x3832A, TypeIndex = (int)Config.ConfigCodeEffectInfos.Type.SpecialAttack, Description = "지원공격", Editable = true, SubEdit = 0 });
            result.CodeEffects.Add(new Config.ConfigCodeEffectInfos { Offset = 0x3B22B, TypeIndex = (int)Config.ConfigCodeEffectInfos.Type.SpecialAttack, Description = "돌진공격", Editable = true, SubEdit = 0 });
            result.CodeEffects.Add(new Config.ConfigCodeEffectInfos { Offset = 0x3B29A, TypeIndex = (int)Config.ConfigCodeEffectInfos.Type.SpecialAttack, Description = "반격강화", Editable = true, SubEdit = 0 });
            result.CodeEffects.Add(new Config.ConfigCodeEffectInfos { Offset = 0x78310, TypeIndex = (int)Config.ConfigCodeEffectInfos.Type.SpecialAttack, Description = "보복공격", Editable = true, SubEdit = 0 });
            result.CodeEffects.Add(new Config.ConfigCodeEffectInfos { Offset = 0x3ECF7, TypeIndex = (int)Config.ConfigCodeEffectInfos.Type.SpecialAttack, Description = "간접공격1", Editable = false, SubEdit = 0 });
            result.CodeEffects.Add(new Config.ConfigCodeEffectInfos { Offset = 0x3ED02, TypeIndex = (int)Config.ConfigCodeEffectInfos.Type.SpecialAttack, Description = "간접공격2", Editable = true, SubEdit = 1 });
            result.CodeEffects.Add(new Config.ConfigCodeEffectInfos { Offset = 0x3ED14, TypeIndex = (int)Config.ConfigCodeEffectInfos.Type.SpecialAttack, Description = "간접공격3", Editable = true, SubEdit = 2 });
            result.CodeEffects.Add(new Config.ConfigCodeEffectInfos { Offset = 0x3B0B1, TypeIndex = (int)Config.ConfigCodeEffectInfos.Type.SpecialAttack, Description = "방어무시", Editable = false, SubEdit = 3 });
            result.CodeEffects.Add(new Config.ConfigCodeEffectInfos { Offset = 0xC219, TypeIndex = (int)Config.ConfigCodeEffectInfos.Type.SpecialAttack, Description = "맹공일격", Editable = true, SubEdit = 0 });
            result.CodeEffects.Add(new Config.ConfigCodeEffectInfos { Offset = 0xC24F, TypeIndex = (int)Config.ConfigCodeEffectInfos.Type.SpecialAttack, Description = "허점공격", Editable = true, SubEdit = 0 });
            result.CodeEffects.Add(new Config.ConfigCodeEffectInfos { Offset = 0xC283, TypeIndex = (int)Config.ConfigCodeEffectInfos.Type.SpecialAttack, Description = "약점공격", Editable = true, SubEdit = 0 });
            result.CodeEffects.Add(new Config.ConfigCodeEffectInfos { Offset = 0xC360, TypeIndex = (int)Config.ConfigCodeEffectInfos.Type.SpecialAttack, Description = "무조건반격", Editable = true, SubEdit = 0 });

            result.CodeEffects.Add(new Config.ConfigCodeEffectInfos { Offset = 0x3AA7A, TypeIndex = (int)Config.ConfigCodeEffectInfos.Type.AttackAcc, Description = "공격백발백중", Editable = true, SubEdit = 0 });
            result.CodeEffects.Add(new Config.ConfigCodeEffectInfos { Offset = 0x3AA92, TypeIndex = (int)Config.ConfigCodeEffectInfos.Type.AttackAcc, Description = "공격명중보조", Editable = true, SubEdit = 0 });
            result.CodeEffects.Add(new Config.ConfigCodeEffectInfos { Offset = 0x3AAB7, TypeIndex = (int)Config.ConfigCodeEffectInfos.Type.AttackAcc, Description = "공격방어보조", Editable = true, SubEdit = 0 });
            result.CodeEffects.Add(new Config.ConfigCodeEffectInfos { Offset = 0x102E3, TypeIndex = (int)Config.ConfigCodeEffectInfos.Type.AttackAcc, Description = "전방어보조", Editable = true, SubEdit = 0 });

            result.CodeEffects.Add(new Config.ConfigCodeEffectInfos { Offset = 0x3B659, TypeIndex = (int)Config.ConfigCodeEffectInfos.Type.Magic, Description = "원소책략보조", Editable = true, SubEdit = 0 });
            result.CodeEffects.Add(new Config.ConfigCodeEffectInfos { Offset = 0x51C5, TypeIndex = (int)Config.ConfigCodeEffectInfos.Type.Magic, Description = "책략위력보조", Editable = true, SubEdit = 0 });
            result.CodeEffects.Add(new Config.ConfigCodeEffectInfos { Offset = 0x4D351, TypeIndex = (int)Config.ConfigCodeEffectInfos.Type.Magic, Description = "MP절약", Editable = true, SubEdit = 0 });
            result.CodeEffects.Add(new Config.ConfigCodeEffectInfos { Offset = 0x1F317, TypeIndex = (int)Config.ConfigCodeEffectInfos.Type.Magic, Description = "날씨무시책략", Editable = true, SubEdit = 0 });
            result.CodeEffects.Add(new Config.ConfigCodeEffectInfos { Offset = 0x1CD33, TypeIndex = (int)Config.ConfigCodeEffectInfos.Type.Magic, Description = "지형무시책략", Editable = true, SubEdit = 0 });
            result.CodeEffects.Add(new Config.ConfigCodeEffectInfos { Offset = 0xA152C, TypeIndex = (int)Config.ConfigCodeEffectInfos.Type.Magic, Description = "책략모방", Editable = true, SubEdit = 0 });
            result.CodeEffects.Add(new Config.ConfigCodeEffectInfos { Offset = 0x3ABD1, TypeIndex = (int)Config.ConfigCodeEffectInfos.Type.Magic, Description = "책략백발백중", Editable = true, SubEdit = 0 });
            result.CodeEffects.Add(new Config.ConfigCodeEffectInfos { Offset = 0x3ADA7, TypeIndex = (int)Config.ConfigCodeEffectInfos.Type.Magic, Description = "책략명중보조", Editable = true, SubEdit = 0 });
            result.CodeEffects.Add(new Config.ConfigCodeEffectInfos { Offset = 0x3ACB4, TypeIndex = (int)Config.ConfigCodeEffectInfos.Type.Magic, Description = "책략방어보조", Editable = true, SubEdit = 0 });
            result.CodeEffects.Add(new Config.ConfigCodeEffectInfos { Offset = 0x3D5B0, TypeIndex = (int)Config.ConfigCodeEffectInfos.Type.Magic, Description = "책략사용", Editable = false, SubEdit = 0 });
            result.CodeEffects.Add(new Config.ConfigCodeEffectInfos { Offset = 0x384BF, TypeIndex = (int)Config.ConfigCodeEffectInfos.Type.Magic, Description = "연속책략", Editable = true, SubEdit = 0 });
            result.CodeEffects.Add(new Config.ConfigCodeEffectInfos { Offset = 0x1F388, TypeIndex = (int)Config.ConfigCodeEffectInfos.Type.Magic, Description = "사신소환", Editable = false, SubEdit = 0 });
            result.CodeEffects.Add(new Config.ConfigCodeEffectInfos { Offset = 0xC30F, TypeIndex = (int)Config.ConfigCodeEffectInfos.Type.Magic, Description = "책략범위고정", Editable = true, SubEdit = 0 });
            result.CodeEffects.Add(new Config.ConfigCodeEffectInfos { Offset = 0xC388, TypeIndex = (int)Config.ConfigCodeEffectInfos.Type.Magic, Description = "회복책략보조", Editable = true, SubEdit = 0 });

            result.CodeEffects.Add(new Config.ConfigCodeEffectInfos { Offset = 0x3721F, TypeIndex = (int)Config.ConfigCodeEffectInfos.Type.StateEffectAttack, Description = "부동공격", Editable = true, SubEdit = 0 });
            result.CodeEffects.Add(new Config.ConfigCodeEffectInfos { Offset = 0x37220, TypeIndex = (int)Config.ConfigCodeEffectInfos.Type.StateEffectAttack, Description = "금책공격", Editable = true, SubEdit = 0 });
            result.CodeEffects.Add(new Config.ConfigCodeEffectInfos { Offset = 0x37221, TypeIndex = (int)Config.ConfigCodeEffectInfos.Type.StateEffectAttack, Description = "혼란공격", Editable = true, SubEdit = 0 });
            result.CodeEffects.Add(new Config.ConfigCodeEffectInfos { Offset = 0x37222, TypeIndex = (int)Config.ConfigCodeEffectInfos.Type.StateEffectAttack, Description = "중독공격", Editable = true, SubEdit = 0 });
            result.CodeEffects.Add(new Config.ConfigCodeEffectInfos { Offset = 0x4E6A, TypeIndex = (int)Config.ConfigCodeEffectInfos.Type.StateEffectAttack, Description = "상태이상공격", Editable = true, SubEdit = 1 });

            result.CodeEffects.Add(new Config.ConfigCodeEffectInfos { Offset = 0x3C25A, TypeIndex = (int)Config.ConfigCodeEffectInfos.Type.TurnCure, Description = "매턴 HP 회복", Editable = true, SubEdit = 0 });
            result.CodeEffects.Add(new Config.ConfigCodeEffectInfos { Offset = 0x3C297, TypeIndex = (int)Config.ConfigCodeEffectInfos.Type.TurnCure, Description = "매턴 MP 회복", Editable = true, SubEdit = 0 });
            result.CodeEffects.Add(new Config.ConfigCodeEffectInfos { Offset = 0x3BB46, TypeIndex = (int)Config.ConfigCodeEffectInfos.Type.TurnCure, Description = "매턴 상태 회복", Editable = true, SubEdit = 0 });
            result.CodeEffects.Add(new Config.ConfigCodeEffectInfos { Offset = 0x3C2E3, TypeIndex = (int)Config.ConfigCodeEffectInfos.Type.TurnCure, Description = "매턴 Exp 획득", Editable = true, SubEdit = 0 });
            result.CodeEffects.Add(new Config.ConfigCodeEffectInfos { Offset = 0x3C30E, TypeIndex = (int)Config.ConfigCodeEffectInfos.Type.TurnCure, Description = "매턴 무기 Exp 획득", Editable = true, SubEdit = 0 });
            result.CodeEffects.Add(new Config.ConfigCodeEffectInfos { Offset = 0x3C339, TypeIndex = (int)Config.ConfigCodeEffectInfos.Type.TurnCure, Description = "매턴 방어 Exp 획득", Editable = true, SubEdit = 0 });
            result.CodeEffects.Add(new Config.ConfigCodeEffectInfos { Offset = 0x3C42D, TypeIndex = (int)Config.ConfigCodeEffectInfos.Type.TurnCure, Description = "자동상승", Editable = false, SubEdit = 0 });

            result.CodeEffects.Add(new Config.ConfigCodeEffectInfos { Offset = 0x37219, TypeIndex = (int)Config.ConfigCodeEffectInfos.Type.DeburfAttack, Description = "공격저하", Editable = true, SubEdit = 0 });
            result.CodeEffects.Add(new Config.ConfigCodeEffectInfos { Offset = 0x3721A, TypeIndex = (int)Config.ConfigCodeEffectInfos.Type.DeburfAttack, Description = "방어저하", Editable = true, SubEdit = 0 });
            result.CodeEffects.Add(new Config.ConfigCodeEffectInfos { Offset = 0x3721B, TypeIndex = (int)Config.ConfigCodeEffectInfos.Type.DeburfAttack, Description = "정신저하", Editable = true, SubEdit = 0 });
            result.CodeEffects.Add(new Config.ConfigCodeEffectInfos { Offset = 0x3721C, TypeIndex = (int)Config.ConfigCodeEffectInfos.Type.DeburfAttack, Description = "순발저하", Editable = true, SubEdit = 0 });
            result.CodeEffects.Add(new Config.ConfigCodeEffectInfos { Offset = 0x3721D, TypeIndex = (int)Config.ConfigCodeEffectInfos.Type.DeburfAttack, Description = "사기저하", Editable = true, SubEdit = 0 });
            result.CodeEffects.Add(new Config.ConfigCodeEffectInfos { Offset = 0x3721E, TypeIndex = (int)Config.ConfigCodeEffectInfos.Type.DeburfAttack, Description = "이동저하", Editable = true, SubEdit = 0 });
            result.CodeEffects.Add(new Config.ConfigCodeEffectInfos { Offset = 0x72164, TypeIndex = (int)Config.ConfigCodeEffectInfos.Type.DeburfAttack, Description = "속성이상공격", Editable = true, SubEdit = 0 });
            result.CodeEffects.Add(new Config.ConfigCodeEffectInfos { Offset = 0xC194, TypeIndex = (int)Config.ConfigCodeEffectInfos.Type.DeburfAttack, Description = "선제공격저하", Editable = true, SubEdit = 0 });
            result.CodeEffects.Add(new Config.ConfigCodeEffectInfos { Offset = 0xC1D8, TypeIndex = (int)Config.ConfigCodeEffectInfos.Type.DeburfAttack, Description = "선제정신저하", Editable = true, SubEdit = 0 });

            result.CodeEffects.Add(new Config.ConfigCodeEffectInfos { Offset = 0x3B1ED, TypeIndex = (int)Config.ConfigCodeEffectInfos.Type.DecreaseDmg, Description = "간접피해감소", Editable = true, SubEdit = 0 });
            result.CodeEffects.Add(new Config.ConfigCodeEffectInfos { Offset = 0x3B259, TypeIndex = (int)Config.ConfigCodeEffectInfos.Type.DecreaseDmg, Description = "물리피해감소", Editable = true, SubEdit = 0 });
            result.CodeEffects.Add(new Config.ConfigCodeEffectInfos { Offset = 0x3B679, TypeIndex = (int)Config.ConfigCodeEffectInfos.Type.DecreaseDmg, Description = "책략피해감소", Editable = true, SubEdit = 0 });
            result.CodeEffects.Add(new Config.ConfigCodeEffectInfos { Offset = 0xC4F1, TypeIndex = (int)Config.ConfigCodeEffectInfos.Type.DecreaseDmg, Description = "물리피해고정", Editable = true, SubEdit = 0 });

            result.CodeEffects.Add(new Config.ConfigCodeEffectInfos { Offset = 0x51D7, TypeIndex = (int)Config.ConfigCodeEffectInfos.Type.Defence, Description = "치명일격방어", Editable = true, SubEdit = 0 });
            result.CodeEffects.Add(new Config.ConfigCodeEffectInfos { Offset = 0x5335, TypeIndex = (int)Config.ConfigCodeEffectInfos.Type.Defence, Description = "이차공격방어", Editable = true, SubEdit = 0 });
            result.CodeEffects.Add(new Config.ConfigCodeEffectInfos { Offset = 0x3ECD1, TypeIndex = (int)Config.ConfigCodeEffectInfos.Type.Defence, Description = "간접공격방어", Editable = true, SubEdit = 0 });
            result.CodeEffects.Add(new Config.ConfigCodeEffectInfos { Offset = 0x7205B, TypeIndex = (int)Config.ConfigCodeEffectInfos.Type.Defence, Description = "상태이상반사", Editable = true, SubEdit = 0 });
            result.CodeEffects.Add(new Config.ConfigCodeEffectInfos { Offset = 0xA151A, TypeIndex = (int)Config.ConfigCodeEffectInfos.Type.Defence, Description = "MP방어", Editable = true, SubEdit = 2 });
            result.CodeEffects.Add(new Config.ConfigCodeEffectInfos { Offset = 0xA13AD, TypeIndex = (int)Config.ConfigCodeEffectInfos.Type.Defence, Description = "금전방어", Editable = true, SubEdit = 1 });
            result.CodeEffects.Add(new Config.ConfigCodeEffectInfos { Offset = 0xC3D5, TypeIndex = (int)Config.ConfigCodeEffectInfos.Type.Defence, Description = "책략반사", Editable = true, SubEdit = 0 });

            result.CodeEffects.Add(new Config.ConfigCodeEffectInfos { Offset = 0x3EC67, TypeIndex = (int)Config.ConfigCodeEffectInfos.Type.TerrainAssist, Description = "지형효과보조", Editable = true, SubEdit = 0 });
            result.CodeEffects.Add(new Config.ConfigCodeEffectInfos { Offset = 0xA0AD2, TypeIndex = (int)Config.ConfigCodeEffectInfos.Type.TerrainAssist, Description = "수전보조", Editable = true, SubEdit = 0 });
            result.CodeEffects.Add(new Config.ConfigCodeEffectInfos { Offset = 0x371A0, TypeIndex = (int)Config.ConfigCodeEffectInfos.Type.TerrainAssist, Description = "돌격이동", Editable = true, SubEdit = 0 });
            result.CodeEffects.Add(new Config.ConfigCodeEffectInfos { Offset = 0x3EC7C, TypeIndex = (int)Config.ConfigCodeEffectInfos.Type.TerrainAssist, Description = "험로이동", Editable = true, SubEdit = 0 });
            result.CodeEffects.Add(new Config.ConfigCodeEffectInfos { Offset = 0x2E80, TypeIndex = (int)Config.ConfigCodeEffectInfos.Type.TerrainAssist, Description = "비상이동", Editable = true, SubEdit = 0 });

            result.CodeEffects.Add(new Config.ConfigCodeEffectInfos { Offset = 0xA1491, TypeIndex = (int)Config.ConfigCodeEffectInfos.Type.Etc, Description = "연속행동", Editable = true, SubEdit = 0 });
            result.CodeEffects.Add(new Config.ConfigCodeEffectInfos { Offset = 0x103E9, TypeIndex = (int)Config.ConfigCodeEffectInfos.Type.Etc, Description = "SP보조", Editable = true, SubEdit = 0 });
            result.CodeEffects.Add(new Config.ConfigCodeEffectInfos { Offset = 0x222E8, TypeIndex = (int)Config.ConfigCodeEffectInfos.Type.Etc, Description = "자동사용", Editable = false, SubEdit = 0 });
            result.CodeEffects.Add(new Config.ConfigCodeEffectInfos { Offset = 0x40275, TypeIndex = (int)Config.ConfigCodeEffectInfos.Type.Etc, Description = "물리반사", Editable = true, SubEdit = 0 });
            result.CodeEffects.Add(new Config.ConfigCodeEffectInfos { Offset = 0x29FAB, TypeIndex = (int)Config.ConfigCodeEffectInfos.Type.Etc, Description = "공훈추가", Editable = true, SubEdit = 0 });
            result.CodeEffects.Add(new Config.ConfigCodeEffectInfos { Offset = 0x78277, TypeIndex = (int)Config.ConfigCodeEffectInfos.Type.Etc, Description = "은신방어", Editable = true, SubEdit = 0 });
            result.CodeEffects.Add(new Config.ConfigCodeEffectInfos { Offset = 0x4EDD1, TypeIndex = (int)Config.ConfigCodeEffectInfos.Type.Etc, Description = "공격유도", Editable = true, SubEdit = 0 });
            result.CodeEffects.Add(new Config.ConfigCodeEffectInfos { Offset = 0xC32F, TypeIndex = (int)Config.ConfigCodeEffectInfos.Type.Etc, Description = "도구범위고정", Editable = true, SubEdit = 0 });
        }

        private void CreateCodes()
        {
            result.Codes.Add("Even", new Config.ConfigExeCodeInfo[]
            {
                new Config.ConfigExeCodeInfo { offset = 0x665, CodeArr = "37 73 1E 3C 28 73 04 B0 64 EB 08 2C 27 6B C0 28 83 C0 64" },
                new Config.ConfigExeCodeInfo { offset = 0x6539, CodeArr = "D1 E0" },
                new Config.ConfigExeCodeInfo { offset = 0x1C4BB, CodeArr = "D1 F8" },
                new Config.ConfigExeCodeInfo { offset = 0x1C5FB, CodeArr = "37 6A 00 EB 05 6A 32" },
                new Config.ConfigExeCodeInfo { offset = 0x2A097, CodeArr = "37 73 31 8B 55 08 D1 E6 03 D6 3C 28 73 06 66 B8 64 00 EB 08 2C 27 6B C0 28 83 C0 64" },
                new Config.ConfigExeCodeInfo { offset = 0x3B905, CodeArr = "32 76 10 83 EA 32 6B D2 02" },
                new Config.ConfigExeCodeInfo { offset = 0x3BB60, CodeArr = "90 90 EB 2A 6A 00 8B 4D FC E8 72 17 FE FF 0F B6 C0 83 F8 32 7E 04 B0 0A EB 14 6A 00 8B 4D FC E8 5C 17 FE FF 90 90" },
                new Config.ConfigExeCodeInfo { offset = 0x3C048, CodeArr = "2D 72 04 B0 05 EB 0A 3C 28" },
                new Config.ConfigExeCodeInfo { offset = 0x4C030, CodeArr = "19 88 51 02 EB 09 0F B6 51 03 89 55 F8 D1 E2" },
                new Config.ConfigExeCodeInfo { offset = 0x598AD, CodeArr = "D1 E2" },
                new Config.ConfigExeCodeInfo { offset = 0x59949, CodeArr = "2D 74 01 42 52 FF 75 FC FF 15 E8 62 48 00 8B 4D 0C 8B 45 F4 33 D2 80 7C 08 21 23" },
                new Config.ConfigExeCodeInfo { offset = 0x614D2, CodeArr = "37 73 E6 3C 28 73 0E 83 FE 64 72 22 83 EE 64 FE 44 11 21 EB E5 2C 27 6B C0 28 83 C0 64" },
                new Config.ConfigExeCodeInfo { offset = 0xD2613, CodeArr = "23" },
            });

            result.Codes.Add("Odd", new Config.ConfigExeCodeInfo[]
            {
                new Config.ConfigExeCodeInfo { offset = 0x665, CodeArr = "6E 73 1E 3C 50 73 04 B0 32 EB 08 2C 4F 6B C0 0A 83 C0 37" },
                new Config.ConfigExeCodeInfo { offset = 0x6539, CodeArr = "90 90" },
                new Config.ConfigExeCodeInfo { offset = 0x1C4BB, CodeArr = "90 90" },
                new Config.ConfigExeCodeInfo { offset = 0x1C5FB, CodeArr = "6E 6A 00 EB 05 6A 64" },
                new Config.ConfigExeCodeInfo { offset = 0x2A097, CodeArr = "6E 73 31 8B 55 08 D1 E6 03 D6 3C 50 73 06 66 B8 32 00 EB 08 2C 4F 6B C0 0A 83 C0 37" },
                new Config.ConfigExeCodeInfo { offset = 0x3B905, CodeArr = "64 76 10 83 EA 64 6B D2 01" },
                new Config.ConfigExeCodeInfo { offset = 0x3BB60, CodeArr = "D1 E8 EB 2A 6A 00 8B 4D FC E8 72 17 FE FF 0F B6 C0 83 F8 64 7E 04 B0 0A EB 14 6A 00 8B 4D FC E8 5C 17 FE FF D1 E8" },
                new Config.ConfigExeCodeInfo { offset = 0x3C048, CodeArr = "5A 72 04 B0 05 EB 0A 3C 50" },
                new Config.ConfigExeCodeInfo { offset = 0x4C030, CodeArr = "32 88 51 02 EB 09 0F B6 51 03 89 55 F8 90 90" },
                new Config.ConfigExeCodeInfo { offset = 0x598AD, CodeArr = "90 90" },
                new Config.ConfigExeCodeInfo { offset = 0x59949, CodeArr = "5A 74 01 42 52 FF 75 FC FF 15 E8 62 48 00 8B 4D 0C 8B 45 F4 33 D2 80 7C 08 21 46" },
                new Config.ConfigExeCodeInfo { offset = 0x614D2, CodeArr = "6E 73 E6 3C 50 73 0E 83 FE 32 72 22 83 EE 32 FE 44 11 21 EB E5 2C 4F 6B C0 0A 83 C0 37" },
                new Config.ConfigExeCodeInfo { offset = 0xD2613, CodeArr = "46" },
            });
            

        }
    }
}
