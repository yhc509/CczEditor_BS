#region using List

using System;

#endregion

namespace CczEditor.Controls.DataControls
{
	public partial class ForceData : BaseDataControl
	{
		public ForceData()
		{
			InitializeComponent();
            f1.Enabled = f2.Enabled = f3.Enabled = f4.Enabled = f5.Enabled = f6.Enabled = f7.Enabled = f8.Enabled = eff.Enabled = button1.Enabled = ExeDataLoaded;
            if (Program.CurrentConfig.AIExtension && ExeDataLoaded)
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
            var equipmentTypes = Program.CurrentConfig.ItemConfigs.EquipmentTypes(false);
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
			cbHitarea.Items.AddRange(Program.CurrentConfig.Hitareas.ToArray());
            lbList.Items.AddRange(Program.CurrentConfig.ForceNames.ToArray());
			lbList.SelectedIndex = 0;
			lbList.Focus();
		}

		private void lbList_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (lbList.SelectedIndex < 0 || lbList.SelectedIndex >= lbList.Items.Count)
			{
				return;
			}
			var force = GameData.ForceGet(lbList.SelectedIndex);
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
            if (ExeDataLoaded)
            {               
                int forcenum = 0;
                int ForceCount = Program.CurrentConfig.Forces.Count;
                int ForceCategoryCount = Program.CurrentConfig.ForceCategories.Count;
                if (lbList.SelectedIndex < ((ForceCount-ForceCategoryCount)/2)*3-1)
                {
                    forcenum = (lbList.SelectedIndex / 3);
                }
                else
                {
                    forcenum = (lbList.SelectedIndex - ((ForceCount - ForceCategoryCount) / 2) * 3) + (ForceCount-ForceCategoryCount)/2;
                }
                label10.Text = Program.CurrentConfig.ForceCategoryNameslb(forcenum);
                f1.SelectedIndex = Program.ExeData.forceload(forcenum, "Exe_Force_MovSound");
                f2.SelectedIndex = Program.ExeData.forceload(forcenum, "Exe_Force_MovSpeed");
                f3.SelectedIndex = Program.ExeData.forceload(forcenum, "Exe_Force_AtkSound");
                f4.SelectedIndex = Program.ExeData.forceload(forcenum, "Exe_Force_AtkType");
                f5.SelectedIndex = Program.ExeData.forceload(forcenum, "Exe_Force_ForceType");
                f6.Value = Program.ExeData.forceload(forcenum, "Exe_Force_SprDmg");
                f7.SelectedIndex = Program.ExeData.forceload(forcenum, "Exe_Force_AtkDelay");
                f8.SelectedIndex = Program.ExeData.forceload(forcenum, "Exe_Force_AtkPinc");
                if (Program.CurrentConfig.AIExtension)
                {
                    f9.SelectedIndex = Program.ExeData.forceload(forcenum, "Exe_Force_AI");
                }
                eff.SelectedIndex = Program.ExeData.forceload(lbList.SelectedIndex, "Exe_Force_AtkEffect");

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
			var force = GameData.ForceGet(index);
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
			GameData.ForceSet(index, force);

            //Imsg
            if (ImsgDataLoaded)
            {
                var msg = ImsgData.ForceGet(lbList.SelectedIndex);
                Utils.ChangeByteValue(msg, Utils.GetBytes(txtImsg.Text), 0, Program.IMSG_DATA_BLOCK_LENGTH);
                ImsgData.ForceSet(lbList.SelectedIndex, msg);
            }

            //EXE
            if (ExeDataLoaded)
            {
                int forcenum = 0;
                if (lbList.SelectedIndex < 60)
                {
                    forcenum = (lbList.SelectedIndex / 3);
                }
                else
                {
                    forcenum = (lbList.SelectedIndex - 59) + 19;
                }
                Program.ExeData.forcesave(forcenum, "Exe_Force_MovSound", (byte)f1.SelectedIndex);
                Program.ExeData.forcesave(forcenum, "Exe_Force_MovSpeed", (byte)f2.SelectedIndex);
                Program.ExeData.forcesave(forcenum, "Exe_Force_AtkSound", (byte)f3.SelectedIndex);
                Program.ExeData.forcesave(forcenum, "Exe_Force_AtkType", (byte)f4.SelectedIndex);
                Program.ExeData.forcesave(forcenum, "Exe_Force_ForceType", (byte)f5.SelectedIndex);
                Program.ExeData.forcesave(forcenum, "Exe_Force_SprDmg", (byte)f6.Value);
                Program.ExeData.forcesave(forcenum, "Exe_Force_AtkDelay", (byte)f7.SelectedIndex);
                Program.ExeData.forcesave(forcenum, "Exe_Force_AtkPinc", (byte)f8.SelectedIndex);
                if (Program.CurrentConfig.AIExtension)
                {
                    Program.ExeData.forcesave(forcenum, "Exe_Force_AI", (byte)f9.SelectedIndex);
                }
                Program.ExeData.forcesave(lbList.SelectedIndex, "Exe_Force_AtkEffect", (byte)eff.SelectedIndex);
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
			var msg = ImsgData.ForceGet(lbList.SelectedIndex);
			txtImsg.Text = Utils.ByteToString(msg, 0, Program.IMSG_DATA_BLOCK_LENGTH);
		}

		private void txtImsg_TextChanged(object sender, EventArgs e)
		{
			lblImsgCount.Text = string.Format("글자 수 {0}", txtImsg.Text.Length);
		}

        private void button1_Click(object sender, EventArgs e)
        {
            sangseong sangseong = new sangseong();
            sangseong.ShowDialog();
        }

	}
}