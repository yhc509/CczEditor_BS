#region using List

using System;
using System.IO;
using System.Windows.Forms;
using System.Text;
using CczEditor.Resources;
using System.Linq;

#endregion

namespace CczEditor.Controls.DataControls
{
	public partial class MagicController : BaseDataControl
	{
        private Data.Wrapper.MagicData CurrentData;

		public MagicController()
		{
			InitializeComponent();
            label17.Visible = cbReflect.Visible = Program.CurrentConfig.CodeOptionContainer.MagicReflect;
			txtImsg.Enabled = ImsgDataLoaded;
			GetResourcesHitarea();
			GetResourcesEffarea();
		}

		private void MagicData_Load(object sender, EventArgs e)
		{
            cbHitarea.Items.AddRange(Program.CurrentConfig.HitAreaNames.ToArray());
			cbEffarea.Items.AddRange(Program.CurrentConfig.EffAreaNames.ToArray());

            if(Program.CurrentConfig.CodeOptionContainer.UseMeffAfterMcallExtension)
            {
                for(int i = 1; i <= 60; i++)
                    cbMcall.Items.Add($"{i:X2}, Meff-{i:D2}");

                cbMcall.Items.Add($"FF, 사용안함");
            } else
            {
                cbMcall.Items.Add("00, 화계1");
                cbMcall.Items.Add("01, 수계");
                cbMcall.Items.Add("02, 풍계");
                cbMcall.Items.Add("03, 지계");
                cbMcall.Items.Add("04, 랜덤");
                cbMcall.Items.Add("05, 번개");
                cbMcall.Items.Add("06, 화계2");
                cbMcall.Items.Add("07, 무표시");
                cbMcall.Items.Add("08, 회복");
                cbMcall.Items.Add("09, 사용안함");
            }

            var forceNames = ConfigUtils.GetForceNames(Program.ExeData, Program.CurrentConfig, Program.FORMATSTRING_KEYVALUEPAIR_HEX2);
            for (var i = 0; i < forceNames.Count; i++)
            {
                var item = new ListViewItem("0");
                item.SubItems.Add(forceNames[i]);
                lvLearnLv.Items.Add(item);
            }
			lbList.Items.AddRange(Program.GameData.MagicNameList(true).ToArray());
		}

        public override void Reset()
        {
            base.Reset();
            CurrentData = new Data.Wrapper.MagicData();
            lbList.SelectedIndex = 0;
            lbList.Focus();
        }

        private void lbList_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (lbList.SelectedIndex < 0 || lbList.SelectedIndex >= lbList.Items.Count)
			{
				return;
			}

            int index = lbList.SelectedIndex;

            CurrentData.Read(index, Program.GameData, Program.ImsgData, Program.ExeData, Program.CurrentConfig);

            txtName.Text = CurrentData.Name;

            ncMagicType.Value = CurrentData.MagicType;
            cbTarget.SelectedIndex = CurrentData.TargetType;
            cbHitarea.SelectedIndex = CurrentData.HitArea;
            cbEffarea.SelectedIndex = CurrentData.EffArea;
            ncMpCost.Value = CurrentData.MpCost;
            ncMagicIcon.Value = CurrentData.Icon;
            for (var i = 0; i < Program.CurrentConfig.ForceNames.Count; i++)
            {
                lvLearnLv.Items[i].Text = CurrentData.LearnLv[i].ToString();
            }
            if (ImsgDataLoaded)
            {
                txtImsg.Text = CurrentData.Imsg;
            }
            
            if (CurrentData.UseMagicType)
            {
                cbMagicType.Enabled = true;
                cbMagicType.SelectedIndex = CurrentData.MagicType;
            }
            else
            {
                cbMagicType.Enabled = false;
                cbMagicType.SelectedIndex = -1;
            }
            
            if (CurrentData.UseDmgType)
            {
                cbDmgType.Enabled = true;
                cbDmgType.SelectedIndex = CurrentData.DmgType;
            }
            else
            {
                cbDmgType.Enabled = false;
                cbDmgType.SelectedIndex = -1;
            }
            
            if (CurrentData.UseHealType)
            {
                cbHealType.Enabled = true;
                cbHealType.SelectedIndex = CurrentData.HealType;
            }
            else
            {
                cbHealType.Enabled = false;
                cbHealType.SelectedIndex = -1;
            }

                
            if (CurrentData.UseMeff)
            {
                cbMeff.Enabled = true;
                cbMeff.Value = CurrentData.Meff;
            }
            else
            {
                cbMeff.Enabled = false;
                cbMeff.Value = 0;
            }
            
