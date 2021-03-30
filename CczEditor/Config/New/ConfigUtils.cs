using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CczEditor.Config.New
{
    public class ConfigUtils
    {
        public static Dictionary<int, string> GetWeaponsTypes(bool hasFormater)
        {
            var min = Program.CurrentConfig.Items.WeaponIndexMin;
            var max = Program.CurrentConfig.Items.WeaponIndexMax;
            var effects = Program.CurrentConfig.ItemEffects;
            var list = new Dictionary<int, string>();
            for (var i = min; i <= max; i++)
            {
                if (effects.Exists(x=>x.Index == i))
                {
                    list.Add(i, hasFormater ? string.Format(Program.FORMATSTRING_KEYVALUEPAIR_HEX2, i, effects[i].Offset.ToString()) : effects[i].Offset.ToString());
                }
            }
            return list;
        }

        public static Dictionary<int, string> GetArmorTypes(bool hasFormater)
        {
            var min = Program.CurrentConfig.Items.ArmorIndexMin;
            var max = Program.CurrentConfig.Items.ArmorIndexMax;
            var effects = Program.CurrentConfig.ItemEffects;
            var list = new Dictionary<int, string>();
            for (var i = min; i <= max; i++)
            {
                if (effects.Exists(x => x.Index == i))
                {
                    list.Add(i, hasFormater ? string.Format(Program.FORMATSTRING_KEYVALUEPAIR_HEX2, i, effects[i].Offset.ToString()) : effects[i].Offset.ToString());
                }
            }
            return list;
        }

        public static Dictionary<int, string> GetEquipmentTypes(string format)
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

                itemTypeName = $"{prefixType}{Data.ExeData.GetText(effect.Offset, effect.Length)}";

                if (string.IsNullOrEmpty(format))
                    result.Add(effect.Index, itemTypeName);
                else
                    result.Add(effect.Index, string.Format(format, i, itemTypeName));
            }
            return result;
        }

        public static Dictionary<int, string> GetAuxiliaryEffects(string format)
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

                    var effName = Data.ExeData.GetText(effect.Offset, effect.Length);

                    if (string.IsNullOrEmpty(format))
                        result.Add(effect.Index, effName);
                    else
                        result.Add(effect.Index, string.Format(format, i, effName));
                }
            }
            return result;
        }

        public static Dictionary<int, string> GetConsumablesEffects(string format)
        {
            var consumablesMin = Program.CurrentConfig.Items.ConsumablesMin;
            var consumablesMax = Program.CurrentConfig.Items.ConsumablesMax;
            var effects = Program.CurrentConfig.ItemEffects;
            var result = new Dictionary<int, string>();

            for (var i = consumablesMin; i <= consumablesMax; i++)
            {
                var effect = effects.Find(x => x.Index == i);
                if (effect == null) continue;
                
                var effName = Data.ExeData.GetText(effect.Offset, effect.Length);

                if (string.IsNullOrEmpty(format))
                    result.Add(effect.Index, effName);
                else
                    result.Add(effect.Index, string.Format(format, i, effName));
            }
            return result;
        }

        public static Dictionary<int, string> GetBombsEffects(bool hasFormater)
        {
            var min = Program.CurrentConfig.Items.MineInstall;
            var max = Program.CurrentConfig.Items.MineControl;
            var effects = Program.CurrentConfig.ItemEffects;
            var list = new Dictionary<int, string>();
            for (var i = min; i <= max; i++)
            {
                if (effects.Exists(x => x.Index == i))
                {
                    var text = Data.ExeData.GetText(effects[i].Offset, effects[i].Length);
                    list.Add(i, hasFormater ? string.Format(Program.FORMATSTRING_KEYVALUEPAIR_HEX2, i, text) : text);
                }
            }
            return list;
        }

        public static Dictionary<int, string> GetBombsEffects2(bool hasFormater)
        {
            var _Bombs = Program.CurrentConfig.Items.Mine;
            var effects = Program.CurrentConfig.ItemEffects;
            var list = new Dictionary<int, string>();
            var i = _Bombs;

            if (effects.Exists(x => x.Index == i))
            {
                var text = Data.ExeData.GetText(effects[i].Offset, effects[i].Length);
                list.Add(i, hasFormater ? string.Format(Program.FORMATSTRING_KEYVALUEPAIR_HEX2, i, text) : text);
            }
            return list;
        }

        public static Dictionary<int, string> GetBombsEffects3(bool hasFormater)
        {
            var _Bombs = Program.CurrentConfig.Items.Bomb;
            var effects = Program.CurrentConfig.ItemEffects;
            var list = new Dictionary<int, string>();
            var i = _Bombs;

            if (effects.Exists(x => x.Index == i))
            {
                var text = Data.ExeData.GetText(effects[i].Offset, effects[i].Length);
                list.Add(i, hasFormater ? string.Format(Program.FORMATSTRING_KEYVALUEPAIR_HEX2, i, text) : text);
            }
            return list;
        }
        
        public static Dictionary<int, string> GetForceNames(string format)
        {
            var result = new Dictionary<int, string>();
            var forceOffsets = Program.CurrentConfig.ForceNames;
            for(int i = 0; i <forceOffsets.Count; i++)
            {
                var forceName = Data.ExeData.GetText(forceOffsets[i].Offset, forceOffsets[i].Length);
                if(string.IsNullOrEmpty(format))
                    result.Add(forceOffsets[i].Index, forceName);
                else
                    result.Add(forceOffsets[i].Index, string.Format(format, i, forceName));
            }
            return result;
        }
    }
}
