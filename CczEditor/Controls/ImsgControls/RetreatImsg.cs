#region using List

using System;

#endregion

namespace CczEditor.Controls.ImsgControls
{
	public partial class RetreatImsg : BaseImsgControl
	{
		public RetreatImsg()
		{
            InitializeComponent();
            comboBox1.Visible = false;
			lblTitle.Text = "퇴각 대사：";
			lbList.SelectedIndexChanged += lbList_SelectedIndexChanged;
			btnSave.Click += btnSave_Click;
			btnRestore.Click += btnRestore_Click;
		}

		private void RetreatImsg_Load(object sender, EventArgs e)
		{
			lbList.Items.AddRange(ImsgData.RetreatNameList(true).ToArray());
			lbList.SelectedIndex = 0;
			lbList.Focus();
		}

		private void lbList_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (lbList.SelectedIndex < 0 || lbList.SelectedIndex >= lbList.Items.Count)
			{
				return;
			}
			var msg = ImsgData.RetreatGet(lbList.SelectedIndex);
			txtText.Text = Utils.ByteToString(msg, 0, Program.IMSG_DATA_BLOCK_LENGTH);
			if (TopLevelControl != null)
			{
				TopLevelControl.Text = string.Format("{1} - 퇴각 대사 - 번호：{0}", lbList.SelectedIndex, Program.TitleNameCurrent);
			}
		}

		private void btnSave_Click(object sender, EventArgs e)
		{
			if (lbList.SelectedIndex < 0 || lbList.SelectedIndex >= lbList.Items.Count)
			{
				return;
			}
			var index = lbList.SelectedIndex;
			var msg = ImsgData.RetreatGet(index);
			Utils.ChangeByteValue(msg, Utils.GetBytes(txtText.Text), 0, Program.IMSG_DATA_BLOCK_LENGTH);
			ImsgData.RetreatSet(index, msg);
			lbList.Items.RemoveAt(index);
			lbList.Items.Insert(index, string.Format(Program.FORMATSTRING_KEYVALUEPAIR_DEC2, index, txtText.Text));
			lbList.SelectedIndex = index;
		}

		private void btnRestore_Click(object sender, EventArgs e)
		{
			lbList_SelectedIndexChanged(lbList, new EventArgs());
		}
	}
}