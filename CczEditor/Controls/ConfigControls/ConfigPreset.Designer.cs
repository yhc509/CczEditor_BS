namespace CczEditor.Controls.ConfigControls
{
    partial class ConfigPreset
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConfigPreset));
            this.Star61Button = new System.Windows.Forms.Button();
            this.Star62Button = new System.Windows.Forms.Button();
            this.Bs10Button = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.Bs11Button = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.VersionHelperTab = new System.Windows.Forms.TabPage();
            this.lbStatus = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.btnDestPath = new System.Windows.Forms.Button();
            this.btnOriginPath = new System.Windows.Forms.Button();
            this.cbSpecialSkill = new System.Windows.Forms.CheckBox();
            this.cbSpecialEffect = new System.Windows.Forms.CheckBox();
            this.cbAbility = new System.Windows.Forms.CheckBox();
            this.cbSpecialAppearForce = new System.Windows.Forms.CheckBox();
            this.cbTitle = new System.Windows.Forms.CheckBox();
            this.cbLevelExp = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnExecute = new System.Windows.Forms.Button();
            this.cbForceCategoryData = new System.Windows.Forms.CheckBox();
            this.cbForceSyn = new System.Windows.Forms.CheckBox();
            this.cbTerrainSyn = new System.Windows.Forms.CheckBox();
            this.cbShopData = new System.Windows.Forms.CheckBox();
            this.cbReflect = new System.Windows.Forms.CheckBox();
            this.cbLearn = new System.Windows.Forms.CheckBox();
            this.cbAcc = new System.Windows.Forms.CheckBox();
            this.cbDmgValue = new System.Windows.Forms.CheckBox();
            this.cbConditionType = new System.Windows.Forms.CheckBox();
            this.cbAIType = new System.Windows.Forms.CheckBox();
            this.cbDmgType = new System.Windows.Forms.CheckBox();
            this.cbHealType = new System.Windows.Forms.CheckBox();
            this.cbMagicType = new System.Windows.Forms.CheckBox();
            this.cbMagicLv = new System.Windows.Forms.CheckBox();
            this.cbEquip = new System.Windows.Forms.CheckBox();
            this.cbForceName = new System.Windows.Forms.CheckBox();
            this.cbForceCategoryName = new System.Windows.Forms.CheckBox();
            this.cbSpecialCode = new System.Windows.Forms.CheckBox();
            this.cbCutin = new System.Windows.Forms.CheckBox();
            this.cbVoice = new System.Windows.Forms.CheckBox();
            this.cbCost = new System.Windows.Forms.CheckBox();
            this.cbBattleObj = new System.Windows.Forms.CheckBox();
            this.cbPmapObj = new System.Windows.Forms.CheckBox();
            this.cbMagicData = new System.Windows.Forms.CheckBox();
            this.cbForceData = new System.Windows.Forms.CheckBox();
            this.cbItemData = new System.Windows.Forms.CheckBox();
            this.cbUnitData = new System.Windows.Forms.CheckBox();
            this.destVersionBox = new System.Windows.Forms.ComboBox();
            this.originVersionBox = new System.Windows.Forms.ComboBox();
            this.tbDestPath = new System.Windows.Forms.TextBox();
            this.tbOriginPath = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.VersionHelperTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // Star61Button
            // 
            this.Star61Button.Location = new System.Drawing.Point(29, 50);
            this.Star61Button.Name = "Star61Button";
            this.Star61Button.Size = new System.Drawing.Size(155, 42);
            this.Star61Button.TabIndex = 0;
            this.Star61Button.Text = "Star 6.1 프리셋 생성";
            this.Star61Button.UseVisualStyleBackColor = true;
            this.Star61Button.Click += new System.EventHandler(this.Star61Button_Click);
            // 
            // Star62Button
            // 
            this.Star62Button.Location = new System.Drawing.Point(228, 50);
            this.Star62Button.Name = "Star62Button";
            this.Star62Button.Size = new System.Drawing.Size(155, 42);
            this.Star62Button.TabIndex = 1;
            this.Star62Button.Text = "Star 6.2 프리셋 생성";
            this.Star62Button.UseVisualStyleBackColor = true;
            this.Star62Button.Click += new System.EventHandler(this.Star62Button_Click);
            // 
            // Bs10Button
            // 
            this.Bs10Button.Location = new System.Drawing.Point(29, 193);
            this.Bs10Button.Name = "Bs10Button";
            this.Bs10Button.Size = new System.Drawing.Size(155, 42);
            this.Bs10Button.TabIndex = 2;
            this.Bs10Button.Text = "BS 1.0 프리셋 생성";
            this.Bs10Button.UseVisualStyleBackColor = true;
            this.Bs10Button.Click += new System.EventHandler(this.Bs10Button_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.VersionHelperTab);
            this.tabControl1.Location = new System.Drawing.Point(3, 3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(860, 539);
            this.tabControl1.TabIndex = 3;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.Bs11Button);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.Star61Button);
            this.tabPage1.Controls.Add(this.Bs10Button);
            this.tabPage1.Controls.Add(this.Star62Button);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(852, 513);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "프리셋";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // Bs11Button
            // 
            this.Bs11Button.Location = new System.Drawing.Point(228, 193);
            this.Bs11Button.Name = "Bs11Button";
            this.Bs11Button.Size = new System.Drawing.Size(155, 42);
            this.Bs11Button.TabIndex = 5;
            this.Bs11Button.Text = "BS 1.1 프리셋 생성";
            this.Bs11Button.UseVisualStyleBackColor = true;
            this.Bs11Button.Click += new System.EventHandler(this.Bs11Button_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.Location = new System.Drawing.Point(17, 165);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "비상 계열";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(17, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(152, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "신조조전 (Star175) 계열";
            // 
            // VersionHelperTab
            // 
            this.VersionHelperTab.Controls.Add(this.lbStatus);
            this.VersionHelperTab.Controls.Add(this.progressBar1);
            this.VersionHelperTab.Controls.Add(this.btnDestPath);
            this.VersionHelperTab.Controls.Add(this.btnOriginPath);
            this.VersionHelperTab.Controls.Add(this.cbSpecialSkill);
            this.VersionHelperTab.Controls.Add(this.cbSpecialEffect);
            this.VersionHelperTab.Controls.Add(this.cbAbility);
            this.VersionHelperTab.Controls.Add(this.cbSpecialAppearForce);
            this.VersionHelperTab.Controls.Add(this.cbTitle);
            this.VersionHelperTab.Controls.Add(this.cbLevelExp);
            this.VersionHelperTab.Controls.Add(this.label7);
            this.VersionHelperTab.Controls.Add(this.label6);
            this.VersionHelperTab.Controls.Add(this.label5);
            this.VersionHelperTab.Controls.Add(this.btnExecute);
            this.VersionHelperTab.Controls.Add(this.cbForceCategoryData);
            this.VersionHelperTab.Controls.Add(this.cbForceSyn);
            this.VersionHelperTab.Controls.Add(this.cbTerrainSyn);
            this.VersionHelperTab.Controls.Add(this.cbShopData);
            this.VersionHelperTab.Controls.Add(this.cbReflect);
            this.VersionHelperTab.Controls.Add(this.cbLearn);
            this.VersionHelperTab.Controls.Add(this.cbAcc);
            this.VersionHelperTab.Controls.Add(this.cbDmgValue);
            this.VersionHelperTab.Controls.Add(this.cbConditionType);
            this.VersionHelperTab.Controls.Add(this.cbAIType);
            this.VersionHelperTab.Controls.Add(this.cbDmgType);
            this.VersionHelperTab.Controls.Add(this.cbHealType);
            this.VersionHelperTab.Controls.Add(this.cbMagicType);
            this.VersionHelperTab.Controls.Add(this.cbMagicLv);
            this.VersionHelperTab.Controls.Add(this.cbEquip);
            this.VersionHelperTab.Controls.Add(this.cbForceName);
            this.VersionHelperTab.Controls.Add(this.cbForceCategoryName);
            this.VersionHelperTab.Controls.Add(this.cbSpecialCode);
            this.VersionHelperTab.Controls.Add(this.cbCutin);
            this.VersionHelperTab.Controls.Add(this.cbVoice);
            this.VersionHelperTab.Controls.Add(this.cbCost);
            this.VersionHelperTab.Controls.Add(this.cbBattleObj);
            this.VersionHelperTab.Controls.Add(this.cbPmapObj);
            this.VersionHelperTab.Controls.Add(this.cbMagicData);
            this.VersionHelperTab.Controls.Add(this.cbForceData);
            this.VersionHelperTab.Controls.Add(this.cbItemData);
            this.VersionHelperTab.Controls.Add(this.cbUnitData);
            this.VersionHelperTab.Controls.Add(this.destVersionBox);
            this.VersionHelperTab.Controls.Add(this.originVersionBox);
            this.VersionHelperTab.Controls.Add(this.tbDestPath);
            this.VersionHelperTab.Controls.Add(this.tbOriginPath);
            this.VersionHelperTab.Controls.Add(this.label4);
            this.VersionHelperTab.Controls.Add(this.label3);
            this.VersionHelperTab.Location = new System.Drawing.Point(4, 22);
            this.VersionHelperTab.Name = "VersionHelperTab";
            this.VersionHelperTab.Padding = new System.Windows.Forms.Padding(3);
            this.VersionHelperTab.Size = new System.Drawing.Size(852, 513);
            this.VersionHelperTab.TabIndex = 1;
            this.VersionHelperTab.Text = "마이그레이션 헬퍼";
            this.VersionHelperTab.UseVisualStyleBackColor = true;
            // 
            // lbStatus
            // 
            this.lbStatus.AutoSize = true;
            this.lbStatus.Location = new System.Drawing.Point(428, 481);
            this.lbStatus.Name = "lbStatus";
            this.lbStatus.Size = new System.Drawing.Size(0, 12);
            this.lbStatus.TabIndex = 53;
            this.lbStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(22, 455);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(817, 23);
            this.progressBar1.TabIndex = 52;
            // 
            // btnDestPath
            // 
            this.btnDestPath.Location = new System.Drawing.Point(505, 47);
            this.btnDestPath.Name = "btnDestPath";
            this.btnDestPath.Size = new System.Drawing.Size(75, 23);
            this.btnDestPath.TabIndex = 51;
            this.btnDestPath.Text = "경로설정";
            this.btnDestPath.UseVisualStyleBackColor = true;
            this.btnDestPath.Click += new System.EventHandler(this.btnDestPath_Click);
            // 
            // btnOriginPath
            // 
            this.btnOriginPath.Location = new System.Drawing.Point(505, 15);
            this.btnOriginPath.Name = "btnOriginPath";
            this.btnOriginPath.Size = new System.Drawing.Size(75, 23);
            this.btnOriginPath.TabIndex = 50;
            this.btnOriginPath.Text = "경로설정";
            this.btnOriginPath.UseVisualStyleBackColor = true;
            this.btnOriginPath.Click += new System.EventHandler(this.btnOriginPath_Click);
            // 
            // cbSpecialSkill
            // 
            this.cbSpecialSkill.AutoSize = true;
            this.cbSpecialSkill.Enabled = false;
            this.cbSpecialSkill.Location = new System.Drawing.Point(158, 264);
            this.cbSpecialSkill.Name = "cbSpecialSkill";
            this.cbSpecialSkill.Size = new System.Drawing.Size(116, 16);
            this.cbSpecialSkill.TabIndex = 49;
            this.cbSpecialSkill.Text = "인물 필살기 설정";
            this.cbSpecialSkill.UseVisualStyleBackColor = true;
            // 
            // cbSpecialEffect
            // 
            this.cbSpecialEffect.AutoSize = true;
            this.cbSpecialEffect.Enabled = false;
            this.cbSpecialEffect.Location = new System.Drawing.Point(20, 264);
            this.cbSpecialEffect.Name = "cbSpecialEffect";
            this.cbSpecialEffect.Size = new System.Drawing.Size(132, 16);
            this.cbSpecialEffect.TabIndex = 48;
            this.cbSpecialEffect.Text = "인물,병종 코드 설정";
            this.cbSpecialEffect.UseVisualStyleBackColor = true;
            // 
            // cbAbility
            // 
            this.cbAbility.AutoSize = true;
            this.cbAbility.Enabled = false;
            this.cbAbility.Location = new System.Drawing.Point(158, 242);
            this.cbAbility.Name = "cbAbility";
            this.cbAbility.Size = new System.Drawing.Size(104, 16);
            this.cbAbility.TabIndex = 47;
            this.cbAbility.Text = "열전 특화 설정";
            this.cbAbility.UseVisualStyleBackColor = true;
            // 
            // cbSpecialAppearForce
            // 
            this.cbSpecialAppearForce.AutoSize = true;
            this.cbSpecialAppearForce.Enabled = false;
            this.cbSpecialAppearForce.Location = new System.Drawing.Point(20, 193);
            this.cbSpecialAppearForce.Name = "cbSpecialAppearForce";
            this.cbSpecialAppearForce.Size = new System.Drawing.Size(104, 16);
            this.cbSpecialAppearForce.TabIndex = 45;
            this.cbSpecialAppearForce.Text = "병종 특수 설정";
            this.cbSpecialAppearForce.UseVisualStyleBackColor = true;
            // 
            // cbTitle
            // 
            this.cbTitle.AutoSize = true;
            this.cbTitle.Enabled = false;
            this.cbTitle.Location = new System.Drawing.Point(291, 242);
            this.cbTitle.Name = "cbTitle";
            this.cbTitle.Size = new System.Drawing.Size(72, 16);
            this.cbTitle.TabIndex = 44;
            this.cbTitle.Text = "타이틀명";
            this.cbTitle.UseVisualStyleBackColor = true;
            // 
            // cbLevelExp
            // 
            this.cbLevelExp.AutoSize = true;
            this.cbLevelExp.Enabled = false;
            this.cbLevelExp.Location = new System.Drawing.Point(20, 242);
            this.cbLevelExp.Name = "cbLevelExp";
            this.cbLevelExp.Size = new System.Drawing.Size(120, 16);
            this.cbLevelExp.TabIndex = 43;
            this.cbLevelExp.Text = "레벨, 경험치 설정";
            this.cbLevelExp.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label7.ForeColor = System.Drawing.Color.Red;
            this.label7.Location = new System.Drawing.Point(195, 298);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(449, 96);
            this.label7.TabIndex = 42;
            this.label7.Text = resources.GetString("label7.Text");
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(634, 52);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 12);
            this.label6.TabIndex = 41;
            this.label6.Text = "컨피그";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(634, 20);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 40;
            this.label5.Text = "컨피그";
            // 
            // btnExecute
            // 
            this.btnExecute.Enabled = false;
            this.btnExecute.Location = new System.Drawing.Point(350, 407);
            this.btnExecute.Name = "btnExecute";
            this.btnExecute.Size = new System.Drawing.Size(158, 42);
            this.btnExecute.TabIndex = 38;
            this.btnExecute.Text = "실행";
            this.btnExecute.UseVisualStyleBackColor = true;
            this.btnExecute.Click += new System.EventHandler(this.btnExecute_Click);
            // 
            // cbForceCategoryData
            // 
            this.cbForceCategoryData.AutoSize = true;
            this.cbForceCategoryData.Enabled = false;
            this.cbForceCategoryData.Location = new System.Drawing.Point(144, 149);
            this.cbForceCategoryData.Name = "cbForceCategoryData";
            this.cbForceCategoryData.Size = new System.Drawing.Size(116, 16);
            this.cbForceCategoryData.TabIndex = 37;
            this.cbForceCategoryData.Text = "계열 기본 데이터";
            this.cbForceCategoryData.UseVisualStyleBackColor = true;
            // 
            // cbForceSyn
            // 
            this.cbForceSyn.AutoSize = true;
            this.cbForceSyn.Enabled = false;
            this.cbForceSyn.Location = new System.Drawing.Point(332, 171);
            this.cbForceSyn.Name = "cbForceSyn";
            this.cbForceSyn.Size = new System.Drawing.Size(72, 16);
            this.cbForceSyn.TabIndex = 36;
            this.cbForceSyn.Text = "병종상성";
            this.cbForceSyn.UseVisualStyleBackColor = true;
            // 
            // cbTerrainSyn
            // 
            this.cbTerrainSyn.AutoSize = true;
            this.cbTerrainSyn.Enabled = false;
            this.cbTerrainSyn.Location = new System.Drawing.Point(254, 171);
            this.cbTerrainSyn.Name = "cbTerrainSyn";
            this.cbTerrainSyn.Size = new System.Drawing.Size(72, 16);
            this.cbTerrainSyn.TabIndex = 35;
            this.cbTerrainSyn.Text = "지형상성";
            this.cbTerrainSyn.UseVisualStyleBackColor = true;
            // 
            // cbShopData
            // 
            this.cbShopData.AutoSize = true;
            this.cbShopData.Enabled = false;
            this.cbShopData.Location = new System.Drawing.Point(591, 90);
            this.cbShopData.Name = "cbShopData";
            this.cbShopData.Size = new System.Drawing.Size(116, 16);
            this.cbShopData.TabIndex = 34;
            this.cbShopData.Text = "상점 기본 데이터";
            this.cbShopData.UseVisualStyleBackColor = true;
            // 
            // cbReflect
            // 
            this.cbReflect.AutoSize = true;
            this.cbReflect.Enabled = false;
            this.cbReflect.Location = new System.Drawing.Point(684, 193);
            this.cbReflect.Name = "cbReflect";
            this.cbReflect.Size = new System.Drawing.Size(96, 16);
            this.cbReflect.TabIndex = 31;
            this.cbReflect.Text = "책략반사유형";
            this.cbReflect.UseVisualStyleBackColor = true;
            // 
            // cbLearn
            // 
            this.cbLearn.AutoSize = true;
            this.cbLearn.Enabled = false;
            this.cbLearn.Location = new System.Drawing.Point(582, 193);
            this.cbLearn.Name = "cbLearn";
            this.cbLearn.Size = new System.Drawing.Size(96, 16);
            this.cbLearn.TabIndex = 30;
            this.cbLearn.Text = "책략습득유형";
            this.cbLearn.UseVisualStyleBackColor = true;
            // 
            // cbAcc
            // 
            this.cbAcc.AutoSize = true;
            this.cbAcc.Enabled = false;
            this.cbAcc.Location = new System.Drawing.Point(516, 193);
            this.cbAcc.Name = "cbAcc";
            this.cbAcc.Size = new System.Drawing.Size(60, 16);
            this.cbAcc.TabIndex = 29;
            this.cbAcc.Text = "명중률";
            this.cbAcc.UseVisualStyleBackColor = true;
            // 
            // cbDmgValue
            // 
            this.cbDmgValue.AutoSize = true;
            this.cbDmgValue.Enabled = false;
            this.cbDmgValue.Location = new System.Drawing.Point(460, 193);
            this.cbDmgValue.Name = "cbDmgValue";
            this.cbDmgValue.Size = new System.Drawing.Size(48, 16);
            this.cbDmgValue.TabIndex = 28;
            this.cbDmgValue.Text = "위력";
            this.cbDmgValue.UseVisualStyleBackColor = true;
            // 
            // cbConditionType
            // 
            this.cbConditionType.AutoSize = true;
            this.cbConditionType.Enabled = false;
            this.cbConditionType.Location = new System.Drawing.Point(460, 215);
            this.cbConditionType.Name = "cbConditionType";
            this.cbConditionType.Size = new System.Drawing.Size(100, 16);
            this.cbConditionType.TabIndex = 27;
            this.cbConditionType.Text = "사용조건 유형";
            this.cbConditionType.UseVisualStyleBackColor = true;
            // 
            // cbAIType
            // 
            this.cbAIType.AutoSize = true;
            this.cbAIType.Enabled = false;
            this.cbAIType.Location = new System.Drawing.Point(694, 171);
            this.cbAIType.Name = "cbAIType";
            this.cbAIType.Size = new System.Drawing.Size(100, 16);
            this.cbAIType.TabIndex = 26;
            this.cbAIType.Text = "인공지능 유형";
            this.cbAIType.UseVisualStyleBackColor = true;
            // 
            // cbDmgType
            // 
            this.cbDmgType.AutoSize = true;
            this.cbDmgType.Enabled = false;
            this.cbDmgType.Location = new System.Drawing.Point(616, 171);
            this.cbDmgType.Name = "cbDmgType";
            this.cbDmgType.Size = new System.Drawing.Size(72, 16);
            this.cbDmgType.TabIndex = 25;
            this.cbDmgType.Text = "피해유형";
            this.cbDmgType.UseVisualStyleBackColor = true;
            // 
            // cbHealType
            // 
            this.cbHealType.AutoSize = true;
            this.cbHealType.Enabled = false;
            this.cbHealType.Location = new System.Drawing.Point(538, 171);
            this.cbHealType.Name = "cbHealType";
            this.cbHealType.Size = new System.Drawing.Size(72, 16);
            this.cbHealType.TabIndex = 24;
            this.cbHealType.Text = "회복유형";
            this.cbHealType.UseVisualStyleBackColor = true;
            // 
            // cbMagicType
            // 
            this.cbMagicType.AutoSize = true;
            this.cbMagicType.Enabled = false;
            this.cbMagicType.Location = new System.Drawing.Point(460, 171);
            this.cbMagicType.Name = "cbMagicType";
            this.cbMagicType.Size = new System.Drawing.Size(72, 16);
            this.cbMagicType.TabIndex = 23;
            this.cbMagicType.Text = "책략유형";
            this.cbMagicType.UseVisualStyleBackColor = true;
            // 
            // cbMagicLv
            // 
            this.cbMagicLv.AutoSize = true;
            this.cbMagicLv.Enabled = false;
            this.cbMagicLv.Location = new System.Drawing.Point(582, 149);
            this.cbMagicLv.Name = "cbMagicLv";
            this.cbMagicLv.Size = new System.Drawing.Size(96, 16);
            this.cbMagicLv.TabIndex = 22;
            this.cbMagicLv.Text = "책략습득레벨";
            this.cbMagicLv.UseVisualStyleBackColor = true;
            // 
            // cbEquip
            // 
            this.cbEquip.AutoSize = true;
            this.cbEquip.Enabled = false;
            this.cbEquip.Location = new System.Drawing.Point(152, 171);
            this.cbEquip.Name = "cbEquip";
            this.cbEquip.Size = new System.Drawing.Size(96, 16);
            this.cbEquip.TabIndex = 21;
            this.cbEquip.Text = "착용가능장비";
            this.cbEquip.UseVisualStyleBackColor = true;
            // 
            // cbForceName
            // 
            this.cbForceName.AutoSize = true;
            this.cbForceName.Enabled = false;
            this.cbForceName.Location = new System.Drawing.Point(20, 171);
            this.cbForceName.Name = "cbForceName";
            this.cbForceName.Size = new System.Drawing.Size(60, 16);
            this.cbForceName.TabIndex = 20;
            this.cbForceName.Text = "병종명";
            this.cbForceName.UseVisualStyleBackColor = true;
            // 
            // cbForceCategoryName
            // 
            this.cbForceCategoryName.AutoSize = true;
            this.cbForceCategoryName.Enabled = false;
            this.cbForceCategoryName.Location = new System.Drawing.Point(86, 171);
            this.cbForceCategoryName.Name = "cbForceCategoryName";
            this.cbForceCategoryName.Size = new System.Drawing.Size(60, 16);
            this.cbForceCategoryName.TabIndex = 19;
            this.cbForceCategoryName.Text = "계열명";
            this.cbForceCategoryName.UseVisualStyleBackColor = true;
            // 
            // cbSpecialCode
            // 
            this.cbSpecialCode.AutoSize = true;
            this.cbSpecialCode.Enabled = false;
            this.cbSpecialCode.Location = new System.Drawing.Point(460, 112);
            this.cbSpecialCode.Name = "cbSpecialCode";
            this.cbSpecialCode.Size = new System.Drawing.Size(196, 16);
            this.cbSpecialCode.TabIndex = 17;
            this.cbSpecialCode.Text = "보물 특수효과 코드번호 및 표기";
            this.cbSpecialCode.UseVisualStyleBackColor = true;
            // 
            // cbCutin
            // 
            this.cbCutin.AutoSize = true;
            this.cbCutin.Enabled = false;
            this.cbCutin.Location = new System.Drawing.Point(335, 112);
            this.cbCutin.Name = "cbCutin";
            this.cbCutin.Size = new System.Drawing.Size(72, 16);
            this.cbCutin.TabIndex = 16;
            this.cbCutin.Text = "컷인번호";
            this.cbCutin.UseVisualStyleBackColor = true;
            // 
            // cbVoice
            // 
            this.cbVoice.AutoSize = true;
            this.cbVoice.Enabled = false;
            this.cbVoice.Location = new System.Drawing.Point(257, 112);
            this.cbVoice.Name = "cbVoice";
            this.cbVoice.Size = new System.Drawing.Size(72, 16);
            this.cbVoice.TabIndex = 15;
            this.cbVoice.Text = "전장음성";
            this.cbVoice.UseVisualStyleBackColor = true;
            // 
            // cbCost
            // 
            this.cbCost.AutoSize = true;
            this.cbCost.Enabled = false;
            this.cbCost.Location = new System.Drawing.Point(177, 112);
            this.cbCost.Name = "cbCost";
            this.cbCost.Size = new System.Drawing.Size(74, 16);
            this.cbCost.TabIndex = 14;
            this.cbCost.Text = "출진Cost";
            this.cbCost.UseVisualStyleBackColor = true;
            // 
            // cbBattleObj
            // 
            this.cbBattleObj.AutoSize = true;
            this.cbBattleObj.Enabled = false;
            this.cbBattleObj.Location = new System.Drawing.Point(99, 112);
            this.cbBattleObj.Name = "cbBattleObj";
            this.cbBattleObj.Size = new System.Drawing.Size(72, 16);
            this.cbBattleObj.TabIndex = 13;
            this.cbBattleObj.Text = "전투조형";
            this.cbBattleObj.UseVisualStyleBackColor = true;
            // 
            // cbPmapObj
            // 
            this.cbPmapObj.AutoSize = true;
            this.cbPmapObj.Enabled = false;
            this.cbPmapObj.Location = new System.Drawing.Point(21, 112);
            this.cbPmapObj.Name = "cbPmapObj";
            this.cbPmapObj.Size = new System.Drawing.Size(72, 16);
            this.cbPmapObj.TabIndex = 12;
            this.cbPmapObj.Text = "평상조형";
            this.cbPmapObj.UseVisualStyleBackColor = true;
            // 
            // cbMagicData
            // 
            this.cbMagicData.AutoSize = true;
            this.cbMagicData.Enabled = false;
            this.cbMagicData.Location = new System.Drawing.Point(460, 149);
            this.cbMagicData.Name = "cbMagicData";
            this.cbMagicData.Size = new System.Drawing.Size(116, 16);
            this.cbMagicData.TabIndex = 11;
            this.cbMagicData.Text = "책략 기본 데이터";
            this.cbMagicData.UseVisualStyleBackColor = true;
            // 
            // cbForceData
            // 
            this.cbForceData.AutoSize = true;
            this.cbForceData.Enabled = false;
            this.cbForceData.Location = new System.Drawing.Point(20, 149);
            this.cbForceData.Name = "cbForceData";
            this.cbForceData.Size = new System.Drawing.Size(116, 16);
            this.cbForceData.TabIndex = 10;
            this.cbForceData.Text = "병종 기본 데이터";
            this.cbForceData.UseVisualStyleBackColor = true;
            // 
            // cbItemData
            // 
            this.cbItemData.AutoSize = true;
            this.cbItemData.Enabled = false;
            this.cbItemData.Location = new System.Drawing.Point(460, 90);
            this.cbItemData.Name = "cbItemData";
            this.cbItemData.Size = new System.Drawing.Size(116, 16);
            this.cbItemData.TabIndex = 9;
            this.cbItemData.Text = "물품 기본 데이터";
            this.cbItemData.UseVisualStyleBackColor = true;
            // 
            // cbUnitData
            // 
            this.cbUnitData.AutoSize = true;
            this.cbUnitData.Enabled = false;
            this.cbUnitData.Location = new System.Drawing.Point(22, 90);
            this.cbUnitData.Name = "cbUnitData";
            this.cbUnitData.Size = new System.Drawing.Size(116, 16);
            this.cbUnitData.TabIndex = 8;
            this.cbUnitData.Text = "인물 기본 데이터";
            this.cbUnitData.UseVisualStyleBackColor = true;
            // 
            // destVersionBox
            // 
            this.destVersionBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.destVersionBox.FormattingEnabled = true;
            this.destVersionBox.Items.AddRange(new object[] {
            "Star 6.1",
            "Star 6.2 ",
            "BS 1.0",
            "BS 1.1"});
            this.destVersionBox.Location = new System.Drawing.Point(681, 49);
            this.destVersionBox.Name = "destVersionBox";
            this.destVersionBox.Size = new System.Drawing.Size(121, 20);
            this.destVersionBox.TabIndex = 7;
            this.destVersionBox.SelectedIndexChanged += new System.EventHandler(this.destVersionBox_SelectedIndexChanged);
            // 
            // originVersionBox
            // 
            this.originVersionBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.originVersionBox.FormattingEnabled = true;
            this.originVersionBox.Items.AddRange(new object[] {
            "Star 6.1",
            "Star 6.2 ",
            "BS 1.0",
            "BS 1.1"});
            this.originVersionBox.Location = new System.Drawing.Point(681, 17);
            this.originVersionBox.Name = "originVersionBox";
            this.originVersionBox.Size = new System.Drawing.Size(121, 20);
            this.originVersionBox.TabIndex = 6;
            this.originVersionBox.SelectedIndexChanged += new System.EventHandler(this.originVersionBox_SelectedIndexChanged);
            // 
            // tbDestPath
            // 
            this.tbDestPath.Enabled = false;
            this.tbDestPath.Location = new System.Drawing.Point(130, 49);
            this.tbDestPath.Name = "tbDestPath";
            this.tbDestPath.Size = new System.Drawing.Size(369, 21);
            this.tbDestPath.TabIndex = 3;
            // 
            // tbOriginPath
            // 
            this.tbOriginPath.Enabled = false;
            this.tbOriginPath.Location = new System.Drawing.Point(130, 17);
            this.tbOriginPath.Name = "tbOriginPath";
            this.tbOriginPath.Size = new System.Drawing.Size(369, 21);
            this.tbOriginPath.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(22, 52);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 12);
            this.label4.TabIndex = 1;
            this.label4.Text = "신규 버전 경로";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "이전 버전 경로";
            // 
            // ConfigPreset
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl1);
            this.Name = "ConfigPreset";
            this.Size = new System.Drawing.Size(866, 545);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.VersionHelperTab.ResumeLayout(false);
            this.VersionHelperTab.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Star61Button;
        private System.Windows.Forms.Button Star62Button;
        private System.Windows.Forms.Button Bs10Button;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Bs11Button;
        private System.Windows.Forms.TabPage VersionHelperTab;
        private System.Windows.Forms.CheckBox cbUnitData;
        private System.Windows.Forms.ComboBox destVersionBox;
        private System.Windows.Forms.ComboBox originVersionBox;
        private System.Windows.Forms.TextBox tbDestPath;
        private System.Windows.Forms.TextBox tbOriginPath;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox cbSpecialCode;
        private System.Windows.Forms.CheckBox cbCutin;
        private System.Windows.Forms.CheckBox cbVoice;
        private System.Windows.Forms.CheckBox cbCost;
        private System.Windows.Forms.CheckBox cbBattleObj;
        private System.Windows.Forms.CheckBox cbPmapObj;
        private System.Windows.Forms.CheckBox cbMagicData;
        private System.Windows.Forms.CheckBox cbForceData;
        private System.Windows.Forms.CheckBox cbItemData;
        private System.Windows.Forms.CheckBox cbForceName;
        private System.Windows.Forms.CheckBox cbForceCategoryName;
        private System.Windows.Forms.CheckBox cbEquip;
        private System.Windows.Forms.CheckBox cbMagicLv;
        private System.Windows.Forms.CheckBox cbMagicType;
        private System.Windows.Forms.CheckBox cbHealType;
        private System.Windows.Forms.CheckBox cbDmgType;
        private System.Windows.Forms.CheckBox cbAIType;
        private System.Windows.Forms.CheckBox cbConditionType;
        private System.Windows.Forms.CheckBox cbAcc;
        private System.Windows.Forms.CheckBox cbDmgValue;
        private System.Windows.Forms.CheckBox cbLearn;
        private System.Windows.Forms.CheckBox cbReflect;
        private System.Windows.Forms.CheckBox cbForceSyn;
        private System.Windows.Forms.CheckBox cbTerrainSyn;
        private System.Windows.Forms.CheckBox cbShopData;
        private System.Windows.Forms.CheckBox cbForceCategoryData;
        private System.Windows.Forms.Button btnExecute;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox cbSpecialAppearForce;
        private System.Windows.Forms.CheckBox cbTitle;
        private System.Windows.Forms.CheckBox cbLevelExp;
        private System.Windows.Forms.CheckBox cbSpecialSkill;
        private System.Windows.Forms.CheckBox cbSpecialEffect;
        private System.Windows.Forms.CheckBox cbAbility;
        private System.Windows.Forms.Button btnDestPath;
        private System.Windows.Forms.Button btnOriginPath;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label lbStatus;
    }
}
