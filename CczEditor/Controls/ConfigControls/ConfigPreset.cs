using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;

namespace CczEditor.Controls.ConfigControls
{
    public partial class ConfigPreset : BaseControl
    {
        private ConfigVersionType originConfigVersionType;
        private ConfigVersionType destConfigVersionType;

        BackgroundWorker bgw = new BackgroundWorker();

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
                cbUnitData.Checked =
                cbPmapObj.Checked =
                cbBattleObj.Checked =
                cbCost.Checked =
                cbCutin.Checked =
                cbVoice.Checked =
                cbItemData.Checked =
                cbShopData.Checked =
                cbSpecialCode.Checked =
                cbForceData.Checked =
                cbForceCategoryData.Checked =
                cbForceName.Checked =
                cbForceCategoryName.Checked =
                cbTerrainSyn.Checked =
                cbForceSyn.Checked =
                cbEquip.Checked =
                cbMagicData.Checked =
                cbMagicLv.Checked =
                cbMagicType.Checked =
                cbHealType.Checked =
                cbDmgType.Checked =
                cbAIType.Checked = 
                cbConditionType.Checked =
                cbDmgValue.Checked =
                cbAcc.Checked = 
                cbLearn.Checked = 
                cbReflect.Checked =
                cbAbility.Checked = 
                cbSpecialCode.Checked =
                cbSpecialEffect.Checked =
                cbSpecialSkill.Checked = 


                btnExecute .Enabled = false;

                return;
            }
            btnExecute.Enabled = true;

            var originConfig = originConfigHandler.Execute();
            var destConfig = destConfigHandler.Execute();
            

            // Unit
            cbUnitData.Checked = IsUnitDataActive(originConfig, destConfig);
            cbPmapObj.Checked = IsPmapObjActive(originConfig, destConfig);
            cbBattleObj.Checked = IsBattleObjActive(originConfig, destConfig);
            cbCost.Checked = IsCostActive(originConfig, destConfig);
            cbCutin.Checked = IsCutinActive(originConfig, destConfig);
            cbVoice.Checked = IsVoiceActive(originConfig, destConfig);

            // Item
            cbItemData.Checked = IsItemDataActive(originConfig, destConfig);
            cbShopData.Checked = IsShopDataActive(originConfig, destConfig);
            cbSpecialCode.Checked = IsItemEffectActive(originConfig, destConfig);
            
            // force
            cbForceData.Checked = IsForceDataActive(originConfig, destConfig);
            cbForceCategoryData.Checked = IsForceCategoryDataActive(originConfig, destConfig);
            cbForceName.Checked = IsForceNameDataActive(originConfig, destConfig);
            cbForceCategoryName.Checked = IsForceCategoryNameDataActive(originConfig, destConfig);
            cbTerrainSyn.Checked = IsForceTerrainActive(originConfig, destConfig);
            cbForceSyn.Checked = IsForceSangsungActive(originConfig, destConfig);
            cbEquip.Checked = IsForceEquipActive(originConfig, destConfig);
            cbSpecialAppearForce.Checked = IsForceDataActive(originConfig, destConfig);

            // magic
            cbMagicData.Checked = IsMagicDataActive(originConfig, destConfig);
            cbMagicLv.Checked = IsMagicLearnActive(originConfig, destConfig);
            cbMagicType.Checked = IsMagicTypeActive(originConfig, destConfig);
            cbHealType.Checked = IsHealTypeActive(originConfig, destConfig);
            cbDmgType.Checked = IsDmgTypeActive(originConfig, destConfig);
            cbAIType.Checked = IsAITypeActive(originConfig, destConfig);
            cbConditionType.Checked = IsConditionTypeActive(originConfig, destConfig);
            cbDmgValue.Checked = IsDmgValueActive(originConfig, destConfig);
            cbAcc.Checked = IsAccActive(originConfig, destConfig);
            cbLearn.Checked = IsLearnActive(originConfig, destConfig);
            cbReflect.Checked = IsReflectActive(originConfig, destConfig);

