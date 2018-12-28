namespace ClinicMesbah
{
    partial class IntermittenceSearch
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IntermittenceSearch));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.grdIntermittenc = new System.Windows.Forms.DataGridView();
            this.CustomerCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IDIntermittence = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CodeCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DateModifiedCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TelphoneCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SectionCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StatusCol = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.VisitedCol = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.grdIntermittenc)).BeginInit();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Font = new System.Drawing.Font("B Nazanin", 14.25F);
            this.textBox1.Location = new System.Drawing.Point(267, 17);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(227, 29);
            this.textBox1.TabIndex = 8;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            this.textBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.White;
            this.button3.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.ForeColor = System.Drawing.Color.Transparent;
            this.button3.Image = ((System.Drawing.Image)(resources.GetObject("button3.Image")));
            this.button3.Location = new System.Drawing.Point(244, 16);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(34, 31);
            this.button3.TabIndex = 9;
            this.button3.UseVisualStyleBackColor = true;
            // 
            // grdIntermittenc
            // 
            this.grdIntermittenc.AllowUserToAddRows = false;
            this.grdIntermittenc.AllowUserToDeleteRows = false;
            this.grdIntermittenc.AllowUserToResizeColumns = false;
            this.grdIntermittenc.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("B Nazanin", 12.25F);
            this.grdIntermittenc.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.grdIntermittenc.BackgroundColor = System.Drawing.Color.White;
            this.grdIntermittenc.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.grdIntermittenc.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.grdIntermittenc.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("B Nazanin", 12.25F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdIntermittenc.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.grdIntermittenc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdIntermittenc.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CustomerCol,
            this.IDIntermittence,
            this.CodeCol,
            this.DateModifiedCol,
            this.TelphoneCol,
            this.SectionCol,
            this.StatusCol,
            this.VisitedCol});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdIntermittenc.DefaultCellStyle = dataGridViewCellStyle4;
            this.grdIntermittenc.EnableHeadersVisualStyles = false;
            this.grdIntermittenc.Location = new System.Drawing.Point(16, 66);
            this.grdIntermittenc.MultiSelect = false;
            this.grdIntermittenc.Name = "grdIntermittenc";
            this.grdIntermittenc.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdIntermittenc.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.grdIntermittenc.RowHeadersVisible = false;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("B Nazanin", 12.25F);
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.SkyBlue;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black;
            this.grdIntermittenc.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.grdIntermittenc.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdIntermittenc.Size = new System.Drawing.Size(650, 454);
            this.grdIntermittenc.TabIndex = 10;
            // 
            // CustomerCol
            // 
            this.CustomerCol.DataPropertyName = "CustomerCol";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.CustomerCol.DefaultCellStyle = dataGridViewCellStyle3;
            this.CustomerCol.HeaderText = " بیمار";
            this.CustomerCol.MinimumWidth = 100;
            this.CustomerCol.Name = "CustomerCol";
            this.CustomerCol.ReadOnly = true;
            // 
            // IDIntermittence
            // 
            this.IDIntermittence.DataPropertyName = "IDIntermittence";
            this.IDIntermittence.FillWeight = 5F;
            this.IDIntermittence.HeaderText = "IDIntermittence";
            this.IDIntermittence.Name = "IDIntermittence";
            this.IDIntermittence.Visible = false;
            this.IDIntermittence.Width = 5;
            // 
            // CodeCol
            // 
            this.CodeCol.DataPropertyName = "CodeCol";
            this.CodeCol.HeaderText = "کد ملی";
            this.CodeCol.MinimumWidth = 100;
            this.CodeCol.Name = "CodeCol";
            this.CodeCol.ReadOnly = true;
            // 
            // DateModifiedCol
            // 
            this.DateModifiedCol.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.DateModifiedCol.DataPropertyName = "DateModifiedCol";
            this.DateModifiedCol.FillWeight = 140F;
            this.DateModifiedCol.HeaderText = "نوبت";
            this.DateModifiedCol.MinimumWidth = 140;
            this.DateModifiedCol.Name = "DateModifiedCol";
            // 
            // TelphoneCol
            // 
            this.TelphoneCol.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.TelphoneCol.DataPropertyName = "TelphoneCol";
            this.TelphoneCol.HeaderText = "شماره";
            this.TelphoneCol.MinimumWidth = 100;
            this.TelphoneCol.Name = "TelphoneCol";
            // 
            // SectionCol
            // 
            this.SectionCol.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.SectionCol.DataPropertyName = "SectionCol";
            this.SectionCol.FillWeight = 90F;
            this.SectionCol.HeaderText = "بخش";
            this.SectionCol.MinimumWidth = 90;
            this.SectionCol.Name = "SectionCol";
            this.SectionCol.Width = 90;
            // 
            // StatusCol
            // 
            this.StatusCol.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.StatusCol.DataPropertyName = "StatusCol";
            this.StatusCol.FillWeight = 20F;
            this.StatusCol.HeaderText = "قطعی";
            this.StatusCol.Name = "StatusCol";
            this.StatusCol.ReadOnly = true;
            this.StatusCol.Width = 46;
            // 
            // VisitedCol
            // 
            this.VisitedCol.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.VisitedCol.DataPropertyName = "VisitedCol";
            this.VisitedCol.FillWeight = 20F;
            this.VisitedCol.HeaderText = "ویزیت";
            this.VisitedCol.Name = "VisitedCol";
            this.VisitedCol.ReadOnly = true;
            this.VisitedCol.Width = 48;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Font = new System.Drawing.Font("B Yekan", 9.75F);
            this.radioButton1.Location = new System.Drawing.Point(316, 17);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(114, 24);
            this.radioButton1.TabIndex = 11;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "نام یا نام خانوادگی";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.Visible = false;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Font = new System.Drawing.Font("B Yekan", 9.75F);
            this.radioButton2.Location = new System.Drawing.Point(143, 17);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(86, 24);
            this.radioButton2.TabIndex = 12;
            this.radioButton2.Text = "شماره تماس";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.Visible = false;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Font = new System.Drawing.Font("B Yekan", 9.75F);
            this.radioButton3.Location = new System.Drawing.Point(245, 17);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(59, 24);
            this.radioButton3.TabIndex = 13;
            this.radioButton3.Text = "کد ملی";
            this.radioButton3.UseVisualStyleBackColor = true;
            this.radioButton3.Visible = false;
            this.radioButton3.CheckedChanged += new System.EventHandler(this.radioButton3_CheckedChanged);
            // 
            // IntermittenceSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(682, 542);
            this.Controls.Add(this.radioButton3);
            this.Controls.Add(this.radioButton2);
            this.Controls.Add(this.radioButton1);
            this.Controls.Add(this.grdIntermittenc);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.textBox1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(698, 580);
            this.MinimumSize = new System.Drawing.Size(698, 580);
            this.Name = "IntermittenceSearch";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "جستجوی نوبت";
            this.Load += new System.EventHandler(this.IntermittenceSearch_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdIntermittenc)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.DataGridView grdIntermittenc;
        private System.Windows.Forms.DataGridViewTextBoxColumn CustomerCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDIntermittence;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodeCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn DateModifiedCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn TelphoneCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn SectionCol;
        private System.Windows.Forms.DataGridViewCheckBoxColumn StatusCol;
        private System.Windows.Forms.DataGridViewCheckBoxColumn VisitedCol;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton3;
    }
}