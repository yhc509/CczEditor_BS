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
        private ConfigVersionType originConfigVersionType;
        private ConfigVersionType destConfigVersionType;

        private enum ConfigVersionType
        {
            Star61 = 0,
            Star62 = 1,
            Bs10 = 2,
            Bs11 = 3
        }


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

        private void Bs11Button_Click(object sender, EventArgs e)
        {
            CreatePreset popup = new CreatePreset();
            popup._presetType = CreatePreset.PresetType.Bs11;
            popup.DefaultDisplayName = "비상조조전 1.1";
            popup.DefaultFileName = "BS 1.1";
            popup.ShowDialog();

        }

        private void originVersionBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (originVersionBox.SelectedIndex == -1) return;
            originConfigVersionType = (ConfigVersionType) originVersionBox.SelectedIndex;
            RefreshVersion();
        }

        private void destVersionBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (destVersionBox.SelectedIndex == -1) return;
            destConfigVersionType = (ConfigVersionType)destVersionBox.SelectedIndex;
            RefreshVersion();
        }
        
        private void RefreshVersion()
        {
            var originConfigHandler = GetVersionConfig(originConfigVersionType);
            var destConfigHandler = GetVersionConfig(destConfigVersionType);

            if (originConfigHandler == null || destConfigHandler == null)
            {
                cbUnitData.Enabled =
                cbPmapObj.Enabled =
                cbBattleObj.Enabled =
                cbCost.Enabled =
                cbCutin.Enabled =
                cbVoice.Enabled =
                cbItemData.Enabled =
                cbShopData.Enabled =
                cbSpecialEffect.Enabled =
                cbForceData.Enabled =
                cbForceCategoryData.Enabled =
                cbForceName.Enabled =
                cbForceCategoryName.Enabled =
                cbTerrainSyn.Enabled =
                cbForceSyn.Enabled =
                cbEquip.Enabled =
                cbMagicData.Enabled =
                cbMagicLv.Enabled =
                cbMagicType.Enabled =
                cbHealType.Enabled =
                cbDmgType.Enabled =
                cbAIType.Enabled = 
                cbConditionType.Enabled =
                cbDmgValue.Enabled =
                cbAcc.Enabled = 
                cbLearn.Enabled = 
                cbReflect.Enabled = false;

                return;
            }

            var originConfig = originConfigHandler.Execute();
            var destConfig = destConfigHandler.Execute();
            

            // Unit
            cbUnitData.Enabled = cbUnitData.Checked = IsUnitDataActive(originConfig, destConfig);
            cbPmapObj.Enabled = cbPmapObj.Checked = IsPmapObjActive(originConfig, destConfig);
            cbBattleObj.Enabled = cbBattleObj.Checked = IsBattleObjActive(originConfig, destConfig);
            cbCost.Enabled = cbCost.Checked = IsCostActive(originConfig, destConfig);
            cbCutin.Enabled = cbCutin.Checked = IsCutinActive(originConfig, destConfig);
            cbVoice.Enabled = cbVoice.Checked = IsVoiceActive(originConfig, destConfig);

            // Item
            cbItemData.Enabled = cbItemData.Checked = IsItemDataActive(originConfig, destConfig);
            cbShopData.Enabled = cbShopData.Checked = IsShopDataActive(originConfig, destConfig);
            cbSpecialEffect.Enabled = cbSpecialEffect.Checked = IsItemEffectActive(originConfig, destConfig);

            // force
            cbForceData.Enabled = cbForceData.Checked = IsForceDataActive(originConfig, destConfig);
            cbForceCategoryData.Enabled = cbForceCategoryData.Checked = IsForceCategoryDataActive(originConfig, destConfig);
            cbForceName.Enabled = cbForceName.Checked = IsForceNameDataActive(originConfig, destConfig);
            cbForceCategoryName.Enabled = cbForceCategoryName.Checked = IsForceCategoryNameDataActive(originConfig, destConfig);
            cbTerrainSyn.Enabled = cbTerrainSyn.Checked = IsForceTerrainActive(originConfig, destConfig);
            cbForceSyn.Enabled = cbForceSyn.Checked = IsForceSangsungActive(originConfig, destConfig);
            cbEquip.Enabled = cbEquip.Checked = IsForceEquipActive(originConfig, destConfig);

            // magic
            cbMagicData.Enabled = cbMagicData.Checked = IsMagicDataActive(originConfig, destConfig);
            cbMagicLv.Enabled = cbMagicLv.Checked = IsMagicLearnActive(originConfig, destConfig);
            cbMagicType.Enabled = cbMagicType.Checked = IsMagicTypeActive(originConfig, destConfig);
            cbHealType.Enabled = cbHealType.Checked = IsHealTypeActive(originConfig, destConfig);
            cbDmgType.Enabled = cbDmgType.Checked = IsDmgTypeActive(originConfig, destConfig);
            cbAIType.Enabled = cbAIType.Checked = IsAITypeActive(originConfig, destConfig);
            cbConditionType.Enabled = cbConditionType.Checked = IsConditionTypeActive(originConfig, destConfig);
            cbDmgValue.Enabled = cbDmgValue.Checked = IsDmgValueActive(originConfig, destConfig);
            cbAcc.Enabled = cbAcc.Checked = IsAccActive(originConfig, destConfig);
            cbLearn.Enabled = cbLearn.Checked = IsLearnActive(originConfig, destConfig);
            cbReflect.Enabled = cbReflect.Checked = IsReflectActive(originConfig, destConfig);
        }

        private ConfigCreateHandler GetVersionConfig(ConfigVersionType type)
        {
            switch (type)
            {
                case ConfigVersionType.Star61:
                    return new Star61ConfigCreateHandler();
                case ConfigVersionType.Star62:
                    return new Star62ConfigCreateHandler();
                case ConfigVersionType.Bs10:
                    return new Bs10ConfigCreateHandler();
                case ConfigVersionType.Bs11:
                    return new Bs11ConfigCreateHandler();
                default:
                    return null;
            }
        }

        #region UnitData
        private bool IsUnitDataActive(Config origin, Config dest)
        {
            if (origin.Data.UnitCount == dest.Data.UnitCount &&
                origin.Data.UnitLength == dest.Data.UnitLength)
                return true;
            return false;
        }

        private bool IsPmapObjActive(Config origin, Config dest)
        {
            if (origin.Data.UnitCount == dest.Data.UnitCount)
                return true;
            return false;
        }

        private bool IsBattleObjActive(Config origin, Config dest)
        {
            if (origin.Data.UnitCount == dest.Data.UnitCount &&
                origin.Exe.BattleObjTripleTypeCount == dest.Exe.BattleObjTripleTypeCount)
                return true;
            return false;
        }

        private bool IsCostActive(Config origin, Config dest)
        {
            if(origin.CodeOptionContainer.UseCost && dest.CodeOptionContainer.UseCost)
               return true;
            return false;
        }

        private bool IsCutinActive(Config origin, Config dest)
        {
            if (origin.CodeOptionContainer.UseCutin && dest.CodeOptionContainer.UseCutin)
                return true;
            return false;
        }

        private bool IsVoiceActive(Config origin, Config dest)
        {
            if (origin.CodeOptionContainer.UseVoice && dest.CodeOptionContainer.UseVoice)
                return true;
            return false;
        }
        #endregion

        #region ItemData
        private bool IsItemDataActive(Config origin, Config dest)
        {
            if (origin.Data.ItemCount == dest.Data.ItemCount &&
                origin.Data.ItemLength == dest.Data.ItemLength)
                return true;
            return false;
        }

        private bool IsShopDataActive(Config origin, Config dest)
        {
            if (origin.Data.ShopCount == dest.Data.ShopCount &&
                origin.Data.ShopLength == dest.Data.ShopLength)
                return true;
            return false;
        }

        private bool IsItemEffectActive(Config origin, Config dest)
        {
            if (origin.ItemEffects.Count <= dest.ItemEffects.Count)
                return true;
            return false;
        }
        #endregion

        #region ForceData
        private bool IsForceDataActive(Config origin, Config dest)
        {
            if (origin.Data.ForceCount == dest.Data.ForceCount &&
                origin.Data.ForceLength == dest.Data.ForceLength)
                return true;
            return false;
        }

        private bool IsForceCategoryDataActive(Config origin, Config dest)
        {
            if (origin.ForceCategoryNames.Count == dest.ForceCategoryNames.Count)
                return true;
            return false;
        }

        private bool IsForceNameDataActive(Config origin, Config dest)
        {
            if (origin.ForceNames.Count == dest.ForceNames.Count)
                return true;
            return false;
        }

        private bool IsForceCategoryNameDataActive(Config origin, Config dest)
        {
            if (origin.ForceCategoryNames.Count == dest.ForceCategoryNames.Count)
                return true;
            return false;
        }

        private bool IsForceEquipActive(Config origin, Config dest)
        {
            if (origin.Data.ForceLength == dest.Data.ForceLength)
                return true;
            return false;
        }

        private bool IsForceTerrainActive(Config origin, Config dest)
        {
            return true;
        }

        private bool IsForceSangsungActive(Config origin, Config dest)
        {
            if (origin.ForceCategoryNames.Count == dest.ForceCategoryNames.Count)
                return true;
            return false;
        }
        #endregion

        #region MagicData
        private bool IsMagicDataActive(Config origin, Config dest)
        {
            if (origin.Data.MagicCount == dest.Data.MagicCount && 
                origin.Data.MagicLength == dest.Data.MagicLength)
                return true;
            return false;
        }

        private bool IsMagicLearnActive(Config origin, Config dest)
        {
            if (origin.Data.MagicLength == dest.Data.MagicLength)
                return true;
            return false;
        }
        
        private bool IsMagicTypeActive(Config origin, Config dest)
        {
            if (origin.Exe.Magic.UseMagicTypeIndexes.Length == dest.Exe.Magic.UseMagicTypeIndexes.Length)
                return true;
            return false;
        }

        private bool IsHealTypeActive(Config origin, Config dest)
        {
            if (origin.Exe.Magic.UseHealTypeIndexes.Length == dest.Exe.Magic.UseHealTypeIndexes.Length)
                return true;
            return false;
        }

        private bool IsDmgTypeActive(Config origin, Config dest)
        {
            if (origin.Exe.Magic.UseDamageTypeIndexes.Length == dest.Exe.Magic.UseDamageTypeIndexes.Length)
                return true;
            return false;
        }

        private bool IsAITypeActive(Config origin, Config dest)
        {
            if (origin.Exe.Magic.UseAiTypeIndexes.Length == dest.Exe.Magic.UseAiTypeIndexes.Length)
                return true;
            return false;
        }

        private bool IsConditionTypeActive(Config origin, Config dest)
        {
            if (origin.CodeOptionContainer.UseMagicCondition == false || dest.CodeOptionContainer.UseMagicCondition == false) return false;

            if (origin.Exe.Magic.UseConditionIndexes.Length == dest.Exe.Magic.UseConditionIndexes.Length)
                return true;
            return false;
        }

        private bool IsDmgValueActive(Config origin, Config dest)
        {
            if (origin.Exe.Magic.UseDamageValueIndexes.Length == dest.Exe.Magic.UseDamageValueIndexes.Length)
                return true;
            return false;
        }

        private bool IsAccActive(Config origin, Config dest)
        {
            if (origin.Exe.Magic.UseAccRateIndexes.Length == dest.Exe.Magic.UseAccRateIndexes.Length)
                return true;
            return false;
        }

        private bool IsLearnActive(Config origin, Config dest)
        {
            if (origin.CodeOptionContainer.MagicLearnExtension != dest.CodeOptionContainer.MagicLearnExtension) return false;

            if (origin.Exe.Magic.UseLearnTypeIndexes.Length == dest.Exe.Magic.UseLearnTypeIndexes.Length)
                return true;
            return false;
        }

        private bool IsReflectActive(Config origin, Config dest)
        {
            if (origin.CodeOptionContainer.MagicReflect == false || dest.CodeOptionContainer.MagicReflect == false) return false;

            if (origin.Exe.Magic.UseReflectIndexes.Length == dest.Exe.Magic.UseReflectIndexes.Length)
                return true;
            return false;
        }
        #endregion

        private void btnExecute_Click(object sender, EventArgs e)
        {
            var originConfigHandler = GetVersionConfig(originConfigVersionType);
            var destConfigHandler = GetVersionConfig(destConfigVersionType);

            if (originConfigHandler == null || destConfigHandler == null)
            {
                return;
            }

            var originConfig = originConfigHandler.Execute();
            var destConfig = destConfigHandler.Execute();

            Migration(tbOriginPath.Text, originConfig, tbDestPath.Text, destConfig);
        }

        private void Migration(string originPath, Config origin, string destPath, Config dest)
        {
            

        }
    }
}
