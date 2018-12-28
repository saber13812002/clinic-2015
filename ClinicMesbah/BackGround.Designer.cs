namespace ClinicMesbah
{
    partial class BackGround
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.grdBackGround = new System.Windows.Forms.DataGridView();
            this.DateModified = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NameLabItem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.valueItem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdBackGround)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(569, 389);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.grdBackGround);
            this.groupBox1.Location = new System.Drawing.Point(11, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(548, 366);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // grdBackGround
            // 
            this.grdBackGround.AllowUserToAddRows = false;
            this.grdBackGround.AllowUserToDeleteRows = false;
            this.grdBackGround.AllowUserToResizeColumns = false;
            this.grdBackGround.AllowUserToResizeRows = false;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("B Nazanin", 12.25F);
            this.grdBackGround.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle6;
            this.grdBackGround.BackgroundColor = System.Drawing.Color.White;
            this.grdBackGround.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.grdBackGround.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.grdBackGround.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("B Nazanin", 12.25F);
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdBackGround.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.grdBackGround.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdBackGround.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DateModified,
            this.NameLabItem,
            this.valueItem,
            this.ID});
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdBackGround.DefaultCellStyle = dataGridViewCellStyle8;
            this.grdBackGround.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdBackGround.EnableHeadersVisualStyles = false;
            this.grdBackGround.Location = new System.Drawing.Point(3, 16);
            this.grdBackGround.MultiSelect = false;
            this.grdBackGround.Name = "grdBackGround";
            this.grdBackGround.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdBackGround.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.grdBackGround.RowHeadersVisible = false;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("B Nazanin", 12.25F);
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.Color.SkyBlue;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.Color.Black;
            this.grdBackGround.RowsDefaultCellStyle = dataGridViewCellStyle10;
            this.grdBackGround.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdBackGround.Size = new System.Drawing.Size(542, 347);
            this.grdBackGround.TabIndex = 8;
            // 
            // DateModified
            // 
            this.DateModified.DataPropertyName = "DateModified";
            this.DateModified.FillWeight = 150F;
            this.DateModified.HeaderText = "تاریخ";
            this.DateModified.Name = "DateModified";
            this.DateModified.ReadOnly = true;
            this.DateModified.Width = 150;
            // 
            // NameLabItem
            // 
            this.NameLabItem.DataPropertyName = "NameLabItem";
            this.NameLabItem.FillWeight = 150F;
            this.NameLabItem.HeaderText = "نام آیتم";
            this.NameLabItem.Name = "NameLabItem";
            this.NameLabItem.ReadOnly = true;
            this.NameLabItem.Width = 150;
            // 
            // valueItem
            // 
            this.valueItem.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.valueItem.DataPropertyName = "valueItem";
            this.valueItem.FillWeight = 150F;
            this.valueItem.HeaderText = "مقدار";
            this.valueItem.Name = "valueItem";
            this.valueItem.ReadOnly = true;
            // 
            // ID
            // 
            this.ID.DataPropertyName = "ID";
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.Visible = false;
            // 
            // BackGround
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(569, 389);
            this.Controls.Add(this.panel1);
            this.MaximumSize = new System.Drawing.Size(585, 427);
            this.MinimumSize = new System.Drawing.Size(585, 427);
            this.Name = "BackGround";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "سابقه آزمایش";
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdBackGround)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView grdBackGround;
        private System.Windows.Forms.DataGridViewTextBoxColumn DateModified;
        private System.Windows.Forms.DataGridViewTextBoxColumn NameLabItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn valueItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
    }
}