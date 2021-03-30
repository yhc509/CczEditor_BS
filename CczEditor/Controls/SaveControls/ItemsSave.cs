#region using List

using System;
using System.Collections.Generic;
using System.Windows.Forms;

using CczEditor.Data;

#endregion

namespace CczEditor.Controls.SaveControls
{
	public partial class ItemsSave : BaseSaveControl
	{
		private List<int> _itemIconList;

		public ItemsSave()
		{
			InitializeComponent();
			GetResourcesItemIcon();
		}

		private void ItemsSave_Load(object sender, EventArgs e)
		{
			_itemIconList = GameData.ItemIconList();
			var equipmentNames = new List<string> { "FF, 장비없음" };
			equipmentNames.AddRange(GameData.GetItemNames(ItemType.Weapons, true));
			equipmentNames.AddRange(GameData.GetItemNames(ItemType.Armor, true));
			equipmentNames.AddRange(GameData.GetItemNames(ItemType.Auxiliary, true));
            equipmentNames.AddRange(StarData.GetItemNames(ItemType.Weapons, true));
            equipmentNames.AddRange(StarData.GetItemNames(ItemType.Armor, true));
            equipmentNames.AddRange(StarData.GetItemNames(ItemType.Auxiliary, true));
			cbItemType.Items.Clear();
			cbItemType.Items.AddRange(equipmentNames.ToArray());
			lbList.Items.Clear();
			lbList.Items.AddRange(SaveData.ItemEquipmentNameList.ToArray());
			lbList.SelectedIndex = 0;
			lbList.Focus();
			ncGold.Value = SaveData.Gold;
			ncLoyalTreacherousValue.Value = SaveData.LoyalTreacherousValue;
			var items = GameData.GetItemNames(ItemType.Consumables, true);
			lvConsumablesItem.Items.Clear();
			for (var i = 0; i < Program.SAVE_ITEM_AMOUNT_COUNT; i++)
			{
				var item = new ListViewItem(SaveData.ItemAmountGet(i).ToString());
				item.SubItems.Add(items[i]);
				lvConsumablesItem.Items.Add(item);
			}
		}

		private void lbList_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (lbList.SelectedIndex < 0 || lbList.SelectedIndex >= lbList.Items.Count)
			{
				return;
			}
			var item = SaveData.ItemEquipmentGet(lbList.SelectedIndex);
			cbItemType.SelectedIndex = cbItemType.FindString(Utils.GetString(item[0]));
			ncLv.Value = item[1];
			ncExp.Value = item[2];
			if (TopLevelControl != null)
			{
				TopLevelControl.Text = string.Format("{1} - 세이브 편집 - 번호：{0}", lbList.SelectedIndex, Program.TitleNameCurrent);
			}
		}

		private void btnEdit_Click(object sender, EventArgs e)
		{
			if (lbList.SelectedIndex < 0 || lbList.SelectedIndex >= lbList.Items.Count || cbItemType.SelectedItem == null)
			{
				return;
			}
			var index = lbList.SelectedIndex;
			var item = SaveData.ItemEquipmentGet(index);
			item[0] = (byte)Utils.GetId(cbItemType.SelectedItem);
			if (item[0] == 0xFF)
			{
				item[1] = item[2] = 0xFF;
			}
			else
			{
				item[1] = (byte)ncLv.Value;
				item[2] = (byte)ncExp.Value;
			}
			SaveData.ItemEquipmentSet(index, item);
			lbList.Items.RemoveAt(index);
			lbList.Items.Insert(index, string.Format(Program.FORMATSTRING_SAVEEQUIPMENT, index, cbItemType.SelectedItem));
			lbList.SelectedIndex = index;
		}

		private void btnSave_Click(object sender, EventArgs e)
		{
			SaveData.Gold = (int)ncGold.Value;
			SaveData.LoyalTreacherousValue = (byte)ncLoyalTreacherousValue.Value;
			for (var i = 0; i < Program.SAVE_ITEM_AMOUNT_COUNT; i++)
			{
				SaveData.ItemAmountSet(i, byte.Parse(lvConsumablesItem.Items[i].Text));
			}
		}

		private void btnRestore_Click(object sender, EventArgs e)
		{
			ItemsSave_Load(this, new EventArgs());
		}

		private void cbItemType_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (ItemIcons == null || cbItemType.SelectedIndex < 0)
			{
				return;
			}
			var index = Utils.GetId(cbItemType.SelectedItem);
			pbItemIcon.Image = index >= 0 && index < _itemIconList.Count ? ItemIcons.GetImage(_itemIconList[index]) : null;
		}

		private void lvConsumablesItem_ItemActivate(object sender, EventArgs e)
		{
			if (lvConsumablesItem.SelectedItems.Count > 0)
			{
				lvConsumablesItem.SelectedItems[0].BeginEdit();
			}
		}

		private void lvConsumablesItem_AfterLabelEdit(object sender, LabelEditEventArgs e)
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