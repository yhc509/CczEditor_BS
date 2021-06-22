#region using List

using System;

#endregion

namespace CczEditor.Controls.ImsgControls
{
	public partial class StaffImsg : BaseImsgControl
	{
		public StaffImsg()
		{
            InitializeComponent();
            comboBox1.Visible = false;
			lblTitle.Text = "제작 인물：";
			lbList.SelectedIndexChanged += lbList_SelectedIndexChanged;
			btnSave.Click += btnSave_Click;
			btnRestore.Click += btnRestore_Click;
		}

		private void StaffImsg_Load(object sender, EventArgs e)
		{
			lbList.Items.AddRange(Program.ImsgData.StaffNameList.ToArray());
			lbList.SelectedIndex = 0;
			lbList.Focus();
			if (TopLevelControl != null)
			{
				TopLevelControl.Text = string.Format("{0} - 제작 인물", Program.TitleNameCurrent);
			}
		}

		private void lbList_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (lbList.SelectedIndex < 0 || lbList.SelectedIndex >= lbList.Items.Count)
			{
				return;
			}
			var msg = Program.ImsgData.StaffGet(lbList.SelectedIndex);
			txtText.Text = Utils.ByteToString(msg, 0, Program.IMSG_DATA_BLOCK_LENGTH);
		}

		private void btnSave_Click(object sender, EventArgs e)
		{
			if (lbList.SelectedIndex < 0 || lbList.SelectedIndex >= lbList.Items.Count)
			{
				return;
			}
			var index = lbList.SelectedIndex;
			var msg = Program.ImsgData.StaffGet(index);
			Utils.ChangeByteValue(msg, Utils.GetBytes(txtText.Text), 0, Program.IMSG_DATA_BLOCK_LENGTH);
            Program.ImsgData.StaffSet(index, msg);
			lbList.Items.RemoveAt(index);
			lbList.Items.Insert(index, txtText.Text);
			lbList.SelectedIndex = index;
		}

		private void btnRestore_Click(object sender, EventArgs e)
		{
			lbList_SelectedIndexChanged(lbList, new EventArgs());
		}
	}
}