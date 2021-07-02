#region using List

using System.Windows.Forms;
using System;
using System.Linq;
using System.Text;

#endregion

namespace CczEditor.Controls.DataControls
{
	public partial class ForceController : BaseDataControl
    {
        Data.Wrapper.ForceData CurrentData;

        public ForceController()
		{
			InitializeComponent();
            if (Program.CurrentConfig.CodeOptionContainer.AIExtension)
            {
                forceAI.Enabled = true;
            }
            else
            {
                forceAI.Enabled = false;
            }
            txtImsg.Enabled = ImsgDataLoaded;
            GetResourcesHitarea();
            GetResourcesEffarea();
		}

		private void ForceData_Load(object sender, EventArgs e)
        {
            var equipmentTypes = ConfigUtils.GetEquipmentTypes(Program.ExeData, Program.CurrentConfig, Program.FORMATSTRING_KEYVALUEPAIR_HEX2);
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
            cbEffArea.Items.AddRange(Program.CurrentConfig.EffAreaNames.ToArray());
            lbList.Items.AddRange(ConfigUtils.GetForceNames(Program.ExeData, Program.CurrentConfig, Program.FORMATSTRING_KEYVALUEPAIR_HEX2).Values.ToArray());
		}

        public override void Reset()
        {
            base.Reset();
            CurrentData = new Data.Wrapper.ForceData();
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

            ncMove.Value = CurrentData.Mov;
            cbHitarea.SelectedIndex = CurrentData.HitArea;
            ncAtk.Value = CurrentData.Atk;
            ncDef.Value = CurrentData.Def;
            ncMag.Value = CurrentData.Spr;
            ncCrt.Value = CurrentData.Cri;
            ncMor.Value = CurrentData.Mor;
            ncHp.Value = CurrentData.Hp;
            ncMp.Value = CurrentData.Mp;

            for (var i = 0; i < CurrentData.EquipTypeList.Length; i++)
            {
                clbEquipment.SetItemChecked(i, CurrentData.EquipTypeList[i] == 0x01);
            }

            txtImsg.Text = CurrentData.Imsg;

            ForceNameBox.Text = CurrentData.ForceName;
            forceCategoryNameBox.Text = CurrentData.ForceCategoryName;
            forceMoveSound.SelectedIndex = CurrentData.MoveSound;
            forceMoveSpeed.SelectedIndex = CurrentData.MoveSpeed;
            forceAtkSound.SelectedIndex = CurrentData.AtkSound;
            forceRangeAtk.SelectedIndex = CurrentData.RangeAtk;
            forceType.SelectedIndex = CurrentData.ForceType;
            forceMagicDmg.Value = CurrentData.MagicDmg;
            forceAtkDelay.SelectedIndex = CurrentData.AtkDelay;
            forceAtkComm.SelectedIndex = CurrentData.AtkComm;
            if (Program.CurrentConfig.CodeOptionContainer.AIExtension)
            {
                forceAI.SelectedIndex = CurrentData.ForceAI;
            }
            cbEffArea.SelectedIndex = CurrentData.EffArea;

            SpecialSkillForce.SelectedIndex = CurrentData.SpecialSkillForce;
            
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

            int index = lbList.SelectedIndex;
            CurrentData.Mov = (byte)ncMove.Value;
            CurrentData.HitArea = (byte)cbHitarea.SelectedIndex;
            CurrentData.Atk = (byte)ncAtk.Value;
            CurrentData.Def = (byte)ncDef.Value;
            CurrentData.Spr = (byte)ncMag.Value;
            CurrentData.Cri = (byte)ncCrt.Value;
            CurrentData.Mor = (byte)ncMor.Value;
            CurrentData.Hp = (byte)ncHp.Value;
            CurrentData.Mp = (byte)ncMp.Value;
            for (var i = 0; i < clbEquipment.Items.Count; i++)
            {
                CurrentData.EquipTypeList[i] = (byte)(clbEquipment.GetItemChecked(i) ? 0x01 : 0x00);
            }

            if (ImsgDataLoaded)
            {
                CurrentData.Imsg = txtImsg.Text;
            }
            
            CurrentData.ForceName = ForceNameBox.Text;
            CurrentData.ForceCategoryName = forceCategoryNameBox.Text;
            CurrentData.MoveSound = (byte)forceMoveSound.SelectedIndex;
            CurrentData.MoveSpeed = (byte)forceMoveSpeed.SelectedIndex;
            CurrentData.AtkSound = (byte)forceAtkSound.SelectedIndex;
            CurrentData.RangeAtk = (byte)forceRangeAtk.SelectedIndex;
            CurrentData.ForceType = (byte)forceType.SelectedIndex;
            CurrentData.MagicDmg = (byte)forceMagicDmg.Value;
            CurrentData.AtkDelay = (byte)forceAtkDelay.SelectedIndex;
            CurrentData.AtkComm = (byte)forceAtkComm.SelectedIndex;
            CurrentData.ForceAI = (byte)forceAI.SelectedIndex;
            CurrentData.EffArea = (byte)cbEffArea.SelectedIndex;
            CurrentData.SpecialSkillForce = (byte)SpecialSkillForce.SelectedIndex;
            
            CurrentData.Write(index, Program.GameData, Program.ImsgData, Program.ExeData, Program.CurrentConfig);
            
            lbList.Items.RemoveAt(index);
            lbList.Items.Insert(index, string.Format(Program.FORMATSTRING_KEYVALUEPAIR_HEX2, index, CurrentData.ForceName));
            lbList.SelectedIndex = index;
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
                pbEffarea.Image = cbEffArea.SelectedIndex == -1 ? null : Effareas.GetImage(cbEffArea.SelectedIndex);
            }
        }
        
		private void txtImsg_TextChanged(object sender, EventArgs e)
        {
            int length = Encoding.Default.GetByteCount(txtImsg.Text);
            lblImsgCount.Text = $"{length} / 200 byte";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ForceSynastryController sangseong = new ForceSynastryController();
            sangseong.ShowDialog();
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            var list = ConfigUtils.GetForceNames(Program.ExeData, Program.CurrentConfig).Values.ToList();
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