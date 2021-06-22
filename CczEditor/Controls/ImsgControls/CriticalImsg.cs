#region using List

using System;

#endregion

namespace CczEditor.Controls.ImsgControls
{
	public partial class CriticalImsg : BaseImsgControl
	{
		public CriticalImsg()
		{
			InitializeComponent();
			lblTitle.Text = "회심 대사：";
			lbList.SelectedIndexChanged += lbList_SelectedIndexChanged;
			btnSave.Click += btnSave_Click;
			btnRestore.Click += btnRestore_Click;
		}

		private void CriticalImsg_Load(object sender, EventArgs e)
		{
			lbList.Items.AddRange(Program.ImsgData.CriticalNameList.ToArray());
			lbList.SelectedIndex = 0;
			lbList.Focus();
		}

		private void lbList_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (lbList.SelectedIndex < 0 || lbList.SelectedIndex >= lbList.Items.Count)
			{
				return;
			}
			var index = lbList.SelectedIndex;
			var msg = Program.ImsgData.CriticalGet(index);
			txtText.Text = Utils.ByteToString(msg, 0, Program.IMSG_DATA_BLOCK_LENGTH);
            /*
            if (ExeDataLoaded)
            {
                if (lbList.SelectedIndex < Program.CurrentConfig.Imsg.CriticalCount+1)
                {
                    comboBox1.Visible = true;
                    comboBox1.SelectedIndex = Program.ExeData.readCritical(lbList.SelectedIndex);

                }
                else
                {
                    comboBox1.Visible = false;
                }
            }*/
			if (TopLevelControl != null)
			{
				TopLevelControl.Text = string.Format("{1} - 회심 대사 - 번호：{0}，유형：{2}", 
                    lbList.SelectedIndex, 
                    Program.TitleNameCurrent, 
                    index < Program.CurrentConfig.Imsg.CriticalCount+1 ? "특수대사" : string.Format("{0:D2}", (index-(Program.CurrentConfig.Imsg.CriticalCount + 1))/3));
			}
		}

		private void btnSave_Click(object sender, EventArgs e)
		{
			if (lbList.SelectedIndex < 0 || lbList.SelectedIndex >= lbList.Items.Count)
			{
				return;
			}
			var index = lbList.SelectedIndex;
			var msg = Program.ImsgData.CriticalGet(index);
			Utils.ChangeByteValue(msg, Utils.GetBytes(txtText.Text), 0, Program.IMSG_DATA_BLOCK_LENGTH);
            Program.ImsgData.CriticalSet(index, msg);
            /*
            if (ExeDataLoaded)
            {
                if (lbList.SelectedIndex < Program.CurrentConfig.Imsg.CriticalCount + 1)
                {
                   Data.ExeData.saveCritical(lbList.SelectedIndex,comboBox1.SelectedIndex);

                }
            }*/
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