namespace CczEditor.Controls.ConfigControls
{
	partial class ConfigEditor
	{
		/// <summary>
		/// 변수설정
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// 清理所有正在使用的资源。
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

		#region Windows 윈도우 생성

		/// <summary>
		/// 设计器支持所需的方法 - 不要
		/// 使用代码编辑器修改此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{
            this.tcMain = new System.Windows.Forms.TabControl();
            this.tpSystemConfig = new System.Windows.Forms.TabPage();
            this.tlpSystemConfig = new System.Windows.Forms.TableLayoutPanel();
            this.lblDataFileDirectory = new System.Windows.Forms.Label();
            this.txtDataFileDirectory = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.exename = new System.Windows.Forms.TextBox();
            this.btnReLoad = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.UseCost = new System.Windows.Forms.CheckBox();
            this.UseVoice = new System.Windows.Forms.CheckBox();
            this.UseCutin = new System.Windows.Forms.CheckBox();
            this.UseFaceLarge = new System.Windows.Forms.CheckBox();
            this.SeperateE5 = new System.Windows.Forms.CheckBox();
            this.SingularAttribute = new System.Windows.Forms.CheckBox();
            this.MagicLearnExtension = new System.Windows.Forms.CheckBox();
            this.AIExtension = new System.Windows.Forms.CheckBox();
            this.ItemCustomRange = new System.Windows.Forms.CheckBox();
            this.tcMain.SuspendLayout();
            this.tpSystemConfig.SuspendLayout();
            this.tlpSystemConfig.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tcMain
            // 
            this.tcMain.Controls.Add(this.tpSystemConfig);
            this.tcMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcMain.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tcMain.Location = new System.Drawing.Point(0, 0);
            this.tcMain.Name = "tcMain";
            this.tcMain.SelectedIndex = 0;
            this.tcMain.Size = new System.Drawing.Size(690, 550);
            this.tcMain.TabIndex = 0;
            // 
            // tpSystemConfig
            // 
            this.tpSystemConfig.Controls.Add(this.tlpSystemConfig);
            this.tpSystemConfig.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tpSystemConfig.Location = new System.Drawing.Point(4, 24);
            this.tpSystemConfig.Name = "tpSystemConfig";
            this.tpSystemConfig.Padding = new System.Windows.Forms.Padding(3);
            this.tpSystemConfig.Size = new System.Drawing.Size(682, 522);
            this.tpSystemConfig.TabIndex = 0;
            this.tpSystemConfig.Text = "설정";
            this.tpSystemConfig.UseVisualStyleBackColor = true;
            // 
            // tlpSystemConfig
            // 
            this.tlpSystemConfig.ColumnCount = 7;
            this.tlpSystemConfig.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tlpSystemConfig.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 93F));
            this.tlpSystemConfig.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 101F));
            this.tlpSystemConfig.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 242F));
            this.tlpSystemConfig.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 67F));
            this.tlpSystemConfig.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 82F));
            this.tlpSystemConfig.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 41F));
            this.tlpSystemConfig.Controls.Add(this.lblDataFileDirectory, 1, 1);
            this.tlpSystemConfig.Controls.Add(this.txtDataFileDirectory, 2, 1);
            this.tlpSystemConfig.Controls.Add(this.label1, 1, 2);
            this.tlpSystemConfig.Controls.Add(this.exename, 2, 2);
            this.tlpSystemConfig.Controls.Add(this.btnReLoad, 6, 6);
            this.tlpSystemConfig.Controls.Add(this.btnSave, 5, 6);
            this.tlpSystemConfig.Controls.Add(this.label2, 3, 2);
            this.tlpSystemConfig.Controls.Add(this.panel1, 1, 3);
            this.tlpSystemConfig.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tlpSystemConfig.Location = new System.Drawing.Point(3, 3);
            this.tlpSystemConfig.Name = "tlpSystemConfig";
            this.tlpSystemConfig.RowCount = 7;
            this.tlpSystemConfig.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tlpSystemConfig.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 44F));
            this.tlpSystemConfig.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 43F));
            this.tlpSystemConfig.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 281F));
            this.tlpSystemConfig.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 18F));
            this.tlpSystemConfig.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 85F));
            this.tlpSystemConfig.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            this.tlpSystemConfig.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpSystemConfig.Size = new System.Drawing.Size(673, 513);
            this.tlpSystemConfig.TabIndex = 0;
            // 
            // lblDataFileDirectory
            // 
            this.lblDataFileDirectory.AutoSize = true;
            this.lblDataFileDirectory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDataFileDirectory.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblDataFileDirectory.Location = new System.Drawing.Point(13, 10);
            this.lblDataFileDirectory.Name = "lblDataFileDirectory";
            this.lblDataFileDirectory.Padding = new System.Windows.Forms.Padding(0, 14, 0, 0);
            this.lblDataFileDirectory.Size = new System.Drawing.Size(87, 44);
            this.lblDataFileDirectory.TabIndex = 8;
            this.lblDataFileDirectory.Text = "파일 경로：";
            this.lblDataFileDirectory.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtDataFileDirectory
            // 
            this.tlpSystemConfig.SetColumnSpan(this.txtDataFileDirectory, 5);
            this.txtDataFileDirectory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtDataFileDirectory.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtDataFileDirectory.Location = new System.Drawing.Point(106, 20);
            this.txtDataFileDirectory.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.txtDataFileDirectory.Name = "txtDataFileDirectory";
            this.txtDataFileDirectory.ReadOnly = true;
            this.txtDataFileDirectory.Size = new System.Drawing.Size(564, 23);
            this.txtDataFileDirectory.TabIndex = 0;
            this.txtDataFileDirectory.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.txtDataFileDirectory_MouseDoubleClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(13, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 43);
            this.label1.TabIndex = 10;
            this.label1.Text = "EXE 파일명 :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // exename
            // 
            this.exename.Dock = System.Windows.Forms.DockStyle.Fill;
            this.exename.Location = new System.Drawing.Point(106, 64);
            this.exename.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.exename.Name = "exename";
            this.exename.Size = new System.Drawing.Size(95, 23);
            this.exename.TabIndex = 11;
            // 
            // btnReLoad
            // 
            this.btnReLoad.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnReLoad.Location = new System.Drawing.Point(598, 484);
            this.btnReLoad.Name = "btnReLoad";
            this.btnReLoad.Size = new System.Drawing.Size(72, 26);
            this.btnReLoad.TabIndex = 7;
            this.btnReLoad.Text = "복원";
            this.btnReLoad.UseVisualStyleBackColor = true;
            this.btnReLoad.Click += new System.EventHandler(this.btnReLoad_Click);
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnSave.Location = new System.Drawing.Point(516, 484);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(76, 26);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "저장";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(207, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(236, 43);
            this.label2.TabIndex = 12;
            this.label2.Text = "수정 후에는 편집기를 재실행해야 합니다.";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.tlpSystemConfig.SetColumnSpan(this.panel1, 6);
            this.panel1.Controls.Add(this.UseCost);
            this.panel1.Controls.Add(this.UseVoice);
            this.panel1.Controls.Add(this.UseCutin);
            this.panel1.Controls.Add(this.UseFaceLarge);
            this.panel1.Controls.Add(this.SeperateE5);
            this.panel1.Controls.Add(this.SingularAttribute);
            this.panel1.Controls.Add(this.MagicLearnExtension);
            this.panel1.Controls.Add(this.AIExtension);
            this.panel1.Controls.Add(this.ItemCustomRange);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(13, 100);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(657, 275);
            this.panel1.TabIndex = 13;
            // 
            // UseCost
            // 
            this.UseCost.AutoSize = true;
            this.UseCost.Location = new System.Drawing.Point(456, 57);
            this.UseCost.Name = "UseCost";
            this.UseCost.Size = new System.Drawing.Size(118, 19);
            this.UseCost.TabIndex = 11;
            this.UseCost.Text = "무장 코스트 사용";
            this.UseCost.UseVisualStyleBackColor = true;
            // 
            // UseVoice
            // 
            this.UseVoice.AutoSize = true;
            this.UseVoice.Location = new System.Drawing.Point(314, 57);
            this.UseVoice.Name = "UseVoice";
            this.UseVoice.Size = new System.Drawing.Size(106, 19);
            this.UseVoice.TabIndex = 10;
            this.UseVoice.Text = "무장 음성 사용";
            this.UseVoice.UseVisualStyleBackColor = true;
            // 
            // UseCutin
            // 
            this.UseCutin.AutoSize = true;
            this.UseCutin.Location = new System.Drawing.Point(161, 57);
            this.UseCutin.Name = "UseCutin";
            this.UseCutin.Size = new System.Drawing.Size(78, 19);
            this.UseCutin.TabIndex = 9;
            this.UseCutin.Text = "컷인 사용";
            this.UseCutin.UseVisualStyleBackColor = true;
            // 
            // UseFaceLarge
            // 
            this.UseFaceLarge.AutoSize = true;
            this.UseFaceLarge.Location = new System.Drawing.Point(19, 57);
            this.UseFaceLarge.Name = "UseFaceLarge";
            this.UseFaceLarge.Size = new System.Drawing.Size(90, 19);
            this.UseFaceLarge.TabIndex = 8;
            this.UseFaceLarge.Text = "전신상 사용";
            this.UseFaceLarge.UseVisualStyleBackColor = true;
            // 
            // SeperateE5
            // 
            this.SeperateE5.AutoSize = true;
            this.SeperateE5.Location = new System.Drawing.Point(456, 13);
            this.SeperateE5.Name = "SeperateE5";
            this.SeperateE5.Size = new System.Drawing.Size(95, 19);
            this.SeperateE5.TabIndex = 7;
            this.SeperateE5.Text = "E5 폴더 분리";
            this.SeperateE5.UseVisualStyleBackColor = true;
            // 
            // SingularAttribute
            // 
            this.SingularAttribute.AutoSize = true;
            this.SingularAttribute.Location = new System.Drawing.Point(19, 13);
            this.SingularAttribute.Name = "SingularAttribute";
            this.SingularAttribute.Size = new System.Drawing.Size(114, 19);
            this.SingularAttribute.TabIndex = 6;
            this.SingularAttribute.Text = "홀수식 장수열전";
            this.SingularAttribute.UseVisualStyleBackColor = true;
            // 
            // MagicLearnExtension
            // 
            this.MagicLearnExtension.AutoSize = true;
            this.MagicLearnExtension.Location = new System.Drawing.Point(314, 13);
            this.MagicLearnExtension.Name = "MagicLearnExtension";
            this.MagicLearnExtension.Size = new System.Drawing.Size(98, 19);
            this.MagicLearnExtension.TabIndex = 5;
            this.MagicLearnExtension.Text = "책략학습확장";
            this.MagicLearnExtension.UseVisualStyleBackColor = true;
            // 
            // AIExtension
            // 
            this.AIExtension.AutoSize = true;
            this.AIExtension.Location = new System.Drawing.Point(161, 13);
            this.AIExtension.Name = "AIExtension";
            this.AIExtension.Size = new System.Drawing.Size(122, 19);
            this.AIExtension.TabIndex = 4;
            this.AIExtension.Text = "병종인공지능확장";
            this.AIExtension.UseVisualStyleBackColor = true;
            // 
            // ItemCustomRange
            // 
            this.ItemCustomRange.AutoSize = true;
            this.ItemCustomRange.Location = new System.Drawing.Point(19, 107);
            this.ItemCustomRange.Name = "ItemCustomRange";
            this.ItemCustomRange.Size = new System.Drawing.Size(122, 19);
            this.ItemCustomRange.TabIndex = 0;
            this.ItemCustomRange.Text = "도구사용범위확장";
            this.ItemCustomRange.UseVisualStyleBackColor = true;
            // 
            // ConfigEditor
            // 
            this.Controls.Add(this.tcMain);
            this.Name = "ConfigEditor";
            this.Size = new System.Drawing.Size(690, 550);
            this.Load += new System.EventHandler(this.ConfigEditor_Load);
            this.tcMain.ResumeLayout(false);
            this.tpSystemConfig.ResumeLayout(false);
            this.tlpSystemConfig.ResumeLayout(false);
            this.tlpSystemConfig.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TabControl tcMain;
		private System.Windows.Forms.TabPage tpSystemConfig;
		private System.Windows.Forms.Button btnSave;
		private System.Windows.Forms.Button btnReLoad;
		private System.Windows.Forms.Label lblDataFileDirectory;
        private System.Windows.Forms.TextBox txtDataFileDirectory;
        private System.Windows.Forms.TableLayoutPanel tlpSystemConfig;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox exename;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox SingularAttribute;
        private System.Windows.Forms.CheckBox MagicLearnExtension;
        private System.Windows.Forms.CheckBox AIExtension;
        private System.Windows.Forms.CheckBox ItemCustomRange;
        private System.Windows.Forms.CheckBox UseCost;
        private System.Windows.Forms.CheckBox UseVoice;
        private System.Windows.Forms.CheckBox UseCutin;
        private System.Windows.Forms.CheckBox UseFaceLarge;
        private System.Windows.Forms.CheckBox SeperateE5;
    }
}
