using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CczEditor
{
    public class ConfigUtils
    {
        public static Dictionary<int, string> GetWeaponsTypes(Data.ExeData targetData, Config config, string format = null)
        {
            var min = config.Items.WeaponIndexMin;
            var max = config.Items.WeaponIndexMax;
            var effects = config.ItemEffects;

            var result = new Dictionary<int, string>();
            for (var i = min; i <= max; i++)
            {
                var effect = effects.Find(x => x.Index == i);
                if (effect == null) continue;

                var effName = targetData.GetText(effect.Offset, effect.Length);

                if (string.IsNullOrEmpty(format))
                    result.Add(effect.Index, effName);
                else
                    result.Add(effect.Index, string.Format(format, i, effName));
            }
            return result;
        }

        public static Dictionary<int, string> GetArmorTypes(Data.ExeData targetData, Config config, string format = null)
        {
            var min = config.Items.ArmorIndexMin;
            var max = config.Items.ArmorIndexMax;
            var effects = config.ItemEffects;

            var result = new Dictionary<int, string>();
            for (var i = min; i <= max; i++)
            {
                var effect = effects.Find(x => x.Index == i);
                if (effect == null) continue;

                var effName = targetData.GetText(effect.Offset, effect.Length);

                if (string.IsNullOrEmpty(format))
                    result.Add(effect.Index, effName);
                else
                    result.Add(effect.Index, string.Format(format, i, effName));
            }
            return result;
        }

        public static Dictionary<int, string> GetEquipmentTypes(Data.ExeData targetData, Config config, string format = null)
        {
            var min = config.Items.WeaponIndexMin;
            var max = config.Items.ArmorIndexMax;
            var effects = config.ItemEffects;

            var result = new Dictionary<int, string>();
            for (var i = min; i <= max; i++)
            {
                var effect = effects.Find(x => x.Index == i);
                if (effect == null) continue;

                string prefixType;
                string itemTypeName;
                if (i % 2 == 0)
                    prefixType = "보통";
                else
                    prefixType = "특수";

                itemTypeName = $"{prefixType}{targetData.GetText(effect.Offset, effect.Length)}";

                if (string.IsNullOrEmpty(format))
                    result.Add(effect.Index, itemTypeName);
                else
                    result.Add(effect.Index, string.Format(format, i, itemTypeName));
            }
            return result;
        }

        public static Dictionary<int, string> GetAuxiliaryEffects(Data.ExeData targetData, Config config, string format = null)
        {
            var auxiliaryMin = config.Items.AuxiliaryIndexMin;
            var auxiliaryMax = config.Items.AuxiliaryIndexMax;
            var consumablesMin = config.Items.ConsumablesMin;
            var consumablesMax = config.Items.Bomb;
            var effects = config.ItemEffects;

            var result = new Dictionary<int, string>();
            for (var i = auxiliaryMin; i <= auxiliaryMax; i++)
            {
                var effect = effects.Find(x => x.Index == i);
                if (effect == null) continue;

                if ((consumablesMin > auxiliaryMax ||
                    (consumablesMin >= auxiliaryMin && consumablesMin <= auxiliaryMax) ||
                    (consumablesMax >= auxiliaryMin && consumablesMax <= auxiliaryMax))
                    && (i < consumablesMin || i > consumablesMax)
                    && effects.Exists(x => x.Index == i))  {

                    var effName = targetData.GetText(effect.Offset, effect.Length);

                    if (string.IsNullOrEmpty(format))
                        result.Add(effect.Index, effName);
                    else
                        result.Add(effect.Index, string.Format(format, i, effName));
                }
            }
            return result;
        }

        public static string GetAuxiliaryEffect(Data.ExeData targetData, Config config, int index, string format = null)
        {
            var auxiliaryMin = config.Items.AuxiliaryIndexMin;
            var auxiliaryMax = config.Items.AuxiliaryIndexMax;
            var consumablesMin = config.Items.ConsumablesMin;
            var consumablesMax = config.Items.Bomb;
            var effects = config.ItemEffects;
            var effect = effects.Find(x => x.Index == index);
            if (effect == null) return null;

            var effName = targetData.GetText(effect.Offset, effect.Length);
            return effName;
        }

        public static Dictionary<int, string> GetConsumablesEffects(Data.ExeData targetData, Config config, string format = null)
        {
            var consumablesMin = config.Items.ConsumablesMin;
            var consumablesMax = config.Items.ConsumablesMax;
            var effects = config.ItemEffects;
            var result = new Dictionary<int, string>();

            for (var i = consumablesMin; i <= consumablesMax; i++)
            {
                var effect = effects.Find(x => x.Index == i);
                if (effect == null) continue;
                
                var effName = targetData.GetText(effect.Offset, effect.Length);

                if (string.IsNullOrEmpty(format))
                    result.Add(effect.Index, effName);
                else
                    result.Add(effect.Index, string.Format(format, i, effName));
            }
            return result;
        }

        public static Dictionary<int, string> GetBombsEffects(Data.ExeData targetData, Config config, string format = null)
        {
            var min = config.Items.MineInstall;
            var max = config.Items.MineControl;
            var effects = config.ItemEffects;
            var result = new Dictionary<int, string>();
            for (var i = min; i <= max; i++)
            {
                var effect = effects.Find(x => x.Index == i);
                if (effect == null) continue;

                var effName = targetData.GetText(effect.Offset, effect.Length);

                if (string.IsNullOrEmpty(format))
                    result.Add(effect.Index, effName);
                else
                    result.Add(effect.Index, string.Format(format, i, effName));
            }
            return result;
        }

        public static Dictionary<int, string> GetBombsEffects2(Data.ExeData targetData, Config config, string format = null)
        {
            var _Bombs = config.Items.Mine;
            var effects = config.ItemEffects;
            var result = new Dictionary<int, string>();
            var i = _Bombs;

            if (effects.Exists(x => x.Index == i))
            {
                var effect = effects.Find(x => x.Index == i);
                if (effect == null) return result;

                var effName = targetData.GetText(effect.Offset, effect.Length);

                if (string.IsNullOrEmpty(format))
                    result.Add(effect.Index, effName);
                else
                    result.Add(effect.Index, string.Format(format, i, effName));
            }
            return result;
        }

        public static Dictionary<int, string> GetBombsEffects3(Data.ExeData targetData, Config config, string format = null)
        {
            var _Bombs = config.Items.Bomb;
            var effects = config.ItemEffects;
            var result = new Dictionary<int, string>();
            var i = _Bombs;

            if (effects.Exists(x => x.Index == i))
            {
                var effect = effects.Find(x => x.Index == i);
                if (effect == null) return result;

                var effName = targetData.GetText(effect.Offset, effect.Length);

                if (string.IsNullOrEmpty(format))
                    result.Add(effect.Index, effName);
                else
                    result.Add(effect.Index, string.Format(format, i, effName));
            }
            return result;
        }

        public static Dictionary<int, string> GetForceNames(Data.ExeData targetData, Config config, string format = null)
        {
            var result = new Dictionary<int, string>();
            var forceOffsets = config.ForceNames;

            targetData.Open(System.IO.FileAccess.ReadWrite);
            for (int i = 0; i < forceOffsets.Count; i++)
            {
                var forceName = GetForceName(targetData, config, i, format);
                result.Add(forceOffsets[i].Index, forceName);
            }
            targetData.Close();
            return result;
        }

        public static string GetForceName(Data.ExeData targetData, Config config, int index, string format = null)
        {
            var forceOffsets = config.ForceNames;
            var forceName = targetData.GetText(forceOffsets[index].Offset, forceOffsets[index].Length);

            if (string.IsNullOrEmpty(format))
                return forceName;
            else
                return string.Format(format, index, forceName);
        }

        public static Dictionary<int, string> GetForceCategoryNames(Data.ExeData targetData, Config config, string format = null)
        {
            var result = new Dictionary<int, string>();
            var forceCategoryOffsets = config.ForceCategoryNames;

            targetData.Open(System.IO.FileAccess.ReadWrite);
            for (int i = 0; i < forceCategoryOffsets.Count; i++)
            {
                var forceCategoryName = GetForceCategoryName(targetData, config, i, format);
                result.Add(forceCategoryOffsets[i].Index, forceCategoryName);
            }
            targetData.Close();
            return result;
        }

        public static string GetForceCategoryName(Data.ExeData targetData, Config config, int index, string format = null)
        {
            var forceCategoryOffsets = config.ForceCategoryNames;
            var forceCategoryName = targetData.GetText(forceCategoryOffsets[index].Offset, forceCategoryOffsets[index].Length);

            if (string.IsNullOrEmpty(format))
                return forceCategoryName;
            else
                return string.Format(format, index, forceCategoryName);
        }


        public static Dictionary<int, string> GetSpecialEffectNames(Data.ExeData targetData, Config config, string format = null)
        {
            var result = new Dictionary<int, string>();
            var specialEffectOffsets = config.SpecialEffectNames;

            targetData.Open(System.IO.FileAccess.ReadWrite);
            for (int i = 0; i < specialEffectOffsets.Count; i++)
            {
                var specialEffectName = GetSpecialEffectName(targetData, config, i, format);
                result.Add(specialEffectOffsets[i].Index, specialEffectName);
            }
            targetData.Close();
            return result;
        }


        public static string GetSpecialEffectName(Data.ExeData targetData, Config config, int index, string format = null)
        {
            var specialEffectOffset = config.SpecialEffectNames;
            var specialEffectName = targetData.GetText(specialEffectOffset[index].Offset, specialEffectOffset[index].Length);
            if (string.IsNullOrEmpty(format))
                return specialEffectName;
            else
                return string.Format(format, index, specialEffectName);
        }

        public static string GetSpecialSkillName(Data.ExeData targetData, Config config, int index, string format = null)
        {
            var specialSkillOffset = config.SpecialSkillNames;
            var specialSkillName = targetData.GetText(specialSkillOffset[index].Offset, specialSkillOffset[index].Length);

            if (string.IsNullOrEmpty(format))
                return specialSkillName;
            else
                return string.Format(format, index, specialSkillName);
        }
    }
}
