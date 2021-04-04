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
    public partial class ExeSpecialDataController : UserControl
    {
        public ExeSpecialDataController()
        {
            InitializeComponent();
        }


        private void ExeSpecialDataController_Load(object sender, EventArgs e)
        {
            InitSpecialTab();
            InitCodeEffectTab();

            SpecialEffectList.SelectedIndex = 0;
            SpecialSkillList.SelectedIndex = 0;
        }


        private void InitSpecialTab()
        {
            Data.ExeData.Open(System.IO.FileAccess.ReadWrite);
            var specialEffectList = Program.CurrentConfig.SpecialEffectNames;
            foreach(var info in specialEffectList)
            {
                var name = ConfigUtils.GetSpecialEffectName(info.Index, Program.FORMATSTRING_KEYVALUEPAIR_HEX2);
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

            var forceList = ConfigUtils.GetForceNames(Program.FORMATSTRING_KEYVALUEPAIR_HEX2);
            forceList.Add(0xFF, "FF, 미사용");
            SpecialEffectForceBox.Items.AddRange(forceList.Values.ToArray());
            Data.ExeData.Close();

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

            SpecialEffectName.Text = ConfigUtils.GetSpecialEffectName(index);

            int offset = Program.CurrentConfig.Exe.SpecialEffectOffset;
            Data.ExeData.Open(System.IO.FileAccess.ReadWrite);

            SpecialEffectUnitBox1.SelectedIndex = Data.ExeData.ReadWord(0, offset + index * 0x08);
            SpecialEffectUnitBox2.SelectedIndex = Data.ExeData.ReadWord(0, offset + index * 0x08 + 0x02);
            SpecialEffectUnitBox3.SelectedIndex = Data.ExeData.ReadWord(0, offset + index * 0x08 + 0x04);

            int force = Data.ExeData.ReadByte(0, offset + index * 0x08 + 0x6);
            if (force == 0xFF) force = 0x50;
            SpecialEffectForceBox.SelectedIndex = force;
            SpecialEffectValueBox.Value = Data.ExeData.ReadByte(0, offset + index * 0x08 + 0x7);

            Data.ExeData.Close();
        }

        private void SaveSpecialEffect(int index)
        {
            var info = Program.CurrentConfig.SpecialEffectNames.Find(x => x.Index == index);
            
            byte[] result = new byte[0x0D];
            Data.ExeData.WriteText(SpecialEffectName.Text, info.Offset, 0x0D);

            int offset = Program.CurrentConfig.Exe.SpecialEffectOffset;
            Data.ExeData.Open(System.IO.FileAccess.ReadWrite);
            Data.ExeData.WriteWord(SpecialEffectUnitBox1.SelectedIndex, 0, offset + index * 0x08);
            Data.ExeData.WriteWord(SpecialEffectUnitBox2.SelectedIndex, 0, offset + index * 0x08 + 0x02);
            Data.ExeData.WriteWord(SpecialEffectUnitBox3.SelectedIndex, 0, offset + index * 0x08 + 0x04);

            int force = SpecialEffectForceBox.SelectedIndex;
            if (force == 0x50) force = 0xFF;
            Data.ExeData.WriteByte(force, 0, offset + index * 0x08 + 0x6);

            Data.ExeData.WriteByte((byte) SpecialEffectValueBox.Value, 0, offset + index * 0x08 + 0x7);
            Data.ExeData.Close();

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
            var list = ConfigUtils.GetSpecialEffectNames().Values.ToList();
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
            Data.ExeData.Open(System.IO.FileAccess.ReadWrite);
            SpecialSkillName.Text = ConfigUtils.GetSpecialSkillName(index);

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

                SpecialSkillUnitBox1.SelectedIndex = Data.ExeData.ReadWord(0, offset + index * 0x10);
                SpecialSkillLevelBox1.Value = Data.ExeData.ReadByte(0, offset + index * 0x10 + 0x02);
                SpecialSkillUnitBox2.SelectedIndex = Data.ExeData.ReadWord(0, offset + index * 0x10 + 0x03);
                SpecialSkillLevelBox2.Value = Data.ExeData.ReadByte(0, offset + index * 0x10 + 0x05);
                SpecialSkillUnitBox3.SelectedIndex = Data.ExeData.ReadWord(0, offset + index * 0x10 + 0x06);
                SpecialSkillLevelBox3.Value = Data.ExeData.ReadByte(0, offset + index * 0x10 + 0x08);
                SpecialSkillUnitBox4.SelectedIndex = Data.ExeData.ReadWord(0, offset + index * 0x10 + 0x09);
                SpecialSkillLevelBox4.Value = Data.ExeData.ReadByte(0, offset + index * 0x10 + 0x0B);
                SpecialSkillUnitBox5.SelectedIndex = Data.ExeData.ReadWord(0, offset + index * 0x10 + 0x0C);
                SpecialSkillLevelBox5.Value = Data.ExeData.ReadByte(0, offset + index * 0x10 + 0x0E);

                SpecialSkillValueBox.Value = Data.ExeData.ReadByte(0, offset + index * 0x10 + 0x0F);
            }
            Data.ExeData.Close();
        }

        private void SaveSpecialSkill(int index)
        {
            var info = Program.CurrentConfig.SpecialSkillNames.Find(x => x.Index == index);

            byte[] result = new byte[0x0E];
            Data.ExeData.Open(System.IO.FileAccess.ReadWrite);
            Data.ExeData.WriteText(SpecialSkillName.Text, info.Offset, 0x0E);

            bool isPhysics = index <= Program.CurrentConfig.Exe.SpecialSkillPhysicsCount;

            if(isPhysics)
            {
                int offset = Program.CurrentConfig.Exe.SpecialSkillOffset;
                Data.ExeData.WriteWord(SpecialSkillUnitBox1.SelectedIndex, 0, offset + index * 0x10);
                Data.ExeData.WriteByte((byte) SpecialSkillLevelBox1.Value, 0, offset + index * 0x10 + 0x02);
                Data.ExeData.WriteWord(SpecialSkillUnitBox2.SelectedIndex, 0, offset + index * 0x10 + 0x03);
                Data.ExeData.WriteByte((byte)SpecialSkillLevelBox2.Value, 0, offset + index * 0x10 + 0x05);
                Data.ExeData.WriteWord(SpecialSkillUnitBox3.SelectedIndex, 0, offset + index * 0x10 + 0x06);
                Data.ExeData.WriteByte((byte)SpecialSkillLevelBox3.Value, 0, offset + index * 0x10 + 0x08);
                Data.ExeData.WriteWord(SpecialSkillUnitBox4.SelectedIndex, 0, offset + index * 0x10 + 0x09);
                Data.ExeData.WriteByte((byte)SpecialSkillLevelBox4.Value, 0, offset + index * 0x10 + 0x0C);
                Data.ExeData.WriteWord(SpecialSkillUnitBox5.SelectedIndex, 0, offset + index * 0x10 + 0x0C);
                Data.ExeData.WriteByte((byte)SpecialSkillLevelBox5.Value, 0, offset + index * 0x10 + 0x0E);

                Data.ExeData.WriteByte((byte)SpecialSkillValueBox.Value, 0, offset + index * 0x10 + 0x0F);
            }
            Data.ExeData.Close();
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

            var temp = ConfigUtils.GetAuxiliaryEffects(Program.FORMATSTRING_KEYVALUEPAIR_HEX2);
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
            if (Data.ExeData.IsLocked) return;

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

            Data.ExeData.Open(System.IO.FileAccess.ReadWrite);
            Data.ExeData.WriteByte((byte)Utils.GetId(AbilityAssistValue.SelectedItem), 0, abilityAssist.Offset);
            if (abilityAssist.SubEdit == 1)
            {
                Data.ExeData.WriteByte(AbilityAssistValue2.Checked ? 2 : 1, AbilityAssistList.SelectedIndex, Program.CurrentConfig.Exe.AbilityAssistPercentOffset);
            }

            Data.ExeData.WriteByte((byte)Utils.GetId(SpecialAtkValue.SelectedItem), 0, specialAtk.Offset);

            if (specialAtk.SubEdit == 1)
            {
                Data.ExeData.WriteByte(SpecialAtkValue2.SelectedIndex, 0, Program.CurrentConfig.Exe.RangeAttack2TypeOffset);
            }
            else if (specialAtk.SubEdit == 2)
            {
                Data.ExeData.WriteByte(SpecialAtkValue2.SelectedIndex, 0, Program.CurrentConfig.Exe.RangeAttack3TypeOffset);
            }
            else if (specialAtk.SubEdit == 3)
            {
                Data.ExeData.WriteByte(SpecialAtkValue3.Checked ? 4 : 1, 0, Program.CurrentConfig.Exe.IgnoreDefenceOffset);
            }

            Data.ExeData.WriteByte((byte)Utils.GetId(AttackAccValue.SelectedItem), 0, attackAcc.Offset);
            Data.ExeData.WriteByte((byte)Utils.GetId(MagicValue.SelectedItem), 0, magic.Offset);
            Data.ExeData.WriteByte((byte)Utils.GetId(StateEffectAttackValue.SelectedItem), 0, stateEffectAttack.Offset);

            if (stateEffectAttack.SubEdit == 1)
            {
                Data.ExeData.WriteByte((byte) StateEffectAttackAccValue1_1.Value, 0, Program.CurrentConfig.Exe.StateEffectAccOffset);
                Data.ExeData.WriteByte((byte)StateEffectAttackAccValue2_1.Value, 1, Program.CurrentConfig.Exe.StateEffectAccOffset);
                Data.ExeData.WriteByte((byte)StateEffectAttackAccValue3_1.Value, 2, Program.CurrentConfig.Exe.StateEffectAccOffset);
                Data.ExeData.WriteByte((byte)StateEffectAttackAccValue4_1.Value, 3, Program.CurrentConfig.Exe.StateEffectAccOffset);
                Data.ExeData.WriteByte((byte)StateEffectAttackAccValue1_2.Value, 4, Program.CurrentConfig.Exe.StateEffectAccOffset);
                Data.ExeData.WriteByte((byte)StateEffectAttackAccValue2_2.Value, 5, Program.CurrentConfig.Exe.StateEffectAccOffset);
                Data.ExeData.WriteByte((byte)StateEffectAttackAccValue3_2.Value, 6, Program.CurrentConfig.Exe.StateEffectAccOffset);
                Data.ExeData.WriteByte((byte)StateEffectAttackAccValue4_2.Value, 7, Program.CurrentConfig.Exe.StateEffectAccOffset);
            }

            Data.ExeData.WriteByte((byte)Utils.GetId(TurnCureValue.SelectedItem), 0, turnCure.Offset);
            Data.ExeData.WriteByte((byte)Utils.GetId(DeburfValue.SelectedItem), 0, deburf.Offset);
            Data.ExeData.WriteByte((byte)Utils.GetId(DecreaseDmgValue.SelectedItem), 0, decreaseDmg.Offset);
            Data.ExeData.WriteByte((byte)Utils.GetId(DefenceValue.SelectedItem), 0, defence.Offset);

            if (defence.SubEdit == 1)
            {
                Data.ExeData.WriteByte((byte) DefenceValue2.Value, 0, Program.CurrentConfig.Exe.GoldDefenceRateOffset);
            }
            else if (defence.SubEdit == 2)
            {
                var code = (byte)Utils.GetId(DefenceValue.SelectedItem);
                Data.ExeData.WriteByte(DefenceValue3.Checked ? code : 0x48, 0, Program.CurrentConfig.Exe.MpDefenceRecoverOffest);
            }

            Data.ExeData.WriteByte((byte)Utils.GetId(TerrainValue.SelectedItem), 0, terrain.Offset);
            Data.ExeData.WriteByte((byte)Utils.GetId(EtcValue.SelectedItem), 0, etc.Offset);

            Data.ExeData.Close();
        }

        private void GetCode(Config.ConfigCodeEffectInfos info, ComboBox codeBox)
        {
            if (Data.ExeData.IsLocked) return;

            var code = Data.ExeData.ReadByte(0, info.Offset);
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
                var isChecked = Data.ExeData.ReadByte(AbilityAssistList.SelectedIndex, Program.CurrentConfig.Exe.AbilityAssistPercentOffset) == 2;
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
            SpecialAtkValue2.Enabled = info.SubEdit == 1 || info.SubEdit == 2;
            if (info.SubEdit == 1)
            {
                SpecialAtkValue2.Enabled = true;
                var value = Data.ExeData.ReadByte(0, Program.CurrentConfig.Exe.RangeAttack2TypeOffset);
                SpecialAtkValue2.SelectedIndex = value;
            }
            else if (info.SubEdit == 2)
            {
                SpecialAtkValue2.Enabled = true;
                var value = Data.ExeData.ReadByte(0, Program.CurrentConfig.Exe.RangeAttack3TypeOffset);
                SpecialAtkValue2.SelectedIndex = value;
            }
            else
            {
                SpecialAtkValue2.Enabled = false;
            }
            
            if (info.SubEdit == 3)
            {
                SpecialAtkValue3.Enabled = true;
                var isChecked = Data.ExeData.ReadByte(0, Program.CurrentConfig.Exe.IgnoreDefenceOffset) == 4;
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
                var value = Data.ExeData.ReadByte(0, Program.CurrentConfig.Exe.GoldDefenceRateOffset);
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
                var isChecked = Data.ExeData.ReadByte(0, Program.CurrentConfig.Exe.MpDefenceRecoverOffest) == code;
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

            Data.ExeData.Open(System.IO.FileAccess.ReadWrite);
            if(info.SubEdit == 1)
            {
                StateEffectAttackAccValue1_1.Value = (byte)Data.ExeData.ReadByte(0, Program.CurrentConfig.Exe.StateEffectAccOffset);
                StateEffectAttackAccValue2_1.Value = (byte)Data.ExeData.ReadByte(1, Program.CurrentConfig.Exe.StateEffectAccOffset);
                StateEffectAttackAccValue3_1.Value = (byte)Data.ExeData.ReadByte(2, Program.CurrentConfig.Exe.StateEffectAccOffset);
                StateEffectAttackAccValue4_1.Value = (byte)Data.ExeData.ReadByte(3, Program.CurrentConfig.Exe.StateEffectAccOffset);
                StateEffectAttackAccValue1_2.Value = (byte)Data.ExeData.ReadByte(4, Program.CurrentConfig.Exe.StateEffectAccOffset);
                StateEffectAttackAccValue2_2.Value = (byte)Data.ExeData.ReadByte(5, Program.CurrentConfig.Exe.StateEffectAccOffset);
                StateEffectAttackAccValue3_2.Value = (byte)Data.ExeData.ReadByte(6, Program.CurrentConfig.Exe.StateEffectAccOffset);
                StateEffectAttackAccValue4_2.Value = (byte)Data.ExeData.ReadByte(7, Program.CurrentConfig.Exe.StateEffectAccOffset);
            }
            Data.ExeData.Close();
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
