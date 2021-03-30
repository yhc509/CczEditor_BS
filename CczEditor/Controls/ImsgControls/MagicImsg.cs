#region using List

using System;

#endregion

namespace CczEditor.Controls.ImsgControls
{
	public partial class MagicImsg : BaseImsgControl
	{
		public MagicImsg()
		{
            InitializeComponent();
            comboBox1.Visible = false;
			lblTitle.Text = "책략 설명：";
			lbList.SelectedIndexChanged += lbList_SelectedIndexChanged;
			btnSave.Click += btnSave_Click;
			btnRestore.Click += btnRestore_Click;
		}

		private void MagicImsg_Load(object sender, EventArgs e)
		{
			lbList.Items.AddRange(GameData.MagicNameList(true).ToArray());
			lbList.SelectedIndex = 0;
			lbList.Focus();
		}

		private void lbList_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (lbList.SelectedIndex < 0 || lbList.SelectedIndex >= lbList.Items.Count)
			{
				return;
			}
			var msg = ImsgData.MagicGet(lbList.SelectedIndex);
			txtText.Text = Utils.ByteToString(msg, 0, Program.IMSG_DATA_BLOCK_LENGTH);
			if (TopLevelControl != null)
			{
				TopLevelControl.Text = string.Format("{1} - 책략 설명 - 번호：{0}", lbList.SelectedIndex, Program.TitleNameCurrent);
			}
		}

		private void btnSave_Click(object sender, EventArgs e)
		{
			if (lbList.SelectedIndex < 0 || lbList.SelectedIndex >= lbList.Items.Count)
			{
				return;
			}
			var msg = ImsgData.MagicGet(lbList.SelectedIndex);
			Utils.ChangeByteValue(msg, Utils.GetBytes(txtText.Text), 0, Program.IMSG_DATA_BLOCK_LENGTH);
			ImsgData.MagicSet(lbList.SelectedIndex, msg);
		}

		private void btnRestore_Click(object sender, EventArgs e)
		{
			lbList_SelectedIndexChanged(lbList, new EventArgs());
		}
	}
}