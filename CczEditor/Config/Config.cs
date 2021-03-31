using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using System.IO;

namespace CczEditor
{
    [Serializable]
    public partial class Config
    {
        public string FileName => $"CczEditor-{VersionName}.json";

        public string VersionName;

        public string DisplayName;

        public string DirectoryPath;

        public string ExeFileName;

        public ConfigCodeOptions CodeOptionContainer = new ConfigCodeOptions();

        public ConfigDataInfos Data = new ConfigDataInfos();

        public ConfigImsgDataInfos Imsg = new ConfigImsgDataInfos();

        public ConfigItemInfos Items = new ConfigItemInfos();

        public ConfigExeInfos Exe = new ConfigExeInfos();

        public List<ConfigItemEffectNameInfos> ItemEffects = new List<ConfigItemEffectNameInfos>();

        public List<ConfigCodeEffectInfos> CodeEffects = new List<ConfigCodeEffectInfos>();

        public List<ConfigForceNameInfos> ForceNames = new List<ConfigForceNameInfos>();

        public List<ConfigForceCategoryNameInfos> ForceCategoryNames = new List<ConfigForceCategoryNameInfos>();

        public List<string> HitAreaNames = new List<string>();

        public List<string> EffAreaNames = new List<string>();


        public static Config Read(string fileName)
        {
            var json = File.ReadAllText(fileName);
            var result = JsonConvert.DeserializeObject<Config>(json);
            return result;
        }

        public static void Write(Config target, string fileName)
        {
            var json = JsonConvert.SerializeObject(target, Formatting.Indented);
            File.WriteAllText(fileName, json);
        }
        
    }



    public partial class Config
    {
        [Serializable]
        public class ConfigCodeOptions
        {
            public bool ItemCustomRange;

            public bool MpExtension;

            public bool AIExtension;

            public bool MagicLearnExtension;

            public bool SingularAttribute;

            public bool MagicReflect;
        }

        [Serializable]
        public class ConfigDataInfos
        {
            public int UnitCount;
            public int UnitOffset;
            public int UnitLength;

            public int ItemCount;
            public int ItemOffset;
            public int ItemLength;

            public int ShopCount;
            public int ShopOffset;
            public int ShopLength;

            public int ForceCount;
            public int ForceOffset;
            public int ForceLength;

            public int MagicCount;
            public int MagicOffset;
            public int MagicLength;

            public int TerrainOffset;

            public int StarItemCount;
            public int StarItemOffset;
        }

        [Serializable]
        public class ConfigImsgDataInfos
        {
            public int ItemOffset;
            public int MagicOffset;

            public int StageCount;
            public int StageOffset;

            public int ForceOffset;

            public int UnitOriginalOffset;
            public int UnitExtensionOffset;

            public int RetreatOffset;
            public int CriticalCount;
            public int CriticalOffset;
            public int StaffOffset;
        }
        
        [Serializable]
        public class ConfigItemInfos
        {
            public int WeaponIndexMin;
            public int WeaponIndexMax;
            public int ArmorIndexMin;
            public int ArmorIndexMax;
            public int AuxiliaryIndexMin;
            public int AuxiliaryIndexMax;
            public int ConsumablesMin;
            public int ConsumablesMax;
            public int MineInstall;
            public int MineControl;
            public int Mine;
            public int Bomb;
        }

        [Serializable]
        public class ConfigExeInfos
        {
            public int BattleObjTripleTypeCount;
            public int UnitCharacterOffset;
            public int UnitVoiceOffset;
            public int UnitCutinOffset;
            public int UnitCostOffset;
            public int UnitBattleObjOffset;
            public int UnitPmapObjOffset;
            public int CriticalOffset;
            public int CriticalCount;

            public ConfigExeForceInfos Force = new ConfigExeForceInfos();
            public ConfigExeMagicInfos Magic = new ConfigExeMagicInfos();
        }

        [Serializable]
        public class ConfigExeForceInfos
        {
            public int AtkEffectOffset;
            public int MoveSoundOffset;
            public int MoveSpeedOffset;
            public int AtkSoundOffset;
            public int AtkTypeOffset;
            public int TypeOffset;
            public int MagicDamageOffset;
            public int AtkDelayOffset;
            public int AtkPincOffset;
            public int SynastryOffset;
            public int AiTypeOffset;
        }

        [Serializable]
        public class ConfigExeMagicInfos
        {
            public int MeffStartIndex;
            public int MeffEndIndex;
            public int MeffOffset;

            public int McallStartIndex;
            public int McallEndIndex;
            public int McallOffset;

            public int MagicTypeStartIndex;
            public int MagicTypeEndIndex;
            public int MagicTypeOffset;

            public int DamageTypeStartIndex;
            public int DamageTypeEndIndex;
            public int DamageTypeOffset;

            public int HealTypeStartIndex;
            public int HealTypeEndIndex;
            public int HealTypeOffset;

            public int AiTypeStartIndex;
            public int AiTypeEndIndex;
            public int AiTypeOffset;

            public int UseConditionStartIndex;
            public int UseConditionEndIndex;
            public int UseConditionOffset;

            public int DamageValueStartIndex;
            public int DamageValueEndIndex;
            public int DamageValueOffset;

            public int AccRateStartIndex;
            public int AccRateEndIndex;
            public int AccRateOffset;

            public int LearTypeStartIndex;
            public int LearTypeEndIndex;
            public int LearTypeOffset;

            public int ReflectTypeStartIndex;
            public int ReflectTypeEndIndex;
            public int ReflectTypeOffset;
        }

        [Serializable]
        public class ConfigItemEffectNameInfos
        {
            public int Index;
            public int Offset;
            public byte Length;
        }

        [Serializable]
        public class ConfigCodeEffectInfos
        {
            public int Index;
            public int Offset;
            public byte Length;
        }

        [Serializable]
        public class ConfigForceNameInfos
        {
            public int Index;
            public int Offset;
            public byte Length;
        }

        [Serializable]
        public class ConfigForceCategoryNameInfos
        {
            public int Index;
            public int Offset;
            public byte Length;
        }
    }
}
