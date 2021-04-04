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
    public partial class MoveUnits : Form
    {
        public MoveUnits()
        {
            InitializeComponent();
            ClearItems();
        }

        private void ClearItems()
        { 
            sourceUnitListBox.Items.Clear();
            sourceUnitListBox.Items.AddRange(Program.GameData.UnitNameList(true).ToArray());

            destUnitListBox.Items.Clear();
            destUnitListBox.Items.AddRange(Program.GameData.UnitNameList(true).ToArray());

            RefreshItems(0,0);
        }


        private void sourceUnitList_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            var control = (CheckedListBox)sender;

            if (destUnitListBox.GetItemChecked(e.Index)) e.NewValue = CheckState.Unchecked;

            int changedValue = 0;
            if (e.CurrentValue == CheckState.Checked && e.NewValue == CheckState.Unchecked) changedValue--;
            else if (e.CurrentValue == CheckState.Unchecked && e.NewValue == CheckState.Checked) changedValue++;

            RefreshItems(changedValue, 0);
        }

        private void destUnitList_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            var control = (CheckedListBox)sender;

            if (sourceUnitListBox.GetItemChecked(e.Index)) e.NewValue = CheckState.Unchecked;

            int changedValue = 0;
            if (e.CurrentValue == CheckState.Checked && e.NewValue == CheckState.Unchecked) changedValue--;
            else if (e.CurrentValue == CheckState.Unchecked && e.NewValue == CheckState.Checked) changedValue++;

            RefreshItems(0, changedValue);
        }

        private void RefreshItems(int sourceChanged, int destChanged)
        {
            int sourceCount = sourceUnitListBox.CheckedIndices.Count + sourceChanged;
            int destCount = destUnitListBox.CheckedIndices.Count + destChanged;

            sourceCountText.Text = string.Format("선택중：{0}", sourceCount);
            destCountText.Text = string.Format("선택중：{0}", destCount);
        }

        private void sourceSelectButton_Click(object sender, EventArgs e)
        {
            for (var i = (int)sourceStartValueBox.Value; i <= sourceEndValueBox.Value; i++)
            {
                sourceUnitListBox.SetItemChecked(i, true);
            }
        }

        private void destSelectButton_Click(object sender, EventArgs e)
        {
            for (var i = (int)destStartValueBox.Value; i <= destEndValueBox.Value; i++)
            {
                destUnitListBox.SetItemChecked(i, true);
            }
        }

        private void sourceCancelButton_Click(object sender, EventArgs e)
        {
            for (var i = 0; i < sourceUnitListBox.Items.Count; i++)
            {
                sourceUnitListBox.SetItemChecked(i, false);
            }
        }

        private void destCancelButton_Click(object sender, EventArgs e)
        {
            for (var i = 0; i < destUnitListBox.Items.Count; i++)
            {
                destUnitListBox.SetItemChecked(i, false);
            }
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ExchangeButton_Click(object sender, EventArgs e)
        {
            int sourceCount = sourceUnitListBox.CheckedIndices.Count;
            int destCount = destUnitListBox.CheckedIndices.Count;

            if(sourceCount != destCount)
            {
                MessageBox.Show("교환할 아이템 수가 일치하지 않습니다.", "경고", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var sourceList = sourceUnitListBox.CheckedIndices.Cast<int>().ToArray();
            var destList = destUnitListBox.CheckedIndices.Cast<int>().ToArray();

            System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
            sw.Start();

            Data.ExeData.Open(System.IO.FileAccess.ReadWrite);
            for (int i = 0; i < destUnitListBox.CheckedIndices.Count; i++)
            {
                var dest = new CczEditor.Data.Wrapper.UnitData();
                dest.Read(destList[i]);

                var source = new CczEditor.Data.Wrapper.UnitData();
                source.Read(sourceList[i]);
                source.Write(destList[i]);

                dest.Write(sourceList[i]);
            }
            Data.ExeData.Close();

            sw.Stop();
            Console.WriteLine($"{sw.Elapsed.ToString()}");
            
            ClearItems();
        }

        private void sourceSearchButton_Click(object sender, EventArgs e)
        {
            var list = Program.GameData.UnitNameList(false);
            var index = list.FindIndex(x => x == sourceSearchBox.Text);
            if (index == -1)
            {
                MessageBox.Show("찾기에 실패했습니다.", "경고", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            sourceUnitListBox.SelectedIndex = index;

        }

        private void destSearchButton_Click(object sender, EventArgs e)
        {
            var list = Program.GameData.UnitNameList(false);
            var index = list.FindIndex(x => x == destSearchBox.Text);
            if (index == -1)
            {
                MessageBox.Show("찾기에 실패했습니다.", "경고", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            destUnitListBox.SelectedIndex = index;

        }
    }
}
