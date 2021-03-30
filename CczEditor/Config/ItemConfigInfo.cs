#region using List

using System.Collections.Generic;
using System.Xml;
using System;

#endregion

namespace CczEditor.Config
{
	/// <summary>
	/// 道具配置相关信息
	/// </summary>
	public class ItemConfigInfo
	{
		private readonly Dictionary<string, int> _configs = new Dictionary<string, int>
		                                                    {
		                                                    	{ "WeaponsMin", 0 },
		                                                    	{ "WeaponsMax", 13 },
		                                                    	{ "ArmorMin", 14 },
		                                                    	{ "ArmorMax", 17 },
		                                                    	{ "AuxiliaryMin", 24 },
		                                                    	{ "AuxiliaryMax", 103 },
		                                                    	{ "ConsumablesMin", 104 },
		                                                    	{ "ConsumablesMax", 118 }
		                                                    };

		/// <summary>
		/// 道具配置
		/// </summary>
		public Dictionary<string, int> Configs
		{
			get { return _configs; }
		}

		/// <summary>
		/// 道具效果
		/// </summary>
		public Dictionary<int, string> Effects { get; set; }

		/// <summary>
		/// 武器类型
		/// </summary>
		public Dictionary<int, string> WeaponsTypes(bool hasFormater)
		{
			var _weaponsMin = _configs["WeaponsMin"];
			var _weaponsMax = _configs["WeaponsMax"];
			var list = new Dictionary<int, string>();
			for (var i = _weaponsMin; i <= _weaponsMax; i++)
			{
				if (Effects.ContainsKey(i))
				{
					list.Add(i, hasFormater ? string.Format(Program.FORMATSTRING_KEYVALUEPAIR_HEX2, i, Effects[i]) : Effects[i]);
				}
			}
			return list;
		}

		/// <summary>
		/// 防具类型
		/// </summary>
		public Dictionary<int, string> ArmorTypes(bool hasFormater)
		{
			var _armorMin = _configs["ArmorMin"];
			var _armorMax = _configs["ArmorMax"];
			var list = new Dictionary<int, string>();
			for (var i = _armorMin; i <= _armorMax; i++)
			{
				if (Effects.ContainsKey(i))
				{
					list.Add(i, hasFormater ? string.Format(Program.FORMATSTRING_KEYVALUEPAIR_HEX2, i, Effects[i]) : Effects[i]);
				}
			}
			return list;
		}

		/// <summary>
		/// 装备类型
		/// </summary>
        public Dictionary<int, string> EquipmentTypes(bool hasFormater)
		{
			var _weaponsMin = _configs["WeaponsMin"];
			var _armorMax = _configs["ArmorMax"];
			var list = new Dictionary<int, string>();
			for (var i = _weaponsMin; i <= _armorMax; i++)
			{
				if (Effects.ContainsKey(i))
				{
					list.Add(i, hasFormater ? string.Format(Program.FORMATSTRING_KEYVALUEPAIR_HEX2, i, Effects[i]) : Effects[i]);
				}
            }
			return list;
		}

