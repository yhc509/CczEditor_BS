#region using List

using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

using CczEditor;
using CczEditor.Controls;
using CczEditor.Controls.ConfigControls;
using CczEditor.Controls.DataControls;
using CczEditor.Controls.ImsgControls;
using CczEditor.Controls.SaveControls;
using CczEditor.Data;

#endregion

namespace CczEditor
{
	public partial class MainForm : Form
	{
		#region 윈도우창 초기화

		public MainForm()
		{
			InitializeComponent();
		}
		private void MainForm_Load(object sender, EventArgs e)
		{
             LoadConfigurationTypeNames();
		}

        #endregion

        UnitController UnitController;
        ItemController ItemController;
        ShopController ShopController;
        ForceController ForceController;
        TerrainController TerrainController;
        MagicController MagicController;
        SpecialDataController SpecialDataController;
        ProjectController ProjectController;
        ConfigPreset ConfigPreset;
        CodeApplierControl CodeApplierControl;

        #region 주메뉴 이벤트

        #region 파일메뉴

        private void tsmiMainMenu_File_LoadFolder_Click(object sender, EventArgs e)
		{
			LoadFolderDialog();
		}

		private void tsmiMainMenu_File_LoadData_Click(object sender, EventArgs e)
		{
			LoadDataFile();
		}
        
		private void tsmiMainMenu_File_ExitApplication_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}

		#endregion

		#region data메뉴

		private void tsmiMainMenu_Data_Units_Click(object sender, EventArgs e)
        {
            if (UnitController == null)
                UnitController = new UnitController();
            ShowEditor(UnitController);
		}

		private void tsmiMainMenu_Data_Items_Click(object sender, EventArgs e)
        {
            if (ItemController == null)
                ItemController = new ItemController();
            ShowEditor(ItemController);
        }

		private void tsmiMainMenu_Data_Store_Click(object sender, EventArgs e)
        {
            if (ShopController == null)
                ShopController = new ShopController();
            ShowEditor(ShopController);
        }

		private void tsmiMainMenu_Data_Force_Click(object sender, EventArgs e)
        {
            if (ForceController == null)
                ForceController = new ForceController();
            ShowEditor(ForceController);
        }

		private void tsmiMainMenu_Data_Terrain_Click(object sender, EventArgs e)
        {
            if (TerrainController == null)
                TerrainController = new TerrainController();
            ShowEditor(TerrainController);
        }

		private void tsmiMainMenu_Data_Magic_Click(object sender, EventArgs e)
        {
            if (MagicController == null)
                MagicController = new MagicController();
            ShowEditor(MagicController);
        }


		#endregion

		#region imsg메뉴

		private void tsmiMainMenu_Imsg_Units_Original_Click(object sender, EventArgs e)
		{
			ShowEditor(new UnitsOriginalImsg());
		}

		private void tsmiMainMenu_Imsg_Units_Extension_Click(object sender, EventArgs e)
		{
			ShowEditor(new UnitsExtensionImsg());
		}
        
		private void tsmiMainMenu_Imsg_Retreat_Click(object sender, EventArgs e)
		{
			ShowEditor(new RetreatImsg());
		}

		private void tsmiMainMenu_Imsg_Critical_Click(object sender, EventArgs e)
		{
			ShowEditor(new CriticalImsg());
		}
        
		private void tsmiMainMenu_Imsg_Staff_Click(object sender, EventArgs e)
		{
			ShowEditor(new StaffImsg());
		}

		#endregion
        

        #region 설정메뉴

        private void tscbMainMenu_Config_Selector_SelectedIndexChanged(object sender, EventArgs e)
        {
            var control = (ToolStripComboBox)sender;
            var configFileName = ConfigList.Keys.ToList()[control.SelectedIndex];

            if(File.Exists(configFileName))
            {
                var config = Config.Read(configFileName);
                SystemConfig.Inst.CurrentConfig = configFileName;
                SystemConfig.Write(SystemConfig.DefaultSystemConfigFileName);
                Program.CurrentConfig = config;
                SetControlsVisible(false);
                pMainContainer.Controls.Clear();
                Text = Program.TitleNameCurrent = string.Format("{0} - {1}", Program.TITLE_NAME_ORIGINAL, Program.CurrentConfig.DisplayName);
                LoadFileList();
                tsmiMainMenu_Config_Editor.Enabled = control.SelectedIndex != -1;
            }
            else
            {
                ConfigList.Remove(configFileName);
                control.Items.RemoveAt(control.SelectedIndex);
                if (control.Items.Count > 0)
                {
                    control.SelectedIndex = 0;
                }
            }
        }

