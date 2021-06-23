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
    public partial class ProjectController : UserControl
    {

        private bool _isEven;

        public ProjectController()
        {
            InitializeComponent();
        }


        private void ProjectController_Load(object sender, EventArgs e)
        {
            Program.ExeData.Open(System.IO.FileAccess.ReadWrite);
            InitTitleText();
            InitAbility();
            InitLevels();
            InitEtc();
            Program.ExeData.Close();
        }

        #region Title
        private void InitTitleText()
        {
            if(Program.CurrentConfig.Exe.TitleOffsets.Length == 1)
                TitleTextBox.Text = Program.ExeData.GetText(Program.CurrentConfig.Exe.TitleOffsets[0], 12);
            else
                TitleTextBox.Text = Program.ExeData.GetText(Program.CurrentConfig.Exe.TitleOffsets[1], 12);
        }

        private void TitleSaveButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (!Program.ExeData.IsLocked)
                {
                    Program.ExeData.Open(System.IO.FileAccess.ReadWrite);
                    if(Program.CurrentConfig.Exe.TitleOffsets.Length == 1)
                    {
                        Program.ExeData.WriteText(TitleTextBox.Text, Program.CurrentConfig.Exe.TitleOffsets[0], 12);
                    }
                    else
                    {
                        Program.ExeData.WriteText($"「{TitleTextBox.Text}」", Program.CurrentConfig.Exe.TitleOffsets[0], 16);
                        Program.ExeData.WriteText(TitleTextBox.Text, Program.CurrentConfig.Exe.TitleOffsets[1], 12);
                        Program.ExeData.WriteText(TitleTextBox.Text, Program.CurrentConfig.Exe.TitleOffsets[2], 12);
                        Program.ExeData.WriteText($"종료「{TitleTextBox.Text}」", Program.CurrentConfig.Exe.TitleOffsets[3], 20);
                        Program.ExeData.WriteText($"정말「{TitleTextBox.Text}」종료?", Program.CurrentConfig.Exe.TitleOffsets[4], 25);
                    }
                    Program.ExeData.Close();
                }
                if (!Data.Mp3Data.IsLocked)
                {
                    Data.Mp3Data.WriteText(TitleTextBox.Text, 0x5B9A, 12);
                }
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
            _isEven = Program.ExeData.ReadByte(0, checkInfo.offset) == Utils.GetCode(checkInfo.CodeArr)[0];
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
                    value = Program.ExeData.ReadByte(0, info.Offset);
                    if (_isEven) value *= 2;
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
            Program.ExeData.Open(System.IO.FileAccess.ReadWrite);
            if (_isEven)
            {
                var codes = Program.CurrentConfig.Codes["Even"];
                foreach(var code in codes)
                {
                    Program.ExeData.Write(Utils.GetCode(code.CodeArr), code.offset);
                }
            }
            else
            {
                var codes = Program.CurrentConfig.Codes["Odd"];
                foreach (var code in codes)
                {
                    Program.ExeData.Write(Utils.GetCode(code.CodeArr), code.offset);
                }
            }


            var grades = Program.CurrentConfig.Exe.AbilityGrades;
            for (int i = 0; i < grades.Length; i++)
            {
                var info = grades[i];
                
                if (i != grades.Length - 1)
                {
                    byte value = byte.Parse(AbilityGradeListView.Items[i].Text);
                    if (_isEven) value /= 2;
                    Program.ExeData.WriteByte(value, 0, info.Offset);
                }
            }

            Program.ExeData.Close();
        }
        #endregion

        #region Level
        private void InitLevels()
        {
            Program.ExeData.Open(System.IO.FileAccess.ReadWrite);

            var classUp1 = Program.ExeData.ReadByte(0, Program.CurrentConfig.Exe.ClassUpLevel1Offsets[0]);
            var classUp2 = Program.ExeData.ReadByte(0, Program.CurrentConfig.Exe.ClassUpLevel2Offsets[0]);
            ClassUpLevel1.Value = classUp1;
            ClassUpLevel2.Value = classUp2;

            var maxUnitLevel = Program.ExeData.ReadByte(0, Program.CurrentConfig.Exe.MaxUnitLevelOffsets[0]);
            MaxUnitLevel.Value = maxUnitLevel;
            var maxUnitExp = Program.ExeData.ReadByte(0, Program.CurrentConfig.Exe.MaxUnitExpOffsets[0]);
            MaxUnitExp.Value = maxUnitExp;

            var normalEquipExp = Program.ExeData.ReadByte(0, Program.CurrentConfig.Exe.NormalEquipExpOffsets[0]);
            NormalEquipExp.Value = normalEquipExp;

            var specialEquipExp = Program.ExeData.ReadByte(0, Program.CurrentConfig.Exe.SpecialEquipExpOffsets[0]);
            SpecialEquipExp.Value = specialEquipExp;

            var normalEquipLevel = Program.ExeData.ReadByte(0, Program.CurrentConfig.Exe.NormalEquipMaxLevelOffsets[0]);
            NormalEquipMaxLevel.Value = normalEquipLevel;

            var specialEquipLevel = Program.ExeData.ReadByte(0, Program.CurrentConfig.Exe.SpecialEquipMaxLevelOffsets[0]);
            SpecialEquipMaxLevel.Value = specialEquipLevel;

            var secondEquipLevel = Program.ExeData.ReadByte(0, Program.CurrentConfig.Exe.SecondEquipStartLevelOffsets[0]);
            SecondEquipStartLevel.Value = secondEquipLevel;

            var newUnitExploit = Program.ExeData.ReadByte(0, Program.CurrentConfig.Exe.NewUnitExploitOffsets[0]);
            NewUnitExploit.Value = newUnitExploit;

            var enemyUnitExploit = Program.ExeData.ReadByte(0, Program.CurrentConfig.Exe.EnemyUnitExploitOffsets[0]);
            EnemyUnitExploit.Value = enemyUnitExploit;

            var normalEquipUpLevel = Program.ExeData.ReadByte(0, Program.CurrentConfig.Exe.NormalEquipUpLevelOffsets[0]);
            NormalEquipStLevel.Value = normalEquipUpLevel;

            var specialEquipUpLevel = Program.ExeData.ReadByte(0, Program.CurrentConfig.Exe.SpecialEquipUpLevelOffsets[0]);
            SpecialEquipStLevel.Value = specialEquipUpLevel;

            Program.ExeData.Close();
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
            Program.ExeData.Open(System.IO.FileAccess.ReadWrite);

            var offsets = Program.CurrentConfig.Exe.ClassUpLevel1Offsets;
            foreach (var offset in offsets)
            {
                Program.ExeData.WriteByte((byte)ClassUpLevel1.Value, 0, offset);
            }

            offsets = Program.CurrentConfig.Exe.ClassUpLevel1Offsets;
            foreach (var offset in offsets)
            {
                Program.ExeData.WriteByte((byte)ClassUpLevel2.Value, 0, offset);
            }

            offsets = Program.CurrentConfig.Exe.MaxUnitLevelOffsets;
            foreach (var offset in offsets)
            {
                if (offset == offsets.Last())
                    Program.ExeData.WriteByte((byte)MaxUnitLevel.Value + 1, 0, offset);
                else
                    Program.ExeData.WriteByte((byte)MaxUnitLevel.Value, 0, offset);
            }

            offsets = Program.CurrentConfig.Exe.MaxUnitExpOffsets;
            foreach (var offset in offsets)
            {
                Program.ExeData.WriteByte((byte)MaxUnitExp.Value, 0, offset);
            }

            offsets = Program.CurrentConfig.Exe.NormalEquipExpOffsets;
            foreach (var offset in offsets)
            {
                Program.ExeData.WriteByte((byte)NormalEquipExp.Value, 0, offset);
            }

            offsets = Program.CurrentConfig.Exe.SpecialEquipExpOffsets;
            foreach (var offset in offsets)
            {
                Program.ExeData.WriteByte((byte)SpecialEquipExp.Value, 0, offset);
            }

            offsets = Program.CurrentConfig.Exe.NormalEquipMaxLevelOffsets;
            foreach (var offset in offsets)
            {
                Program.ExeData.WriteByte((byte)NormalEquipMaxLevel.Value, 0, offset);
            }

            offsets = Program.CurrentConfig.Exe.SpecialEquipMaxLevelOffsets;
            foreach (var offset in offsets)
            {
                if(offset == offsets.Last())
                    Program.ExeData.WriteByte((byte)SpecialEquipMaxLevel.Value + 1, 0, offset);
                else
                    Program.ExeData.WriteByte((byte)SpecialEquipMaxLevel.Value, 0, offset);
            }

            offsets = Program.CurrentConfig.Exe.SecondEquipStartLevelOffsets;
            foreach (var offset in offsets)
            {
                Program.ExeData.WriteByte((byte)SecondEquipStartLevel.Value, 0, offset);
            }

            offsets = Program.CurrentConfig.Exe.NewUnitExploitOffsets;
            foreach (var offset in offsets)
            {
                Program.ExeData.WriteByte((byte)NewUnitExploit.Value, 0, offset);
            }

            offsets = Program.CurrentConfig.Exe.EnemyUnitExploitOffsets;
            foreach (var offset in offsets)
            {
                Program.ExeData.WriteByte((byte)EnemyUnitExploit.Value, 0, offset);
            }

            offsets = Program.CurrentConfig.Exe.NormalEquipUpLevelOffsets;
            foreach (var offset in offsets)
            {
                Program.ExeData.WriteByte((byte)NormalEquipStLevel.Value, 0, offset);
            }

            offsets = Program.CurrentConfig.Exe.SpecialEquipUpLevelOffsets;
            foreach (var offset in offsets)
            {
                Program.ExeData.WriteByte((byte)SpecialEquipStLevel.Value, 0, offset);
            }

            Program.ExeData.Close();

        }
        #endregion

        #region Etc
        private void InitEtc()
        {
            SpecialAppearForceList1.Items.AddRange(ConfigUtils.GetForceNames(Program.FORMATSTRING_KEYVALUEPAIR_HEX2).Values.ToArray());
            SpecialAppearForceList1.Items.Add("50,미사용");
            SpecialAppearForceList2.Items.AddRange(ConfigUtils.GetForceNames(Program.FORMATSTRING_KEYVALUEPAIR_HEX2).Values.ToArray());
            SpecialAppearForceList2.Items.Add("50,미사용");
            KnockBackForceList.Items.AddRange(ConfigUtils.GetForceNames(Program.FORMATSTRING_KEYVALUEPAIR_HEX2).Values.ToArray());
            KnockBackForceList.Items.Add("50,미사용");
            SpecialSkillDmgForceList.Items.AddRange(ConfigUtils.GetForceCategoryNames(Program.FORMATSTRING_KEYVALUEPAIR_HEX2).Values.ToArray());
            SpecialSkillDmgForceList.Items.Add("28,미사용");

            var specialAppear1 = Program.ExeData.ReadByte(0, Program.CurrentConfig.Exe.SpecialAppear_ForceIndexOffset[0]);
            var specialAppear2 = Program.ExeData.ReadByte(0, Program.CurrentConfig.Exe.SpecialAppear_ForceIndexOffset[1]);
            SpecialAppearForceList1.SelectedIndex = SpecialAppearForceList1.FindString(Utils.GetString(specialAppear1));
            SpecialAppearForceList2.SelectedIndex = SpecialAppearForceList2.FindString(Utils.GetString(specialAppear2));

            var knockback = Program.ExeData.ReadByte(0, Program.CurrentConfig.Exe.Knock_Back_ForceIndexOffset);
            KnockBackForceList.SelectedIndex = KnockBackForceList.FindString(Utils.GetString(knockback));

            var specialSkillDmg = Program.ExeData.ReadByte(0, Program.CurrentConfig.Exe.SpecialSkillDmg_ForceCategoryIndexOffset);
            SpecialSkillDmgForceList.SelectedIndex = SpecialSkillDmgForceList.FindString(Utils.GetString(specialSkillDmg));
        }
        #endregion

        private void EtcSave_Click(object sender, EventArgs e)
        {
            Program.ExeData.Open(System.IO.FileAccess.ReadWrite);

            var offset = Program.CurrentConfig.Exe.SpecialAppear_ForceIndexOffset[0];
            Program.ExeData.WriteByte((byte)SpecialAppearForceList1.SelectedIndex, 0, offset);

            offset = Program.CurrentConfig.Exe.SpecialAppear_ForceIndexOffset[1];
            Program.ExeData.WriteByte((byte)SpecialAppearForceList2.SelectedIndex, 0, offset);

            offset = Program.CurrentConfig.Exe.Knock_Back_ForceIndexOffset;
            Program.ExeData.WriteByte((byte)KnockBackForceList.SelectedIndex, 0, offset);

            offset = Program.CurrentConfig.Exe.SpecialSkillDmg_ForceCategoryIndexOffset;
            Program.ExeData.WriteByte((byte)SpecialSkillDmgForceList.SelectedIndex, 0, offset);

            Program.ExeData.Close();
        }
    }
}
