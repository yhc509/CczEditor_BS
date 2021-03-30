#region

using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Windows.Forms;
using System.Xml;

#endregion

namespace CczEditor.Config
{
    /// <summary>
    /// 配置信息
    /// </summary>
    public class ConfigInfo
    {
        public ConfigInfo() { }

        public ConfigInfo(string typeName)
        {
            TypeName = typeName;
        }


        /// <summary>
        /// 버전명
        /// </summary>
        public string TypeName { get; private set; }

        /// <summary>
        /// 버전명표시
        /// </summary>
        public string DisplayName { get; set; }

        /// <summary>
        /// 소모품도구범위확장
        /// </summary>
        public bool ItemCustomRange { get; set; }

        /// <summary>
        /// 간체번체여부
        /// </summary>
        public bool LanguageGB { get; set; }

        /// <summary>
        /// MP한계돌파
        /// </summary>
        public bool SaveMpExtension { get; set; }

        /// <summary>
        /// Star사용여부
        /// </summary>
        public bool Starusing { get; set; }

        /// <summary>
        /// 평상조형한계돌파
        /// </summary>
        public bool ObjExtension { get; set; }

        /// <summary>
        /// 전투조형한계돌파
        /// </summary>
        public bool SpcExtension { get; set; }

        /// <summary>
        /// 인공지능한계돌파
        /// </summary>
        public bool AIExtension { get; set; }

        /// <summary>
        /// 책략습득
        /// </summary>
        public bool MagicLearnExtension { get; set; }

        /// <summary>
        /// 열전능력방식
        /// </summary>
        public bool SingularAttribute { get; set; }

        /// <summary>
        /// 파일경로
        /// </summary>
        public string DataFileDirectory { get; set; }

        /// <summary>
        /// Exe이름
        /// </summary>
        public string Exename { get; set; }


