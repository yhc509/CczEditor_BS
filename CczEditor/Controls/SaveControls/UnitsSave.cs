#region using List

using System;
using System.Collections.Generic;
using System.Windows.Forms;

using CczEditor.Data;

#endregion

namespace CczEditor.Controls.SaveControls
{
	public partial class UnitsSave : BaseSaveControl
	{
		private List<int> _itemIconList;

		public UnitsSave()
		{
			InitializeComponent();
			ncStr.Maximum = ncVit.Maximum = ncInt.Maximum = ncAvg.Maximum = ncLuk.Maximum = Program.CurrentConfig.SingularAttribute ? 255 : 510;
			ncStr.Increment = ncVit.Increment = ncInt.Increment = ncAvg.Increment = ncLuk.Increment = Program.CurrentConfig.SingularAttribute ? 1 : 2;
			ncMp.Maximum = Program.CurrentConfig.SaveMpExtension ? 65535 : 255;
			GetResourcesFace();
			GetResourcesPmapobj();
			GetResourcesItemIcon();
		}

		private void UnitsSave_Load(object sender, EventArgs e)
		{
			_itemIconList = GameData.ItemIconList();
			cbForce.Items.AddRange(Program.CurrentConfig.ForceNames.ToArray());
			cbWeapon.Items.Add("FF,장비 없음");
			cbWeapon.Items.AddRange(GameData.GetItemNames(ItemType.Weapons, true).ToArray());
            cbWeapon.Items.AddRange(StarData.GetItemNames(ItemType.Weapons, true).ToArray());
			cbArmor.Items.Add("FF,장비 없음");
			cbArmor.Items.AddRange(GameData.GetItemNames(ItemType.Armor, true).ToArray());
            cbArmor.Items.AddRange(StarData.GetItemNames(ItemType.Armor, true).ToArray());
			cbAncillary.Items.Add("FF,장비 없음");
			cbAncillary.Items.AddRange(GameData.GetItemNames(ItemType.Auxiliary, true).ToArray());
            cbAncillary.Items.AddRange(StarData.GetItemNames(ItemType.Auxiliary, true).ToArray());
			clbList.Items.AddRange(GameData.UnitNameList(true).ToArray());
			clbList.SelectedIndex = 0;
			clbList.Focus();
		}

		private void clbList_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (clbList.SelectedIndex < 0 || clbList.SelectedIndex >= clbList.Items.Count)
			{
				return;
			}
			var unit = SaveData.UnitGet(clbList.SelectedIndex);
			ncFace.Value = BitConverter.ToUInt16(unit, 0);
			ncPmapobj.Value = unit[2];
			cbCamp.Checked = unit[3] == 0x00 ? true : false;
			ncAtk.Value = BitConverter.ToUInt16(unit, 4);
			ncDef.Value = BitConverter.ToUInt16(unit, 6);
			ncMag.Value = BitConverter.ToUInt16(unit, 8);
			ncCrt.Value = BitConverter.ToUInt16(unit, 10);
			ncMor.Value = BitConverter.ToUInt16(unit, 12);
			if (Program.CurrentConfig.SingularAttribute)
			{
				ncStr.Value = unit[14];
				ncVit.Value = unit[15];
				ncInt.Value = unit[16];
				ncAvg.Value = unit[17];
				ncLuk.Value = unit[18];
			}
			else
			{
				ncStr.Value = unit[14]*2;
				ncVit.Value = unit[15]*2;
				ncInt.Value = unit[16]*2;
				ncAvg.Value = unit[17]*2;
				ncLuk.Value = unit[18]*2;
			}
			ncHp.Value = BitConverter.ToUInt16(unit, 19);
			if (Program.CurrentConfig.SaveMpExtension)
			{
				ncMp.Value = BitConverter.ToUInt16(unit, 21);
				cbForce.SelectedIndex = unit[23];
				ncLv.Value = unit[24];
				ncExp.Value = unit[25];
				cbWeapon.SelectedIndex = cbWeapon.FindString(Utils.GetString(unit[26]));
				ncWeaponLv.Value = unit[27];
				ncWeaponExp.Value = unit[28];
				cbArmor.SelectedIndex = cbArmor.FindString(Utils.GetString(unit[29]));
				ncArmorLv.Value = unit[30];
				ncArmorExp.Value = unit[31];
				cbAncillary.SelectedIndex = cbAncillary.FindString(Utils.GetString(unit[32]));
				//33 0xFF
			}
			else
			{
				ncMp.Value = unit[21];
				cbForce.SelectedIndex = unit[22];
				ncLv.Value = unit[23];
				ncExp.Value = unit[24];
				cbWeapon.SelectedIndex = cbWeapon.FindString(Utils.GetString(unit[25]));
				ncWeaponLv.Value = unit[26];
				ncWeaponExp.Value = unit[27];
				cbArmor.SelectedIndex = cbArmor.FindString(Utils.GetString(unit[28]));
				ncArmorLv.Value = unit[29];
				ncArmorExp.Value = unit[30];
				cbAncillary.SelectedIndex = cbAncillary.FindString(Utils.GetString(unit[31]));
				//32 0xFF
				//33 0x00
			}
			ncRune.Value = unit[34];
			//35 =34
			ncRetreat.Value = unit[36];
			if (TopLevelControl != null)
			{
				TopLevelControl.Text = string.Format("{1} - 세이브 편집 - 번호：{0}", clbList.SelectedIndex, Program.TitleNameCurrent);
			}
		}

