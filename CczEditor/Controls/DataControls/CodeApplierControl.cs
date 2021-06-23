using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace CczEditor.Controls.DataControls
{
    public partial class CodeApplierControl : UserControl
    {
        public CodeApplierControl()
        {
            InitializeComponent();
        }

        private void ApplyButton_Click(object sender, EventArgs e)
        {
            string codeStr = Regex.Replace(CodeTextBox.Text, @"^\s*$\n|\r", string.Empty, RegexOptions.Multiline).TrimEnd();
            var codes = codeStr.Split('\n');

            if(codes.Length % 2 != 0)
            {
                Utils.ShowError("코드 쌍이 맞지 않습니다!");
                return;
            }

            List<Config.ConfigExeCodeInfo> codeList = new List<Config.ConfigExeCodeInfo>();
            for(int i = 0; i < codes.Length; i+=2)
            {
                var offset = codes[i].Substring(2);
                var values = codes[i + 1];

                var codeInfo = new Config.ConfigExeCodeInfo();
                codeInfo.offset = int.Parse(offset, System.Globalization.NumberStyles.HexNumber);
                codeInfo.CodeArr = values;

                codeList.Add(codeInfo);
            }

            try
            {
                if (BackupCheck.Checked)
                {
                    var now = DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss");
                    var originPath = System.IO.Path.Combine(Program.CurrentConfig.DirectoryPath, Program.CurrentConfig.ExeFileName);
                    var destPath = System.IO.Path.Combine(Program.CurrentConfig.DirectoryPath, $"{now}_{Program.CurrentConfig.ExeFileName}");
                    System.IO.File.Copy(originPath, destPath);
                }

                Program.ExeData.Open(System.IO.FileAccess.ReadWrite);
                foreach (var code in codeList)
                {
                    Program.ExeData.Write(Utils.GetCode(code.CodeArr), code.offset);
                }
                Program.ExeData.Close();

                MessageBox.Show("코드 적용 완료");
            }
            catch
            {
                Utils.ShowError("코드 적용 중 에러 발생!");
            }
            
        }
    }
}
