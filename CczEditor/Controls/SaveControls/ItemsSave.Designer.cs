namespace CczEditor.Controls.SaveControls
{
	partial class ItemsSave
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
            this.lbList = new System.Windows.Forms.ListBox();
            this.btnRestore = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.tlpMainContainer = new System.Windows.Forms.TableLayoutPanel();
            this.lvConsumablesItem = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lblGold = new System.Windows.Forms.Label();
            this.lblLoyalTreacherousValue = new System.Windows.Forms.Label();
            this.ncGold = new CczEditor.Controls.NumericControl();
            this.ncLoyalTreacherousValue = new CczEditor.Controls.NumericControl();
            this.lblItemType = new System.Windows.Forms.Label();
            this.lblLv = new System.Windows.Forms.Label();
            this.lblExp = new System.Windows.Forms.Label();
            this.cbItemType = new System.Windows.Forms.ComboBox();
            this.ncLv = new CczEditor.Controls.NumericControl();
            this.ncExp = new CczEditor.Controls.NumericControl();
            this.btnEdit = new System.Windows.Forms.Button();
            this.pbItemIcon = new System.Windows.Forms.PictureBox();
            this.tlpMainContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ncGold)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ncLoyalTreacherousValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ncLv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ncExp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbItemIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // lbList
            // 
            this.lbList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbList.FormattingEnabled = true;
            this.lbList.ItemHeight = 12;
            this.lbList.Location = new System.Drawing.Point(3, 3);
            this.lbList.Name = "lbList";
            this.tlpMainContainer.SetRowSpan(this.lbList, 11);
            this.lbList.Size = new System.Drawing.Size(125, 663);
            this.lbList.TabIndex = 0;
            this.lbList.SelectedIndexChanged += new System.EventHandler(this.lbList_SelectedIndexChanged);
            // 
            // btnRestore
            // 
            this.btnRestore.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnRestore.Font = new System.Drawing.Font("SimSun", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnRestore.Location = new System.Drawing.Point(478, 634);
            this.btnRestore.Name = "btnRestore";
            this.btnRestore.Size = new System.Drawing.Size(209, 24);
            this.btnRestore.TabIndex = 9;
            this.btnRestore.Text = "복원";
            this.btnRestore.UseVisualStyleBackColor = true;
            this.btnRestore.Click += new System.EventHandler(this.btnRestore_Click);
            // 
            // btnSave
            // 
            this.btnSave.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSave.Font = new System.Drawing.Font("SimSun", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSave.Location = new System.Drawing.Point(369, 634);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(103, 24);
            this.btnSave.TabIndex = 8;
            this.btnSave.Text = "저장";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // tlpMainContainer
            // 
            this.tlpMainContainer.ColumnCount = 7;
            this.tlpMainContainer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 131F));
            this.tlpMainContainer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 4F));
            this.tlpMainContainer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 59F));
            this.tlpMainContainer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 130F));
            this.tlpMainContainer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 42F));
            this.tlpMainContainer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 109F));
            this.tlpMainContainer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 85F));
            this.tlpMainContainer.Controls.Add(this.lvConsumablesItem, 5, 1);
            this.tlpMainContainer.Controls.Add(this.btnSave, 5, 9);
            this.tlpMainContainer.Controls.Add(this.btnRestore, 6, 9);
            this.tlpMainContainer.Controls.Add(this.lbList, 0, 0);
            this.tlpMainContainer.Controls.Add(this.lblGold, 2, 6);
            this.tlpMainContainer.Controls.Add(this.lblLoyalTreacherousValue, 2, 7);
            this.tlpMainContainer.Controls.Add(this.ncGold, 3, 6);
            this.tlpMainContainer.Controls.Add(this.ncLoyalTreacherousValue, 3, 7);
            this.tlpMainContainer.Controls.Add(this.lblItemType, 2, 1);
            this.tlpMainContainer.Controls.Add(this.lblLv, 2, 2);
            this.tlpMainContainer.Controls.Add(this.lblExp, 2, 3);
            this.tlpMainContainer.Controls.Add(this.cbItemType, 3, 1);
            this.tlpMainContainer.Controls.Add(this.ncLv, 3, 2);
            this.tlpMainContainer.Controls.Add(this.ncExp, 3, 3);
            this.tlpMainContainer.Controls.Add(this.btnEdit, 3, 4);
            this.tlpMainContainer.Controls.Add(this.pbItemIcon, 4, 1);
            this.tlpMainContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMainContainer.Location = new System.Drawing.Point(0, 0);
            this.tlpMainContainer.Name = "tlpMainContainer";
            this.tlpMainContainer.RowCount = 11;
            this.tlpMainContainer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tlpMainContainer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpMainContainer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpMainContainer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpMainContainer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpMainContainer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 112F));
            this.tlpMainContainer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tlpMainContainer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tlpMainContainer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 329F));
            this.tlpMainContainer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpMainContainer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            this.tlpMainContainer.Size = new System.Drawing.Size(690, 550);
            this.tlpMainContainer.TabIndex = 0;
            // 
            // lvConsumablesItem
            // 
            this.lvConsumablesItem.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.tlpMainContainer.SetColumnSpan(this.lvConsumablesItem, 2);
            this.lvConsumablesItem.FullRowSelect = true;
            this.lvConsumablesItem.GridLines = true;
            this.lvConsumablesItem.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvConsumablesItem.LabelEdit = true;
            this.lvConsumablesItem.LabelWrap = false;
            this.lvConsumablesItem.Location = new System.Drawing.Point(369, 13);
            this.lvConsumablesItem.MultiSelect = false;
            this.lvConsumablesItem.Name = "lvConsumablesItem";
            this.tlpMainContainer.SetRowSpan(this.lvConsumablesItem, 7);
            this.lvConsumablesItem.Scrollable = false;
            this.lvConsumablesItem.ShowGroups = false;
            this.lvConsumablesItem.Size = new System.Drawing.Size(170, 286);
            this.lvConsumablesItem.TabIndex = 5;
            this.lvConsumablesItem.UseCompatibleStateImageBehavior = false;
            this.lvConsumablesItem.View = System.Windows.Forms.View.Details;
            this.lvConsumablesItem.AfterLabelEdit += new System.Windows.Forms.LabelEditEventHandler(this.lvConsumablesItem_AfterLabelEdit);
            this.lvConsumablesItem.ItemActivate += new System.EventHandler(this.lvConsumablesItem_ItemActivate);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "갯수";
            this.columnHeader1.Width = 50;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "소모도구";
            this.columnHeader2.Width = 108;
            // 
            // lblGold
            // 
            this.lblGold.AutoSize = true;
            this.lblGold.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblGold.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblGold.Location = new System.Drawing.Point(138, 242);
            this.lblGold.Name = "lblGold";
            this.lblGold.Padding = new System.Windows.Forms.Padding(0, 7, 0, 0);
            this.lblGold.Size = new System.Drawing.Size(53, 32);
            this.lblGold.TabIndex = 10;
            this.lblGold.Text = "소지금";
            this.lblGold.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblLoyalTreacherousValue
            // 
            this.lblLoyalTreacherousValue.AutoSize = true;
            this.lblLoyalTreacherousValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLoyalTreacherousValue.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblLoyalTreacherousValue.Location = new System.Drawing.Point(138, 274);
            this.lblLoyalTreacherousValue.Name = "lblLoyalTreacherousValue";
            this.lblLoyalTreacherousValue.Padding = new System.Windows.Forms.Padding(0, 7, 0, 0);
            this.lblLoyalTreacherousValue.Size = new System.Drawing.Size(53, 28);
            this.lblLoyalTreacherousValue.TabIndex = 11;
            this.lblLoyalTreacherousValue.Text = "충간도";
            this.lblLoyalTreacherousValue.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // ncGold
            // 
            this.ncGold.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ncGold.Increment = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.ncGold.Location = new System.Drawing.Point(197, 245);
            this.ncGold.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.ncGold.MaxNumberControl = null;
            this.ncGold.MinNumberControl = null;
            this.ncGold.Name = "ncGold";
            this.ncGold.Size = new System.Drawing.Size(124, 21);
            this.ncGold.TabIndex = 6;
            // 
            // ncLoyalTreacherousValue
            // 
            this.ncLoyalTreacherousValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ncLoyalTreacherousValue.Location = new System.Drawing.Point(197, 277);
            this.ncLoyalTreacherousValue.MaxNumberControl = null;
            this.ncLoyalTreacherousValue.MinNumberControl = null;
            this.ncLoyalTreacherousValue.Name = "ncLoyalTreacherousValue";
            this.ncLoyalTreacherousValue.Size = new System.Drawing.Size(124, 21);
            this.ncLoyalTreacherousValue.TabIndex = 7;
            // 
            // lblItemType
            // 
            this.lblItemType.AutoSize = true;
            this.lblItemType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblItemType.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblItemType.Location = new System.Drawing.Point(138, 10);
            this.lblItemType.Name = "lblItemType";
            this.lblItemType.Padding = new System.Windows.Forms.Padding(0, 7, 0, 0);
            this.lblItemType.Size = new System.Drawing.Size(53, 30);
            this.lblItemType.TabIndex = 12;
            this.lblItemType.Text = "장비";
            this.lblItemType.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblLv
            // 
            this.lblLv.AutoSize = true;
            this.lblLv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLv.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblLv.Location = new System.Drawing.Point(138, 40);
            this.lblLv.Name = "lblLv";
            this.lblLv.Padding = new System.Windows.Forms.Padding(0, 7, 0, 0);
            this.lblLv.Size = new System.Drawing.Size(53, 30);
            this.lblLv.TabIndex = 13;
            this.lblLv.Text = "등급";
            this.lblLv.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblExp
            // 
            this.lblExp.AutoSize = true;
            this.lblExp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblExp.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblExp.Location = new System.Drawing.Point(138, 70);
            this.lblExp.Name = "lblExp";
            this.lblExp.Padding = new System.Windows.Forms.Padding(0, 7, 0, 0);
            this.lblExp.Size = new System.Drawing.Size(53, 30);
            this.lblExp.TabIndex = 14;
            this.lblExp.Text = "경험치";
            this.lblExp.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // cbItemType
            // 
            this.cbItemType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbItemType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbItemType.FormattingEnabled = true;
            this.cbItemType.Location = new System.Drawing.Point(197, 13);
            this.cbItemType.Name = "cbItemType";
            this.cbItemType.Size = new System.Drawing.Size(124, 20);
            this.cbItemType.TabIndex = 1;
            this.cbItemType.SelectedIndexChanged += new System.EventHandler(this.cbItemType_SelectedIndexChanged);
            // 
            // ncLv
            // 
            this.ncLv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ncLv.Location = new System.Drawing.Point(197, 43);
            this.ncLv.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.ncLv.MaxNumberControl = null;
            this.ncLv.MinNumberControl = null;
            this.ncLv.Name = "ncLv";
            this.ncLv.Size = new System.Drawing.Size(124, 21);
            this.ncLv.TabIndex = 2;
            // 
            // ncExp
            // 
            this.ncExp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ncExp.Location = new System.Drawing.Point(197, 73);
            this.ncExp.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.ncExp.MaxNumberControl = null;
            this.ncExp.MinNumberControl = null;
            this.ncExp.Name = "ncExp";
            this.ncExp.Size = new System.Drawing.Size(124, 21);
            this.ncExp.TabIndex = 3;
            // 
            // btnEdit
            // 
            this.btnEdit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnEdit.Location = new System.Drawing.Point(197, 103);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(124, 24);
            this.btnEdit.TabIndex = 4;
            this.btnEdit.Text = "수정";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // pbItemIcon
            // 
            this.pbItemIcon.Location = new System.Drawing.Point(327, 17);
            this.pbItemIcon.Margin = new System.Windows.Forms.Padding(3, 7, 3, 3);
            this.pbItemIcon.Name = "pbItemIcon";
            this.tlpMainContainer.SetRowSpan(this.pbItemIcon, 3);
            this.pbItemIcon.Size = new System.Drawing.Size(32, 32);
            this.pbItemIcon.TabIndex = 19;
            this.pbItemIcon.TabStop = false;
            // 
            // ItemsSave
            // 
            this.Controls.Add(this.tlpMainContainer);
            this.Name = "ItemsSave";
            this.Load += new System.EventHandler(this.ItemsSave_Load);
            this.tlpMainContainer.ResumeLayout(false);
            this.tlpMainContainer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ncGold)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ncLoyalTreacherousValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ncLv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ncExp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbItemIcon)).EndInit();
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ListBox lbList;
		private System.Windows.Forms.TableLayoutPanel tlpMainContainer;
		private System.Windows.Forms.Button btnSave;
		private System.Windows.Forms.Button btnRestore;
		private System.Windows.Forms.ListView lvConsumablesItem;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.Label lblGold;
		private System.Windows.Forms.Label lblLoyalTreacherousValue;
		private NumericControl ncGold;
		private NumericControl ncLoyalTreacherousValue;
		private System.Windows.Forms.Label lblItemType;
		private System.Windows.Forms.Label lblLv;
		private System.Windows.Forms.Label lblExp;
		private System.Windows.Forms.ComboBox cbItemType;
		private NumericControl ncLv;
		private NumericControl ncExp;
		private System.Windows.Forms.Button btnEdit;
		private System.Windows.Forms.PictureBox pbItemIcon;

	}
}