            if (CurrentData.UseMcall)
            {
                cbMcall.Enabled = true;
                cbMcall.SelectedIndex = cbMcall.FindString(Utils.GetString(CurrentData.Mcall));

            }
            else
            {
                cbMcall.Enabled = false;
                cbMcall.SelectedIndex = -1;
            }
            
            if (CurrentData.UseAIType)
            {
                cbAiType.Enabled = true;
                cbAiType.SelectedIndex = CurrentData.AIType;

            }
            else
            {
                cbAiType.Enabled = false;
                cbAiType.SelectedIndex = -1;
            }

            if (Program.CurrentConfig.CodeOptionContainer.UseMagicCondition)
            {
                if (CurrentData.UseCondition)
                {
                    cbCondition.Enabled = true;
                    cbCondition.SelectedIndex = CurrentData.Condition;
                }
                else
                {
                    cbCondition.Enabled = false;
                    cbCondition.SelectedIndex = -1;
                }
            }
            else
            {
                cbCondition.Enabled = false;
                cbCondition.SelectedIndex = -1;
            }
            
            if (CurrentData.UseLearnType)
            {
                cbLearnType.Enabled = true;
                cbLearnType.Value = CurrentData.LearnType;
            }
            else
            {
                cbLearnType.Enabled = false;
                cbLearnType.Value = -1;
            }
            
            if (CurrentData.UseDmgValue)
            {
                cbDmgValue.Enabled = true;
                cbDmgValue.Value = CurrentData.DmgValue;
            }
            else
            {
                cbDmgValue.Enabled = false;
                cbDmgValue.Value = 0;
            }
            
            if (CurrentData.UseAccRate)
            {
                cbAccRate.Enabled = true;
                cbAccRate.Value = CurrentData.AccRate;

            }
            else
            {
                cbAccRate.Enabled = false;
                cbAccRate.Value = 0;
            }

            if (Program.CurrentConfig.CodeOptionContainer.MagicReflect)
            {
                if (CurrentData.UseReflect)
                {
                    cbReflect.Enabled = true;
                    cbReflect.SelectedIndex = CurrentData.Reflect;

                }
                else
                {
                    cbReflect.Enabled = false;
                    cbReflect.SelectedIndex = 0;
                }

            }

            if (TopLevelControl != null)
			{
				TopLevelControl.Text = string.Format("{1} - 책략 편집 - 번호：{0}", lbList.SelectedIndex, Program.TitleNameCurrent);
			}
		}

		private void btnSave_Click(object sender, EventArgs e)
		{
			if (lbList.SelectedIndex < 0 || lbList.SelectedIndex >= lbList.Items.Count)
			{
				return;
			}
			var index = lbList.SelectedIndex;

            CurrentData.MagicType = (byte)ncMagicType.Value;
            CurrentData.TargetType = (byte)cbTarget.SelectedIndex;
            CurrentData.HitArea = (byte)cbHitarea.SelectedIndex;
            CurrentData.EffArea = (byte)cbEffarea.SelectedIndex;
            CurrentData.MpCost = (byte)ncMpCost.Value;
            CurrentData.Icon = (byte)ncMagicIcon.Value;
            for (var i = 0; i < Program.CurrentConfig.ForceNames.Count; i++)
            {
                CurrentData.LearnLv[i] = byte.Parse(lvLearnLv.Items[i].Text);
            }

            CurrentData.Imsg = txtImsg.Text;

            CurrentData.MagicType = (byte) cbMagicType.SelectedIndex;
            CurrentData.DmgType = (byte)cbDmgType.SelectedIndex;
            CurrentData.HealType = (byte) cbHealType.SelectedIndex;
            CurrentData.Meff = (byte)cbMeff.Value;
            CurrentData.Mcall = (byte)cbMcall.SelectedIndex;
            CurrentData.AIType = (byte)cbAiType.SelectedIndex;
            CurrentData.Condition = (byte)cbCondition.SelectedIndex;
            CurrentData.LearnType = (byte)cbLearnType.Value;
            CurrentData.DmgValue = (byte)cbDmgValue.Value;
            CurrentData.AccRate = (byte)cbAccRate.Value;
            
            CurrentData.Write(index, Program.GameData, Program.ImsgData, Program.ExeData, Program.CurrentConfig);

            lbList.Items.RemoveAt(index);
			lbList.Items.Insert(index, string.Format(Program.FORMATSTRING_KEYVALUEPAIR_HEX2, index, txtName.Text));
			lbList.SelectedIndex = index;
		}

