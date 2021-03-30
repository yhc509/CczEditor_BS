using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using System.IO;

namespace CczEditor.Config.New
{
    [Serializable]
    public class SystemConfig
    {
        private SystemConfig() { }
        public static SystemConfig Inst { get; private set; }

        public string CurrentConfig;

        public static string DefaultSystemConfigFileName = "CczEditor.json";
        public static readonly string DefaultConfigName = "CczEditor-BS 1.0.json";

        public static SystemConfig Read(string fileName)
        {
            if (File.Exists(fileName))
            {
                var json = File.ReadAllText(fileName);
                Inst = JsonConvert.DeserializeObject<SystemConfig>(json);
            }
            else
            {
                Inst = CreateDefaultSystemConfig();
                Write(DefaultSystemConfigFileName);
            }
            return Inst;
        }

        public static void Write(string fileName)
        {
            if(Inst == null)
                Inst = CreateDefaultSystemConfig();
            var json = JsonConvert.SerializeObject(Inst, Formatting.Indented);
            File.WriteAllText(fileName, json);
        }

        private static SystemConfig CreateDefaultSystemConfig()
        {
            var result = new SystemConfig();
            Config defaultConfig;
            if (File.Exists(DefaultConfigName))
                defaultConfig = Config.Read(DefaultConfigName);
            else
                defaultConfig = CreateDefaultConfig();

            Config.Write(defaultConfig, DefaultConfigName);

            result.CurrentConfig = DefaultConfigName;
            return result;
        }

        public static Config CreateDefaultConfig()
        {
            Config result = new Config();

            result.VersionName = "BS 1.0";
            result.DisplayName = "비상조조전 1.0";
            result.DirectoryPath = string.Empty;
            result.ExeFileName = "Ekd5.exe";

            #region CodeOption Setting
            result.CodeOptionContainer.ItemCustomRange = true;
            result.CodeOptionContainer.MpExtension = false;
            result.CodeOptionContainer.AIExtension = true;
            result.CodeOptionContainer.MagicLearnExtension = true;
            result.CodeOptionContainer.SingularAttribute = false;
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

            result.ItemEffects.Add(new Config.ConfigItemEffectNameInfos { Index = 26, Length = 10, Offset = 0x8A9E8 });
            result.ItemEffects.Add(new Config.ConfigItemEffectNameInfos { Index = 27, Length = 10, Offset = 0x8A9F5 });
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

            #region CodeEffName Setting
            //result.CodeEffects.Add(new Config.ConfigCodeEffectInfos { Index = 0, Offset = 0, Length = 0x10 });
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

            #region ForceCategoryName Setting
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
            #endregion

            #region HitAreaName Setting
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
            #endregion

            #region EffAreaName Setting
            result.EffAreaNames.Add("무");
            result.EffAreaNames.Add("십자");
            result.EffAreaNames.Add("구궁");
            result.EffAreaNames.Add("몰우전");
            result.EffAreaNames.Add("이격");
            result.EffAreaNames.Add("육격");
            result.EffAreaNames.Add("대몰우전");
            result.EffAreaNames.Add("삼격");
            result.EffAreaNames.Add("방괴");
            #endregion

            return result;
        }
        
    }
}
