namespace CczEditor.Controls.ExtensionsControls
{
	partial class ForceCategoriesRestraint
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
            this.btnSave = new System.Windows.Forms.Button();
            this.btnLoadFile = new System.Windows.Forms.Button();
            this.lvRestraint = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.txtFileName = new CczEditor.Controls.TextBoxControl();
            this.lblOffset = new System.Windows.Forms.Label();
            this.ncOffset = new CczEditor.Controls.NumericControl();
            this.btnSaveOffset = new System.Windows.Forms.Button();
            this.tlpContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ncOffset)).BeginInit();
            this.SuspendLayout();
            // 
            // tlpContainer
            // 
            this.tlpContainer.ColumnCount = 8;
            this.tlpContainer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 144F));
            this.tlpContainer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpContainer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 210F));
            this.tlpContainer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpContainer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 230F));
            this.tlpContainer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tlpContainer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tlpContainer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tlpContainer.Controls.Add(this.lbList, 0, 0);
            this.tlpContainer.Controls.Add(this.btnSave, 5, 3);
            this.tlpContainer.Controls.Add(this.btnLoadFile, 6, 3);
            this.tlpContainer.Controls.Add(this.lvRestraint, 2, 0);
            this.tlpContainer.Controls.Add(this.txtFileName, 4, 3);
            this.tlpContainer.Controls.Add(this.lblOffset, 4, 2);
            this.tlpContainer.Controls.Add(this.ncOffset, 5, 2);
            this.tlpContainer.Controls.Add(this.btnSaveOffset, 6, 2);
            this.tlpContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpContainer.Location = new System.Drawing.Point(0, 0);
            this.tlpContainer.Name = "tlpContainer";
            this.tlpContainer.RowCount = 5;
            this.tlpContainer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tlpContainer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 470F));
            this.tlpContainer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpContainer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpContainer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tlpContainer.Size = new System.Drawing.Size(794, 550);
            this.tlpContainer.TabIndex = 0;
            // 
            // lbList
            // 
            this.lbList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbList.Enabled = false;
            this.lbList.FormattingEnabled = true;
            this.lbList.ItemHeight = 12;
            this.lbList.Location = new System.Drawing.Point(3, 3);
            this.lbList.Name = "lbList";
            this.tlpContainer.SetRowSpan(this.lbList, 5);
            this.lbList.Size = new System.Drawing.Size(138, 544);
            this.lbList.TabIndex = 0;
            this.lbList.SelectedIndexChanged += new System.EventHandler(this.lbList_SelectedIndexChanged);
            // 
            // btnSave
            // 
            this.btnSave.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSave.Enabled = false;
            this.btnSave.Font = new System.Drawing.Font("SimSun", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSave.Location = new System.Drawing.Point(627, 513);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(74, 24);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnLoadFile
            // 
            this.btnLoadFile.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnLoadFile.Font = new System.Drawing.Font("SimSun", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnLoadFile.Location = new System.Drawing.Point(707, 513);
            this.btnLoadFile.Name = "btnLoadFile";
            this.btnLoadFile.Size = new System.Drawing.Size(74, 24);
            this.btnLoadFile.TabIndex = 2;
            this.btnLoadFile.Text = "载入";
            this.btnLoadFile.UseVisualStyleBackColor = true;
            this.btnLoadFile.Click += new System.EventHandler(this.btnLoadFile_Click);
            // 
            // lvRestraint
            // 
            this.lvRestraint.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.lvRestraint.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvRestraint.Enabled = false;
            this.lvRestraint.FullRowSelect = true;
            this.lvRestraint.GridLines = true;
            this.lvRestraint.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvRestraint.LabelEdit = true;
            this.lvRestraint.Location = new System.Drawing.Point(167, 3);
            this.lvRestraint.MultiSelect = false;
            this.lvRestraint.Name = "lvRestraint";
            this.tlpContainer.SetRowSpan(this.lvRestraint, 5);
            this.lvRestraint.ShowGroups = false;
            this.lvRestraint.Size = new System.Drawing.Size(204, 544);
            this.lvRestraint.TabIndex = 3;
            this.lvRestraint.UseCompatibleStateImageBehavior = false;
            this.lvRestraint.View = System.Windows.Forms.View.Details;
            this.lvRestraint.AfterLabelEdit += new System.Windows.Forms.LabelEditEventHandler(this.lvRestraint_AfterLabelEdit);
            this.lvRestraint.ItemActivate += new System.EventHandler(this.lvRestraint_ItemActivate);
            this.lvRestraint.SelectedIndexChanged += new System.EventHandler(this.lvRestraint_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "相克值";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "兵种";
            this.columnHeader2.Width = 120;
            // 
            // txtFileName
            // 
            this.txtFileName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtFileName.Location = new System.Drawing.Point(397, 515);
            this.txtFileName.Margin = new System.Windows.Forms.Padding(3, 5, 3, 3);
            this.txtFileName.Name = "txtFileName";
            this.txtFileName.ReadOnly = true;
            this.txtFileName.Size = new System.Drawing.Size(224, 21);
            this.txtFileName.TabIndex = 4;
            // 
            // lblOffset
            // 
            this.lblOffset.AutoSize = true;
            this.lblOffset.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblOffset.Location = new System.Drawing.Point(397, 480);
            this.lblOffset.Name = "lblOffset";
            this.lblOffset.Padding = new System.Windows.Forms.Padding(0, 9, 0, 0);
            this.lblOffset.Size = new System.Drawing.Size(224, 30);
            this.lblOffset.TabIndex = 5;
            this.lblOffset.Text = "文件偏移：";
            this.lblOffset.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // ncOffset
            // 
            this.ncOffset.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ncOffset.Hexadecimal = true;
            this.ncOffset.Location = new System.Drawing.Point(627, 485);
            this.ncOffset.Margin = new System.Windows.Forms.Padding(3, 5, 3, 3);
            this.ncOffset.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.ncOffset.MaxNumberControl = null;
            this.ncOffset.MinNumberControl = null;
            this.ncOffset.Name = "ncOffset";
            this.ncOffset.Size = new System.Drawing.Size(74, 21);
            this.ncOffset.TabIndex = 6;
            // 
            // btnSaveOffset
            // 
            this.btnSaveOffset.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSaveOffset.Location = new System.Drawing.Point(707, 483);
            this.btnSaveOffset.Name = "btnSaveOffset";
            this.btnSaveOffset.Size = new System.Drawing.Size(74, 24);
            this.btnSaveOffset.TabIndex = 7;
            this.btnSaveOffset.Text = "保存偏移";
            this.btnSaveOffset.UseVisualStyleBackColor = true;
            this.btnSaveOffset.Click += new System.EventHandler(this.btnSaveOffset_Click);
            // 
            // ForceCategoriesRestraint
            // 
            this.Controls.Add(this.tlpContainer);
            this.Name = "ForceCategoriesRestraint";
            this.Load += new System.EventHandler(this.ForceCategoriesRestraint_Load);
            this.tlpContainer.ResumeLayout(false);
            this.tlpContainer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ncOffset)).EndInit();
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TableLayoutPanel tlpContainer;
		private System.Windows.Forms.ListBox lbList;
		private System.Windows.Forms.Button btnSave;
		private System.Windows.Forms.Button btnLoadFile;
		private System.Windows.Forms.ListView lvRestraint;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private TextBoxControl txtFileName;
		private System.Windows.Forms.Label lblOffset;
		private NumericControl ncOffset;
		private System.Windows.Forms.Button btnSaveOffset;
	}
}
