#region using List

using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

#endregion

namespace CczEditor.Config
{
	/// <summary>
	/// 配置操作类
	/// </summary>
	public class ConfigOperation
	{
		static ConfigOperation()
		{
			DefaultConfigInitialization();
		}

		/// <summary>
		/// 初始化配置
		/// </summary>
		public static void InitializationConfiguration()
		{
			if (SystemConfig.Exists)
			{
				if (!DefaultConfig.Exists)
				{
					DefaultConfig.WriteXml();
				}
				SystemConfig.ReadXml();
				var typeName = SystemConfig.CurrentType;
				if (string.IsNullOrEmpty(typeName))
				{
					SetCurrentConfigToDefault();
					return;
				}
				SetCurrentConfig(typeName);
			}
			else
			{
				WriteDefaultSystemConfig();
				Configs.Add(DEFAULT_TYPE, DefaultConfig.CloneConfig(DEFAULT_TYPE));
				Configs[DEFAULT_TYPE].WriteXml();
				Program.CurrentConfig = Configs[DEFAULT_TYPE];
			}
		}

		private static readonly SystemConfigInfo _systemConfig = new SystemConfigInfo();

		/// <summary>
		/// 系统配置
		/// </summary>
		public static SystemConfigInfo SystemConfig
		{
			get { return _systemConfig; }
		}

		/// <summary>
		/// 配置集合
		/// </summary>
		public static readonly ConfigInfoCollection Configs = new ConfigInfoCollection();

		/// <summary>
		/// 默认配置类型名
		/// </summary>
		public const string DEFAULT_TYPE = "Star175 5.7";

		/// <summary>
		/// 默认配置信息
		/// </summary>
		public static ConfigInfo DefaultConfig { get; private set; }

		/// <summary>
		/// 从配置文件中读入配置信息
		/// </summary>
		/// <param name="typeName">配置类型</param>
		/// <returns>是否成功读入配置信息</returns>
		public static bool LoadConfig(string typeName)
		{
			var flag = false;
			if (Configs.ContainsKey(typeName))
			{
				flag = true;
			}
			else
			{
				var config = ReadConfigFromFile(typeName);
				if (config != null)
				{
					Configs.Add(typeName, config);
					flag = true;
				}
			}
			return flag;
		}

		/// <summary>
		/// 返回所有符合条件的配置文件路径列表
		/// </summary>
		/// <returns>配置文件路径列表</returns>
		public static List<string> GetConfigFileNames()
		{
			return Directory.GetFiles(Application.StartupPath, string.Format("{0}-*.config", Path.GetFileNameWithoutExtension(Application.ExecutablePath)), SearchOption.TopDirectoryOnly).ToList();
		}

		/// <summary>
		/// 返回配置类型与配置显示名称的键值对
		/// </summary>
		/// <returns>配置类型与配置显示名称的键值对</returns>
		public static Dictionary<string, string> GetConfigTypeNames()
		{
			var files = GetConfigFileNames();
			var typeNames = new Dictionary<string, string>();
			string typeName, displayName;
			Match match;
			var regex = new Regex(string.Format("{0}-(.*).config", Path.GetFileNameWithoutExtension(Application.ExecutablePath)));
			foreach (var file in files)
			{
				match = regex.Match(file);
				typeName = match.Groups[0].Success ? match.Groups[1].Value : string.Empty;
				displayName = Configs[typeName].DisplayName;
				if (!string.IsNullOrEmpty(typeName) && !string.IsNullOrEmpty(displayName))
				{
					typeNames.Add(typeName, displayName);
				}
			}
			return typeNames;
		}

		/// <summary>
		/// 从配置文件中读取配置信息
		/// </summary>
		/// <param name="typeName">类型名</param>
		/// <returns>配置信息</returns>
		public static ConfigInfo ReadConfigFromFile(string typeName)
		{
			var config = new ConfigInfo(typeName);
			if (config.Exists)
			{
				config.ReadXml();
				return config;
			}
			return null;
		}

