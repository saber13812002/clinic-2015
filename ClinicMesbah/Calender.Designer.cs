namespace ClinicMesbah
{
    partial class Calender
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            AmirCalendar.FarsiDate farsiDate2 = new AmirCalendar.FarsiDate();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.MenuItem1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItem2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItem4ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItem3ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DataGridView = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ShiftName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Active = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.StartTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EndTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ShiftID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DayOfWeek = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label2 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtEndSobh = new System.Windows.Forms.TextBox();
            this.btnAdd2 = new System.Windows.Forms.Button();
            this.cmbShift = new System.Windows.Forms.ComboBox();
            this.txtStartSobh = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnNew = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbDayOfWeek = new System.Windows.Forms.ComboBox();
            this.chEnabled = new System.Windows.Forms.CheckBox();
            this.lblMonth = new System.Windows.Forms.Label();
            this.btnCancel2 = new System.Windows.Forms.Button();
            this.pnlWeeklyHour = new System.Windows.Forms.Panel();
            this.farsiCalendar1 = new AmirCalendar.FarsiCalendar();
            this.pnlHoliday = new System.Windows.Forms.Panel();
            this.pnlSMS = new System.Windows.Forms.Panel();
            this.txtText = new System.Windows.Forms.TextBox();
            this.btnDeleteSMS = new System.Windows.Forms.Button();
            this.btnNewSMS = new System.Windows.Forms.Button();
            this.btnSaveSMS = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.grdSMS = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IDSection = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView)).BeginInit();
            this.pnlWeeklyHour.SuspendLayout();
            this.pnlHoliday.SuspendLayout();
            this.pnlSMS.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdSMS)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.Gainsboro;
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.Right;
            this.menuStrip1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItem1ToolStripMenuItem,
            this.MenuItem2ToolStripMenuItem,
            this.MenuItem4ToolStripMenuItem,
            this.MenuItem3ToolStripMenuItem});
            this.menuStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.VerticalStackWithOverflow;
            this.menuStrip1.Location = new System.Drawing.Point(690, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(0, 1, 0, 0);
            this.menuStrip1.Size = new System.Drawing.Size(28, 484);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.TextDirection = System.Windows.Forms.ToolStripTextDirection.Vertical270;
            // 
            // MenuItem1ToolStripMenuItem
            // 
            this.MenuItem1ToolStripMenuItem.Checked = true;
            this.MenuItem1ToolStripMenuItem.CheckOnClick = true;
            this.MenuItem1ToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.MenuItem1ToolStripMenuItem.Margin = new System.Windows.Forms.Padding(0, 0, -1, 0);
            this.MenuItem1ToolStripMenuItem.Name = "MenuItem1ToolStripMenuItem";
            this.MenuItem1ToolStripMenuItem.Size = new System.Drawing.Size(28, 134);
            this.MenuItem1ToolStripMenuItem.Text = "ساعت کاری ایام هفته";
            this.MenuItem1ToolStripMenuItem.Click += new System.EventHandler(this.MenuItem1ToolStripMenuItem_Click);
            this.MenuItem1ToolStripMenuItem.MouseEnter += new System.EventHandler(this.MenuItem1ToolStripMenuItem_MouseEnter);
            this.MenuItem1ToolStripMenuItem.MouseLeave += new System.EventHandler(this.MenuItem1ToolStripMenuItem_MouseLeave);
            // 
            // MenuItem2ToolStripMenuItem
            // 
            this.MenuItem2ToolStripMenuItem.CheckOnClick = true;
            this.MenuItem2ToolStripMenuItem.Margin = new System.Windows.Forms.Padding(0, 0, -1, 0);
            this.MenuItem2ToolStripMenuItem.Name = "MenuItem2ToolStripMenuItem";
            this.MenuItem2ToolStripMenuItem.Size = new System.Drawing.Size(28, 56);
            this.MenuItem2ToolStripMenuItem.Text = "تعطیلات";
            this.MenuItem2ToolStripMenuItem.Click += new System.EventHandler(this.MenuItem2ToolStripMenuItem_Click);
            this.MenuItem2ToolStripMenuItem.MouseEnter += new System.EventHandler(this.MenuItem1ToolStripMenuItem_MouseEnter);
            this.MenuItem2ToolStripMenuItem.MouseLeave += new System.EventHandler(this.MenuItem1ToolStripMenuItem_MouseLeave);
            // 
            // MenuItem4ToolStripMenuItem
            // 
            this.MenuItem4ToolStripMenuItem.CheckOnClick = true;
            this.MenuItem4ToolStripMenuItem.Margin = new System.Windows.Forms.Padding(0, 0, -1, 0);
            this.MenuItem4ToolStripMenuItem.Name = "MenuItem4ToolStripMenuItem";
            this.MenuItem4ToolStripMenuItem.Size = new System.Drawing.Size(28, 4);
            // 
            // MenuItem3ToolStripMenuItem
            // 
            this.MenuItem3ToolStripMenuItem.Name = "MenuItem3ToolStripMenuItem";
            this.MenuItem3ToolStripMenuItem.Size = new System.Drawing.Size(27, 45);
            this.MenuItem3ToolStripMenuItem.Text = "پیامک";
            this.MenuItem3ToolStripMenuItem.Click += new System.EventHandler(this.پیامکToolStripMenuItem_Click);
            this.MenuItem3ToolStripMenuItem.MouseEnter += new System.EventHandler(this.MenuItem1ToolStripMenuItem_MouseEnter);
            this.MenuItem3ToolStripMenuItem.MouseLeave += new System.EventHandler(this.MenuItem1ToolStripMenuItem_MouseLeave);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "ID";
            this.dataGridViewTextBoxColumn1.HeaderText = "ID";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Visible = false;
            this.dataGridViewTextBoxColumn1.Width = 5;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "DN";
            this.dataGridViewTextBoxColumn2.HeaderText = "روز";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 170;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "ShiftName";
            this.dataGridViewTextBoxColumn3.FillWeight = 5F;
            this.dataGridViewTextBoxColumn3.HeaderText = "شیفت";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.dataGridViewTextBoxColumn3.Width = 150;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "StartTime";
            this.dataGridViewTextBoxColumn4.HeaderText = "ساعت شروع";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "EndTime";
            this.dataGridViewTextBoxColumn5.HeaderText = "ساعت پایان";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "ShiftID";
            this.dataGridViewTextBoxColumn6.HeaderText = "جمعه";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.Visible = false;
            this.dataGridViewTextBoxColumn6.Width = 70;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "DayOfWeek";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.dataGridViewTextBoxColumn7.DefaultCellStyle = dataGridViewCellStyle9;
            this.dataGridViewTextBoxColumn7.FillWeight = 5F;
            this.dataGridViewTextBoxColumn7.HeaderText = "روز";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            this.dataGridViewTextBoxColumn7.Visible = false;
            this.dataGridViewTextBoxColumn7.Width = 150;
            // 
            // DataGridView
            // 
            this.DataGridView.AllowUserToAddRows = false;
            this.DataGridView.AllowUserToDeleteRows = false;
            this.DataGridView.AllowUserToResizeColumns = false;
            this.DataGridView.AllowUserToResizeRows = false;
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.DataGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle10;
            this.DataGridView.BackgroundColor = System.Drawing.Color.White;
            this.DataGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.DataGridView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.DataGridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle11.BackColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle11;
            this.DataGridView.ColumnHeadersHeight = 30;
            this.DataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.DN,
            this.ShiftName,
            this.Active,
            this.StartTime,
            this.EndTime,
            this.ShiftID,
            this.DayOfWeek});
            this.DataGridView.EnableHeadersVisualStyles = false;
            this.DataGridView.Location = new System.Drawing.Point(36, 132);
            this.DataGridView.Name = "DataGridView";
            this.DataGridView.ReadOnly = true;
            this.DataGridView.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.DataGridView.RowHeadersVisible = false;
            dataGridViewCellStyle13.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle13.SelectionBackColor = System.Drawing.Color.SkyBlue;
            dataGridViewCellStyle13.SelectionForeColor = System.Drawing.Color.Black;
            this.DataGridView.RowsDefaultCellStyle = dataGridViewCellStyle13;
            this.DataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DataGridView.Size = new System.Drawing.Size(625, 346);
            this.DataGridView.TabIndex = 8;
            this.DataGridView.SelectionChanged += new System.EventHandler(this.DataGridView_SelectionChanged_1);
            // 
            // ID
            // 
            this.ID.DataPropertyName = "ID";
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Visible = false;
            this.ID.Width = 5;
            // 
            // DN
            // 
            this.DN.DataPropertyName = "DN";
            this.DN.HeaderText = "روز";
            this.DN.Name = "DN";
            this.DN.ReadOnly = true;
            this.DN.Width = 170;
            // 
            // ShiftName
            // 
            this.ShiftName.DataPropertyName = "ShiftName";
            this.ShiftName.FillWeight = 5F;
            this.ShiftName.HeaderText = "شیفت";
            this.ShiftName.Name = "ShiftName";
            this.ShiftName.ReadOnly = true;
            this.ShiftName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.ShiftName.Width = 150;
            // 
            // Active
            // 
            this.Active.DataPropertyName = "Active";
            this.Active.FalseValue = "0";
            this.Active.HeaderText = "فعال";
            this.Active.Name = "Active";
            this.Active.ReadOnly = true;
            this.Active.TrueValue = "1";
            // 
            // StartTime
            // 
            this.StartTime.DataPropertyName = "StartTime";
            this.StartTime.HeaderText = "ساعت شروع";
            this.StartTime.Name = "StartTime";
            this.StartTime.ReadOnly = true;
            // 
            // EndTime
            // 
            this.EndTime.DataPropertyName = "EndTime";
            this.EndTime.HeaderText = "ساعت پایان";
            this.EndTime.Name = "EndTime";
            this.EndTime.ReadOnly = true;
            // 
            // ShiftID
            // 
            this.ShiftID.DataPropertyName = "ShiftID";
            this.ShiftID.HeaderText = "جمعه";
            this.ShiftID.Name = "ShiftID";
            this.ShiftID.ReadOnly = true;
            this.ShiftID.Visible = false;
            this.ShiftID.Width = 70;
            // 
            // DayOfWeek
            // 
            this.DayOfWeek.DataPropertyName = "DayOfWeek";
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.DayOfWeek.DefaultCellStyle = dataGridViewCellStyle12;
            this.DayOfWeek.FillWeight = 5F;
            this.DayOfWeek.HeaderText = "روز";
            this.DayOfWeek.Name = "DayOfWeek";
            this.DayOfWeek.ReadOnly = true;
            this.DayOfWeek.Visible = false;
            this.DayOfWeek.Width = 150;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(477, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 24);
            this.label2.TabIndex = 10;
            this.label2.Text = "نام شیفت:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(95, 21);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(38, 24);
            this.label8.TabIndex = 12;
            this.label8.Text = "پایان:";
            // 
            // txtEndSobh
            // 
            this.txtEndSobh.Location = new System.Drawing.Point(12, 18);
            this.txtEndSobh.Name = "txtEndSobh";
            this.txtEndSobh.Size = new System.Drawing.Size(77, 31);
            this.txtEndSobh.TabIndex = 4;
            // 
            // btnAdd2
            // 
            this.btnAdd2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd2.BackColor = System.Drawing.Color.SteelBlue;
            this.btnAdd2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAdd2.FlatAppearance.BorderSize = 0;
            this.btnAdd2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd2.Font = new System.Drawing.Font("B Nazanin", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnAdd2.ForeColor = System.Drawing.Color.White;
            this.btnAdd2.Location = new System.Drawing.Point(213, 77);
            this.btnAdd2.Name = "btnAdd2";
            this.btnAdd2.Size = new System.Drawing.Size(71, 32);
            this.btnAdd2.TabIndex = 5;
            this.btnAdd2.Text = "ثبت";
            this.btnAdd2.UseVisualStyleBackColor = false;
            this.btnAdd2.Click += new System.EventHandler(this.btnAdd2_Click);
            // 
            // cmbShift
            // 
            this.cmbShift.Enabled = false;
            this.cmbShift.FormattingEnabled = true;
            this.cmbShift.Location = new System.Drawing.Point(350, 17);
            this.cmbShift.Name = "cmbShift";
            this.cmbShift.Size = new System.Drawing.Size(121, 32);
            this.cmbShift.TabIndex = 1;
            // 
            // txtStartSobh
            // 
            this.txtStartSobh.Location = new System.Drawing.Point(139, 18);
            this.txtStartSobh.Name = "txtStartSobh";
            this.txtStartSobh.Size = new System.Drawing.Size(77, 31);
            this.txtStartSobh.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(222, 21);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 24);
            this.label4.TabIndex = 11;
            this.label4.Text = "شروع:";
            // 
            // btnNew
            // 
            this.btnNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNew.BackColor = System.Drawing.Color.SteelBlue;
            this.btnNew.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNew.FlatAppearance.BorderSize = 0;
            this.btnNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNew.Font = new System.Drawing.Font("B Nazanin", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnNew.ForeColor = System.Drawing.Color.White;
            this.btnNew.Location = new System.Drawing.Point(125, 77);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(71, 32);
            this.btnNew.TabIndex = 6;
            this.btnNew.Text = "جدید";
            this.btnNew.UseVisualStyleBackColor = false;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(660, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(28, 24);
            this.label1.TabIndex = 9;
            this.label1.Text = "روز:";
            // 
            // cmbDayOfWeek
            // 
            this.cmbDayOfWeek.Enabled = false;
            this.cmbDayOfWeek.FormattingEnabled = true;
            this.cmbDayOfWeek.Location = new System.Drawing.Point(542, 17);
            this.cmbDayOfWeek.Name = "cmbDayOfWeek";
            this.cmbDayOfWeek.Size = new System.Drawing.Size(121, 32);
            this.cmbDayOfWeek.TabIndex = 0;
            // 
            // chEnabled
            // 
            this.chEnabled.AutoSize = true;
            this.chEnabled.Location = new System.Drawing.Point(267, 19);
            this.chEnabled.Name = "chEnabled";
            this.chEnabled.Size = new System.Drawing.Size(69, 28);
            this.chEnabled.TabIndex = 2;
            this.chEnabled.Text = "غیرفعال";
            this.chEnabled.UseVisualStyleBackColor = true;
            // 
            // lblMonth
            // 
            this.lblMonth.AutoSize = true;
            this.lblMonth.Location = new System.Drawing.Point(609, 77);
            this.lblMonth.Name = "lblMonth";
            this.lblMonth.Size = new System.Drawing.Size(18, 24);
            this.lblMonth.TabIndex = 203;
            this.lblMonth.Text = "اااا";
            this.lblMonth.Visible = false;
            // 
            // btnCancel2
            // 
            this.btnCancel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel2.BackColor = System.Drawing.Color.SteelBlue;
            this.btnCancel2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel2.FlatAppearance.BorderSize = 0;
            this.btnCancel2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel2.Font = new System.Drawing.Font("B Nazanin", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnCancel2.ForeColor = System.Drawing.Color.White;
            this.btnCancel2.Location = new System.Drawing.Point(36, 77);
            this.btnCancel2.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.btnCancel2.Name = "btnCancel2";
            this.btnCancel2.Size = new System.Drawing.Size(71, 32);
            this.btnCancel2.TabIndex = 7;
            this.btnCancel2.Text = "حذف";
            this.btnCancel2.UseVisualStyleBackColor = false;
            this.btnCancel2.Click += new System.EventHandler(this.btnCancel2_Click);
            // 
            // pnlWeeklyHour
            // 
            this.pnlWeeklyHour.Controls.Add(this.btnCancel2);
            this.pnlWeeklyHour.Controls.Add(this.lblMonth);
            this.pnlWeeklyHour.Controls.Add(this.chEnabled);
            this.pnlWeeklyHour.Controls.Add(this.cmbDayOfWeek);
            this.pnlWeeklyHour.Controls.Add(this.label1);
            this.pnlWeeklyHour.Controls.Add(this.btnNew);
            this.pnlWeeklyHour.Controls.Add(this.label4);
            this.pnlWeeklyHour.Controls.Add(this.txtStartSobh);
            this.pnlWeeklyHour.Controls.Add(this.cmbShift);
            this.pnlWeeklyHour.Controls.Add(this.btnAdd2);
            this.pnlWeeklyHour.Controls.Add(this.txtEndSobh);
            this.pnlWeeklyHour.Controls.Add(this.label8);
            this.pnlWeeklyHour.Controls.Add(this.label2);
            this.pnlWeeklyHour.Controls.Add(this.DataGridView);
            this.pnlWeeklyHour.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.pnlWeeklyHour.Location = new System.Drawing.Point(0, 0);
            this.pnlWeeklyHour.Name = "pnlWeeklyHour";
            this.pnlWeeklyHour.Size = new System.Drawing.Size(691, 484);
            this.pnlWeeklyHour.TabIndex = 1;
            this.pnlWeeklyHour.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlWeeklyHour_Paint);
            // 
            // farsiCalendar1
            // 
            this.farsiCalendar1.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.farsiCalendar1.Location = new System.Drawing.Point(103, 12);
            this.farsiCalendar1.Name = "farsiCalendar1";
            this.farsiCalendar1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.farsiCalendar1.Size = new System.Drawing.Size(500, 300);
            this.farsiCalendar1.TabIndex = 0;
            farsiDate2.FarsiSelectedDate = "1393/09/19";
            farsiDate2.Mode = AmirCalendar.ControlType.MonthCalendar;
            farsiDate2.Theme = AmirCalendar.CalendarTheme.Gold;
            this.farsiCalendar1.Value = farsiDate2;
            this.farsiCalendar1.DateChanged += new AmirCalendar.DateChangedHandler(this.farsiCalendar1_DateChanged_1);
            this.farsiCalendar1.DockChanged += new System.EventHandler(this.farsiCalendar1_DockChanged);
            // 
            // pnlHoliday
            // 
            this.pnlHoliday.AutoSize = true;
            this.pnlHoliday.Controls.Add(this.farsiCalendar1);
            this.pnlHoliday.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlHoliday.Location = new System.Drawing.Point(0, 0);
            this.pnlHoliday.Name = "pnlHoliday";
            this.pnlHoliday.Size = new System.Drawing.Size(718, 484);
            this.pnlHoliday.TabIndex = 2;
            this.pnlHoliday.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlDailyHour_Paint);
            // 
            // pnlSMS
            // 
            this.pnlSMS.Controls.Add(this.txtText);
            this.pnlSMS.Controls.Add(this.btnDeleteSMS);
            this.pnlSMS.Controls.Add(this.btnNewSMS);
            this.pnlSMS.Controls.Add(this.btnSaveSMS);
            this.pnlSMS.Controls.Add(this.label5);
            this.pnlSMS.Controls.Add(this.grdSMS);
            this.pnlSMS.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlSMS.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.pnlSMS.Location = new System.Drawing.Point(0, 0);
            this.pnlSMS.Name = "pnlSMS";
            this.pnlSMS.Size = new System.Drawing.Size(718, 484);
            this.pnlSMS.TabIndex = 205;
            this.pnlSMS.Visible = false;
            // 
            // txtText
            // 
            this.txtText.Location = new System.Drawing.Point(47, 31);
            this.txtText.Multiline = true;
            this.txtText.Name = "txtText";
            this.txtText.Size = new System.Drawing.Size(576, 81);
            this.txtText.TabIndex = 19;
            // 
            // btnDeleteSMS
            // 
            this.btnDeleteSMS.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDeleteSMS.BackColor = System.Drawing.Color.SteelBlue;
            this.btnDeleteSMS.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDeleteSMS.FlatAppearance.BorderSize = 0;
            this.btnDeleteSMS.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteSMS.Font = new System.Drawing.Font("B Nazanin", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnDeleteSMS.ForeColor = System.Drawing.Color.White;
            this.btnDeleteSMS.Location = new System.Drawing.Point(75, 121);
            this.btnDeleteSMS.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.btnDeleteSMS.Name = "btnDeleteSMS";
            this.btnDeleteSMS.Size = new System.Drawing.Size(71, 32);
            this.btnDeleteSMS.TabIndex = 15;
            this.btnDeleteSMS.Text = "حذف";
            this.btnDeleteSMS.UseVisualStyleBackColor = false;
            this.btnDeleteSMS.Click += new System.EventHandler(this.btnDeleteSMS_Click);
            // 
            // btnNewSMS
            // 
            this.btnNewSMS.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNewSMS.BackColor = System.Drawing.Color.SteelBlue;
            this.btnNewSMS.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNewSMS.FlatAppearance.BorderSize = 0;
            this.btnNewSMS.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNewSMS.Font = new System.Drawing.Font("B Nazanin", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnNewSMS.ForeColor = System.Drawing.Color.White;
            this.btnNewSMS.Location = new System.Drawing.Point(164, 121);
            this.btnNewSMS.Name = "btnNewSMS";
            this.btnNewSMS.Size = new System.Drawing.Size(71, 32);
            this.btnNewSMS.TabIndex = 14;
            this.btnNewSMS.Text = "جدید";
            this.btnNewSMS.UseVisualStyleBackColor = false;
            this.btnNewSMS.Click += new System.EventHandler(this.btnNewSMS_Click);
            // 
            // btnSaveSMS
            // 
            this.btnSaveSMS.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveSMS.BackColor = System.Drawing.Color.SteelBlue;
            this.btnSaveSMS.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSaveSMS.FlatAppearance.BorderSize = 0;
            this.btnSaveSMS.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveSMS.Font = new System.Drawing.Font("B Nazanin", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnSaveSMS.ForeColor = System.Drawing.Color.White;
            this.btnSaveSMS.Location = new System.Drawing.Point(252, 121);
            this.btnSaveSMS.Name = "btnSaveSMS";
            this.btnSaveSMS.Size = new System.Drawing.Size(71, 32);
            this.btnSaveSMS.TabIndex = 13;
            this.btnSaveSMS.Text = "ثبت";
            this.btnSaveSMS.UseVisualStyleBackColor = false;
            this.btnSaveSMS.Click += new System.EventHandler(this.btnSaveSMS_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(632, 31);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(33, 24);
            this.label5.TabIndex = 18;
            this.label5.Text = "متن:";
            // 
            // grdSMS
            // 
            this.grdSMS.AllowUserToAddRows = false;
            this.grdSMS.AllowUserToDeleteRows = false;
            this.grdSMS.AllowUserToResizeColumns = false;
            this.grdSMS.AllowUserToResizeRows = false;
            dataGridViewCellStyle14.BackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle14.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.grdSMS.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle14;
            this.grdSMS.BackgroundColor = System.Drawing.Color.White;
            this.grdSMS.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.grdSMS.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.grdSMS.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle15.BackColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle15.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle15.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle15.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle15.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdSMS.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle15;
            this.grdSMS.ColumnHeadersHeight = 30;
            this.grdSMS.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn8,
            this.dataGridViewTextBoxColumn12,
            this.IDSection});
            this.grdSMS.EnableHeadersVisualStyles = false;
            this.grdSMS.Location = new System.Drawing.Point(47, 162);
            this.grdSMS.Name = "grdSMS";
            this.grdSMS.ReadOnly = true;
            this.grdSMS.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.grdSMS.RowHeadersVisible = false;
            dataGridViewCellStyle16.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle16.SelectionBackColor = System.Drawing.Color.SkyBlue;
            dataGridViewCellStyle16.SelectionForeColor = System.Drawing.Color.Black;
            this.grdSMS.RowsDefaultCellStyle = dataGridViewCellStyle16;
            this.grdSMS.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdSMS.Size = new System.Drawing.Size(576, 311);
            this.grdSMS.TabIndex = 16;
            this.grdSMS.SelectionChanged += new System.EventHandler(this.grdSMS_SelectionChanged);
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "IDSectionSMS";
            this.dataGridViewTextBoxColumn8.HeaderText = "IDSectionSMS";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            this.dataGridViewTextBoxColumn8.Visible = false;
            this.dataGridViewTextBoxColumn8.Width = 5;
            // 
            // dataGridViewTextBoxColumn12
            // 
            this.dataGridViewTextBoxColumn12.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn12.DataPropertyName = "Text";
            this.dataGridViewTextBoxColumn12.HeaderText = "متن";
            this.dataGridViewTextBoxColumn12.Name = "dataGridViewTextBoxColumn12";
            this.dataGridViewTextBoxColumn12.ReadOnly = true;
            // 
            // IDSection
            // 
            this.IDSection.HeaderText = "IDSection";
            this.IDSection.Name = "IDSection";
            this.IDSection.ReadOnly = true;
            this.IDSection.Visible = false;
            // 
            // Calender
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(718, 484);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.pnlWeeklyHour);
            this.Controls.Add(this.pnlHoliday);
            this.Controls.Add(this.pnlSMS);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(734, 522);
            this.MinimumSize = new System.Drawing.Size(734, 522);
            this.Name = "Calender";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "تقویم";
            this.Load += new System.EventHandler(this.Calender_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView)).EndInit();
            this.pnlWeeklyHour.ResumeLayout(false);
            this.pnlWeeklyHour.PerformLayout();
            this.pnlHoliday.ResumeLayout(false);
            this.pnlSMS.ResumeLayout(false);
            this.pnlSMS.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdSMS)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem MenuItem1ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MenuItem2ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MenuItem4ToolStripMenuItem;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.ToolStripMenuItem MenuItem3ToolStripMenuItem;
        private System.Windows.Forms.DataGridView DataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn DN;
        private System.Windows.Forms.DataGridViewTextBoxColumn ShiftName;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Active;
        private System.Windows.Forms.DataGridViewTextBoxColumn StartTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn EndTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn ShiftID;
        private System.Windows.Forms.DataGridViewTextBoxColumn DayOfWeek;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtEndSobh;
        private System.Windows.Forms.Button btnAdd2;
        private System.Windows.Forms.ComboBox cmbShift;
        private System.Windows.Forms.TextBox txtStartSobh;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbDayOfWeek;
        private System.Windows.Forms.CheckBox chEnabled;
        private System.Windows.Forms.Label lblMonth;
        private System.Windows.Forms.Button btnCancel2;
        private System.Windows.Forms.Panel pnlWeeklyHour;
        private AmirCalendar.FarsiCalendar farsiCalendar1;
        private System.Windows.Forms.Panel pnlHoliday;
        private System.Windows.Forms.Panel pnlSMS;
        private System.Windows.Forms.TextBox txtText;
        private System.Windows.Forms.Button btnDeleteSMS;
        private System.Windows.Forms.Button btnNewSMS;
        private System.Windows.Forms.Button btnSaveSMS;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView grdSMS;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn12;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDSection;
    }
}