#region using List

using System;
using System.IO;
using System.Windows.Forms;
using System.Xml;

#endregion

namespace CczEditor.Config
{
	/// <summary>
	/// 系统配置信息
	/// </summary>
	public class SystemConfigInfo
	{
		private string _currentType;

		/// <summary>
		/// 当前配置
		/// </summary>
		public string CurrentType
		{
			get { return _currentType; }
			set
			{
				_currentType = value;
				WriteXml();
			}
		}

		private int _specialImageDesignatedOffset;
        private int _RspecialImageDesignatedOffset;

		/// <summary>
		/// 特殊形象偏移
		/// </summary>
		public int SpecialImageDesignatedOffset
		{
			get { return _specialImageDesignatedOffset; }
			set
			{
				_specialImageDesignatedOffset = value;
				WriteXml();
			}
		}
        public int RSpecialImageDesignatedOffset
        {
            get { return _RspecialImageDesignatedOffset; }
            set
            {
                _RspecialImageDesignatedOffset = value;
                WriteXml();
            }
        }

		private int _forceCategoriesRestraintOffset;

		/// <summary>
		/// 兵种相克偏移
		/// </summary>
		public int ForceCategoriesRestraintOffset
		{
			get { return _forceCategoriesRestraintOffset; }
			set
			{
				_forceCategoriesRestraintOffset = value;
				WriteXml();
			}
		}

		/// <summary>
		/// 文件路径
		/// </summary>
		public static readonly string FileName = GetFileName();

		/// <summary>
		/// 配置文件是否存在
		/// </summary>
		public bool Exists
		{
			get { return File.Exists(FileName); }
		}

		/// <summary>
		/// 获得系统配置文件，文件名
		/// </summary>
		/// <returns>配置文件名</returns>
		public static string GetFileName()
		{
			return Path.Combine(Application.StartupPath, string.Format("{0}.config", Path.GetFileNameWithoutExtension(Application.ExecutablePath)));
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
					reader.Skip();
					reader.ReadStartElement("SystemConfig");
					var wasEmpty = reader.IsEmptyElement;
					reader.ReadStartElement("CurrentType");
					if (!wasEmpty)
					{
						_currentType = reader.ReadContentAsString();
						reader.ReadEndElement();
					}
					wasEmpty = reader.IsEmptyElement;
					reader.ReadStartElement("SpecialImageDesignatedOffset");
					if (!wasEmpty)
					{
						_specialImageDesignatedOffset = reader.ReadContentAsInt();
						reader.ReadEndElement();
					}
					wasEmpty = reader.IsEmptyElement;
					reader.ReadStartElement("ForceCategoriesRestraintOffset");
					if (!wasEmpty)
					{
						_forceCategoriesRestraintOffset = reader.ReadContentAsInt();
						reader.ReadEndElement();
					}
					reader.ReadEndElement();
					reader.Close();
				}
			}
			catch (Exception)
			{
				return;
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
						writer.WriteStartElement("SystemConfig");
						writer.WriteStartElement("CurrentType");
						writer.WriteString(_currentType);
						writer.WriteEndElement();
						writer.WriteStartElement("SpecialImageDesignatedOffset");
						writer.WriteValue(_specialImageDesignatedOffset);
						writer.WriteEndElement();
						writer.WriteStartElement("ForceCategoriesRestraintOffset");
						writer.WriteValue(_forceCategoriesRestraintOffset);
						writer.WriteEndElement();
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
	}
}