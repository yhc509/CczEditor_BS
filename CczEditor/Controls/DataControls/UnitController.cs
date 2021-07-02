#region using List

using System;
using System.Collections.Generic;
using System.Windows.Forms;

using CczEditor.Data;

#endregion
using System.Drawing;
using System.Media;
using System.Linq;
using System.Text;
using System.IO;

namespace CczEditor.Controls.DataControls
{
    public partial class UnitController : BaseDataControl
	{
        public Data.Wrapper.UnitData CurrentData;

        public UnitController()
		{
			InitializeComponent();
			tlpImsg.Enabled = ImsgDataLoaded;
			ncStr.Maximum = ncVit.Maximum = ncInt.Maximum = ncAvg.Maximum = ncLuk.Maximum = Program.CurrentConfig.CodeOptionContainer.SingularAttribute ? 255 : 510;
			ncStr.Increment = ncVit.Increment = ncInt.Increment = ncAvg.Increment = ncLuk.Increment = Program.CurrentConfig.CodeOptionContainer.SingularAttribute ? 1 : 2;

            cbbCutin.Visible = CutinComboBox.Visible = lblCutin.Visible = Program.CurrentConfig.CodeOptionContainer.UseCutin;
            cbbCost.Visible = CostValueBox.Visible = lblCost.Visible = Program.CurrentConfig.CodeOptionContainer.UseCost;
            cbbVoice.Visible = VoiceComboBox.Visible = VoicePlayButton.Visible = lblVoice.Visible = Program.CurrentConfig.CodeOptionContainer.UseVoice;

            PmapObjValueBox.Maximum = 65535;
            BattleObjValueBox.Maximum = 65535;

            for(int i = 0; i <= 99; i++)
            {
                if(i == 10)
                    CutinComboBox.Items.Add($"사용불가자리");
                else
                    CutinComboBox.Items.Add($"Mcall{i:D2}.e5");
            }

            for (int i = 0; i <= 99; i++)
            {
                VoiceComboBox.Items.Add($"SE{i:D2}.wav");
            }
            for (int i = 0; i <= 99; i++)
            {
                VoiceComboBox.Items.Add($"SE_M_{i:D2}.wav");
            }
            for (int i = 0; i <= 55; i++)
            {
                VoiceComboBox.Items.Add($"SE_E_{i:D2}.wav");
            }


            GetResourcesFace();
            GetResourcesFaceLarge();
            GetResourcesPmapobj();
            GetResourcesImageAtk();
            GetResourcesImageMov();
            GetResourcesImageSpc();
			GetResourcesItemIcon();
		}

		private void UnitsData_Load(object sender, EventArgs e)
		{
            cbForce.Items.Clear();
            cbForce.Items.AddRange(ConfigUtils.GetForceNames(Program.ExeData, Program.CurrentConfig, Program.FORMATSTRING_KEYVALUEPAIR_HEX2).Values.ToArray());
            clbList.Items.AddRange(Program.GameData.UnitNameList(true).ToArray());
		}

        public override void Reset()
        {
            base.Reset();

            CurrentData = new CczEditor.Data.Wrapper.UnitData();

            clbList.SelectedIndex = 0;
            PmapObjActionComboBox.SelectedIndex = 0;
            BattleObjComboBox.SelectedIndex = 0;
            clbList.Focus();
        }