        private readonly Dictionary<string, int> _offsets = new Dictionary<string, int>
		                                                    {
		                                                    	{ "Game_Unit_Count", 0x400 },
		                                                    	{ "Game_Unit_Offset", 0x18C },
		                                                    	{ "Game_Item_Count", 0x68 },
		                                                    	{ "Game_Item_Offset", 0x818C },
		                                                    	{ "Game_Shop_Offset", 0x8BB4 },
		                                                    	{ "Game_Force_Offset", 0x9DB4 },
		                                                    	{ "Game_Force_Length", 0x1B },
		                                                    	{ "Game_Terrain_Offset", 0xA624 },
		                                                    	{ "Game_Magic_Count", 0X4A },
		                                                    	{ "Game_Magic_Offset", 0xAF84 },
		                                                    	{ "Game_Magic_Length", 0x61 },
		                                                    	{ "Imsg_Item_Offset", 0x0 },
		                                                    	{ "Imsg_Magic_Offset", 0x7530 },
		                                                    	{ "Imsg_Stage_Count", 0X63 },
		                                                    	{ "Imsg_Stage_Offset", 0xC350 },
		                                                    	{ "Imsg_Force_Offset", 0x11170 },
		                                                    	{ "Imsg_UnitOriginal_Offset", 0x15F90 },
		                                                    	{ "Imsg_Retreat_Offset", 0x1FBD0 },
		                                                    	{ "Imsg_Critical_Offset", 0x222E0 },
		                                                    	{ "Imsg_Staff_Offset", 0x27100 },
		                                                    	{ "Imsg_UnitExtension_Offset", 0x2D050 },
		                                                    	{ "Save_Gold_Offset", 0x32 },
		                                                    	{ "Save_LoyalTreacherousValue_Offset", 0x7E },
		                                                    	{ "Save_ItemEquipment_Offset", 0x7F },
		                                                    	{ "Save_ItemAmount_Offset", 0x2D7 },
		                                                    	{ "Save_Unit_Offset", 0x14F0 },
                                                                { "Star_Item_Count", 0x8E },
                                                                { "Star_Item_Offset", 0x0 },
                                                                { "Three_SPC", 0x6 },
                                                                { "Unit_Cha", 0xE2800 },
                                                                { "Unit_Spc", 0xD2800 },
                                                                { "Unit_Pmapobj", 0xE1000 },
                                                                { "Imsg_Critical_Count", 0x14 },
                                                                { "Exe_Critical_Offset", 0x89C30 },

                                                                { "Exe_Force_AtkEffect", 0x6C81 },
                                                                { "Exe_Force_MovSound", 0xA38C0 },
                                                                { "Exe_Force_MovSpeed", 0xA38E8 },
                                                                { "Exe_Force_AtkSound", 0xA3910 },
                                                                { "Exe_Force_AtkType", 0xA3938 },
                                                                { "Exe_Force_ForceType", 0xA3988 },
                                                                { "Exe_Force_SprDmg", 0xA39B0 },
                                                                { "Exe_Force_AtkDelay", 0xA39D8 },
                                                                { "Exe_Force_AtkPinc", 0xA3960 },
                                                                { "Exe_Force_SangSeong", 0xA3280 },
                                                                
                                                                { "Exe_Magic_Meff_Start", 0x0 },
                                                                { "Exe_Magic_Meff_Offset", 0x858BE },
                                                                { "Exe_Magic_Meff_End", 0x49 },
                                                                { "Exe_Magic_Mcall_Start", 0x3 },
                                                                { "Exe_Magic_Mcall_Offset", 0x20BBE },
                                                                { "Exe_Magic_Mcall_End", 0x43 },
                                                                { "Exe_Magic_MagicT_Start", 0x0 },
                                                                { "Exe_Magic_MagicT_Offset", 0x24E53 },
                                                                { "Exe_Magic_MagicT_End", 0x49 },
                                                                { "Exe_Magic_DamgT_Start", 0x0 },
                                                                { "Exe_Magic_DamgT_Offset", 0x48FC3 },
                                                                { "Exe_Magic_DamgT_End", 0x49 },
                                                                { "Exe_Magic_CureT_Start", 0x26 },
                                                                { "Exe_Magic_CureT_Offset", 0x3BB14 },
                                                                { "Exe_Magic_CureT_End", 0x43 },
                                                                { "Exe_Magic_AI_Start", 0x0 },
                                                                { "Exe_Magic_AI_Offset", 0x39580 },
                                                                { "Exe_Magic_AI_End", 0x48 },
                                                                
                                                                { "Exe_Magic_Cond_Start", 0x0 },
                                                                { "Exe_Magic_Cond_Offset", 0x1F47E },
                                                                { "Exe_Magic_Cond_End", 0x49 },
                                                                { "Exe_Magic_Damg_Start", 0x0 },
                                                                { "Exe_Magic_Damg_Offset", 0x3B720 },
                                                                { "Exe_Magic_Damg_End", 0x49 },
                                                                { "Exe_Magic_HitP_Start", 0x0 },
                                                                { "Exe_Magic_HitP_Offset", 0x3AE01 },
                                                                { "Exe_Magic_HitP_End", 0x49 },
                                                                { "Exe_Magic_Learn_Start", 0x0 },
                                                                { "Exe_Magic_Learn_Offset", 0x65208 },
                                                                { "Exe_Magic_Learn_End", 0x49 },

                                                                { "Unit_Cutin", 0xF7F50 },
                                                                { "Unit_Voice", 0xF80C0 },
                                                                { "Unit_Cost", 0xF9330 },
                                                            };

        /// <summary>
        /// 文件偏移
        /// </summary>
        public Dictionary<string, int> Offsets
        {
            get { return _offsets; }
        }

        /// <summary>
        /// 部队类型
        /// </summary>
        public List<string> Forces { get; set; }

        /// <summary>
        /// 部队类型显示名称
        /// </summary>
        public List<string> ForceNames
        {
            get
            {
                var list = new List<string>();
                if (Forces != null)
                {
                    if (Program.ExeData != null && Program.ExeData.CurrentFile != null && Program.ExeData.CurrentStream != null)
                    {
                        for (var i = 0; i < Forces.Count; i++)
                        {
                            Program.ExeData.ForceNames(true, list, Convert.ToInt32(Forces[i], 16), i);
                        }             
                    }
                    else
                    {
                        for (var i = 0; i < Forces.Count; i++)
                        {
                            list.Add(string.Format(Program.FORMATSTRING_KEYVALUEPAIR_HEX2, i, " "));
                        }           
                    }
                }
                return list;
            }
        }
        /// <summary>
        /// 部队分类
        /// </summary>
        public List<string> ForceCategories { get; set; }