            // etc
            cbLevelExp.Checked = true;
            cbTitle.Checked = true;
            cbAbility.Checked = IsAbilityGradeActive(originConfig, destConfig);
            cbSpecialCode.Checked = IsItemEffectActive(originConfig, destConfig);
            cbSpecialEffect.Checked = IsSpecialEffectActive(originConfig, destConfig);
            cbSpecialSkill.Checked = IsSpecialSkillActive(originConfig, destConfig);
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

        #region Etc
        private bool IsAbilityGradeActive(Config origin, Config dest)
        {
            if (origin.Exe.AbilityGrades.Length == dest.Exe.AbilityGrades.Length)
                return true;
            return false;
        }

        private bool IsSpecialEffectActive(Config origin, Config dest)
        {
            if (origin.SpecialEffectNames.Count == dest.SpecialEffectNames.Count)
                return true;
            return false;
        }

        private bool IsSpecialSkillActive(Config origin, Config dest)
        {
            return true;
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
            originConfig.DirectoryPath = tbOriginPath.Text;
            destConfig.DirectoryPath = tbDestPath.Text;

            bgw.DoWork += new DoWorkEventHandler((object o, DoWorkEventArgs dwe) => Migration(originConfig, destConfig));
            bgw.ProgressChanged += new ProgressChangedEventHandler(bgw_ProgressChanged);
            bgw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bgw_RunWorkerCompleted);
            bgw.WorkerReportsProgress = true;
            bgw.RunWorkerAsync();

        }

        private void Migration(Config originConfig, Config destConfig)
        {
            var originPath = originConfig.DirectoryPath;
            var destPath = destConfig.DirectoryPath;

            var originGameData = Data.DataContainer.LoadGameData(originPath);
            var originStarData = Data.DataContainer.LoadStarData(originPath);
            var originImsgData = Data.DataContainer.LoadImsgData(originPath);
            var originExeData = Data.DataContainer.LoadExeData(originPath);

            Data.DataContainer.Initialize(originGameData, originStarData, originImsgData, originExeData, originConfig);

            var destGameData = Data.DataContainer.LoadGameData(destPath);
            var destStarData = Data.DataContainer.LoadStarData(destPath);
            var destImsgData = Data.DataContainer.LoadImsgData(destPath);
            var destExeData = Data.DataContainer.LoadExeData(destPath);

            Data.DataContainer.Initialize(destGameData, destStarData, destImsgData, destExeData, destConfig);

            bgw.ReportProgress(1);

            if (cbUnitData.Checked)
            {
                var data = new Data.Wrapper.UnitData();

                for(int i = 0; i < originConfig.Data.UnitCount; i++)
                {
                    data.Read(i, originGameData, originImsgData, originExeData, originConfig);
                    data.Write(i, destGameData, destImsgData, destExeData, destConfig);
                }
            }
            bgw.ReportProgress(10);

            if (cbItemData.Checked)
            {
                var data = new Data.Wrapper.ItemData();
                for (int i = 0; i < originConfig.Data.ItemCount; i++)
                {
                    data.Read(i, originGameData, originImsgData, originExeData, originConfig);
                    data.Write(i, destGameData, destStarData, destImsgData, destExeData, destConfig);
                }
            }
            bgw.ReportProgress(20);

            if (cbShopData.Checked)
            {
                var data = new Data.Wrapper.ShopData();
                for (int i = 0; i < originConfig.Data.ShopCount; i++)
                {
                    data.Read(i, originGameData, originImsgData, originExeData, originConfig);
                    data.Write(i, destGameData, destImsgData, destExeData, destConfig);
                }
            }
            bgw.ReportProgress(30);

            if (cbForceData.Checked)
            {
                var data = new Data.Wrapper.ForceData();
                for (int i = 0; i < originConfig.Data.ForceCount; i++)
                {
                    data.Read(i, originGameData, originImsgData, originExeData, originConfig);
                    data.Write(i, destGameData, destImsgData, destExeData, destConfig);
                }
            }
            bgw.ReportProgress(40);

            if (cbTerrainSyn.Checked)
            {
                var data = new Data.Wrapper.TerrainData();
                for (int i = 0; i < originConfig.ForceCategoryNames.Count; i++)
                {
                    data.Read(i, originGameData, originImsgData, originExeData, originConfig);
                    data.Write(i, destGameData, destImsgData, destExeData, destConfig);
                }
            }
            bgw.ReportProgress(50);

            if (cbMagicData.Checked)
            {
                var data = new Data.Wrapper.MagicData();
                for (int i = 0; i < originConfig.Data.MagicCount; i++)
                {
                    data.Read(i, originGameData, originImsgData, originExeData, originConfig);
                    data.Write(i, destGameData, destImsgData, destExeData, destConfig);
                }
            }
            bgw.ReportProgress(60);

            if (cbSpecialEffect.Checked)
            {
                var data = new Data.Wrapper.SpecialEffectData();
                for (int i = 0; i < originConfig.SpecialEffectNames.Count; i++)
                {
                    data.Read(i, originExeData, originConfig);
                    data.Write(i, destExeData, destConfig);
                }
            }
            bgw.ReportProgress(70);

            if (cbSpecialSkill.Checked)
            {
                var data = new Data.Wrapper.SpecialSkillData();
                for (int i = 0; i < originConfig.SpecialSkillNames.Count; i++)
                {
                    bool isPhysics = i <= Program.CurrentConfig.Exe.SpecialSkillPhysicsCount;
                    if (!isPhysics) continue;
                    data.Read(i, originExeData, originConfig);
                    data.Write(i, destExeData, destConfig);
                }
            }
            bgw.ReportProgress(80);

            if (cbSpecialCode.Checked)
            {
                var data = new Data.Wrapper.CodeEffectData();
                data.Read(originExeData, originConfig);
                data.Write(destExeData, destConfig);
            }

            if (cbSpecialCode.Checked)
            {
                var data = new Data.Wrapper.CodeEffectNameData();
                for (int i = 0; i < originConfig.ItemEffects.Count; i++)
                {
                    data.Read(i, originExeData, originConfig);
                    data.Write(i, destExeData, destConfig);
                }
            }
            bgw.ReportProgress(90);

            {
                var data = new Data.Wrapper.ProjectData();

                if (cbTitle.Checked)
                {
                    data.ReadTitle(originExeData, originConfig);
                    data.WriteTitle(destExeData, destConfig);
                }
                bgw.ReportProgress(94);

                if (cbAbility.Checked)
                {
                    data.ReadAbility(originExeData, originConfig);
                    data.WriteAbility(destExeData, destConfig);
                }
                bgw.ReportProgress(95);

                if (cbLevelExp.Checked)
                {
                    data.ReadLevels(originExeData, originConfig);
                    data.WriteLevel(destExeData, destConfig);
                }
                bgw.ReportProgress(97);

                if (cbSpecialAppearForce.Checked)
                {
                    data.ReadEtc(originExeData, originConfig);
                    data.WriteEtc(destExeData, destConfig);
                }
            }
            bgw.ReportProgress(100);
        }
        
        void bgw_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }

        void bgw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //do the code when bgv completes its work
            MessageBox.Show("마이그레이션이 완료되었습니다");
        }

        private void btnOriginPath_Click(object sender, EventArgs e)
        {
            tbOriginPath.Text = LoadFolder();
        }

        private void btnDestPath_Click(object sender, EventArgs e)
        {
            tbDestPath.Text = LoadFolder();
        }

        private string LoadFolder()
        {
            var fbd = new FolderBrowserDialog
            {
                SelectedPath = Program.CurrentConfig.DirectoryPath,
                Description = "경로를 설정해주세요!"
            };
            if (DialogResult.OK != fbd.ShowDialog() || string.IsNullOrEmpty(fbd.SelectedPath) || !System.IO.Directory.Exists(fbd.SelectedPath))
            {
                return string.Empty;
            }
            return fbd.SelectedPath;
        }
    }
}