		private void btnRestore_Click(object sender, EventArgs e)
		{
			lbList_SelectedIndexChanged(lbList, new EventArgs());
		}        	

		private void btnImsgRestore_Click()
		{
			if (lbList.SelectedIndex < 0 || lbList.SelectedIndex >= lbList.Items.Count)
			{
				return;
			}
			var msg = Program.ImsgData.MagicGet(lbList.SelectedIndex);
			txtImsg.Text = Utils.ByteToString(msg, 0, Program.IMSG_DATA_BLOCK_LENGTH);
		}

		private void cbHitarea_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (Hitareas != null && Hitareas.Exists)
			{
				pbHitarea.Image = cbHitarea.SelectedIndex == -1 ? null : Hitareas.GetImage(cbHitarea.SelectedIndex);
			}
		}

		private void cbEffarea_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (Effareas != null && Effareas.Exists)
			{
				pbEffarea.Image = cbEffarea.SelectedIndex == -1 ? null : Effareas.GetImage(cbEffarea.SelectedIndex);
			}
		}

		private void txtImsg_TextChanged(object sender, EventArgs e)
        {
            int length = Encoding.Default.GetByteCount(txtImsg.Text);
            lblImsgCount.Text = $"{length} / 200 byte";
        }

		private void lvLearnLv_ItemActivate(object sender, EventArgs e)
		{
			if (lvLearnLv.SelectedItems.Count > 0)
			{
				lvLearnLv.SelectedItems[0].BeginEdit();
			}
		}

		private void lvLearnLv_AfterLabelEdit(object sender, LabelEditEventArgs e)
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

		private void ncMagicIcon_ValueChanged(object sender, EventArgs e)
        {
            if (Hitareas != null && Hitareas.Exists)
            {
                pbHitarea.Image = cbHitarea.SelectedIndex == -1 ? null : Hitareas.GetImage(cbHitarea.SelectedIndex);
            }

			if (((Program.GameData == null || Program.GameData.CurrentFile == null) || !Program.GameData.CurrentFile.Exists) || string.IsNullOrEmpty(Program.GameData.CurrentFile.DirectoryName))
			{
				return;
			}
            pbIconSmall.Image = MagicIconResources.Load((int) (ncMagicIcon.Value * 2) + 100);
            lblIconSmall.Text = ((ncMagicIcon.Value * 2) + 100).ToString();
            pbIcon.Image = MagicIconResources.Load((int)(ncMagicIcon.Value * 2) + 101);
            lblIcon.Text = ((ncMagicIcon.Value * 2) + 101).ToString();
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            var list = Program.GameData.MagicNameList(false);
            var index = list.FindIndex(x => x == searchTextBox.Text);
            if (index == -1)
            {
                MessageBox.Show("찾기에 실패했습니다.", "경고", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            lbList.SelectedIndex = index;
        }

        private void pbIcon_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog1 = new OpenFileDialog();
                openFileDialog1.Filter = "Image File(*.bmp)|*.bmp";
                OpenFileDialog openFileDialog2 = openFileDialog1;
                if (DialogResult.OK != openFileDialog2.ShowDialog() || string.IsNullOrEmpty(openFileDialog2.FileName) || !System.IO.File.Exists(openFileDialog2.FileName))
                    return;

                int index = (int)(ncMagicIcon.Value * 2) + 101;

                Resources.MagicIconResources.Save(index, openFileDialog2.FileName);

                ncMagicIcon_ValueChanged((object)null, (EventArgs)null);
                MessageBox.Show("수정 성공!");
            }
            catch
            {
                MessageBox.Show("오류가 발생했습니다!");
            }
        }

        private void pbIconSmall_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog1 = new OpenFileDialog();
                openFileDialog1.Filter = "Image File(*.bmp)|*.bmp";
                OpenFileDialog openFileDialog2 = openFileDialog1;
                if (DialogResult.OK != openFileDialog2.ShowDialog() || string.IsNullOrEmpty(openFileDialog2.FileName) || !System.IO.File.Exists(openFileDialog2.FileName))
                    return;

                int index = (int)(ncMagicIcon.Value * 2) + 100;

                Resources.MagicIconResources.Save(index, openFileDialog2.FileName);

                ncMagicIcon_ValueChanged((object)null, (EventArgs)null);
                MessageBox.Show("수정 성공!");
            }
            catch
            {
                MessageBox.Show("오류가 발생했습니다!");
            }
        }

        private void pbIcon_Click(object sender, EventArgs e)
        {

        }
    }
}