        /// <summary>
        /// 部队分类显示名称
        /// </summary>
        public List<string> ForceCategoryNames
        {
            get
            {
                var list = new List<string>();

                if (ForceCategories != null)
                {
                    if (Program.ExeData != null && Program.ExeData.CurrentFile != null && Program.ExeData.CurrentStream != null)
                    {
                        for (var i = 0; i < ForceCategories.Count; i++)
                        {
                            Program.ExeData.ForceCategoryNames(true, list, Convert.ToInt32(ForceCategories[i], 16), i);
                        }
                    }
                    else
                    {
                        for (var i = 0; i < ForceCategories.Count; i++)
                        {
                            list.Add(string.Format(Program.FORMATSTRING_KEYVALUEPAIR_HEX2, i, " "));
                        }
                    }
                }
                return list;
            }
        }
        public String ForceCategoryNameslb(int i)
        {
            var label = new Label();
            if (ForceCategories != null)
            {
                if (Program.ExeData != null && Program.ExeData.CurrentFile != null && Program.ExeData.CurrentStream != null)
                {
                    return Program.ExeData.ForceCategoryNames2(Convert.ToInt32(ForceCategories[i], 16));
                        
                }
                else
                {
                    return " ";                   
                }
            }
            else
            {
                return " ";                
            }
        }
        private readonly ItemConfigInfo _itemConfigs = new ItemConfigInfo();

        /// <summary>
        /// 道具设置
        /// </summary>
        public ItemConfigInfo ItemConfigs
        {
            get { return _itemConfigs; }
        }

        /// <summary>
        /// 攻击范围文本设置
        /// </summary>
        public List<string> Hitareas { get; set; }

        /// <summary>
        /// 效果范围文本设置
        /// </summary>
        public List<string> Effareas { get; set; }

        /// <summary>
        /// 返回当前配置的副本
        /// </summary>
        /// <param name="newTypeName">新配置的类型名</param>
        /// <returns>当前配置的副本</returns>
        public ConfigInfo CloneConfig(string newTypeName)
        {
            if (newTypeName == null)
            {
                return null;
            }
            var config = new ConfigInfo(string.Copy(newTypeName))
            {
                LanguageGB = LanguageGB,
                ItemCustomRange = ItemCustomRange,
                SaveMpExtension = SaveMpExtension,
                Starusing = Starusing,
                ObjExtension = ObjExtension,
                SpcExtension = SpcExtension,
                AIExtension = AIExtension,
                MagicLearnExtension = MagicLearnExtension,
                SingularAttribute = SingularAttribute
            };
            if (DisplayName != null)
            {
                config.DisplayName = string.Copy(DisplayName);
            }
            if (Exename != null)
            {
                config.Exename = string.Copy(Exename);
            }
            if (DataFileDirectory != null)
            {
                config.DataFileDirectory = string.Copy(DataFileDirectory);
            }
            foreach (var offset in Offsets)
            {
                config.Offsets[offset.Key] = offset.Value;
            }
            config.Forces = new List<string>();
            if (Forces != null)
            {
                foreach (var force in Forces)
                {
                    config.Forces.Add(string.Copy(force));
                }
            }
            config.ForceCategories = new List<string>();
            if (ForceCategories != null)
            {
                foreach (var forceCategory in ForceCategories)
                {
                    config.ForceCategories.Add(string.Copy(forceCategory));
                }
            }
            foreach (var itemConfig in ItemConfigs.Configs)
            {
                config.ItemConfigs.Configs[itemConfig.Key] = itemConfig.Value;
            }
            config.ItemConfigs.Effects = new Dictionary<int, string>();
            if (ItemConfigs.Effects != null)
            {
                foreach (var effect in ItemConfigs.Effects)
                {
                    config.ItemConfigs.Effects.Add(effect.Key, string.Copy(effect.Value));
                }
            }
            config.Hitareas = new List<string>();
            if (Hitareas != null)
            {
                foreach (var area in Hitareas)
                {
                    config.Hitareas.Add(string.Copy(area));
                }
            }
            config.Effareas = new List<string>();
            if (Effareas != null)
            {
                foreach (var area in Effareas)
                {
                    config.Effareas.Add(string.Copy(area));
                }
            }
            return config;
        }

