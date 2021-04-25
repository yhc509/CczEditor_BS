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

        public bool UseE5Directory;
        
        public ConfigCodeOptions CodeOptionContainer = new ConfigCodeOptions();

        public ConfigDataInfos Data = new ConfigDataInfos();

        public ConfigImsgDataInfos Imsg = new ConfigImsgDataInfos();

        public ConfigItemInfos Items = new ConfigItemInfos();

        public ConfigExeInfos Exe = new ConfigExeInfos();
        
        public ConfigSaveInfos Save = new ConfigSaveInfos();

        public List<ConfigItemEffectNameInfos> ItemEffects = new List<ConfigItemEffectNameInfos>();

        public List<ConfigCodeEffectInfos> CodeEffects = new List<ConfigCodeEffectInfos>();

        public List<ConfigForceNameInfos> ForceNames = new List<ConfigForceNameInfos>();

        public List<ConfigForceCategoryNameInfos> ForceCategoryNames = new List<ConfigForceCategoryNameInfos>();

        public List<string> HitAreaNames = new List<string>();

        public List<string> EffAreaNames = new List<string>();
        
        public List<ConfigSpecialEffectNameInfos> SpecialEffectNames = new List<ConfigSpecialEffectNameInfos>();
        
        public List<ConfigSpecialSkillNameInfos> SpecialSkillNames = new List<ConfigSpecialSkillNameInfos>();

        public Dictionary<string, ConfigExeCodeInfo[]> Codes = new Dictionary<string, ConfigExeCodeInfo[]>();

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

            public bool UseLargeFace;

            public bool UseCutin;

            public bool UseVoice;

            public bool UseCost;

            public bool UseMagicCondition;

            public bool UseMeffAfterMcallExtension;
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
            public int TreasureCountOffset;

            public int SpecialSkillOffset;
            public int SpecialSkillPhysicsCount;
            public int SpecialSkillForceOffset;

            public int SpecialEffectOffset;

            public int AbilityAssistPercentOffset;
            public int RangeAttack2TypeOffset;
            public int RangeAttack3TypeOffset;
            public int IgnoreDefenceOffset;
            public int GoldDefenceRateOffset;
            public int MpDefenceRecoverOffest;
            public int StateEffectAccOffset;
            

            public int[] TitleOffsets;
            public ConfigExeAbilityGradeInfos[] AbilityGrades;
            public int[] ClassUpLevel1Offsets;
            public int[] ClassUpLevel2Offsets;
            public int[] MaxUnitLevelOffsets;
            public int[] MaxUnitExpOffsets;
            public int[] NormalEquipExpOffsets;
            public int[] SpecialEquipExpOffsets;
            public int[] NormalEquipMaxLevelOffsets;
            public int[] SpecialEquipMaxLevelOffsets;
            public int[] SecondEquipStartLevelOffsets;
            public int[] NewUnitExploitOffsets;
            public int[] EnemyUnitExploitOffsets;
            public int[] NormalEquipUpLevelOffsets;
            public int[] SpecialEquipUpLevelOffsets;


            public ConfigExeForceInfos Force = new ConfigExeForceInfos();
            public ConfigExeMagicInfos Magic = new ConfigExeMagicInfos();
        }
        

        [Serializable]
        public class ConfigSaveInfos
        {
            public int SpecialSkillOffset;
            public int SpecialEffectOffset;
            public int BattleObjOffset;
            public int PmapObjOffset;
            public int FaceObjOffset;
        }

        [Serializable]
        public class ConfigExeAbilityGradeInfos
        {
            public string Name;
            public int Offset;
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
            public int[] UseMeffIndexes;
            public int MeffOffset;

            public int[] UseMcallIndexes;
            public int McallOffset;

            public int[] UseMagicTypeIndexes;
            public int MagicTypeOffset;

            public int[] UseDamageTypeIndexes;
            public int DamageTypeOffset;

            public int[] UseHealTypeIndexes;
            public int HealTypeOffset;

            public int[] UseAiTypeIndexes;
            public int AiTypeOffset;

            public int[] UseConditionIndexes;
            public int UseConditionOffset;

            public int[] UseDamageValueIndexes;
            public int DamageValueOffset;

            public int[] UseAccRateIndexes;
            public int AccRateOffset;

            public int[] UseLearnTypeIndexes;
            public int LearTypeOffset;

            public int[] UseReflectIndexes;
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
            public enum Type
            {
                AbilityAssist = 0,
                SpecialAttack = 1,
                AttackAcc = 2,
                Magic = 3,
                StateEffectAttack = 4,
                TurnCure = 5,
                DeburfAttack = 6,
                DecreaseDmg = 7,
                Defence = 8,
                TerrainAssist = 9,
                Etc = 10,
            }

            public int Offset;
            public int TypeIndex;
            public string Description;
            public bool Editable;
            public int SubEdit;
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

        [Serializable]
        public class ConfigSpecialEffectNameInfos
        {
            public int Index;
            public int Offset;
            public byte Length;
            public string Description;
        }
        
        [Serializable]
        public class ConfigSpecialSkillNameInfos
        {
            public int Index;
            public int Offset;
            public byte Length;
            public string Description;
        }

        [Serializable]
        public class ConfigExeCodeInfo
        {
            public int offset;
            public string CodeArr;
        }
    }
}
