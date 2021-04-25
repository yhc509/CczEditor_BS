using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CczEditor.Controls.ConfigControls
{
    public partial class CreatePreset : Form
    {
        public enum PresetType
        {
            Star61,
            Star62,
            Bs10,
        }
        
        public PresetType _presetType;
        public string DefaultFileName
        {
            get { return FileNameTextBox.Text; }
            set { FileNameTextBox.Text = value; }
        }
        public string DefaultDisplayName
        {
            get { return DisplayName.Text; }
            set { DisplayName.Text = value; }
        }

        public CreatePreset()
        {
            InitializeComponent();
            
        }

        private void CreateButton_Click(object sender, EventArgs e)
        {
            var fileName = $"CczEditor-{FileNameTextBox.Text}.json";
            if (System.IO.File.Exists(fileName))
            {
                Utils.ShowError("이미 존재하는 컨피그 파일명입니다.");
                return;
            }

            Config config;
            ConfigCreateHandler handler;
            switch(_presetType)
            {
                case PresetType.Star61:
                    handler = new Star61ConfigCreateHandler();
                    handler.result.DisplayName = DisplayName.Text;
                    config = handler.Execute();
                    break;
                case PresetType.Star62:
                    handler = new Star62ConfigCreateHandler();
                    handler.result.DisplayName = DisplayName.Text;
                    config = handler.Execute();
                    break;
                default:
                    handler = new Bs10ConfigCreateHandler();
                    handler.result.DisplayName = DisplayName.Text;
                    config = handler.Execute();
                    break;
            }

            Config.Write(config, fileName);

            MessageBox.Show($"{fileName} 생성 완료.", "알림", MessageBoxButtons.OK);

            var mainForm = Application.OpenForms["MainForm"] as MainForm;
            if(mainForm != null)
                mainForm.LoadConfigurationTypeNames();

            Close();
        }
    }
}
