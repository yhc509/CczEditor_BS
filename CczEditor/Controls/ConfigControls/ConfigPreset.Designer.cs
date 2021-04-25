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
            this.Star61Button = new System.Windows.Forms.Button();
            this.Star62Button = new System.Windows.Forms.Button();
            this.Bs10Button = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
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
            this.tabControl1.Location = new System.Drawing.Point(3, 3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(860, 539);
            this.tabControl1.TabIndex = 3;
            // 
            // tabPage1
            // 
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
    }
}
