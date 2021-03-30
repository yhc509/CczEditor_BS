#region using List

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;

using CczEditor.Config;
using CczEditor.Data;

#endregion

namespace CczEditor.Controls.ConfigControls
{
	public partial class ConfigEditor : BaseControl
	{
		public string TypeName { get; set; }

		public ConfigEditor()
		{
			InitializeComponent();
		}

		private void ConfigEditor_Load(object sender, EventArgs e)
		{
			if (string.IsNullOrEmpty(TypeName) || !ConfigOperation.Configs.ContainsKey(TypeName))
			{
				return;
			}
			var config = ConfigOperation.Configs[TypeName];
			txtDataFileDirectory.Text = config.DataFileDirectory;
            exename.Text = config.Exename;

            ItemCustomRange.Checked = config.ItemCustomRange;
            Starusing.Checked = config.Starusing;
            ObjExtension.Checked = config.ObjExtension;
            SpcExtension.Checked = config.SpcExtension;
            AIExtension.Checked = config.AIExtension;
            MagicLearnExtension.Checked = config.MagicLearnExtension;
            SingularAttribute.Checked = config.SingularAttribute;		
		}

		private void btnSave_Click(object sender, EventArgs e)
		{
			if (string.IsNullOrEmpty(TypeName) || !ConfigOperation.Configs.ContainsKey(TypeName))
			{
				return;
			}
			var config = ConfigOperation.Configs[TypeName];
			config.DataFileDirectory = txtDataFileDirectory.Text;
            config.Exename = exename.Text;
            config.ItemCustomRange = ItemCustomRange.Checked;
            config.Starusing = Starusing.Checked;
            config.ObjExtension = ObjExtension.Checked;
            config.SpcExtension = SpcExtension.Checked;
            config.AIExtension = AIExtension.Checked;
            config.MagicLearnExtension = MagicLearnExtension.Checked;
            config.SingularAttribute = SingularAttribute.Checked;			
			config.WriteXml();
			if (TypeName == Program.CurrentConfig.TypeName)
			{
				Program.ReLoadData();
			}
		}

		private void btnReLoad_Click(object sender, EventArgs e)
		{
			if (string.IsNullOrEmpty(TypeName) || !ConfigOperation.Configs.ContainsKey(TypeName) || !ConfigInfo.ExistsFile(TypeName))
			{
				return;
			}
			ConfigOperation.Configs[TypeName].ReadXml();
			ConfigEditor_Load(this, new EventArgs());
			if (TypeName == Program.CurrentConfig.TypeName)
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