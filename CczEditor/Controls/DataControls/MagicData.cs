#region using List

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
            mda1.Enabled = mda2.Enabled = dp1.Enabled = dp2.Enabled = dp3.Enabled = dp4.Enabled = m0.Enabled = m1.Enabled = m2.Enabled = m3.Enabled = m4.Enabled = m5.Enabled = m6.Enabled = m7.Enabled = m8.Enabled = m9.Enabled = button1.Enabled = ExeDataLoaded;
			txtImsg.Enabled = ImsgDataLoaded;
			GetResourcesHitarea();
			GetResourcesEffarea();
		}

		private void MagicData_Load(object sender, EventArgs e)
		{
			cbHitarea.Items.AddRange(Program.CurrentConfig.Hitareas.ToArray());
			cbEffarea.Items.AddRange(Program.CurrentConfig.Effareas.ToArray());
            var forceNames = Program.CurrentConfig.ForceNames;
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
			for (var i = 0; i < Program.CurrentConfig.Forces.Count; i++)
			{
				lvLearnLv.Items[i].Text = magic[17+i].ToString();
			}
			if (ImsgDataLoaded)
			{
				btnImsgRestore_Click();
			}
            if (ExeDataLoaded)
            {
                if (lbList.SelectedIndex >= Program.CurrentConfig.Offsets["Exe_Magic_MagicT_Start"] && lbList.SelectedIndex <= Program.CurrentConfig.Offsets["Exe_Magic_MagicT_End"])
                {
                    m0.Enabled = true;
                    m0.SelectedIndex = Program.ExeData.magicload(lbList.SelectedIndex - (Program.CurrentConfig.Offsets["Exe_Magic_MagicT_Start"]), "Exe_Magic_MagicT_Offset");
                }
                else
                {
                    m0.Enabled = false;
                    m0.SelectedIndex = -1;
                }

                if (lbList.SelectedIndex >= Program.CurrentConfig.Offsets["Exe_Magic_DamgT_Start"] && lbList.SelectedIndex <= Program.CurrentConfig.Offsets["Exe_Magic_DamgT_End"])
                {
                    m1.Enabled = true;
                    m1.SelectedIndex = Program.ExeData.magicload(lbList.SelectedIndex - (Program.CurrentConfig.Offsets["Exe_Magic_DamgT_Start"]), "Exe_Magic_DamgT_Offset");
                }
                else
                {
                    m1.Enabled = false;
                    m1.SelectedIndex = -1;
                }

                if (lbList.SelectedIndex >= Program.CurrentConfig.Offsets["Exe_Magic_CureT_Start"] && lbList.SelectedIndex <= Program.CurrentConfig.Offsets["Exe_Magic_CureT_End"])
                {
                    m2.Enabled = true;
                    m2.SelectedIndex = Program.ExeData.magicload(lbList.SelectedIndex - (Program.CurrentConfig.Offsets["Exe_Magic_CureT_Start"]), "Exe_Magic_CureT_Offset");
                }
                else
                {
                    m2.Enabled = false;
                    m2.SelectedIndex = -1;
                }

                if (lbList.SelectedIndex >= Program.CurrentConfig.Offsets["Exe_Magic_Meff_Start"] && lbList.SelectedIndex <= Program.CurrentConfig.Offsets["Exe_Magic_Meff_End"])
                {
                    m3.Enabled = true;
                    m3.Value = Program.ExeData.magicload(lbList.SelectedIndex - (Program.CurrentConfig.Offsets["Exe_Magic_Meff_Start"]), "Exe_Magic_Meff_Offset");
                }
                else
                {
                    m3.Enabled = false;
                    m3.Value = 0;
                }

                if (lbList.SelectedIndex >= Program.CurrentConfig.Offsets["Exe_Magic_Mcall_Start"] && lbList.SelectedIndex <= Program.CurrentConfig.Offsets["Exe_Magic_Mcall_End"])
                {
                    m4.Enabled = true;
                    m4.SelectedIndex = Program.ExeData.magicload(lbList.SelectedIndex - (Program.CurrentConfig.Offsets["Exe_Magic_Mcall_Start"]), "Exe_Magic_Mcall_Offset");
                   
                }
                else
                {
                    m4.Enabled = false;
                    m4.SelectedIndex = -1;
                }

                if (lbList.SelectedIndex >= Program.CurrentConfig.Offsets["Exe_Magic_AI_Start"] && lbList.SelectedIndex <= Program.CurrentConfig.Offsets["Exe_Magic_AI_End"])
                {
                    m5.Enabled = true;
                    m5.SelectedIndex = Program.ExeData.magicload(lbList.SelectedIndex - (Program.CurrentConfig.Offsets["Exe_Magic_AI_Start"]), "Exe_Magic_AI_Offset");

                }
                else
                {
                    m5.Enabled = false;
                    m5.SelectedIndex = -1;
                }

                if (lbList.SelectedIndex >= Program.CurrentConfig.Offsets["Exe_Magic_Cond_Start"] && lbList.SelectedIndex <= Program.CurrentConfig.Offsets["Exe_Magic_Cond_End"])
                {
                    m6.Enabled = true;
                    m6.SelectedIndex = Program.ExeData.magicload(lbList.SelectedIndex - (Program.CurrentConfig.Offsets["Exe_Magic_Cond_Start"]), "Exe_Magic_Cond_Offset");

                }
                else
                {
                    m6.Enabled = false;
                    m6.SelectedIndex = -1;
                }

                if (lbList.SelectedIndex >= Program.CurrentConfig.Offsets["Exe_Magic_Learn_Start"] && lbList.SelectedIndex <= Program.CurrentConfig.Offsets["Exe_Magic_Learn_End"])
                {
                    m7.Enabled = true;
                    m7.Value = Program.ExeData.magicload(lbList.SelectedIndex - (Program.CurrentConfig.Offsets["Exe_Magic_Learn_Start"]), "Exe_Magic_Learn_Offset");

                }
                else
                {
                    m7.Enabled = false;
                    m7.Value = -1;
                }

                if (lbList.SelectedIndex >= Program.CurrentConfig.Offsets["Exe_Magic_Damg_Start"] && lbList.SelectedIndex <= Program.CurrentConfig.Offsets["Exe_Magic_Damg_End"])
                {
                    m8.Enabled = true;
                    m8.Value = Program.ExeData.magicload(lbList.SelectedIndex - (Program.CurrentConfig.Offsets["Exe_Magic_Damg_Start"]), "Exe_Magic_Damg_Offset");

                }
                else
                {
                    m8.Enabled = false;
                    m8.Value = 0;
                }

                if (lbList.SelectedIndex >= Program.CurrentConfig.Offsets["Exe_Magic_HitP_Start"] && lbList.SelectedIndex <= Program.CurrentConfig.Offsets["Exe_Magic_HitP_End"])
                {
                    m9.Enabled = true;
                    m9.Value = Program.ExeData.magicload(lbList.SelectedIndex - (Program.CurrentConfig.Offsets["Exe_Magic_HitP_Start"]), "Exe_Magic_HitP_Offset");

                }
                else
                {
                    m9.Enabled = false;
                    m9.Value = 0;
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
			for (var i = 0; i < Program.CurrentConfig.Forces.Count; i++)
			{
				magic[17+i] = byte.Parse(lvLearnLv.Items[i].Text);
			}
			GameData.MagicSet(index, magic);

            //Imsg
            var msg = ImsgData.MagicGet(lbList.SelectedIndex);
            Utils.ChangeByteValue(msg, Utils.GetBytes(txtImsg.Text), 0, Program.IMSG_DATA_BLOCK_LENGTH);
            ImsgData.MagicSet(lbList.SelectedIndex, msg);


            //EXE
            if (ExeDataLoaded)
            {
                if (lbList.SelectedIndex >= Program.CurrentConfig.Offsets["Exe_Magic_MagicT_Start"] && lbList.SelectedIndex <= Program.CurrentConfig.Offsets["Exe_Magic_MagicT_End"])
                {
                    Program.ExeData.magicsave(lbList.SelectedIndex - (Program.CurrentConfig.Offsets["Exe_Magic_MagicT_Start"]), "Exe_Magic_MagicT_Offset", (byte)m0.SelectedIndex);
                }

                if (lbList.SelectedIndex >= Program.CurrentConfig.Offsets["Exe_Magic_DamgT_Start"] && lbList.SelectedIndex <= Program.CurrentConfig.Offsets["Exe_Magic_DamgT_End"])
                {
                    Program.ExeData.magicsave(lbList.SelectedIndex - (Program.CurrentConfig.Offsets["Exe_Magic_DamgT_Start"]), "Exe_Magic_DamgT_Offset", (byte)m1.SelectedIndex);
                }

                if (lbList.SelectedIndex >= Program.CurrentConfig.Offsets["Exe_Magic_CureT_Start"] && lbList.SelectedIndex <= Program.CurrentConfig.Offsets["Exe_Magic_CureT_End"])
                {
                    Program.ExeData.magicsave(lbList.SelectedIndex - (Program.CurrentConfig.Offsets["Exe_Magic_CureT_Start"]), "Exe_Magic_CureT_Offset", (byte)m2.SelectedIndex);
                }

                if (lbList.SelectedIndex >= Program.CurrentConfig.Offsets["Exe_Magic_Meff_Start"] && lbList.SelectedIndex <= Program.CurrentConfig.Offsets["Exe_Magic_Meff_End"])
                {
                    Program.ExeData.magicsave(lbList.SelectedIndex - (Program.CurrentConfig.Offsets["Exe_Magic_Meff_Start"]), "Exe_Magic_Meff_Offset", (byte)m3.Value);
                }

                if (lbList.SelectedIndex >= Program.CurrentConfig.Offsets["Exe_Magic_Mcall_Start"] && lbList.SelectedIndex <= Program.CurrentConfig.Offsets["Exe_Magic_Mcall_End"])
                {
                    Program.ExeData.magicsave(lbList.SelectedIndex - (Program.CurrentConfig.Offsets["Exe_Magic_Mcall_Start"]), "Exe_Magic_Mcall_Offset", (byte)m4.SelectedIndex);
                }

                if (lbList.SelectedIndex >= Program.CurrentConfig.Offsets["Exe_Magic_AI_Start"] && lbList.SelectedIndex <= Program.CurrentConfig.Offsets["Exe_Magic_AI_End"])
                {
                    Program.ExeData.magicsave(lbList.SelectedIndex - (Program.CurrentConfig.Offsets["Exe_Magic_AI_Start"]), "Exe_Magic_AI_Offset", (byte)m5.SelectedIndex);
                }

                if (lbList.SelectedIndex >= Program.CurrentConfig.Offsets["Exe_Magic_Cond_Start"] && lbList.SelectedIndex <= Program.CurrentConfig.Offsets["Exe_Magic_Cond_End"])
                {
                    Program.ExeData.magicsave(lbList.SelectedIndex - (Program.CurrentConfig.Offsets["Exe_Magic_Cond_Start"]), "Exe_Magic_Cond_Offset", (byte)m6.SelectedIndex);
                }

                if (lbList.SelectedIndex >= Program.CurrentConfig.Offsets["Exe_Magic_Learn_Start"] && lbList.SelectedIndex <= Program.CurrentConfig.Offsets["Exe_Magic_Learn_End"])
                {
                    Program.ExeData.magicsave(lbList.SelectedIndex - (Program.CurrentConfig.Offsets["Exe_Magic_Learn_Start"]), "Exe_Magic_Learn_Offset", (byte)m7.Value);
                }

                if (lbList.SelectedIndex >= Program.CurrentConfig.Offsets["Exe_Magic_Damg_Start"] && lbList.SelectedIndex <= Program.CurrentConfig.Offsets["Exe_Magic_Damg_End"])
                {
                    Program.ExeData.magicsave(lbList.SelectedIndex - (Program.CurrentConfig.Offsets["Exe_Magic_Damg_Start"]), "Exe_Magic_Damg_Offset", (byte)m8.Value);
                }

                if (lbList.SelectedIndex >= Program.CurrentConfig.Offsets["Exe_Magic_HitP_Start"] && lbList.SelectedIndex <= Program.CurrentConfig.Offsets["Exe_Magic_HitP_End"])
                {
                    Program.ExeData.magicsave(lbList.SelectedIndex - (Program.CurrentConfig.Offsets["Exe_Magic_HitP_Start"]), "Exe_Magic_HitP_Offset", (byte)m9.Value);
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
            var icon = IconResources.ExtractIconFromFile(Path.Combine(GameData.CurrentFile.DirectoryName, Program.FILENAME_MAGICICON), (int)ncMagicIcon.Value, true);
			pbIcon.Image = icon == null ? null : icon.ToBitmap();
		}



	}
}