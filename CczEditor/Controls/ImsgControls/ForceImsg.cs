#region using List

using System;
using System.Linq;

#endregion

namespace CczEditor.Controls.ImsgControls
{
	public partial class ForceImsg : BaseImsgControl
	{
		public ForceImsg()
		{
			InitializeComponent();
            comboBox1.Visible = false;
			lblTitle.Text = "병종 설명：";
			lbList.SelectedIndexChanged += lbList_SelectedIndexChanged;
			btnSave.Click += btnSave_Click;
			btnRestore.Click += btnRestore_Click;
		}

		private void ForceImsg_Load(object sender, EventArgs e)
		{
			lbList.Items.AddRange(ConfigUtils.GetForceNames(Program.ExeData, Program.CurrentConfig, Program.FORMATSTRING_KEYVALUEPAIR_HEX2).Values.ToArray());
			lbList.SelectedIndex = 0;
			lbList.Focus();
		}

		private void lbList_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (lbList.SelectedIndex < 0 || lbList.SelectedIndex >= lbList.Items.Count)
			{
				return;
			}
			var msg = Program.ImsgData.ForceGet(lbList.SelectedIndex);
			txtText.Text = Utils.ByteToString(msg, 0, Program.IMSG_DATA_BLOCK_LENGTH);
			if (TopLevelControl != null)
			{
				TopLevelControl.Text = string.Format("{1} - 병종 설명 - 번호：{0}", lbList.SelectedIndex, Program.TitleNameCurrent);
			}
		}

		private void btnSave_Click(object sender, EventArgs e)
		{
			if (lbList.SelectedIndex < 0 || lbList.SelectedIndex >= lbList.Items.Count)
			{
				return;
			}
			var msg = Program.ImsgData.ForceGet(lbList.SelectedIndex);
			Utils.ChangeByteValue(msg, Utils.GetBytes(txtText.Text), 0, Program.IMSG_DATA_BLOCK_LENGTH);
            Program.ImsgData.ForceSet(lbList.SelectedIndex, msg);
		}

		private void btnRestore_Click(object sender, EventArgs e)
		{
			lbList_SelectedIndexChanged(lbList, new EventArgs());
		}
	}
}