        private void LoadUnit(int index)
        {
            if (index < 0 || index >= Program.CurrentConfig.Data.UnitCount)
                return;

            CurrentData.Read(index, Program.GameData, Program.ImsgData, Program.ExeData, Program.CurrentConfig);

            txtName.Text = CurrentData.Name;
            ncFace.Value = CurrentData.Face;
            ncCritical.Value = CurrentData.CriticalIndex;

            if (Program.CurrentConfig.CodeOptionContainer.SingularAttribute)
            {
                ncStr.Value = CurrentData.Str;
                ncVit.Value = CurrentData.Vit;
                ncInt.Value = CurrentData.Int;
                ncAvg.Value = CurrentData.Avg;
                ncLuk.Value = CurrentData.Luk;
            }
            else
            {
                ncStr.Value = CurrentData.Str * 2;
                ncVit.Value = CurrentData.Vit * 2;
                ncInt.Value = CurrentData.Int * 2;
                ncAvg.Value = CurrentData.Avg * 2;
                ncLuk.Value = CurrentData.Luk * 2;
            }
            ncHp.Value = CurrentData.Hp;
            ncMp.Value = CurrentData.Mp;
            cbForce.SelectedIndex = CurrentData.Force;

            PmapObjValueBox.Enabled = !Program.ExeData.IsLocked;
            CharacterComboBox.Enabled = !Program.ExeData.IsLocked;
            BattleObjValueBox.Enabled = !Program.ExeData.IsLocked;
            CutinComboBox.Enabled = !Program.ExeData.IsLocked;
            VoiceComboBox.Enabled = !Program.ExeData.IsLocked;
            CostValueBox.Enabled = !Program.ExeData.IsLocked;

            if (!Program.ExeData.IsLocked)
            {
                PmapObjValueBox.Value = CurrentData.Pmapobj;
                CharacterComboBox.SelectedIndex = CurrentData.CharacterType;
                BattleObjValueBox.Value = CurrentData.BattleObj;

                lblCutin.Visible = CutinComboBox.Visible = cbbCutin.Visible = index <= 255 && Program.CurrentConfig.CodeOptionContainer.UseCutin;
                lblVoice.Visible = VoiceComboBox.Visible = cbbVoice.Visible = VoicePlayButton.Visible = index <= 255 && Program.CurrentConfig.CodeOptionContainer.UseVoice;
                lblCost.Visible = CostValueBox.Visible = cbbCost.Visible = index <= 255 && Program.CurrentConfig.CodeOptionContainer.UseCost;
                if (index <= 255)
                {
                    CutinComboBox.SelectedIndex = CurrentData.Cutin;
                    VoiceComboBox.SelectedIndex = CurrentData.Voice;
                    CostValueBox.Value = CurrentData.Cost;
                }
            }
            
            if (index < Program.IMSG_UNITORIGINAL_COUNT)
            {
            }
            else
            {
                rbtnImsgType1.Checked = true;
            }
            if (index < Program.IMSG_RETREAT_COUNT)
            {
                rbtnImsgType2.Enabled = true;
            }
            else
            {
                rbtnImsgType2.Enabled = false;
                if (rbtnImsgType2.Checked)
                {
                    rbtnImsgType2.Checked = false;
                    rbtnImsgType1.Checked = true;
                }
            }

            if (rbtnImsgType1.Checked)
                txtImsg.Text = CurrentData.Imsg;
            else if (rbtnImsgType2.Checked)
                txtImsg.Text = CurrentData.Retreat;

            SettingFaceType();

            if (TopLevelControl != null)
                TopLevelControl.Text = string.Format("{1} - 인물 편집 - 번호：{0}", clbList.SelectedIndex, Program.TitleNameCurrent);
        }

        private void SaveUnit(int index, bool isBatch = false)
        {
            CurrentData.Name = txtName.Text;
            CurrentData.Face = (ushort)ncFace.Value;
            CurrentData.CriticalIndex = (byte)ncCritical.Value;
            CurrentData.Str = (byte)ncStr.Value;
            
            if (Program.CurrentConfig.CodeOptionContainer.SingularAttribute)
            {
                CurrentData.Str = (byte)ncStr.Value;
                CurrentData.Vit = (byte)ncVit.Value;
                CurrentData.Int = (byte)ncInt.Value;
                CurrentData.Avg = (byte)ncAvg.Value;
                CurrentData.Luk = (byte)ncLuk.Value;
            } else
            {
                CurrentData.Str = (byte) (ncStr.Value / 2);
                CurrentData.Vit = (byte) (ncVit.Value / 2);
                CurrentData.Int = (byte) (ncInt.Value / 2);
                CurrentData.Avg = (byte) (ncAvg.Value / 2);
                CurrentData.Luk = (byte) (ncLuk.Value / 2);
            }

            CurrentData.Hp = (ushort)ncHp.Value;
            CurrentData.Mp = (byte)ncMp.Value;
            CurrentData.Force = (byte)cbForce.SelectedIndex;

            CurrentData.Pmapobj = (ushort) PmapObjValueBox.Value;
            CurrentData.BattleObj = (ushort) BattleObjValueBox.Value;
            CurrentData.CharacterType = (byte) CharacterComboBox.SelectedIndex;
            CurrentData.Cutin = (byte) CutinComboBox.SelectedIndex;
            CurrentData.Voice = (byte)VoiceComboBox.SelectedIndex;
            CurrentData.Cost = (byte) CostValueBox.Value;

            if (rbtnImsgType1.Checked)
                CurrentData.Imsg = txtImsg.Text;
            else if (rbtnImsgType2.Checked)
                CurrentData.Retreat = txtImsg.Text;

            CurrentData.Write(index, Program.GameData, Program.ImsgData, Program.ExeData, Program.CurrentConfig);

            clbList.Items.RemoveAt(index);
            clbList.Items.Insert(index, string.Format(Program.FORMATSTRING_KEYVALUEPAIR_HEX3, index, CurrentData.Name));
            clbList.SelectedIndex = index;
        }

