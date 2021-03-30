#region

using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Xml;

#endregion

namespace CczEditor.Config
{
	/// <summary>
	/// 配置信息集合
	/// </summary>
	public class ConfigInfoCollection : Dictionary<string, ConfigInfo>
	{
		public new ConfigInfo this[string key]
		{
			get
			{
				if (ContainsKey(key))
				{
					return base[key];
				}
				var config = new ConfigInfo(key);
				if (config.Exists)
				{
					config.ReadXml();
					Add(key, config);
					return config;
				}
				return null;
			}
			set { base[key] = value; }
		}

		/// <summary>
		/// 文件路径
		/// </summary>
		public static readonly string FileName = GetFileName();

		/// <summary>
		/// 配置文件是否存在
		/// </summary>
		public static bool Exists
		{
			get { return File.Exists(FileName); }
		}

		/// <summary>
		/// 获得系统配置文件，文件名
		/// </summary>
		/// <returns>配置文件名</returns>
		public static string GetFileName()
		{
			return Path.Combine(Application.StartupPath, string.Format("{0}Configs.config", Path.GetFileNameWithoutExtension(Application.ExecutablePath)));
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
			if (reader == null || reader.IsEmptyElement)
			{
				return;
			}
			reader.Read();
			ConfigInfo info;
			while (reader.NodeType != XmlNodeType.EndElement)
			{
				info = new ConfigInfo();
				info.ReadXml(reader);
				Add(info.TypeName, info);
			}
			reader.ReadEndElement();
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
						writer.WriteStartElement("Configs");
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
			if (writer == null || Count <= 0)
			{
				return;
			}
			foreach (var info in Values)
			{
				writer.WriteStartElement("Config");
				info.WriteXml(writer);
				writer.WriteEndElement();
			}
		}
	}
}