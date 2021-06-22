#region using List

using System;

#endregion

namespace CczEditor.Controls.ImsgControls
{
	public partial class UnitsOriginalImsg : BaseImsgControl
	{
		public UnitsOriginalImsg()
		{
            InitializeComponent();
            comboBox1.Visible = false;
			lblTitle.Text = "장수 열전：";
			lbList.SelectedIndexChanged += lbList_SelectedIndexChanged;
			btnSave.Click += btnSave_Click;
			btnRestore.Click += btnRestore_Click;
		}

		private void UnitsOriginalImsg_Load(object sender, EventArgs e)
		{
			var list = new string[Program.IMSG_UNITORIGINAL_COUNT];
            Program.GameData.UnitNameList(true).CopyTo(0, list, 0, list.Length);
			lbList.Items.AddRange(list);
			lbList.SelectedIndex = 0;
			lbList.Focus();
		}

		private void lbList_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (lbList.SelectedIndex < 0 || lbList.SelectedIndex >= lbList.Items.Count)
			{
				return;
			}
			var msg = Program.ImsgData.UnitOriginalGet(lbList.SelectedIndex);
			txtText.Text = Utils.ByteToString(msg, 0, Program.IMSG_DATA_BLOCK_LENGTH);
			if (TopLevelControl != null)
			{
				TopLevelControl.Text = string.Format("{1} - 장수 열전 - 번호：{0}", lbList.SelectedIndex, Program.TitleNameCurrent);
			}
		}

		private void btnSave_Click(object sender, EventArgs e)
		{
			if (lbList.SelectedIndex < 0 || lbList.SelectedIndex >= lbList.Items.Count)
			{
				return;
			}
			var msg = Program.ImsgData.UnitOriginalGet(lbList.SelectedIndex);
			Utils.ChangeByteValue(msg, Utils.GetBytes(txtText.Text), 0, Program.IMSG_DATA_BLOCK_LENGTH);
            Program.ImsgData.UnitOriginalSet(lbList.SelectedIndex, msg);
		}

		private void btnRestore_Click(object sender, EventArgs e)
		{
			lbList_SelectedIndexChanged(lbList, new EventArgs());
		}
	}
}