        private void CopyUnit(int index, int[] targetIndexes, bool isTailNumber)
        {
            var origin = new CczEditor.Data.Wrapper.UnitData();
            origin.Read(index, Program.GameData, Program.ImsgData, Program.ExeData, Program.CurrentConfig);

            int nameNumber = 1;

            foreach(var targetIndex in targetIndexes)
            {

                var unit = new CczEditor.Data.Wrapper.UnitData();
                unit.Read(targetIndex, Program.GameData, Program.ImsgData, Program.ExeData, Program.CurrentConfig);

                if (cbbName.Checked)
                {
                    if(isTailNumber)
                        unit.Name = $"{txtName.Text}{nameNumber++}";
                    else
                        unit.Name = origin.Name;
                }
                if (cbbFace.Checked) unit.Face = origin.Face;
                if (cbbCritical.Checked) unit.CriticalIndex = origin.CriticalIndex;
                if (cbbStr.Checked) unit.Str = origin.Str;
                if (cbbVit.Checked) unit.Vit = origin.Vit;
                if (cbbInt.Checked) unit.Int = origin.Int;
                if (cbbAvg.Checked) unit.Avg = origin.Avg;
                if (cbbLuk.Checked) unit.Luk = origin.Luk;
                if (cbbHp.Checked) unit.Hp = origin.Hp;
                if (cbbMp.Checked) unit.Mp = origin.Mp;
                if (cbbForce.Checked) unit.Force = origin.Force;
                if (cbbPmapObj.Checked) unit.Pmapobj = origin.Pmapobj;
                if (cbbBattleObj.Checked) unit.BattleObj = origin.BattleObj;
                if (cbbCharacter.Checked) unit.CharacterType = origin.CharacterType;
                if (cbbCutin.Checked) unit.Cutin = origin.Cutin;
                if (cbbCost.Checked) unit.Cost = origin.Cost;
                if (cbbVoice.Checked) unit.Voice = origin.Voice;
                if (cbbImsg.Checked && rbtnImsgType1.Checked) unit.Imsg = origin.Imsg;

                
                unit.Write(targetIndex, Program.GameData, Program.ImsgData, Program.ExeData, Program.CurrentConfig);

                clbList.Items.RemoveAt(targetIndex);
                clbList.Items.Insert(targetIndex, string.Format(Program.FORMATSTRING_KEYVALUEPAIR_HEX3, targetIndex, unit.Name));
            }
            
            clbList.SelectedIndex = index;
        }

        private void clbList_SelectedIndexChanged(object sender, EventArgs e)
		{
            LoadUnit(clbList.SelectedIndex);
		}
        
		private void btnSave_Click(object sender, EventArgs e)
        {
            SaveUnit(clbList.SelectedIndex);
		}

		private void btnRestore_Click(object sender, EventArgs e)
        {
            LoadUnit(clbList.SelectedIndex);
		}
                

		#region Imsg
        
		private void txtImsg_TextChanged(object sender, EventArgs e)
        {
            int length = Encoding.Default.GetByteCount(txtImsg.Text);
            lblImsgCount.Text = $"{length} / 200 byte";
		}

