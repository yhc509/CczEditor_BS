#region using List

using System.Windows.Forms;
using System;
using System.Linq;
using System.Text;

#endregion

namespace CczEditor.Controls.DataControls
{
	public partial class ForceData : BaseDataControl
	{
		public ForceData()
		{
			InitializeComponent();
            if (Program.CurrentConfig.CodeOptionContainer.AIExtension)
            {
                f9.Enabled = true;
            }
            else
            {
                f9.Enabled = false;
            }
            txtImsg.Enabled = ImsgDataLoaded;
            GetResourcesHitarea();
            GetResourcesEffarea();
		}

		private void ForceData_Load(object sender, EventArgs e)
		{
            var equipmentTypes = ConfigUtils.GetEquipmentTypes(Program.FORMATSTRING_KEYVALUEPAIR_HEX2);
			if (equipmentTypes != null)
			{
				for (var i = 0; i < equipmentTypes.Count; i++)
				{
					if (equipmentTypes.ContainsKey(i))
					{
						clbEquipment.Items.Add(equipmentTypes[i]);
					}
					else
					{
						clbEquipment.Items.Add(string.Empty);
					}
				}
			}

            SpecialSkillForce.Items.Add(string.Format(Program.FORMATSTRING_KEYVALUEPAIR_HEX2, 0, "미사용"));
            var specialSkillList = Program.CurrentConfig.SpecialSkillNames;
            for(int i = Program.CurrentConfig.Exe.SpecialSkillPhysicsCount + 1; i < specialSkillList.Count; i++)
            {
                var index = i - Program.CurrentConfig.Exe.SpecialSkillPhysicsCount;
                SpecialSkillForce.Items.Add(string.Format(Program.FORMATSTRING_KEYVALUEPAIR_HEX2, index, specialSkillList[i].Description));
            }


            cbHitarea.Items.AddRange(Program.CurrentConfig.HitAreaNames.ToArray());
            eff.Items.AddRange(Program.CurrentConfig.EffAreaNames.ToArray());
            lbList.Items.AddRange(ConfigUtils.GetForceNames(Program.FORMATSTRING_KEYVALUEPAIR_HEX2).Values.ToArray());
			lbList.SelectedIndex = 0;
			lbList.Focus();
		}

		private void lbList_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (lbList.SelectedIndex < 0 || lbList.SelectedIndex >= lbList.Items.Count)
			{
				return;
			}

			var force = Program.GameData.ForceGet(lbList.SelectedIndex);
			ncMove.Value = force[0];
			cbHitarea.SelectedIndex = force[1];
			ncAtk.Value = force[2];
			ncDef.Value = force[3];
			ncMag.Value = force[4];
			ncCrt.Value = force[5];
			ncMor.Value = force[6];
			ncHp.Value = force[7];
			ncMp.Value = force[8];
			var di = 9;
			for (var i = 0; i < clbEquipment.Items.Count; i++, di++)
			{
				clbEquipment.SetItemChecked(i, force[di] == 0x01);
			}
			if (ImsgDataLoaded)
			{
				btnImsgRestore_Click();
			}

            int forceIndex = (byte) lbList.SelectedIndex;
            int forceCategoryIndex = 0;
            int ForceCount = Program.CurrentConfig.ForceNames.Count;
            int ForceCategoryCount = Program.CurrentConfig.ForceCategoryNames.Count;
            if (lbList.SelectedIndex < ((ForceCount - ForceCategoryCount) / 2) * 3 - 1)
            {
                forceCategoryIndex = (lbList.SelectedIndex / 3);
            }
            else
            {
                forceCategoryIndex = (lbList.SelectedIndex - ((ForceCount - ForceCategoryCount) / 2) * 3) + (ForceCount - ForceCategoryCount) / 2;
            }

