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
    public partial class ForceSynastryController : Form
    {
        private Data.Wrapper.ForceSynastryData CurrentSynastryData;

        public ForceSynastryController()
        {
            InitializeComponent();
            var forceNames = ConfigUtils.GetForceCategoryNames(Program.ExeData, Program.CurrentConfig, Program.FORMATSTRING_KEYVALUEPAIR_HEX2);
            listBox1.Items.AddRange(forceNames.Values.ToArray());
            for (var i = 0; i < forceNames.Count; i++)
            {
                var item = new ListViewItem("0");
                item.SubItems.Add(forceNames[i]);
                lvLearnLv.Items.Add(item);
            }
            CurrentSynastryData = new Data.Wrapper.ForceSynastryData();
            listBox1.SelectedIndex = 0;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = listBox1.SelectedIndex;
            CurrentSynastryData.Read(index, Program.GameData, Program.ImsgData, Program.ExeData, Program.CurrentConfig);

            for (var i = 0; i < CurrentSynastryData.Values.Length; i++)
            {
                lvLearnLv.Items[i].Text = CurrentSynastryData.Values[i].ToString();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            for (var i = 0; i < Program.CurrentConfig.ForceCategoryNames.Count; i++)
            {
                lvLearnLv.Items[i].Text = "100";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int index = listBox1.SelectedIndex;
            for (var i = 0; i < CurrentSynastryData.Values.Length; i++)
            {
                CurrentSynastryData.Values[i] = byte.Parse(lvLearnLv.Items[i].Text);
            }
            CurrentSynastryData.Write(index, Program.GameData, Program.ImsgData, Program.ExeData, Program.CurrentConfig);
        }
        private void lvLearnLv_ItemActivate(object sender, EventArgs e)
        {
            if (lvLearnLv.SelectedItems.Count > 0)
            {
                lvLearnLv.SelectedItems[0].BeginEdit();
            }
        }
        private void lvLearnLv_AfterLabelEdit(object sender, LabelEditEventArgs e)
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
    }
}
