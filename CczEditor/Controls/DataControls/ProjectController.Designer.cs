﻿namespace CczEditor.Controls.DataControls
{
    partial class ProjectController
    {
        /// <summary> 
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 구성 요소 디자이너에서 생성한 코드

        /// <summary> 
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox14 = new System.Windows.Forms.GroupBox();
            this.TitleSaveButton = new System.Windows.Forms.Button();
            this.TitleLengthText = new System.Windows.Forms.Label();
            this.TitleTextBox = new System.Windows.Forms.TextBox();
            this.groupBox15 = new System.Windows.Forms.GroupBox();
            this.SecondEquipStartLevel = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.LevelSaveButton = new System.Windows.Forms.Button();
            this.SpecialEquipStLevel = new System.Windows.Forms.NumericUpDown();
            this.label34 = new System.Windows.Forms.Label();
            this.NormalEquipStLevel = new System.Windows.Forms.NumericUpDown();
            this.label33 = new System.Windows.Forms.Label();
            this.EnemyUnitExploit = new System.Windows.Forms.NumericUpDown();
            this.NewUnitExploit = new System.Windows.Forms.NumericUpDown();
            this.label31 = new System.Windows.Forms.Label();
            this.label32 = new System.Windows.Forms.Label();
            this.SpecialEquipMaxLevel = new System.Windows.Forms.NumericUpDown();
            this.SpecialEquipExp = new System.Windows.Forms.NumericUpDown();
            this.NormalEquipMaxLevel = new System.Windows.Forms.NumericUpDown();
            this.NormalEquipExp = new System.Windows.Forms.NumericUpDown();
            this.MaxUnitExp = new System.Windows.Forms.NumericUpDown();
            this.MaxUnitLevel = new System.Windows.Forms.NumericUpDown();
            this.ClassUpLevel2 = new System.Windows.Forms.NumericUpDown();
            this.ClassUpLevel1 = new System.Windows.Forms.NumericUpDown();
            this.label29 = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.groupBox18 = new System.Windows.Forms.GroupBox();
            this.AbilitySave = new System.Windows.Forms.Button();
            this.EvenType = new System.Windows.Forms.RadioButton();
            this.OddType = new System.Windows.Forms.RadioButton();
            this.AbilityGradeListView = new System.Windows.Forms.ListView();
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox14.SuspendLayout();
            this.groupBox15.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SecondEquipStartLevel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SpecialEquipStLevel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NormalEquipStLevel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EnemyUnitExploit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NewUnitExploit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SpecialEquipMaxLevel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SpecialEquipExp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NormalEquipMaxLevel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NormalEquipExp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MaxUnitExp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MaxUnitLevel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ClassUpLevel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ClassUpLevel1)).BeginInit();
            this.groupBox18.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox14
            // 
            this.groupBox14.Controls.Add(this.TitleSaveButton);
            this.groupBox14.Controls.Add(this.TitleLengthText);
            this.groupBox14.Controls.Add(this.TitleTextBox);
            this.groupBox14.Location = new System.Drawing.Point(3, 3);
            this.groupBox14.Name = "groupBox14";
            this.groupBox14.Size = new System.Drawing.Size(358, 87);
            this.groupBox14.TabIndex = 4;
            this.groupBox14.TabStop = false;
            this.groupBox14.Text = "모드 제목 설정";
            // 
            // TitleSaveButton
            // 
            this.TitleSaveButton.Location = new System.Drawing.Point(277, 26);
            this.TitleSaveButton.Name = "TitleSaveButton";
            this.TitleSaveButton.Size = new System.Drawing.Size(75, 23);
            this.TitleSaveButton.TabIndex = 2;
            this.TitleSaveButton.Text = "저장";
            this.TitleSaveButton.UseVisualStyleBackColor = true;
            this.TitleSaveButton.Click += new System.EventHandler(this.TitleSaveButton_Click);
            // 
            // TitleLengthText
            // 
            this.TitleLengthText.AutoSize = true;
            this.TitleLengthText.Location = new System.Drawing.Point(208, 60);
            this.TitleLengthText.Name = "TitleLengthText";
            this.TitleLengthText.Size = new System.Drawing.Size(59, 12);
            this.TitleLengthText.TabIndex = 1;
            this.TitleLengthText.Text = "0 / 0 byte";
            // 
            // TitleTextBox
            // 
            this.TitleTextBox.Location = new System.Drawing.Point(11, 26);
            this.TitleTextBox.Name = "TitleTextBox";
            this.TitleTextBox.Size = new System.Drawing.Size(256, 21);
            this.TitleTextBox.TabIndex = 0;
            this.TitleTextBox.TextChanged += new System.EventHandler(this.TitleTextBox_TextChanged);
            // 
            // groupBox15
            // 
            this.groupBox15.Controls.Add(this.SecondEquipStartLevel);
            this.groupBox15.Controls.Add(this.label1);
            this.groupBox15.Controls.Add(this.LevelSaveButton);
            this.groupBox15.Controls.Add(this.SpecialEquipStLevel);
            this.groupBox15.Controls.Add(this.label34);
            this.groupBox15.Controls.Add(this.NormalEquipStLevel);
            this.groupBox15.Controls.Add(this.label33);
            this.groupBox15.Controls.Add(this.EnemyUnitExploit);
            this.groupBox15.Controls.Add(this.NewUnitExploit);
            this.groupBox15.Controls.Add(this.label31);
            this.groupBox15.Controls.Add(this.label32);
            this.groupBox15.Controls.Add(this.SpecialEquipMaxLevel);
            this.groupBox15.Controls.Add(this.SpecialEquipExp);
            this.groupBox15.Controls.Add(this.NormalEquipMaxLevel);
            this.groupBox15.Controls.Add(this.NormalEquipExp);
            this.groupBox15.Controls.Add(this.MaxUnitExp);
            this.groupBox15.Controls.Add(this.MaxUnitLevel);
            this.groupBox15.Controls.Add(this.ClassUpLevel2);
            this.groupBox15.Controls.Add(this.ClassUpLevel1);
            this.groupBox15.Controls.Add(this.label29);
            this.groupBox15.Controls.Add(this.label30);
            this.groupBox15.Controls.Add(this.label28);
            this.groupBox15.Controls.Add(this.label27);
            this.groupBox15.Controls.Add(this.label26);
            this.groupBox15.Controls.Add(this.label25);
            this.groupBox15.Controls.Add(this.label24);
            this.groupBox15.Controls.Add(this.label20);
            this.groupBox15.Location = new System.Drawing.Point(146, 96);
            this.groupBox15.Name = "groupBox15";
            this.groupBox15.Size = new System.Drawing.Size(733, 230);
            this.groupBox15.TabIndex = 6;
            this.groupBox15.TabStop = false;
            this.groupBox15.Text = "레벨 / 경험치 설정";
            // 
            // SecondEquipStartLevel
            // 
            this.SecondEquipStartLevel.Location = new System.Drawing.Point(572, 125);
            this.SecondEquipStartLevel.Name = "SecondEquipStartLevel";
            this.SecondEquipStartLevel.ReadOnly = true;
            this.SecondEquipStartLevel.Size = new System.Drawing.Size(68, 21);
            this.SecondEquipStartLevel.TabIndex = 26;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(444, 131);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 12);
            this.label1.TabIndex = 25;
            this.label1.Text = "중급 장비 등장 레벨";
            // 
            // LevelSaveButton
            // 
            this.LevelSaveButton.Location = new System.Drawing.Point(639, 195);
            this.LevelSaveButton.Name = "LevelSaveButton";
            this.LevelSaveButton.Size = new System.Drawing.Size(75, 23);
            this.LevelSaveButton.TabIndex = 24;
            this.LevelSaveButton.Text = "저장";
            this.LevelSaveButton.UseVisualStyleBackColor = true;
            this.LevelSaveButton.Click += new System.EventHandler(this.LevelSaveButton_Click);
            // 
            // SpecialEquipStLevel
            // 
            this.SpecialEquipStLevel.Location = new System.Drawing.Point(356, 159);
            this.SpecialEquipStLevel.Name = "SpecialEquipStLevel";
            this.SpecialEquipStLevel.Size = new System.Drawing.Size(68, 21);
            this.SpecialEquipStLevel.TabIndex = 23;
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Location = new System.Drawing.Point(228, 165);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(113, 12);
            this.label34.TabIndex = 22;
            this.label34.Text = "특수 장비 기준 레벨";
            // 
            // NormalEquipStLevel
            // 
            this.NormalEquipStLevel.Location = new System.Drawing.Point(356, 125);
            this.NormalEquipStLevel.Name = "NormalEquipStLevel";
            this.NormalEquipStLevel.Size = new System.Drawing.Size(68, 21);
            this.NormalEquipStLevel.TabIndex = 21;
            this.NormalEquipStLevel.ValueChanged += new System.EventHandler(this.NormalEquipStLevel_ValueChanged);
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Location = new System.Drawing.Point(228, 131);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(113, 12);
            this.label33.TabIndex = 20;
            this.label33.Text = "일반 장비 기준 레벨";
            // 
            // EnemyUnitExploit
            // 
            this.EnemyUnitExploit.Location = new System.Drawing.Point(356, 195);
            this.EnemyUnitExploit.Name = "EnemyUnitExploit";
            this.EnemyUnitExploit.Size = new System.Drawing.Size(68, 21);
            this.EnemyUnitExploit.TabIndex = 19;
            // 
            // NewUnitExploit
            // 
            this.NewUnitExploit.Location = new System.Drawing.Point(147, 195);
            this.NewUnitExploit.Name = "NewUnitExploit";
            this.NewUnitExploit.Size = new System.Drawing.Size(68, 21);
            this.NewUnitExploit.TabIndex = 18;
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Location = new System.Drawing.Point(256, 200);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(85, 12);
            this.label31.TabIndex = 17;
            this.label31.Text = "적군 무장 공훈";
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Location = new System.Drawing.Point(47, 200);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(85, 12);
            this.label32.TabIndex = 16;
            this.label32.Text = "신규 무장 공훈";
            // 
            // SpecialEquipMaxLevel
            // 
            this.SpecialEquipMaxLevel.Location = new System.Drawing.Point(147, 158);
            this.SpecialEquipMaxLevel.Name = "SpecialEquipMaxLevel";
            this.SpecialEquipMaxLevel.Size = new System.Drawing.Size(68, 21);
            this.SpecialEquipMaxLevel.TabIndex = 15;
            // 
            // SpecialEquipExp
            // 
            this.SpecialEquipExp.Location = new System.Drawing.Point(356, 91);
            this.SpecialEquipExp.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.SpecialEquipExp.Name = "SpecialEquipExp";
            this.SpecialEquipExp.Size = new System.Drawing.Size(68, 21);
            this.SpecialEquipExp.TabIndex = 14;
            // 
            // NormalEquipMaxLevel
            // 
            this.NormalEquipMaxLevel.Location = new System.Drawing.Point(147, 125);
            this.NormalEquipMaxLevel.Name = "NormalEquipMaxLevel";
            this.NormalEquipMaxLevel.Size = new System.Drawing.Size(68, 21);
            this.NormalEquipMaxLevel.TabIndex = 13;
            this.NormalEquipMaxLevel.ValueChanged += new System.EventHandler(this.NormalEquipMaxLevel_ValueChanged);
            // 
            // NormalEquipExp
            // 
            this.NormalEquipExp.Location = new System.Drawing.Point(147, 91);
            this.NormalEquipExp.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.NormalEquipExp.Name = "NormalEquipExp";
            this.NormalEquipExp.Size = new System.Drawing.Size(68, 21);
            this.NormalEquipExp.TabIndex = 12;
            // 
            // MaxUnitExp
            // 
            this.MaxUnitExp.Location = new System.Drawing.Point(356, 58);
            this.MaxUnitExp.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.MaxUnitExp.Name = "MaxUnitExp";
            this.MaxUnitExp.Size = new System.Drawing.Size(68, 21);
            this.MaxUnitExp.TabIndex = 11;
            // 
            // MaxUnitLevel
            // 
            this.MaxUnitLevel.Location = new System.Drawing.Point(147, 58);
            this.MaxUnitLevel.Maximum = new decimal(new int[] {
            127,
            0,
            0,
            0});
            this.MaxUnitLevel.Name = "MaxUnitLevel";
            this.MaxUnitLevel.Size = new System.Drawing.Size(68, 21);
            this.MaxUnitLevel.TabIndex = 10;
            // 
            // ClassUpLevel2
            // 
            this.ClassUpLevel2.Location = new System.Drawing.Point(261, 26);
            this.ClassUpLevel2.Maximum = new decimal(new int[] {
            126,
            0,
            0,
            0});
            this.ClassUpLevel2.Name = "ClassUpLevel2";
            this.ClassUpLevel2.ReadOnly = true;
            this.ClassUpLevel2.Size = new System.Drawing.Size(68, 21);
            this.ClassUpLevel2.TabIndex = 9;
            // 
            // ClassUpLevel1
            // 
            this.ClassUpLevel1.Location = new System.Drawing.Point(147, 26);
            this.ClassUpLevel1.Maximum = new decimal(new int[] {
            63,
            0,
            0,
            0});
            this.ClassUpLevel1.Name = "ClassUpLevel1";
            this.ClassUpLevel1.Size = new System.Drawing.Size(68, 21);
            this.ClassUpLevel1.TabIndex = 8;
            this.ClassUpLevel1.ValueChanged += new System.EventHandler(this.ClassUpLevel1_ValueChanged);
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(19, 165);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(113, 12);
            this.label29.TabIndex = 7;
            this.label29.Text = "특수 장비 최대 레벨";
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(244, 98);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(97, 12);
            this.label30.TabIndex = 6;
            this.label30.Text = "특수 장비 경험치";
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(19, 132);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(113, 12);
            this.label28.TabIndex = 5;
            this.label28.Text = "일반 장비 최대 레벨";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(35, 98);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(97, 12);
            this.label27.TabIndex = 4;
            this.label27.Text = "일반 장비 경험치";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(272, 64);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(69, 12);
            this.label26.TabIndex = 3;
            this.label26.Text = "필요 경험치";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(81, 64);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(57, 12);
            this.label25.TabIndex = 2;
            this.label25.Text = "최대 레벨";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(228, 31);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(23, 12);
            this.label24.TabIndex = 1;
            this.label24.Text = "2차";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(59, 31);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(79, 12);
            this.label20.TabIndex = 0;
            this.label20.Text = "전직 레벨 1차";
            // 
            // groupBox18
            // 
            this.groupBox18.Controls.Add(this.AbilitySave);
            this.groupBox18.Controls.Add(this.EvenType);
            this.groupBox18.Controls.Add(this.OddType);
            this.groupBox18.Controls.Add(this.AbilityGradeListView);
            this.groupBox18.Location = new System.Drawing.Point(13, 96);
            this.groupBox18.Name = "groupBox18";
            this.groupBox18.Size = new System.Drawing.Size(127, 330);
            this.groupBox18.TabIndex = 5;
            this.groupBox18.TabStop = false;
            this.groupBox18.Text = "열전 특화 설정";
            // 
            // AbilitySave
            // 
            this.AbilitySave.Location = new System.Drawing.Point(6, 297);
            this.AbilitySave.Name = "AbilitySave";
            this.AbilitySave.Size = new System.Drawing.Size(112, 23);
            this.AbilitySave.TabIndex = 1;
            this.AbilitySave.Text = "저장";
            this.AbilitySave.UseVisualStyleBackColor = true;
            this.AbilitySave.Click += new System.EventHandler(this.AbilitySave_Click);
            // 
            // EvenType
            // 
            this.EvenType.AutoSize = true;
            this.EvenType.Location = new System.Drawing.Point(6, 275);
            this.EvenType.Name = "EvenType";
            this.EvenType.Size = new System.Drawing.Size(75, 16);
            this.EvenType.TabIndex = 10;
            this.EvenType.TabStop = true;
            this.EvenType.Text = "짝수 열전";
            this.EvenType.UseVisualStyleBackColor = true;
            // 
            // OddType
            // 
            this.OddType.AutoSize = true;
            this.OddType.Location = new System.Drawing.Point(6, 253);
            this.OddType.Name = "OddType";
            this.OddType.Size = new System.Drawing.Size(75, 16);
            this.OddType.TabIndex = 1;
            this.OddType.TabStop = true;
            this.OddType.Text = "홀수 열전";
            this.OddType.UseVisualStyleBackColor = true;
            this.OddType.CheckedChanged += new System.EventHandler(this.OddType_CheckedChanged);
            // 
            // AbilityGradeListView
            // 
            this.AbilityGradeListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader3,
            this.columnHeader4});
            this.AbilityGradeListView.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.AbilityGradeListView.FullRowSelect = true;
            this.AbilityGradeListView.GridLines = true;
            this.AbilityGradeListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.AbilityGradeListView.LabelEdit = true;
            this.AbilityGradeListView.LabelWrap = false;
            this.AbilityGradeListView.Location = new System.Drawing.Point(6, 20);
            this.AbilityGradeListView.MultiSelect = false;
            this.AbilityGradeListView.Name = "AbilityGradeListView";
            this.AbilityGradeListView.ShowGroups = false;
            this.AbilityGradeListView.Size = new System.Drawing.Size(112, 227);
            this.AbilityGradeListView.TabIndex = 9;
            this.AbilityGradeListView.UseCompatibleStateImageBehavior = false;
            this.AbilityGradeListView.View = System.Windows.Forms.View.Details;
            this.AbilityGradeListView.AfterLabelEdit += new System.Windows.Forms.LabelEditEventHandler(this.AbilityGradeListView_AfterLabelEdit);
            this.AbilityGradeListView.ItemActivate += new System.EventHandler(this.AbilityGradeListView_ItemActivate);
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "수치";
            this.columnHeader3.Width = 50;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "등급";
            this.columnHeader4.Width = 50;
            // 
            // ProjectController
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox15);
            this.Controls.Add(this.groupBox18);
            this.Controls.Add(this.groupBox14);
            this.Name = "ProjectController";
            this.Size = new System.Drawing.Size(892, 581);
            this.Load += new System.EventHandler(this.ProjectController_Load);
            this.groupBox14.ResumeLayout(false);
            this.groupBox14.PerformLayout();
            this.groupBox15.ResumeLayout(false);
            this.groupBox15.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SecondEquipStartLevel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SpecialEquipStLevel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NormalEquipStLevel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EnemyUnitExploit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NewUnitExploit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SpecialEquipMaxLevel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SpecialEquipExp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NormalEquipMaxLevel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NormalEquipExp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MaxUnitExp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MaxUnitLevel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ClassUpLevel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ClassUpLevel1)).EndInit();
            this.groupBox18.ResumeLayout(false);
            this.groupBox18.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox14;
        private System.Windows.Forms.Button TitleSaveButton;
        private System.Windows.Forms.Label TitleLengthText;
        private System.Windows.Forms.TextBox TitleTextBox;
        private System.Windows.Forms.GroupBox groupBox15;
        private System.Windows.Forms.NumericUpDown SpecialEquipStLevel;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.NumericUpDown NormalEquipStLevel;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.NumericUpDown EnemyUnitExploit;
        private System.Windows.Forms.NumericUpDown NewUnitExploit;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.NumericUpDown SpecialEquipMaxLevel;
        private System.Windows.Forms.NumericUpDown SpecialEquipExp;
        private System.Windows.Forms.NumericUpDown NormalEquipMaxLevel;
        private System.Windows.Forms.NumericUpDown NormalEquipExp;
        private System.Windows.Forms.NumericUpDown MaxUnitExp;
        private System.Windows.Forms.NumericUpDown MaxUnitLevel;
        private System.Windows.Forms.NumericUpDown ClassUpLevel2;
        private System.Windows.Forms.NumericUpDown ClassUpLevel1;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.GroupBox groupBox18;
        private System.Windows.Forms.Button AbilitySave;
        private System.Windows.Forms.RadioButton EvenType;
        private System.Windows.Forms.RadioButton OddType;
        private System.Windows.Forms.ListView AbilityGradeListView;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.Button LevelSaveButton;
        private System.Windows.Forms.NumericUpDown SecondEquipStartLevel;
        private System.Windows.Forms.Label label1;
    }
}