            f1.Enabled = f2.Enabled = f3.Enabled = f4.Enabled = f5.Enabled = f6.Enabled = f7.Enabled = f8.Enabled = eff.Enabled = button1.Enabled = !Data.ExeData.IsLocked;
            if (!Data.ExeData.IsLocked)
            {
                ForceNameBox.Text = ConfigUtils.GetForceName(forceIndex);
                ForceCategoryNameBox.Text = ConfigUtils.GetForceCategoryName(forceCategoryIndex);
                f1.SelectedIndex = Data.ExeData.ReadByte(forceCategoryIndex, Program.CurrentConfig.Exe.Force.MoveSoundOffset);
                f2.SelectedIndex = Data.ExeData.ReadByte(forceCategoryIndex, Program.CurrentConfig.Exe.Force.MoveSpeedOffset);
                f3.SelectedIndex = Data.ExeData.ReadByte(forceCategoryIndex, Program.CurrentConfig.Exe.Force.AtkSoundOffset);
                f4.SelectedIndex = Data.ExeData.ReadByte(forceCategoryIndex, Program.CurrentConfig.Exe.Force.AtkTypeOffset);
                f5.SelectedIndex = Data.ExeData.ReadByte(forceCategoryIndex, Program.CurrentConfig.Exe.Force.TypeOffset);
                f6.Value = Data.ExeData.ReadByte(forceCategoryIndex, Program.CurrentConfig.Exe.Force.MagicDamageOffset);
                f7.SelectedIndex = Data.ExeData.ReadByte(forceCategoryIndex, Program.CurrentConfig.Exe.Force.AtkDelayOffset);
                f8.SelectedIndex = Data.ExeData.ReadByte(forceCategoryIndex, Program.CurrentConfig.Exe.Force.AtkPincOffset);
                if (Program.CurrentConfig.CodeOptionContainer.AIExtension)
                {
                    f9.SelectedIndex = Data.ExeData.ReadByte(forceCategoryIndex, Program.CurrentConfig.Exe.Force.AiTypeOffset);
                }
                eff.SelectedIndex = Data.ExeData.ReadByte(forceIndex, Program.CurrentConfig.Exe.Force.AtkEffectOffset);

                SpecialSkillForce.SelectedIndex = Data.ExeData.ReadByte(forceCategoryIndex, Program.CurrentConfig.Exe.SpecialSkillForceOffset);
            }
            if (TopLevelControl != null)
			{
				TopLevelControl.Text = string.Format("{1} - 병종 편집 - 번호：{0}", lbList.SelectedIndex, Program.TitleNameCurrent);
			}
		}

