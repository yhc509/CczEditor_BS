using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CczEditor.Controls.DataControls
{
    public partial class SaveApplyPopup : Form
    {
        public enum ApplyType
        {
            SpecialEffect,
            SpecailSkill
        }

        public ApplyType _applyType;

        public SaveApplyPopup()
        {
            InitializeComponent();
        }

        private void ApplyButton_Click(object sender, EventArgs e)
        {
            var index = (int) SaveNumberValue.Value;

            try
            {
                if (index == 0)
                {
                    for (int i = 0; i <= 200; i++)
                    {
                        Apply(i);
                    }
                }
                else
                {
                    Apply(index);
                }

                MessageBox.Show("수정 성공!");
            }
            catch
            {

                MessageBox.Show("오류 발생!");
            }
        }

        private void Apply(int saveIndex)
        {
            if (_applyType == ApplyType.SpecialEffect)
            {
                int count = Program.CurrentConfig.SpecialEffectNames.Count;
                var binary = Data.ExeData.Read(Program.CurrentConfig.Exe.SpecialEffectOffset, count * 0x08);
                Data.SaveNewData.Write(saveIndex, binary, Program.CurrentConfig.Save.SpecialEffectOffset, binary.Length);
            }
            else
            {
                var binary = Data.ExeData.Read(Program.CurrentConfig.Exe.SpecialSkillOffset, 10 * 0x1B);
                Data.SaveNewData.Write(saveIndex, binary, Program.CurrentConfig.Save.SpecialSkillOffset, binary.Length);

            }
        }
    }
}
