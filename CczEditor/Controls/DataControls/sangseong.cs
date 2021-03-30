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
    public partial class sangseong : Form
    {
        public sangseong()
        {
            InitializeComponent();
            listBox1.Items.AddRange(Program.CurrentConfig.ForceCategoryNames.ToArray());
            var forceNames = Program.CurrentConfig.ForceCategoryNames;
            for (var i = 0; i < forceNames.Count; i++)
            {
                var item = new ListViewItem("0");
                item.SubItems.Add(forceNames[i]);
                lvLearnLv.Items.Add(item);
            }
            listBox1.SelectedIndex = 0;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            for (var i = 0; i < Program.CurrentConfig.ForceCategoryNames.Count; i++)
            {
                lvLearnLv.Items[i].Text = Program.ExeData.detailload(0, 0, Program.CurrentConfig.Offsets["Exe_Force_SangSeong"] + (listBox1.SelectedIndex * Program.CurrentConfig.ForceCategoryNames.Count) + i).ToString(); ;
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
            for (var i = 0; i < Program.CurrentConfig.ForceCategoryNames.Count; i++)
            {
                Program.ExeData.detailsave(0, 0, Program.CurrentConfig.Offsets["Exe_Force_SangSeong"] + (listBox1.SelectedIndex *  Program.CurrentConfig.ForceCategoryNames.Count) + i, byte.Parse(lvLearnLv.Items[i].Text));
            }
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