		/// <summary>
		/// 初始化默认配置信息
		/// </summary>
		private static void DefaultConfigInitialization()
		{
			DefaultConfig = new ConfigInfo(DEFAULT_TYPE)
			                {
			                	DisplayName = "Star175 5.7",
                                LanguageGB = true,
			                	ItemCustomRange = false,
			                	SaveMpExtension = false,
                                Starusing = true,
                                ObjExtension = true,
                                SpcExtension = true,
                                AIExtension = false,
                                MagicLearnExtension = false,
			                	SingularAttribute = false,
			                	DataFileDirectory = string.Copy(Application.StartupPath),
                                Exename = "Ekd5.exe"
			                };
			DefaultConfig.Offsets["Game_Unit_Count"] = 0x400;
			DefaultConfig.Offsets["Game_Unit_Offset"] = 0x18C;
			DefaultConfig.Offsets["Game_Item_Count"] = 0x68;
			DefaultConfig.Offsets["Game_Item_Offset"] = 0x818C;
			DefaultConfig.Offsets["Game_Shop_Offset"] = 0x8bb4;
			DefaultConfig.Offsets["Game_Force_Offset"] = 0x9db4;
			DefaultConfig.Offsets["Game_Force_Length"] = 0x1B;
			DefaultConfig.Offsets["Game_Terrain_Offset"] = 0xA624;
			DefaultConfig.Offsets["Game_Magic_Count"] = 0x4a;
            DefaultConfig.Offsets["Game_Magic_Offset"] = 0xAF84;
			DefaultConfig.Offsets["Game_Magic_Length"] = 0x61;

            DefaultConfig.Offsets["Imsg_Item_Offset"] = 0x00;
            DefaultConfig.Offsets["Imsg_Magic_Offset"] = 0x7530;
            DefaultConfig.Offsets["Imsg_Stage_Count"] = 0x63;
            DefaultConfig.Offsets["Imsg_Stage_Offset"] = 0xc350;
            DefaultConfig.Offsets["Imsg_Force_Offset"] = 0x11170;
            DefaultConfig.Offsets["Imsg_UnitOriginal_Offset"] = 0x15f90;
            DefaultConfig.Offsets["Imsg_Retreat_Offset"] = 0x1fbd0;
            DefaultConfig.Offsets["Imsg_Critical_Offset"] = 0x222E0;
            DefaultConfig.Offsets["Imsg_Staff_Offset"] = 0x27100;
            DefaultConfig.Offsets["Imsg_UnitExtension_Offset"] = 0x2d050;

			DefaultConfig.Offsets["Save_Gold_Offset"] = 0x32;
			DefaultConfig.Offsets["Save_LoyalTreacherousValue_Offset"] = 0x7E;
			DefaultConfig.Offsets["Save_ItemEquipment_Offset"] = 0x7F;
			DefaultConfig.Offsets["Save_ItemAmount_Offset"] = 0x2D7;
			DefaultConfig.Offsets["Save_Unit_Offset"] = 0x14F0;

            DefaultConfig.Offsets["Star_Item_Count"] = 0x8e;
            DefaultConfig.Offsets["Star_Item_Offset"] = 0x00;
            DefaultConfig.Offsets["Three_SPC"] = 0x06;
            DefaultConfig.Offsets["Unit_Cha"] = 0xE2800;
            DefaultConfig.Offsets["Unit_Spc"] = 0xD2800;
            DefaultConfig.Offsets["Unit_Pmapobj"] = 0xE1000;
            DefaultConfig.Offsets["Imsg_Critical_Count"] = 0x14;
            DefaultConfig.Offsets["Exe_Critical_Offset"] = 0x89c30;

            DefaultConfig.Offsets["Exe_Force_AtkEffect"] = 0x6c81;
            DefaultConfig.Offsets["Exe_Force_MovSound"] = 0xa38c0;
            DefaultConfig.Offsets["Exe_Force_MovSpeed"] = 0xa38e8;
            DefaultConfig.Offsets["Exe_Force_AtkSound"] = 0xa3910;
            DefaultConfig.Offsets["Exe_Force_AtkType"] = 0xA3938;
            DefaultConfig.Offsets["Exe_Force_ForceType"] = 0xA3988;
            DefaultConfig.Offsets["Exe_Force_SprDmg"] = 0xA39B0;
            DefaultConfig.Offsets["Exe_Force_AtkDelay"] = 0xA39D8;
            DefaultConfig.Offsets["Exe_Force_AtkPinc"] = 0xA3960;
            DefaultConfig.Offsets["Exe_Force_SangSeong"] = 0xA3280;

            DefaultConfig.Offsets["Exe_Magic_Meff_Start"] = 0x0;
            DefaultConfig.Offsets["Exe_Magic_Meff_Offset"] = 0x858BE;
            DefaultConfig.Offsets["Exe_Magic_Meff_End"] = 0x49;
            DefaultConfig.Offsets["Exe_Magic_Mcall_Start"] = 0x3;
            DefaultConfig.Offsets["Exe_Magic_Mcall_Offset"] = 0x20BBE;
            DefaultConfig.Offsets["Exe_Magic_Mcall_End"] = 0x43;
            DefaultConfig.Offsets["Exe_Magic_MagicT_Start"] = 0x0;
            DefaultConfig.Offsets["Exe_Magic_MagicT_Offset"] = 0x24e53;
            DefaultConfig.Offsets["Exe_Magic_MagicT_End"] = 0x49;
            DefaultConfig.Offsets["Exe_Magic_DamgT_Start"] = 0x0;
            DefaultConfig.Offsets["Exe_Magic_DamgT_Offset"] = 0x48FC3;
            DefaultConfig.Offsets["Exe_Magic_DamgT_End"] = 0x49;
            DefaultConfig.Offsets["Exe_Magic_CureT_Start"] = 0x27;
            DefaultConfig.Offsets["Exe_Magic_CureT_Offset"] = 0x3BB14;
            DefaultConfig.Offsets["Exe_Magic_CureT_End"] = 0x42;
            DefaultConfig.Offsets["Exe_Magic_AI_Start"] = 0x0;
            DefaultConfig.Offsets["Exe_Magic_AI_Offset"] = 0x39580;
            DefaultConfig.Offsets["Exe_Magic_AI_End"] = 0x49;
            DefaultConfig.Offsets["Exe_Magic_Cond_Start"] = 0x0;
            DefaultConfig.Offsets["Exe_Magic_Cond_Offset"] = 0x1f47e;
            DefaultConfig.Offsets["Exe_Magic_Cond_End"] = 0x49;
            DefaultConfig.Offsets["Exe_Magic_Damg_Start"] = 0x0;
            DefaultConfig.Offsets["Exe_Magic_Damg_Offset"] = 0x3b720;
            DefaultConfig.Offsets["Exe_Magic_Damg_End"] = 0x49;
            DefaultConfig.Offsets["Exe_Magic_HitP_Start"] = 0x0;
            DefaultConfig.Offsets["Exe_Magic_HitP_Offset"] = 0x3ae10;
            DefaultConfig.Offsets["Exe_Magic_HitP_End"] = 0x49;
            DefaultConfig.Offsets["Exe_Magic_Learn_Start"] = 0x0;
            DefaultConfig.Offsets["Exe_Magic_Learn_Offset"] = 0x65208;
            DefaultConfig.Offsets["Exe_Magic_Learn_End"] = 0x49;


			DefaultConfig.ItemConfigs.Configs["WeaponsMin"] = 0;
			DefaultConfig.ItemConfigs.Configs["WeaponsMax"] = 13;
			DefaultConfig.ItemConfigs.Configs["ArmorMin"] = 14;
			DefaultConfig.ItemConfigs.Configs["ArmorMax"] = 17;
			DefaultConfig.ItemConfigs.Configs["AuxiliaryMin"] = 18;
			DefaultConfig.ItemConfigs.Configs["AuxiliaryMax"] = 107;
			DefaultConfig.ItemConfigs.Configs["ConsumablesMin"] = 63;
            DefaultConfig.ItemConfigs.Configs["ConsumablesMax"] = 76;
            DefaultConfig.ItemConfigs.Configs["AssMin"] = 77;
            DefaultConfig.ItemConfigs.Configs["AssMax"] = 78;
            DefaultConfig.ItemConfigs.Configs["AtkMine"] = 79;
            DefaultConfig.ItemConfigs.Configs["AtkBomb"] = 80;
			DefaultConfig.ItemConfigs.Effects = new Dictionary<int, string>
			                                    {
			                                    	{ 0x00, "보통검" }, { 0x01, "특수검" }, { 0x02, "보통창" }, { 0x03, "특수창" }, { 0x04, "보통활" }, { 0x05, "특수활" },
			                                    	{ 0x06, "보통곤봉" }, { 0x07, "특수곤봉" }, { 0x08, "보통포차" }, { 0x09, "특수포차" }, { 0x0A, "보통부채" }, { 0x0B, "특수부채" },
			                                    	{ 0x0C, "보통보검" }, { 0x0D, "특수보검" }, { 0x0E, "보통갑옷" }, { 0x0F, "특수갑옷" }, { 0x10, "보통의복" }, { 0x11, "특수의복" },
			                                    	{ 0x12, "8A9E8" }, { 0x13, "8A9F5" }, { 0x14, "8AA02" }, { 0x15, "8AA11" },	{ 0x16, "8AA1E" }, { 0x17, "8AA30" }, 
                                                    { 0x18, "8AA39" }, { 0x19, "8AA44" }, { 0x1A, "8AA4F" }, { 0x1B, "8AA5A" },	{ 0x1C, "8AA65" }, { 0x1D, "8AA6E" },
                                                    { 0x1E, "8AA75" }, { 0x1F, "8AA7C" }, { 0x20, "8AA88" }, { 0x21, "8AA93" },	{ 0x22, "8AA9C" }, { 0x23, "8AAA5" }, 
                                                    { 0x24, "8AAAE" }, { 0x25, "8AAB7" }, { 0x26, "8AAC0" }, { 0x27, "8AAC9" },
			                                    	{ 0x28, "8AAD6" }, { 0x29, "8AAE3" }, { 0x2A, "8AAF0" }, { 0x2B, "8AAF9" }, { 0x2C, "8AB02" }, { 0x2D, "8AB0D" },
			                                    	{ 0x2E, "8AB16" }, { 0x2F, "8AB1F" }, { 0x30, "8AB2C" }, { 0x31, "8AB39" }, { 0x32, "8AB40" }, { 0x33, "8AB49" },
			                                    	{ 0x34, "8AB52" }, { 0x35, "8AB5F" }, { 0x36, "8AB6C" }, { 0x37, "8AB79" }, { 0x38, "8AB84" }, { 0x39, "8AB91" },
			                                    	{ 0x3A, "8AB9E" }, { 0x3B, "8ABA7" }, { 0x3C, "8ABB4" }, { 0x3D, "8ABBF" }, { 0x3E, "8ABCC" }, { 0x51, "8ABD5" },
			                                    	{ 0x52, "8ABE2" }, { 0x53, "8ABEB" }, { 0x54, "8ABF4" }, { 0x55, "8ABFD" }, { 0x56, "8AC06" }, { 0x57, "8AC13" },
			                                    	{ 0x58, "8AC1C" }, { 0x59, "8AC25" }, { 0x5A, "8AC2E" }, { 0x5B, "8AC37" }, { 0x5C, "8AC40" }, { 0x5D, "D1C10" },
			                                    	{ 0x5E, "D1C19" }, { 0x5F, "D1C22" }, { 0x60, "D1C2B" }, { 0x61, "D1C34" }, { 0x62, "D1C3D" }, { 0x63, "D1C46" },
			                                    	{ 0x64, "D1C4F" }, { 0x65, "D1C58" }, { 0x66, "D1C61" }, { 0x67, "D1C6A" }, { 0x68, "D1C73" }, { 0x69, "D1C7C" },
			                                    	{ 0x6A, "D1C85" }, { 0x6B, "D1C8E" }, 
			                                    	{ 0x3F, "8ACC0" }, { 0x40, "8ACC7" }, { 0x41, "8ACCE" }, { 0x42, "8ACD7" }, { 0x43, "8ACE0" }, { 0x44, "8ACE9" },
			                                    	{ 0x45, "8ACF2" }, { 0x46, "8ACFB" }, { 0x47, "8AD04" }, { 0x48, "8AD0D" }, { 0x49, "8AD18" }, { 0x4A, "8AD21" },
			                                    	{ 0x4B, "8AD2A" }, { 0x4C, "8AD33" }, { 0x4D, "8AD3C" }, { 0x4E, "8AD45" }, { 0x4F, "8AD4E" }, { 0x50, "8AD4E" },
			                                    };
            DefaultConfig.Forces = new List<string>
			                       {
			                       	"D18D0", "D18D9", "D18E2", "D18EB", "D18F4", "D18FD", "D1906", "D190F", "D1918", "D1921", "D192A", "D1933",
			                       	"D193C", "D1945", "D194E", "D1957", "D1960", "D1969", "D1972", "D197B", "D1984", "D198D", "D1996", "D199F",
			                       	"D19A8", "D19B1", "D19BA", "D19C3", "D19CC", "D19D5", "D19DE", "D19E7", "D19F0", "D19F9", "D1A02", "D1A0B",
			                       	"D1A14", "D1A1D", "D1A26", "D1A2F", "D1A38", "D1A41", "D1A4A", "D1A53", "D1A5C", "D1A65", "D1A6E", "D1A77",
			                       	"D1A80", "D1A89", "D1A92", "D1A9B", "D1AA4", "D1AAD", "D1AB6", "D1ABF", "D1AC8", "D1AD1", "D1ADA", "D1AE3",
			                       	"D1AEC", "D1AF5", "D1AFE", "D1B07", "D1B10", "D1B19", "D1B22", "D1B2B", "D1B34", "D1B3D", "D1B46", "D1B4F",
			                       	"D1B58", "D1B61", "D1B6A", "D1B73", "D1B7C", "D1B85", "D1B8E", "D1B97"
			                       };
			DefaultConfig.ForceCategories = new List<string>
			                                {
			                                	"8B010", "8B019", "8B022", "8B02B", "8B034", "8B03D", "8B046", "8B04F", "8B058", "8B061", "8B06A", "8B073", "8B07C",
			                                	"8B085", "8B08E", "8B097", "8B0A0", "8B0A9", "8B0B2", "8B0BB", "8B0C4", "8B0CD", "8B0D6", "8B0DF", "8B0E8", "8B0F1",
                                                "8B0FA", "8B103", "8B10C", "8B115", "8B11E", "8B127", "8B130", "8B139", "8B142", "8B14B", "8B154", "8B15D", "8B166",
                                                "8B16F"
			                                };
			DefaultConfig.Hitareas = new List<string>
			                         {
			                         	"군웅 경기병등", "보병등", "궁병 노기병", "노병", "연노병", "폭염", "몰우전", "경포차",
			                         	"벽력차", "궁기병", "전체", "무공격", "대몰우전", "거대몰우전", "특수한형상비교",
			                         	"대방괴", "자객1", "자객2", "자객3", "대폭염", "방괴1", "방괴2",
			                         	"방괴3", "교차일격", "교차이격", "청정", "운하", "등궁", "노",
			                         	"참월", "사방죽궁", "남만궁", "12격"
			                         };
			DefaultConfig.Effareas = new List<string>
			                         {
			                         	"무", "십자", "구궁", "몰우전", "이격", "육격", "대몰우전", "삼격", "방괴"
			                         };
		}

