namespace ClinicMesbah
{
    partial class Lablatory
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Lablatory));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.RightPanelWithBorder = new MesbahComponent.PanelWithBorder(this.components);
            this.grdIntermittenc = new System.Windows.Forms.DataGridView();
            this.CustomerCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IDIntermittence = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CodeCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SendSMSPanelWithBorder = new MesbahComponent.PanelWithBorder(this.components);
            this.menuStrip2 = new System.Windows.Forms.MenuStrip();
            this.MenuTop4ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuTop3ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel2 = new System.Windows.Forms.Panel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.btnNextPatiant = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.panel5 = new System.Windows.Forms.Panel();
            this.grdDocuments = new System.Windows.Forms.DataGridView();
            this.buttonToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.button3 = new System.Windows.Forms.Button();
            this.RightPanelWithBorder.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdIntermittenc)).BeginInit();
            this.SendSMSPanelWithBorder.SuspendLayout();
            this.menuStrip2.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdDocuments)).BeginInit();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Interval = 3000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // RightPanelWithBorder
            // 
            this.RightPanelWithBorder.BorderColor = System.Drawing.Color.Black;
            this.RightPanelWithBorder.BorderSize = 1;
            this.RightPanelWithBorder.Controls.Add(this.grdIntermittenc);
            this.RightPanelWithBorder.Controls.Add(this.SendSMSPanelWithBorder);
            this.RightPanelWithBorder.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            this.RightPanelWithBorder.Location = new System.Drawing.Point(1, 0);
            this.RightPanelWithBorder.Name = "RightPanelWithBorder";
            this.RightPanelWithBorder.Padding = new System.Windows.Forms.Padding(1, 0, 0, 0);
            this.RightPanelWithBorder.Size = new System.Drawing.Size(331, 733);
            this.RightPanelWithBorder.TabIndex = 19;
            // 
            // grdIntermittenc
            // 
            this.grdIntermittenc.AllowUserToAddRows = false;
            this.grdIntermittenc.AllowUserToDeleteRows = false;
            this.grdIntermittenc.AllowUserToResizeColumns = false;
            this.grdIntermittenc.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("B Nazanin", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.grdIntermittenc.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.grdIntermittenc.BackgroundColor = System.Drawing.Color.White;
            this.grdIntermittenc.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.grdIntermittenc.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.grdIntermittenc.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("B Nazanin", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdIntermittenc.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.grdIntermittenc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdIntermittenc.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CustomerCol,
            this.IDIntermittence,
            this.CodeCol});
            this.grdIntermittenc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdIntermittenc.EnableHeadersVisualStyles = false;
            this.grdIntermittenc.Location = new System.Drawing.Point(1, 77);
            this.grdIntermittenc.MultiSelect = false;
            this.grdIntermittenc.Name = "grdIntermittenc";
            this.grdIntermittenc.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdIntermittenc.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.grdIntermittenc.RowHeadersVisible = false;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("B Nazanin", 12.25F);
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.SkyBlue;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black;
            this.grdIntermittenc.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.grdIntermittenc.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdIntermittenc.Size = new System.Drawing.Size(330, 656);
            this.grdIntermittenc.TabIndex = 4;
            this.grdIntermittenc.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdIntermittenc_CellClick);
            // 
            // CustomerCol
            // 
            this.CustomerCol.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.CustomerCol.DataPropertyName = "CustomerCol";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.CustomerCol.DefaultCellStyle = dataGridViewCellStyle3;
            this.CustomerCol.HeaderText = " بیمار";
            this.CustomerCol.MinimumWidth = 10;
            this.CustomerCol.Name = "CustomerCol";
            this.CustomerCol.ReadOnly = true;
            this.CustomerCol.Width = 210;
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
            this.CodeCol.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.CodeCol.DataPropertyName = "CodeCol";
            this.CodeCol.HeaderText = "کد ملی";
            this.CodeCol.MinimumWidth = 40;
            this.CodeCol.Name = "CodeCol";
            this.CodeCol.ReadOnly = true;
            this.CodeCol.Width = 120;
            // 
            // SendSMSPanelWithBorder
            // 
            this.SendSMSPanelWithBorder.BorderColor = System.Drawing.Color.Black;
            this.SendSMSPanelWithBorder.BorderSize = 1;
            this.SendSMSPanelWithBorder.Controls.Add(this.menuStrip2);
            this.SendSMSPanelWithBorder.Controls.Add(this.panel2);
            this.SendSMSPanelWithBorder.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
            this.SendSMSPanelWithBorder.Dock = System.Windows.Forms.DockStyle.Top;
            this.SendSMSPanelWithBorder.Location = new System.Drawing.Point(1, 0);
            this.SendSMSPanelWithBorder.Name = "SendSMSPanelWithBorder";
            this.SendSMSPanelWithBorder.Padding = new System.Windows.Forms.Padding(0, 1, 0, 0);
            this.SendSMSPanelWithBorder.Size = new System.Drawing.Size(330, 77);
            this.SendSMSPanelWithBorder.TabIndex = 3;
            // 
            // menuStrip2
            // 
            this.menuStrip2.Font = new System.Drawing.Font("B Yekan", 9.75F);
            this.menuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuTop4ToolStripMenuItem,
            this.MenuTop3ToolStripMenuItem});
            this.menuStrip2.Location = new System.Drawing.Point(0, 1);
            this.menuStrip2.Name = "menuStrip2";
            this.menuStrip2.Padding = new System.Windows.Forms.Padding(3, 0, 0, 2);
            this.menuStrip2.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.menuStrip2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.menuStrip2.Size = new System.Drawing.Size(330, 26);
            this.menuStrip2.TabIndex = 4;
            this.menuStrip2.Text = "menuStrip2";
            // 
            // MenuTop4ToolStripMenuItem
            // 
            this.MenuTop4ToolStripMenuItem.CheckOnClick = true;
            this.MenuTop4ToolStripMenuItem.Name = "MenuTop4ToolStripMenuItem";
            this.MenuTop4ToolStripMenuItem.Size = new System.Drawing.Size(100, 24);
            this.MenuTop4ToolStripMenuItem.Text = "نسخه ی آزمایش";
            this.MenuTop4ToolStripMenuItem.Click += new System.EventHandler(this.MenuTop4ToolStripMenuItem_Click);
            this.MenuTop4ToolStripMenuItem.MouseEnter += new System.EventHandler(this.MenuTop4ToolStripMenuItem_MouseEnter);
            this.MenuTop4ToolStripMenuItem.MouseLeave += new System.EventHandler(this.MenuTop4ToolStripMenuItem_MouseLeave);
            // 
            // MenuTop3ToolStripMenuItem
            // 
            this.MenuTop3ToolStripMenuItem.CheckOnClick = true;
            this.MenuTop3ToolStripMenuItem.Margin = new System.Windows.Forms.Padding(2, 0, 0, 0);
            this.MenuTop3ToolStripMenuItem.Name = "MenuTop3ToolStripMenuItem";
            this.MenuTop3ToolStripMenuItem.Size = new System.Drawing.Size(85, 24);
            this.MenuTop3ToolStripMenuItem.Text = "خطای آزمایش";
            this.MenuTop3ToolStripMenuItem.Click += new System.EventHandler(this.MenuTop3ToolStripMenuItem_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.button3);
            this.panel2.Controls.Add(this.textBox1);
            this.panel2.Location = new System.Drawing.Point(0, 27);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(3);
            this.panel2.Size = new System.Drawing.Size(330, 50);
            this.panel2.TabIndex = 2;
            // 
            // textBox1
            // 
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Font = new System.Drawing.Font("B Nazanin", 14.25F);
            this.textBox1.Location = new System.Drawing.Point(85, 10);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(195, 29);
            this.textBox1.TabIndex = 8;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            this.textBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.BackColor = System.Drawing.Color.SteelBlue;
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("B Nazanin", 11.25F, System.Drawing.FontStyle.Bold);
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(1133, 440);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(95, 38);
            this.button1.TabIndex = 20;
            this.button1.Text = "ثبت";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnNextPatiant
            // 
            this.btnNextPatiant.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNextPatiant.BackColor = System.Drawing.Color.SteelBlue;
            this.btnNextPatiant.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNextPatiant.FlatAppearance.BorderSize = 0;
            this.btnNextPatiant.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNextPatiant.Font = new System.Drawing.Font("B Nazanin", 11.25F, System.Drawing.FontStyle.Bold);
            this.btnNextPatiant.ForeColor = System.Drawing.Color.White;
            this.btnNextPatiant.Location = new System.Drawing.Point(1133, 493);
            this.btnNextPatiant.Name = "btnNextPatiant";
            this.btnNextPatiant.Size = new System.Drawing.Size(95, 38);
            this.btnNextPatiant.TabIndex = 21;
            this.btnNextPatiant.Text = "بیمار بعدی";
            this.btnNextPatiant.UseVisualStyleBackColor = false;
            this.btnNextPatiant.Click += new System.EventHandler(this.btnNextPatiant_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Font = new System.Drawing.Font("B Yekan", 9.75F);
            this.tabControl1.Location = new System.Drawing.Point(341, 411);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(780, 319);
            this.tabControl1.TabIndex = 25;
            this.tabControl1.Selecting += new System.Windows.Forms.TabControlCancelEventHandler(this.tabControl1_Selecting);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.panel1);
            this.tabPage1.Location = new System.Drawing.Point(4, 29);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(772, 286);
            this.tabPage1.TabIndex = 2;
            this.tabPage1.Text = "نتایج  آزمایش";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Location = new System.Drawing.Point(4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(772, 286);
            this.panel1.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.FloralWhite;
            this.tabPage2.Cursor = System.Windows.Forms.Cursors.Default;
            this.tabPage2.Font = new System.Drawing.Font("B Nazanin", 9.75F, System.Drawing.FontStyle.Bold);
            this.tabPage2.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.tabPage2.Location = new System.Drawing.Point(4, 29);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(772, 286);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Tag = "2";
            this.tabPage2.Text = "نسخه آزمایش";
            // 
            // panel5
            // 
            this.panel5.AutoScroll = true;
            this.panel5.Controls.Add(this.grdDocuments);
            this.panel5.Controls.Add(this.tabControl1);
            this.panel5.Controls.Add(this.btnNextPatiant);
            this.panel5.Controls.Add(this.button1);
            this.panel5.Controls.Add(this.RightPanelWithBorder);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1284, 733);
            this.panel5.TabIndex = 23;
            // 
            // grdDocuments
            // 
            this.grdDocuments.AllowUserToAddRows = false;
            this.grdDocuments.AllowUserToDeleteRows = false;
            this.grdDocuments.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grdDocuments.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.grdDocuments.BackgroundColor = System.Drawing.SystemColors.Window;
            this.grdDocuments.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.grdDocuments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdDocuments.ColumnHeadersVisible = false;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdDocuments.DefaultCellStyle = dataGridViewCellStyle6;
            this.grdDocuments.Location = new System.Drawing.Point(342, 12);
            this.grdDocuments.MultiSelect = false;
            this.grdDocuments.Name = "grdDocuments";
            this.grdDocuments.ReadOnly = true;
            this.grdDocuments.RowHeadersVisible = false;
            this.grdDocuments.Size = new System.Drawing.Size(881, 382);
            this.grdDocuments.TabIndex = 24;
            this.grdDocuments.SelectionChanged += new System.EventHandler(this.grdDocuments_SelectionChanged);
            // 
            // buttonToolTip
            // 
            this.buttonToolTip.AutomaticDelay = 10;
            this.buttonToolTip.AutoPopDelay = 10;
            this.buttonToolTip.InitialDelay = 10;
            this.buttonToolTip.ReshowDelay = 2;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.White;
            this.button3.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.ForeColor = System.Drawing.Color.Transparent;
            this.button3.Image = ((System.Drawing.Image)(resources.GetObject("button3.Image")));
            this.button3.Location = new System.Drawing.Point(54, 9);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(34, 31);
            this.button3.TabIndex = 9;
            this.button3.UseVisualStyleBackColor = true;
            this.button3.MouseEnter += new System.EventHandler(this.button3_MouseEnter);
            // 
            // Lablatory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1284, 733);
            this.Controls.Add(this.panel5);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Lablatory";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Tag = "Documents,Intermittence,LabResult";
            this.Text = "آزمایشگاه";
            this.Load += new System.EventHandler(this.Lablatory_Load);
            this.RightPanelWithBorder.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdIntermittenc)).EndInit();
            this.SendSMSPanelWithBorder.ResumeLayout(false);
            this.SendSMSPanelWithBorder.PerformLayout();
            this.menuStrip2.ResumeLayout(false);
            this.menuStrip2.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdDocuments)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private MesbahComponent.PanelWithBorder RightPanelWithBorder;
        private System.Windows.Forms.DataGridView grdIntermittenc;
        private System.Windows.Forms.DataGridViewTextBoxColumn CustomerCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDIntermittence;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodeCol;
        private MesbahComponent.PanelWithBorder SendSMSPanelWithBorder;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnNextPatiant;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.ToolTip buttonToolTip;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.MenuStrip menuStrip2;
        private System.Windows.Forms.ToolStripMenuItem MenuTop4ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MenuTop3ToolStripMenuItem;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.DataGridView grdDocuments;
    }
}