        /// <summary>
        /// 文件路径
        /// </summary>
        public string FileName
        {
            get { return GetFileName(TypeName); }
        }

        /// <summary>
        /// 配置文件是否存在
        /// </summary>
        public bool Exists
        {
            get { return File.Exists(FileName); }
        }

        /// <summary>
        /// 获得配置文件，文件名
        /// </summary>
        /// <param name="typeName">类型名</param>
        /// <returns>配置文件名</returns>
        public static string GetFileName(string typeName)
        {
            return Path.Combine(Application.StartupPath, string.Format("{0}-{1}.config", Path.GetFileNameWithoutExtension(Application.ExecutablePath), typeName));
        }

        /// <summary>
        /// 判断指定类型的配置文件是否存在
        /// </summary>
        /// <param name="typeName">类型名</param>
        /// <returns>配置文件是否存在</returns>
        public static bool ExistsFile(string typeName)
        {
            return File.Exists(GetFileName(typeName));
        }

        /// <summary>
        /// 读取配置文件
        /// </summary>
        public void ReadXml()
        {
            try
            {
                using (var reader = XmlReader.Create(FileName, Program.XmlReaderSettings))
                {
                    reader.Read();
                    ReadXml(reader);
                    reader.Close();
                }
            }
            catch (Exception)
            {
                return;
            }
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
                int iValue;
                wasEmpty = reader.IsEmptyElement;
                reader.ReadStartElement("TypeName");
                if (!wasEmpty)
                {
                    TypeName = reader.ReadContentAsString();
                    reader.ReadEndElement();
                }
                wasEmpty = reader.IsEmptyElement;
                reader.ReadStartElement("DisplayName");
                if (!wasEmpty)
                {
                    DisplayName = reader.ReadContentAsString();
                    reader.ReadEndElement();
                }
                wasEmpty = reader.IsEmptyElement;
                reader.ReadStartElement("LanguageGB");
                if (!wasEmpty)
                {
                    LanguageGB = reader.ReadContentAsBoolean();
                    reader.ReadEndElement();
                }
                wasEmpty = reader.IsEmptyElement;
                reader.ReadStartElement("ItemCustomRange");
                if (!wasEmpty)
                {
                    ItemCustomRange = reader.ReadContentAsBoolean();
                    reader.ReadEndElement();
                }
                wasEmpty = reader.IsEmptyElement;
                reader.ReadStartElement("SaveMpExtension");
                if (!wasEmpty)
                {
                    SaveMpExtension = reader.ReadContentAsBoolean();
                    reader.ReadEndElement();
                }
                wasEmpty = reader.IsEmptyElement;
                reader.ReadStartElement("Starusing");
                if (!wasEmpty)
                {
                    Starusing = reader.ReadContentAsBoolean();
                    reader.ReadEndElement();
                }
                wasEmpty = reader.IsEmptyElement;
                reader.ReadStartElement("ObjExtension");
                if (!wasEmpty)
                {
                    ObjExtension = reader.ReadContentAsBoolean();
                    reader.ReadEndElement();
                }
                wasEmpty = reader.IsEmptyElement;
                reader.ReadStartElement("SpcExtension");
                if (!wasEmpty)
                {
                    SpcExtension = reader.ReadContentAsBoolean();
                    reader.ReadEndElement();
                }
                wasEmpty = reader.IsEmptyElement;
                reader.ReadStartElement("AIExtension");
                if (!wasEmpty)
                {
                    AIExtension = reader.ReadContentAsBoolean();
                    reader.ReadEndElement();
                }
                wasEmpty = reader.IsEmptyElement;
                reader.ReadStartElement("MagicLearnExtension");
                if (!wasEmpty)
                {
                    MagicLearnExtension = reader.ReadContentAsBoolean();
                    reader.ReadEndElement();
                }
                wasEmpty = reader.IsEmptyElement;
                reader.ReadStartElement("SingularAttribute");
                if (!wasEmpty)
                {
                    SingularAttribute = reader.ReadContentAsBoolean();
                    reader.ReadEndElement();
                }
                wasEmpty = reader.IsEmptyElement;
                reader.ReadStartElement("DataFileDirectory");
                if (!wasEmpty)
                {
                    DataFileDirectory = reader.ReadContentAsString();
                    reader.ReadEndElement();
                }
                wasEmpty = reader.IsEmptyElement;
                reader.ReadStartElement("Exename");
                if (!wasEmpty)
                {
                    Exename = reader.ReadContentAsString();
                    reader.ReadEndElement();
                }
                wasEmpty = reader.IsEmptyElement;
                reader.ReadStartElement("Offsets");
                if (!wasEmpty)
                {
                    while (reader.NodeType != XmlNodeType.EndElement)
                    {
                        sKey = reader.GetAttribute("Key");
                        reader.ReadStartElement("Offset");
                        iValue = int.Parse(reader.ReadContentAsString(), NumberStyles.HexNumber);
                        Offsets[sKey] = iValue;
                        reader.ReadEndElement();
                    }
                    reader.ReadEndElement();
                }
                wasEmpty = reader.IsEmptyElement;
                reader.ReadStartElement("Forces");
                if (!wasEmpty)
                {
                    Forces = new List<string>();
                    while (reader.NodeType != XmlNodeType.EndElement)
                    {
                        reader.ReadStartElement("Force");
                        sValue = reader.ReadContentAsString();
                        Forces.Add(sValue);
                        reader.ReadEndElement();
                    }
                    reader.ReadEndElement();
                }
                wasEmpty = reader.IsEmptyElement;
                reader.ReadStartElement("ForceCategories");
                if (!wasEmpty)
                {
                    ForceCategories = new List<string>();
                    while (reader.NodeType != XmlNodeType.EndElement)
                    {
                        reader.ReadStartElement("ForceCategory");
                        sValue = reader.ReadContentAsString();
                        ForceCategories.Add(sValue);
                        reader.ReadEndElement();
                    }
                    reader.ReadEndElement();
                }
                ItemConfigs.ReadXml(reader);
                wasEmpty = reader.IsEmptyElement;
                reader.ReadStartElement("Hitareas");
                if (!wasEmpty)
                {
                    Hitareas = new List<string>();
                    while (reader.NodeType != XmlNodeType.EndElement)
                    {
                        reader.ReadStartElement("Hitarea");
                        sValue = reader.ReadContentAsString();
                        Hitareas.Add(sValue);
                        reader.ReadEndElement();
                    }
                    reader.ReadEndElement();
                }
                wasEmpty = reader.IsEmptyElement;
                reader.ReadStartElement("Effareas");
                if (!wasEmpty)
                {
                    Effareas = new List<string>();
                    while (reader.NodeType != XmlNodeType.EndElement)
                    {
                        reader.ReadStartElement("Effarea");
                        sValue = reader.ReadContentAsString();
                        Effareas.Add(sValue);
                        reader.ReadEndElement();
                    }
                    reader.ReadEndElement();
                }
                reader.ReadEndElement();
            }
        }