		/// <summary>
		/// 设定当前的配置为指定配置
		/// </summary>
		/// <param name="typeName">指定的配置名</param>
		/// <returns>是否设置成功</returns>
		public static bool SetCurrentConfig(string typeName)
		{
			if (!Configs.ContainsKey(typeName) || Configs[typeName] == null)
			{
				var config = ReadConfigFromFile(typeName);
				if (config != null)
				{
					Configs.Add(typeName, config);
					Program.CurrentConfig = config;
					return true;
				}
				config = ReadConfigFromFile(DEFAULT_TYPE);
				if (config != null)
				{
					Configs.Add(typeName, config);
					Program.CurrentConfig = config;
					return false;
				}
				config = DefaultConfig.CloneConfig(DEFAULT_TYPE);
				Configs.Add(typeName, config);
				Program.CurrentConfig = config;
				config.WriteXml();
				SystemConfig.CurrentType = DEFAULT_TYPE;
				return false;
			}
			Program.CurrentConfig = Configs[typeName];
			SystemConfig.CurrentType = Program.CurrentConfig.TypeName;
			return true;
		}

		/// <summary>
		/// 将当前使用的配置信息替换为默认配置
		/// </summary>
		public static void SetCurrentConfigToDefault()
		{
			Program.CurrentConfig = DefaultConfig.CloneConfig(DEFAULT_TYPE);
			Program.CurrentConfig.WriteXml();
			SystemConfig.CurrentType = Program.CurrentConfig.TypeName;
		}

		/// <summary>
		/// 将默认配置文件写入程序目录
		/// </summary>
		public static void WriteDefaultConfig()
		{
			DefaultConfig.WriteXml();
		}

		/// <summary>
		/// 写入默认系统配置信息
		/// </summary>
		public static void WriteDefaultSystemConfig()
		{
			_systemConfig.CurrentType = DEFAULT_TYPE;
			_systemConfig.ForceCategoriesRestraintOffset = 0xCB000;
            _systemConfig.SpecialImageDesignatedOffset = 0xD2800;
            _systemConfig.RSpecialImageDesignatedOffset = 0xE1000;
		}
	}
}