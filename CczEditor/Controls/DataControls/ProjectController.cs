using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CczEditor.Controls.DataControls
{
    public partial class ProjectController : BaseControl
    {
        private Data.Wrapper.ProjectData CurrentData;
        private bool _isEven;

        public ProjectController()
        {
            InitializeComponent();
        }


        private void ProjectController_Load(object sender, EventArgs e)
        {

            var forceNames = ConfigUtils.GetForceNames(Program.ExeData, Program.CurrentConfig, Program.FORMATSTRING_KEYVALUEPAIR_HEX2).Values.ToArray();
            var forceCategoryNames = ConfigUtils.GetForceCategoryNames(Program.ExeData, Program.CurrentConfig, Program.FORMATSTRING_KEYVALUEPAIR_HEX2).Values.ToArray();
            SpecialAppearForceList1.Items.AddRange(forceNames);
            SpecialAppearForceList1.Items.Add("50,미사용");
            SpecialAppearForceList2.Items.AddRange(forceNames);
            SpecialAppearForceList2.Items.Add("50,미사용");
            KnockBackForceList.Items.AddRange(forceNames);
            KnockBackForceList.Items.Add("50,미사용");
            cbMagicBlock.Items.AddRange(forceNames);
            cbMagicBlock.Items.Add("50,미사용");
            cbNeighborHPRec.Items.AddRange(forceNames);
            cbNeighborHPRec.Items.Add("50,미사용");
            cbNeighborMorInc.Items.AddRange(forceNames);
            cbNeighborMorInc.Items.Add("50,미사용");

            cbNeighborAwaken.Items.AddRange(forceCategoryNames);
            cbNeighborAwaken.Items.Add("28,미사용");
            SpecialSkillDmgForceList.Items.AddRange(forceCategoryNames);
            SpecialSkillDmgForceList.Items.Add("28,미사용");
            cbNeighborMpRec.Items.AddRange(forceCategoryNames);
            cbNeighborMpRec.Items.Add("28,미사용");
        }

        public override void Reset()
        {
            base.Reset();
            CurrentData = new Data.Wrapper.ProjectData();
            InitTitleText();
            InitAbility();
            InitLevels();
            InitEtc();
        }

        #region Title
        private void InitTitleText()
        {
            CurrentData.ReadTitle(Program.ExeData, Program.CurrentConfig);
            TitleTextBox.Text = CurrentData.TitleText;
        }

        private void TitleSaveButton_Click(object sender, EventArgs e)
        {
            try
            {
                CurrentData.WriteTitle(Program.ExeData, Program.CurrentConfig);
                MessageBox.Show("수정 성공!");

            }
            catch
            {
                MessageBox.Show("오류가 발생했습니다!");

            }
        }

        private void TitleTextBox_TextChanged(object sender, EventArgs e)
        {
            int length = Encoding.Default.GetByteCount(TitleTextBox.Text);
            TitleLengthText.Text = $"{length}/12 byte";

        }
        #endregion

        #region Ability
        private void InitAbility()
        {
            AbilityGradeListView.Items.Clear();

            CurrentData.ReadAbility(Program.ExeData, Program.CurrentConfig);

            var grades = Program.CurrentConfig.Exe.AbilityGrades;
            for (int i = 0; i < grades.Length; i++)
            {
                var info = grades[i];
                var item = new ListViewItem { Text = "0" };
                item.SubItems.Add(new ListViewItem.ListViewSubItem { Text = info.Name });
                AbilityGradeListView.Items.Add(item);
            }

            var evenCode = Program.CurrentConfig.Codes["Even"];
            var checkInfo = evenCode.Last();
            _isEven = CurrentData.IsEven;
            EvenType.Checked = _isEven;
            OddType.Checked = !_isEven;

            RefreshAbility();
        }
        
        private void AbilityGradeListView_ItemActivate(object sender, EventArgs e)
        {
            if (AbilityGradeListView.SelectedItems.Count > 0)
            {
                AbilityGradeListView.SelectedItems[0].BeginEdit();
            }
        }

        private void AbilityGradeListView_AfterLabelEdit(object sender, LabelEditEventArgs e)
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

        private void RefreshAbility()
        {
            var grades = Program.CurrentConfig.Exe.AbilityGrades;
            for (int i = 0; i < grades.Length; i++)
            {
                var info = grades[i];

                int value = 0;
                if (i != grades.Length - 1)
                {
                    value = CurrentData.AbilityGrades[i];
                    if (CurrentData.IsEven) value *= 2;
                }
                AbilityGradeListView.Items[i].Text = value.ToString();
            }
        }
        
        private void OddType_CheckedChanged(object sender, EventArgs e)
        {
            _isEven = !OddType.Checked;
            RefreshAbility();
        }

        private void AbilitySave_Click(object sender, EventArgs e)
        {
            CurrentData.IsEven = _isEven;

            var grades = Program.CurrentConfig.Exe.AbilityGrades;
            for (int i = 0; i < grades.Length; i++)
            {
                CurrentData.AbilityGrades[i] = byte.Parse(AbilityGradeListView.Items[i].Text);
            }

            CurrentData.WriteAbility(Program.ExeData, Program.CurrentConfig);
        }
        #endregion

        #region Level
        private void InitLevels()
        {
            CurrentData.ReadLevels(Program.ExeData, Program.CurrentConfig);

            ClassUpLevel1.Value = CurrentData.ClassUp[0];
            ClassUpLevel2.Value = CurrentData.ClassUp[1];
            MaxUnitLevel.Value = CurrentData.MaxUnitLevel;
            MaxUnitExp.Value = CurrentData.MaxUnitExp;
            NormalEquipExp.Value = CurrentData.NormalEquipExp;
            SpecialEquipExp.Value = CurrentData.SpecialEquipExp;
            NormalEquipMaxLevel.Value = CurrentData.NormalEquipLevel;
            SpecialEquipMaxLevel.Value = CurrentData.SpecialEquipLevel;
            SecondEquipStartLevel.Value = CurrentData.SecondEquipLevel;
            NewUnitExploit.Value = CurrentData.NewUnitExploit;
            EnemyUnitExploit.Value = CurrentData.EnemyUnitExploit;
            NormalEquipStLevel.Value = CurrentData.NormalEquipUpLevel;
            SpecialEquipStLevel.Value = CurrentData.SpecialEquipUpLevel;
        }

        private void ClassUpLevel1_ValueChanged(object sender, EventArgs e)
        {
            ClassUpLevel2.Value = ClassUpLevel1.Value * 2;
        }

        private void NormalEquipMaxLevel_ValueChanged(object sender, EventArgs e)
        {
            RefreshSecondEquipLevel((int)NormalEquipMaxLevel.Value, (int)NormalEquipStLevel.Value);
        }

        private void NormalEquipStLevel_ValueChanged(object sender, EventArgs e)
        {
            RefreshSecondEquipLevel((int)NormalEquipMaxLevel.Value, (int)NormalEquipStLevel.Value);
        }

        private void RefreshSecondEquipLevel(int normalEquipMaxLevel, int normalEquipUpLevel)
        {
            SecondEquipStartLevel.Value = normalEquipMaxLevel * normalEquipUpLevel;
        }

        private void LevelSaveButton_Click(object sender, EventArgs e)
        {
            CurrentData.ClassUp[0] = (byte)ClassUpLevel1.Value;
            CurrentData.ClassUp[1] = (byte)ClassUpLevel2.Value;

            CurrentData.MaxUnitLevel = (byte)MaxUnitLevel.Value;
            CurrentData.MaxUnitExp = (byte)MaxUnitExp.Value;

            CurrentData.NormalEquipExp = (byte)NormalEquipExp.Value;
            CurrentData.SpecialEquipExp = (byte)SpecialEquipExp.Value;
            CurrentData.NormalEquipLevel = (byte)NormalEquipMaxLevel.Value;
            CurrentData.SpecialEquipLevel = (byte)SpecialEquipMaxLevel.Value;

            CurrentData.SecondEquipLevel = (byte)SecondEquipStartLevel.Value;
            CurrentData.NewUnitExploit = (byte) NewUnitExploit.Value;
            CurrentData.EnemyUnitExploit = (byte)EnemyUnitExploit.Value;
            CurrentData.NormalEquipLevel = (byte)NormalEquipStLevel.Value;
            CurrentData.SpecialEquipLevel = (byte)SpecialEquipStLevel.Value;
            CurrentData.WriteLevel(Program.ExeData, Program.CurrentConfig);
        }
        #endregion

        #region Etc
        private void InitEtc()
        {
            CurrentData.ReadEtc(Program.ExeData, Program.CurrentConfig);
            
            SpecialAppearForceList1.SelectedIndex = SpecialAppearForceList1.FindString(Utils.GetString(CurrentData.SpecialAppearForce[0]));
            SpecialAppearForceList2.SelectedIndex = SpecialAppearForceList2.FindString(Utils.GetString(CurrentData.SpecialAppearForce[1]));
            
            KnockBackForceList.SelectedIndex = KnockBackForceList.FindString(Utils.GetString(CurrentData.KnockBackForce));
            
            SpecialSkillDmgForceList.SelectedIndex = SpecialSkillDmgForceList.FindString(Utils.GetString(CurrentData.SpecialSkillDmgForce));

            cbMagicBlock.SelectedIndex = cbMagicBlock.FindString(Utils.GetString(CurrentData.MagicBlockForce));
            cbNeighborAwaken.SelectedIndex = cbNeighborAwaken.FindString(Utils.GetString(CurrentData.NeighborAwakenForce));
            cbNeighborHPRec.SelectedIndex = cbNeighborHPRec.FindString(Utils.GetString(CurrentData.NeighborHpRecForce));
            cbNeighborMpRec.SelectedIndex = cbNeighborMpRec.FindString(Utils.GetString(CurrentData.NeighborMpRecForce));
            cbNeighborMorInc.SelectedIndex = cbNeighborMorInc.FindString(Utils.GetString(CurrentData.NeighborMorIncForce));
        }
        #endregion

        private void EtcSave_Click(object sender, EventArgs e)
        {
            CurrentData.SpecialAppearForce[0] = (byte)SpecialAppearForceList1.SelectedIndex;
            CurrentData.SpecialAppearForce[1] = (byte)SpecialAppearForceList2.SelectedIndex;
            CurrentData.KnockBackForce = (byte)KnockBackForceList.SelectedIndex;
            CurrentData.SpecialSkillDmgForce = (byte)SpecialSkillDmgForceList.SelectedIndex;


            CurrentData.MagicBlockForce = (byte)cbMagicBlock.SelectedIndex;
            CurrentData.NeighborAwakenForce = (byte)cbNeighborAwaken.SelectedIndex;
            CurrentData.NeighborHpRecForce = (byte)cbNeighborHPRec.SelectedIndex;
            CurrentData.NeighborMpRecForce = (byte)cbNeighborMpRec.SelectedIndex;
            CurrentData.NeighborMorIncForce = (byte)cbNeighborMorInc.SelectedIndex;

            CurrentData.WriteEtc(Program.ExeData, Program.CurrentConfig);
        }
    }
}