        /// <summary>
        /// 写入配置文件
        /// </summary>
        public void WriteXml()
        {
            try
            {
                using (var writer = XmlWriter.Create(FileName, Program.XmlWriterSettings))
                {
                    if (writer != null)
                    {
                        writer.WriteStartDocument();
                        writer.WriteStartElement("Config");
                        WriteXml(writer);
                        writer.WriteEndElement();
                        writer.WriteEndDocument();
                        writer.Flush();
                        writer.Close();
                    }
                }
            }
            catch (Exception)
            {
                return;
            }
        }

        public void WriteXml(XmlWriter writer)
        {
            if (writer == null)
            {
                return;
            }
            writer.WriteStartElement("TypeName");
            writer.WriteString(TypeName);
            writer.WriteEndElement();
            writer.WriteStartElement("DisplayName");
            writer.WriteString(DisplayName);
            writer.WriteEndElement();
            writer.WriteStartElement("LanguageGB");
            writer.WriteValue(LanguageGB);
            writer.WriteEndElement();
            writer.WriteStartElement("ItemCustomRange");
            writer.WriteValue(ItemCustomRange);
            writer.WriteEndElement();
            writer.WriteStartElement("SaveMpExtension");
            writer.WriteValue(SaveMpExtension);
            writer.WriteEndElement();
            writer.WriteStartElement("Starusing");
            writer.WriteValue(Starusing);
            writer.WriteEndElement();
            writer.WriteStartElement("ObjExtension");
            writer.WriteValue(ObjExtension);
            writer.WriteEndElement();
            writer.WriteStartElement("SpcExtension");
            writer.WriteValue(SpcExtension);
            writer.WriteEndElement();
            writer.WriteStartElement("AIExtension");
            writer.WriteValue(AIExtension);
            writer.WriteEndElement();
            writer.WriteStartElement("MagicLearnExtension");
            writer.WriteValue(MagicLearnExtension);
            writer.WriteEndElement();
            writer.WriteStartElement("SingularAttribute");
            writer.WriteValue(SingularAttribute);
            writer.WriteEndElement();
            writer.WriteStartElement("DataFileDirectory");
            writer.WriteString(DataFileDirectory);
            writer.WriteEndElement();
            writer.WriteStartElement("Exename");
            writer.WriteString(Exename);
            writer.WriteEndElement();
            writer.WriteStartElement("Offsets");
            foreach (var offset in Offsets)
            {
                writer.WriteStartElement("Offset");
                writer.WriteStartAttribute("Key");
                writer.WriteString(offset.Key);
                writer.WriteEndAttribute();
                writer.WriteString(offset.Value.ToString("X"));
                writer.WriteEndElement();
            }
            writer.WriteEndElement();
            writer.WriteStartElement("Forces");
            if (Forces != null)
            {
                for (var i = 0; i < Forces.Count; i++)
                {
                    writer.WriteStartElement("Force");
                    writer.WriteStartAttribute("Id");
                    writer.WriteValue(i);
                    writer.WriteEndAttribute();
                    writer.WriteString(Forces[i]);
                    writer.WriteEndElement();
                }
            }
            writer.WriteEndElement();
            writer.WriteStartElement("ForceCategories");
            if (ForceCategories != null)
            {
                for (var i = 0; i < ForceCategories.Count; i++)
                {
                    writer.WriteStartElement("ForceCategory");
                    writer.WriteStartAttribute("Id");
                    writer.WriteValue(i);
                    writer.WriteEndAttribute();
                    writer.WriteString(ForceCategories[i]);
                    writer.WriteEndElement();
                }
            }
            writer.WriteEndElement();
            writer.WriteStartElement("ItemConfigs");
            if (ItemConfigs != null)
            {
                ItemConfigs.WriteXml(writer);
            }
            writer.WriteEndElement();
            writer.WriteStartElement("Hitareas");
            if (Hitareas != null)
            {
                for (var i = 0; i < Hitareas.Count; i++)
                {
                    writer.WriteStartElement("Hitarea");
                    writer.WriteStartAttribute("Id");
                    writer.WriteValue(i);
                    writer.WriteEndAttribute();
                    writer.WriteString(Hitareas[i]);
                    writer.WriteEndElement();
                }
            }
            writer.WriteEndElement();
            writer.WriteStartElement("Effareas");
            if (Effareas != null)
            {
                for (var i = 0; i < Effareas.Count; i++)
                {
                    writer.WriteStartElement("Effarea");
                    writer.WriteStartAttribute("Id");
                    writer.WriteValue(i);
                    writer.WriteEndAttribute();
                    writer.WriteString(Effareas[i]);
                    writer.WriteEndElement();
                }
            }
            writer.WriteEndElement();
        }
    }
}