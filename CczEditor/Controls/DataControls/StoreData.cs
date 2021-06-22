#region using List

using System;
using System.Windows.Forms;

using CczEditor.Data;

#endregion

namespace CczEditor.Controls.DataControls
{
	public partial class StoreData : BaseDataControl
	{
		private string[] _unitList;

		public StoreData()
		{
			InitializeComponent();
			txtStageName.MaxLength = Program.IMSG_STAGE_NAME_LENGTH/2;
			txtStageName.Enabled = ImsgDataLoaded;
		}

		private void StoreData_Load(object sender, EventArgs e)
		{
			_unitList = Program.GameData.UnitNameList(true).ToArray();

			cbStorage.Items.AddRange(_unitList);
			cbBusiness.Items.AddRange(_unitList);
			clbEquipment.Items.AddRange(Program.GameData.GetItemNames(ItemType.Weapons, true).ToArray());
			clbEquipment.Items.AddRange(Program.GameData.GetItemNames(ItemType.Armor, true).ToArray());
			clbEquipment.Items.AddRange(Program.GameData.GetItemNames(ItemType.Auxiliary, true).ToArray());
            clbConsumables.Items.AddRange(Program.GameData.GetItemNames(ItemType.Consumables, true).ToArray());
            clbConsumables.Items.AddRange(Program.GameData.GetItemNames(ItemType.bombs3, true).ToArray());
            clbConsumables.Items.AddRange(Program.GameData.GetItemNames(ItemType.bombs, true).ToArray());
            clbConsumables.Items.AddRange(Program.GameData.GetItemNames(ItemType.bombs2, true).ToArray()); 
			lbList.Items.AddRange(Program.GameData.StoreNameList(true).ToArray());
			lbList.SelectedIndex = 0;
			lbList.Focus();
		}

		private void lbList_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (lbList.SelectedIndex < 0 || lbList.SelectedIndex >= lbList.Items.Count)
			{
				return;
			}
			var store = Program.GameData.StoreGet(lbList.SelectedIndex);
			cbStorage.SelectedIndex = BitConverter.ToUInt16(store, 0);
			cbBusiness.SelectedIndex = BitConverter.ToUInt16(store, 2);
			var indexs = new int[clbEquipment.CheckedIndices.Count];
			clbEquipment.CheckedIndices.CopyTo(indexs, 0);
			for (var i = 0; i < indexs.Length; i++)
			{
				clbEquipment.SetItemChecked(indexs[i], false);
			}
			int index;
			for (var i = 4; i < 20; i++)
			{
				if (store[i] == 0xFF)
				{
					continue;
				}
				index = clbEquipment.FindString(Utils.GetString(store[i]));
				if (index < 0 || index >= clbEquipment.Items.Count)
				{
					continue;
				}
				clbEquipment.SetItemChecked(index, true);
			}
			indexs = new int[clbConsumables.CheckedIndices.Count];
			clbConsumables.CheckedIndices.CopyTo(indexs, 0);
			for (var i = 0; i < indexs.Length; i++)
			{
				clbConsumables.SetItemChecked(indexs[i], false);
			}
			for (var i = 20; i < 36; i++)
			{
				if (store[i] == 0xFF)
				{
					continue;
				}
				index = clbConsumables.FindString(Utils.GetString(store[i]));
				if (index < 0 || index >= clbConsumables.Items.Count)
				{
					continue;
				}
				clbConsumables.SetItemChecked(index, true);
			}
			if (ImsgDataLoaded)
			{
				btnStageNameRestore();
			}
			if (TopLevelControl != null)
			{
				TopLevelControl.Text = string.Format("{1} - 상점 편집 - 번호：{0}", lbList.SelectedIndex, Program.TitleNameCurrent);
			}
		}

		private void btnSave_Click(object sender, EventArgs e)
		{
			if (lbList.SelectedIndex < 0 || lbList.SelectedIndex >= lbList.Items.Count)
			{
				return;
			}
			var index = lbList.SelectedIndex;
			var store = Program.GameData.StoreGet(index);
			Utils.ChangeByteValue(store, BitConverter.GetBytes((ushort)cbStorage.SelectedIndex), 0);
			Utils.ChangeByteValue(store, BitConverter.GetBytes((ushort)cbBusiness.SelectedIndex), 2);
			var i = 4;
			for (var j = 0; j < clbEquipment.CheckedItems.Count; j++)
			{
				store[i++] = (byte)Utils.GetId(clbEquipment.CheckedItems[j]);
			}
			for (; i < 20; i++)
			{
				store[i] = 0xFF;
			}
			for (var j = 0; j < clbConsumables.CheckedItems.Count; j++)
			{
				store[i++] = (byte)Utils.GetId(clbConsumables.CheckedItems[j]);
			}
			for (; i < 36; i++)
			{
				store[i] = 0xFF;
			}
            Program.GameData.StoreSet(index, store);

            //Imsg
            var stage = Program.ImsgData.StageGet(index);
            Utils.ChangeByteValue(stage, Utils.GetBytes(txtStageName.Text), 0, Program.IMSG_STAGE_NAME_LENGTH);
            Program.ImsgData.StageSet(index, stage);
            lbList.Items.RemoveAt(index);
            lbList.Items.Insert(index, string.Format("{0:D2},{1}", index, txtStageName.Text));
            lbList.SelectedIndex = index;
		}

		private void btnRestore_Click(object sender, EventArgs e)
		{
			lbList_SelectedIndexChanged(lbList, new EventArgs());

		}


		private void btnStageNameRestore()
		{
			if (lbList.SelectedIndex < 0 || lbList.SelectedIndex >= lbList.Items.Count)
			{
				return;
			}
			var stage = Program.ImsgData.StageGet(lbList.SelectedIndex);
			txtStageName.Text = Utils.ByteToString(stage);
		}

		private void clbEquipment_ItemCheck(object sender, ItemCheckEventArgs e)
		{
			var control = (CheckedListBox)sender;
			if (control.CheckedIndices.Count >= 15)
			{
				e.NewValue = CheckState.Unchecked;
			}

            int changedValue = 0;
            if (e.CurrentValue == CheckState.Checked && e.NewValue == CheckState.Unchecked) changedValue--;
            else if (e.CurrentValue == CheckState.Unchecked && e.NewValue == CheckState.Checked) changedValue++;

            lblEquipmentCheckedCount.Text = string.Format("선택중：{0}", control.CheckedIndices.Count + changedValue);
		}

		private void clbConsumables_ItemCheck(object sender, ItemCheckEventArgs e)
		{
			var control = (CheckedListBox)sender;
			if (control.CheckedIndices.Count >= 15)
			{
				e.NewValue = CheckState.Unchecked;
            }

            int changedValue = 0;
            if (e.CurrentValue == CheckState.Checked && e.NewValue == CheckState.Unchecked) changedValue--;
            else if (e.CurrentValue == CheckState.Unchecked && e.NewValue == CheckState.Checked) changedValue++;
            lblConsumablesCheckedCount.Text = string.Format("선택중：{0}", control.CheckedIndices.Count + changedValue);
		}

        private void searchButton_Click(object sender, EventArgs e)
        {
            var list = Program.GameData.StoreNameList(false);
            var index = list.FindIndex(x => x == searchTextBox.Text);
            if (index == -1)
            {
                MessageBox.Show("찾기에 실패했습니다.", "경고", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            lbList.SelectedIndex = index;
        }
    }
}