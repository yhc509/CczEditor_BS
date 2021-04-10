using System;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Xml;

using CczEditor;
using CczEditor.Data;

namespace CczEditor
{
	internal static class Program
	{
		[STAThread]
		private static void Main()
		{
			Application.ThreadException += Application_ThreadException;
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);

			try
			{

                string systemConfigFileName = SystemConfig.DefaultSystemConfigFileName;
                SystemConfig.Read(systemConfigFileName);

                if (string.IsNullOrEmpty(SystemConfig.Inst.CurrentConfig) ||
                    !File.Exists(SystemConfig.Inst.CurrentConfig))
                {
                    var config = SystemConfig.CreateDefaultConfig();
                    Config.Write(config, SystemConfig.DefaultConfigName);
                    CurrentConfig = config;
                }
                else
                {
                    var config = Config.Read(SystemConfig.Inst.CurrentConfig);
                    CurrentConfig = config;
                }
			}
			catch (Exception ex)
			{
				Utils.ShowError(ex.Message);
			}

			Application.Run(new MainForm());
		}
        
		private static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
		{
			Utils.ShowError(e.Exception.Message);
		}
        
		public static Config CurrentConfig { get; set; }
        
		public static readonly Encoding EncoderS = Encoding.GetEncoding("euc-kr");
        
		public static readonly Encoding EncoderT = Encoding.GetEncoding("euc-kr");
        
		public static Encoding Encoder
		{
            get { return EncoderS; }
		}
        
        public static string TitleNameCurrent = "CczEditor 4.0.2";

		#region
        
		public const string TITLE_NAME_ORIGINAL = "조조전 - Data 편집";

		#region 데이터상수
        
		public const int GAME_UNIT_LENGTH = 0x20;
        
		public const int GAME_ITEM_LENGTH = 0x19;
        
		public const int GAME_STORE_LENGTH = 0x24;
        
		public const int GAME_FORCE_LENGTH = 0x1B;
        
		public const int GAME_TERRAIN_LENGTH = 0x3C;
        
		public const int GAME_MAGIC_LENGTH = 0x46;
        
		public const int IMSG_DATA_BLOCK_LENGTH = 0xC8;
        
		public const int IMSG_STAGE_NAME_LENGTH = 0x12;
        
		public const int IMSG_UNITORIGINAL_COUNT = 174;
        
		public const int IMSG_RETREAT_COUNT = 49;
        
		public const int IMSG_CRITICAL_COUNT = 99;
        
		public const int IMSG_STAFF_COUNT = 121;
        
		public const int SAVE_UNIT_LENGTH = 0x25;
        
		public const int SAVE_ITEM_EQUIPMENT_COUNT = 200;
        
		public const int SAVE_ITEM_AMOUNT_COUNT = 17;

		#endregion

		#region 파일명기본값
        
        public const string FILENAME_EXE = "Ekd5.exe";
        
		public const string FILENAME_DATA = "Data.e5";
        
        public const string FILENAME_STAR = "Star.e5";
        
		public const string FILENAME_IMSG = "Imsg.e5";
        
		public const string FILENAME_SAVE = "sv0?d.e5s";
        
        public const string FILENAME_SAVEB = "sv0?b.e5s";
        
        public const string FILENAME_SAVEE = "sv0?e.e5s";
        
        public const string FILENAME_SAVES = "sv0?s.e5s";
        
		public const string FILENAME_ITEM = "Item.e5";
        
		public const string FILENAME_FACE = "Face.e5";
        
        public const string FILENAME_FACE_LARGE = "Face_L.e5";
        
        public const string FILENAME_PMAPOBJ = "Pmapobj.e5";
        
		public const string FILENAME_HITAREA = "Hitarea.e5";
        
		public const string FILENAME_EFFAREA = "Effarea.e5";
        
		public const string FILENAME_IMAGEATK = "Unit_atk.e5";
        
		public const string FILENAME_IMAGEMOV = "Unit_mov.e5";
        
		public const string FILENAME_IMAGESPC = "Unit_spc.e5";
        
		public const string FILENAME_MAGICICON = "Mgcicon.dll";

		#endregion

		#region 문자열포맷
        
		public const string FORMATSTRING_KEYVALUEPAIR_DEC2 = "{0:D2},{1}";
        
		public const string FORMATSTRING_KEYVALUEPAIR_DEC3 = "{0:D3},{1}";
        
		public const string FORMATSTRING_KEYVALUEPAIR_DEC4 = "{0:D4},{1}";
        
		public const string FORMATSTRING_KEYVALUEPAIR_HEX2 = "{0:X2},{1}";
        
		public const string FORMATSTRING_KEYVALUEPAIR_HEX3 = "{0:X3},{1}";
        
		public const string FORMATSTRING_KEYVALUEPAIR_HEX4 = "{0:X4},{1}";
        
