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
        static MainForm mainForm;
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

            mainForm = new MainForm();

            Application.Run(mainForm);
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
        
        public static string TitleNameCurrent = "CczEditor 4.1.0";

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

        public static GameData GameData {
            get
            {
                return DataContainer.GetGameData(CurrentConfig.DirectoryPath);
            }
        }

        public static StarData StarData
        {
            get
            {
                return DataContainer.GetStarData(CurrentConfig.DirectoryPath);
            }
        }

        public static ImsgData ImsgData
        {
            get
            {
                return DataContainer.GetImsgData(CurrentConfig.DirectoryPath);
            }
        }

        public static ExeData ExeData
        {
            get
            {
                return DataContainer.GetExeData(CurrentConfig.DirectoryPath);
            }
        }

        public static void ReloadData()
        {
            var path = CurrentConfig.DirectoryPath;

            mainForm.Reset();

            var exeData = DataContainer.LoadExeData(path);
            var gameData = DataContainer.LoadGameData(path);
            var starData = DataContainer.LoadStarData(path);
            var imsgData = DataContainer.LoadImsgData(path);
            DataContainer.Initialize(gameData, starData, imsgData, exeData, CurrentConfig);
        }
    }
}