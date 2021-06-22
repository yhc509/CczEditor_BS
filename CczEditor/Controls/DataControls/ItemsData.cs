#region using List

using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using CczEditor.Data;
using System.Text;

#endregion

namespace CczEditor.Controls.DataControls
{
	public partial class ItemsData : BaseDataControl
	{

		public ItemsData()
		{
			InitializeComponent();
            cbItemHitarea.Enabled = cbItemHitarea.Enabled = pbItemHitarea.Enabled = Program.CurrentConfig.CodeOptionContainer.ItemCustomRange;
			if (Program.CurrentConfig.CodeOptionContainer.ItemCustomRange)
			{
				GetResourcesHitarea();
            }

            GetResourcesHitarea();
            GetResourcesEffarea();
            GetResourcesItemIcon();
		}

		private void ItemsData_Load(object sender, EventArgs e)
		{
			cbItemType.Items.Add("FF,유형 없음");
            cbItemType.Items.AddRange(ConfigUtils.GetEquipmentTypes(Program.FORMATSTRING_KEYVALUEPAIR_HEX2).Values.ToArray());

			cbSpecialEffects.Items.Add("FF,능력 없음");
            cbSpecialEffects.Items.AddRange(ConfigUtils.GetAuxiliaryEffects(Program.FORMATSTRING_KEYVALUEPAIR_HEX2).Values.ToArray());
     
			cbItemEffects.Items.Add("FF,효과 없음");
            cbItemEffects.Items.AddRange(ConfigUtils.GetConsumablesEffects(Program.FORMATSTRING_KEYVALUEPAIR_HEX2).Values.ToArray());

			cbCorps.Items.Add("FF,모든 병종");
            cbCorps.Items.AddRange(ConfigUtils.GetForceCategoryNames(Program.FORMATSTRING_KEYVALUEPAIR_HEX2).Values.ToArray());

            cbItemHitarea.Items.AddRange(Program.CurrentConfig.HitAreaNames.ToArray());
			lbList.Items.AddRange(GameData.ItemNameList(Program.FORMATSTRING_KEYVALUEPAIR_HEX2).ToArray());

            if (Program.StarData != null && Program.StarData.CurrentFile != null && Program.StarData.CurrentStream != null)
            {
                cbBombEffects.Items.Add("FF,효과 없음");
                cbBombEffects.Items.AddRange(ConfigUtils.GetBombsEffects(Program.FORMATSTRING_KEYVALUEPAIR_HEX2).Values.ToArray());
                cbBombEffects.Items.AddRange(ConfigUtils.GetBombsEffects2(Program.FORMATSTRING_KEYVALUEPAIR_HEX2).Values.ToArray());
                cbBombEffects.Items.AddRange(ConfigUtils.GetBombsEffects3(Program.FORMATSTRING_KEYVALUEPAIR_HEX2).Values.ToArray());
                EffectsRange.Items.AddRange(Program.CurrentConfig.EffAreaNames.ToArray());
                AtkRange.Items.AddRange(Program.CurrentConfig.HitAreaNames.ToArray());
                lbList.Items.AddRange(StarData.ItemNameList(true).ToArray());
            }

            lbList.SelectedIndex = 0;
			lbList.Focus();
		}

		private void lbList_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (lbList.SelectedIndex < 0 || lbList.SelectedIndex >= lbList.Items.Count)
			{
				return;
			}

            LoadItem(lbList.SelectedIndex);
		}

