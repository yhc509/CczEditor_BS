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
	public partial class ItemController : BaseDataControl
	{
        Data.Wrapper.ItemData CurrentData;
        Data.Wrapper.CodeEffectNameData CurrentCodeEffectNameData;

		public ItemController()
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
            cbItemType.Items.AddRange(ConfigUtils.GetEquipmentTypes(Program.ExeData, Program.CurrentConfig, Program.FORMATSTRING_KEYVALUEPAIR_HEX2).Values.ToArray());

			cbSpecialEffects.Items.Add("FF,능력 없음");
            cbSpecialEffects.Items.AddRange(ConfigUtils.GetAuxiliaryEffects(Program.ExeData, Program.CurrentConfig, Program.FORMATSTRING_KEYVALUEPAIR_HEX2).Values.ToArray());
     
			cbItemEffects.Items.Add("FF,효과 없음");
            cbItemEffects.Items.AddRange(ConfigUtils.GetConsumablesEffects(Program.ExeData, Program.CurrentConfig, Program.FORMATSTRING_KEYVALUEPAIR_HEX2).Values.ToArray());

			cbCorps.Items.Add("FF,모든 병종");
            cbCorps.Items.AddRange(ConfigUtils.GetForceCategoryNames(Program.ExeData, Program.CurrentConfig, Program.FORMATSTRING_KEYVALUEPAIR_HEX2).Values.ToArray());

            cbItemHitarea.Items.AddRange(Program.CurrentConfig.HitAreaNames.ToArray());
			lbList.Items.AddRange(DataUtils.ItemNameList(Program.GameData, Program.StarData, true).ToArray());

            if (Program.StarData != null && Program.StarData.CurrentFile != null && Program.StarData.CurrentStream != null)
            {
                cbBombEffects.Items.Add("FF,효과 없음");
                cbBombEffects.Items.AddRange(ConfigUtils.GetBombsEffects(Program.ExeData, Program.CurrentConfig, Program.FORMATSTRING_KEYVALUEPAIR_HEX2).Values.ToArray());
                cbBombEffects.Items.AddRange(ConfigUtils.GetBombsEffects2(Program.ExeData, Program.CurrentConfig, Program.FORMATSTRING_KEYVALUEPAIR_HEX2).Values.ToArray());
                cbBombEffects.Items.AddRange(ConfigUtils.GetBombsEffects3(Program.ExeData, Program.CurrentConfig, Program.FORMATSTRING_KEYVALUEPAIR_HEX2).Values.ToArray());
                EffectsRange.Items.AddRange(Program.CurrentConfig.EffAreaNames.ToArray());
                AtkRange.Items.AddRange(Program.CurrentConfig.HitAreaNames.ToArray());
            }
            
		}

        public override void Reset()
        {
            base.Reset();
            CurrentData = new Data.Wrapper.ItemData();
            CurrentCodeEffectNameData = new Data.Wrapper.CodeEffectNameData();
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
            CurrentData.Read(index, Program.GameData, Program.ImsgData, Program.ExeData, Program.CurrentConfig);

            switch(CurrentData.Type)
            {
                case ItemType.Weapons:
                case ItemType.Armor:
                    txtName.Text = CurrentData.Name;
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

                    cbItemType.SelectedIndex = cbItemType.FindString(Utils.GetString(CurrentData.WeaponTypeIndex));
                    cbSpecialEffects.SelectedIndex = cbSpecialEffects.FindString(Utils.GetString(CurrentData.SpecialEffectIndex));
                    cbItemEffects.SelectedIndex = -1;
                    ncInitialValue.Value = CurrentData.InitValue;
                    ncSpecialEffectsValue.Value = CurrentData.SpecialEffectValue;
                    ncUpgradeValue.Value = CurrentData.IncreaseValue;
                    cbCorps.SelectedIndex = -1;
                    cbItemHitarea.SelectedIndex = -1;
                    pbItemHitarea.Image = null;
                    pbEffectRange.Image = null;
                    pbAtkRange.Image = null;
                    EffectsRange.SelectedIndex = -1;
                    AtkRange.SelectedIndex = -1;
                    BombType.SelectedIndex = -1;
                    cbBombEffects.SelectedIndex = -1;

                    ncPrice.Value = CurrentData.Cost;
                    ncItemIcon.Value = CurrentData.IconIndex;
                    break;
                case ItemType.Auxiliary:
                    txtName.Text = CurrentData.Name;
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
                    cbSpecialEffects.SelectedIndex = cbSpecialEffects.FindString(Utils.GetString(CurrentData.SpecialEffectIndex));
                    cbItemEffects.SelectedIndex = -1;
                    ncInitialValue.Value = 0;
                    ncSpecialEffectsValue.Value = CurrentData.SpecialEffectValue;
                    ncUpgradeValue.Value = 0;
                    cbCorps.SelectedIndex = cbCorps.FindString(Utils.GetString(CurrentData.EquipForceIndex));
                    cbItemHitarea.SelectedIndex = -1;
                    pbItemHitarea.Image = null;
                    pbEffectRange.Image = null;
                    pbAtkRange.Image = null;
                    EffectsRange.SelectedIndex = -1;
                    AtkRange.SelectedIndex = -1;
                    BombType.SelectedIndex = -1;
                    cbBombEffects.SelectedIndex = -1;

                    ncPrice.Value = CurrentData.Cost;
                    ncItemIcon.Value = CurrentData.IconIndex;
                    break;
                case ItemType.Consumables:
                    txtName.Text = CurrentData.Name;
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
                    cbItemEffects.SelectedIndex = cbItemEffects.FindString(Utils.GetString(CurrentData.ItemEffectIndex));
                    ncInitialValue.Value = CurrentData.InitValue;
                    ncSpecialEffectsValue.Value = 0;
                    ncUpgradeValue.Value = 0;
                    cbCorps.SelectedIndex = -1;
                    if (Program.CurrentConfig.CodeOptionContainer.ItemCustomRange)
                    {
                        cbItemHitarea.SelectedIndex = CurrentData.ItemRange;
                        cbItemHitarea_SelectedIndexChanged(cbItemHitarea, new EventArgs());
                    }
                    pbEffectRange.Image = null;
                    pbAtkRange.Image = null;
                    EffectsRange.SelectedIndex = -1;
                    AtkRange.SelectedIndex = -1;
                    BombType.SelectedIndex = -1;
                    cbBombEffects.SelectedIndex = -1;

                    ncPrice.Value = CurrentData.Cost;
                    ncItemIcon.Value = CurrentData.IconIndex;
                    break;
                case ItemType.BombTools:
                    txtName.Text = CurrentData.Name;
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

                    cbBombEffects.SelectedIndex = CurrentData.BombEffectIndex - (Program.CurrentConfig.Items.MineInstall - 1);
                    ncPrice.Value = CurrentData.Cost;
                    ncItemIcon.Value = CurrentData.IconIndex;
                    ncSpecialEffectsValue.Value = CurrentData.BombEffectValue;
                    break;
                case ItemType.Bombs:
                    txtName.Text = CurrentData.Name;
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

                    BombType.SelectedIndex = CurrentData.BombTypeIndex;
                    cbBombEffects.SelectedIndex = CurrentData.BombEffectIndex - (Program.CurrentConfig.Items.MineInstall - 1);
                    ncPrice.Value = CurrentData.Cost;
                    ncItemIcon.Value = CurrentData.IconIndex;
                    ncSpecialEffectsValue.Value = CurrentData.BombEffectValue;
                    EffectsRange.SelectedIndex = CurrentData.EffectRange;
                    break;
                case ItemType.BombMines:
                    txtName.Text = CurrentData.Name;
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

                    AtkRange.SelectedIndex = CurrentData.AttackRange;
                    cbBombEffects.SelectedIndex = CurrentData.BombEffectIndex - (Program.CurrentConfig.Items.MineInstall - 1);
                    ncPrice.Value = CurrentData.Cost;
                    ncItemIcon.Value = CurrentData.IconIndex;
                    ncSpecialEffectsValue.Value = CurrentData.BombEffectValue;
                    EffectsRange.SelectedIndex = CurrentData.EffectRange;
                    break;
                default:
                    txtName.Text = CurrentData.Name;
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

                    ncPrice.Value = CurrentData.Cost;
                    ncItemIcon.Value = CurrentData.IconIndex;
                    break;
            }

            checkBox1.Checked = CurrentData.Treasure == 0x00 ? false : true;
            if (ImsgDataLoaded)
            {
                if (lbList.SelectedIndex < 0 || lbList.SelectedIndex >= lbList.Items.Count)
                {
                    return;
                }
                var msg = Program.ImsgData.ItemGet(lbList.SelectedIndex);
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
            
            var index = lbList.SelectedIndex;
            
            switch (CurrentData.Type)
			{
				case ItemType.Weapons:
				case ItemType.Armor:
                    CurrentData.Name = txtName.Text;
                    CurrentData.WeaponTypeIndex = (byte)Utils.GetId(cbItemType.SelectedItem);
                    CurrentData.SpecialEffectIndex = (byte)Utils.GetId(cbSpecialEffects.SelectedItem);
                    CurrentData.Cost = (byte)ncPrice.Value;
                    CurrentData.IconIndex = (byte)ncItemIcon.Value;
                    CurrentData.InitValue = (byte)ncInitialValue.Value;
                    CurrentData.SpecialEffectValue = (byte)ncSpecialEffectsValue.Value;
                    CurrentData.IncreaseValue = (byte)ncUpgradeValue.Value;
                    break;
				case ItemType.Auxiliary:
                    CurrentData.Name = txtName.Text;
                    CurrentData.SpecialEffectIndex = (byte)Utils.GetId(cbSpecialEffects.SelectedItem);
                    CurrentData.Cost = (byte)ncPrice.Value;
                    CurrentData.IconIndex = (byte)ncItemIcon.Value;
                    CurrentData.SpecialEffectValue = (byte)ncSpecialEffectsValue.Value;
                    CurrentData.EquipForceIndex = (byte)Utils.GetId(cbCorps.SelectedItem);
                    break;
				case ItemType.Consumables:
                    CurrentData.Name = txtName.Text;
                    CurrentData.ItemEffectIndex = (byte)Utils.GetId(cbItemEffects.SelectedItem);
                    CurrentData.Cost = (byte)ncPrice.Value;
                    CurrentData.IconIndex = (byte)ncItemIcon.Value;
                    CurrentData.InitValue = (byte)ncInitialValue.Value;
                    CurrentData.ItemRange = (byte)(cbItemHitarea.SelectedIndex == -1 ? 0 : cbItemHitarea.SelectedIndex);
                    break;
                case ItemType.BombTools:
                    CurrentData.Name = txtName.Text;
                    CurrentData.BombEffectIndex = (byte)Utils.GetId(cbBombEffects.SelectedItem);
                    CurrentData.Cost = (byte)ncPrice.Value;
                    CurrentData.IconIndex = (byte)ncItemIcon.Value;
                    CurrentData.BombEffectValue = (ushort)ncSpecialEffectsValue.Value;
                    break;
                case ItemType.Bombs:
                    CurrentData.Name = txtName.Text;
                    CurrentData.BombTypeIndex = (byte)(BombType.SelectedIndex == -1 ? 0 : BombType.SelectedIndex);
                    CurrentData.BombEffectIndex = (byte)Utils.GetId(cbBombEffects.SelectedItem);
                    CurrentData.Cost = (byte)ncPrice.Value;
                    CurrentData.IconIndex = (byte)ncItemIcon.Value;
                    CurrentData.BombEffectValue = (ushort)ncSpecialEffectsValue.Value;
                    CurrentData.EffectRange = (byte) EffectsRange.SelectedIndex;
                    break;
                case ItemType.BombMines:
                    CurrentData.Name = txtName.Text;
                    CurrentData.AttackRange = (byte) AtkRange.SelectedIndex;
                    CurrentData.BombEffectIndex = (byte)Utils.GetId(cbBombEffects.SelectedItem);
                    CurrentData.Cost = (byte)ncPrice.Value;
                    CurrentData.IconIndex = (byte)ncItemIcon.Value;
                    CurrentData.BombEffectValue = (ushort)ncSpecialEffectsValue.Value;
                    CurrentData.EffectRange = (byte) EffectsRange.SelectedIndex;
                    break;
				case ItemType.None:
					var type1 = (byte)Utils.GetId(cbItemType.SelectedItem);
					var type2 = (byte)Utils.GetId(cbSpecialEffects.SelectedItem);
                    var type3 = (byte)Utils.GetId(cbItemEffects.SelectedItem);
                    var type4 = (byte)Utils.GetId(cbBombEffects.SelectedItem);

                    bool isConsumables = (type1 == 0xFF && type2 == 0xFF && type3 != 0xFF && type4 == 0xFF);
                    bool isAuxiliary = (type1 == 0xFF && type2 != 0xFF && type3 == 0xFF && type4 == 0xFF);
                    bool isWeaponOrArmor = (type1 != 0xFF && type3 == 0xFF && type4 == 0xFF);
                    bool isBomb = (type1 == 0xFF && type2 == 0xFF && type3 == 0xFF && type4 != 0xFF);

                    if (isConsumables)
                    {
                        CurrentData.Name = txtName.Text;
                        CurrentData.Type = ItemType.Consumables;
                        CurrentData.ItemEffectIndex = (byte)Utils.GetId(cbItemEffects.SelectedItem);
                        CurrentData.Cost = (byte)ncPrice.Value;
                        CurrentData.IconIndex = (byte)ncItemIcon.Value;
                        CurrentData.InitValue = (byte)ncInitialValue.Value;
                        CurrentData.ItemRange = (byte)(cbItemHitarea.SelectedIndex == -1 ? 0 : cbItemHitarea.SelectedIndex);
                    }
					else if (isAuxiliary)
                    {
                        CurrentData.Type = ItemType.Auxiliary;
                        CurrentData.WeaponTypeIndex = (byte)Utils.GetId(cbItemType.SelectedItem);
                        CurrentData.SpecialEffectIndex = (byte)Utils.GetId(cbSpecialEffects.SelectedItem);
                        CurrentData.Cost = (byte)ncPrice.Value;
                        CurrentData.IconIndex = (byte)ncItemIcon.Value;
                        CurrentData.InitValue = (byte)ncInitialValue.Value;
                        CurrentData.SpecialEffectValue = (byte)ncSpecialEffectsValue.Value;
                        CurrentData.IncreaseValue = (byte)ncUpgradeValue.Value;
                    }
					else if (isWeaponOrArmor)
                    {
                        CurrentData.Name = txtName.Text;
                        CurrentData.Type = type1 >= Program.CurrentConfig.Items.WeaponIndexMax ? ItemType.Armor : ItemType.Weapons;
                        CurrentData.WeaponTypeIndex = (byte)Utils.GetId(cbItemType.SelectedItem);
                        CurrentData.SpecialEffectIndex = (byte)Utils.GetId(cbSpecialEffects.SelectedItem);
                        CurrentData.IconIndex = (byte)ncItemIcon.Value;
                        CurrentData.InitValue = (byte)ncInitialValue.Value;
                        CurrentData.SpecialEffectValue = (byte)ncSpecialEffectsValue.Value;
                        CurrentData.IncreaseValue = (byte)ncUpgradeValue.Value;
					}
                    else if (isBomb)
                    {
                        CurrentData.Name = txtName.Text;
                        if (type4 <= Program.CurrentConfig.Items.MineControl && type4 >= Program.CurrentConfig.Items.MineInstall)
                        {
                            CurrentData.Type = ItemType.BombTools;
                            CurrentData.BombEffectIndex = (byte)Utils.GetId(cbBombEffects.SelectedItem);
                            CurrentData.Cost = (byte)ncPrice.Value;
                            CurrentData.IconIndex = (byte)ncItemIcon.Value;
                            CurrentData.BombEffectValue = (ushort)ncSpecialEffectsValue.Value;

                        }
                        else if (type4 == Program.CurrentConfig.Items.Mine)
                        {
                            CurrentData.Type = ItemType.BombMines;
                            CurrentData.BombTypeIndex = (byte)(BombType.SelectedIndex == -1 ? 0 : BombType.SelectedIndex);
                            CurrentData.BombEffectIndex = (byte)Utils.GetId(cbBombEffects.SelectedItem);
                            CurrentData.Cost = (byte)ncPrice.Value;
                            CurrentData.IconIndex = (byte)ncItemIcon.Value;
                            CurrentData.BombEffectValue = (ushort)ncSpecialEffectsValue.Value;
                            CurrentData.EffectRange = (byte)EffectsRange.SelectedIndex;
                        }
                        else if (type4 == Program.CurrentConfig.Items.Bomb)
                        {
                            CurrentData.BombTypeIndex = (byte)(BombType.SelectedIndex == -1 ? 0 : BombType.SelectedIndex);
                            CurrentData.BombEffectIndex = (byte)Utils.GetId(cbBombEffects.SelectedItem);
                            CurrentData.Cost = (byte)ncPrice.Value;
                            CurrentData.IconIndex = (byte)ncItemIcon.Value;
                            CurrentData.BombEffectValue = (ushort)ncSpecialEffectsValue.Value;
                            CurrentData.EffectRange = (byte)EffectsRange.SelectedIndex;
                        }
                    }
					break;
				
				default:
				{
					break;
				}
			}
            CurrentData.Treasure = (byte) (checkBox1.Checked ? 1 : 0);

            CurrentData.Imsg = txtImsg.Text;
            
            CurrentData.Write(index, Program.GameData, Program.StarData, Program.ImsgData, Program.ExeData, Program.CurrentConfig);

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

            var msg = Program.ImsgData.ItemGet(lbList.SelectedIndex);
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
            var list = DataUtils.ItemNameList(Program.GameData, Program.StarData, false);
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
            if (Program.ExeData.IsLocked || cbSpecialEffects.SelectedIndex < 0)
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

            CurrentCodeEffectNameData.Read(code, Program.ExeData, Program.CurrentConfig);

            var effName = CurrentCodeEffectNameData.Name;//ConfigUtils.GetAuxiliaryEffect(Program.ExeData, Program.CurrentConfig, code);
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
                var checkCode = Program.ExeData.ReadByte(0, eff.Offset);
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
            try
            {
                var code = Utils.GetId(cbSpecialEffects.SelectedItem);

                CurrentCodeEffectNameData.Name = SpecialEffNameEditBox.Text;
                CurrentCodeEffectNameData.Write(code, Program.ExeData, Program.CurrentConfig);
            }
            catch(Data.Wrapper.CodeEffectNameData.IsLongNameException)
            {
                MessageBox.Show("이름이 너무 깁니다!");
            }
            
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