		private void btnSave_Click(object sender, EventArgs e)
		{
			if (clbList.SelectedIndex < 0 || clbList.SelectedIndex >= clbList.Items.Count)
			{
				return;
			}
			UnitDataSave(clbList.SelectedIndex, false);
		}

		private void btnRestore_Click(object sender, EventArgs e)
		{
			clbList_SelectedIndexChanged(clbList, new EventArgs());
		}

		private void UnitDataSave(int index, bool batch)
		{
			var unit = SaveData.UnitGet(index);
			if (!batch || cbbFace.Checked)
			{
				Utils.ChangeByteValue(unit, BitConverter.GetBytes((ushort)ncFace.Value), 0);
			}
			if (!batch || cbbPmapobj.Checked)
			{
				unit[2] = (byte)ncPmapobj.Value;
			}
			if (!batch || cbbCamp.Checked)
			{
				unit[3] = (byte)(cbCamp.Checked ? 0x00 : 0xFF);
			}
			if (!batch || cbbAtk.Checked)
			{
				Utils.ChangeByteValue(unit, BitConverter.GetBytes((ushort)ncAtk.Value), 4);
			}
			if (!batch || cbbDef.Checked)
			{
				Utils.ChangeByteValue(unit, BitConverter.GetBytes((ushort)ncDef.Value), 6);
			}
			if (!batch || cbbMag.Checked)
			{
				Utils.ChangeByteValue(unit, BitConverter.GetBytes((ushort)ncMag.Value), 8);
			}
			if (!batch || cbbCrt.Checked)
			{
				Utils.ChangeByteValue(unit, BitConverter.GetBytes((ushort)ncCrt.Value), 10);
			}
			if (!batch || cbbMor.Checked)
			{
				Utils.ChangeByteValue(unit, BitConverter.GetBytes((ushort)ncMor.Value), 12);
			}
			if (Program.CurrentConfig.SingularAttribute)
			{
				if (!batch || cbbStr.Checked)
				{
					unit[14] = (byte)ncStr.Value;
				}
				if (!batch || cbbVit.Checked)
				{
					unit[15] = (byte)ncVit.Value;
				}
				if (!batch || cbbInt.Checked)
				{
					unit[16] = (byte)ncInt.Value;
				}
				if (!batch || cbbAvg.Checked)
				{
					unit[17] = (byte)ncAvg.Value;
				}
				if (!batch || cbbLuk.Checked)
				{
					unit[18] = (byte)ncLuk.Value;
				}
			}
			else
			{
				if (!batch || cbbStr.Checked)
				{
					unit[14] = (byte)(ncStr.Value/2);
				}
				if (!batch || cbbVit.Checked)
				{
					unit[15] = (byte)(ncVit.Value/2);
				}
				if (!batch || cbbInt.Checked)
				{
					unit[16] = (byte)(ncInt.Value/2);
				}
				if (!batch || cbbAvg.Checked)
				{
					unit[17] = (byte)(ncAvg.Value/2);
				}
				if (!batch || cbbLuk.Checked)
				{
					unit[18] = (byte)(ncLuk.Value/2);
				}
			}
			if (!batch || cbbHp.Checked)
			{
				Utils.ChangeByteValue(unit, BitConverter.GetBytes((ushort)ncHp.Value), 19);
			}
			if (Program.CurrentConfig.SaveMpExtension)
			{
				if (!batch || cbbMp.Checked)
				{
					Utils.ChangeByteValue(unit, BitConverter.GetBytes((ushort)ncMp.Value), 21);
				}
				if (!batch || cbbForce.Checked)
				{
					unit[23] = (byte)cbForce.SelectedIndex;
				}
				if (!batch || cbbLv.Checked)
				{
					unit[24] = (byte)ncLv.Value;
				}
				if (!batch || cbbExp.Checked)
				{
					unit[25] = (byte)ncExp.Value;
				}
				if (!batch || cbbWeapon.Checked)
				{
					unit[26] = (byte)Utils.GetId(cbWeapon.SelectedItem);
					unit[27] = (byte)ncWeaponLv.Value;
					unit[28] = (byte)ncWeaponExp.Value;
				}
				if (!batch || cbbArmor.Checked)
				{
					unit[29] = (byte)Utils.GetId(cbArmor.SelectedItem);
					unit[30] = (byte)ncArmorLv.Value;
					unit[31] = (byte)ncArmorExp.Value;
				}
				if (!batch || cbbAncillary.Checked)
				{
					unit[32] = (byte)Utils.GetId(cbAncillary.SelectedItem);
				}
				//33 0xFF
			}
			else
			{
				if (!batch || cbbMp.Checked)
				{
					unit[21] = (byte)ncMp.Value;
				}
				if (!batch || cbbForce.Checked)
				{
					unit[22] = (byte)cbForce.SelectedIndex;
				}
				if (!batch || cbbLv.Checked)
				{
					unit[23] = (byte)ncLv.Value;
				}
				if (!batch || cbbExp.Checked)
				{
					unit[24] = (byte)ncExp.Value;
				}
				if (!batch || cbbWeapon.Checked)
				{
					unit[25] = (byte)Utils.GetId(cbWeapon.SelectedItem);
					unit[26] = (byte)ncWeaponLv.Value;
					unit[27] = (byte)ncWeaponExp.Value;
				}
				if (!batch || cbbArmor.Checked)
				{
					unit[28] = (byte)Utils.GetId(cbArmor.SelectedItem);
					unit[29] = (byte)ncArmorLv.Value;
					unit[30] = (byte)ncArmorExp.Value;
				}
				if (!batch || cbbAncillary.Checked)
				{
					unit[31] = (byte)Utils.GetId(cbAncillary.SelectedItem);
				}
				//32 0xFF
				//33 0x00
			}
			if (!batch || cbbRune.Checked)
			{
				unit[34] = (byte)ncRune.Value;
			}
			//35 =34
			if (!batch || cbbRetreat.Checked)
			{
				unit[36] = (byte)ncRetreat.Value;
			}

			SaveData.UnitSet(index, unit);
		}