		public const string FORMATSTRING_SAVEEQUIPMENT = "{0:X2}:[{1}]";

		#endregion

		#endregion
                
		public static GameData GameData;
        public static StarData StarData;
        
		public static ImsgData ImsgData;
        
        
		public static void ReLoadData()
		{
			if (GameData != null && GameData.CurrentFile != null && !string.IsNullOrEmpty(GameData.CurrentFile.FullName) && GameData.CurrentFile.Exists)
			{
				GameData = new GameData(GameData.CurrentFile.FullName);
			}
			if (ImsgData != null && ImsgData.CurrentFile != null && !string.IsNullOrEmpty(ImsgData.CurrentFile.FullName) && ImsgData.CurrentFile.Exists)
			{
				ImsgData = new ImsgData(ImsgData.CurrentFile.FullName);
			}
            if (StarData != null && StarData.CurrentFile != null && !string.IsNullOrEmpty(StarData.CurrentFile.FullName) && StarData.CurrentFile.Exists)
            {
                StarData = new StarData(StarData.CurrentFile.FullName);
            }
		}

		public static void LoadGameData()
		{
			try
			{
				if (GameData == null || GameData.CurrentStream == null)
				{
					if (ImsgData != null && ImsgData.CurrentFile != null && ImsgData.CurrentFile.Exists && ImsgData.CurrentFile.DirectoryName != null)
					{
						GameData = new GameData(Path.Combine(ImsgData.CurrentFile.DirectoryName, FILENAME_DATA));
						return;
					}
					if (CurrentConfig != null && !string.IsNullOrEmpty(CurrentConfig.DirectoryPath) && Directory.Exists(CurrentConfig.DirectoryPath))
					{
						GameData = new GameData(Path.Combine(CurrentConfig.DirectoryPath, FILENAME_DATA));
						return;
					}
				}
				else
				{
					if (ImsgData != null && ImsgData.CurrentFile != null && ImsgData.CurrentFile.Exists && ImsgData.CurrentFile.DirectoryName != null && GameData.CurrentFile.DirectoryName != ImsgData.CurrentFile.DirectoryName)
					{
						GameData = new GameData(Path.Combine(ImsgData.CurrentFile.DirectoryName, FILENAME_DATA));
					}
				}
			}
			catch (Exception)
			{
				GameData = null;
				return;
			}
		}

        public static void LoadStarData()
        {
                try
                {
                    if (StarData == null || StarData.CurrentStream == null)
                    {
                        if (ImsgData != null && ImsgData.CurrentFile != null && ImsgData.CurrentFile.Exists && ImsgData.CurrentFile.DirectoryName != null)
                        {
                            StarData = new StarData(Path.Combine(ImsgData.CurrentFile.DirectoryName, FILENAME_STAR));
                            return;
                        }
                        if (CurrentConfig != null && !string.IsNullOrEmpty(CurrentConfig.DirectoryPath) && Directory.Exists(CurrentConfig.DirectoryPath))
                        {
                            StarData = new StarData(Path.Combine(CurrentConfig.DirectoryPath, FILENAME_STAR));
                            return;
                        }
                    }
                    else
                    {
                        if (ImsgData != null && ImsgData.CurrentFile != null && ImsgData.CurrentFile.Exists && ImsgData.CurrentFile.DirectoryName != null && StarData.CurrentFile.DirectoryName != ImsgData.CurrentFile.DirectoryName)
                        {
                            StarData = new StarData(Path.Combine(ImsgData.CurrentFile.DirectoryName, FILENAME_STAR));
                        }
                    }
                }
                catch (Exception)
                {
                    StarData = null;
                    return;
                }
        }
        
		public static void LoadImsgData()
		{
			try
			{
				if (ImsgData == null || ImsgData.CurrentStream == null)
				{
					if (GameData != null && GameData.CurrentFile != null && GameData.CurrentFile.Exists && GameData.CurrentFile.DirectoryName != null)
					{
						ImsgData = new ImsgData(Path.Combine(GameData.CurrentFile.DirectoryName, FILENAME_IMSG));
						return;
					}
					if (CurrentConfig != null && !string.IsNullOrEmpty(CurrentConfig.DirectoryPath) && Directory.Exists(CurrentConfig.DirectoryPath))
					{
						ImsgData = new ImsgData(Path.Combine(CurrentConfig.DirectoryPath, FILENAME_IMSG));
						return;
					}
				}
				else
				{
					if (GameData != null && GameData.CurrentFile != null && GameData.CurrentFile.Exists && GameData.CurrentFile.DirectoryName != null && ImsgData.CurrentFile.DirectoryName != GameData.CurrentFile.DirectoryName)
					{
						ImsgData = new ImsgData(Path.Combine(GameData.CurrentFile.DirectoryName, FILENAME_IMSG));
						return;
					}
				}
			}
			catch (Exception)
			{
				ImsgData = null;
				return;
			}
		}
	}
}