		private void rbtnImsgType_CheckedChanged(object sender, EventArgs e)
		{
			if (((RadioButton)sender).Checked)
			{
                if (clbList.SelectedIndex < 0 || clbList.SelectedIndex >= clbList.Items.Count)
                {
                    return;
                }
                var index = clbList.SelectedIndex;
                if (index < Program.IMSG_UNITORIGINAL_COUNT)
                {
                }
                else
                {
                    rbtnImsgType1.Checked = true;
                }
                if (index < Program.IMSG_RETREAT_COUNT)
                {
                    rbtnImsgType2.Enabled = true;
                }
                else
                {
                    rbtnImsgType2.Enabled = false;
                    if (rbtnImsgType2.Checked)
                    {
                        rbtnImsgType2.Checked = false;
                        rbtnImsgType1.Checked = true;
                    }
                } if (rbtnImsgType1.Checked)
                {
                    var msg = Program.ImsgData.UnitExtensionGet(clbList.SelectedIndex);
                    txtImsg.Text = Utils.ByteToString(msg, 0, Program.IMSG_DATA_BLOCK_LENGTH);
                }
                else if (rbtnImsgType2.Checked)
                {
                    var msg = Program.ImsgData.RetreatGet(clbList.SelectedIndex);
                    txtImsg.Text = Utils.ByteToString(msg, 0, Program.IMSG_DATA_BLOCK_LENGTH);
                }
			}
		}

        #endregion


        #region Add-On
        
        #endregion

        #region BattleObj Image
        private void battleObjComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            DrawBattleObj();
        }
        
        private void spcv_ValueChanged_1(object sender, EventArgs e)
        {
            DrawBattleObj();
        }

        private void battleObjTeam1_CheckedChanged(object sender, EventArgs e)
        {
            DrawBattleObj();
        }

        private void battleObjTeam2_CheckedChanged(object sender, EventArgs e)
        {
            DrawBattleObj();
        }

        private void battleObjTeam3_CheckedChanged(object sender, EventArgs e)
        {
            DrawBattleObj();
        }

        private void cbForce_SelectedIndexChanged(object sender, EventArgs e)
        {
            DrawBattleObj();
        }

        private void DrawBattleObj()
        {
            if (UnitSpc == null || clbList.SelectedIndex < 0)
            {
                return;
            }

            int spc = 0;
            var battleObjIndex = BattleObjValueBox.Value;

            Resources.ImageResources loader = null;
            switch (BattleObjComboBox.SelectedIndex)
            {
                case 0:
                    loader = UnitAtk;
                    break;
                case 1:
                    loader = UnitMov;
                    break;
                default:
                    loader = UnitSpc;
                    break;
            }

            var forceIndex = GetBattleObjImageIndex();
            if (battleObjIndex == 0)
            {
                BattleObjTeam1Radio.Enabled = BattleObjTeam2Radio.Enabled = BattleObjTeam3Radio.Enabled = true;
                var teamIndex = BattleObjTeam1Radio.Checked ? 0 : (BattleObjTeam2Radio.Checked ? 1 : (BattleObjTeam3Radio.Checked ? 2 : 0));
                if (cbForce.SelectedIndex <= 0x3b)
                {
                    BattleObjText2.Visible = BattleObjText3.Visible = spcimg2.Visible = spcimg3.Visible = true;
                    spc = forceIndex * 9 + (teamIndex);
                    BattleObjText1.Text = (spc + 1).ToString();
                    spcimg1.Image = loader.GetImage(spc);
                    BattleObjText2.Text = (spc + 4).ToString();
                    spcimg2.Image = loader.GetImage(spc + 3);
                    BattleObjText3.Text = (spc + 7).ToString();
                    spcimg3.Image = loader.GetImage(spc + 6);
                }
                else
                {
                    BattleObjText2.Visible = BattleObjText3.Visible = spcimg2.Visible = spcimg3.Visible = false;
                    spc = 180 + (forceIndex - 20) * 3 + teamIndex;
                    BattleObjText1.Text = (spc + 1).ToString();
                    spcimg1.Image = loader.GetImage(spc);
                }
            }
            else if (battleObjIndex >= 1 && battleObjIndex <= Program.CurrentConfig.Exe.BattleObjTripleTypeCount)
            {
                BattleObjText2.Visible = BattleObjText3.Visible = spcimg2.Visible = spcimg3.Visible = true;
                BattleObjTeam1Radio.Enabled = BattleObjTeam2Radio.Enabled = BattleObjTeam3Radio.Enabled = false;
                spc = 240 + ((int)battleObjIndex - 1) * 3;
                BattleObjText1.Text = (spc + 1).ToString();
                spcimg1.Image = loader.GetImage(spc);
                BattleObjText2.Text = (spc + 2).ToString();
                spcimg2.Image = loader.GetImage(spc + 1);
                BattleObjText3.Text = (spc + 3).ToString();
                spcimg3.Image = loader.GetImage(spc + 2);
            }
            else
            {
                BattleObjText2.Visible = BattleObjText3.Visible = spcimg2.Visible = spcimg3.Visible = false;
                BattleObjTeam1Radio.Enabled = BattleObjTeam2Radio.Enabled = BattleObjTeam3Radio.Enabled = false;
                spc = 240 + (Program.CurrentConfig.Exe.BattleObjTripleTypeCount * 3) + ((int)battleObjIndex - (Program.CurrentConfig.Exe.BattleObjTripleTypeCount + 1));
                BattleObjText1.Text = (spc + 1).ToString();
                spcimg1.Image = loader.GetImage(spc);
            }
        }

