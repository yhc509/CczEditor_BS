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
            Data.ExeData.Open(System.IO.FileAccess.ReadWrite);
            InitTitleText();
            InitAbility();
            InitLevels();
            Data.ExeData.Close();
        }

        #region Title
        private void InitTitleText()
        {
            TitleTextBox.Text = Data.ExeData.GetText(Program.CurrentConfig.Exe.TitleOffsets[1], 12);
        }

        private void TitleSaveButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (!Data.ExeData.IsLocked)
                {
                    Data.ExeData.Open(System.IO.FileAccess.ReadWrite);
                    Data.ExeData.WriteText($"「{TitleTextBox.Text}」", Program.CurrentConfig.Exe.TitleOffsets[0], 16);
                    Data.ExeData.WriteText(TitleTextBox.Text, Program.CurrentConfig.Exe.TitleOffsets[1], 12);
                    Data.ExeData.WriteText(TitleTextBox.Text, Program.CurrentConfig.Exe.TitleOffsets[2], 12);
                    Data.ExeData.WriteText($"종료「{TitleTextBox.Text}」", Program.CurrentConfig.Exe.TitleOffsets[3], 20);
                    Data.ExeData.WriteText($"정말「{TitleTextBox.Text}」종료?", Program.CurrentConfig.Exe.TitleOffsets[4], 25);
                    Data.ExeData.Close();
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
            _isEven = Data.ExeData.ReadByte(0, checkInfo.offset) == Utils.GetCode(checkInfo.CodeArr)[0];
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
                    value = Data.ExeData.ReadByte(0, info.Offset);
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
            Data.ExeData.Open(System.IO.FileAccess.ReadWrite);
            if (_isEven)
            {
                var codes = Program.CurrentConfig.Codes["Even"];
                foreach(var code in codes)
                {
                    Data.ExeData.Write(Utils.GetCode(code.CodeArr), code.offset);
                }
            }
            else
            {
                var codes = Program.CurrentConfig.Codes["Odd"];
                foreach (var code in codes)
                {
                    Data.ExeData.Write(Utils.GetCode(code.CodeArr), code.offset);
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
                    Data.ExeData.WriteByte(value, 0, info.Offset);
                }
            }

            Data.ExeData.Close();
        }
        #endregion

        #region Level
        private void InitLevels()
        {
            Data.ExeData.Open(System.IO.FileAccess.ReadWrite);

            var classUp1 = Data.ExeData.ReadByte(0, Program.CurrentConfig.Exe.ClassUpLevel1Offsets[0]);
            var classUp2 = Data.ExeData.ReadByte(0, Program.CurrentConfig.Exe.ClassUpLevel2Offsets[0]);
            ClassUpLevel1.Value = classUp1;
            ClassUpLevel2.Value = classUp2;

            var maxUnitLevel = Data.ExeData.ReadByte(0, Program.CurrentConfig.Exe.MaxUnitLevelOffsets[0]);
            MaxUnitLevel.Value = maxUnitLevel;
            var maxUnitExp = Data.ExeData.ReadByte(0, Program.CurrentConfig.Exe.MaxUnitExpOffsets[0]);
            MaxUnitExp.Value = maxUnitExp;

            var normalEquipExp = Data.ExeData.ReadByte(0, Program.CurrentConfig.Exe.NormalEquipExpOffsets[0]);
            NormalEquipExp.Value = normalEquipExp;

            var specialEquipExp = Data.ExeData.ReadByte(0, Program.CurrentConfig.Exe.SpecialEquipExpOffsets[0]);
            SpecialEquipExp.Value = specialEquipExp;

            var normalEquipLevel = Data.ExeData.ReadByte(0, Program.CurrentConfig.Exe.NormalEquipMaxLevelOffsets[0]);
            NormalEquipMaxLevel.Value = normalEquipLevel;

            var specialEquipLevel = Data.ExeData.ReadByte(0, Program.CurrentConfig.Exe.SpecialEquipMaxLevelOffsets[0]);
            SpecialEquipMaxLevel.Value = specialEquipLevel;

            var secondEquipLevel = Data.ExeData.ReadByte(0, Program.CurrentConfig.Exe.SecondEquipStartLevelOffsets[0]);
            SecondEquipStartLevel.Value = secondEquipLevel;

            var newUnitExploit = Data.ExeData.ReadByte(0, Program.CurrentConfig.Exe.NewUnitExploitOffsets[0]);
            NewUnitExploit.Value = newUnitExploit;

            var enemyUnitExploit = Data.ExeData.ReadByte(0, Program.CurrentConfig.Exe.EnemyUnitExploitOffsets[0]);
            EnemyUnitExploit.Value = enemyUnitExploit;

            var normalEquipUpLevel = Data.ExeData.ReadByte(0, Program.CurrentConfig.Exe.NormalEquipUpLevelOffsets[0]);
            NormalEquipStLevel.Value = normalEquipUpLevel;

            var specialEquipUpLevel = Data.ExeData.ReadByte(0, Program.CurrentConfig.Exe.SpecialEquipUpLevelOffsets[0]);
            SpecialEquipStLevel.Value = specialEquipUpLevel;

            Data.ExeData.Close();
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
            Data.ExeData.Open(System.IO.FileAccess.ReadWrite);

            var offsets = Program.CurrentConfig.Exe.ClassUpLevel1Offsets;
            foreach (var offset in offsets)
            {
                Data.ExeData.WriteByte((byte)ClassUpLevel1.Value, 0, offset);
            }

            offsets = Program.CurrentConfig.Exe.ClassUpLevel1Offsets;
            foreach (var offset in offsets)
            {
                Data.ExeData.WriteByte((byte)ClassUpLevel2.Value, 0, offset);
            }

            offsets = Program.CurrentConfig.Exe.MaxUnitLevelOffsets;
            foreach (var offset in offsets)
            {
                if (offset == offsets.Last())
                    Data.ExeData.WriteByte((byte)MaxUnitLevel.Value + 1, 0, offset);
                else
                    Data.ExeData.WriteByte((byte)MaxUnitLevel.Value, 0, offset);
            }

            offsets = Program.CurrentConfig.Exe.MaxUnitExpOffsets;
            foreach (var offset in offsets)
            {
                Data.ExeData.WriteByte((byte)MaxUnitExp.Value, 0, offset);
            }

            offsets = Program.CurrentConfig.Exe.NormalEquipExpOffsets;
            foreach (var offset in offsets)
            {
                Data.ExeData.WriteByte((byte)NormalEquipExp.Value, 0, offset);
            }

            offsets = Program.CurrentConfig.Exe.SpecialEquipExpOffsets;
            foreach (var offset in offsets)
            {
                Data.ExeData.WriteByte((byte)SpecialEquipExp.Value, 0, offset);
            }

            offsets = Program.CurrentConfig.Exe.NormalEquipMaxLevelOffsets;
            foreach (var offset in offsets)
            {
                Data.ExeData.WriteByte((byte)NormalEquipMaxLevel.Value, 0, offset);
            }

            offsets = Program.CurrentConfig.Exe.SpecialEquipMaxLevelOffsets;
            foreach (var offset in offsets)
            {
                if(offset == offsets.Last())
                    Data.ExeData.WriteByte((byte)SpecialEquipMaxLevel.Value + 1, 0, offset);
                else
                    Data.ExeData.WriteByte((byte)SpecialEquipMaxLevel.Value, 0, offset);
            }

            offsets = Program.CurrentConfig.Exe.SecondEquipStartLevelOffsets;
            foreach (var offset in offsets)
            {
                Data.ExeData.WriteByte((byte)SecondEquipStartLevel.Value, 0, offset);
            }

            offsets = Program.CurrentConfig.Exe.NewUnitExploitOffsets;
            foreach (var offset in offsets)
            {
                Data.ExeData.WriteByte((byte)NewUnitExploit.Value, 0, offset);
            }

            offsets = Program.CurrentConfig.Exe.EnemyUnitExploitOffsets;
            foreach (var offset in offsets)
            {
                Data.ExeData.WriteByte((byte)EnemyUnitExploit.Value, 0, offset);
            }

            offsets = Program.CurrentConfig.Exe.NormalEquipUpLevelOffsets;
            foreach (var offset in offsets)
            {
                Data.ExeData.WriteByte((byte)NormalEquipStLevel.Value, 0, offset);
            }

            offsets = Program.CurrentConfig.Exe.SpecialEquipUpLevelOffsets;
            foreach (var offset in offsets)
            {
                Data.ExeData.WriteByte((byte)SpecialEquipStLevel.Value, 0, offset);
            }

            Data.ExeData.Close();

        }
        #endregion

    }
}
