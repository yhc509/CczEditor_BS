﻿#region using List

using System;
using System.IO;
using System.Windows.Forms;

using CczEditor.Resources;

#endregion

namespace CczEditor.Controls.DataControls
{
	public partial class MagicData : BaseDataControl
	{
		public MagicData()
		{
			InitializeComponent();
            label17.Visible = reflect.Visible = Program.CurrentConfig.CodeOptionContainer.MagicReflect;
			txtImsg.Enabled = ImsgDataLoaded;
			GetResourcesHitarea();
			GetResourcesEffarea();
		}

		private void MagicData_Load(object sender, EventArgs e)
		{
			cbHitarea.Items.AddRange(Program.CurrentConfig.HitAreaNames.ToArray());
			cbEffarea.Items.AddRange(Program.CurrentConfig.EffAreaNames.ToArray());
            var forceNames = ConfigUtils.GetForceNames(Program.FORMATSTRING_KEYVALUEPAIR_HEX2);
            for (var i = 0; i < forceNames.Count; i++)
            {
                var item = new ListViewItem("0");
                item.SubItems.Add(forceNames[i]);
                lvLearnLv.Items.Add(item);
            }
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
			var magic = GameData.MagicGet(lbList.SelectedIndex);
			txtName.Text = Utils.ByteToString(magic, 0, 10);

			ncMagicType.Value = magic[11];
			cbTarget.SelectedIndex = magic[12];
			cbHitarea.SelectedIndex = magic[13];
			cbEffarea.SelectedIndex = magic[14];
			ncMpCost.Value = magic[15];
			ncMagicIcon.Value = magic[16];
			for (var i = 0; i < Program.CurrentConfig.ForceNames.Count; i++)
			{
				lvLearnLv.Items[i].Text = magic[17+i].ToString();
			}
			if (ImsgDataLoaded)
			{
				btnImsgRestore_Click();
			}
            
            if (!Data.ExeData.IsLocked)
            {
                if (lbList.SelectedIndex >= Program.CurrentConfig.Exe.Magic.MagicTypeStartIndex
                    && lbList.SelectedIndex <= Program.CurrentConfig.Exe.Magic.MagicTypeEndIndex)
                {
                    m0.Enabled = true;
                    m0.SelectedIndex = Data.ExeData.ReadByte(
                        lbList.SelectedIndex - (Program.CurrentConfig.Exe.Magic.MagicTypeStartIndex),
                        Program.CurrentConfig.Exe.Magic.MagicTypeOffset);
                }
                else
                {
                    m0.Enabled = false;
                    m0.SelectedIndex = -1;
                }

                if (lbList.SelectedIndex >= Program.CurrentConfig.Exe.Magic.DamageTypeStartIndex
                    && lbList.SelectedIndex <= Program.CurrentConfig.Exe.Magic.DamageTypeEndIndex)
                {
                    m1.Enabled = true;
                    m1.SelectedIndex = Data.ExeData.ReadByte(
                        lbList.SelectedIndex - (Program.CurrentConfig.Exe.Magic.DamageTypeStartIndex),
                        Program.CurrentConfig.Exe.Magic.DamageTypeOffset);
                }
                else
                {
                    m1.Enabled = false;
                    m1.SelectedIndex = -1;
                }

                if (lbList.SelectedIndex >= Program.CurrentConfig.Exe.Magic.HealTypeStartIndex
                    && lbList.SelectedIndex <= Program.CurrentConfig.Exe.Magic.HealTypeEndIndex)
                {
                    m2.Enabled = true;
                    m2.SelectedIndex = Data.ExeData.ReadByte(
                        lbList.SelectedIndex - (Program.CurrentConfig.Exe.Magic.HealTypeStartIndex),
                        Program.CurrentConfig.Exe.Magic.HealTypeOffset);
                }
                else
                {
                    m2.Enabled = false;
                    m2.SelectedIndex = -1;
                }

                if (lbList.SelectedIndex >= Program.CurrentConfig.Exe.Magic.MeffStartIndex
                    && lbList.SelectedIndex <= Program.CurrentConfig.Exe.Magic.MeffEndIndex)
                {
                    m3.Enabled = true;
                    m3.Value = Data.ExeData.ReadByte(
                        lbList.SelectedIndex - (Program.CurrentConfig.Exe.Magic.MeffStartIndex),
                        Program.CurrentConfig.Exe.Magic.MeffOffset);
                }
                else
                {
                    m3.Enabled = false;
                    m3.Value = 0;
                }

                if (lbList.SelectedIndex >= Program.CurrentConfig.Exe.Magic.McallStartIndex
                    && lbList.SelectedIndex <= Program.CurrentConfig.Exe.Magic.McallEndIndex)
                {
                    m4.Enabled = true;
                    m4.SelectedIndex = Data.ExeData.ReadByte(
                        lbList.SelectedIndex - (Program.CurrentConfig.Exe.Magic.McallStartIndex),
                        Program.CurrentConfig.Exe.Magic.McallOffset);
                   
                }
                else
                {
                    m4.Enabled = false;
                    m4.SelectedIndex = -1;
                }

                if (lbList.SelectedIndex >= Program.CurrentConfig.Exe.Magic.AiTypeStartIndex
                    && lbList.SelectedIndex <= Program.CurrentConfig.Exe.Magic.AiTypeEndIndex)
                {
                    m5.Enabled = true;
                    m5.SelectedIndex = Data.ExeData.ReadByte(
                        lbList.SelectedIndex - (Program.CurrentConfig.Exe.Magic.AiTypeStartIndex),
                        Program.CurrentConfig.Exe.Magic.AiTypeOffset);

                }
                else
                {
                    m5.Enabled = false;
                    m5.SelectedIndex = -1;
                }

                if (lbList.SelectedIndex >= Program.CurrentConfig.Exe.Magic.UseConditionStartIndex
                    && lbList.SelectedIndex <= Program.CurrentConfig.Exe.Magic.UseConditionEndIndex)
                {
                    m6.Enabled = true;
                    m6.SelectedIndex = Data.ExeData.ReadByte(
                        lbList.SelectedIndex - (Program.CurrentConfig.Exe.Magic.UseConditionStartIndex),
                        Program.CurrentConfig.Exe.Magic.UseConditionOffset);

                }
                else
                {
                    m6.Enabled = false;
                    m6.SelectedIndex = -1;
                }

                if (lbList.SelectedIndex >= Program.CurrentConfig.Exe.Magic.LearTypeStartIndex
                    && lbList.SelectedIndex <= Program.CurrentConfig.Exe.Magic.LearTypeEndIndex)
                {
                    m7.Enabled = true;
                    m7.Value = Data.ExeData.ReadByte(
                        lbList.SelectedIndex - (Program.CurrentConfig.Exe.Magic.LearTypeStartIndex),
                        Program.CurrentConfig.Exe.Magic.LearTypeOffset);

                }
                else
                {
                    m7.Enabled = false;
                    m7.Value = -1;
                }

                if (lbList.SelectedIndex >= Program.CurrentConfig.Exe.Magic.DamageValueStartIndex
                    && lbList.SelectedIndex <= Program.CurrentConfig.Exe.Magic.DamageValueEndIndex)
                {
                    m8.Enabled = true;
                    m8.Value = Data.ExeData.ReadByte(
                        lbList.SelectedIndex - (Program.CurrentConfig.Exe.Magic.DamageValueStartIndex),
                        Program.CurrentConfig.Exe.Magic.DamageValueOffset);

                }
                else
                {
                    m8.Enabled = false;
                    m8.Value = 0;
                }

                if (lbList.SelectedIndex >= Program.CurrentConfig.Exe.Magic.AccRateStartIndex
                    && lbList.SelectedIndex <= Program.CurrentConfig.Exe.Magic.AccRateEndIndex)
                {
                    m9.Enabled = true;
                    m9.Value = Data.ExeData.ReadByte(
                        lbList.SelectedIndex - (Program.CurrentConfig.Exe.Magic.AccRateStartIndex),
                        Program.CurrentConfig.Exe.Magic.AccRateOffset);

                }
                else
                {
                    m9.Enabled = false;
                    m9.Value = 0;
                }

                if(Program.CurrentConfig.CodeOptionContainer.MagicReflect)
                {
                    if (lbList.SelectedIndex >= Program.CurrentConfig.Exe.Magic.ReflectTypeStartIndex
                        && lbList.SelectedIndex <= Program.CurrentConfig.Exe.Magic.ReflectTypeEndIndex)
                    {
                        reflect.Enabled = true;
                        reflect.SelectedIndex = Data.ExeData.ReadByte(
                            lbList.SelectedIndex - (Program.CurrentConfig.Exe.Magic.ReflectTypeStartIndex),
                            Program.CurrentConfig.Exe.Magic.ReflectTypeOffset);

                    }
                    else
                    {
                        reflect.Enabled = false;
                        reflect.SelectedIndex = 0;
                    }

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
			var magic = GameData.MagicGet(index);
			Utils.ChangeByteValue(magic, Utils.GetBytes(txtName.Text), 0, 10);

			magic[11] = (byte)ncMagicType.Value;
			magic[12] = (byte)cbTarget.SelectedIndex;
			magic[13] = (byte)cbHitarea.SelectedIndex;
			magic[14] = (byte)cbEffarea.SelectedIndex;
			magic[15] = (byte)ncMpCost.Value;
			magic[16] = (byte)ncMagicIcon.Value;
			for (var i = 0; i < Program.CurrentConfig.ForceNames.Count; i++)
			{
				magic[17+i] = byte.Parse(lvLearnLv.Items[i].Text);
			}
			GameData.MagicSet(index, magic);

            //Imsg
            var msg = ImsgData.MagicGet(lbList.SelectedIndex);
            Utils.ChangeByteValue(msg, Utils.GetBytes(txtImsg.Text), 0, Program.IMSG_DATA_BLOCK_LENGTH);
            ImsgData.MagicSet(lbList.SelectedIndex, msg);


            //EXE
            if (!Data.ExeData.IsLocked)
            {
                if (lbList.SelectedIndex >= Program.CurrentConfig.Exe.Magic.MagicTypeStartIndex
                    && lbList.SelectedIndex <= Program.CurrentConfig.Exe.Magic.MagicTypeEndIndex)
                {
                    Data.ExeData.WriteByte(
                         (byte)m0.SelectedIndex,
                         lbList.SelectedIndex - (Program.CurrentConfig.Exe.Magic.MagicTypeStartIndex),
                         Program.CurrentConfig.Exe.Magic.MagicTypeOffset);
                }

                if (lbList.SelectedIndex >= Program.CurrentConfig.Exe.Magic.DamageTypeStartIndex
                    && lbList.SelectedIndex <= Program.CurrentConfig.Exe.Magic.DamageTypeEndIndex)
                {
                    Data.ExeData.WriteByte(
                         (byte)m1.SelectedIndex,
                         lbList.SelectedIndex - (Program.CurrentConfig.Exe.Magic.DamageTypeStartIndex),
                         Program.CurrentConfig.Exe.Magic.DamageTypeOffset);
                }

                if (lbList.SelectedIndex >= Program.CurrentConfig.Exe.Magic.HealTypeStartIndex
                    && lbList.SelectedIndex <= Program.CurrentConfig.Exe.Magic.HealTypeEndIndex)
                {
                    Data.ExeData.WriteByte(
                         (byte)m2.SelectedIndex,
                         lbList.SelectedIndex - (Program.CurrentConfig.Exe.Magic.HealTypeStartIndex),
                         Program.CurrentConfig.Exe.Magic.HealTypeOffset);
                }

                if (lbList.SelectedIndex >= Program.CurrentConfig.Exe.Magic.MeffStartIndex
                    && lbList.SelectedIndex <= Program.CurrentConfig.Exe.Magic.MeffEndIndex)
                {
                    Data.ExeData.WriteByte(
                         (byte)m3.Value,
                         lbList.SelectedIndex - (Program.CurrentConfig.Exe.Magic.MeffStartIndex),
                         Program.CurrentConfig.Exe.Magic.MeffOffset);
                }

                if (lbList.SelectedIndex >= Program.CurrentConfig.Exe.Magic.McallStartIndex
                    && lbList.SelectedIndex <= Program.CurrentConfig.Exe.Magic.McallEndIndex)
                {
                    Data.ExeData.WriteByte(
                         (byte)m4.SelectedIndex,
                         lbList.SelectedIndex - (Program.CurrentConfig.Exe.Magic.MagicTypeStartIndex),
                         Program.CurrentConfig.Exe.Magic.McallOffset);
                }

                if (lbList.SelectedIndex >= Program.CurrentConfig.Exe.Magic.AiTypeStartIndex
                    && lbList.SelectedIndex <= Program.CurrentConfig.Exe.Magic.AiTypeEndIndex)
                {
                    Data.ExeData.WriteByte(
                         (byte)m5.SelectedIndex,
                         lbList.SelectedIndex - (Program.CurrentConfig.Exe.Magic.AiTypeStartIndex),
                         Program.CurrentConfig.Exe.Magic.AiTypeOffset);
                }

                if (lbList.SelectedIndex >= Program.CurrentConfig.Exe.Magic.UseConditionStartIndex
                    && lbList.SelectedIndex <= Program.CurrentConfig.Exe.Magic.UseConditionEndIndex)
                {
                    Data.ExeData.WriteByte(
                         (byte)m6.SelectedIndex,
                         lbList.SelectedIndex - (Program.CurrentConfig.Exe.Magic.UseConditionStartIndex),
                         Program.CurrentConfig.Exe.Magic.UseConditionOffset);
                }

                if (lbList.SelectedIndex >= Program.CurrentConfig.Exe.Magic.LearTypeStartIndex
                    && lbList.SelectedIndex <= Program.CurrentConfig.Exe.Magic.LearTypeEndIndex)
                {
                    Data.ExeData.WriteByte(
                         (byte)m7.Value,
                         lbList.SelectedIndex - (Program.CurrentConfig.Exe.Magic.LearTypeStartIndex),
                         Program.CurrentConfig.Exe.Magic.LearTypeOffset);
                }

                if (lbList.SelectedIndex >= Program.CurrentConfig.Exe.Magic.DamageValueStartIndex
                    && lbList.SelectedIndex <= Program.CurrentConfig.Exe.Magic.DamageValueEndIndex)
                {
                    Data.ExeData.WriteByte(
                         (byte)m8.Value,
                         lbList.SelectedIndex - (Program.CurrentConfig.Exe.Magic.DamageValueStartIndex),
                         Program.CurrentConfig.Exe.Magic.DamageValueOffset);
                }

                if (lbList.SelectedIndex >= Program.CurrentConfig.Exe.Magic.AccRateStartIndex
                    && lbList.SelectedIndex <= Program.CurrentConfig.Exe.Magic.AccRateEndIndex)
                {
                    Data.ExeData.WriteByte(
                         (byte)m9.Value,
                         lbList.SelectedIndex - (Program.CurrentConfig.Exe.Magic.AccRateStartIndex),
                         Program.CurrentConfig.Exe.Magic.AccRateOffset);
                }
            }
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
			var msg = ImsgData.MagicGet(lbList.SelectedIndex);
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
			lblImsgCount.Text = string.Format("글자 수 {0}", txtImsg.Text.Length);
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

			if (((GameData == null || GameData.CurrentFile == null) || !GameData.CurrentFile.Exists) || string.IsNullOrEmpty(GameData.CurrentFile.DirectoryName))
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
            var list = GameData.MagicNameList(false);
            var index = list.FindIndex(x => x == searchTextBox.Text);
            if (index == -1)
            {
                MessageBox.Show("찾기에 실패했습니다.", "경고", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            lbList.SelectedIndex = index;
        }
    }
}