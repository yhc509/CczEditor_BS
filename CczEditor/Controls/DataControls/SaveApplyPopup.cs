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
            SpecailSkill,
            UnitObj,
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
            if (Data.SaveNewData.IsLocked(saveIndex)) return;

            Program.ExeData.Open(System.IO.FileAccess.ReadWrite);
            if (_applyType == ApplyType.SpecialEffect)
            {
                int count = Program.CurrentConfig.SpecialEffectNames.Count;
                var binary = Program.ExeData.Read(Program.CurrentConfig.Exe.SpecialEffectOffset, count * 0x08);
                Data.SaveNewData.Write(saveIndex, binary, Program.CurrentConfig.Save.SpecialEffectOffset, binary.Length);
            }
            else if(_applyType == ApplyType.SpecailSkill)
            {
                var binary = Program.ExeData.Read(Program.CurrentConfig.Exe.SpecialSkillOffset, 10 * 0x1B);
                Data.SaveNewData.Write(saveIndex, binary, Program.CurrentConfig.Save.SpecialSkillOffset, binary.Length);
            }
            else
            {
                int count = Program.CurrentConfig.Data.UnitCount;
                var binary = Program.ExeData.Read(Program.CurrentConfig.Exe.UnitBattleObjOffset, 2 * count);
                Data.SaveNewData.Write(saveIndex, binary, Program.CurrentConfig.Save.BattleObjOffset, binary.Length);

                binary = Program.ExeData.Read(Program.CurrentConfig.Exe.UnitPmapObjOffset, 2 * count);
                Data.SaveNewData.Write(saveIndex, binary, Program.CurrentConfig.Save.PmapObjOffset, binary.Length);

                binary = new byte[count * 2];
                for(int i = 0; i < count; i++)
                {
                    var unit = new Data.Wrapper.UnitData();
                    unit.Read(i, Program.GameData, Program.ImsgData, Program.ExeData, Program.CurrentConfig);

                    Utils.ChangeByteValue(binary, BitConverter.GetBytes(unit.Face), i * 2);
                }
                Data.SaveNewData.Write(saveIndex, binary, Program.CurrentConfig.Save.FaceObjOffset, binary.Length);
            }
            Program.ExeData.Close();
        }
    }
}
