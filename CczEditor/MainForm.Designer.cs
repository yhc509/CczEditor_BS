namespace CczEditor
{
	partial class MainForm
	{
		/// <summary>
		/// 필요변수
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// 자원초기화
		/// </summary>
		/// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows 윈도우 생성코드

		/// <summary>
		/// 设计器支持所需的方法 - 不要
		/// 使用代码编辑器修改此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.msMainMenu = new System.Windows.Forms.MenuStrip();
            this.tsmiMainMenu_File = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiMainMenu_File_LoadFolder = new System.Windows.Forms.ToolStripMenuItem();
            this.tss_File_1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiMainMenu_File_LoadData = new System.Windows.Forms.ToolStripMenuItem();
            this.tss_File_2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiMainMenu_File_ExitApplication = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiMainMenu_Data = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiMainMenu_Data_Units = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiMainMenu_Data_Items = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiMainMenu_Data_Store = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiMainMenu_Data_Force = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiMainMenu_Data_Terrain = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiMainMenu_Data_Magic = new System.Windows.Forms.ToolStripMenuItem();
            this.ExeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.프로젝트편집ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.코드입력기ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiMainMenu_Imsg = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiMainMenu_Imsg_Units = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiMainMenu_Imsg_Units_Original = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiMainMenu_Imsg_Units_Extension = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiMainMenu_Imsg_Retreat = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiMainMenu_Imsg_Critical = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiMainMenu_Imsg_Staff = new System.Windows.Forms.ToolStripMenuItem();
            this.특수편집ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.세이브편집ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiMainMenu_Config = new System.Windows.Forms.ToolStripMenuItem();
            this.tscbMainMenu_Config_Selector = new System.Windows.Forms.ToolStripComboBox();
            this.tsmiMainMenu_Config_Editor = new System.Windows.Forms.ToolStripMenuItem();
            this.tss_Config_1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiMainMenu_Config_LoadAll = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiMainMenu_Config_SaveAll = new System.Windows.Forms.ToolStripMenuItem();
            this.테스트용ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiMainMenu_About = new System.Windows.Forms.ToolStripMenuItem();
            this.pMainContainer = new System.Windows.Forms.Panel();
            this.msMainMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // msMainMenu
            // 
            this.msMainMenu.BackColor = System.Drawing.SystemColors.ControlLight;
            this.msMainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiMainMenu_File,
            this.tsmiMainMenu_Data,
            this.tsmiMainMenu_Imsg,
            this.특수편집ToolStripMenuItem,
            this.세이브편집ToolStripMenuItem,
            this.tsmiMainMenu_Config,
            this.tsmiMainMenu_About});
            this.msMainMenu.Location = new System.Drawing.Point(0, 0);
            this.msMainMenu.Name = "msMainMenu";
            this.msMainMenu.Padding = new System.Windows.Forms.Padding(7, 2, 0, 2);
            this.msMainMenu.Size = new System.Drawing.Size(893, 24);
            this.msMainMenu.TabIndex = 0;
            this.msMainMenu.Text = "程序主菜单";
            // 
            // tsmiMainMenu_File
            // 
            this.tsmiMainMenu_File.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiMainMenu_File_LoadFolder,
            this.tss_File_1,
            this.tsmiMainMenu_File_LoadData,
            this.tss_File_2,
            this.tsmiMainMenu_File_ExitApplication});
            this.tsmiMainMenu_File.Name = "tsmiMainMenu_File";
            this.tsmiMainMenu_File.Size = new System.Drawing.Size(61, 20);
            this.tsmiMainMenu_File.Text = "파일 (&F)";
            // 
            // tsmiMainMenu_File_LoadFolder
            // 
            this.tsmiMainMenu_File_LoadFolder.Name = "tsmiMainMenu_File_LoadFolder";
            this.tsmiMainMenu_File_LoadFolder.Size = new System.Drawing.Size(169, 22);
            this.tsmiMainMenu_File_LoadFolder.Text = "경로 설정 (&D)";
            this.tsmiMainMenu_File_LoadFolder.Click += new System.EventHandler(this.tsmiMainMenu_File_LoadFolder_Click);
            // 
            // tss_File_1
            // 
            this.tss_File_1.Name = "tss_File_1";
            this.tss_File_1.Size = new System.Drawing.Size(166, 6);
            // 
            // tsmiMainMenu_File_LoadData
            // 
            this.tsmiMainMenu_File_LoadData.Enabled = false;
            this.tsmiMainMenu_File_LoadData.Name = "tsmiMainMenu_File_LoadData";
            this.tsmiMainMenu_File_LoadData.Size = new System.Drawing.Size(169, 22);
            this.tsmiMainMenu_File_LoadData.Text = "프로젝트 로드";
            this.tsmiMainMenu_File_LoadData.Click += new System.EventHandler(this.tsmiMainMenu_File_LoadData_Click);
            // 
            // tss_File_2
            // 
            this.tss_File_2.Name = "tss_File_2";
            this.tss_File_2.Size = new System.Drawing.Size(166, 6);
            // 
            // tsmiMainMenu_File_ExitApplication
            // 
            this.tsmiMainMenu_File_ExitApplication.Name = "tsmiMainMenu_File_ExitApplication";
            this.tsmiMainMenu_File_ExitApplication.Size = new System.Drawing.Size(169, 22);
            this.tsmiMainMenu_File_ExitApplication.Text = "프로그램 종료 (&X)";
            this.tsmiMainMenu_File_ExitApplication.Click += new System.EventHandler(this.tsmiMainMenu_File_ExitApplication_Click);
            // 
            // tsmiMainMenu_Data
            // 
            this.tsmiMainMenu_Data.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiMainMenu_Data_Units,
            this.tsmiMainMenu_Data_Items,
            this.tsmiMainMenu_Data_Store,
            this.tsmiMainMenu_Data_Force,
            this.tsmiMainMenu_Data_Terrain,
            this.tsmiMainMenu_Data_Magic,
            this.ExeToolStripMenuItem,
            this.프로젝트편집ToolStripMenuItem,
            this.코드입력기ToolStripMenuItem});
            this.tsmiMainMenu_Data.Name = "tsmiMainMenu_Data";
            this.tsmiMainMenu_Data.Size = new System.Drawing.Size(104, 20);
            this.tsmiMainMenu_Data.Text = "데이터 편집 (&D)";
            this.tsmiMainMenu_Data.Visible = false;
            // 
            // tsmiMainMenu_Data_Units
            // 
            this.tsmiMainMenu_Data_Units.Name = "tsmiMainMenu_Data_Units";
            this.tsmiMainMenu_Data_Units.Size = new System.Drawing.Size(169, 22);
            this.tsmiMainMenu_Data_Units.Text = "인물 편집 (&U)";
            this.tsmiMainMenu_Data_Units.Click += new System.EventHandler(this.tsmiMainMenu_Data_Units_Click);
            // 
            // tsmiMainMenu_Data_Items
            // 
            this.tsmiMainMenu_Data_Items.Name = "tsmiMainMenu_Data_Items";
            this.tsmiMainMenu_Data_Items.Size = new System.Drawing.Size(169, 22);
            this.tsmiMainMenu_Data_Items.Text = "물품 편집 (I)";
            this.tsmiMainMenu_Data_Items.Click += new System.EventHandler(this.tsmiMainMenu_Data_Items_Click);
            // 
            // tsmiMainMenu_Data_Store
            // 
            this.tsmiMainMenu_Data_Store.Name = "tsmiMainMenu_Data_Store";
            this.tsmiMainMenu_Data_Store.Size = new System.Drawing.Size(169, 22);
            this.tsmiMainMenu_Data_Store.Text = "상점 편집 (&S)";
            this.tsmiMainMenu_Data_Store.Click += new System.EventHandler(this.tsmiMainMenu_Data_Store_Click);
            // 
            // tsmiMainMenu_Data_Force
            // 
            this.tsmiMainMenu_Data_Force.Name = "tsmiMainMenu_Data_Force";
            this.tsmiMainMenu_Data_Force.Size = new System.Drawing.Size(169, 22);
            this.tsmiMainMenu_Data_Force.Text = "병종 편집 (&F)";
            this.tsmiMainMenu_Data_Force.Click += new System.EventHandler(this.tsmiMainMenu_Data_Force_Click);
            // 
            // tsmiMainMenu_Data_Terrain
            // 
            this.tsmiMainMenu_Data_Terrain.Name = "tsmiMainMenu_Data_Terrain";
            this.tsmiMainMenu_Data_Terrain.Size = new System.Drawing.Size(169, 22);
            this.tsmiMainMenu_Data_Terrain.Text = "지형 편집 (&T)";
            this.tsmiMainMenu_Data_Terrain.Click += new System.EventHandler(this.tsmiMainMenu_Data_Terrain_Click);
            // 
            // tsmiMainMenu_Data_Magic
            // 
            this.tsmiMainMenu_Data_Magic.Name = "tsmiMainMenu_Data_Magic";
            this.tsmiMainMenu_Data_Magic.Size = new System.Drawing.Size(169, 22);
            this.tsmiMainMenu_Data_Magic.Text = "책략 편집 (&M)";
            this.tsmiMainMenu_Data_Magic.Click += new System.EventHandler(this.tsmiMainMenu_Data_Magic_Click);
            // 
            // ExeToolStripMenuItem
            // 
            this.ExeToolStripMenuItem.Name = "ExeToolStripMenuItem";
            this.ExeToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.ExeToolStripMenuItem.Text = "특수능력 편집 (&E)";
            this.ExeToolStripMenuItem.Click += new System.EventHandler(this.ExeToolStripMenuItem_Click);
            // 
            // 프로젝트편집ToolStripMenuItem
            // 
            this.프로젝트편집ToolStripMenuItem.Name = "프로젝트편집ToolStripMenuItem";
            this.프로젝트편집ToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.프로젝트편집ToolStripMenuItem.Text = "프로젝트 편집 (&P)";
            this.프로젝트편집ToolStripMenuItem.Click += new System.EventHandler(this.프로젝트편집ToolStripMenuItem_Click);
            // 
            // 코드입력기ToolStripMenuItem
            // 
            this.코드입력기ToolStripMenuItem.Name = "코드입력기ToolStripMenuItem";
            this.코드입력기ToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.코드입력기ToolStripMenuItem.Text = "코드 입력기 (&C)";
            this.코드입력기ToolStripMenuItem.Click += new System.EventHandler(this.코드입력기ToolStripMenuItem_Click);
            // 
            // tsmiMainMenu_Imsg
            // 
            this.tsmiMainMenu_Imsg.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiMainMenu_Imsg_Units,
            this.tsmiMainMenu_Imsg_Retreat,
            this.tsmiMainMenu_Imsg_Critical,
            this.tsmiMainMenu_Imsg_Staff});
            this.tsmiMainMenu_Imsg.Name = "tsmiMainMenu_Imsg";
            this.tsmiMainMenu_Imsg.Size = new System.Drawing.Size(94, 20);
            this.tsmiMainMenu_Imsg.Text = "용어 편집 (&M)";
            this.tsmiMainMenu_Imsg.Visible = false;
            // 
            // tsmiMainMenu_Imsg_Units
            // 
            this.tsmiMainMenu_Imsg_Units.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiMainMenu_Imsg_Units_Original,
            this.tsmiMainMenu_Imsg_Units_Extension});
            this.tsmiMainMenu_Imsg_Units.Name = "tsmiMainMenu_Imsg_Units";
            this.tsmiMainMenu_Imsg_Units.Size = new System.Drawing.Size(152, 22);
            this.tsmiMainMenu_Imsg_Units.Text = "인물 열전 (&U)";
            this.tsmiMainMenu_Imsg_Units.Visible = false;
            // 
            // tsmiMainMenu_Imsg_Units_Original
            // 
            this.tsmiMainMenu_Imsg_Units_Original.Name = "tsmiMainMenu_Imsg_Units_Original";
            this.tsmiMainMenu_Imsg_Units_Original.Size = new System.Drawing.Size(119, 22);
            this.tsmiMainMenu_Imsg_Units_Original.Text = "원판 (&O)";
            this.tsmiMainMenu_Imsg_Units_Original.Click += new System.EventHandler(this.tsmiMainMenu_Imsg_Units_Original_Click);
            // 
            // tsmiMainMenu_Imsg_Units_Extension
            // 
            this.tsmiMainMenu_Imsg_Units_Extension.Name = "tsmiMainMenu_Imsg_Units_Extension";
            this.tsmiMainMenu_Imsg_Units_Extension.Size = new System.Drawing.Size(119, 22);
            this.tsmiMainMenu_Imsg_Units_Extension.Text = "확장(&E)";
            this.tsmiMainMenu_Imsg_Units_Extension.Click += new System.EventHandler(this.tsmiMainMenu_Imsg_Units_Extension_Click);
            // 
            // tsmiMainMenu_Imsg_Retreat
            // 
            this.tsmiMainMenu_Imsg_Retreat.Name = "tsmiMainMenu_Imsg_Retreat";
            this.tsmiMainMenu_Imsg_Retreat.Size = new System.Drawing.Size(152, 22);
            this.tsmiMainMenu_Imsg_Retreat.Text = "퇴각 대사 (&R)";
            this.tsmiMainMenu_Imsg_Retreat.Click += new System.EventHandler(this.tsmiMainMenu_Imsg_Retreat_Click);
            // 
            // tsmiMainMenu_Imsg_Critical
            // 
            this.tsmiMainMenu_Imsg_Critical.Name = "tsmiMainMenu_Imsg_Critical";
            this.tsmiMainMenu_Imsg_Critical.Size = new System.Drawing.Size(152, 22);
            this.tsmiMainMenu_Imsg_Critical.Text = "회심 대사 (&C)";
            this.tsmiMainMenu_Imsg_Critical.Click += new System.EventHandler(this.tsmiMainMenu_Imsg_Critical_Click);
            // 
            // tsmiMainMenu_Imsg_Staff
            // 
            this.tsmiMainMenu_Imsg_Staff.Name = "tsmiMainMenu_Imsg_Staff";
            this.tsmiMainMenu_Imsg_Staff.Size = new System.Drawing.Size(152, 22);
            this.tsmiMainMenu_Imsg_Staff.Text = "제작 인물 (&S)";
            this.tsmiMainMenu_Imsg_Staff.Click += new System.EventHandler(this.tsmiMainMenu_Imsg_Staff_Click);
            // 
            // 특수편집ToolStripMenuItem
            // 
            this.특수편집ToolStripMenuItem.Name = "특수편집ToolStripMenuItem";
            this.특수편집ToolStripMenuItem.Size = new System.Drawing.Size(90, 20);
            this.특수편집ToolStripMenuItem.Text = "특수 편집 (&S)";
            this.특수편집ToolStripMenuItem.Visible = false;
            // 
            // 세이브편집ToolStripMenuItem
            // 
            this.세이브편집ToolStripMenuItem.Name = "세이브편집ToolStripMenuItem";
            this.세이브편집ToolStripMenuItem.Size = new System.Drawing.Size(103, 20);
            this.세이브편집ToolStripMenuItem.Text = "세이브 편집 (&V)";
            this.세이브편집ToolStripMenuItem.Visible = false;
            // 
            // tsmiMainMenu_Config
            // 
            this.tsmiMainMenu_Config.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tscbMainMenu_Config_Selector,
            this.tsmiMainMenu_Config_Editor,
            this.tss_Config_1,
            this.tsmiMainMenu_Config_LoadAll,
            this.tsmiMainMenu_Config_SaveAll,
            this.테스트용ToolStripMenuItem});
            this.tsmiMainMenu_Config.Name = "tsmiMainMenu_Config";
            this.tsmiMainMenu_Config.Size = new System.Drawing.Size(91, 20);
            this.tsmiMainMenu_Config.Text = "버전 설정 (&C)";
            // 
            // tscbMainMenu_Config_Selector
            // 
            this.tscbMainMenu_Config_Selector.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tscbMainMenu_Config_Selector.Name = "tscbMainMenu_Config_Selector";
            this.tscbMainMenu_Config_Selector.Size = new System.Drawing.Size(200, 23);
            this.tscbMainMenu_Config_Selector.ToolTipText = "버전 파일 목록";
            this.tscbMainMenu_Config_Selector.SelectedIndexChanged += new System.EventHandler(this.tscbMainMenu_Config_Selector_SelectedIndexChanged);
            // 
            // tsmiMainMenu_Config_Editor
            // 
            this.tsmiMainMenu_Config_Editor.Name = "tsmiMainMenu_Config_Editor";
            this.tsmiMainMenu_Config_Editor.Size = new System.Drawing.Size(260, 22);
            this.tsmiMainMenu_Config_Editor.Text = "편집 기본정보 설정 (&E)";
            this.tsmiMainMenu_Config_Editor.Click += new System.EventHandler(this.tsmiMainMenu_Config_Editor_Click);
            // 
            // tss_Config_1
            // 
            this.tss_Config_1.Name = "tss_Config_1";
            this.tss_Config_1.Size = new System.Drawing.Size(257, 6);
            // 
            // tsmiMainMenu_Config_LoadAll
            // 
            this.tsmiMainMenu_Config_LoadAll.Name = "tsmiMainMenu_Config_LoadAll";
            this.tsmiMainMenu_Config_LoadAll.Size = new System.Drawing.Size(260, 22);
            this.tsmiMainMenu_Config_LoadAll.Text = "설정을 다시 불러온다 (&R)";
            // 
            // tsmiMainMenu_Config_SaveAll
            // 
            this.tsmiMainMenu_Config_SaveAll.Name = "tsmiMainMenu_Config_SaveAll";
            this.tsmiMainMenu_Config_SaveAll.Size = new System.Drawing.Size(260, 22);
            this.tsmiMainMenu_Config_SaveAll.Text = "설정을 보존한다 (&S)";
            // 
            // 테스트용ToolStripMenuItem
            // 
            this.테스트용ToolStripMenuItem.Name = "테스트용ToolStripMenuItem";
            this.테스트용ToolStripMenuItem.Size = new System.Drawing.Size(260, 22);
            this.테스트용ToolStripMenuItem.Text = "프리셋 설정";
            this.테스트용ToolStripMenuItem.Click += new System.EventHandler(this.테스트용ToolStripMenuItem_Click);
            // 
            // tsmiMainMenu_About
            // 
            this.tsmiMainMenu_About.Name = "tsmiMainMenu_About";
            this.tsmiMainMenu_About.Size = new System.Drawing.Size(115, 20);
            this.tsmiMainMenu_About.Text = "프로그램 정보 (&A)";
            this.tsmiMainMenu_About.Click += new System.EventHandler(this.tsmiMainMenu_About_Click);
            // 
            // pMainContainer
            // 
            this.pMainContainer.BackColor = System.Drawing.SystemColors.ControlLight;
            this.pMainContainer.Location = new System.Drawing.Point(0, 24);
            this.pMainContainer.Name = "pMainContainer";
            this.pMainContainer.Size = new System.Drawing.Size(893, 580);
            this.pMainContainer.TabIndex = 1;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(893, 607);
            this.Controls.Add(this.pMainContainer);
            this.Controls.Add(this.msMainMenu);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.msMainMenu;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CczEditor 4.0.0";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.msMainMenu.ResumeLayout(false);
            this.msMainMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.MenuStrip msMainMenu;
		private System.Windows.Forms.Panel pMainContainer;
		private System.Windows.Forms.ToolStripMenuItem tsmiMainMenu_File;
		private System.Windows.Forms.ToolStripMenuItem tsmiMainMenu_File_LoadFolder;
		private System.Windows.Forms.ToolStripSeparator tss_File_1;
		private System.Windows.Forms.ToolStripMenuItem tsmiMainMenu_File_LoadData;
		private System.Windows.Forms.ToolStripSeparator tss_File_2;
		private System.Windows.Forms.ToolStripMenuItem tsmiMainMenu_File_ExitApplication;
		private System.Windows.Forms.ToolStripMenuItem tsmiMainMenu_Data;
		private System.Windows.Forms.ToolStripMenuItem tsmiMainMenu_Data_Units;
		private System.Windows.Forms.ToolStripMenuItem tsmiMainMenu_Data_Items;
		private System.Windows.Forms.ToolStripMenuItem tsmiMainMenu_Data_Store;
		private System.Windows.Forms.ToolStripMenuItem tsmiMainMenu_Data_Force;
		private System.Windows.Forms.ToolStripMenuItem tsmiMainMenu_Data_Terrain;
		private System.Windows.Forms.ToolStripMenuItem tsmiMainMenu_Data_Magic;
		private System.Windows.Forms.ToolStripMenuItem tsmiMainMenu_Imsg;
		private System.Windows.Forms.ToolStripMenuItem tsmiMainMenu_Imsg_Units;
		private System.Windows.Forms.ToolStripMenuItem tsmiMainMenu_Imsg_Units_Original;
		private System.Windows.Forms.ToolStripMenuItem tsmiMainMenu_Imsg_Units_Extension;
		private System.Windows.Forms.ToolStripMenuItem tsmiMainMenu_Imsg_Retreat;
		private System.Windows.Forms.ToolStripMenuItem tsmiMainMenu_Imsg_Critical;
		private System.Windows.Forms.ToolStripMenuItem tsmiMainMenu_Imsg_Staff;
        private System.Windows.Forms.ToolStripMenuItem tsmiMainMenu_About;
        private System.Windows.Forms.ToolStripMenuItem tsmiMainMenu_Config;
        private System.Windows.Forms.ToolStripComboBox tscbMainMenu_Config_Selector;
        private System.Windows.Forms.ToolStripMenuItem tsmiMainMenu_Config_Editor;
        private System.Windows.Forms.ToolStripSeparator tss_Config_1;
        private System.Windows.Forms.ToolStripMenuItem tsmiMainMenu_Config_LoadAll;
        private System.Windows.Forms.ToolStripMenuItem tsmiMainMenu_Config_SaveAll;
        private System.Windows.Forms.ToolStripMenuItem ExeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 프로젝트편집ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 특수편집ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 세이브편집ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 테스트용ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 코드입력기ToolStripMenuItem;
    }
}