		#region 复选框列表操作

		private void btnListControlCheckNumber_Click(object sender, EventArgs e)
		{
			btnListControlCheckClear_Click(btnListControlCheckClear, new EventArgs());
			for (var i = (int)ncListControlCheckNumberMin.Value; i <= ncListControlCheckNumberMax.Value; i++)
			{
				clbList.SetItemChecked(i, true);
			}
		}

		private void btnListControlCheckAll_Click(object sender, EventArgs e)
		{
			for (var i = 0; i < clbList.Items.Count; i++)
			{
				clbList.SetItemChecked(i, true);
			}
		}

		private void btnListControlCheckReverse_Click(object sender, EventArgs e)
		{
			for (var i = 0; i < clbList.Items.Count; i++)
			{
				clbList.SetItemChecked(i, !clbList.GetItemChecked(i));
			}
		}

		private void btnListControlCheckClear_Click(object sender, EventArgs e)
		{
			for (var i = 0; i < clbList.Items.Count; i++)
			{
				clbList.SetItemChecked(i, false);
			}
		}

		#endregion

		#region 图像显示

		private void ncFace_ValueChanged(object sender, EventArgs e)
		{
			if (Faces == null || clbList.SelectedIndex < 0)
			{
				return;
			}
			pbFace.Image = Faces.GetImage((int)ncFace.Value);
		}
        /*
		private void ncPmapobj_ValueChanged(object sender, EventArgs e)
		{
			if (Pmapobjs == null || clbList.SelectedIndex < 0)
			{
				return;
			}
			pbPmapobj.Image = Pmapobjs.GetImage((int)ncPmapobj.Value);
		}
        */
		private void cbWeapon_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (ItemIcons == null || cbWeapon.SelectedIndex < 0)
			{
				return;
			}
			var index = Utils.GetId(cbWeapon.SelectedItem);
			pbWeapon.Image = index >= 0 && index < _itemIconList.Count ? ItemIcons.GetImage(_itemIconList[index]) : null;
		}

		private void cbArmor_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (ItemIcons == null || cbArmor.SelectedIndex < 0)
			{
				return;
			}
			var index = Utils.GetId(cbArmor.SelectedItem);
			pbArmor.Image = index >= 0 && index < _itemIconList.Count ? ItemIcons.GetImage(_itemIconList[index]) : null;
		}

		private void cbAncillary_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (ItemIcons == null || cbAncillary.SelectedIndex < 0)
			{
				return;
			}
			var index = Utils.GetId(cbAncillary.SelectedItem);
			pbAncillary.Image = index >= 0 && index < _itemIconList.Count ? ItemIcons.GetImage(_itemIconList[index]) : null;
		}

		#endregion

		#region 批量操作

		private void cbBatchCheck_CheckedChanged(object sender, EventArgs e)
		{
			switch (cbBatchCheck.CheckState)
			{
				case CheckState.Unchecked:
				{
					cbbFace.Checked =
						cbbPmapobj.Checked =
						cbbCamp.Checked =
						cbbForce.Checked =
						cbbAtk.Checked =
						cbbDef.Checked =
						cbbMag.Checked =
						cbbCrt.Checked =
						cbbMor.Checked =
						cbbLv.Checked =
						cbbExp.Checked =
						cbbHp.Checked =
						cbbMp.Checked =
						cbbStr.Checked =
						cbbVit.Checked =
						cbbInt.Checked =
						cbbAvg.Checked =
						cbbLuk.Checked =
						cbbWeapon.Checked =
						cbbArmor.Checked =
						cbbAncillary.Checked =
						cbbRune.Checked =
						cbbRetreat.Checked = false;
					break;
				}
				case CheckState.Checked:
				{
					cbbFace.Checked =
						cbbPmapobj.Checked =
						cbbCamp.Checked =
						cbbForce.Checked =
						cbbAtk.Checked =
						cbbDef.Checked =
						cbbMag.Checked =
						cbbCrt.Checked =
						cbbMor.Checked =
						cbbLv.Checked =
						cbbExp.Checked =
						cbbHp.Checked =
						cbbMp.Checked =
						cbbStr.Checked =
						cbbVit.Checked =
						cbbInt.Checked =
						cbbAvg.Checked =
						cbbLuk.Checked =
						cbbWeapon.Checked =
						cbbArmor.Checked =
						cbbAncillary.Checked =
						cbbRune.Checked =
						cbbRetreat.Checked = true;
					break;
				}
			}
		}

		private void cbbBatchItemCheck_CheckedChanged(object sender, EventArgs e)
		{
			var flag1 = cbbFace.Checked &&
			            cbbPmapobj.Checked &&
			            cbbCamp.Checked &&
			            cbbForce.Checked &&
			            cbbAtk.Checked &&
			            cbbDef.Checked &&
			            cbbMag.Checked &&
			            cbbCrt.Checked &&
			            cbbMor.Checked &&
			            cbbLv.Checked &&
			            cbbExp.Checked &&
			            cbbHp.Checked &&
			            cbbMp.Checked &&
			            cbbStr.Checked &&
			            cbbVit.Checked &&
			            cbbInt.Checked &&
			            cbbAvg.Checked &&
			            cbbLuk.Checked &&
			            cbbWeapon.Checked &&
			            cbbArmor.Checked &&
			            cbbAncillary.Checked &&
			            cbbRune.Checked &&
			            cbbRetreat.Checked;
			if (flag1)
			{
				cbBatchCheck.CheckState = CheckState.Checked;
				return;
			}
			var flag2 = cbbFace.Checked ||
			            cbbPmapobj.Checked ||
			            cbbCamp.Checked ||
			            cbbForce.Checked ||
			            cbbAtk.Checked ||
			            cbbDef.Checked ||
			            cbbMag.Checked ||
			            cbbCrt.Checked ||
			            cbbMor.Checked ||
			            cbbLv.Checked ||
			            cbbExp.Checked ||
			            cbbHp.Checked ||
			            cbbMp.Checked ||
			            cbbStr.Checked ||
			            cbbVit.Checked ||
			            cbbInt.Checked ||
			            cbbAvg.Checked ||
			            cbbLuk.Checked ||
			            cbbWeapon.Checked ||
			            cbbArmor.Checked ||
			            cbbAncillary.Checked ||
			            cbbRune.Checked ||
			            cbbRetreat.Checked;
			cbBatchCheck.CheckState = flag2 ? CheckState.Indeterminate : CheckState.Unchecked;
		}

		private void btnBatchSave_Click(object sender, EventArgs e)
		{
			if (cbBatchCheck.CheckState == CheckState.Unchecked)
			{
				Utils.HintUser("다 선택되지 않았습니다!");
				return;
			}
			if (clbList.CheckedIndices.Count == 0)
			{
                Utils.HintUser("다 선택되지 않았습니다!");
				return;
			}
			var indexs = new int[clbList.CheckedIndices.Count];
			clbList.CheckedIndices.CopyTo(indexs, 0);
			for (var i = 0; i < indexs.Length; i++)
			{
				UnitDataSave(indexs[i], true);
			}
		}

		#endregion
	}
}