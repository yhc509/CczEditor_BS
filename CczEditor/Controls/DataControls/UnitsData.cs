#region using List

using System;
using System.Collections.Generic;
using System.Windows.Forms;

using CczEditor.Data;

#endregion
using System.Drawing;
using System.Media;

namespace CczEditor.Controls.DataControls
{
    public partial class UnitsData : BaseDataControl
	{
        private List<int> _itemIconList;
        
        public UnitsData()
		{
			InitializeComponent();
            CharacterComboBox.Enabled = PmapObjValueBox.Enabled = BattleObjValueBox.Enabled = BattleObjTeam1Radio.Visible = BattleObjTeam2Radio.Visible = BattleObjTeam3Radio.Visible = ExeDataLoaded;
            PmapobjFrontText.Visible = PmapObjBackText.Visible = BattleObjText1.Visible = BattleObjText2.Visible = BattleObjText3.Visible = ExeDataLoaded;
            pmapimg1.Visible = pmapimg2.Visible = spcimg1.Visible = spcimg2.Visible = spcimg3.Visible = ExeDataLoaded;
            lblCharacter.Visible = CharacterComboBox.Visible = Program.CurrentConfig.Starusing;

			tlpImsg.Enabled = ImsgDataLoaded;
			ncStr.Maximum = ncVit.Maximum = ncInt.Maximum = ncAvg.Maximum = ncLuk.Maximum = Program.CurrentConfig.SingularAttribute ? 255 : 510;
			ncStr.Increment = ncVit.Increment = ncInt.Increment = ncAvg.Increment = ncLuk.Increment = Program.CurrentConfig.SingularAttribute ? 1 : 2;

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
			_itemIconList = GameData.ItemIconList();
            cbForce.Items.Clear();
            cbForce.Items.AddRange(Program.CurrentConfig.ForceNames.ToArray());
            
            clbList.Items.AddRange(GameData.UnitNameList(true).ToArray());
			clbList.SelectedIndex = 0;
            PmapObjActionComboBox.SelectedIndex = 0;
            BattleObjComboBox.SelectedIndex = 0;
            clbList.Focus();
		}