		/// <summary>
		/// 辅助效果
		/// </summary>
        public Dictionary<int, string> AuxiliaryEffects(bool hasFormater)
		{
			var _auxiliaryMin = _configs["AuxiliaryMin"];
			var _auxiliaryMax = _configs["AuxiliaryMax"];
			var _consumablesMin = _configs["ConsumablesMin"];
            var _consumablesMax = _configs["ConsumablesMax"]; ;
            if (Program.CurrentConfig.Starusing)
            {
                _consumablesMax = _configs["AtkBomb"];
            }
            else
            {
                _consumablesMax = _configs["ConsumablesMax"];
            }
			var list = new Dictionary<int, string>();
			for (var i = _auxiliaryMin; i <= _auxiliaryMax; i++)
            {
                if (Program.ExeData != null && Program.ExeData.CurrentFile != null && Program.ExeData.CurrentStream != null)
                {
                    if (((_consumablesMin > _auxiliaryMax) || (_consumablesMin >= _auxiliaryMin && _consumablesMin <= _auxiliaryMax) || (_consumablesMax >= _auxiliaryMin && _consumablesMax <= _auxiliaryMax)) && (i < _consumablesMin || i > _consumablesMax) && Effects.ContainsKey(i))
                    {
                        Program.ExeData.EffectsNames(true, list, Convert.ToInt32(Effects[i], 16), i);
                    }
                }
                else
                {
                    if (((_consumablesMin > _auxiliaryMax) || (_consumablesMin >= _auxiliaryMin && _consumablesMin <= _auxiliaryMax) || (_consumablesMax >= _auxiliaryMin && _consumablesMax <= _auxiliaryMax)) && (i < _consumablesMin || i > _consumablesMax) && Effects.ContainsKey(i))
                    {
                        list.Add(i, hasFormater ? string.Format(Program.FORMATSTRING_KEYVALUEPAIR_HEX2, i, " ") : " ");
                    }
                   
                }                
			}
			return list;
		}
		/// <summary>
		/// 消耗品效果
		/// </summary>
        public Dictionary<int, string> ConsumablesEffects(bool hasFormater)
		{
			var _consumablesMin = _configs["ConsumablesMin"];
			var _consumablesMax = _configs["ConsumablesMax"];
            var list = new Dictionary<int, string>();
            for (var i = _consumablesMin; i <= _consumablesMax; i++)
            {
                if (Program.ExeData != null && Program.ExeData.CurrentFile != null && Program.ExeData.CurrentStream != null)
                {
                    if (Effects.ContainsKey(i))
                    {
                        Program.ExeData.EffectsNames(true, list, Convert.ToInt32(Effects[i], 16), i);
                    }                   
                }
                else
                {
                    if (Effects.ContainsKey(i))
                    {
                        list.Add(i, hasFormater ? string.Format(Program.FORMATSTRING_KEYVALUEPAIR_HEX2, i, " ") : " ");
                    }            
                }
            }
			return list;
		}
        /// <summary>
        /// 폭탄-매설/조종
        /// </summary>
        public Dictionary<int, string> BombsEffects(bool hasFormater)
        {
            var _BombsMin = _configs["AssMin"];
            var _BombsMax = _configs["AssMax"];
            var list = new Dictionary<int, string>();
            for (var i = _BombsMin; i <= _BombsMax; i++)
            {
                if (Program.ExeData != null && Program.ExeData.CurrentFile != null && Program.ExeData.CurrentStream != null)
                {
                    if (Effects.ContainsKey(i))
                    {
                        Program.ExeData.EffectsNames(true, list, Convert.ToInt32(Effects[i], 16), i);
                    }
                }
                else
                {
                    if (Effects.ContainsKey(i))
                    {
                        list.Add(i, hasFormater ? string.Format(Program.FORMATSTRING_KEYVALUEPAIR_HEX2, i, " ") : " ");
                    }
                }
            }
            return list;
        }
        /// <summary>
        /// 폭탄-지뢰
        /// </summary>
        public Dictionary<int, string> BombsEffects2(bool hasFormater)
        {
            var _Bombs = _configs["AtkMine"];
            var list = new Dictionary<int, string>();
            var i = _Bombs;

            if (Program.ExeData != null && Program.ExeData.CurrentFile != null && Program.ExeData.CurrentStream != null)
            {
                if (Effects.ContainsKey(i))
                {
                    Program.ExeData.EffectsNames(true, list, Convert.ToInt32(Effects[i], 16), i);
                }
            }
            else
            {
                if (Effects.ContainsKey(i))
                {
                    list.Add(i, hasFormater ? string.Format(Program.FORMATSTRING_KEYVALUEPAIR_HEX2, i, " ") : " ");
                }
            }
            return list;
        }
        /// <summary>
        /// 폭탄-폭탄
        /// </summary>
        public Dictionary<int, string> BombsEffects3(bool hasFormater)
        {
            var _Bombs = _configs["AtkBomb"];
            var list = new Dictionary<int, string>();
            var i = _Bombs;

            if (Program.ExeData != null && Program.ExeData.CurrentFile != null && Program.ExeData.CurrentStream != null)
            {
                if (Effects.ContainsKey(i))
                {
                    Program.ExeData.EffectsNames(true, list, Convert.ToInt32(Effects[i], 16), i);
                }
            }
            else
            {
                if (Effects.ContainsKey(i))
                {
                    list.Add(i, hasFormater ? string.Format(Program.FORMATSTRING_KEYVALUEPAIR_HEX2, i, " ") : " ");
                }
            }
            return list;
        }
		public void ReadXml(XmlReader reader)
		{
			if (reader == null)
			{
				return;
			}
			var wasEmpty = reader.IsEmptyElement;
			reader.Read();
			if (!wasEmpty)
			{
				string sKey, sValue;
				int iKey, iValue;
				wasEmpty = reader.IsEmptyElement;
				reader.ReadStartElement("Configs");
				if (!wasEmpty)
				{
					while (reader.NodeType != XmlNodeType.EndElement)
					{
						sKey = reader.GetAttribute("Key");
						reader.ReadStartElement("Config");
						iValue = reader.ReadContentAsInt();
						Configs[sKey] = iValue;
						reader.ReadEndElement();
					}
					reader.ReadEndElement();
				}
				wasEmpty = reader.IsEmptyElement;
				reader.ReadStartElement("Effects");
				if (!wasEmpty)
				{
					Effects = new Dictionary<int, string>();
					while (reader.NodeType != XmlNodeType.EndElement)
					{
						iKey = int.Parse(reader.GetAttribute("Id"));
						reader.ReadStartElement("Effect");
						sValue = reader.ReadContentAsString();
						Effects.Add(iKey, sValue);
						reader.ReadEndElement();
					}
					reader.ReadEndElement();
				}
				reader.ReadEndElement();
			}
		}

		public void WriteXml(XmlWriter writer)
		{
			if (writer == null)
			{
				return;
			}
			writer.WriteStartElement("Configs");
			foreach (var config in Configs)
			{
				writer.WriteStartElement("Config");
				writer.WriteStartAttribute("Key");
				writer.WriteString(config.Key);
				writer.WriteEndAttribute();
				writer.WriteValue(config.Value);
				writer.WriteEndElement();
			}
			writer.WriteEndElement();
			writer.WriteStartElement("Effects");
			if (Effects != null)
			{
				foreach (var effect in Effects)
				{
					writer.WriteStartElement("Effect");
					writer.WriteStartAttribute("Id");
					writer.WriteValue(effect.Key);
					writer.WriteEndAttribute();
					writer.WriteString(effect.Value);
					writer.WriteEndElement();
				}
			}
			writer.WriteEndElement();
		}
	}
}