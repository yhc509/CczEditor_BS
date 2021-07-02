using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CczEditor.Controls.DataControls
{
    public partial class SpecialDataController : BaseControl
    {

        private Data.Wrapper.SpecialEffectData CurrentSpecialEffectData;
        private Data.Wrapper.SpecialSkillData CurrentSpecialSkillData;
        private Data.Wrapper.CodeEffectData CurrentCodeEffectData;

        public SpecialDataController()
        {
            InitializeComponent();
        }


        private void ExeSpecialDataController_Load(object sender, EventArgs e)
        {
            InitSpecialTab();
            InitCodeEffectTab();
            
        }
        

        private void InitSpecialTab()
        {
            Program.ExeData.Open(System.IO.FileAccess.ReadWrite);
            var specialEffectList = Program.CurrentConfig.SpecialEffectNames;
            foreach(var info in specialEffectList)
            {
                var name = ConfigUtils.GetSpecialEffectName(Program.ExeData, Program.CurrentConfig, info.Index, Program.FORMATSTRING_KEYVALUEPAIR_HEX2);
                SpecialEffectList.Items.Add(name);
            }

            var specialSkillList = Program.CurrentConfig.SpecialSkillNames;
            foreach (var info in specialSkillList)
            {
                SpecialSkillList.Items.Add(string.Format(Program.FORMATSTRING_KEYVALUEPAIR_HEX2, info.Index, info.Description));
            }
            var temp = Program.GameData.UnitNameList(true).ToList();
            temp.Add("400, 미사용");
            var unitList = temp.ToArray();
            SpecialEffectUnitBox1.Items.AddRange(unitList);
            SpecialEffectUnitBox2.Items.AddRange(unitList);
            SpecialEffectUnitBox3.Items.AddRange(unitList);
            SpecialSkillUnitBox1.Items.AddRange(unitList);
            SpecialSkillUnitBox2.Items.AddRange(unitList);
            SpecialSkillUnitBox3.Items.AddRange(unitList);
            SpecialSkillUnitBox4.Items.AddRange(unitList);
            SpecialSkillUnitBox5.Items.AddRange(unitList);

            var forceList = ConfigUtils.GetForceNames(Program.ExeData, Program.CurrentConfig, Program.FORMATSTRING_KEYVALUEPAIR_HEX2);
            forceList.Add(0xFF, "FF, 미사용");
            SpecialEffectForceBox.Items.AddRange(forceList.Values.ToArray());
            Program.ExeData.Close();

        }

        public override void Reset()
        {
            base.Reset();
            CurrentSpecialEffectData = new Data.Wrapper.SpecialEffectData();
            CurrentSpecialSkillData = new Data.Wrapper.SpecialSkillData();
            CurrentCodeEffectData = new Data.Wrapper.CodeEffectData();
            SpecialEffectList.SelectedIndex = 0;
            SpecialSkillList.SelectedIndex = 0;
        }

        #region SpecialEffect
        private void SpecialEffectList_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadSpecielEffect(SpecialEffectList.SelectedIndex);
        }
        
        private void SpecialEffectSaveButton_Click(object sender, EventArgs e)
        {
            SaveSpecialEffect(SpecialEffectList.SelectedIndex);
        }

        private void LoadSpecielEffect(int index)
        {
            if (index < 0 || index >= Program.CurrentConfig.SpecialEffectNames.Count)
                return;

            CurrentSpecialEffectData.Read(index, Program.ExeData, Program.CurrentConfig);
            SpecialEffectName.Text = CurrentSpecialEffectData.Name;
            SpecialEffectUnitBox1.SelectedIndex = CurrentSpecialEffectData.Units[0];
            SpecialEffectUnitBox2.SelectedIndex = CurrentSpecialEffectData.Units[1];
            SpecialEffectUnitBox3.SelectedIndex = CurrentSpecialEffectData.Units[2];
            SpecialEffectForceBox.SelectedIndex = CurrentSpecialEffectData.Force;
            SpecialEffectValueBox.Value = CurrentSpecialEffectData.Value;

            if (TopLevelControl != null)
            {
                TopLevelControl.Text = string.Format("{1} - 인물/병종 코드 편집 - 번호：{0}", index, Program.TitleNameCurrent);
            }
        }

        private void SaveSpecialEffect(int index)
        {
            CurrentSpecialEffectData.Name = SpecialEffectName.Text;
            CurrentSpecialEffectData.Units[0] = (ushort) SpecialEffectUnitBox1.SelectedIndex;
            CurrentSpecialEffectData.Units[1] = (ushort) SpecialEffectUnitBox2.SelectedIndex;
            CurrentSpecialEffectData.Units[2] = (ushort) SpecialEffectUnitBox3.SelectedIndex;
            CurrentSpecialEffectData.Force = (byte) SpecialEffectForceBox.SelectedIndex;
            CurrentSpecialEffectData.Value = (byte) SpecialEffectValueBox.Value;
            
            CurrentSpecialEffectData.Write(index, Program.ExeData, Program.CurrentConfig);

            SpecialEffectList.Items.RemoveAt(index);
            SpecialEffectList.Items.Insert(index, string.Format(Program.FORMATSTRING_KEYVALUEPAIR_HEX2, index, SpecialEffectName.Text));
            SpecialEffectList.SelectedIndex = index;
        }

        private void SpecialEffectSaveApplyButton_Click(object sender, EventArgs e)
        {
            var popup = new SaveApplyPopup();
            popup._applyType = SaveApplyPopup.ApplyType.SpecialEffect;
            popup.ShowDialog();
        }

        private void SpecialEffectSearchButton_Click(object sender, EventArgs e)
        {
            int index = -1;
            var list = ConfigUtils.GetSpecialEffectNames(Program.ExeData, Program.CurrentConfig).Values.ToList();
            for (var i = 0; i < list.Count; i++)
            {
                if (list[i].Contains(SpecialEffectSearchBox.Text))
                {
                    index = i;
                    break;
                }
            }
            if (index == -1)
            {
                MessageBox.Show("찾기에 실패했습니다.", "경고", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            SpecialEffectList.SelectedIndex = index;

        }
        #endregion
        
        #region SpecialSkill

        private void SpecialSkillList_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadSpecielSkill(SpecialSkillList.SelectedIndex);
        }

        private void SpecialSkillSaveButton_Click(object sender, EventArgs e)
        {
            SaveSpecialSkill(SpecialSkillList.SelectedIndex);
        }

        private void LoadSpecielSkill(int index)
        {
            if (index < 0 || index >= Program.CurrentConfig.SpecialSkillNames.Count)
                return;
            
            CurrentSpecialSkillData.Read(index, Program.GameData, Program.ImsgData, Program.ExeData, Program.CurrentConfig);
            SpecialSkillName.Text = CurrentSpecialSkillData.Name;

            bool isPhysics = index <= Program.CurrentConfig.Exe.SpecialSkillPhysicsCount;
            SpecialSkillUnitBox1.Enabled = isPhysics;
            SpecialSkillUnitBox2.Enabled = isPhysics;
            SpecialSkillUnitBox3.Enabled = isPhysics;
            SpecialSkillUnitBox4.Enabled = isPhysics;
            SpecialSkillUnitBox5.Enabled = isPhysics;
            SpecialSkillLevelBox1.Enabled = isPhysics;
            SpecialSkillLevelBox2.Enabled = isPhysics;
            SpecialSkillLevelBox3.Enabled = isPhysics;
            SpecialSkillLevelBox4.Enabled = isPhysics;
            SpecialSkillLevelBox5.Enabled = isPhysics;
            SpecialSkillValueBox.Enabled = isPhysics;

            if (isPhysics)
            {
                int offset = Program.CurrentConfig.Exe.SpecialSkillOffset;

                SpecialSkillUnitBox1.SelectedIndex = CurrentSpecialSkillData.Units[0];
                SpecialSkillLevelBox1.Value = CurrentSpecialSkillData.Levels[0];
                SpecialSkillUnitBox2.SelectedIndex = CurrentSpecialSkillData.Units[1];
                SpecialSkillLevelBox2.Value = CurrentSpecialSkillData.Levels[1];
                SpecialSkillUnitBox3.SelectedIndex = CurrentSpecialSkillData.Units[2];
                SpecialSkillLevelBox3.Value = CurrentSpecialSkillData.Levels[2];
                SpecialSkillUnitBox4.SelectedIndex = CurrentSpecialSkillData.Units[3];
                SpecialSkillLevelBox4.Value = CurrentSpecialSkillData.Levels[3];
                SpecialSkillUnitBox5.SelectedIndex = CurrentSpecialSkillData.Units[4];
                SpecialSkillLevelBox5.Value = CurrentSpecialSkillData.Levels[4];

                SpecialSkillValueBox.Value = CurrentSpecialSkillData.Value;
            }

            if (TopLevelControl != null)
            {
                TopLevelControl.Text = string.Format("{1} - 필살기 편집 - 번호：{0}", index, Program.TitleNameCurrent);
            }
        }

        private void SaveSpecialSkill(int index)
        {
            CurrentSpecialSkillData.Write(index, Program.ExeData, Program.CurrentConfig);
            CurrentSpecialSkillData.Name = SpecialSkillName.Text;
            CurrentSpecialSkillData.Units[0] = (ushort) SpecialSkillUnitBox1.SelectedIndex;
            CurrentSpecialSkillData.Units[1] = (ushort)SpecialSkillUnitBox2.SelectedIndex;
            CurrentSpecialSkillData.Units[2] = (ushort)SpecialSkillUnitBox3.SelectedIndex;
            CurrentSpecialSkillData.Units[3] = (ushort)SpecialSkillUnitBox4.SelectedIndex;
            CurrentSpecialSkillData.Units[4] = (ushort)SpecialSkillUnitBox5.SelectedIndex;

            CurrentSpecialSkillData.Levels[0] = (byte)SpecialSkillLevelBox1.Value;
            CurrentSpecialSkillData.Levels[1] = (byte)SpecialSkillLevelBox2.Value;
            CurrentSpecialSkillData.Levels[2] = (byte)SpecialSkillLevelBox3.Value;
            CurrentSpecialSkillData.Levels[3] = (byte)SpecialSkillLevelBox4.Value;
            CurrentSpecialSkillData.Levels[4] = (byte)SpecialSkillLevelBox5.Value;

            CurrentSpecialSkillData.Value = (byte)SpecialSkillValueBox.Value;

            SpecialSkillList.Items.RemoveAt(index);
            SpecialSkillList.Items.Insert(index, string.Format(Program.FORMATSTRING_KEYVALUEPAIR_HEX2, index, SpecialSkillName.Text));
            SpecialSkillList.SelectedIndex = index;
        }

        private void SpecialSkillSaveApplyButton_Click(object sender, EventArgs e)
        {
            var popup = new SaveApplyPopup();
            popup._applyType = SaveApplyPopup.ApplyType.SpecailSkill;
            popup.ShowDialog();
        }

        #endregion
        
        private void InitCodeEffectTab()
        {
            CurrentCodeEffectData.Read(Program.ExeData, Program.CurrentConfig);

            AbilityAssistList.Items.AddRange(Program.CurrentConfig.CodeEffects.Where(x => x.TypeIndex == (int)Config.ConfigCodeEffectInfos.Type.AbilityAssist).Select(x=>x.Description).ToArray());
            SpecialAtkList.Items.AddRange(Program.CurrentConfig.CodeEffects.Where(x => x.TypeIndex == (int)Config.ConfigCodeEffectInfos.Type.SpecialAttack).Select(x => x.Description).ToArray());
            AttackAccList.Items.AddRange(Program.CurrentConfig.CodeEffects.Where(x => x.TypeIndex == (int)Config.ConfigCodeEffectInfos.Type.AttackAcc).Select(x => x.Description).ToArray());
            MagicList.Items.AddRange(Program.CurrentConfig.CodeEffects.Where(x => x.TypeIndex == (int)Config.ConfigCodeEffectInfos.Type.Magic).Select(x => x.Description).ToArray());
            StateEffectAttackList.Items.AddRange(Program.CurrentConfig.CodeEffects.Where(x => x.TypeIndex == (int)Config.ConfigCodeEffectInfos.Type.StateEffectAttack).Select(x => x.Description).ToArray());
            TurnCureList.Items.AddRange(Program.CurrentConfig.CodeEffects.Where(x => x.TypeIndex == (int)Config.ConfigCodeEffectInfos.Type.TurnCure).Select(x => x.Description).ToArray());
            DeburfList.Items.AddRange(Program.CurrentConfig.CodeEffects.Where(x => x.TypeIndex == (int)Config.ConfigCodeEffectInfos.Type.DeburfAttack).Select(x => x.Description).ToArray());
            DecreaseDmgList.Items.AddRange(Program.CurrentConfig.CodeEffects.Where(x => x.TypeIndex == (int)Config.ConfigCodeEffectInfos.Type.DecreaseDmg).Select(x => x.Description).ToArray());
            DefenceList.Items.AddRange(Program.CurrentConfig.CodeEffects.Where(x => x.TypeIndex == (int)Config.ConfigCodeEffectInfos.Type.Defence).Select(x => x.Description).ToArray());
            TerrainList.Items.AddRange(Program.CurrentConfig.CodeEffects.Where(x => x.TypeIndex == (int)Config.ConfigCodeEffectInfos.Type.TerrainAssist).Select(x => x.Description).ToArray());
            EtcList.Items.AddRange(Program.CurrentConfig.CodeEffects.Where(x => x.TypeIndex == (int)Config.ConfigCodeEffectInfos.Type.Etc).Select(x => x.Description).ToArray());

            SpecialAtkValue2.Items.AddRange(Program.CurrentConfig.HitAreaNames.ToArray());

            var temp = ConfigUtils.GetAuxiliaryEffects(Program.ExeData, Program.CurrentConfig, Program.FORMATSTRING_KEYVALUEPAIR_HEX2);
            temp.Add(0x48, "48, 미사용");
            var codeList = temp.Values.ToArray();
            AbilityAssistValue.Items.AddRange(codeList);
            SpecialAtkValue.Items.AddRange(codeList);
            AttackAccValue.Items.AddRange(codeList);
            MagicValue.Items.AddRange(codeList);
            StateEffectAttackValue.Items.AddRange(codeList);
            TurnCureValue.Items.AddRange(codeList);
            DeburfValue.Items.AddRange(codeList);
            DecreaseDmgValue.Items.AddRange(codeList);
            DefenceValue.Items.AddRange(codeList);
            TerrainValue.Items.AddRange(codeList);
            EtcValue.Items.AddRange(codeList);
            
            AbilityAssistList.SelectedIndex = 0;
            SpecialAtkList.SelectedIndex = 0;
            AttackAccList.SelectedIndex = 0;
            MagicList.SelectedIndex = 0;
            StateEffectAttackList.SelectedIndex = 0;
            TurnCureList.SelectedIndex = 0;
            DeburfList.SelectedIndex = 0;
            DecreaseDmgList.SelectedIndex = 0;
            DefenceList.SelectedIndex = 0;
            TerrainList.SelectedIndex = 0;
            EtcList.SelectedIndex = 0;
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (Program.ExeData.IsLocked) return;

            var abilityAssistList = Program.CurrentConfig.CodeEffects.Where(x => x.TypeIndex == (int)Config.ConfigCodeEffectInfos.Type.AbilityAssist).ToArray();
            var specialAtkList = Program.CurrentConfig.CodeEffects.Where(x => x.TypeIndex == (int)Config.ConfigCodeEffectInfos.Type.SpecialAttack).ToArray();
            var attackAccList = Program.CurrentConfig.CodeEffects.Where(x => x.TypeIndex == (int)Config.ConfigCodeEffectInfos.Type.AttackAcc).ToArray();
            var magicList = Program.CurrentConfig.CodeEffects.Where(x => x.TypeIndex == (int)Config.ConfigCodeEffectInfos.Type.Magic).ToArray();
            var stateEffectAttackList = Program.CurrentConfig.CodeEffects.Where(x => x.TypeIndex == (int)Config.ConfigCodeEffectInfos.Type.StateEffectAttack).ToArray();
            var turnCureList = Program.CurrentConfig.CodeEffects.Where(x => x.TypeIndex == (int)Config.ConfigCodeEffectInfos.Type.TurnCure).ToArray();
            var deburfList = Program.CurrentConfig.CodeEffects.Where(x => x.TypeIndex == (int)Config.ConfigCodeEffectInfos.Type.DeburfAttack).ToArray();
            var decreaseDmgList = Program.CurrentConfig.CodeEffects.Where(x => x.TypeIndex == (int)Config.ConfigCodeEffectInfos.Type.DecreaseDmg).ToArray();
            var defenceList = Program.CurrentConfig.CodeEffects.Where(x => x.TypeIndex == (int)Config.ConfigCodeEffectInfos.Type.Defence).ToArray();
            var terrainList = Program.CurrentConfig.CodeEffects.Where(x => x.TypeIndex == (int)Config.ConfigCodeEffectInfos.Type.TerrainAssist).ToArray();
            var etcList = Program.CurrentConfig.CodeEffects.Where(x => x.TypeIndex == (int)Config.ConfigCodeEffectInfos.Type.Etc).ToArray();

            var abilityAssist = abilityAssistList[AbilityAssistList.SelectedIndex];
            var specialAtk = specialAtkList[SpecialAtkList.SelectedIndex];
            var attackAcc = attackAccList[AttackAccList.SelectedIndex];
            var magic = magicList[MagicList.SelectedIndex];
            var stateEffectAttack = stateEffectAttackList[StateEffectAttackList.SelectedIndex];
            var turnCure = turnCureList[TurnCureList.SelectedIndex];
            var deburf = deburfList[DeburfList.SelectedIndex];
            var decreaseDmg = decreaseDmgList[DecreaseDmgList.SelectedIndex];
            var defence = defenceList[DefenceList.SelectedIndex];
            var terrain = terrainList[TerrainList.SelectedIndex];
            var etc = etcList[EtcList.SelectedIndex];

            CurrentCodeEffectData.CodeEffectContainer[abilityAssist.Description] = (byte)Utils.GetId(AbilityAssistValue.SelectedItem);
            if (abilityAssist.SubEdit == 1)
            {
                CurrentCodeEffectData.AbilityAssistPercent[AbilityAssistList.SelectedIndex] = AbilityAssistValue2.Checked;
            }

            CurrentCodeEffectData.CodeEffectContainer[specialAtk.Description] = (byte)Utils.GetId(SpecialAtkValue.SelectedItem);
            if (specialAtk.SubEdit == 1)
            {
                CurrentCodeEffectData.SpecialAtkValue[0] = (byte) SpecialAtkValue2.SelectedIndex;
            }
            else if (specialAtk.SubEdit == 2)
            {
                CurrentCodeEffectData.SpecialAtkValue[1] = (byte)SpecialAtkValue2.SelectedIndex;
            }
            else if (specialAtk.SubEdit == 3)
            {
                CurrentCodeEffectData.SpecialAtkValue[2] = (byte) (SpecialAtkValue3.Checked ? 4 : 1);
            }

            CurrentCodeEffectData.CodeEffectContainer[attackAcc.Description] = (byte)Utils.GetId(AttackAccValue.SelectedItem);
            CurrentCodeEffectData.CodeEffectContainer[magic.Description] = (byte)Utils.GetId(MagicValue.SelectedItem);


            CurrentCodeEffectData.CodeEffectContainer[stateEffectAttack.Description] = (byte)Utils.GetId(StateEffectAttackValue.SelectedItem);

            if (stateEffectAttack.SubEdit == 1)
            {
                CurrentCodeEffectData.StateEffectAttackAccValue[0,0] = (byte)StateEffectAttackAccValue1_1.Value;
                CurrentCodeEffectData.StateEffectAttackAccValue[1, 0] = (byte)StateEffectAttackAccValue2_1.Value;
                CurrentCodeEffectData.StateEffectAttackAccValue[2, 0] = (byte)StateEffectAttackAccValue3_1.Value;
                CurrentCodeEffectData.StateEffectAttackAccValue[3, 0] = (byte)StateEffectAttackAccValue4_1.Value;
                CurrentCodeEffectData.StateEffectAttackAccValue[0, 1] = (byte)StateEffectAttackAccValue1_2.Value;
                CurrentCodeEffectData.StateEffectAttackAccValue[1, 1] = (byte)StateEffectAttackAccValue2_2.Value;
                CurrentCodeEffectData.StateEffectAttackAccValue[2, 1] = (byte)StateEffectAttackAccValue3_2.Value;
                CurrentCodeEffectData.StateEffectAttackAccValue[3, 1] = (byte)StateEffectAttackAccValue4_2.Value;
            }

            CurrentCodeEffectData.CodeEffectContainer[turnCure.Description] = (byte)Utils.GetId(TurnCureValue.SelectedItem);
            CurrentCodeEffectData.CodeEffectContainer[deburf.Description] = (byte)Utils.GetId(DeburfValue.SelectedItem);
            CurrentCodeEffectData.CodeEffectContainer[decreaseDmg.Description] = (byte)Utils.GetId(DecreaseDmgValue.SelectedItem);
            CurrentCodeEffectData.CodeEffectContainer[defence.Description] = (byte)Utils.GetId(DefenceValue.SelectedItem);

            if (defence.SubEdit == 1)
            {
                CurrentCodeEffectData.GoldDefence = (byte)DefenceValue2.Value;
                Program.ExeData.WriteByte((byte)DefenceValue2.Value, 0, Program.CurrentConfig.Exe.GoldDefenceRateOffset);
            }
            else if (defence.SubEdit == 2)
            {
                var code = (byte)Utils.GetId(DefenceValue.SelectedItem);
                CurrentCodeEffectData.MpDefenceRecover = DefenceValue3.Checked;
            }

            CurrentCodeEffectData.CodeEffectContainer[terrain.Description] = (byte)Utils.GetId(TerrainValue.SelectedItem);
            CurrentCodeEffectData.CodeEffectContainer[etc.Description] = (byte)Utils.GetId(EtcValue.SelectedItem);

            CurrentCodeEffectData.Write(Program.ExeData, Program.CurrentConfig);
        }

        private void GetCode(Config.ConfigCodeEffectInfos info, ComboBox codeBox)
        {
            if (Program.ExeData.IsLocked) return;

            var code = CurrentCodeEffectData.CodeEffectContainer[info.Description]; //Program.ExeData.ReadByte(0, info.Offset);
            codeBox.SelectedIndex = codeBox.FindString(Utils.GetString(code));
        }

        private void AbilityAssistList_SelectedIndexChanged(object sender, EventArgs e)
        {
            var list = Program.CurrentConfig.CodeEffects.Where(x => x.TypeIndex == (int)Config.ConfigCodeEffectInfos.Type.AbilityAssist).ToArray();
            var info = list[AbilityAssistList.SelectedIndex];
            GetCode(info, AbilityAssistValue);
            AbilityAssistValue.Enabled = info.Editable;
            if(info.SubEdit == 1)
            {
                AbilityAssistValue2.Enabled = true;
                var isChecked = CurrentCodeEffectData.AbilityAssistPercent[AbilityAssistList.SelectedIndex];
                // Program.ExeData.ReadByte(AbilityAssistList.SelectedIndex, Program.CurrentConfig.Exe.AbilityAssistPercentOffset) == 2;
                AbilityAssistValue2.Checked = isChecked;
            }
            else
            {
                AbilityAssistValue2.Enabled = false;
            }
            
        }

        private void SpecialAtkList_SelectedIndexChanged(object sender, EventArgs e)
        {
            var list = Program.CurrentConfig.CodeEffects.Where(x => x.TypeIndex == (int)Config.ConfigCodeEffectInfos.Type.SpecialAttack).ToArray();
            var info = list[SpecialAtkList.SelectedIndex];
            GetCode(info, SpecialAtkValue);
            SpecialAtkValue.Enabled = info.Editable;
            SpecialAtkValue2.Enabled = info.SubEdit == 1 || info.SubEdit == 2;
            if (info.SubEdit == 1)
            {
                SpecialAtkValue2.Enabled = true;
                var value = CurrentCodeEffectData.SpecialAtkValue[0];// Program.ExeData.ReadByte(0, Program.CurrentConfig.Exe.RangeAttack2TypeOffset);
                SpecialAtkValue2.SelectedIndex = value;
            }
            else if (info.SubEdit == 2)
            {
                SpecialAtkValue2.Enabled = true;
                var value = CurrentCodeEffectData.SpecialAtkValue[1]; // Program.ExeData.ReadByte(0, Program.CurrentConfig.Exe.RangeAttack3TypeOffset);
                SpecialAtkValue2.SelectedIndex = value;
            }
            else
            {
                SpecialAtkValue2.Enabled = false;
            }
            
            if (info.SubEdit == 3)
            {
                SpecialAtkValue3.Enabled = true;
                var isChecked = CurrentCodeEffectData.SpecialAtkValue[2] == 4;// Program.ExeData.ReadByte(0, Program.CurrentConfig.Exe.IgnoreDefenceOffset) == 4;
                SpecialAtkValue3.Checked = isChecked;
            }
            else
            {
                SpecialAtkValue3.Enabled = false;
            }
        }

        private void AttackAccList_SelectedIndexChanged(object sender, EventArgs e)
        {
            var list = Program.CurrentConfig.CodeEffects.Where(x => x.TypeIndex == (int)Config.ConfigCodeEffectInfos.Type.AttackAcc).ToArray();
            var info = list[AttackAccList.SelectedIndex];
            GetCode(info, AttackAccValue);
            AttackAccValue.Enabled = info.Editable;
        }
        
        private void TerrainList_SelectedIndexChanged(object sender, EventArgs e)
        {
            var list = Program.CurrentConfig.CodeEffects.Where(x => x.TypeIndex == (int)Config.ConfigCodeEffectInfos.Type.TerrainAssist).ToArray();
            var info = list[TerrainList.SelectedIndex];
            GetCode(info, TerrainValue);
            TerrainValue.Enabled = info.Editable;
        }

        private void EtcList_SelectedIndexChanged(object sender, EventArgs e)
        {
            var list = Program.CurrentConfig.CodeEffects.Where(x => x.TypeIndex == (int)Config.ConfigCodeEffectInfos.Type.Etc).ToArray();
            var info = list[EtcList.SelectedIndex];
            GetCode(info, EtcValue);
            EtcValue.Enabled = info.Editable;
        }

        private void DefenceList_SelectedIndexChanged(object sender, EventArgs e)
        {
            var list = Program.CurrentConfig.CodeEffects.Where(x => x.TypeIndex == (int)Config.ConfigCodeEffectInfos.Type.Defence).ToArray();
            var info = list[DefenceList.SelectedIndex];
            GetCode(info, DefenceValue);
            DefenceValue.Enabled = info.Editable;
            DefenceValue2.Enabled = info.SubEdit == 1;
            DefenceValue3.Enabled = info.SubEdit == 2;

            if (info.SubEdit == 1)
            {
                DefenceValue2.Enabled = true;
                var value = CurrentCodeEffectData.GoldDefence;// Program.ExeData.ReadByte(0, Program.CurrentConfig.Exe.GoldDefenceRateOffset);
                DefenceValue2.Value = value;
            }
            else
            {
                DefenceValue2.Enabled = false;
            }

            if (info.SubEdit == 2)
            {
                DefenceValue3.Enabled = true;
                var code = (byte)Utils.GetId(DefenceValue.SelectedItem);
                var isChecked = CurrentCodeEffectData.MpDefenceRecover;// Program.ExeData.ReadByte(0, Program.CurrentConfig.Exe.MpDefenceRecoverOffest) == code;
                DefenceValue3.Checked = isChecked;
            }
            else
            {
                DefenceValue3.Enabled = false;
            }
        }

        private void TurnCureList_SelectedIndexChanged(object sender, EventArgs e)
        {
            var list = Program.CurrentConfig.CodeEffects.Where(x => x.TypeIndex == (int)Config.ConfigCodeEffectInfos.Type.TurnCure).ToArray();
            var info = list[TurnCureList.SelectedIndex];
            GetCode(info, TurnCureValue);
            TurnCureValue.Enabled = info.Editable;
        }

        private void DeburfList_SelectedIndexChanged(object sender, EventArgs e)
        {
            var list = Program.CurrentConfig.CodeEffects.Where(x => x.TypeIndex == (int)Config.ConfigCodeEffectInfos.Type.DeburfAttack).ToArray();
            var info = list[DeburfList.SelectedIndex];
            GetCode(info, DeburfValue);
            DeburfValue.Enabled = info.Editable;
        }

        private void MagicList_SelectedIndexChanged(object sender, EventArgs e)
        {
            var list = Program.CurrentConfig.CodeEffects.Where(x => x.TypeIndex == (int)Config.ConfigCodeEffectInfos.Type.Magic).ToArray();
            var info = list[MagicList.SelectedIndex];
            GetCode(info, MagicValue);
            MagicValue.Enabled = info.Editable;
        }

        private void StateEffectAttackList_SelectedIndexChanged(object sender, EventArgs e)
        {
            var list = Program.CurrentConfig.CodeEffects.Where(x => x.TypeIndex == (int)Config.ConfigCodeEffectInfos.Type.StateEffectAttack).ToArray();
            var info = list[StateEffectAttackList.SelectedIndex];
            GetCode(info, StateEffectAttackValue);
            StateEffectAttackValue.Enabled = info.Editable;
            StateEffectAttackAccValue1_1.Enabled = info.SubEdit == 1;
            StateEffectAttackAccValue2_1.Enabled = info.SubEdit == 1;
            StateEffectAttackAccValue3_1.Enabled = info.SubEdit == 1;
            StateEffectAttackAccValue4_1.Enabled = info.SubEdit == 1;
            StateEffectAttackAccValue1_2.Enabled = info.SubEdit == 1;
            StateEffectAttackAccValue2_2.Enabled = info.SubEdit == 1;
            StateEffectAttackAccValue3_2.Enabled = info.SubEdit == 1;
            StateEffectAttackAccValue4_2.Enabled = info.SubEdit == 1;

            Program.ExeData.Open(System.IO.FileAccess.ReadWrite);
            if(info.SubEdit == 1)
            {
                StateEffectAttackAccValue1_1.Value = CurrentCodeEffectData.StateEffectAttackAccValue[0, 0];// (byte)Program.ExeData.ReadByte(0, Program.CurrentConfig.Exe.StateEffectAccOffset);
                StateEffectAttackAccValue2_1.Value = CurrentCodeEffectData.StateEffectAttackAccValue[1, 0];//(byte)Program.ExeData.ReadByte(1, Program.CurrentConfig.Exe.StateEffectAccOffset);
                StateEffectAttackAccValue3_1.Value = CurrentCodeEffectData.StateEffectAttackAccValue[2, 0];//(byte)Program.ExeData.ReadByte(2, Program.CurrentConfig.Exe.StateEffectAccOffset);
                StateEffectAttackAccValue4_1.Value = CurrentCodeEffectData.StateEffectAttackAccValue[3, 0];//(byte)Program.ExeData.ReadByte(3, Program.CurrentConfig.Exe.StateEffectAccOffset);
                StateEffectAttackAccValue1_2.Value = CurrentCodeEffectData.StateEffectAttackAccValue[0, 1];//(byte)Program.ExeData.ReadByte(4, Program.CurrentConfig.Exe.StateEffectAccOffset);
                StateEffectAttackAccValue2_2.Value = CurrentCodeEffectData.StateEffectAttackAccValue[1, 1];//(byte)Program.ExeData.ReadByte(5, Program.CurrentConfig.Exe.StateEffectAccOffset);
                StateEffectAttackAccValue3_2.Value = CurrentCodeEffectData.StateEffectAttackAccValue[2, 1];//(byte)Program.ExeData.ReadByte(6, Program.CurrentConfig.Exe.StateEffectAccOffset);
                StateEffectAttackAccValue4_2.Value = CurrentCodeEffectData.StateEffectAttackAccValue[3, 1];//(byte)Program.ExeData.ReadByte(7, Program.CurrentConfig.Exe.StateEffectAccOffset);
            }
            Program.ExeData.Close();
        }

        private void DecreaseDmgList_SelectedIndexChanged(object sender, EventArgs e)
        {
            var list = Program.CurrentConfig.CodeEffects.Where(x => x.TypeIndex == (int)Config.ConfigCodeEffectInfos.Type.DecreaseDmg).ToArray();
            var info = list[DecreaseDmgList.SelectedIndex];
            GetCode(info, DecreaseDmgValue);
            DecreaseDmgValue.Enabled = info.Editable;
        }
        
    }
}