        private void LoadUnit(int index)
        {
            if (index < 0 || index >= Program.CurrentConfig.Offsets["Game_Unit_Count"])
                return;

            var unit = new CczEditor.Data.Wrapper.UnitData();
            unit.Read(index);

            txtName.Text = unit.Name;
            ncFace.Value = unit.Face;
            ncCritical.Value = unit.CriticalIndex;

            if (Program.CurrentConfig.SingularAttribute)
            {
                ncStr.Value = unit.Str;
                ncVit.Value = unit.Vit;
                ncInt.Value = unit.Int;
                ncAvg.Value = unit.Avg;
                ncLuk.Value = unit.Luk;
            }
            else
            {
                ncStr.Value = unit.Str * 2;
                ncVit.Value = unit.Vit * 2;
                ncInt.Value = unit.Int * 2;
                ncAvg.Value = unit.Avg * 2;
                ncLuk.Value = unit.Luk * 2;
            }
            ncHp.Value = unit.Hp;
            ncMp.Value = unit.Mp;
            cbForce.SelectedIndex = unit.Force;


            PmapObjValueBox.Value = unit.Pmapobj;
            CharacterComboBox.SelectedIndex = unit.CharacterType;
            BattleObjValueBox.Value = unit.BattleObj;

            lblCutin.Visible = CutinComboBox.Visible = cbbCutin.Visible = index <= 255;
            lblVoice.Visible = VoiceComboBox.Visible = cbbVoice.Visible = VoicePlayButton.Visible = index <= 255;
            lblCost.Visible = CostValueBox.Visible = cbbCost.Visible = index <= 255;
            if (index <= 255)
            {
                CutinComboBox.SelectedIndex = unit.Cutin;
                VoiceComboBox.SelectedIndex = unit.Voice;
                CostValueBox.Value = unit.Cost;
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
                txtImsg.Text = unit.Imsg;
            else if (rbtnImsgType2.Checked)
                txtImsg.Text = unit.Retreat;

            SettingFaceType();

            if (TopLevelControl != null)
                TopLevelControl.Text = string.Format("{1} - 인물 편집 - 번호：{0}", clbList.SelectedIndex, Program.TitleNameCurrent);
        }

        private void SaveUnit(int index, bool isBatch = false)
        {
            var unit = new CczEditor.Data.Wrapper.UnitData();

            unit.Name = txtName.Text;
            unit.Face = (ushort)ncFace.Value;
            unit.CriticalIndex = (byte)ncCritical.Value;
            unit.Str = (byte)ncStr.Value;
            
            if (Program.CurrentConfig.SingularAttribute)
            {
                unit.Str = (byte)ncStr.Value;
                unit.Vit = (byte)ncVit.Value;
                unit.Int = (byte)ncInt.Value;
                unit.Avg = (byte)ncAvg.Value;
                unit.Luk = (byte)ncLuk.Value;
            } else
            {
                unit.Str = (byte) (ncStr.Value / 2);
                unit.Vit = (byte) (ncVit.Value / 2);
                unit.Int = (byte) (ncInt.Value / 2);
                unit.Avg = (byte) (ncAvg.Value / 2);
                unit.Luk = (byte) (ncLuk.Value / 2);
            }

            unit.Hp = (ushort)ncHp.Value;
            unit.Mp = (byte)ncMp.Value;
            unit.Force = (byte)cbForce.SelectedIndex;

            unit.Pmapobj = (ushort) PmapObjValueBox.Value;
            unit.BattleObj = (ushort) BattleObjValueBox.Value;
            unit.CharacterType = (byte) CharacterComboBox.SelectedIndex;
            unit.Cutin = (byte) CutinComboBox.SelectedIndex;
            unit.Voice = (byte)VoiceComboBox.SelectedIndex;
            unit.Cost = (byte) CostValueBox.Value;

            if (rbtnImsgType1.Checked)
                unit.Imsg = txtImsg.Text;
            else if (rbtnImsgType2.Checked)
                unit.Retreat = txtImsg.Text;

            unit.Write(index);

            clbList.Items.RemoveAt(index);
            clbList.Items.Insert(index, string.Format(Program.FORMATSTRING_KEYVALUEPAIR_HEX3, index, unit.Name));
            clbList.SelectedIndex = index;
        }

        private void CopyUnit(int index, int[] targetIndexes, bool isTailNumber)
        {
            var unit = new CczEditor.Data.Wrapper.UnitData();
            unit.Read(index);

            int nameNumber = 1;

            foreach(var targetIndex in targetIndexes)
            {
                if(isTailNumber)
                    unit.Name = $"{txtName.Text}{nameNumber++}";
                unit.Write(targetIndex);

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
			lblImsgCount.Text = string.Format("글자 수 {0}", txtImsg.Text.Length);
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
                    var msg = ImsgData.UnitExtensionGet(clbList.SelectedIndex);
                    txtImsg.Text = Utils.ByteToString(msg, 0, Program.IMSG_DATA_BLOCK_LENGTH);
                }
                else if (rbtnImsgType2.Checked)
                {
                    var msg = ImsgData.RetreatGet(clbList.SelectedIndex);
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
            if (UnitSpc == null || Program.ExeData == null || clbList.SelectedIndex < 0)
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

            if (Program.CurrentConfig.SpcExtension)
            {
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
                        spc = 180 + (forceIndex - 0x1f) * 3 + teamIndex;
                        BattleObjText1.Text = (spc + 1).ToString();
                        spcimg1.Image = loader.GetImage(spc);
                    }
                }
                else if (battleObjIndex >= 1 && battleObjIndex <= Program.CurrentConfig.Offsets["Three_SPC"])
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
                    spc = 240 + (Program.CurrentConfig.Offsets["Three_SPC"] * 3) + ((int)battleObjIndex - (Program.CurrentConfig.Offsets["Three_SPC"] + 1));
                    BattleObjText1.Text = (spc + 1).ToString();
                    spcimg1.Image = loader.GetImage(spc);
                }
            }
        }

        private int GetBattleObjImageIndex()
        {
            var force = cbForce.SelectedIndex;
            int value;

            if (force < 60) value = force / 3;
            else value = 20 + (force - 60) / 3;
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
            if (Pmapobjs == null || Program.ExeData == null || clbList.SelectedIndex < 0)
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

            if (FaceLarges == null || clbList.SelectedIndex < 0)
            {
                return;
            }

            pbFaceL.Image = FaceLarges.GetImage(faceIndex);

        }
        #endregion

        #region Search
        private void searchButton_Click(object sender, EventArgs e)
        {
            var list = GameData.UnitNameList(false);
            var index = list.FindIndex(x => x == searchTextBox.Text);
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
            MoveUnits popup = new MoveUnits();
            popup.FormClosed += (s, ev) =>
            {
                clbList.Items.Clear();
                clbList.Items.AddRange(GameData.UnitNameList(true).ToArray());
                clbList.SelectedIndex = 0;
            };
            popup.ShowDialog();
        }
        #endregion

        private void VoicePlayButton_Click(object sender, EventArgs e)
        {
            var fileName = VoiceComboBox.SelectedItem.ToString();
            var path = System.IO.Path.Combine(Program.CurrentConfig.DataFileDirectory, "Wav", fileName);

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
    }
}