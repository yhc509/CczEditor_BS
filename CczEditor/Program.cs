#region using List

using System;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Xml;

using CczEditor;
using CczEditor.Data;

#endregion
using CczEditor;

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
        
        public static string TitleNameCurrent = "CczEditor 4.0.0";

		#region 常数定义

		/// <summary>
		/// 程序窗口原始标题
		/// </summary>
		public const string TITLE_NAME_ORIGINAL = "조조전 - Data 편집";

		#region 데이터상수

		/// <summary>
		/// Data-인물 길이
		/// </summary>
		public const int GAME_UNIT_LENGTH = 0x20;

		/// <summary>
		/// Data-아이템 길이
		/// </summary>
		public const int GAME_ITEM_LENGTH = 0x19;

		/// <summary>
		/// Data-상점 길이
		/// </summary>
		public const int GAME_STORE_LENGTH = 0x24;

		/// <summary>
		/// Data-병종길이
		/// </summary>
		public const int GAME_FORCE_LENGTH = 0x1B;

		/// <summary>
		/// Data-지형길이
		/// </summary>
		public const int GAME_TERRAIN_LENGTH = 0x3C;

		/// <summary>
		/// Data-책략길이
		/// </summary>
		public const int GAME_MAGIC_LENGTH = 0x46;

		/// <summary>
		/// imsg-설명길이
		/// </summary>
		public const int IMSG_DATA_BLOCK_LENGTH = 0xC8;

		/// <summary>
		/// imsg-전투이름길이
		/// </summary>
		public const int IMSG_STAGE_NAME_LENGTH = 0x12;

		/// <summary>
		/// imsg-원판열전갯수
		/// </summary>
		public const int IMSG_UNITORIGINAL_COUNT = 174;

		/// <summary>
		/// imsg-퇴각대사갯수
		/// </summary>
		public const int IMSG_RETREAT_COUNT = 49;

		/// <summary>
		/// imsg-회심대사갯수
		/// </summary>
		public const int IMSG_CRITICAL_COUNT = 99;

		/// <summary>
		/// imsg-제작인물갯수
		/// </summary>
		public const int IMSG_STAFF_COUNT = 121;

		/// <summary>
		/// save-인물길이
		/// </summary>
		public const int SAVE_UNIT_LENGTH = 0x25;

		/// <summary>
		/// save-창고갯수
		/// </summary>
		public const int SAVE_ITEM_EQUIPMENT_COUNT = 200;

		/// <summary>
		/// save-소모품갯수
		/// </summary>
		public const int SAVE_ITEM_AMOUNT_COUNT = 17;

		#endregion

		#region 파일명기본값

        /// <summary>
        /// exe파일
        /// </summary>
        public const string FILENAME_EXE = "Ekd5.exe";

		/// <summary>
		/// data파일
		/// </summary>
		public const string FILENAME_DATA = "Data.e5";

        /// <summary>
        /// Star파일
        /// </summary>
        public const string FILENAME_STAR = "Star.e5";

		/// <summary>
		/// imsg파일
		/// </summary>
		public const string FILENAME_IMSG = "Imsg.e5";

		/// <summary>
		/// save파일
		/// </summary>
		public const string FILENAME_SAVE = "sv0?d.e5s";

        /// <summary>
        /// save파일b
        /// </summary>
        public const string FILENAME_SAVEB = "sv0?b.e5s";

        /// <summary>
        /// save파일e
        /// </summary>
        public const string FILENAME_SAVEE = "sv0?e.e5s";

        /// <summary>
        /// save파일s
        /// </summary>
        public const string FILENAME_SAVES = "sv0?s.e5s";

		/// <summary>
		/// item파일
		/// </summary>
		public const string FILENAME_ITEM = "Item.e5";

		/// <summary>
		/// face파일
		/// </summary>
		public const string FILENAME_FACE = "Face.e5";

        /// <summary>
        /// faceLarge파일
        /// </summary>
        public const string FILENAME_FACE_LARGE = "Face_L.e5";

        /// <summary>
        /// pmapobj파일
        /// </summary>
        public const string FILENAME_PMAPOBJ = "Pmapobj.e5";

		/// <summary>
		/// hitarea파일
		/// </summary>
		public const string FILENAME_HITAREA = "Hitarea.e5";

		/// <summary>
		/// effarea파일
		/// </summary>
		public const string FILENAME_EFFAREA = "Effarea.e5";

		/// <summary>
		/// unit-atk파일
		/// </summary>
		public const string FILENAME_IMAGEATK = "Unit_atk.e5";

		/// <summary>
		/// unit-mov파일
		/// </summary>
		public const string FILENAME_IMAGEMOV = "Unit_mov.e5";

		/// <summary>
		/// unit-spc파일
		/// </summary>
		public const string FILENAME_IMAGESPC = "Unit_spc.e5";

		/// <summary>
		/// mgcicon.dll
		/// </summary>
		public const string FILENAME_MAGICICON = "Mgcicon.dll";

		#endregion

		#region 문자열포맷

		/// <summary>
		/// 십진법2
		/// </summary>
		public const string FORMATSTRING_KEYVALUEPAIR_DEC2 = "{0:D2},{1}";

		/// <summary>
		/// 십진법3
		/// </summary>
		public const string FORMATSTRING_KEYVALUEPAIR_DEC3 = "{0:D3},{1}";

		/// <summary>
		/// 십진법4
		/// </summary>
		public const string FORMATSTRING_KEYVALUEPAIR_DEC4 = "{0:D4},{1}";

		/// <summary>
		/// 십육진법2
		/// </summary>
		public const string FORMATSTRING_KEYVALUEPAIR_HEX2 = "{0:X2},{1}";

		/// <summary>
		/// 십육진법3
		/// </summary>
		public const string FORMATSTRING_KEYVALUEPAIR_HEX3 = "{0:X3},{1}";

		/// <summary>
		/// 십육진법4
		/// </summary>
		public const string FORMATSTRING_KEYVALUEPAIR_HEX4 = "{0:X4},{1}";

		/// <summary>
		/// 보존사용
		/// </summary>
		public const string FORMATSTRING_SAVEEQUIPMENT = "{0:X2}:[{1}]";

		#endregion

		#endregion
                
		public static GameData GameData;
        public static StarData StarData;
        
		public static ImsgData ImsgData;
        
        /*
        public static SaveData SaveData;
        public static SavebData SavebData;*/
        
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
			/*if (SaveData != null && SaveData.CurrentFile != null && !string.IsNullOrEmpty(SaveData.CurrentFile.FullName) && SaveData.CurrentFile.Exists)
			{
				SaveData = new SaveData(SaveData.CurrentFile.FullName);
			}*/
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
					/*if (SaveData != null && SaveData.CurrentFile != null && SaveData.CurrentFile.Exists && SaveData.CurrentFile.DirectoryName != null)
					{
						GameData = new GameData(Path.Combine(SaveData.CurrentFile.DirectoryName, FILENAME_DATA));
						return;
					}*/
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
					/*if (SaveData != null && SaveData.CurrentFile != null && SaveData.CurrentFile.Exists && SaveData.CurrentFile.DirectoryName != null && GameData.CurrentFile.DirectoryName != SaveData.CurrentFile.DirectoryName)
					{
						GameData = new GameData(Path.Combine(SaveData.CurrentFile.DirectoryName, FILENAME_DATA));
					}*/
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
                        /*if (SaveData != null && SaveData.CurrentFile != null && SaveData.CurrentFile.Exists && SaveData.CurrentFile.DirectoryName != null)
                        {
                            StarData = new StarData(Path.Combine(SaveData.CurrentFile.DirectoryName, FILENAME_STAR));
                            return;
                        }*/
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
                        /*if (SaveData != null && SaveData.CurrentFile != null && SaveData.CurrentFile.Exists && SaveData.CurrentFile.DirectoryName != null && StarData.CurrentFile.DirectoryName != SaveData.CurrentFile.DirectoryName)
                        {
                            StarData = new StarData(Path.Combine(SaveData.CurrentFile.DirectoryName, FILENAME_STAR));
                        }*/
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
					/*if (SaveData != null && SaveData.CurrentFile != null && SaveData.CurrentFile.Exists && SaveData.CurrentFile.DirectoryName != null)
					{
						ImsgData = new ImsgData(Path.Combine(SaveData.CurrentFile.DirectoryName, FILENAME_IMSG));
						return;
					}*/
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
					/*if (SaveData != null && SaveData.CurrentFile != null && SaveData.CurrentFile.Exists && SaveData.CurrentFile.DirectoryName != null && ImsgData.CurrentFile.DirectoryName != SaveData.CurrentFile.DirectoryName)
					{
						ImsgData = new ImsgData(Path.Combine(SaveData.CurrentFile.DirectoryName, FILENAME_IMSG));
						return;
					}*/
				}
			}
			catch (Exception)
			{
				ImsgData = null;
				return;
			}
		}
        public static void LoadSavebData()
        {
            /*
            try
            {
                if (SavebData == null || SavebData.CurrentStream == null)
                {
                    if (ImsgData != null && ImsgData.CurrentFile != null && ImsgData.CurrentFile.Exists && ImsgData.CurrentFile.DirectoryName != null)
                    {
                        SavebData = new SavebData(Path.Combine(SavebData.CurrentFile.DirectoryName, FILENAME_SAVEB));
                        return;
                    }
                    if (SaveData != null && SaveData.CurrentFile != null && SaveData.CurrentFile.Exists && SaveData.CurrentFile.DirectoryName != null)
                    {
                        SavebData = new SavebData(Path.Combine(SavebData.CurrentFile.DirectoryName, Program.CurrentConfig.ExeFileName));
                        return;
                    }
                    if (CurrentConfig != null && !string.IsNullOrEmpty(CurrentConfig.DirectoryPath) && Directory.Exists(CurrentConfig.DirectoryPath))
                    {
                        SavebData = new SavebData(Path.Combine(CurrentConfig.DirectoryPath, Program.CurrentConfig.ExeFileName));
                        return;
                    }
                }
                else
                {
                    if (ImsgData != null && ImsgData.CurrentFile != null && ImsgData.CurrentFile.Exists && ImsgData.CurrentFile.DirectoryName != null && StarData.CurrentFile.DirectoryName != ImsgData.CurrentFile.DirectoryName)
                    {
                        ExeData = new ExeData(Path.Combine(ImsgData.CurrentFile.DirectoryName, Program.CurrentConfig.ExeFileName));
                    }
                    if (SaveData != null && SaveData.CurrentFile != null && SaveData.CurrentFile.Exists && SaveData.CurrentFile.DirectoryName != null && StarData.CurrentFile.DirectoryName != SaveData.CurrentFile.DirectoryName)
                    {
                        ExeData = new ExeData(Path.Combine(SaveData.CurrentFile.DirectoryName, Program.CurrentConfig.ExeFileName));
                    }
                }
            }
            catch (Exception)
            {
                StarData = null;
                return;
            }*/
        }
	}
}