        private void LoadItem(int index)
        {
            var item = new CczEditor.Data.Wrapper.ItemData();
            item.Read(index);

            switch(item.Type)
            {
                case ItemType.Weapons:
                case ItemType.Armor:
                    txtName.Text = item.Name;
                    cbItemType.Enabled = true;
                    cbSpecialEffects.Enabled = true;
                    cbItemEffects.Enabled = false;
                    ncInitialValue.Enabled = true;
                    ncSpecialEffectsValue.Enabled = true;
                    ncUpgradeValue.Enabled = true;
                    cbCorps.Enabled = false;
                    cbItemHitarea.Enabled = false;
                    cbBombEffects.Enabled = false;
                    EffectsRange.Enabled = false;
                    AtkRange.Enabled = false;
                    BombType.Enabled = false;
                    ncSpecialEffectsValue.Maximum = 255;

                    cbItemType.SelectedIndex = cbItemType.FindString(Utils.GetString(item.WeaponTypeIndex));
                    cbSpecialEffects.SelectedIndex = cbSpecialEffects.FindString(Utils.GetString(item.SpecialEffectIndex));
                    cbItemEffects.SelectedIndex = -1;
                    ncInitialValue.Value = item.InitValue;
                    ncSpecialEffectsValue.Value = item.SpecialEffectValue;
                    ncUpgradeValue.Value = item.IncreaseValue;
                    cbCorps.SelectedIndex = -1;
                    cbItemHitarea.SelectedIndex = -1;
                    pbItemHitarea.Image = null;
                    pbEffectRange.Image = null;
                    pbAtkRange.Image = null;
                    EffectsRange.SelectedIndex = -1;
                    AtkRange.SelectedIndex = -1;
                    BombType.SelectedIndex = -1;
                    cbBombEffects.SelectedIndex = -1;

                    ncPrice.Value = item.Cost;
                    ncItemIcon.Value = item.IconIndex;
                    break;
                case ItemType.Auxiliary:
                    txtName.Text = item.Name;
                    cbItemType.Enabled = false;
                    cbSpecialEffects.Enabled = true;
                    cbItemEffects.Enabled = false;
                    ncInitialValue.Enabled = false;
                    ncSpecialEffectsValue.Enabled = true;
                    ncUpgradeValue.Enabled = false;
                    cbCorps.Enabled = true;
                    cbItemHitarea.Enabled = false;
                    cbBombEffects.Enabled = false;
                    EffectsRange.Enabled = false;
                    AtkRange.Enabled = false;
                    BombType.Enabled = false;
                    ncSpecialEffectsValue.Maximum = 255;

                    cbItemType.SelectedIndex = -1;
                    cbSpecialEffects.SelectedIndex = cbSpecialEffects.FindString(Utils.GetString(item.SpecialEffectIndex));
                    cbItemEffects.SelectedIndex = -1;
                    ncInitialValue.Value = 0;
                    ncSpecialEffectsValue.Value = item.SpecialEffectValue;
                    ncUpgradeValue.Value = 0;
                    cbCorps.SelectedIndex = cbCorps.FindString(Utils.GetString(item.EquipForceIndex));
                    cbItemHitarea.SelectedIndex = -1;
                    pbItemHitarea.Image = null;
                    pbEffectRange.Image = null;
                    pbAtkRange.Image = null;
                    EffectsRange.SelectedIndex = -1;
                    AtkRange.SelectedIndex = -1;
                    BombType.SelectedIndex = -1;
                    cbBombEffects.SelectedIndex = -1;

                    ncPrice.Value = item.Cost;
                    ncItemIcon.Value = item.IconIndex;
                    break;
                case ItemType.Consumables:
                    txtName.Text = item.Name;
                    cbItemType.Enabled = false;
                    cbSpecialEffects.Enabled = false;
                    cbItemEffects.Enabled = true;
                    ncInitialValue.Enabled = true;
                    ncSpecialEffectsValue.Enabled = false;
                    ncUpgradeValue.Enabled = false;
                    cbCorps.Enabled = false;
                    cbItemHitarea.Enabled = Program.CurrentConfig.CodeOptionContainer.ItemCustomRange;
                    cbBombEffects.Enabled = false;
                    EffectsRange.Enabled = false;
                    AtkRange.Enabled = false;
                    BombType.Enabled = false;
                    ncSpecialEffectsValue.Maximum = 255;

                    cbItemType.SelectedIndex = -1;
                    cbSpecialEffects.SelectedIndex = -1;
                    cbItemEffects.SelectedIndex = cbItemEffects.FindString(Utils.GetString(item.ItemEffectIndex));
                    ncInitialValue.Value = item.InitValue;
                    ncSpecialEffectsValue.Value = 0;
                    ncUpgradeValue.Value = 0;
                    cbCorps.SelectedIndex = -1;
                    if (Program.CurrentConfig.CodeOptionContainer.ItemCustomRange)
                    {
                        cbItemHitarea.SelectedIndex = item.ItemRange;
                        cbItemHitarea_SelectedIndexChanged(cbItemHitarea, new EventArgs());
                    }
                    pbEffectRange.Image = null;
                    pbAtkRange.Image = null;
                    EffectsRange.SelectedIndex = -1;
                    AtkRange.SelectedIndex = -1;
                    BombType.SelectedIndex = -1;
                    cbBombEffects.SelectedIndex = -1;

                    ncPrice.Value = item.Cost;
                    ncItemIcon.Value = item.IconIndex;
                    break;
                case ItemType.bombs:
                    txtName.Text = item.Name;
                    cbItemType.Enabled = false;
                    cbSpecialEffects.Enabled = false;
                    cbItemEffects.Enabled = false;
                    ncInitialValue.Enabled = false;
                    ncSpecialEffectsValue.Enabled = true;
                    ncUpgradeValue.Enabled = false;
                    cbCorps.Enabled = false;
                    cbItemHitarea.Enabled = false;
                    cbBombEffects.Enabled = true;
                    EffectsRange.Enabled = false;
                    AtkRange.Enabled = false;
                    BombType.Enabled = false;
                    ncSpecialEffectsValue.Maximum = 65535;

                    cbItemType.SelectedIndex = -1;
                    cbSpecialEffects.SelectedIndex = -1;
                    cbItemEffects.SelectedIndex = -1;
                    ncInitialValue.Value = 0;
                    ncUpgradeValue.Value = 0;
                    cbCorps.SelectedIndex = -1;
                    cbItemHitarea.SelectedIndex = -1;
                    pbItemHitarea.Image = null;
                    pbEffectRange.Image = null;
                    pbAtkRange.Image = null;
                    EffectsRange.SelectedIndex = -1;
                    AtkRange.SelectedIndex = -1;
                    BombType.SelectedIndex = -1;

                    cbBombEffects.SelectedIndex = item.BombEffectIndex - (Program.CurrentConfig.Items.MineInstall - 1);
                    ncPrice.Value = item.Cost;
                    ncItemIcon.Value = item.IconIndex;
                    ncSpecialEffectsValue.Value = item.BombEffectValue;
                    break;
                case ItemType.bombs2:
                    txtName.Text = item.Name;
                    cbItemType.Enabled = false;
                    cbSpecialEffects.Enabled = false;
                    cbItemEffects.Enabled = false;
                    ncInitialValue.Enabled = false;
                    ncSpecialEffectsValue.Enabled = true;
                    ncUpgradeValue.Enabled = false;
                    cbCorps.Enabled = false;
                    cbItemHitarea.Enabled = false;
                    cbBombEffects.Enabled = true;
                    EffectsRange.Enabled = true;
                    AtkRange.Enabled = false;
                    BombType.Enabled = true;
                    ncSpecialEffectsValue.Maximum = 65535;

                    cbItemType.SelectedIndex = -1;
                    cbSpecialEffects.SelectedIndex = -1;
                    cbItemEffects.SelectedIndex = -1;
                    ncInitialValue.Value = 0;
                    ncUpgradeValue.Value = 0;
                    cbCorps.SelectedIndex = -1;
                    cbItemHitarea.SelectedIndex = -1;
                    AtkRange.SelectedIndex = -1;
                    pbItemHitarea.Image = null;

                    BombType.SelectedIndex = item.BombTypeIndex;
                    cbBombEffects.SelectedIndex = item.BombEffectIndex - (Program.CurrentConfig.Items.MineInstall - 1);
                    ncPrice.Value = item.Cost;
                    ncItemIcon.Value = item.IconIndex;
                    ncSpecialEffectsValue.Value = item.BombEffectValue;
                    EffectsRange.SelectedIndex = item.EffectRange;
                    break;
                case ItemType.bombs3:
                    txtName.Text = item.Name;
                    cbItemType.Enabled = false;
                    cbSpecialEffects.Enabled = false;
                    cbItemEffects.Enabled = false;
                    ncInitialValue.Enabled = false;
                    ncSpecialEffectsValue.Enabled = true;
                    ncUpgradeValue.Enabled = false;
                    cbCorps.Enabled = false;
                    cbItemHitarea.Enabled = false;
                    cbBombEffects.Enabled = true;
                    EffectsRange.Enabled = true;
                    AtkRange.Enabled = true;
                    BombType.Enabled = false;
                    ncSpecialEffectsValue.Maximum = 65535;

                    cbItemType.SelectedIndex = -1;
                    cbSpecialEffects.SelectedIndex = -1;
                    cbItemEffects.SelectedIndex = -1;
                    ncInitialValue.Value = 0;
                    ncUpgradeValue.Value = 0;
                    cbCorps.SelectedIndex = -1;
                    cbItemHitarea.SelectedIndex = -1;
                    BombType.SelectedIndex = -1;
                    pbItemHitarea.Image = null;

                    AtkRange.SelectedIndex = item.AttackRange;
                    cbBombEffects.SelectedIndex = item.BombEffectIndex - (Program.CurrentConfig.Items.MineInstall - 1);
                    ncPrice.Value = item.Cost;
                    ncItemIcon.Value = item.IconIndex;
                    ncSpecialEffectsValue.Value = item.BombEffectValue;
                    EffectsRange.SelectedIndex = item.EffectRange;
                    break;
                default:
                    txtName.Text = item.Name;
                    cbItemType.Enabled = true;
                    cbSpecialEffects.Enabled = true;
                    cbItemEffects.Enabled = true;
                    ncInitialValue.Enabled = true;
                    ncSpecialEffectsValue.Enabled = true;
                    ncUpgradeValue.Enabled = true;
                    cbCorps.Enabled = true;
                    cbItemHitarea.Enabled = false;
                    ncSpecialEffectsValue.Maximum = 255;
                    cbBombEffects.Enabled = true;
                    EffectsRange.Enabled = false;
                    AtkRange.Enabled = false;
                    BombType.Enabled = false;

                    cbItemType.SelectedIndex = cbItemType.FindString(Utils.GetString(0xFF));
                    cbSpecialEffects.SelectedIndex = cbSpecialEffects.FindString(Utils.GetString(0xFF));
                    cbItemEffects.SelectedIndex = cbItemEffects.FindString(Utils.GetString(0xFF));
                    ncInitialValue.Value = 0;
                    ncSpecialEffectsValue.Value = 0;
                    ncUpgradeValue.Value = 0;
                    cbCorps.SelectedIndex = -1;
                    cbItemHitarea.SelectedIndex = -1;
                    pbItemHitarea.Image = null;
                    pbEffectRange.Image = null;
                    pbAtkRange.Image = null;
                    EffectsRange.SelectedIndex = -1;
                    AtkRange.SelectedIndex = -1;
                    cbBombEffects.SelectedIndex = cbBombEffects.FindString(Utils.GetString(0xFF));
                    BombType.SelectedIndex = -1;

                    ncPrice.Value = item.Cost;
                    ncItemIcon.Value = item.IconIndex;
                    break;
            }

            checkBox1.Checked = item.Treasure == 0x00 ? false : true;
            if (ImsgDataLoaded)
            {
                if (lbList.SelectedIndex < 0 || lbList.SelectedIndex >= lbList.Items.Count)
                {
                    return;
                }
                var msg = ImsgData.ItemGet(lbList.SelectedIndex);
                txtImsg.Text = Utils.ByteToString(msg, 0, Program.IMSG_DATA_BLOCK_LENGTH);
            }
            if (TopLevelControl != null)
            {
                TopLevelControl.Text = string.Format("{1} - 물품 편집 - 번호：{0}", lbList.SelectedIndex, Program.TitleNameCurrent);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
		{
			if (lbList.SelectedIndex < 0 || lbList.SelectedIndex >= lbList.Items.Count)
			{
				return;
			}
            //Imsg저장
            if (ImsgDataLoaded)
            {
                var msg = ImsgData.ItemGet(lbList.SelectedIndex);
                Utils.ChangeByteValue(msg, Utils.GetBytes(txtImsg.Text), 0, Program.IMSG_DATA_BLOCK_LENGTH);
                ImsgData.ItemSet(lbList.SelectedIndex, msg);
            }

            //Data저장
            var index = lbList.SelectedIndex;
            var item = GameData.ItemGet(index);
            Utils.ChangeByteValue(item, Utils.GetBytes(txtName.Text), 0, 16);            
			//16 0x00
			//17,18,21,22,23
			switch (GameData.GetItemType(item[17]))
			{
				case ItemType.Weapons:
				case ItemType.Armor:
				{
                    Utils.ChangeByteValue(item, Utils.GetBytes(txtName.Text), 0, 16);
					item[17] = (byte)Utils.GetId(cbItemType.SelectedItem);
					item[18] = (byte)Utils.GetId(cbSpecialEffects.SelectedItem);
                    item[19] = (byte)ncPrice.Value;
                    item[20] = (byte)ncItemIcon.Value;
					item[21] = (byte)ncInitialValue.Value;
					item[22] = (byte)ncSpecialEffectsValue.Value;
					item[23] = (byte)ncUpgradeValue.Value;
					break;
				}
				case ItemType.Auxiliary:
				{
                    Utils.ChangeByteValue(item, Utils.GetBytes(txtName.Text), 0, 16);
					item[17] = (byte)Utils.GetId(cbSpecialEffects.SelectedItem);
					item[18] = 0xFF;
                    item[19] = (byte)ncPrice.Value;
                    item[20] = (byte)ncItemIcon.Value;
					item[21] = (byte)ncSpecialEffectsValue.Value;
					item[22] = 0x0;
					item[23] = (byte)Utils.GetId(cbCorps.SelectedItem);
					break;
				}
				case ItemType.Consumables:
				{
                    Utils.ChangeByteValue(item, Utils.GetBytes(txtName.Text), 0, 16);
					item[17] = (byte)Utils.GetId(cbItemEffects.SelectedItem);
					item[18] = 0xFF;
                    item[19] = (byte)ncPrice.Value;
                    item[20] = (byte)ncItemIcon.Value;
					item[21] = (byte)ncInitialValue.Value;
					item[22] = 0x0;
					if (Program.CurrentConfig.CodeOptionContainer.ItemCustomRange)
					{
						item[23] = (byte)(cbItemHitarea.SelectedIndex == -1 ? 0 : cbItemHitarea.SelectedIndex);
					}
					else
					{
						item[23] = 0x0;
					}
					break;
				}
                case ItemType.bombs:
                {
                    Utils.ChangeByteValue(item, Utils.GetBytes(txtName.Text), 0, 15);
                    item[16] = 0x00;
                    item[17] = (byte)Utils.GetId(cbBombEffects.SelectedItem);
                    item[18] = (byte)ncPrice.Value;
                    item[19] = (byte)ncItemIcon.Value;
                    item[20] = 0xFF;
                    Utils.ChangeByteValue(item, BitConverter.GetBytes((ushort)ncSpecialEffectsValue.Value), 21);
                    item[23] = 0x00;
                    break;
                }
                case ItemType.bombs2:
                {
                    Utils.ChangeByteValue(item, Utils.GetBytes(txtName.Text), 0, 15);
                    item[16] = (byte)(BombType.SelectedIndex == -1 ? 0 : BombType.SelectedIndex);
                    item[17] = (byte)Utils.GetId(cbBombEffects.SelectedItem);
                    item[18] = (byte)ncPrice.Value;
                    item[19] = (byte)ncItemIcon.Value;
                    item[20] = 0xFF;
                    Utils.ChangeByteValue(item, BitConverter.GetBytes((ushort)ncSpecialEffectsValue.Value), 21);
                    item[23] = (byte)(EffectsRange.SelectedIndex == -1 ? 0 : EffectsRange.SelectedIndex);
                    break;
                }
                case ItemType.bombs3:
                {
                    Utils.ChangeByteValue(item, Utils.GetBytes(txtName.Text), 0, 15);
                    item[16] = (byte)(AtkRange.SelectedIndex == -1 ? 0 : AtkRange.SelectedIndex);
                    item[17] = (byte)Utils.GetId(cbBombEffects.SelectedItem);
                    item[18] = (byte)ncPrice.Value;
                    item[19] = (byte)ncItemIcon.Value;
                    item[20] = 0xFF;
                    Utils.ChangeByteValue(item, BitConverter.GetBytes((ushort)ncSpecialEffectsValue.Value), 21);
                    item[23] = (byte)(EffectsRange.SelectedIndex == -1 ? 0 : EffectsRange.SelectedIndex);
                    break;
                }
				case ItemType.Unknow:
				{
					var type1 = (byte)Utils.GetId(cbItemType.SelectedItem);
					var type2 = (byte)Utils.GetId(cbSpecialEffects.SelectedItem);
                    var type3 = (byte)Utils.GetId(cbItemEffects.SelectedItem);
                    var type4 = (byte)Utils.GetId(cbBombEffects.SelectedItem);
					if (type1 == 0xFF && type2 == 0xFF && type3 != 0xFF && type4 == 0xFF)
                    {
                        Utils.ChangeByteValue(item, Utils.GetBytes(txtName.Text), 0, 16);
						item[17] = type3;
						item[18] = 0xFF;
						item[21] = (byte)ncInitialValue.Value;
						item[22] = 0x0;
						if (Program.CurrentConfig.CodeOptionContainer.ItemCustomRange)
						{
							item[23] = (byte)(cbItemHitarea.SelectedIndex == -1 ? 0 : cbItemHitarea.SelectedIndex);
						}
						else
						{
							item[23] = 0x0;
						}
					}
					else if (type1 == 0xFF && type2 != 0xFF && type3 == 0xFF && type4 == 0xFF)
                    {
                        Utils.ChangeByteValue(item, Utils.GetBytes(txtName.Text), 0, 16);
						item[17] = type2;
						item[18] = 0xFF;
						item[21] = (byte)ncSpecialEffectsValue.Value;
						item[22] = 0x0;
						item[23] = (byte)Utils.GetId(cbCorps.SelectedItem);
					}
					else if (type1 != 0xFF && type3 == 0xFF && type4 == 0xFF)
                    {
                        Utils.ChangeByteValue(item, Utils.GetBytes(txtName.Text), 0, 16);
						item[17] = type1;
						item[18] = type2;
						item[21] = (byte)ncInitialValue.Value;
						item[22] = (byte)ncSpecialEffectsValue.Value;
						item[23] = (byte)ncUpgradeValue.Value;
					}
                    else if (type1 == 0xFF && type2 == 0xFF && type3 == 0xFF && type4 != 0xFF)
                    {
                        Utils.ChangeByteValue(item, Utils.GetBytes(txtName.Text), 0, 15);
                        if (type4 <= Program.CurrentConfig.Items.MineControl && type4 >= Program.CurrentConfig.Items.MineInstall)
                        {
                            item[16] = 0x00;
                            item[17] = type4;
                            item[18] = (byte)ncPrice.Value;
                            item[19] = (byte)ncItemIcon.Value;
                            item[20] = 0xFF;
                            Utils.ChangeByteValue(item, BitConverter.GetBytes((ushort)ncSpecialEffectsValue.Value), 21);
                            item[23] = 0x00;
                        }
                        else if (type4 == Program.CurrentConfig.Items.Mine)
                        {
                            item[16] = (byte)(BombType.SelectedIndex == -1 ? 0 : BombType.SelectedIndex);
                            item[17] = type4;
                            item[18] = (byte)ncPrice.Value;
                            item[19] = (byte)ncItemIcon.Value;
                            item[20] = 0xFF;
                            Utils.ChangeByteValue(item, BitConverter.GetBytes((ushort)ncSpecialEffectsValue.Value), 21);
                            item[23] = (byte)(EffectsRange.SelectedIndex == -1 ? 0 : EffectsRange.SelectedIndex);
                        }
                        else if (type4 == Program.CurrentConfig.Items.Bomb)
                        {
                            item[16] = (byte)(AtkRange.SelectedIndex == -1 ? 0 : AtkRange.SelectedIndex);
                            item[17] = type4;
                            item[18] = (byte)ncPrice.Value;
                            item[19] = (byte)ncItemIcon.Value;
                            item[20] = 0xFF;
                            Utils.ChangeByteValue(item, BitConverter.GetBytes((ushort)ncSpecialEffectsValue.Value), 21);
                            item[23] = (byte)(EffectsRange.SelectedIndex == -1 ? 0 : EffectsRange.SelectedIndex);
                        }
                    }
					break;
				}
				default:
				{
					break;
				}
			}
            if (checkBox1.Checked == false)
            {
                item[24] = 0;
            }
            else
            {
                item[24] = 1;
            }

            int bomulcount = 0;
            GameData.WriteTreasureCount(bomulcount);

            GameData.ItemSet(index, item);
			lbList.Items.RemoveAt(index);
            lbList.Items.Insert(index, string.Format(Program.FORMATSTRING_KEYVALUEPAIR_HEX2, index, txtName.Text));
			lbList.SelectedIndex = index;
		}

		private void btnRestore_Click(object sender, EventArgs e)
		{
            if (lbList.SelectedIndex < 0 || lbList.SelectedIndex >= lbList.Items.Count)
            {
                return;
            }

            var msg = ImsgData.ItemGet(lbList.SelectedIndex);
            txtImsg.Text = Utils.ByteToString(msg, 0, Program.IMSG_DATA_BLOCK_LENGTH);
			lbList_SelectedIndexChanged(lbList, new EventArgs());

		}
        
		private void txtImsg_TextChanged(object sender, EventArgs e)
        {
            int length = Encoding.Default.GetByteCount(txtImsg.Text);
            lblImsgCount.Text = $"{length} / 200 byte";
		}

		private void ncItemIcon_ValueChanged(object sender, EventArgs e)
		{
			if (ItemIcons == null)
			{
				return;
			}
            pbIcons.Image = Resources.ItemIconResources.Load((int) (ncItemIcon.Value * 2) + 100);
            lbIconSmall.Text = ((ncItemIcon.Value * 2) + 100).ToString();
            pbIcon.Image = Resources.ItemIconResources.Load((int)(ncItemIcon.Value * 2) + 101);
            lbIcon.Text = ((ncItemIcon.Value * 2) + 101).ToString();
        }

		private void cbItemHitarea_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (Program.CurrentConfig.CodeOptionContainer.ItemCustomRange && (Hitareas != null && Hitareas.Exists))
			{
				pbItemHitarea.Image = cbItemHitarea.SelectedIndex == -1 ? null : Hitareas.GetImage(cbItemHitarea.SelectedIndex);
			}
		}
        private void EffectsRange_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (Effareas != null && Effareas.Exists)
            {
                pbEffectRange.Image = EffectsRange.SelectedIndex == -1 ? null : Effareas.GetImage(EffectsRange.SelectedIndex);
            }
        }

