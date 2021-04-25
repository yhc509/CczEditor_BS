namespace CczEditor.Controls.DataControls
{
    partial class CodeApplierControl
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.ApplyButton = new System.Windows.Forms.Button();
            this.BackupCheck = new System.Windows.Forms.CheckBox();
            this.CodeTextBox = new CczEditor.Controls.TextBoxControl();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Location = new System.Drawing.Point(3, 3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(807, 531);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.BackupCheck);
            this.tabPage1.Controls.Add(this.CodeTextBox);
            this.tabPage1.Controls.Add(this.ApplyButton);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(799, 505);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "코드 적용";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // ApplyButton
            // 
            this.ApplyButton.Location = new System.Drawing.Point(718, 476);
            this.ApplyButton.Name = "ApplyButton";
            this.ApplyButton.Size = new System.Drawing.Size(75, 23);
            this.ApplyButton.TabIndex = 2;
            this.ApplyButton.Text = "적용";
            this.ApplyButton.UseVisualStyleBackColor = true;
            this.ApplyButton.Click += new System.EventHandler(this.ApplyButton_Click);
            // 
            // BackupCheck
            // 
            this.BackupCheck.AutoSize = true;
            this.BackupCheck.Checked = true;
            this.BackupCheck.CheckState = System.Windows.Forms.CheckState.Checked;
            this.BackupCheck.Location = new System.Drawing.Point(594, 480);
            this.BackupCheck.Name = "BackupCheck";
            this.BackupCheck.Size = new System.Drawing.Size(104, 16);
            this.BackupCheck.TabIndex = 4;
            this.BackupCheck.Text = "백업 파일 생성";
            this.BackupCheck.UseVisualStyleBackColor = true;
            // 
            // CodeTextBox
            // 
            this.CodeTextBox.Location = new System.Drawing.Point(6, 6);
            this.CodeTextBox.Multiline = true;
            this.CodeTextBox.Name = "CodeTextBox";
            this.CodeTextBox.Size = new System.Drawing.Size(787, 464);
            this.CodeTextBox.TabIndex = 3;
            // 
            // CodeApplierControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl1);
            this.Name = "CodeApplierControl";
            this.Size = new System.Drawing.Size(813, 537);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button ApplyButton;
        private TextBoxControl CodeTextBox;
        private System.Windows.Forms.CheckBox BackupCheck;
    }
}