        private void tsmiMainMenu_Config_Editor_Click(object sender, EventArgs e)
        {
            var editor = new ConfigEditor
            {
                ConfigFileName = SystemConfig.Inst.CurrentConfig,
                Location = new Point(0, 0),
                Dock = DockStyle.Fill
            };
            pMainContainer.Controls.Clear();
            pMainContainer.Controls.Add(editor);
        }
        
        #endregion

		
		#region 프로그램정보 메뉴

		private void tsmiMainMenu_About_Click(object sender, EventArgs e)
		{
			(new AboutBox()).ShowDialog();
		}

		#endregion

		#endregion
        
		public static Dictionary<string, string> ConfigList;
        
		#region 데이터 로드

		private void ShowEditor(BaseControl control)
		{
			if (control != null)
			{
				control.Location = new Point(0, 0);
				control.Dock = DockStyle.Fill;
				pMainContainer.Controls.Clear();
                pMainContainer.Controls.Add(control);
                control.Reset();
			}
		}

		private void SetControlsVisible(bool isShow)
		{
			tsmiMainMenu_Data.Enabled = tsmiMainMenu_Data.Visible =
			tsmiMainMenu_Imsg.Enabled = tsmiMainMenu_Imsg.Visible = isShow;

            tsmiMainMenu_File_LoadData.Enabled = !isShow;
            ProjectClose.Enabled = isShow;
            PresetSetting.Enabled = !isShow;
		}
        
		private void LoadFolderDialog()
		{
			var fbd = new FolderBrowserDialog
			          {
			          	SelectedPath = Program.CurrentConfig.DirectoryPath,
			          	Description = "경로를 설정해주세요!"
			          };
			if (DialogResult.OK != fbd.ShowDialog() || string.IsNullOrEmpty(fbd.SelectedPath) || !Directory.Exists(fbd.SelectedPath))
			{
				return;
			}
			Program.CurrentConfig.DirectoryPath = fbd.SelectedPath;
            Config.Write(Program.CurrentConfig, Program.CurrentConfig.FileName);
			LoadFileList();
		}

		private void LoadDataFile()
        {
            string path = Program.CurrentConfig.DirectoryPath;

            var exeData = DataContainer.LoadExeData(path);
            var gameData = DataContainer.LoadGameData(path);
            var starData = DataContainer.LoadStarData(path);
            var imsgData = DataContainer.LoadImsgData(path);

            DataContainer.Initialize(gameData, starData, imsgData, exeData, Program.CurrentConfig);
            SetControlsVisible(true);
			tsmiMainMenu_Data_Units_Click(tsmiMainMenu_Data_Units, new EventArgs());
		}

        public void LoadConfigurationTypeNames()
        {
            tscbMainMenu_Config_Selector.Items.Clear();
            ConfigList = ConfigManager.GetConfigs();
            tscbMainMenu_Config_Selector.Items.AddRange(ConfigList.Values.ToArray());
            tscbMainMenu_Config_Selector.Width += 50;
            var index = ConfigList.Keys.ToList().IndexOf(SystemConfig.Inst.CurrentConfig);
            index = index == -1 ? 0 : index;
            tscbMainMenu_Config_Selector.SelectedIndex = index;
        }

		private void LoadFileList()
		{
            
			if (Program.CurrentConfig == null || string.IsNullOrEmpty(Program.CurrentConfig.DirectoryPath) || !Directory.Exists(Program.CurrentConfig.DirectoryPath))
			{
				tsmiMainMenu_File_LoadData.Enabled = false;
				return;
			}
			try
			{
				tsmiMainMenu_File_LoadData.Enabled = File.Exists(Path.Combine(Program.CurrentConfig.DirectoryPath, Program.FILENAME_DATA));
			}
			catch (Exception ex)
			{
				Utils.ShowError(ex.Message);
				return;
			}
        }

        #endregion
        
        private void ExeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (SpecialDataController == null)
                SpecialDataController = new SpecialDataController();
            ShowEditor(SpecialDataController);
        }

        private void 프로젝트편집ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ProjectController == null)
                ProjectController = new ProjectController();
            ShowEditor(ProjectController);
        }

        private void 테스트용ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ConfigPreset == null)
                ConfigPreset = new ConfigPreset();
            ShowEditor(ConfigPreset);
        }

        private void 코드입력기ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (CodeApplierControl == null)
                CodeApplierControl = new CodeApplierControl();
            ShowEditor(CodeApplierControl);

        }

        private void 프로젝트닫기ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetControlsVisible(false);
            pMainContainer.Controls.Clear();

            var path = Program.CurrentConfig.DirectoryPath;

            DataContainer.UnloadGameData(path);
            DataContainer.UnloadStarData(path);
            DataContainer.UnloadImsgData(path);
            DataContainer.UnloadExeData(path);
        }
    }
}