        private void AtkRange_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Hitareas != null && Hitareas.Exists)
            {
                pbAtkRange.Image = AtkRange.SelectedIndex == -1 ? null : Hitareas.GetImage(AtkRange.SelectedIndex);
            }
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            var list = GameData.ItemNameList(null);
            var index = list.FindIndex(x => x == searchTextBox.Text);
            if (index == -1)
            {
                MessageBox.Show("찾기에 실패했습니다.", "경고", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            lbList.SelectedIndex = index;
        }

        private void cbSpecialEffects_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Data.ExeData.IsLocked || cbSpecialEffects.SelectedIndex < 0)
            {
                SpecialEffListLabel.Text = string.Empty;
                SpecialEffNameEditBox.Text = string.Empty;
                SpecialEffNameEditBox.Enabled = false;
                SpecialEffNameEditButton.Enabled = false;
                return;
            }

            SpecialEffNameEditBox.Enabled = true;
            SpecialEffNameEditButton.Enabled = true;

            var code = Utils.GetId(cbSpecialEffects.SelectedItem);
            var effName = ConfigUtils.GetAuxiliaryEffect(code);
            if (string.IsNullOrEmpty(effName))
            {
                SpecialEffNameEditBox.Enabled = false;
            }
            else
            {
                SpecialEffNameEditBox.Enabled = true;
            }
            SpecialEffNameEditBox.Text = effName;


            StringBuilder sb = new StringBuilder();
            sb.Append("특수효과 리스트\n");
            var list = Program.CurrentConfig.CodeEffects;
            int count = 0;
            foreach(var eff in list)
            {
                var checkCode = Data.ExeData.ReadByte(0, eff.Offset);
                if (checkCode != code) continue;
                sb.Append($"-{eff.Description}");
                sb.Append("\n");
                count++;
            }
            if (count == 0) sb.Append("-없음");
            SpecialEffListLabel.Text = sb.ToString();
        }

        private void SpecialEffNameEditButton_Click(object sender, EventArgs e)
        {
            var code = Utils.GetId(cbSpecialEffects.SelectedItem);
            var target = Program.CurrentConfig.ItemEffects.Find(x => x.Index == code);
            if (target == null) return;

            int length = Encoding.Default.GetByteCount(SpecialEffNameEditBox.Text);
            if (length > target.Length)
            {
                MessageBox.Show("이름이 너무 깁니다!");
                return;
            }

            Data.ExeData.WriteText(SpecialEffNameEditBox.Text, target.Offset, target.Length);
        }

        private void SpecialEffNameEditBox_TextChanged(object sender, EventArgs e)
        {
            var code = Utils.GetId(cbSpecialEffects.SelectedItem);
            var target = Program.CurrentConfig.ItemEffects.Find(x => x.Index == code);
            if (target == null) return;

            int length = Encoding.Default.GetByteCount(SpecialEffNameEditBox.Text);
            EffNameLabel.Text = $"{length}/{target.Length} byte";
        }
    }
}