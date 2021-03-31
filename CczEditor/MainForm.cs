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
using CczEditor.Controls.ExtensionsControls;
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
			 //LoadFileList();
		}

		#endregion

		#region 주메뉴 이벤트

		#region 파일메뉴

		private void tsmiMainMenu_File_LoadFile_Data_Click(object sender, EventArgs e)
		{
			LoadFileDialog(1);
		}

		private void tsmiMainMenu_File_LoadFile_Imsg_Click(object sender, EventArgs e)
		{
			LoadFileDialog(2);
		}

		private void tsmiMainMenu_File_LoadFile_Save_Click(object sender, EventArgs e)
		{
			LoadFileDialog(3);
		}

		private void tsmiMainMenu_File_LoadFolder_Click(object sender, EventArgs e)
		{
			LoadFolderDialog();
		}

		private void tsmiMainMenu_File_LoadData_Click(object sender, EventArgs e)
		{
			LoadDataFile(Path.Combine(Program.CurrentConfig.DirectoryPath, Program.FILENAME_DATA));
		}

		private void tsmiMainMenu_File_LoadImsg_Click(object sender, EventArgs e)
		{
			LoadImsgFile(Path.Combine(Program.CurrentConfig.DirectoryPath, Program.FILENAME_IMSG));
		}

		private void tscbMainMenu_File_LoadSave_SelectedIndexChanged(object sender, EventArgs e)
		{
			LoadSaveFile(Path.Combine(Program.CurrentConfig.DirectoryPath, string.Format("{0}.e5s", ((ToolStripComboBox)sender).SelectedItem)));
		}

		private void tsmiMainMenu_File_ExitApplication_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}

		#endregion

		#region data메뉴

		private void tsmiMainMenu_Data_Units_Click(object sender, EventArgs e)
		{
			ShowEditor(new UnitsData());
		}

		private void tsmiMainMenu_Data_Items_Click(object sender, EventArgs e)
		{
			ShowEditor(new ItemsData());
		}

		private void tsmiMainMenu_Data_Store_Click(object sender, EventArgs e)
		{
			ShowEditor(new StoreData());
		}

		private void tsmiMainMenu_Data_Force_Click(object sender, EventArgs e)
		{
			ShowEditor(new ForceData());
		}

		private void tsmiMainMenu_Data_Terrain_Click(object sender, EventArgs e)
		{
			ShowEditor(new TerrainData());
		}

		private void tsmiMainMenu_Data_Magic_Click(object sender, EventArgs e)
		{
			ShowEditor(new MagicData());
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

		private void tsmiMainMenu_Imsg_Items_Click(object sender, EventArgs e)
		{
			ShowEditor(new ItemsImsg());
		}

		private void tsmiMainMenu_Imsg_Force_Click(object sender, EventArgs e)
		{
			ShowEditor(new ForceImsg());
		}

		private void tsmiMainMenu_Imsg_Retreat_Click(object sender, EventArgs e)
		{
			ShowEditor(new RetreatImsg());
		}

		private void tsmiMainMenu_Imsg_Critical_Click(object sender, EventArgs e)
		{
			ShowEditor(new CriticalImsg());
		}

		private void tsmiMainMenu_Imsg_Magic_Click(object sender, EventArgs e)
		{
			ShowEditor(new MagicImsg());
		}

		private void tsmiMainMenu_Imsg_Stage_Click(object sender, EventArgs e)
		{
			ShowEditor(new StageImsg());
		}

		private void tsmiMainMenu_Imsg_Staff_Click(object sender, EventArgs e)
		{
			ShowEditor(new StaffImsg());
		}

		#endregion

		#region save메뉴

		private void tsmiMainMenu_Save_Units_Click(object sender, EventArgs e)
		{
			ShowEditor(new UnitsSave());
		}

		private void tsmiMainMenu_Save_Items_Click(object sender, EventArgs e)
		{
			ShowEditor(new ItemsSave());
		}
        
        private void 변량편집VToolStripMenuItem_Click(object sender, EventArgs e)
        {
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
                SetControlsVisible(false, false, false);
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

        private void tsmiMainMenu_Config_CopyEditor_Click(object sender, EventArgs e)
        {/*
            var dialog = new CopyAndEditDialog
            {
                Owner = this,
                TypeName = Program.CurrentConfig.TypeName,
                TypeDisplayName = Program.CurrentConfig.DisplayName,
                TypeNames = TypeNames
            };
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                var config = Program.CurrentConfig.CloneConfig(dialog.TypeName);
                config.DisplayName = dialog.TypeDisplayName;
                ConfigOperation.Configs.Add(dialog.TypeName, config);
                TypeNames.Add(dialog.TypeName, dialog.TypeDisplayName);
                tscbMainMenu_Config_Selector.Items.Add(dialog.TypeDisplayName);
                var editor = new ConfigEditor
                {
                    TypeName = dialog.TypeName,
                    Location = new Point(0, 0),
                    Dock = DockStyle.Fill
                };
                pMainContainer.Controls.Clear();
                pMainContainer.Controls.Add(editor);
            }*/
        }

        private void tsmiMainMenu_Config_LoadAll_Click(object sender, EventArgs e)
        {
            //LoadConfigurationTypeNames();
            //ConfigOperation.Configs.Clear();
            //tscbMainMenu_Config_Selector_SelectedIndexChanged(tscbMainMenu_Config_Selector, new EventArgs());
        }

        private void tsmiMainMenu_Config_SaveAll_Click(object sender, EventArgs e)
        {/*
            if (TypeNames.Count <= 0)
            {
                return;
            }
            foreach (var typeName in TypeNames)
            {
                if (ConfigOperation.Configs.ContainsKey(typeName.Key))
                {
                    ConfigOperation.Configs[typeName.Key].WriteXml();
                }
            }*/
        }

        #endregion

		
		#region 프로그램정보 메뉴

		private void tsmiMainMenu_About_Click(object sender, EventArgs e)
		{
			(new AboutBox()).ShowDialog();
		}

		#endregion

		#endregion

		#region 정의

		public static Dictionary<string, string> ConfigList;

		#endregion

		#region 데이터 로드

		private void ShowEditor(Control control)
		{
			if (control != null)
			{
				control.Location = new Point(0, 0);
				control.Dock = DockStyle.Fill;
				pMainContainer.Controls.Clear();
                pMainContainer.Controls.Add(control);
			}
		}

		private void SetControlsVisible(bool game, bool imsg, bool save)
		{
			tsmiMainMenu_Data.Enabled = tsmiMainMenu_Data.Visible = game;
			tsmiMainMenu_Imsg.Enabled = tsmiMainMenu_Imsg.Visible = imsg;
			tsmiMainMenu_Save.Enabled = tsmiMainMenu_Save.Visible = save;
		}

		private void LoadFileDialog(int index)
		{
			var ofd = new OpenFileDialog
			          {
			          	Filter = index == 3 ? "조조전 Save 파일|Sv0?d.e5s" : "조조전 구성 파일|*.e5",
			          	InitialDirectory = Program.CurrentConfig.DirectoryPath
			          };
			if (DialogResult.OK == ofd.ShowDialog() && !string.IsNullOrEmpty(ofd.FileName) && File.Exists(ofd.FileName))
			{
				pMainContainer.Controls.Clear();
				Text = Program.TITLE_NAME_ORIGINAL;
				switch (index)
				{
					case 1:
					{
						LoadDataFile(ofd.FileName);
						break;
					}
					case 2:
					{
						LoadImsgFile(ofd.FileName);
						break;
					}
					case 3:
					{
						LoadSaveFile(ofd.FileName);
						break;
					}
					default:
						break;
				}
				GC.Collect();
			}
			else
			{
				SetControlsVisible(false, false, false);
				pMainContainer.Controls.Clear();
			}
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

		private void LoadDataFile(string fileName)
		{
			try
			{
				Program.GameData = new GameData(fileName);
				Program.ImsgData = null;
				//Program.SaveData = null;
			}
			catch (Exception ex)
			{
				Utils.ShowError(ex.Message);
				return;
			}
			SetControlsVisible(true, false, false);
			tsmiMainMenu_Data_Units_Click(tsmiMainMenu_Data_Units, new EventArgs());
		}

		private void LoadImsgFile(string fileName)
		{
			try
			{
				Program.GameData = null;
				Program.ImsgData = new ImsgData(fileName);
				//Program.SaveData = null;
			}
			catch (Exception ex)
			{
				Utils.ShowError(ex.Message);
				return;
			}
			SetControlsVisible(false, true, false);
			tsmiMainMenu_Imsg_Items_Click(tsmiMainMenu_Imsg_Items, new EventArgs());
		}

		private void LoadSaveFile(string fileName)
		{
			/*try
			{
				Program.GameData = null;
				Program.ImsgData = null;
				Program.SaveData = new SaveData(fileName);
			}
			catch (Exception ex)
			{
				Utils.ShowError(ex.Message);
				return;
			}
			SetControlsVisible(false, false, true);
			tsmiMainMenu_Save_Units_Click(tsmiMainMenu_Save_Units, new EventArgs());*/
		}

        private void LoadConfigurationTypeNames()
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
				tsmiMainMenu_File_LoadData.Enabled = tsmiMainMenu_File_LoadImsg.Enabled = tscbMainMenu_File_LoadSave.Enabled = false;
				return;
			}
			try
			{
				tsmiMainMenu_File_LoadData.Enabled = File.Exists(Path.Combine(Program.CurrentConfig.DirectoryPath, Program.FILENAME_DATA));
				tsmiMainMenu_File_LoadImsg.Enabled = File.Exists(Path.Combine(Program.CurrentConfig.DirectoryPath, Program.FILENAME_IMSG));
				var saves = Directory.GetFiles(Program.CurrentConfig.DirectoryPath, Program.FILENAME_SAVE, SearchOption.TopDirectoryOnly);
				tscbMainMenu_File_LoadSave.Items.Clear();
				if (saves.Length > 0)
				{
					tscbMainMenu_File_LoadSave.Enabled = true;
					var list = saves.ToList();
					list.Sort();
					foreach (var save in list)
					{
						tscbMainMenu_File_LoadSave.Items.Add(Path.GetFileNameWithoutExtension(save));
					}
				}
				else
				{
					tscbMainMenu_File_LoadSave.Enabled = false;
				}
			}
			catch (Exception ex)
			{
				Utils.ShowError(ex.Message);
				return;
			}
        }

        #endregion
    }
}