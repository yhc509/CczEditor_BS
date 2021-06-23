using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CczEditor
{
    public class ConfigUtils
    {
        public static Dictionary<int, string> GetWeaponsTypes(string format = null)
        {
            var min = Program.CurrentConfig.Items.WeaponIndexMin;
            var max = Program.CurrentConfig.Items.WeaponIndexMax;
            var effects = Program.CurrentConfig.ItemEffects;

            var result = new Dictionary<int, string>();
            for (var i = min; i <= max; i++)
            {
                var effect = effects.Find(x => x.Index == i);
                if (effect == null) continue;

                var effName = Program.ExeData.GetText(effect.Offset, effect.Length);

                if (string.IsNullOrEmpty(format))
                    result.Add(effect.Index, effName);
                else
                    result.Add(effect.Index, string.Format(format, i, effName));
            }
            return result;
        }

        public static Dictionary<int, string> GetArmorTypes(string format = null)
        {
            var min = Program.CurrentConfig.Items.ArmorIndexMin;
            var max = Program.CurrentConfig.Items.ArmorIndexMax;
            var effects = Program.CurrentConfig.ItemEffects;

            var result = new Dictionary<int, string>();
            for (var i = min; i <= max; i++)
            {
                var effect = effects.Find(x => x.Index == i);
                if (effect == null) continue;

                var effName = Program.ExeData.GetText(effect.Offset, effect.Length);

                if (string.IsNullOrEmpty(format))
                    result.Add(effect.Index, effName);
                else
                    result.Add(effect.Index, string.Format(format, i, effName));
            }
            return result;
        }

        public static Dictionary<int, string> GetEquipmentTypes(string format = null)
        {
            var min = Program.CurrentConfig.Items.WeaponIndexMin;
            var max = Program.CurrentConfig.Items.ArmorIndexMax;
            var effects = Program.CurrentConfig.ItemEffects;

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

                itemTypeName = $"{prefixType}{Program.ExeData.GetText(effect.Offset, effect.Length)}";

                if (string.IsNullOrEmpty(format))
                    result.Add(effect.Index, itemTypeName);
                else
                    result.Add(effect.Index, string.Format(format, i, itemTypeName));
            }
            return result;
        }

        public static Dictionary<int, string> GetAuxiliaryEffects(string format = null)
        {
            var auxiliaryMin = Program.CurrentConfig.Items.AuxiliaryIndexMin;
            var auxiliaryMax = Program.CurrentConfig.Items.AuxiliaryIndexMax;
            var consumablesMin = Program.CurrentConfig.Items.ConsumablesMin;
            var consumablesMax = Program.CurrentConfig.Items.Bomb;
            var effects = Program.CurrentConfig.ItemEffects;

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

                    var effName = Program.ExeData.GetText(effect.Offset, effect.Length);

                    if (string.IsNullOrEmpty(format))
                        result.Add(effect.Index, effName);
                    else
                        result.Add(effect.Index, string.Format(format, i, effName));
                }
            }
            return result;
        }

        public static string GetAuxiliaryEffect(int index, string format = null)
        {
            var auxiliaryMin = Program.CurrentConfig.Items.AuxiliaryIndexMin;
            var auxiliaryMax = Program.CurrentConfig.Items.AuxiliaryIndexMax;
            var consumablesMin = Program.CurrentConfig.Items.ConsumablesMin;
            var consumablesMax = Program.CurrentConfig.Items.Bomb;
            var effects = Program.CurrentConfig.ItemEffects;
            var effect = effects.Find(x => x.Index == index);
            if (effect == null) return null;

            var effName = Program.ExeData.GetText(effect.Offset, effect.Length);
            return effName;
        }

        public static Dictionary<int, string> GetConsumablesEffects(string format = null)
        {
            var consumablesMin = Program.CurrentConfig.Items.ConsumablesMin;
            var consumablesMax = Program.CurrentConfig.Items.ConsumablesMax;
            var effects = Program.CurrentConfig.ItemEffects;
            var result = new Dictionary<int, string>();

            for (var i = consumablesMin; i <= consumablesMax; i++)
            {
                var effect = effects.Find(x => x.Index == i);
                if (effect == null) continue;
                
                var effName = Program.ExeData.GetText(effect.Offset, effect.Length);

                if (string.IsNullOrEmpty(format))
                    result.Add(effect.Index, effName);
                else
                    result.Add(effect.Index, string.Format(format, i, effName));
            }
            return result;
        }

        public static Dictionary<int, string> GetBombsEffects(string format = null)
        {
            var min = Program.CurrentConfig.Items.MineInstall;
            var max = Program.CurrentConfig.Items.MineControl;
            var effects = Program.CurrentConfig.ItemEffects;
            var result = new Dictionary<int, string>();
            for (var i = min; i <= max; i++)
            {
                var effect = effects.Find(x => x.Index == i);
                if (effect == null) continue;

                var effName = Program.ExeData.GetText(effect.Offset, effect.Length);

                if (string.IsNullOrEmpty(format))
                    result.Add(effect.Index, effName);
                else
                    result.Add(effect.Index, string.Format(format, i, effName));
            }
            return result;
        }

        public static Dictionary<int, string> GetBombsEffects2(string format = null)
        {
            var _Bombs = Program.CurrentConfig.Items.Mine;
            var effects = Program.CurrentConfig.ItemEffects;
            var result = new Dictionary<int, string>();
            var i = _Bombs;

            if (effects.Exists(x => x.Index == i))
            {
                var effect = effects.Find(x => x.Index == i);
                if (effect == null) return result;

                var effName = Program.ExeData.GetText(effect.Offset, effect.Length);

                if (string.IsNullOrEmpty(format))
                    result.Add(effect.Index, effName);
                else
                    result.Add(effect.Index, string.Format(format, i, effName));
            }
            return result;
        }

        public static Dictionary<int, string> GetBombsEffects3(string format = null)
        {
            var _Bombs = Program.CurrentConfig.Items.Bomb;
            var effects = Program.CurrentConfig.ItemEffects;
            var result = new Dictionary<int, string>();
            var i = _Bombs;

            if (effects.Exists(x => x.Index == i))
            {
                var effect = effects.Find(x => x.Index == i);
                if (effect == null) return result;

                var effName = Program.ExeData.GetText(effect.Offset, effect.Length);

                if (string.IsNullOrEmpty(format))
                    result.Add(effect.Index, effName);
                else
                    result.Add(effect.Index, string.Format(format, i, effName));
            }
            return result;
        }

        public static Dictionary<int, string> GetForceNames(string format = null)
        {
            var result = new Dictionary<int, string>();
            var forceOffsets = Program.CurrentConfig.ForceNames;

            Program.ExeData.Open(System.IO.FileAccess.ReadWrite);
            for (int i = 0; i < forceOffsets.Count; i++)
            {
                var forceName = GetForceName(i, format);
                result.Add(forceOffsets[i].Index, forceName);
            }
            Program.ExeData.Close();
            return result;
        }

        public static string GetForceName(int index, string format = null)
        {
            var forceOffsets = Program.CurrentConfig.ForceNames;
            var forceName = Program.ExeData.GetText(forceOffsets[index].Offset, forceOffsets[index].Length);

            if (string.IsNullOrEmpty(format))
                return forceName;
            else
                return string.Format(format, index, forceName);
        }

        public static Dictionary<int, string> GetForceCategoryNames(string format = null)
        {
            var result = new Dictionary<int, string>();
            var forceCategoryOffsets = Program.CurrentConfig.ForceCategoryNames;

            Program.ExeData.Open(System.IO.FileAccess.ReadWrite);
            for (int i = 0; i < forceCategoryOffsets.Count; i++)
            {
                var forceCategoryName = GetForceCategoryName(i, format);
                result.Add(forceCategoryOffsets[i].Index, forceCategoryName);
            }
            Program.ExeData.Close();
            return result;
        }

        public static string GetForceCategoryName(int index, string format = null)
        {
            var forceCategoryOffsets = Program.CurrentConfig.ForceCategoryNames;
            var forceCategoryName = Program.ExeData.GetText(forceCategoryOffsets[index].Offset, forceCategoryOffsets[index].Length);

            if (string.IsNullOrEmpty(format))
                return forceCategoryName;
            else
                return string.Format(format, index, forceCategoryName);
        }


        public static Dictionary<int, string> GetSpecialEffectNames(string format = null)
        {
            var result = new Dictionary<int, string>();
            var specialEffectOffsets = Program.CurrentConfig.SpecialEffectNames;

            Program.ExeData.Open(System.IO.FileAccess.ReadWrite);
            for (int i = 0; i < specialEffectOffsets.Count; i++)
            {
                var specialEffectName = GetSpecialEffectName(i, format);
                result.Add(specialEffectOffsets[i].Index, specialEffectName);
            }
            Program.ExeData.Close();
            return result;
        }


        public static string GetSpecialEffectName(int index, string format = null)
        {
            var specialEffectOffset = Program.CurrentConfig.SpecialEffectNames;
            var specialEffectName = Program.ExeData.GetText(specialEffectOffset[index].Offset, specialEffectOffset[index].Length);
            if (string.IsNullOrEmpty(format))
                return specialEffectName;
            else
                return string.Format(format, index, specialEffectName);
        }

        public static string GetSpecialSkillName(int index, string format = null)
        {
            var specialSkillOffset = Program.CurrentConfig.SpecialSkillNames;
            var specialSkillName = Program.ExeData.GetText(specialSkillOffset[index].Offset, specialSkillOffset[index].Length);

            if (string.IsNullOrEmpty(format))
                return specialSkillName;
            else
                return string.Format(format, index, specialSkillName);
        }
    }
}
