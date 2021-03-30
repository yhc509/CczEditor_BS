namespace CczEditor.Controls.ImsgControls
{
	partial class BaseImsgControl
	{
		/// <summary>
		/// 必需的设计器变量。
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

		#region Windows 窗体设计器生成的代码

		/// <summary>
		/// 设计器支持所需的方法 - 不要
		/// 使用代码编辑器修改此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{
            this.tlpContainer = new System.Windows.Forms.TableLayoutPanel();
            this.lbList = new System.Windows.Forms.ListBox();
            this.txtText = new CczEditor.Controls.TextBoxControl();
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnRestore = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.lblTextCount = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.tlpContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpContainer
            // 
            this.tlpContainer.ColumnCount = 4;
            this.tlpContainer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 137F));
            this.tlpContainer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 209F));
            this.tlpContainer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 172F));
            this.tlpContainer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 81F));
            this.tlpContainer.Controls.Add(this.lbList, 0, 0);
            this.tlpContainer.Controls.Add(this.txtText, 1, 3);
            this.tlpContainer.Controls.Add(this.lblTitle, 1, 1);
            this.tlpContainer.Controls.Add(this.btnRestore, 3, 5);
            this.tlpContainer.Controls.Add(this.btnSave, 2, 5);
            this.tlpContainer.Controls.Add(this.lblTextCount, 1, 5);
            this.tlpContainer.Controls.Add(this.comboBox1, 2, 1);
            this.tlpContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpContainer.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tlpContainer.Location = new System.Drawing.Point(0, 0);
            this.tlpContainer.Name = "tlpContainer";
            this.tlpContainer.RowCount = 8;
            this.tlpContainer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpContainer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpContainer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tlpContainer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 246F));
            this.tlpContainer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            this.tlpContainer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31F));
            this.tlpContainer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 347F));
            this.tlpContainer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            this.tlpContainer.Size = new System.Drawing.Size(690, 550);
            this.tlpContainer.TabIndex = 0;
            // 
            // lbList
            // 
            this.lbList.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbList.FormattingEnabled = true;
            this.lbList.ItemHeight = 15;
            this.lbList.Location = new System.Drawing.Point(3, 3);
            this.lbList.Name = "lbList";
            this.tlpContainer.SetRowSpan(this.lbList, 8);
            this.lbList.Size = new System.Drawing.Size(130, 544);
            this.lbList.TabIndex = 0;
            // 
            // txtText
            // 
            this.tlpContainer.SetColumnSpan(this.txtText, 3);
            this.txtText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtText.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtText.Location = new System.Drawing.Point(140, 53);
            this.txtText.MaxLength = 200;
            this.txtText.Multiline = true;
            this.txtText.Name = "txtText";
            this.txtText.Size = new System.Drawing.Size(547, 240);
            this.txtText.TabIndex = 1;
            this.txtText.TextChanged += new System.EventHandler(this.txtText_TextChanged);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitle.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblTitle.Location = new System.Drawing.Point(140, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(203, 20);
            this.lblTitle.TabIndex = 4;
            this.lblTitle.Text = "설명：";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnRestore
            // 
            this.btnRestore.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnRestore.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnRestore.Location = new System.Drawing.Point(521, 307);
            this.btnRestore.Name = "btnRestore";
            this.btnRestore.Size = new System.Drawing.Size(166, 25);
            this.btnRestore.TabIndex = 3;
            this.btnRestore.Text = "복원";
            this.btnRestore.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSave.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnSave.Location = new System.Drawing.Point(349, 307);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(166, 25);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "저장";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // lblTextCount
            // 
            this.lblTextCount.AutoSize = true;
            this.lblTextCount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTextCount.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblTextCount.Location = new System.Drawing.Point(140, 304);
            this.lblTextCount.Name = "lblTextCount";
            this.lblTextCount.Size = new System.Drawing.Size(203, 31);
            this.lblTextCount.TabIndex = 5;
            this.lblTextCount.Text = "글자 수：0";
            this.lblTextCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(349, 23);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(111, 23);
            this.comboBox1.TabIndex = 6;
            this.comboBox1.Visible = false;
            // 
            // BaseImsgControl
            // 
            this.Controls.Add(this.tlpContainer);
            this.Name = "BaseImsgControl";
            this.Size = new System.Drawing.Size(690, 550);
            this.tlpContainer.ResumeLayout(false);
            this.tlpContainer.PerformLayout();
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TableLayoutPanel tlpContainer;
		protected System.Windows.Forms.ListBox lbList;
		protected System.Windows.Forms.Label lblTitle;
		protected TextBoxControl txtText;
		protected System.Windows.Forms.Label lblTextCount;
		protected System.Windows.Forms.Button btnRestore;
        protected System.Windows.Forms.Button btnSave;
        protected System.Windows.Forms.ComboBox comboBox1;

	}
}
