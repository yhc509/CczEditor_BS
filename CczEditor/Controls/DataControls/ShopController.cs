#region using List

using System;
using System.Windows.Forms;

using CczEditor.Data;
using System.Linq;

#endregion

namespace CczEditor.Controls.DataControls
{
	public partial class ShopController : BaseDataControl
	{
		private string[] _unitList;
        Data.Wrapper.ShopData CurrentData;

        public ShopController()
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
			clbEquipment.Items.AddRange(DataUtils.GetItemNames(ItemType.Weapons, true).ToArray());
			clbEquipment.Items.AddRange(DataUtils.GetItemNames(ItemType.Armor, true).ToArray());
			clbEquipment.Items.AddRange(DataUtils.GetItemNames(ItemType.Auxiliary, true).ToArray());
            clbConsumables.Items.AddRange(DataUtils.GetItemNames(ItemType.Consumables, true).ToArray());
            clbConsumables.Items.AddRange(DataUtils.GetItemNames(ItemType.BombMines, true).ToArray());
            clbConsumables.Items.AddRange(DataUtils.GetItemNames(ItemType.BombTools, true).ToArray());
            clbConsumables.Items.AddRange(DataUtils.GetItemNames(ItemType.Bombs, true).ToArray()); 
			lbList.Items.AddRange(Program.GameData.StoreNameList(true).ToArray());
		}

        public override void Reset()
        {
            base.Reset();

            CurrentData = new Data.Wrapper.ShopData();

            lbList.SelectedIndex = 0;
            lbList.Focus();
        }

        private void lbList_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (lbList.SelectedIndex < 0 || lbList.SelectedIndex >= lbList.Items.Count)
			{
				return;
			}

            int index = lbList.SelectedIndex;

            CurrentData.Read(index, Program.GameData, Program.ImsgData, Program.ExeData, Program.CurrentConfig);

            var store = Program.GameData.StoreGet(lbList.SelectedIndex);
			cbStorage.SelectedIndex = BitConverter.ToUInt16(store, 0);
			cbBusiness.SelectedIndex = BitConverter.ToUInt16(store, 2);

            ClearStorage();
            ClearShop();

            foreach (var item in CurrentData.EquipItemList)
            {
                var i = clbEquipment.FindString(Utils.GetString(item));
                if (i == -1) continue;
                clbEquipment.SetItemChecked(i, true);
            }

            foreach (var item in CurrentData.ConsumeItemList)
            {
                var i = clbConsumables.FindString(Utils.GetString(item));
                if (i == -1) continue;
                clbConsumables.SetItemChecked(i, true);
            }

            txtStageName.Text = CurrentData.StageName;

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
            
            CurrentData.StageName = txtStageName.Text;

            CurrentData.StorageUnitIndex = (ushort) cbStorage.SelectedIndex;
            CurrentData.ShopUnitIndex = (ushort) cbBusiness.SelectedIndex;

            CurrentData.ConsumeItemList.Clear();
            CurrentData.EquipItemList.Clear();
            for (var j = 0; j < clbEquipment.CheckedItems.Count; j++)
            {
                CurrentData.EquipItemList.Add((byte)Utils.GetId(clbEquipment.CheckedItems[j]));
            }
            for (var j = 0; j < clbConsumables.CheckedItems.Count; j++)
            {
                CurrentData.ConsumeItemList.Add((byte)Utils.GetId(clbConsumables.CheckedItems[j]));
            }

            CurrentData.Write(index, Program.GameData, Program.ImsgData, Program.ExeData, Program.CurrentConfig);

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

        private void btnStorageClear_Click(object sender, EventArgs e)
        {
            ClearStorage();
        }
        
        private void btnShopClear_Click(object sender, EventArgs e)
        {
            ClearShop();
        }

        private void ClearStorage()
        {
            var indexs = new int[clbEquipment.CheckedIndices.Count];
            clbEquipment.CheckedIndices.CopyTo(indexs, 0);
            for (var i = 0; i < indexs.Length; i++)
            {
                clbEquipment.SetItemChecked(indexs[i], false);
            }
        }

        private void ClearShop()
        {
            var indexs = new int[clbConsumables.CheckedIndices.Count];
            clbConsumables.CheckedIndices.CopyTo(indexs, 0);
            for (var i = 0; i < indexs.Length; i++)
            {
                clbConsumables.SetItemChecked(indexs[i], false);
            }
        }

    }
}