		private void btnSave_Click(object sender, EventArgs e)
		{
			if (lbList.SelectedIndex < 0 || lbList.SelectedIndex >= lbList.Items.Count)
			{
				return;
			}


			var index = lbList.SelectedIndex;

			var force = Program.GameData.ForceGet(index);
			force[0] = (byte)ncMove.Value;
			force[1] = (byte)cbHitarea.SelectedIndex;
			force[2] = (byte)ncAtk.Value;
			force[3] = (byte)ncDef.Value;
			force[4] = (byte)ncMag.Value;
			force[5] = (byte)ncCrt.Value;
			force[6] = (byte)ncMor.Value;
			force[7] = (byte)ncHp.Value;
			force[8] = (byte)ncMp.Value;
			var di = 9;
			for (var i = 0; i < clbEquipment.Items.Count; i++, di++)
			{
				force[di] = (byte)(clbEquipment.GetItemChecked(i) ? 0x01 : 0x00);
			}
            Program.GameData.ForceSet(index, force);

            //Imsg
            if (ImsgDataLoaded)
            {
                var msg = Program.ImsgData.ForceGet(lbList.SelectedIndex);
                Utils.ChangeByteValue(msg, Utils.GetBytes(txtImsg.Text), 0, Program.IMSG_DATA_BLOCK_LENGTH);
                Program.ImsgData.ForceSet(lbList.SelectedIndex, msg);
            }

            //EXE
            if (!Data.ExeData.IsLocked)
            {
                Data.ExeData.Open(System.IO.FileAccess.ReadWrite);
                int forcenum = 0;
                if (lbList.SelectedIndex < 60)
                {
                    forcenum = (lbList.SelectedIndex / 3);
                }
                else
                {
                    forcenum = (lbList.SelectedIndex - 59) + 19;
                }

                string forceName;
                var forceInfo = Program.CurrentConfig.ForceNames.Find(x => x.Index == index);
                if (ForceNameBox.Text.Length > forceInfo.Length)
                    forceName = ForceNameBox.Text.Substring(0, forceInfo.Length);
                else
                    forceName = ForceNameBox.Text;

                Data.ExeData.WriteText(forceName, forceInfo.Offset, forceInfo.Length);

                string forceCategoryName;
                var forceCategoryInfo = Program.CurrentConfig.ForceCategoryNames.Find(x => x.Index == forcenum);
                if (ForceCategoryNameBox.Text.Length > forceInfo.Length)
                    forceCategoryName = ForceCategoryNameBox.Text.Substring(0, forceInfo.Length);
                else
                    forceCategoryName = ForceCategoryNameBox.Text;
            
                Data.ExeData.WriteText(forceCategoryName, forceCategoryInfo.Offset, forceCategoryInfo.Length);

                Data.ExeData.WriteByte((byte)f1.SelectedIndex, forcenum, Program.CurrentConfig.Exe.Force.MoveSoundOffset);
                Data.ExeData.WriteByte((byte)f2.SelectedIndex, forcenum, Program.CurrentConfig.Exe.Force.MoveSpeedOffset);
                Data.ExeData.WriteByte((byte)f3.SelectedIndex, forcenum, Program.CurrentConfig.Exe.Force.AtkSoundOffset);
                Data.ExeData.WriteByte((byte)f4.SelectedIndex, forcenum, Program.CurrentConfig.Exe.Force.AtkTypeOffset);
                Data.ExeData.WriteByte((byte)f5.SelectedIndex, forcenum, Program.CurrentConfig.Exe.Force.TypeOffset);
                Data.ExeData.WriteByte((byte)f6.Value, forcenum, Program.CurrentConfig.Exe.Force.MagicDamageOffset);
                Data.ExeData.WriteByte((byte)f7.SelectedIndex, forcenum, Program.CurrentConfig.Exe.Force.AtkDelayOffset);
                Data.ExeData.WriteByte((byte)f8.SelectedIndex, forcenum, Program.CurrentConfig.Exe.Force.AtkPincOffset);
                if (Program.CurrentConfig.CodeOptionContainer.AIExtension)
                {
                    Data.ExeData.WriteByte((byte)f9.SelectedIndex, forcenum, Program.CurrentConfig.Exe.Force.AiTypeOffset);
                }
                Data.ExeData.WriteByte((byte)eff.SelectedIndex, index, Program.CurrentConfig.Exe.Force.AtkEffectOffset);

                Data.ExeData.WriteByte((byte)SpecialSkillForce.SelectedIndex, forcenum, Program.CurrentConfig.Exe.SpecialSkillForceOffset);

                Data.ExeData.Close();

                lbList.Items.RemoveAt(index);
                lbList.Items.Insert(index, string.Format(Program.FORMATSTRING_KEYVALUEPAIR_HEX2, index, forceName));
                lbList.SelectedIndex = index;
            }
        }

        private void btnRestore_Click(object sender, EventArgs e)
		{
			lbList_SelectedIndexChanged(lbList, new EventArgs());
		}

		private void cbHitarea_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (Hitareas != null && Hitareas.Exists)
			{
				pbHitarea.Image = cbHitarea.SelectedIndex == -1 ? null : Hitareas.GetImage(cbHitarea.SelectedIndex);
			}
		}

        private void eff_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Effareas != null && Effareas.Exists)
            {
                pbEffarea.Image = eff.SelectedIndex == -1 ? null : Effareas.GetImage(eff.SelectedIndex);
            }
        }

		private void btnImsgRestore_Click()
		{
			if (lbList.SelectedIndex < 0 || lbList.SelectedIndex >= lbList.Items.Count)
			{
				return;
			}
			var msg = Program.ImsgData.ForceGet(lbList.SelectedIndex);
			txtImsg.Text = Utils.ByteToString(msg, 0, Program.IMSG_DATA_BLOCK_LENGTH);
		}

		private void txtImsg_TextChanged(object sender, EventArgs e)
        {
            int length = Encoding.Default.GetByteCount(txtImsg.Text);
            lblImsgCount.Text = $"{length} / 200 byte";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            sangseong sangseong = new sangseong();
            sangseong.ShowDialog();
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            var list = ConfigUtils.GetForceNames().Values.ToList();
            var index = list.FindIndex(x => x == searchTextBox.Text);
            if(index == -1)
            {
                MessageBox.Show("찾기에 실패했습니다.", "경고", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            lbList.SelectedIndex = index;

        }
    }
}