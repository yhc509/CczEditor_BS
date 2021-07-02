namespace CczEditor.Controls.DataControls
{
    partial class MoveUnitsPopup
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.sourceUnitListBox = new System.Windows.Forms.CheckedListBox();
            this.destUnitListBox = new System.Windows.Forms.CheckedListBox();
            this.sourceCountText = new System.Windows.Forms.Label();
            this.destCountText = new System.Windows.Forms.Label();
            this.sourceSearchButton = new System.Windows.Forms.Button();
            this.destSearchButton = new System.Windows.Forms.Button();
            this.ExchangeButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.sourceCancelButton = new System.Windows.Forms.Button();
            this.sourceSelectButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.destCancelButton = new System.Windows.Forms.Button();
            this.destSelectButton = new System.Windows.Forms.Button();
            this.CancelButton = new System.Windows.Forms.Button();
            this.destEndValueBox = new CczEditor.Controls.NumericControl();
            this.destStartValueBox = new CczEditor.Controls.NumericControl();
            this.sourceEndValueBox = new CczEditor.Controls.NumericControl();
            this.sourceStartValueBox = new CczEditor.Controls.NumericControl();
            this.destSearchBox = new CczEditor.Controls.TextBoxControl();
            this.sourceSearchBox = new CczEditor.Controls.TextBoxControl();
            ((System.ComponentModel.ISupportInitialize)(this.destEndValueBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.destStartValueBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sourceEndValueBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sourceStartValueBox)).BeginInit();
            this.SuspendLayout();
            // 
            // sourceUnitListBox
            // 
            this.sourceUnitListBox.FormattingEnabled = true;
            this.sourceUnitListBox.Location = new System.Drawing.Point(12, 41);
            this.sourceUnitListBox.Name = "sourceUnitListBox";
            this.sourceUnitListBox.Size = new System.Drawing.Size(112, 292);
            this.sourceUnitListBox.TabIndex = 0;
            this.sourceUnitListBox.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.sourceUnitList_ItemCheck);
            // 
            // destUnitListBox
            // 
            this.destUnitListBox.FormattingEnabled = true;
            this.destUnitListBox.Location = new System.Drawing.Point(233, 41);
            this.destUnitListBox.Name = "destUnitListBox";
            this.destUnitListBox.Size = new System.Drawing.Size(112, 292);
            this.destUnitListBox.TabIndex = 1;
            this.destUnitListBox.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.destUnitList_ItemCheck);
            // 
            // sourceCountText
            // 
            this.sourceCountText.AutoSize = true;
            this.sourceCountText.Location = new System.Drawing.Point(10, 26);
            this.sourceCountText.Name = "sourceCountText";
            this.sourceCountText.Size = new System.Drawing.Size(59, 12);
            this.sourceCountText.TabIndex = 2;
            this.sourceCountText.Text = "선택중 : 0";
            // 
            // destCountText
            // 
            this.destCountText.AutoSize = true;
            this.destCountText.Location = new System.Drawing.Point(231, 26);
            this.destCountText.Name = "destCountText";
            this.destCountText.Size = new System.Drawing.Size(59, 12);
            this.destCountText.TabIndex = 3;
            this.destCountText.Text = "선택중 : 0";
            // 
            // sourceSearchButton
            // 
            this.sourceSearchButton.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.sourceSearchButton.Location = new System.Drawing.Point(12, 365);
            this.sourceSearchButton.Name = "sourceSearchButton";
            this.sourceSearchButton.Size = new System.Drawing.Size(112, 23);
            this.sourceSearchButton.TabIndex = 12;
            this.sourceSearchButton.Text = "검색";
            this.sourceSearchButton.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.sourceSearchButton.UseVisualStyleBackColor = true;
            this.sourceSearchButton.Click += new System.EventHandler(this.sourceSearchButton_Click);
            // 
            // destSearchButton
            // 
            this.destSearchButton.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.destSearchButton.Location = new System.Drawing.Point(233, 365);
            this.destSearchButton.Name = "destSearchButton";
            this.destSearchButton.Size = new System.Drawing.Size(112, 23);
            this.destSearchButton.TabIndex = 14;
            this.destSearchButton.Text = "검색";
            this.destSearchButton.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.destSearchButton.UseVisualStyleBackColor = true;
            this.destSearchButton.Click += new System.EventHandler(this.destSearchButton_Click);
            // 
            // ExchangeButton
            // 
            this.ExchangeButton.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.ExchangeButton.Location = new System.Drawing.Point(124, 464);
            this.ExchangeButton.Name = "ExchangeButton";
            this.ExchangeButton.Size = new System.Drawing.Size(112, 23);
            this.ExchangeButton.TabIndex = 15;
            this.ExchangeButton.Text = "교환하기";
            this.ExchangeButton.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.ExchangeButton.UseVisualStyleBackColor = true;
            this.ExchangeButton.Click += new System.EventHandler(this.ExchangeButton_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(170, 192);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(27, 12);
            this.label3.TabIndex = 16;
            this.label3.Text = "<->";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(61, 400);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(14, 12);
            this.label8.TabIndex = 82;
            this.label8.Text = "~";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // sourceCancelButton
            // 
            this.sourceCancelButton.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.sourceCancelButton.Location = new System.Drawing.Point(79, 423);
            this.sourceCancelButton.Name = "sourceCancelButton";
            this.sourceCancelButton.Size = new System.Drawing.Size(45, 23);
            this.sourceCancelButton.TabIndex = 81;
            this.sourceCancelButton.Text = "취소";
            this.sourceCancelButton.UseVisualStyleBackColor = true;
            this.sourceCancelButton.Click += new System.EventHandler(this.sourceCancelButton_Click);
            // 
            // sourceSelectButton
            // 
            this.sourceSelectButton.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.sourceSelectButton.Location = new System.Drawing.Point(12, 423);
            this.sourceSelectButton.Name = "sourceSelectButton";
            this.sourceSelectButton.Size = new System.Drawing.Size(45, 23);
            this.sourceSelectButton.TabIndex = 80;
            this.sourceSelectButton.Text = "선택";
            this.sourceSelectButton.UseVisualStyleBackColor = true;
            this.sourceSelectButton.Click += new System.EventHandler(this.sourceSelectButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(282, 402);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(14, 12);
            this.label1.TabIndex = 87;
            this.label1.Text = "~";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // destCancelButton
            // 
            this.destCancelButton.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.destCancelButton.Location = new System.Drawing.Point(300, 425);
            this.destCancelButton.Name = "destCancelButton";
            this.destCancelButton.Size = new System.Drawing.Size(45, 23);
            this.destCancelButton.TabIndex = 86;
            this.destCancelButton.Text = "취소";
            this.destCancelButton.UseVisualStyleBackColor = true;
            this.destCancelButton.Click += new System.EventHandler(this.destCancelButton_Click);
            // 
            // destSelectButton
            // 
            this.destSelectButton.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.destSelectButton.Location = new System.Drawing.Point(233, 425);
            this.destSelectButton.Name = "destSelectButton";
            this.destSelectButton.Size = new System.Drawing.Size(45, 23);
            this.destSelectButton.TabIndex = 85;
            this.destSelectButton.Text = "선택";
            this.destSelectButton.UseVisualStyleBackColor = true;
            this.destSelectButton.Click += new System.EventHandler(this.destSelectButton_Click);
            // 
            // CancelButton
            // 
            this.CancelButton.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.CancelButton.Location = new System.Drawing.Point(124, 493);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(112, 23);
            this.CancelButton.TabIndex = 88;
            this.CancelButton.Text = "취소";
            this.CancelButton.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // destEndValueBox
            // 
            this.destEndValueBox.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.destEndValueBox.Location = new System.Drawing.Point(300, 396);
            this.destEndValueBox.Maximum = new decimal(new int[] {
            1023,
            0,
            0,
            0});
            this.destEndValueBox.MaxNumberControl = null;
            this.destEndValueBox.MinNumberControl = null;
            this.destEndValueBox.Name = "destEndValueBox";
            this.destEndValueBox.Size = new System.Drawing.Size(45, 23);
            this.destEndValueBox.TabIndex = 84;
            this.destEndValueBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // destStartValueBox
            // 
            this.destStartValueBox.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.destStartValueBox.Location = new System.Drawing.Point(233, 396);
            this.destStartValueBox.Maximum = new decimal(new int[] {
            1023,
            0,
            0,
            0});
            this.destStartValueBox.MaxNumberControl = null;
            this.destStartValueBox.MinNumberControl = null;
            this.destStartValueBox.Name = "destStartValueBox";
            this.destStartValueBox.Size = new System.Drawing.Size(45, 23);
            this.destStartValueBox.TabIndex = 83;
            this.destStartValueBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // sourceEndValueBox
            // 
            this.sourceEndValueBox.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.sourceEndValueBox.Location = new System.Drawing.Point(79, 394);
            this.sourceEndValueBox.Maximum = new decimal(new int[] {
            1023,
            0,
            0,
            0});
            this.sourceEndValueBox.MaxNumberControl = null;
            this.sourceEndValueBox.MinNumberControl = null;
            this.sourceEndValueBox.Name = "sourceEndValueBox";
            this.sourceEndValueBox.Size = new System.Drawing.Size(45, 23);
            this.sourceEndValueBox.TabIndex = 79;
            this.sourceEndValueBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // sourceStartValueBox
            // 
            this.sourceStartValueBox.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.sourceStartValueBox.Location = new System.Drawing.Point(12, 394);
            this.sourceStartValueBox.Maximum = new decimal(new int[] {
            1023,
            0,
            0,
            0});
            this.sourceStartValueBox.MaxNumberControl = null;
            this.sourceStartValueBox.MinNumberControl = null;
            this.sourceStartValueBox.Name = "sourceStartValueBox";
            this.sourceStartValueBox.Size = new System.Drawing.Size(45, 23);
            this.sourceStartValueBox.TabIndex = 78;
            this.sourceStartValueBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // destSearchBox
            // 
            this.destSearchBox.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.destSearchBox.Location = new System.Drawing.Point(233, 339);
            this.destSearchBox.MaxLength = 6;
            this.destSearchBox.Name = "destSearchBox";
            this.destSearchBox.Size = new System.Drawing.Size(112, 23);
            this.destSearchBox.TabIndex = 13;
            // 
            // sourceSearchBox
            // 
            this.sourceSearchBox.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.sourceSearchBox.Location = new System.Drawing.Point(12, 339);
            this.sourceSearchBox.MaxLength = 6;
            this.sourceSearchBox.Name = "sourceSearchBox";
            this.sourceSearchBox.Size = new System.Drawing.Size(112, 23);
            this.sourceSearchBox.TabIndex = 11;
            // 
            // MoveUnits
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(357, 524);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.destCancelButton);
            this.Controls.Add(this.destEndValueBox);
            this.Controls.Add(this.destSelectButton);
            this.Controls.Add(this.destStartValueBox);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.sourceCancelButton);
            this.Controls.Add(this.sourceEndValueBox);
            this.Controls.Add(this.sourceSelectButton);
            this.Controls.Add(this.sourceStartValueBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ExchangeButton);
            this.Controls.Add(this.destSearchButton);
            this.Controls.Add(this.destSearchBox);
            this.Controls.Add(this.sourceSearchButton);
            this.Controls.Add(this.sourceSearchBox);
            this.Controls.Add(this.destCountText);
            this.Controls.Add(this.sourceCountText);
            this.Controls.Add(this.destUnitListBox);
            this.Controls.Add(this.sourceUnitListBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "MoveUnits";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "교환";
            ((System.ComponentModel.ISupportInitialize)(this.destEndValueBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.destStartValueBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sourceEndValueBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sourceStartValueBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckedListBox sourceUnitListBox;
        private System.Windows.Forms.CheckedListBox destUnitListBox;
        private System.Windows.Forms.Label sourceCountText;
        private System.Windows.Forms.Label destCountText;
        private System.Windows.Forms.Button sourceSearchButton;
        private TextBoxControl sourceSearchBox;
        private System.Windows.Forms.Button destSearchButton;
        private TextBoxControl destSearchBox;
        private System.Windows.Forms.Button ExchangeButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button sourceCancelButton;
        private NumericControl sourceEndValueBox;
        private NumericControl sourceStartValueBox;
        private System.Windows.Forms.Button sourceSelectButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button destCancelButton;
        private NumericControl destEndValueBox;
        private NumericControl destStartValueBox;
        private System.Windows.Forms.Button destSelectButton;
        private System.Windows.Forms.Button CancelButton;
    }
}