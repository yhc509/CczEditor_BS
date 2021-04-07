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
        public ProjectController()
        {
            InitializeComponent();
        }


        private void ProjectController_Load(object sender, EventArgs e)
        {
            InitTitleText();
        }



        private void InitTitleText()
        {
            TitleTextBox.Text = Data.ExeData.GetText(Program.CurrentConfig.Exe.TitleOffsets[1], 12);
        }

        private void TitleSaveButton_Click(object sender, EventArgs e)
        {
            try
            {
                Data.ExeData.Open(System.IO.FileAccess.ReadWrite);
                if (!Data.ExeData.IsLocked)
                {
                    Data.ExeData.WriteText($"「{TitleTextBox.Text}」", Program.CurrentConfig.Exe.TitleOffsets[0], 16);
                    Data.ExeData.WriteText(TitleTextBox.Text, Program.CurrentConfig.Exe.TitleOffsets[1], 12);
                    Data.ExeData.WriteText(TitleTextBox.Text, Program.CurrentConfig.Exe.TitleOffsets[2], 12);
                    Data.ExeData.WriteText($"종료「{TitleTextBox.Text}」", Program.CurrentConfig.Exe.TitleOffsets[3], 20);
                    Data.ExeData.WriteText($"정말「{TitleTextBox.Text}」종료?", Program.CurrentConfig.Exe.TitleOffsets[4], 25);

                }
                Data.ExeData.Close();
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
        
    }
}