        private int GetBattleObjImageIndex()
        {
            var force = cbForce.SelectedIndex;
            int value;

            if (force < 60) value = force / 3;
            else value = force - 60 + 20;
            return value;
        }
        #endregion

        #region PmapObj Image
        private void pmap_ValueChanged(object sender, EventArgs e)
        {
            DrawPmapObj();
        }

        private void pmapobjActionComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            DrawPmapObj();
        }

        private void DrawPmapObj()
        {
            if (Pmapobjs == null || clbList.SelectedIndex < 0)
            {
                return;
            }

            int pmapobjIndex = (int)PmapObjValueBox.Value;
            var actionIndex = PmapObjActionComboBox.SelectedIndex;
            pmapimg1.Image = Pmapobjs.GetImageCrop(pmapobjIndex * 2, actionIndex);
            pmapimg2.Image = Pmapobjs.GetImageCrop(pmapobjIndex * 2 + 1, actionIndex);

            PmapobjFrontText.Text = (PmapObjValueBox.Value * 2 + 1).ToString();
            PmapObjBackText.Text = (PmapObjValueBox.Value * 2 + 2).ToString();
        }
        #endregion

        #region Face Image
        private void ncFace_ValueChanged(object sender, EventArgs e)
		{
            DrawFace();
		}

        private void faceType_SelectedIndexChanged(object sender, EventArgs e)
        {
            DrawFace();
        }

        private void SettingFaceType()
        {
            faceType.Items.Clear();

            faceType.Visible = true;
            if (clbList.SelectedIndex == 0)
            {
                faceType.Items.Add("00.초년-보통");
                faceType.Items.Add("01.초년-놀람");
                faceType.Items.Add("02.초년-화남");
                faceType.Items.Add("03.초년-기쁨");
                faceType.Items.Add("04.노년-보통");
                faceType.Items.Add("05.노년-놀람");
                faceType.Items.Add("06.노년-화남");
                faceType.Items.Add("07.노년-기쁨");
                faceType.SelectedIndex = 0;
            }
            else if (clbList.SelectedIndex == 1)
            {
                faceType.Items.Add("00.일반");
                faceType.Items.Add("DF.양눈");
                faceType.Items.Add("E0.굴욕");
                faceType.SelectedIndex = 0;
            }
            else if(clbList.SelectedIndex == 4)
            {
                faceType.Items.Add("00.일반");
                faceType.Items.Add("E3.중년");
                faceType.SelectedIndex = 0;
            }
            else if(clbList.SelectedIndex == 8)
            {
                faceType.Items.Add("00.일반");
                faceType.Items.Add("E2.노년");
                faceType.SelectedIndex = 0;
            }
            else if(clbList.SelectedIndex == 35)
            {
                faceType.Items.Add("00.일반");
                faceType.Items.Add("D6.마왕");
                faceType.SelectedIndex = 0;
            }
            else
            {
                faceType.Visible = false;
                faceType.SelectedIndex = -1;
            }
        }

        private void DrawFace()
        {
            if (Faces == null || clbList.SelectedIndex < 0)
            {
                return;
            }

            int faceIndex = (int)ncFace.Value;
            if (faceType.SelectedIndex > 0)
            {
                switch(clbList.SelectedIndex)
                {
                    case 0:
                        faceIndex = faceType.SelectedIndex;
                        break;
                    case 1:
                        faceIndex = faceType.SelectedIndex == 1 ? 223 : 224;
                        break;
                    case 4:
                        faceIndex = 227;
                        break;
                    case 8:
                        faceIndex = 226;
                        break;
                    case 35:
                        faceIndex = 214;
                        break;
                }
            }
            else
            {
                if (faceIndex > 0)
                    faceIndex += 7;
            }

            FaceText.Text = faceIndex.ToString();

            pbFace.Image = Faces.GetImage(faceIndex);

            if (Program.CurrentConfig.CodeOptionContainer.UseLargeFace)
            {
                if (FaceLarges == null || clbList.SelectedIndex < 0)
                {
                    return;
                }

                pbFaceL.Image = FaceLarges.GetImage(faceIndex);
            }

        }
        #endregion

        #region Search
        private void searchButton_Click(object sender, EventArgs e)
        {
            var list = Program.GameData.UnitNameList(false);
            var index = list.FindIndex(x => x == searchTextBox.Text);
            if (index == -1)
            {
                MessageBox.Show("찾기에 실패했습니다.", "경고", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            clbList.SelectedIndex = index;
        }
        #endregion

        #region Copy
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

        private void cbBatchCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (cbBatchCheck.CheckState == CheckState.Indeterminate) return;

            cbbName.Checked
                = cbbFace.Checked
                = cbbCutin.Checked
                = cbbCritical.Checked
                = cbbStr.Checked
                = cbbVit.Checked
                = cbbInt.Checked
                = cbbAvg.Checked
                = cbbLuk.Checked
                = cbbHp.Checked
                = cbbMp.Checked
                = cbbForce.Checked
                = cbbPmapObj.Checked
                = cbbBattleObj.Checked
                = cbbCharacter.Checked
                = cbbImsg.Checked
                = cbbCost.Checked
                = cbbCutin.Checked
                = cbbVoice.Checked
                = cbBatchCheck.CheckState == CheckState.Checked;
        }

        private void cbbBatchItemCheck_CheckedChanged(object sender, EventArgs e)
        {
            var isAllChecked =
                cbbName.Checked &&
                cbbFace.Checked &&
                cbbCutin.Checked &&
                cbbCritical.Checked &&
                cbbStr.Checked &&
                cbbVit.Checked &&
                cbbInt.Checked &&
                cbbAvg.Checked &&
                cbbLuk.Checked &&
                cbbHp.Checked &&
                cbbMp.Checked &&
                cbbForce.Checked &&
                cbbPmapObj.Checked &&
                cbbBattleObj.Checked &&
                cbbCharacter.Checked &&
                cbbImsg.Checked &&
                cbbCost.Checked &&
                cbbCutin.Checked &&
                cbbVoice.Checked;

            if (isAllChecked)
            {
                cbBatchCheck.CheckState = CheckState.Checked;
                return;
            }

            var isChecked =
                cbbName.Checked ||
                cbbFace.Checked ||
                cbbCutin.Checked ||
                cbbCritical.Checked ||
                cbbStr.Checked ||
                cbbVit.Checked ||
                cbbInt.Checked ||
                cbbAvg.Checked ||
                cbbLuk.Checked ||
                cbbHp.Checked ||
                cbbMp.Checked ||
                cbbForce.Checked ||
                cbbPmapObj.Checked ||
                cbbBattleObj.Checked ||
                cbbCharacter.Checked ||
                cbbImsg.Checked ||
                cbbCost.Checked ||
                cbbCutin.Checked ||
                cbbVoice.Checked;

            cbBatchCheck.CheckState = isChecked ? CheckState.Indeterminate : CheckState.Unchecked;
        }

        private void btnBatchSave_Click(object sender, EventArgs e)
        {
            if (cbBatchCheck.CheckState == CheckState.Unchecked)
            {
                Utils.HintUser("항목 선택이 되지 않았습니다!");
                return;
            }
            if (clbList.CheckedIndices.Count == 0)
            {
                Utils.HintUser("인물 선택이 되지 않았습니다!");
                return;
            }
            
            var targetIndexes = new int[clbList.CheckedIndices.Count];
            clbList.CheckedIndices.CopyTo(targetIndexes, 0);

            CopyUnit(clbList.SelectedIndex, targetIndexes, cbBatchNumberNaming.Checked);
        }
        
        private void exchangeButton_Click(object sender, EventArgs e)
        {
            MoveUnitsPopup popup = new MoveUnitsPopup();
            popup.FormClosed += (s, ev) =>
            {
                clbList.Items.Clear();
                clbList.Items.AddRange(Program.GameData.UnitNameList(true).ToArray());
                clbList.SelectedIndex = 0;
            };
            popup.ShowDialog();
        }
        #endregion

        private void VoicePlayButton_Click(object sender, EventArgs e)
        {
            var fileName = VoiceComboBox.SelectedItem.ToString();
            var path = System.IO.Path.Combine(Program.CurrentConfig.DirectoryPath, "Wav", fileName);

            if(System.IO.File.Exists(path))
            {
                SoundPlayer player = new SoundPlayer(path);
                player.Play();
            }
            else
            {
                MessageBox.Show($"파일 {fileName}이 존재하지 않습니다.", "경고", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        #region ImageChange

        private void pbFace_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog1 = new OpenFileDialog();
                openFileDialog1.Filter = "Image File(*.bmp;*.jpg)|*.bmp;*.jpg";
                OpenFileDialog openFileDialog2 = openFileDialog1;
                if (DialogResult.OK != openFileDialog2.ShowDialog() || string.IsNullOrEmpty(openFileDialog2.FileName) || !File.Exists(openFileDialog2.FileName))
                    return;

                int faceIndex = int.Parse(this.FaceText.Text);

                bool flag = this.Faces.SetImage(faceIndex, 120, 120, openFileDialog2.FileName);
                this.ncFace_ValueChanged((object)null, (EventArgs)null);
                if (flag)
                {
                    int num1 = (int)MessageBox.Show("수정 성공!");
                }
                else
                {
                    int num2 = (int)MessageBox.Show("오류가 발생했습니다!");
                }
            }
            catch
            {
            }
        }

        private void pbFaceL_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog1 = new OpenFileDialog();
                openFileDialog1.Filter = "Image File(*.bmp;*.jpg)|*.bmp;*.jpg";
                OpenFileDialog openFileDialog2 = openFileDialog1;
                if (DialogResult.OK != openFileDialog2.ShowDialog() || string.IsNullOrEmpty(openFileDialog2.FileName) || !File.Exists(openFileDialog2.FileName))
                    return;

                int faceIndex = int.Parse(this.FaceText.Text);
                bool flag = this.FaceLarges.SetImage(faceIndex, 196, 280, openFileDialog2.FileName);
                this.ncFace_ValueChanged((object)null, (EventArgs)null);
                if (flag)
                {
                    int num1 = (int)MessageBox.Show("수정 성공!");
                }
                else
                {
                    int num2 = (int)MessageBox.Show("오류가 발생했습니다!");
                }
            }
            catch
            {
            }
        }


        private void pmapImg1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog1 = new OpenFileDialog();
                openFileDialog1.Filter = "Image File(*.bmp;*.jpg)|*.bmp;*.jpg";
                OpenFileDialog openFileDialog2 = openFileDialog1;
                if (DialogResult.OK != openFileDialog2.ShowDialog() || string.IsNullOrEmpty(openFileDialog2.FileName) || !File.Exists(openFileDialog2.FileName))
                    return;
                bool flag = this.Pmapobjs.SetImage(int.Parse(this.PmapobjFrontText.Text) - 1, openFileDialog2.FileName);
                this.pmap_ValueChanged((object)null, (EventArgs)null);
                if (flag)
                {
                    int num1 = (int)MessageBox.Show("수정 성공!");
                }
                else
                {
                    int num2 = (int)MessageBox.Show("오류가 발생했습니다!");
                }
            }
            catch
            {
            }
        }

        private void pmapImg2_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog1 = new OpenFileDialog();
                openFileDialog1.Filter = "Image File(*.bmp;*.jpg)|*.bmp;*.jpg";
                OpenFileDialog openFileDialog2 = openFileDialog1;
                if (DialogResult.OK != openFileDialog2.ShowDialog() || string.IsNullOrEmpty(openFileDialog2.FileName) || !File.Exists(openFileDialog2.FileName))
                    return;
                bool flag = this.Pmapobjs.SetImage(int.Parse(this.PmapObjBackText.Text) - 1, openFileDialog2.FileName);
                this.pmap_ValueChanged((object)null, (EventArgs)null);
                if (flag)
                {
                    int num1 = (int)MessageBox.Show("수정 성공!");
                }
                else
                {
                    int num2 = (int)MessageBox.Show("오류가 발생했습니다!");
                }
            }
            catch
            {
            }
        }

        private void spcimg1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog1 = new OpenFileDialog();
                openFileDialog1.Filter = "Image File(*.bmp;*.jpg)|*.bmp;*.jpg";
                OpenFileDialog openFileDialog2 = openFileDialog1;
                if (DialogResult.OK != openFileDialog2.ShowDialog() || string.IsNullOrEmpty(openFileDialog2.FileName) || !File.Exists(openFileDialog2.FileName))
                    return;
                int index = int.Parse(this.BattleObjText1.Text) - 1;
                bool flag = false;
                switch (this.BattleObjComboBox.SelectedIndex)
                {
                    case 0:
                        flag = this.UnitAtk.SetImage(index, openFileDialog2.FileName);
                        break;
                    case 1:
                        flag = this.UnitMov.SetImage(index, openFileDialog2.FileName);
                        break;
                    case 2:
                        flag = this.UnitSpc.SetImage(index, openFileDialog2.FileName);
                        break;
                }
                this.spcv_ValueChanged_1((object)null, (EventArgs)null);
                if (flag)
                {
                    int num1 = (int)MessageBox.Show("수정 성공!");
                }
                else
                {
                    int num2 = (int)MessageBox.Show("오류가 발생했습니다!");
                }
            }
            catch
            {
            }
        }

        private void spcimg2_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog1 = new OpenFileDialog();
                openFileDialog1.Filter = "Image File(*.bmp;*.jpg)|*.bmp;*.jpg";
                OpenFileDialog openFileDialog2 = openFileDialog1;
                if (DialogResult.OK != openFileDialog2.ShowDialog() || string.IsNullOrEmpty(openFileDialog2.FileName) || !File.Exists(openFileDialog2.FileName))
                    return;
                int index = int.Parse(this.BattleObjText2.Text) - 1;
                bool flag = false;
                switch (this.BattleObjComboBox.SelectedIndex)
                {
                    case 0:
                        flag = this.UnitAtk.SetImage(index, openFileDialog2.FileName);
                        break;
                    case 1:
                        flag = this.UnitMov.SetImage(index, openFileDialog2.FileName);
                        break;
                    case 2:
                        flag = this.UnitSpc.SetImage(index, openFileDialog2.FileName);
                        break;
                }
                this.spcv_ValueChanged_1((object)null, (EventArgs)null);
                if (flag)
                {
                    int num1 = (int)MessageBox.Show("수정 성공!");
                }
                else
                {
                    int num2 = (int)MessageBox.Show("오류가 발생했습니다!");
                }
            }
            catch
            {
            }
        }

        private void spcimg3_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog1 = new OpenFileDialog();
                openFileDialog1.Filter = "Image File(*.bmp;*.jpg)|*.bmp;*.jpg";
                OpenFileDialog openFileDialog2 = openFileDialog1;
                if (DialogResult.OK != openFileDialog2.ShowDialog() || string.IsNullOrEmpty(openFileDialog2.FileName) || !File.Exists(openFileDialog2.FileName))
                    return;
                int index = int.Parse(this.BattleObjText3.Text) - 1;
                bool flag = false;
                switch (this.BattleObjComboBox.SelectedIndex)
                {
                    case 0:
                        flag = this.UnitAtk.SetImage(index, openFileDialog2.FileName);
                        break;
                    case 1:
                        flag = this.UnitMov.SetImage(index, openFileDialog2.FileName);
                        break;
                    case 2:
                        flag = this.UnitSpc.SetImage(index, openFileDialog2.FileName);
                        break;
                }
                this.spcv_ValueChanged_1((object)null, (EventArgs)null);
                if (flag)
                {
                    int num1 = (int)MessageBox.Show("수정 성공!");
                }
                else
                {
                    int num2 = (int)MessageBox.Show("오류가 발생했습니다!");
                }
            }
            catch
            {
            }
        }
        #endregion

        private void SaveApply_Click(object sender, EventArgs e)
        {
            var popup = new SaveApplyPopup();
            popup._applyType = SaveApplyPopup.ApplyType.UnitObj;
            popup.ShowDialog();
        }
    }
}