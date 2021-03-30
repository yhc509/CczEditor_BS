#region using List

using System;
using System.IO;
using System.Windows.Forms;

using CczEditor.Config;

#endregion

namespace CczEditor.Controls.ExtensionsControls
{
	public partial class ForceCategoriesRestraint : BaseControl
	{
		private FileStream _fs;
		private int _dataLength;

		public ForceCategoriesRestraint()
		{
			InitializeComponent();
		}

		private void ForceCategoriesRestraint_Load(object sender, EventArgs e)
		{
			ncOffset.Value = ConfigOperation.SystemConfig.ForceCategoriesRestraintOffset;
			var forceCategoryNames = Program.CurrentConfig.ForceCategoryNames;
			_dataLength = forceCategoryNames.Count;
			lbList.Items.Clear();
			lbList.Items.AddRange(forceCategoryNames.ToArray());
			lvRestraint.Items.Clear();
			for (var i = 0; i < forceCategoryNames.Count; i++)
			{
				var item = new ListViewItem("0");
				item.SubItems.Add(forceCategoryNames[i]);
				lvRestraint.Items.Add(item);
			}
		}

		private void btnLoadFile_Click(object sender, EventArgs e)
		{
			var ofd = new OpenFileDialog
			          {
			          	Filter = "曹操传执行文件|*.exe"
			          };
			if (DialogResult.OK != ofd.ShowDialog() || string.IsNullOrEmpty(ofd.FileName) || !File.Exists(ofd.FileName))
			{
				_fs = null;
				txtFileName.Text = string.Empty;
				btnSave.Enabled = lbList.Enabled = lvRestraint.Enabled = false;
				lbList.SelectedIndex = -1;
				return;
			}
			txtFileName.Text = ofd.FileName;
			try
			{
				_fs = new FileStream(ofd.FileName, FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite);
				btnSave.Enabled = lbList.Enabled = lvRestraint.Enabled = true;
				lbList.SelectedIndex = 0;
				lbList_SelectedIndexChanged(lbList, new EventArgs());
				lbList.Focus();
			}
			catch (Exception ex)
			{
				_fs = null;
				txtFileName.Text = string.Empty;
				btnSave.Enabled = lbList.Enabled = lvRestraint.Enabled = false;
				lbList.SelectedIndex = -1;
				Utils.ShowError(ex.Message);
				return;
			}
		}

		private void lbList_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (_fs == null || lbList.SelectedIndex < 0 || lbList.SelectedIndex >= lbList.Items.Count)
			{
				return;
			}
			var data = new byte[_dataLength];
			_fs.Seek((int)ncOffset.Value+lbList.SelectedIndex*_dataLength, SeekOrigin.Begin);
			_fs.Read(data, 0, data.Length);
			for (var i = 0; i < data.Length; i++)
			{
				lvRestraint.Items[i].Text = data[i].ToString();
			}
		}

		private void btnSave_Click(object sender, EventArgs e)
		{
			if (_fs == null || lbList.SelectedIndex < 0 || lbList.SelectedIndex >= lbList.Items.Count)
			{
				return;
			}
			var data = new byte[_dataLength];
			for (var i = 0; i < data.Length; i++)
			{
				data[i] = byte.Parse(lvRestraint.Items[i].Text);
			}
			_fs.Seek((int)ncOffset.Value+lbList.SelectedIndex*_dataLength, SeekOrigin.Begin);
			_fs.Write(data, 0, data.Length);
		}

		private void lvRestraint_ItemActivate(object sender, EventArgs e)
		{
			if (lvRestraint.SelectedItems.Count > 0)
			{
				lvRestraint.SelectedItems[0].BeginEdit();
			}
		}

		private void lvRestraint_AfterLabelEdit(object sender, LabelEditEventArgs e)
		{
			int value;
			if (!int.TryParse(e.Label, out value))
			{
				e.CancelEdit = true;
			}
			else if (value < 0 || value > 255)
			{
				e.CancelEdit = true;
			}
		}

		private void btnSaveOffset_Click(object sender, EventArgs e)
		{
			ConfigOperation.SystemConfig.ForceCategoriesRestraintOffset = (int)ncOffset.Value;
		}

        private void lvRestraint_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
	}
}