using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CczEditor.Controls.ConfigControls
{
    public partial class ConfigPreset : UserControl
    {
        public ConfigPreset()
        {
            InitializeComponent();
        }

        private void Star61Button_Click(object sender, EventArgs e)
        {
            CreatePreset popup = new CreatePreset();
            popup._presetType = CreatePreset.PresetType.Star61;
            popup.DefaultDisplayName = "신조조전 6.1";
            popup.DefaultFileName = "Star 6.1";
            popup.ShowDialog();
        }

        private void Star62Button_Click(object sender, EventArgs e)
        {
            CreatePreset popup = new CreatePreset();
            popup._presetType = CreatePreset.PresetType.Star62;
            popup.DefaultDisplayName = "신조조전 6.2";
            popup.DefaultFileName = "Star 6.2";
            popup.ShowDialog();
        }

        private void Bs10Button_Click(object sender, EventArgs e)
        {
            CreatePreset popup = new CreatePreset();
            popup._presetType = CreatePreset.PresetType.Bs10;
            popup.DefaultDisplayName = "비상조조전 1.0";
            popup.DefaultFileName = "BS 1.0";
            popup.ShowDialog();
        }
    }
}
