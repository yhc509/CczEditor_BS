#region using List

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;

using CczEditor;
using CczEditor.Data;

#endregion

namespace CczEditor.Controls.ConfigControls
{
	public partial class ConfigEditor : BaseControl
	{
		public string ConfigFileName { get; set; }

		public ConfigEditor()
		{
			InitializeComponent();
		}

		private void ConfigEditor_Load(object sender, EventArgs e)
		{
			if (string.IsNullOrEmpty(ConfigFileName))
			{
				return;
			}
            var config = Config.Read(ConfigFileName);
			txtDataFileDirectory.Text = config.DirectoryPath;
            exename.Text = config.ExeFileName;

            ItemCustomRange.Checked = config.CodeOptionContainer.ItemCustomRange;
            AIExtension.Checked = config.CodeOptionContainer.AIExtension;
            MagicLearnExtension.Checked = config.CodeOptionContainer.MagicLearnExtension;
            SingularAttribute.Checked = config.CodeOptionContainer.SingularAttribute;
            SeperateE5.Checked = config.UseE5Directory;
            UseCost.Checked = config.CodeOptionContainer.UseCost;
            UseCutin.Checked = config.CodeOptionContainer.UseCutin;
            UseFaceLarge.Checked = config.CodeOptionContainer.UseLargeFace;
            UseVoice.Checked = config.CodeOptionContainer.UseVoice;
		}

		private void btnSave_Click(object sender, EventArgs e)
		{
			if (string.IsNullOrEmpty(ConfigFileName))
			{
				return;
            }
            var config = Config.Read(ConfigFileName);
            config.DirectoryPath = txtDataFileDirectory.Text;
            config.ExeFileName = exename.Text;
            config.CodeOptionContainer.ItemCustomRange = ItemCustomRange.Checked;
            config.CodeOptionContainer.AIExtension = AIExtension.Checked;
            config.CodeOptionContainer.MagicLearnExtension = MagicLearnExtension.Checked;
            config.CodeOptionContainer.SingularAttribute = SingularAttribute.Checked;
            config.UseE5Directory = SeperateE5.Checked;
            config.CodeOptionContainer.UseCost = UseCost.Checked;
            config.CodeOptionContainer.UseCutin = UseCutin.Checked;
            config.CodeOptionContainer.UseLargeFace = UseFaceLarge.Checked;
            config.CodeOptionContainer.UseVoice = UseVoice.Checked;

            Config.Write(config, ConfigFileName);
            Program.ReLoadData();
        }

		private void btnReLoad_Click(object sender, EventArgs e)
		{
			if (string.IsNullOrEmpty(ConfigFileName))
			{
				return;
            }
            var config = Config.Read(ConfigFileName);
			ConfigEditor_Load(this, new EventArgs());
			if (ConfigFileName == Program.CurrentConfig.FileName)
			{
				Program.ReLoadData();
			}
		}

		
		private void txtDataFileDirectory_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			var fbd = new FolderBrowserDialog
			          {
			          	ShowNewFolderButton = false,
			          	Description = "Data 파일을 선택해주십시오.",
			          	SelectedPath = txtDataFileDirectory.Text
			          };
			if (fbd.ShowDialog() == DialogResult.OK && !string.IsNullOrEmpty(fbd.SelectedPath) && Directory.Exists(fbd.SelectedPath))
			{
				txtDataFileDirectory.Text = fbd.SelectedPath;
			}
		}
	}
}