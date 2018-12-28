namespace ClinicMesbah
{
    partial class Form1
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel4 = new System.Windows.Forms.Panel();
            this.colorBox1 = new MesbahComponent.ColorBox();
            this.MenuRightPanelWithBorder = new MesbahComponent.PanelWithBorder(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.RightPanelWithBorder = new MesbahComponent.PanelWithBorder(this.components);
            this.SMSDataGridView = new System.Windows.Forms.DataGridView();
            this.CustomerCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NumberCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TimeCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StateCol = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.CancelCol = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SectionCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SendSMSPanelWithBorder = new MesbahComponent.PanelWithBorder(this.components);
            this.panel2 = new System.Windows.Forms.Panel();
            this.pnlSmsProgress = new System.Windows.Forms.Panel();
            this.button4 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.colorProgressBar1 = new MesbahComponent.ColorProgressBar();
            this.SendSMSColorProgressBar = new MesbahComponent.ColorProgressBar();
            this.DeliveredSmsProgressBar1 = new MesbahComponent.ColorProgressBar();
            this.SendSMSButton = new System.Windows.Forms.Button();
            this.menuStrip2 = new System.Windows.Forms.MenuStrip();
            this.MenuTop4ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuTop3ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuTop1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuTop2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.BottomPanelWithBorder = new MesbahComponent.PanelWithBorder(this.components);
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnSearch = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.lblDate = new System.Windows.Forms.Label();
            this.ColorCheckBox = new System.Windows.Forms.CheckBox();
            this.TopPanelWithBorder = new MesbahComponent.PanelWithBorder(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.button6 = new System.Windows.Forms.Button();
            this.btnDocument = new System.Windows.Forms.Button();
            this.btnAfterTomorrow = new System.Windows.Forms.Button();
            this.btnOthers = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.lblDate1 = new System.Windows.Forms.Label();
            this.btnTomarow = new System.Windows.Forms.Button();
            this.btnToday = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.panel5 = new System.Windows.Forms.Panel();
            this.gridMesbah2 = new MesbahComponent.Grid.GridMesbah();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.panel4.SuspendLayout();
            this.MenuRightPanelWithBorder.SuspendLayout();
            this.RightPanelWithBorder.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SMSDataGridView)).BeginInit();
            this.SendSMSPanelWithBorder.SuspendLayout();
            this.panel2.SuspendLayout();
            this.pnlSmsProgress.SuspendLayout();
            this.panel6.SuspendLayout();
            this.menuStrip2.SuspendLayout();
            this.BottomPanelWithBorder.SuspendLayout();
            this.panel3.SuspendLayout();
            this.TopPanelWithBorder.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Interval = 3000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.colorBox1);
            this.panel4.Location = new System.Drawing.Point(3, 547);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(144, 155);
            this.panel4.TabIndex = 7;
            this.panel4.Visible = false;
            this.panel4.Paint += new System.Windows.Forms.PaintEventHandler(this.panel4_Paint);
            // 
            // colorBox1
            // 
            this.colorBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.colorBox1.BackColor = System.Drawing.Color.White;
            this.colorBox1.Color1 = System.Drawing.Color.SteelBlue;
            this.colorBox1.Color2 = System.Drawing.Color.CadetBlue;
            this.colorBox1.Color3 = System.Drawing.Color.DarkSlateBlue;
            this.colorBox1.Color4 = System.Drawing.Color.DarkGoldenrod;
            this.colorBox1.Color5 = System.Drawing.Color.DimGray;
            this.colorBox1.Color6 = System.Drawing.Color.DarkKhaki;
            this.colorBox1.Color7 = System.Drawing.Color.Black;
            this.colorBox1.Color8 = System.Drawing.Color.Maroon;
            this.colorBox1.Color9 = System.Drawing.Color.SaddleBrown;
            this.colorBox1.ColorActive = System.Drawing.Color.SteelBlue;
            this.colorBox1.Location = new System.Drawing.Point(2, 4);
            this.colorBox1.Name = "colorBox1";
            this.colorBox1.Size = new System.Drawing.Size(139, 148);
            this.colorBox1.TabIndex = 3;
            this.colorBox1.Visible = false;
            this.colorBox1.ColorChange += new MesbahComponent.ColorBox.ColorChangeHandler(this.colorBox1_ColorChange);
            this.colorBox1.Load += new System.EventHandler(this.colorBox1_Load);
            this.colorBox1.Leave += new System.EventHandler(this.colorBox1_Leave);
            // 
            // MenuRightPanelWithBorder
            // 
            this.MenuRightPanelWithBorder.BorderColor = System.Drawing.Color.Black;
            this.MenuRightPanelWithBorder.BorderSize = 1;
            this.MenuRightPanelWithBorder.Controls.Add(this.menuStrip1);
            this.MenuRightPanelWithBorder.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
            this.MenuRightPanelWithBorder.Dock = System.Windows.Forms.DockStyle.Right;
            this.MenuRightPanelWithBorder.Location = new System.Drawing.Point(776, 82);
            this.MenuRightPanelWithBorder.Name = "MenuRightPanelWithBorder";
            this.MenuRightPanelWithBorder.Padding = new System.Windows.Forms.Padding(1, 0, 0, 0);
            this.MenuRightPanelWithBorder.Size = new System.Drawing.Size(36, 621);
            this.MenuRightPanelWithBorder.TabIndex = 5;
            this.MenuRightPanelWithBorder.Paint += new System.Windows.Forms.PaintEventHandler(this.MenuRightPanelWithBorder_Paint);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.menuStrip1.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.menuStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.VerticalStackWithOverflow;
            this.menuStrip1.Location = new System.Drawing.Point(1, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(0);
            this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.menuStrip1.Size = new System.Drawing.Size(35, 621);
            this.menuStrip1.TabIndex = 5;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.TextDirection = System.Windows.Forms.ToolStripTextDirection.Vertical270;
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // RightPanelWithBorder
            // 
            this.RightPanelWithBorder.BorderColor = System.Drawing.Color.Black;
            this.RightPanelWithBorder.BorderSize = 1;
            this.RightPanelWithBorder.Controls.Add(this.SMSDataGridView);
            this.RightPanelWithBorder.Controls.Add(this.SendSMSPanelWithBorder);
            this.RightPanelWithBorder.Controls.Add(this.menuStrip2);
            this.RightPanelWithBorder.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            this.RightPanelWithBorder.Dock = System.Windows.Forms.DockStyle.Right;
            this.RightPanelWithBorder.Location = new System.Drawing.Point(812, 82);
            this.RightPanelWithBorder.Name = "RightPanelWithBorder";
            this.RightPanelWithBorder.Padding = new System.Windows.Forms.Padding(1, 0, 0, 0);
            this.RightPanelWithBorder.Size = new System.Drawing.Size(371, 621);
            this.RightPanelWithBorder.TabIndex = 2;
            this.RightPanelWithBorder.Paint += new System.Windows.Forms.PaintEventHandler(this.RightPanelWithBorder_Paint);
            // 
            // SMSDataGridView
            // 
            this.SMSDataGridView.AllowUserToAddRows = false;
            this.SMSDataGridView.AllowUserToDeleteRows = false;
            this.SMSDataGridView.AllowUserToResizeColumns = false;
            this.SMSDataGridView.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.SMSDataGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.SMSDataGridView.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.SMSDataGridView.BackgroundColor = System.Drawing.Color.White;
            this.SMSDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.SMSDataGridView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.SMSDataGridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("B Nazanin", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.SMSDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.SMSDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.SMSDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CustomerCol,
            this.NumberCol,
            this.TimeCol,
            this.StateCol,
            this.CancelCol,
            this.ID,
            this.SectionCol});
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.SMSDataGridView.DefaultCellStyle = dataGridViewCellStyle5;
            this.SMSDataGridView.EnableHeadersVisualStyles = false;
            this.SMSDataGridView.Location = new System.Drawing.Point(1, 87);
            this.SMSDataGridView.Name = "SMSDataGridView";
            this.SMSDataGridView.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.SMSDataGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.SMSDataGridView.RowHeadersVisible = false;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.SkyBlue;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.Black;
            this.SMSDataGridView.RowsDefaultCellStyle = dataGridViewCellStyle7;
            this.SMSDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.SMSDataGridView.Size = new System.Drawing.Size(370, 434);
            this.SMSDataGridView.TabIndex = 1;
            this.SMSDataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.SMSDataGridView_CellClick_1);
            this.SMSDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.SMSDataGridView_CellContentClick);
            this.SMSDataGridView.CellMouseUp += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.SMSDataGridView_CellMouseUp);
            this.SMSDataGridView.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.SMSDataGridView_CellContentClick);
            // 
            // CustomerCol
            // 
            this.CustomerCol.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.CustomerCol.DataPropertyName = "CustomerCol";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.CustomerCol.DefaultCellStyle = dataGridViewCellStyle3;
            this.CustomerCol.HeaderText = " بیمار";
            this.CustomerCol.MinimumWidth = 60;
            this.CustomerCol.Name = "CustomerCol";
            this.CustomerCol.ReadOnly = true;
            // 
            // NumberCol
            // 
            this.NumberCol.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.NumberCol.DataPropertyName = "NumberCol";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.NumberCol.DefaultCellStyle = dataGridViewCellStyle4;
            this.NumberCol.HeaderText = "شماره تماس";
            this.NumberCol.MinimumWidth = 60;
            this.NumberCol.Name = "NumberCol";
            this.NumberCol.ReadOnly = true;
            // 
            // TimeCol
            // 
            this.TimeCol.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.TimeCol.DataPropertyName = "TimeCol";
            this.TimeCol.HeaderText = "نوبت";
            this.TimeCol.MinimumWidth = 30;
            this.TimeCol.Name = "TimeCol";
            this.TimeCol.ReadOnly = true;
            this.TimeCol.Width = 55;
            // 
            // StateCol
            // 
            this.StateCol.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.StateCol.DataPropertyName = "StateCol";
            this.StateCol.HeaderText = "قطعی";
            this.StateCol.IndeterminateValue = "";
            this.StateCol.MinimumWidth = 30;
            this.StateCol.Name = "StateCol";
            this.StateCol.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.StateCol.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.StateCol.Width = 30;
            // 
            // CancelCol
            // 
            this.CancelCol.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.CancelCol.DataPropertyName = "CancelCol";
            this.CancelCol.FillWeight = 10F;
            this.CancelCol.HeaderText = "لغو";
            this.CancelCol.Name = "CancelCol";
            this.CancelCol.Width = 20;
            // 
            // ID
            // 
            this.ID.DataPropertyName = "ID";
            this.ID.HeaderText = "شناسه";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Visible = false;
            this.ID.Width = 5;
            // 
            // SectionCol
            // 
            this.SectionCol.DataPropertyName = "SectionCol";
            this.SectionCol.HeaderText = "بخش";
            this.SectionCol.MinimumWidth = 60;
            this.SectionCol.Name = "SectionCol";
            this.SectionCol.ReadOnly = true;
            this.SectionCol.Width = 110;
            // 
            // SendSMSPanelWithBorder
            // 
            this.SendSMSPanelWithBorder.BorderColor = System.Drawing.Color.Black;
            this.SendSMSPanelWithBorder.BorderSize = 1;
            this.SendSMSPanelWithBorder.Controls.Add(this.panel2);
            this.SendSMSPanelWithBorder.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
            this.SendSMSPanelWithBorder.Location = new System.Drawing.Point(1, 26);
            this.SendSMSPanelWithBorder.Name = "SendSMSPanelWithBorder";
            this.SendSMSPanelWithBorder.Padding = new System.Windows.Forms.Padding(0, 1, 0, 0);
            this.SendSMSPanelWithBorder.Size = new System.Drawing.Size(370, 55);
            this.SendSMSPanelWithBorder.TabIndex = 3;
            this.SendSMSPanelWithBorder.Paint += new System.Windows.Forms.PaintEventHandler(this.SendSMSPanelWithBorder_Paint);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.pnlSmsProgress);
            this.panel2.Controls.Add(this.DeliveredSmsProgressBar1);
            this.panel2.Controls.Add(this.SendSMSButton);
            this.panel2.Location = new System.Drawing.Point(0, 1);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(3);
            this.panel2.Size = new System.Drawing.Size(370, 48);
            this.panel2.TabIndex = 2;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // pnlSmsProgress
            // 
            this.pnlSmsProgress.Controls.Add(this.button4);
            this.pnlSmsProgress.Controls.Add(this.label1);
            this.pnlSmsProgress.Controls.Add(this.panel6);
            this.pnlSmsProgress.Location = new System.Drawing.Point(6, 4);
            this.pnlSmsProgress.Name = "pnlSmsProgress";
            this.pnlSmsProgress.Size = new System.Drawing.Size(197, 44);
            this.pnlSmsProgress.TabIndex = 6;
            this.pnlSmsProgress.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlSmsProgress_Paint);
            // 
            // button4
            // 
            this.button4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button4.FlatAppearance.BorderSize = 0;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Font = new System.Drawing.Font("B Nazanin", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.button4.ForeColor = System.Drawing.Color.White;
            this.button4.Image = global::ClinicMesbah.Properties.Resources.sync;
            this.button4.Location = new System.Drawing.Point(158, 7);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(36, 30);
            this.button4.TabIndex = 7;
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("B Nazanin", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label1.Location = new System.Drawing.Point(40, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 20);
            this.label1.TabIndex = 7;
            this.label1.Text = "پیام های ارسال شده";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.colorProgressBar1);
            this.panel6.Controls.Add(this.SendSMSColorProgressBar);
            this.panel6.Location = new System.Drawing.Point(6, 6);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(139, 31);
            this.panel6.TabIndex = 3;
            this.panel6.Paint += new System.Windows.Forms.PaintEventHandler(this.panel6_Paint);
            // 
            // colorProgressBar1
            // 
            this.colorProgressBar1.BackColor = System.Drawing.Color.Gainsboro;
            this.colorProgressBar1.BarColor = System.Drawing.Color.SteelBlue;
            this.colorProgressBar1.BorderColor = System.Drawing.Color.DimGray;
            this.colorProgressBar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.colorProgressBar1.FillStyle = MesbahComponent.ColorProgressBar.FillStyles.Solid;
            this.colorProgressBar1.Location = new System.Drawing.Point(0, 0);
            this.colorProgressBar1.LocationTextValue = 0;
            this.colorProgressBar1.Maximum = 100;
            this.colorProgressBar1.Minimum = 0;
            this.colorProgressBar1.Name = "colorProgressBar1";
            this.colorProgressBar1.ShowTextValue = false;
            this.colorProgressBar1.Size = new System.Drawing.Size(139, 10);
            this.colorProgressBar1.Step = 1;
            this.colorProgressBar1.StyleDrowMode = MesbahComponent.ColorProgressBar.StyleDraw.Normal;
            this.colorProgressBar1.TabIndex = 6;
            this.colorProgressBar1.Text = "DeliveredProgressBar";
            this.colorProgressBar1.Value = 0;
            this.colorProgressBar1.Click += new System.EventHandler(this.colorProgressBar1_Click);
            // 
            // SendSMSColorProgressBar
            // 
            this.SendSMSColorProgressBar.BarColor = System.Drawing.Color.SteelBlue;
            this.SendSMSColorProgressBar.BorderColor = System.Drawing.Color.DimGray;
            this.SendSMSColorProgressBar.FillStyle = MesbahComponent.ColorProgressBar.FillStyles.Solid;
            this.SendSMSColorProgressBar.Location = new System.Drawing.Point(0, 20);
            this.SendSMSColorProgressBar.LocationTextValue = 0;
            this.SendSMSColorProgressBar.Maximum = 100;
            this.SendSMSColorProgressBar.Minimum = 0;
            this.SendSMSColorProgressBar.Name = "SendSMSColorProgressBar";
            this.SendSMSColorProgressBar.ShowTextValue = false;
            this.SendSMSColorProgressBar.Size = new System.Drawing.Size(139, 10);
            this.SendSMSColorProgressBar.Step = 1;
            this.SendSMSColorProgressBar.StyleDrowMode = MesbahComponent.ColorProgressBar.StyleDraw.Normal;
            this.SendSMSColorProgressBar.TabIndex = 5;
            this.SendSMSColorProgressBar.Text = "p";
            this.SendSMSColorProgressBar.Value = 0;
            this.SendSMSColorProgressBar.Click += new System.EventHandler(this.SendSMSColorProgressBar_Click);
            // 
            // DeliveredSmsProgressBar1
            // 
            this.DeliveredSmsProgressBar1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.DeliveredSmsProgressBar1.BarColor = System.Drawing.Color.SteelBlue;
            this.DeliveredSmsProgressBar1.BorderColor = System.Drawing.Color.Transparent;
            this.DeliveredSmsProgressBar1.FillStyle = MesbahComponent.ColorProgressBar.FillStyles.Solid;
            this.DeliveredSmsProgressBar1.Location = new System.Drawing.Point(15, 25);
            this.DeliveredSmsProgressBar1.LocationTextValue = 0;
            this.DeliveredSmsProgressBar1.Maximum = 100;
            this.DeliveredSmsProgressBar1.Minimum = 0;
            this.DeliveredSmsProgressBar1.Name = "DeliveredSmsProgressBar1";
            this.DeliveredSmsProgressBar1.ShowTextValue = false;
            this.DeliveredSmsProgressBar1.Size = new System.Drawing.Size(136, 10);
            this.DeliveredSmsProgressBar1.Step = 1;
            this.DeliveredSmsProgressBar1.StyleDrowMode = MesbahComponent.ColorProgressBar.StyleDraw.Normal;
            this.DeliveredSmsProgressBar1.TabIndex = 5;
            this.DeliveredSmsProgressBar1.Text = "colorProgressBar1";
            this.DeliveredSmsProgressBar1.Value = 0;
            this.DeliveredSmsProgressBar1.Click += new System.EventHandler(this.DeliveredSmsProgressBar1_Click);
            // 
            // SendSMSButton
            // 
            this.SendSMSButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.SendSMSButton.BackColor = System.Drawing.Color.SteelBlue;
            this.SendSMSButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SendSMSButton.FlatAppearance.BorderSize = 0;
            this.SendSMSButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SendSMSButton.Font = new System.Drawing.Font("B Nazanin", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.SendSMSButton.ForeColor = System.Drawing.Color.White;
            this.SendSMSButton.Location = new System.Drawing.Point(210, 6);
            this.SendSMSButton.Name = "SendSMSButton";
            this.SendSMSButton.Size = new System.Drawing.Size(151, 38);
            this.SendSMSButton.TabIndex = 0;
            this.SendSMSButton.Text = "ارسال پیامک ها";
            this.SendSMSButton.UseVisualStyleBackColor = false;
            this.SendSMSButton.Click += new System.EventHandler(this.SendSMSButton_Click);
            // 
            // menuStrip2
            // 
            this.menuStrip2.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.menuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuTop4ToolStripMenuItem,
            this.MenuTop3ToolStripMenuItem,
            this.MenuTop1ToolStripMenuItem,
            this.MenuTop2ToolStripMenuItem});
            this.menuStrip2.Location = new System.Drawing.Point(1, 0);
            this.menuStrip2.Name = "menuStrip2";
            this.menuStrip2.Padding = new System.Windows.Forms.Padding(3, 0, 0, 2);
            this.menuStrip2.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.menuStrip2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.menuStrip2.Size = new System.Drawing.Size(370, 26);
            this.menuStrip2.TabIndex = 0;
            this.menuStrip2.Text = "menuStrip2";
            this.menuStrip2.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip2_ItemClicked);
            // 
            // MenuTop4ToolStripMenuItem
            // 
            this.MenuTop4ToolStripMenuItem.CheckOnClick = true;
            this.MenuTop4ToolStripMenuItem.Name = "MenuTop4ToolStripMenuItem";
            this.MenuTop4ToolStripMenuItem.Size = new System.Drawing.Size(49, 24);
            this.MenuTop4ToolStripMenuItem.Text = "پیامک";
            this.MenuTop4ToolStripMenuItem.Click += new System.EventHandler(this.MenuTop4ToolStripMenuItem_Click);
            this.MenuTop4ToolStripMenuItem.MouseEnter += new System.EventHandler(this.MenuItem1ToolStripMenuItem_MouseEnter);
            this.MenuTop4ToolStripMenuItem.MouseLeave += new System.EventHandler(this.MenuItem1ToolStripMenuItem_MouseLeave);
            // 
            // MenuTop3ToolStripMenuItem
            // 
            this.MenuTop3ToolStripMenuItem.CheckOnClick = true;
            this.MenuTop3ToolStripMenuItem.Margin = new System.Windows.Forms.Padding(2, 0, 0, 0);
            this.MenuTop3ToolStripMenuItem.Name = "MenuTop3ToolStripMenuItem";
            this.MenuTop3ToolStripMenuItem.Size = new System.Drawing.Size(68, 24);
            this.MenuTop3ToolStripMenuItem.Text = "تلفن ثابت";
            this.MenuTop3ToolStripMenuItem.Click += new System.EventHandler(this.MenuTop3ToolStripMenuItem_Click);
            this.MenuTop3ToolStripMenuItem.MouseEnter += new System.EventHandler(this.MenuItem1ToolStripMenuItem_MouseEnter);
            this.MenuTop3ToolStripMenuItem.MouseLeave += new System.EventHandler(this.MenuItem1ToolStripMenuItem_MouseLeave);
            // 
            // MenuTop1ToolStripMenuItem
            // 
            this.MenuTop1ToolStripMenuItem.CheckOnClick = true;
            this.MenuTop1ToolStripMenuItem.Margin = new System.Windows.Forms.Padding(2, 0, 0, 0);
            this.MenuTop1ToolStripMenuItem.Name = "MenuTop1ToolStripMenuItem";
            this.MenuTop1ToolStripMenuItem.Size = new System.Drawing.Size(82, 24);
            this.MenuTop1ToolStripMenuItem.Text = "ارتباط دوباره";
            this.MenuTop1ToolStripMenuItem.Click += new System.EventHandler(this.MenuTop1ToolStripMenuItem_Click);
            this.MenuTop1ToolStripMenuItem.MouseEnter += new System.EventHandler(this.MenuItem1ToolStripMenuItem_MouseEnter);
            this.MenuTop1ToolStripMenuItem.MouseLeave += new System.EventHandler(this.MenuItem1ToolStripMenuItem_MouseLeave);
            // 
            // MenuTop2ToolStripMenuItem
            // 
            this.MenuTop2ToolStripMenuItem.CheckOnClick = true;
            this.MenuTop2ToolStripMenuItem.Margin = new System.Windows.Forms.Padding(2, 0, 0, 0);
            this.MenuTop2ToolStripMenuItem.Name = "MenuTop2ToolStripMenuItem";
            this.MenuTop2ToolStripMenuItem.Size = new System.Drawing.Size(101, 24);
            this.MenuTop2ToolStripMenuItem.Text = "قطعی کردن نهایی";
            this.MenuTop2ToolStripMenuItem.Click += new System.EventHandler(this.MenuTop2ToolStripMenuItem_Click);
            this.MenuTop2ToolStripMenuItem.MouseEnter += new System.EventHandler(this.MenuItem1ToolStripMenuItem_MouseEnter);
            this.MenuTop2ToolStripMenuItem.MouseLeave += new System.EventHandler(this.MenuItem1ToolStripMenuItem_MouseLeave);
            // 
            // BottomPanelWithBorder
            // 
            this.BottomPanelWithBorder.BorderColor = System.Drawing.Color.Black;
            this.BottomPanelWithBorder.BorderSize = 1;
            this.BottomPanelWithBorder.Controls.Add(this.panel3);
            this.BottomPanelWithBorder.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            this.BottomPanelWithBorder.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BottomPanelWithBorder.Location = new System.Drawing.Point(0, 703);
            this.BottomPanelWithBorder.Name = "BottomPanelWithBorder";
            this.BottomPanelWithBorder.Padding = new System.Windows.Forms.Padding(0, 1, 0, 0);
            this.BottomPanelWithBorder.Size = new System.Drawing.Size(1183, 30);
            this.BottomPanelWithBorder.TabIndex = 1;
            this.BottomPanelWithBorder.Paint += new System.Windows.Forms.PaintEventHandler(this.BottomPanelWithBorder_Paint);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnSearch);
            this.panel3.Controls.Add(this.button7);
            this.panel3.Controls.Add(this.lblDate);
            this.panel3.Controls.Add(this.ColorCheckBox);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 1);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1183, 29);
            this.panel3.TabIndex = 0;
            this.panel3.Paint += new System.Windows.Forms.PaintEventHandler(this.panel3_Paint);
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.Transparent;
            this.btnSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSearch.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.ForeColor = System.Drawing.Color.Transparent;
            this.btnSearch.Image = ((System.Drawing.Image)(resources.GetObject("btnSearch.Image")));
            this.btnSearch.Location = new System.Drawing.Point(35, 1);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(39, 31);
            this.btnSearch.TabIndex = 16;
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // button7
            // 
            this.button7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button7.BackColor = System.Drawing.SystemColors.Control;
            this.button7.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button7.FlatAppearance.BorderSize = 0;
            this.button7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button7.Font = new System.Drawing.Font("B Nazanin", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.button7.ForeColor = System.Drawing.Color.White;
            this.button7.Location = new System.Drawing.Point(84, 3);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(29, 23);
            this.button7.TabIndex = 11;
            this.button7.UseVisualStyleBackColor = false;
            this.button7.Visible = false;
            this.button7.Click += new System.EventHandler(this.button7_Click_1);
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblDate.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblDate.Location = new System.Drawing.Point(1076, 0);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(107, 24);
            this.lblDate.TabIndex = 10;
            this.lblDate.Text = "پیام های دلیور شده";
            this.lblDate.Click += new System.EventHandler(this.lblDate_Click);
            // 
            // ColorCheckBox
            // 
            this.ColorCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ColorCheckBox.Appearance = System.Windows.Forms.Appearance.Button;
            this.ColorCheckBox.BackColor = System.Drawing.Color.SteelBlue;
            this.ColorCheckBox.BackgroundImage = global::ClinicMesbah.Properties.Resources.BackGroundButton;
            this.ColorCheckBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ColorCheckBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ColorCheckBox.FlatAppearance.BorderSize = 0;
            this.ColorCheckBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ColorCheckBox.Location = new System.Drawing.Point(4, 3);
            this.ColorCheckBox.Name = "ColorCheckBox";
            this.ColorCheckBox.Size = new System.Drawing.Size(23, 23);
            this.ColorCheckBox.TabIndex = 4;
            this.ColorCheckBox.UseVisualStyleBackColor = false;
            this.ColorCheckBox.CheckedChanged += new System.EventHandler(this.ColorCheckBox_CheckedChanged);
            // 
            // TopPanelWithBorder
            // 
            this.TopPanelWithBorder.BorderColor = System.Drawing.Color.Black;
            this.TopPanelWithBorder.BorderSize = 1;
            this.TopPanelWithBorder.Controls.Add(this.panel1);
            this.TopPanelWithBorder.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            this.TopPanelWithBorder.Dock = System.Windows.Forms.DockStyle.Top;
            this.TopPanelWithBorder.Location = new System.Drawing.Point(0, 0);
            this.TopPanelWithBorder.Name = "TopPanelWithBorder";
            this.TopPanelWithBorder.Padding = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.TopPanelWithBorder.Size = new System.Drawing.Size(1183, 82);
            this.TopPanelWithBorder.TabIndex = 0;
            this.TopPanelWithBorder.Paint += new System.Windows.Forms.PaintEventHandler(this.TopPanelWithBorder_Paint);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.button6);
            this.panel1.Controls.Add(this.btnDocument);
            this.panel1.Controls.Add(this.btnAfterTomorrow);
            this.panel1.Controls.Add(this.btnOthers);
            this.panel1.Controls.Add(this.button5);
            this.panel1.Controls.Add(this.lblDate1);
            this.panel1.Controls.Add(this.btnTomarow);
            this.panel1.Controls.Add(this.btnToday);
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1183, 81);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // button6
            // 
            this.button6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button6.BackColor = System.Drawing.Color.SteelBlue;
            this.button6.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button6.FlatAppearance.BorderSize = 0;
            this.button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button6.Font = new System.Drawing.Font("B Nazanin", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.button6.ForeColor = System.Drawing.Color.White;
            this.button6.Location = new System.Drawing.Point(634, 6);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(72, 65);
            this.button6.TabIndex = 14;
            this.button6.Text = "پزشکان";
            this.button6.UseVisualStyleBackColor = false;
            this.button6.Visible = false;
            this.button6.Click += new System.EventHandler(this.button6_Click_1);
            this.button6.MouseEnter += new System.EventHandler(this.button6_MouseEnter);
            this.button6.MouseMove += new System.Windows.Forms.MouseEventHandler(this.button6_MouseMove);
            // 
            // btnDocument
            // 
            this.btnDocument.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDocument.BackColor = System.Drawing.Color.SteelBlue;
            this.btnDocument.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDocument.FlatAppearance.BorderSize = 0;
            this.btnDocument.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDocument.Font = new System.Drawing.Font("B Nazanin", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnDocument.ForeColor = System.Drawing.Color.White;
            this.btnDocument.Location = new System.Drawing.Point(944, 6);
            this.btnDocument.Name = "btnDocument";
            this.btnDocument.Size = new System.Drawing.Size(72, 65);
            this.btnDocument.TabIndex = 13;
            this.btnDocument.Text = " پرونده";
            this.btnDocument.UseVisualStyleBackColor = false;
            this.btnDocument.Click += new System.EventHandler(this.button6_Click);
            this.btnDocument.MouseEnter += new System.EventHandler(this.btnDocument_MouseEnter);
            this.btnDocument.MouseLeave += new System.EventHandler(this.btnDocument_MouseLeave);
            // 
            // btnAfterTomorrow
            // 
            this.btnAfterTomorrow.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnAfterTomorrow.BackColor = System.Drawing.SystemColors.Control;
            this.btnAfterTomorrow.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAfterTomorrow.FlatAppearance.BorderSize = 0;
            this.btnAfterTomorrow.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAfterTomorrow.Font = new System.Drawing.Font("B Nazanin", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnAfterTomorrow.ForeColor = System.Drawing.Color.White;
            this.btnAfterTomorrow.Location = new System.Drawing.Point(262, 8);
            this.btnAfterTomorrow.Name = "btnAfterTomorrow";
            this.btnAfterTomorrow.Size = new System.Drawing.Size(94, 38);
            this.btnAfterTomorrow.TabIndex = 12;
            this.btnAfterTomorrow.Text = "پس فردا";
            this.btnAfterTomorrow.UseVisualStyleBackColor = false;
            this.btnAfterTomorrow.Click += new System.EventHandler(this.btnAfterTomorrow_Click);
            this.btnAfterTomorrow.MouseEnter += new System.EventHandler(this.btnAfterTomorrow_MouseEnter);
            this.btnAfterTomorrow.MouseLeave += new System.EventHandler(this.btnAfterTomorrow_MouseLeave);
            // 
            // btnOthers
            // 
            this.btnOthers.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOthers.BackColor = System.Drawing.Color.SteelBlue;
            this.btnOthers.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOthers.FlatAppearance.BorderSize = 0;
            this.btnOthers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOthers.Font = new System.Drawing.Font("B Nazanin", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnOthers.ForeColor = System.Drawing.Color.White;
            this.btnOthers.Location = new System.Drawing.Point(711, 5);
            this.btnOthers.Name = "btnOthers";
            this.btnOthers.Size = new System.Drawing.Size(72, 65);
            this.btnOthers.TabIndex = 11;
            this.btnOthers.Text = "رادیولوژی";
            this.btnOthers.UseVisualStyleBackColor = false;
            this.btnOthers.Visible = false;
            this.btnOthers.Click += new System.EventHandler(this.btnOthers_Click);
            this.btnOthers.MouseEnter += new System.EventHandler(this.btnOthers_MouseEnter);
            this.btnOthers.MouseLeave += new System.EventHandler(this.btnOthers_MouseLeave);
            // 
            // button5
            // 
            this.button5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button5.BackColor = System.Drawing.Color.SteelBlue;
            this.button5.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button5.FlatAppearance.BorderSize = 0;
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.Font = new System.Drawing.Font("B Nazanin", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.button5.ForeColor = System.Drawing.Color.White;
            this.button5.Location = new System.Drawing.Point(867, 6);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(72, 65);
            this.button5.TabIndex = 10;
            this.button5.Text = "آزمایشگاه";
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Visible = false;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            this.button5.MouseEnter += new System.EventHandler(this.button5_MouseEnter);
            this.button5.MouseLeave += new System.EventHandler(this.button5_MouseLeave);
            // 
            // lblDate1
            // 
            this.lblDate1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDate1.AutoSize = true;
            this.lblDate1.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblDate1.Location = new System.Drawing.Point(504, 55);
            this.lblDate1.Name = "lblDate1";
            this.lblDate1.Size = new System.Drawing.Size(107, 24);
            this.lblDate1.TabIndex = 9;
            this.lblDate1.Text = "پیام های دلیور شده";
            this.lblDate1.Click += new System.EventHandler(this.lblDate1_Click);
            // 
            // btnTomarow
            // 
            this.btnTomarow.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnTomarow.BackColor = System.Drawing.SystemColors.Control;
            this.btnTomarow.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTomarow.FlatAppearance.BorderSize = 0;
            this.btnTomarow.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTomarow.Font = new System.Drawing.Font("B Nazanin", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnTomarow.ForeColor = System.Drawing.Color.White;
            this.btnTomarow.Location = new System.Drawing.Point(377, 8);
            this.btnTomarow.Name = "btnTomarow";
            this.btnTomarow.Size = new System.Drawing.Size(94, 38);
            this.btnTomarow.TabIndex = 2;
            this.btnTomarow.Text = "فردا";
            this.btnTomarow.UseVisualStyleBackColor = false;
            this.btnTomarow.Click += new System.EventHandler(this.button7_Click);
            this.btnTomarow.MouseEnter += new System.EventHandler(this.btnTomarow_MouseEnter);
            this.btnTomarow.MouseLeave += new System.EventHandler(this.btnTomarow_MouseLeave);
            // 
            // btnToday
            // 
            this.btnToday.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnToday.BackColor = System.Drawing.SystemColors.Control;
            this.btnToday.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnToday.FlatAppearance.BorderSize = 0;
            this.btnToday.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnToday.Font = new System.Drawing.Font("B Nazanin", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnToday.ForeColor = System.Drawing.Color.White;
            this.btnToday.Location = new System.Drawing.Point(493, 8);
            this.btnToday.Name = "btnToday";
            this.btnToday.Size = new System.Drawing.Size(94, 38);
            this.btnToday.TabIndex = 1;
            this.btnToday.Text = "امروز";
            this.btnToday.UseVisualStyleBackColor = false;
            this.btnToday.Click += new System.EventHandler(this.btnDay_Click);
            this.btnToday.MouseEnter += new System.EventHandler(this.btnToday_MouseEnter);
            this.btnToday.MouseLeave += new System.EventHandler(this.btnToday_MouseLeave);
            // 
            // button3
            // 
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button3.BackColor = System.Drawing.Color.SteelBlue;
            this.button3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("B Nazanin", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.button3.ForeColor = System.Drawing.Color.White;
            this.button3.Location = new System.Drawing.Point(1021, 6);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(72, 65);
            this.button3.TabIndex = 0;
            this.button3.Text = "تنظیمات";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            this.button3.MouseEnter += new System.EventHandler(this.button3_MouseEnter);
            this.button3.MouseLeave += new System.EventHandler(this.button3_MouseLeave);
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.BackColor = System.Drawing.Color.SteelBlue;
            this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("B Nazanin", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(1099, 6);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(72, 65);
            this.button2.TabIndex = 0;
            this.button2.Text = "پزشک";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            this.button2.MouseEnter += new System.EventHandler(this.button2_MouseEnter);
            this.button2.MouseLeave += new System.EventHandler(this.button2_MouseLeave);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.BackColor = System.Drawing.Color.SteelBlue;
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("B Nazanin", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(789, 6);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(72, 65);
            this.button1.TabIndex = 0;
            this.button1.Text = "داروخانه";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            this.button1.MouseEnter += new System.EventHandler(this.button1_MouseEnter);
            this.button1.MouseLeave += new System.EventHandler(this.button1_MouseLeave);
            // 
            // panel5
            // 
            this.panel5.AutoScroll = true;
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1183, 733);
            this.panel5.TabIndex = 8;
            this.panel5.Paint += new System.Windows.Forms.PaintEventHandler(this.panel5_Paint);
            // 
            // gridMesbah2
            // 
            this.gridMesbah2.AllowCellsDrop = false;
            this.gridMesbah2.AutoScroll = true;
            this.gridMesbah2.AutoSize = true;
            this.gridMesbah2.CellsBorderColor = System.Drawing.Color.Black;
            this.gridMesbah2.CellsButtonColor = System.Drawing.Color.Black;
            this.gridMesbah2.CellsForColor = System.Drawing.Color.Black;
            this.gridMesbah2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridMesbah2.Location = new System.Drawing.Point(0, 82);
            this.gridMesbah2.Name = "gridMesbah2";
            this.gridMesbah2.Padding = new System.Windows.Forms.Padding(1);
            this.gridMesbah2.RowsBorderColor = System.Drawing.Color.Black;
            this.gridMesbah2.Size = new System.Drawing.Size(776, 621);
            this.gridMesbah2.TabIndex = 6;
            this.gridMesbah2.CellClickAdd += new MesbahComponent.Grid.GridMesbah.CellClickAddHandler(this.gridMesbah1_CellClickAdd);
            this.gridMesbah2.CellClickAttach += new MesbahComponent.Grid.GridMesbah.CellClickAttachHandler(this.gridMesbah1_CellClickAttach);
            this.gridMesbah2.CellClickForward += new MesbahComponent.Grid.GridMesbah.CellClickForwardHandler(this.gridMesbah1_CellClickForward);
            this.gridMesbah2.CellClickDelete += new MesbahComponent.Grid.GridMesbah.CellClickDeleteHandler(this.gridMesbah1_CellClickDelete);
            this.gridMesbah2.Load += new System.EventHandler(this.gridMesbah2_Load);
            // 
            // timer2
            // 
            this.timer2.Interval = 900000;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1183, 733);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.gridMesbah2);
            this.Controls.Add(this.MenuRightPanelWithBorder);
            this.Controls.Add(this.RightPanelWithBorder);
            this.Controls.Add(this.BottomPanelWithBorder);
            this.Controls.Add(this.TopPanelWithBorder);
            this.Controls.Add(this.panel5);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Text = "کلینیک";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel4.ResumeLayout(false);
            this.MenuRightPanelWithBorder.ResumeLayout(false);
            this.MenuRightPanelWithBorder.PerformLayout();
            this.RightPanelWithBorder.ResumeLayout(false);
            this.RightPanelWithBorder.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SMSDataGridView)).EndInit();
            this.SendSMSPanelWithBorder.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.pnlSmsProgress.ResumeLayout(false);
            this.pnlSmsProgress.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.menuStrip2.ResumeLayout(false);
            this.menuStrip2.PerformLayout();
            this.BottomPanelWithBorder.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.TopPanelWithBorder.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MesbahComponent.PanelWithBorder TopPanelWithBorder;
        private System.Windows.Forms.Panel panel1;
        private MesbahComponent.PanelWithBorder BottomPanelWithBorder;
        private MesbahComponent.PanelWithBorder RightPanelWithBorder;
        private System.Windows.Forms.Panel panel3;
        private MesbahComponent.ColorBox colorBox1;
        private System.Windows.Forms.CheckBox ColorCheckBox;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.MenuStrip menuStrip2;
        private System.Windows.Forms.ToolStripMenuItem MenuTop4ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MenuTop3ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MenuTop2ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MenuTop1ToolStripMenuItem;
        private System.Windows.Forms.DataGridView SMSDataGridView;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button SendSMSButton;
        private MesbahComponent.PanelWithBorder MenuRightPanelWithBorder;
        private MesbahComponent.PanelWithBorder SendSMSPanelWithBorder;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button btnToday;
        private System.Windows.Forms.Button btnTomarow;
        private System.Windows.Forms.Panel panel4;
        private MesbahComponent.ColorProgressBar DeliveredSmsProgressBar1;
        private System.Windows.Forms.Panel panel6;
        private MesbahComponent.ColorProgressBar SendSMSColorProgressBar;
        private System.Windows.Forms.Panel pnlSmsProgress;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label1;
        private MesbahComponent.ColorProgressBar colorProgressBar1;
        private System.Windows.Forms.Label lblDate1;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.DataGridViewTextBoxColumn CustomerCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn NumberCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn TimeCol;
        private System.Windows.Forms.DataGridViewCheckBoxColumn StateCol;
        private System.Windows.Forms.DataGridViewCheckBoxColumn CancelCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn SectionCol;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.Button btnOthers;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Button btnAfterTomorrow;
        private MesbahComponent.Grid.GridMesbah gridMesbah2;
        private System.Windows.Forms.Button btnDocument;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button btnSearch;
      //  private System.Windows.Forms.MenuStrip menuStrip1;
    }
}

