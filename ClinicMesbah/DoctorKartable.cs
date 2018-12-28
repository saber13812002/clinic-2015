using AmirCalendar;
using MesbahComponent;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Xml;
using USBDriveSerialNumber;

namespace ClinicMesbah
{
    public partial class DoctorKartable : Form
    {
        public DoctorKartable()
        {
            InitializeComponent();
            tabControl1.TabPages[0].Controls.Add(pictureBox1);
            pictureBox1.MouseDown += new MouseEventHandler(pictureBox1_MouseDown);
            pictureBox1.MouseMove += new MouseEventHandler(pictureBox1_MouseMove);
            pictureBox1.MouseUp += new MouseEventHandler(pictureBox1_MouseUp);
            SelectMenuTop(MenuTop4ToolStripMenuItem);
            SetColor(); 
       
            
        }
        public DoctorKartable(bool isDoctor,bool isSecretory)
        {
            InitializeComponent();
            tabControl1.TabPages[0].Controls.Add(pictureBox1);
            pictureBox1.MouseDown += new MouseEventHandler(pictureBox1_MouseDown);
            pictureBox1.MouseMove += new MouseEventHandler(pictureBox1_MouseMove);
            pictureBox1.MouseUp += new MouseEventHandler(pictureBox1_MouseUp);
            SelectMenuTop(MenuTop4ToolStripMenuItem);
            SetColor();
            this.ISDoctor = isDoctor;
            this.ISSecretory = isSecretory;


        }
        #region Variables
        private string USBDrive;
        private int i = 1;
        CheckBox[] CheckBoxTeamNames = new CheckBox[1];
        CheckBox[] CheckBoxTeamNames1 = new CheckBox[1];
        private TextBox[] txtTeamNames = new TextBox[1]; private Button[] btnTeamNames = new Button[1];
        private DataTable ControlDT = new DataTable();
        private DataTable DrugControlsDT = new DataTable();
        private string SecretorySerial = "A110000000028845";//C2///فلش چاووش  / "02501111130000000DC2";//"07BB08072E3F26F8";// "0014780C9ED2A8B132CF013A";// "A110000000028845"  ;
        private string DoctorSerial = "8";//"07BB08072E3F26F8";فلش خودمی//"0014780C9ED2A8B132CF013A";//"1401461905819145";
        DataSet dsResult = new DataSet();
        USBSerialNumber usb = new USBSerialNumber();
        private PictureBox pictureBox1 = new PictureBox();
        private ToolStripItem menuActiveRight;
         private string path;
        private ToolStripMenuItem menuActiveTop;
        DataTable centersDT = new DataTable();
        private short DepartmentID = 0;
        public short DepartmentSelected;
        private DataSet DepartementInfo = new DataSet();
        private string PATH = Application.StartupPath + @"\setting.xml";
        private Point? _Previous = null;
        private DataTable DoctDT = new DataTable();
        private DataTable DocumentDT = new DataTable();
        SolidBrush myBrush = new SolidBrush(Color.Black);
        private byte size = 2;
     //   private Panel pnl = new Panel();
       // private TabControl tcDescriptionDetails = new TabControl();
        //private TabPage complaint = new TabPage();
        //private TabPage symptoms = new TabPage();
        //private TabPage diagnosis = new TabPage();
        //private TabPage consultation = new TabPage();
        private Bitmap drawing;
        private DataSet sectionDS = new DataSet();
        private DataAccess da = new DataAccess();
        private DataTable dt = new DataTable();
        private DataTable dtDoc = new DataTable();
        private DataTable smsDt = new DataTable();
        private string  Id;
        private Color color = Properties.Settings.Default.Color;
        public DataSet GridDataSourceDS;
        private bool IntOrChar;
        private bool ISDoctor = false;
        private bool ISSecretory = true;
        

        #endregion
        private void ChangeKeboardLayout(int culturenumber)
        {
            System.Globalization.CultureInfo CultureInfo = new System.Globalization.CultureInfo(culturenumber);
           
            InputLanguage c = InputLanguage.FromCulture(CultureInfo);
            InputLanguage.CurrentInputLanguage = c;
            
        }
        #region Form
        #region Load
        private void DoctorKartable_Load(object sender, EventArgs e)
        {
            ////////////////////////////////////////////////////////////////
            string mutex_id = "Clinic";
            using (Mutex mutex = new Mutex(false, mutex_id))
            {
                if (!mutex.WaitOne(0, false))
                {
                    MessageBox.Show("Instance Already Running!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    return;
                }
                else
                {
                    // برای رزرو کردن یک هات کی که برنامه با آن باز می شود
                    // HotKey
                    RegistryKey Key = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Run", true);
                    Key.SetValue("Clinic", System.Reflection.Assembly.GetEntryAssembly().Location);

                    // تغییر کی بورد به فارسی که کاربر راحت باشد
                    // change keyboard language
                    ChangeKeboardLayout(1065);
                }
            }
            //////////////////////////////////////////////////////////////////////////////////////
            DateTime now = DateTime.Now;
            DateTime Update_New = DateTime.Parse("08/02/2019 12:00:00 AM");
            if (now.Date >= Update_New)
            {
                var msg = "مدت زمان یکساله برنامه تمام شده است. لطفا نسخه جدید را دریافت و نصب کنید."; MessageForm.Show(msg, "خطا", MessageFormIcons.Warning, MessageFormButtons.Ok, color);

                this.Close();
                System.Environment.Exit(1);
            }
          //  Lock();
            this.Hide();
            ConnectionString logon = new ConnectionString();

            if (TestConnection())
            { this.Show(); WindowState = FormWindowState.Maximized; }
            else if (logon.ShowDialog() != DialogResult.OK)
            {
                this.Show(); WindowState = FormWindowState.Maximized;
            }

            //if (ISDoctor)
            //{ ShowAttachments sa = new ShowAttachments(Properties.Resources.check.ToString(),1); sa.ShowDialog(); }
            SetLook();
            GridSet();
            GridDocumentsSet();
            FillMenu();
            MenuTop4ToolStripMenuItem_Click(null,null);
            timer2.Enabled=true;//();
            
        }
        #endregion
        #endregion
        #region TestConnection
        private bool TestConnection()
        {
            if (System.IO.File.Exists(PATH))
            {


                try
                {
                    using (SqlConnection con = new SqlConnection(da.GetConnectionString()))
                    {

                        SqlCommand command = new SqlCommand();
                        con.Open(); con.Close();
                        return true;


                    }

                }
                catch
                {
                    return false;

                }
            }
            else return false;

        }
                #endregion
        #region Lock
        private void Lock()
        {

            
            if (usb.getSerialNumberFromDriveLetter("a:") != null)
            {
                USBDrive = "a:";
                if (usb.getSerialNumberFromDriveLetter("a:") == SecretorySerial || usb.getSerialNumberFromDriveLetter("a:") == DoctorSerial)
              
                      {if (usb.getSerialNumberFromDriveLetter("a:") == SecretorySerial) ISSecretory = true; else ISDoctor = true;  return; }

                  
                else
                {
                    var msg = "شناسایی قفل ناموفق است."; MessageForm.Show(msg, "خطای قفل", MessageFormIcons.Warning, MessageFormButtons.Ok, color);
                    this.Close();
                    System.Environment.Exit(1);
                }
            }
            else if (usb.getSerialNumberFromDriveLetter("b:") != null)
            {
                USBDrive = "b:";
                if (usb.getSerialNumberFromDriveLetter("b:") == SecretorySerial || usb.getSerialNumberFromDriveLetter("b:") == DoctorSerial)
                { if (usb.getSerialNumberFromDriveLetter("b:") == SecretorySerial) ISSecretory = true; else ISDoctor = true; return; }
                else
                {
                    var msg = "شناسایی قفل ناموفق است."; MessageForm.Show(msg, "خطای قفل", MessageFormIcons.Warning, MessageFormButtons.Ok, color);
                    this.Close();
                    System.Environment.Exit(1);
                }
            }
            else if (usb.getSerialNumberFromDriveLetter("c:") != null)
            {
                USBDrive = "c:";
                if (usb.getSerialNumberFromDriveLetter("c:") == SecretorySerial || usb.getSerialNumberFromDriveLetter("c:") == DoctorSerial)
                { if (usb.getSerialNumberFromDriveLetter("c:") == SecretorySerial) ISSecretory = true; else ISDoctor = true; return; }
                else
                {
                    var msg = "شناسایی قفل ناموفق است."; MessageForm.Show(msg, "خطای قفل", MessageFormIcons.Warning, MessageFormButtons.Ok, color);
                    this.Close();
                    System.Environment.Exit(1);
                }
            }
            else if (usb.getSerialNumberFromDriveLetter("d:") != null)
            {
                USBDrive = "d:";
                if (usb.getSerialNumberFromDriveLetter("d:") == SecretorySerial || usb.getSerialNumberFromDriveLetter("d:") == DoctorSerial)
                { if (usb.getSerialNumberFromDriveLetter("d:") == SecretorySerial) ISSecretory = true; else ISDoctor = true; return; }
                else
                {
                    var msg = "شناسایی قفل ناموفق است."; MessageForm.Show(msg, "خطای قفل", MessageFormIcons.Warning, MessageFormButtons.Ok, color);
                    this.Close();
                    System.Environment.Exit(1);
                }
            }
            else if (usb.getSerialNumberFromDriveLetter("e:") != null)
            {
                USBDrive = "e:";
                if (usb.getSerialNumberFromDriveLetter("e:") == SecretorySerial || usb.getSerialNumberFromDriveLetter("e:") == DoctorSerial)
                { if (usb.getSerialNumberFromDriveLetter("e:") == SecretorySerial) ISSecretory = true; else ISDoctor = true; return; }
                else
                {
                    var msg = "شناسایی قفل ناموفق است."; MessageForm.Show(msg, "خطای قفل", MessageFormIcons.Warning, MessageFormButtons.Ok, color);
                    this.Close();
                    System.Environment.Exit(1);
                }
            }

            else if (usb.getSerialNumberFromDriveLetter("f:") != null)
            {
                USBDrive = "f:";
                if (usb.getSerialNumberFromDriveLetter("f:") == SecretorySerial || usb.getSerialNumberFromDriveLetter("f:") == DoctorSerial)
                { if (usb.getSerialNumberFromDriveLetter("f:") == SecretorySerial) ISSecretory = true; else ISDoctor = true; return; }
                else
                {
                    var msg = "شناسایی قفل ناموفق است."; MessageForm.Show(msg, "خطای قفل", MessageFormIcons.Warning, MessageFormButtons.Ok, color);
                    this.Close();
                    System.Environment.Exit(1);
                }
            }

            else if (usb.getSerialNumberFromDriveLetter("g:") != null)
            {
                USBDrive = "g:";
                if (usb.getSerialNumberFromDriveLetter("g:") == SecretorySerial || usb.getSerialNumberFromDriveLetter("g:") == DoctorSerial)
                { if (usb.getSerialNumberFromDriveLetter("g:") == SecretorySerial) ISSecretory = true; else ISDoctor = true; return; }
                else
                {
                    var msg = "شناسایی قفل ناموفق است."; MessageForm.Show(msg, "خطای قفل", MessageFormIcons.Warning, MessageFormButtons.Ok, color);
                    this.Close();
                    System.Environment.Exit(1);
                }
            }

            else if (usb.getSerialNumberFromDriveLetter("h:") != null)
            {
                USBDrive = "h:";
                if (usb.getSerialNumberFromDriveLetter("h:") == SecretorySerial || usb.getSerialNumberFromDriveLetter("h:") == DoctorSerial)
                { if (usb.getSerialNumberFromDriveLetter("h:") == SecretorySerial) ISSecretory = true; else ISDoctor = true; return; }
                else
                {
                    var msg = "شناسایی قفل ناموفق است."; MessageForm.Show(msg, "خطای قفل", MessageFormIcons.Warning, MessageFormButtons.Ok, color);
                    this.Close();
                    System.Environment.Exit(1);
                }
            }

            else if (usb.getSerialNumberFromDriveLetter("i:") != null)
            {
                USBDrive = "i:";
                if (usb.getSerialNumberFromDriveLetter("i:") == SecretorySerial || usb.getSerialNumberFromDriveLetter("i:") == DoctorSerial)
                { if (usb.getSerialNumberFromDriveLetter("i:") == SecretorySerial) ISSecretory = true; else ISDoctor = true; return; }
                else
                {
                    var msg = "شناسایی قفل ناموفق است."; MessageForm.Show(msg, "خطای قفل", MessageFormIcons.Warning, MessageFormButtons.Ok, color);
                    this.Close();
                    System.Environment.Exit(1);
                }
            }

            else if (usb.getSerialNumberFromDriveLetter("j:") != null)
            {
                USBDrive = "j:";
                if (usb.getSerialNumberFromDriveLetter("j:") == SecretorySerial || usb.getSerialNumberFromDriveLetter("j:") == DoctorSerial)
                { if (usb.getSerialNumberFromDriveLetter("j:") == SecretorySerial) ISSecretory = true; else ISDoctor = true; return; }
                else
                {
                    var msg = "شناسایی قفل ناموفق است."; MessageForm.Show(msg, "خطای قفل", MessageFormIcons.Warning, MessageFormButtons.Ok, color);
                    this.Close();
                    System.Environment.Exit(1);
                }
            }

            else if (usb.getSerialNumberFromDriveLetter("k:") != null)
            {
                USBDrive = "k:";
                if (usb.getSerialNumberFromDriveLetter("k:") == SecretorySerial || usb.getSerialNumberFromDriveLetter("k:") == DoctorSerial)
                { if (usb.getSerialNumberFromDriveLetter("k:") == SecretorySerial) ISSecretory = true; else ISDoctor = true; return; }
                else
                {
                    var msg = "شناسایی قفل ناموفق است."; MessageForm.Show(msg, "خطای قفل", MessageFormIcons.Warning, MessageFormButtons.Ok, color);
                    this.Close();
                    System.Environment.Exit(1);
                }
            }

            else if (usb.getSerialNumberFromDriveLetter("l:") != null)
            {
                USBDrive = "l:";
                if (usb.getSerialNumberFromDriveLetter("l:") == SecretorySerial || usb.getSerialNumberFromDriveLetter("l:") == DoctorSerial)
                { if (usb.getSerialNumberFromDriveLetter("l:") == SecretorySerial) ISSecretory = true; else ISDoctor = true; return; }
                else
                {
                    var msg = "شناسایی قفل ناموفق است."; MessageForm.Show(msg, "خطای قفل", MessageFormIcons.Warning, MessageFormButtons.Ok, color);
                    this.Close();
                    System.Environment.Exit(1);
                }
            }

            else if (usb.getSerialNumberFromDriveLetter("m:") != null)
            {
                USBDrive = "m:";
                if (usb.getSerialNumberFromDriveLetter("m:") == SecretorySerial || usb.getSerialNumberFromDriveLetter("m:") == DoctorSerial)
                { if (usb.getSerialNumberFromDriveLetter("m:") == SecretorySerial) ISSecretory = true; else ISDoctor = true; return; }
                else
                {
                    var msg = "شناسایی قفل ناموفق است."; MessageForm.Show(msg, "خطای قفل", MessageFormIcons.Warning, MessageFormButtons.Ok, color);
                    this.Close();
                    System.Environment.Exit(1);
                }
            }

            else if (usb.getSerialNumberFromDriveLetter("n:") != null)
            {
                USBDrive = "n:";
                if (usb.getSerialNumberFromDriveLetter("n:") == SecretorySerial || usb.getSerialNumberFromDriveLetter("n:") == DoctorSerial)
                { if (usb.getSerialNumberFromDriveLetter("n:") == SecretorySerial) ISSecretory = true; else ISDoctor = true; return; }
                else
                {
                    var msg = "شناسایی قفل ناموفق است."; MessageForm.Show(msg, "خطای قفل", MessageFormIcons.Warning, MessageFormButtons.Ok, color);
                    this.Close();
                    System.Environment.Exit(1);
                }
            }

            else if (usb.getSerialNumberFromDriveLetter("o:") != null)
            {
                USBDrive = "o:";
                if (usb.getSerialNumberFromDriveLetter("o:") == SecretorySerial || usb.getSerialNumberFromDriveLetter("o:") == DoctorSerial)
                { if (usb.getSerialNumberFromDriveLetter("o:") == SecretorySerial) ISSecretory = true; else ISDoctor = true; return; }
                else
                {
                    var msg = "شناسایی قفل ناموفق است."; MessageForm.Show(msg, "خطای قفل", MessageFormIcons.Warning, MessageFormButtons.Ok, color);
                    this.Close();
                    System.Environment.Exit(1);
                }
            }
            else
            {
                var msg = "لطفا قفل را وارد کنید."; MessageForm.Show(msg, "خطای قفل", MessageFormIcons.Warning, MessageFormButtons.Ok, color);

                this.Close();
                System.Environment.Exit(1);

            }
        }
        #endregion
        #region SetColor
        private void SetColor()
        {
            color = Properties.Settings.Default.Color;
            SendSMSPanelWithBorder.BorderColor = color;
             BottomPanelWithBorder .BackColor = color; btnSave.BackColor = color;btnNew.BackColor = color;
            btnNextPatiant.BackColor = color;
            if (menuActiveRight != null)
                menuActiveRight.BackColor = color;
            menuActiveTop.BackColor = color;
            grdDocuments.RowsDefaultCellStyle.SelectionBackColor = ControlPaint.LightLight(ControlPaint.LightLight((color)));
            grdIntermittenc.ColumnHeadersDefaultCellStyle.BackColor = color;
            //toolStripMenuItem1.BackColor = toolStripMenuItem2.BackColor = toolStripMenuItem3.BackColor = toolStripMenuItem4.BackColor = toolStripMenuItem5.BackColor
           grdIntermittenc.RowsDefaultCellStyle.SelectionBackColor = ControlPaint.LightLight(color);
            grdIntermittenc.AlternatingRowsDefaultCellStyle.BackColor = ControlPaint.LightLight(ControlPaint.LightLight(ControlPaint.LightLight(ControlPaint.LightLight(color))));
            TopPanelWithBorder.BorderColor = color;
            BottomPanelWithBorder.BorderColor = color;
            btnAttach.BackColor= RightPanelWithBorder.BorderColor = color;
            MenuRightPanelWithBorder.BorderColor = color;
          btnBackGround.BackColor=  btnDcumentDetails.BackColor=   SendSMSPanelWithBorder.BorderColor = color;
            ColorCheckBox.BackColor = color;
            lblDate.ForeColor = ControlPaint.Dark(color);
            menuStrip3.BackColor = lblDate.BackColor = ControlPaint.LightLight(ControlPaint.LightLight((color)));
            ColorCheckBox.BackColor = color;
        }
        #endregion
        #region SetLook
        private void SetLook()
        {
            btnGold.Tag = 0;
            btnGold.Image = Properties.Resources._0;
            tabControl2.Location = tabControl1.Location;//btnGold.
            lblDate.Text = string.Format("{0}", FarsiDateHelper.GetLongFarsiDate(DateTime.Now));
            drawing = new Bitmap(pictureBox1.Width, pictureBox1.Height, pictureBox1.CreateGraphics());
            Graphics.FromImage(drawing).Clear(Color.White);
            tabControl1.TabPages[0].Controls.Add(pictureBox1);
            consultation.Tag = 8; diagnosis.Tag =7; symptoms.Tag = 6; complaint.Tag = 5;
            consultation.Name = "consultation"; diagnosis.Name = "diagnosis"; symptoms.Name = "symptoms"; complaint.Name = "complaint";
            consultation.BackColor =ControlPaint.LightLight( Color.FromName("Beige"));
            diagnosis.BackColor = ControlPaint.LightLight( ControlPaint.LightLight( ControlPaint.LightLight(Color.LightSeaGreen)));
            symptoms.BackColor =  ControlPaint.LightLight( ControlPaint.LightLight(ControlPaint.LightLight(Color.LightGray)));
            complaint.BackColor = ControlPaint.LightLight( ControlPaint.LightLight( ControlPaint.LightLight(Color.LightGoldenrodYellow)));
          
            consultation.Font = diagnosis.Font = symptoms.Font = complaint.Font = new System.Drawing.Font("B Yekan", 9.75F);
            
           // consultation.Size = diagnosis.Size = symptoms.Size = complaint.Size = tabControl1.TabPages[0].Size;
            consultation.Text = "مشاوره"; diagnosis.Text = "معاینات و تشخیص"; symptoms.Text = "علائم بیمار"; complaint.Text = "شکایت بیمار";
          //  consultation.UseVisualStyleBackColor = diagnosis.UseVisualStyleBackColor = symptoms.UseVisualStyleBackColor = complaint.UseVisualStyleBackColor = true;
            this.tcDescriptionDetails.Alignment = System.Windows.Forms.TabAlignment.Left;
         
            tcDescriptionDetails.Visible = false;
           //// tcDescriptionDetails.Appearance = TabAppearance.Normal;
           // tcDescriptionDetails.Margin = new System.Windows.Forms.Padding(0);
           // tcDescriptionDetails.Location = new Point(-3, -3);
           // tcDescriptionDetails.Dock = DockStyle.Fill;
           // this.tcDescriptionDetails.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right | System.Windows.Forms.AnchorStyles.Bottom)));
         pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right | System.Windows.Forms.AnchorStyles.Bottom)));
           // tcDescriptionDetails.Appearance = TabAppearance.Buttons;
           // this.tcDescriptionDetails.Font = new System.Drawing.Font("B Yekan", 9.75F);
           // this.tcDescriptionDetails.Name = "tcDescriptionDetails";
           // this.tcDescriptionDetails.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
           // this.tcDescriptionDetails.SelectedIndex = 0;
           // this.tcDescriptionDetails.Size = tabControl1.TabPages[3].Size;// new System.Drawing.Size(597, 340);// pictureBox1.Size;// 
           // this.tcDescriptionDetails.Selecting += new System.Windows.Forms.TabControlCancelEventHandler(this.tcDescriptionDetails_Selecting);
       
            
            //this.tabPage1.Cursor = System.Windows.Forms.Cursors.Default;
            //this.tabPage1.Font = new System.Drawing.Font("B Yekan", 9.75F);
            //this.tabPage1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            //this.tabPage1.Location = new System.Drawing.Point(4, 29);
     
    
            //this.tabPage1.Size = new System.Drawing.Size(591, 307);
            //this.tabPage1.TabIndex = 0;
            //this.tabPage1.Tag = "1";

            pictureBox1.Size = tabControl1.TabPages[0].Size;
             //pictureBox1.Anchor = AnchorStyles.Right;
             //pictureBox1.Anchor = AnchorStyles.Left;
             setcontrols();
             panel3.BackColor = Color.FromName("Control");
            if(ISSecretory)
            {
                btnSave.Text = "ثبت خطا";
                pictureBox1.Enabled = false;
                btnNew.Visible = false;
                gbInsertCenter.Visible = true;
                MenuTop1ToolStripMenuItem.Visible = false;
                tabControl2.TabPages[0].Text = "استعلام از داروخانه";
                cmbCenters.Enabled = cmbCenters.Visible = true;
                 SendToDrugStore();
                 btnDcumentDetails.Location = btnNew.Location;
               

            }
            else if (ISDoctor)
            {
                btnSave.Enabled = true;
                btnSave.Text = "ثبت"; 
                btnNew.Visible = true; 
                pictureBox1.Enabled = true;
                gbInsertCenter.Visible = false;
                MenuTop1ToolStripMenuItem.Visible = true;
                tabControl2.TabPages[0].Text = "تایید آزمایش";
                cmbCenters.Enabled = cmbCenters.Visible = false;

                int y = 0;
                int x = 0;
                tabControl2.TabPages[0].AutoScroll = true;

                int i = 0;
                DataSet ds = new DataSet();
                ds = da.ExecuteCommand("GetLabItems");
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    ControlDT = da.ExecuteCommand("GetLabItems").Tables[0];
                    CheckBoxTeamNames = new CheckBox[ControlDT.Rows.Count];
                    CheckBoxTeamNames1 = new CheckBox[ControlDT.Rows.Count];
                    txtTeamNames = new TextBox[ControlDT.Rows.Count];
                    Label[] LabelTeamNames = new Label[ControlDT.Rows.Count];
                    foreach (DataRow row in ControlDT.Rows)
                    {
                        var lbl = new Label();
                        LabelTeamNames[i] = lbl;
                        lbl.Name = "lbl" + row["NameLabItem"].ToString();
                        lbl.Text = " :" + row["NameLabItem"].ToString(); lbl.AutoSize = true;
                        //if (30 + tabControl1.TabPages[1].Location.Y + (i) * 30 >= tabControl1.TabPages[1].Location.Y + tabControl1.TabPages[1].Height - 30)
                        //{ x = 210; y = -(tabControl1.TabPages[1].Height - 30); }
                        lbl.Location = new Point(tabControl1.TabPages[0].Location.X, tabControl1.TabPages[0].Location.Y + y + (i * 30));
                        lbl.Visible = true;
                        lbl.ForeColor = Color.Black;
                        var txt = new TextBox();
                        txt.TextAlign = HorizontalAlignment.Left;
                        txtTeamNames[i] = txt;
                        txt.Name = row["NameLabItem"].ToString();
                        txt.Tag = row["IDLabItem"].ToString();
                        txt.Visible = true;
                        txt.Enabled = false;
                        //if (30 + tabControl1.TabPages[1].Location.Y + (i) * 30 >= tabControl1.TabPages[1].Location.Y + tabControl1.TabPages[1].Height - 30)
                        //{ x = 210; y = -(tabControl1.TabPages[1].Height - 30); }
                        txt.Location = new Point(tabControl1.TabPages[0].Location.X + 110, tabControl1.TabPages[0].Location.Y + y + (i * 30));
                        var tCh = new CheckBox();
                        tCh.CheckedChanged += checkBoxt_CheckedChanged;
                        CheckBoxTeamNames[i] = tCh;
                        tCh.Name = "t" + row["NameLabItem"].ToString();
                        tCh.Tag = row["IDLabItem"].ToString();
                        tCh.Visible = true;
                        tCh.BackColor = Color.Green;
                        tCh.Text = string.Empty;
                        //if (30 + tabControl1.TabPages[1].Location.Y + (i) * 30 >= tabControl1.TabPages[1].Location.Y + tabControl1.TabPages[1].Height - 30)
                        //{ x = 210; y = -(tabControl1.TabPages[1].Height - 30); }
                        tCh.Location = new Point(tabControl1.TabPages[0].Location.X + 125, tabControl1.TabPages[0].Location.Y + y + (i * 30));
                        var fCh = new CheckBox();
                        fCh.CheckedChanged += checkBoxf_CheckedChanged;
                        CheckBoxTeamNames1[i] = fCh; fCh.Text = string.Empty;
                        fCh.Name = "f" + row["NameLabItem"].ToString();
                        fCh.Tag = row["IDLabItem"].ToString();
                        fCh.BackColor = Color.Red;
                        //if (30 + tabControl1.TabPages[1].Location.Y + (i) * 30 >= tabControl1.TabPages[1].Location.Y + tabControl1.TabPages[1].Height - 30)
                        // { x = 210; y = -(tabControl1.TabPages[1].Height - 30); }
                        fCh.Location = new Point(tabControl1.TabPages[0].Location.X + 145, tabControl1.TabPages[0].Location.Y + y + (i * 30));
                        fCh.Visible = true;
                        tabControl2.TabPages[0].Controls.Add(lbl);
                        tabControl2.TabPages[0].Controls.Add(txt);
                        tabControl2.TabPages[0].Controls.Add(tCh);
                        tabControl2.TabPages[0].Controls.Add(fCh);
                        i++;

                    }
                }

            }
           
        }
        #endregion

        private void tabControl1_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (e.TabPage == null)
                return;
            //e.TabPage.Controls.Add(pictureBox1);
            //e.TabPage.Controls.SetChildIndex(pictureBox1, 0);
            pictureBox1.BackColor = e.TabPage.BackColor;
            if (Convert.ToInt32(e.TabPage.Tag) == 4)
            {
                tcDescriptionDetails.Visible = true;
                tabPage4.Controls.Add(tcDescriptionDetails);
                pictureBox1.Visible = true;
                pictureBox1.Enabled = true;
              //  pictureBox1.Size = tabControl1.TabPages[0].Size;
                tcDescriptionDetails.SelectedTab.Controls.Add(pictureBox1);
               // pictureBox1.Location = new Point(-80,-40 );  
            }
            else
            {
                
                pictureBox1.Visible = true;
             //   tcDescriptionDetails.Visible = false;
                pictureBox1.Size = tabControl1.TabPages[0].Size;
                //pictureBox1.Location = tabControl1.Location;
                e.TabPage.Controls.Add(pictureBox1);
                e.TabPage.Controls.SetChildIndex(pictureBox1, 0);
         
                //tabPage4.Controls.Remove(tcDescriptionDetails);
            }

        }
        #region Menu 
        private void menuStrip2_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            pictureBox1.Invalidate();
            pictureBox1.Enabled = true;
            grdDocuments.SelectionChanged -= grdDocuments_SelectionChanged;
            grdDocuments.DataSource = null;
            grdDocuments.SelectionChanged += grdDocuments_SelectionChanged;

        }
        #region FillMenu
        private void FillMenu()
        {
            string eventlog = "Fill Departments Menu";
            try
            {
                sectionDS = da.ExecuteCommand("GetActiveDep");
                menuStrip1.Items.Clear();
                int i = 0;
                ToolStripMenuItem[] items = new ToolStripMenuItem[sectionDS.Tables[0].Rows.Count]; // You would obviously calculate this value at runtime
                foreach (DataRow Row in sectionDS.Tables[0].Rows)// there is one department in each row 
                {
                    items[i] = new ToolStripMenuItem();
                    items[i].Name = "Item" + i.ToString();
                    items[i].Tag = Row["DepartmentID"];// set tag by department ID
                    items[i].Text = Row["DepartmentName"].ToString();// set tag by department Name
                    menuStrip1.Items.Add(items[i]);// add items to menuStrip control from DS
                    i++;
                }
               menuStrip1.Items[0].PerformClick();// = true;

                menuStrip1.Items[0].Select(); SelectMenuRight(menuStrip1.Items[0]);
                
            }
            catch
            {
                NewMethod_eventlog(eventlog, 15007);
                throw;
            }
        }
        #region eventlog

        private static void NewMethod_eventlog(string eventlog, int id)
        {
            EventLog log = new EventLog();
            //log.taskca
            log.Source = "application";
            log.WriteEntry(eventlog, EventLogEntryType.Information, id);
        }
        #endregion
      
        #endregion

        private void SelectMenuRight(ToolStripItem menuItem)
        {
            for (int o = 0; o < menuStrip1.Items.Count; o++)
            {   // menuStrip1.Items[0].BackColor = menuStrip1.Items[1].BackColor = menuStrip1.Items[2].BackColor = menuStrip1.Items[3].BackColor = Color.Transparent;
                menuStrip1.Items[o].BackColor = Color.Transparent;
                menuStrip1.Items[o].ForeColor = Color.Black;
                // menuStrip1.Items[0].ForeColor = menuStrip1.Items[1].ForeColor = menuStrip1.Items[2].ForeColor = menuStrip1.Items[3].ForeColor = Color.Black;
            } menuItem.BackColor = color;
            menuItem.ForeColor = Color.White;
            menuActiveRight = menuItem;
        }

        private void SelectMenuTop(ToolStripMenuItem menuItem)
        {
            MenuTop1ToolStripMenuItem.Checked = false;
            MenuTop3ToolStripMenuItem.Checked = false;
            MenuTop4ToolStripMenuItem.Checked = false;
            MenuTop1ToolStripMenuItem.BackColor = Color.Transparent;
            MenuTop3ToolStripMenuItem.BackColor = Color.Transparent;
            MenuTop4ToolStripMenuItem.BackColor = Color.Transparent;
            MenuTop1ToolStripMenuItem.ForeColor = Color.Black;
            MenuTop3ToolStripMenuItem.ForeColor = Color.Black;
            MenuTop4ToolStripMenuItem.ForeColor = Color.Black;
            menuItem.Checked = true;
            menuItem.BackColor = color;
            menuItem.ForeColor = Color.White;
            menuActiveTop = menuItem;
        }
        #endregion 
        #region LabREsultInfo
        public class LabResult// اینفوی اطلاعات بیمار
        {
            public string SecondValueItemLab;
            public string valueItemLab;
            public int iDItemLab;
            public bool statusItem;
            public long id;
            public int IDdocument;
            public LabResult()
            { }
            public LabResult(string SecondValueItemLab, int iDItemLab, string valueItemLab, bool statusItem, long id, int IDdocument)
            {
                this.SecondValueItemLab = SecondValueItemLab;
                this.iDItemLab = iDItemLab;
                this.valueItemLab = valueItemLab;
                this.statusItem = statusItem;
                this.id = id;
                this.IDdocument = IDdocument;

            }
            public LabResult(int IDdocument, int id, int iDItemLab, string valueItemLab)
            {
                this.id = id;
                this.IDdocument = IDdocument;
                this.iDItemLab = iDItemLab;
                this.valueItemLab = valueItemLab;
            }

            public string secondValueItemLab
            {
                get { return SecondValueItemLab; }
                set { SecondValueItemLab = value; }
            }

            public int IDItemLab
            {
                get { return iDItemLab; }
                set { iDItemLab = value; }
            }

            public string ValueItemLab
            {
                get { return valueItemLab; }
                set { valueItemLab = value; }
            }

            public bool StatusItem
            {
                get { return statusItem; }
                set { statusItem = value; }
            }
            public long ID
            {
                get { return id; }
                set { id = value; }
            }
            public int IDDocument
            {
                get { return IDdocument; }
                set { IDdocument = value; }
            }

        }
        #endregion
        #region PictureBox
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            _Previous = new Point(e.X, e.Y);
            pictureBox1_MouseMove(sender, e);
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {      
            
            Pen _Pen = new Pen(myBrush);
            if(size==(byte)2)
            _Pen.Width=2;
            else
                _Pen.Width =1;      

            _Pen.EndCap = LineCap.Round;
            _Pen.StartCap = LineCap.Round;

            if (_Previous != null)
            {
                if (pictureBox1.Image == null)
                {
                    Bitmap bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
                    using (Graphics g = Graphics.FromImage(bmp))
                    {
                        g.Clear(pictureBox1.BackColor);
                    }
                    pictureBox1.Image = bmp;
                }
                using (Graphics g = Graphics.FromImage(pictureBox1.Image))
                {
                    g.DrawLine(_Pen, _Previous.Value.X, _Previous.Value.Y, e.X, e.Y);
                }
                pictureBox1.Invalidate();
                pictureBox1.Enabled = true;

                _Previous = new Point(e.X, e.Y);
            }
            
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            _Previous = null;
        }
        #endregion
        #region Grid

        #region GridSet
        private void GridSet()
        {
            dt = new DataTable();
            dt.Columns.Add(IDIntermittence.Name);
            dt.Columns.Add(CodeCol.Name);
            dt.Columns.Add(CustomerCol.Name);
            grdIntermittenc.DataSource = dt;
        }
        private void GridDocumentsSet()
        {
            DataGridViewTextBoxColumn IDImage = new DataGridViewTextBoxColumn();
            IDImage.Name = "ID";
            IDImage.HeaderText = "ID";
            IDImage.DataPropertyName = "ID";
            IDImage.Visible = false;
            IDImage.Width = 5;

            DataGridViewTextBoxColumn DocumentType = new DataGridViewTextBoxColumn();
            DocumentType.Name = "DocumentType";
            DocumentType.HeaderText = "DocumentType";
            DocumentType.Visible = false;
            DocumentType.Width = 5;
            DocumentType.DataPropertyName = "DocumentType";

            DataGridViewImageColumn imgColumn = new DataGridViewImageColumn();
            imgColumn.Name = "image";
            imgColumn.DataPropertyName = "image";
            imgColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            imgColumn.MinimumWidth = 500;
            imgColumn.Width = 700;
            imgColumn.ImageLayout =(DataGridViewImageCellLayout) ImageLayout.Tile;

            DataGridViewTextBoxColumn CenterIDSent = new DataGridViewTextBoxColumn();
            CenterIDSent.Name = "CenterIDSent";
            CenterIDSent.HeaderText = "CenterIDSent";
            CenterIDSent.Visible = false;
            CenterIDSent.Width = 5;
            CenterIDSent.DataPropertyName = "CenterIDSent";

            DataGridViewTextBoxColumn DateModified = new DataGridViewTextBoxColumn();
            DateModified.Name = "DateModified";
            DateModified.HeaderText = "DateModified";
            DateModified.Visible = true;
            DateModified.Width = 5;
            DateModified.DataPropertyName = "DateModified";

        }
        #endregion

        private void FillGrid(DataTable GridDataSourceDS)
        {
            if (GridDataSourceDS == null) return;
              grdIntermittenc.SelectionChanged -= grdIntermittenc_SelectionChanged;
               smsDt.Rows.Clear();
            if (grdIntermittenc.Rows.Count > 0)
                grdIntermittenc.Rows.Clear();
            if (grdIntermittenc.DataSource != null)
                smsDt = (DataTable)grdIntermittenc.DataSource;
            if (GridDataSourceDS.Rows.Count == 0) return;
            foreach (DataRow row in GridDataSourceDS.Rows)
            {

                    DataRow dr = smsDt.Rows.Add();
                    if (GridDataSourceDS.Columns.Contains("ID")
                    )
                    dr["IDIntermittence"] = (row["ID"]);
                    dr["CodeCol"] = row["NationalityCode"];
                    dr["CustomerCol"] = row["Name"];
                    Int32 index = grdIntermittenc.Rows.Count - 1;
                    grdIntermittenc.Rows[index].Tag = row;

            }
            
           grdIntermittenc.DataSource = smsDt;
           grdIntermittenc.Columns["IDIntermittence"].Visible = false;
           this.grdIntermittenc.Columns["CustomerCol"].DefaultCellStyle.Alignment =
           this.grdIntermittenc.Columns["CodeCol"].DefaultCellStyle.Alignment =
           DataGridViewContentAlignment.MiddleRight;
           grdIntermittenc.ClearSelection();
           grdIntermittenc.SelectionChanged += grdIntermittenc_SelectionChanged;
        }
        private void FillDocumentsGrid()
        {
            if (grdIntermittenc.SelectedRows.Count != 1) return;
            grdDocuments.SelectionChanged -= grdDocuments_SelectionChanged;
            if (grdDocuments.Rows.Count > 0)
                grdDocuments.DataSource=null;
              
            if (grdIntermittenc.SelectedRows.Count==1)
            Id = ( grdIntermittenc.SelectedRows[0].Cells[1].Value).ToString();
            if (Id == "0")
            { Id = (grdIntermittenc.Rows[0].Cells[1].Value).ToString(); }
            SqlParameter[] param;
            param = new SqlParameter[1];
            int index = 0;
            param[index++] = new SqlParameter("@NationalityCode", Id);
            DataSet ds = new DataSet();
            if (MenuTop1ToolStripMenuItem.Checked)// اگر کارتابل پزشک جهت تایید آزمایش ها کلیک شده بود
            {
                ds = da.ExecuteSP("GetDocumentForVerifyInfo", param);
                if (ds == null || ds == null && (ds.Tables[0].Rows.Count == 0)|| ds.Tables[0].Rows.Count==0) return;
                DocumentDT = ds.Tables[0];
                grdDocuments.DataSource = DocumentDT;
            }
            else
            { 

            ds=da.ExecuteSP("GetDocumentInfo", param) ;
            if (ds == null || ds==null&&( ds.Tables[0].Rows.Count == 0)) return;
            DocumentDT = ds.Tables[0];
            grdDocuments.DataSource = DocumentDT;

            }
              //((DataGridViewColumn)this.grdDocuments.Columns["image"]) = DataGridViewImageCellLayout.Zoom;

                if (grdDocuments.Rows.Count>0)
                {
                  grdDocuments.Columns["CenterIDSent"].Visible = grdDocuments.Columns["ID"].Visible =
                  grdDocuments.Columns["DocumentType"].Visible = false;
                  // grdDocuments.Columns["image"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                  this.grdDocuments.Columns["DateModified"].MinimumWidth =15; this.grdDocuments.Columns["DateModified"].FillWeight = 15; 
                  this.grdDocuments.Columns["DateModified"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight;this.grdDocuments.Columns["DateModified"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                  this.grdDocuments.Columns["image"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None; 
                    grdDocuments.FirstDisplayedScrollingRowIndex = grdDocuments.RowCount - 1;
               // grdDocuments.Rows[grdDocuments.Rows.Count-1].Selected = true; 
                grdDocuments.ClearSelection();
                }
                //grdDocuments.Rows.OfType<DataGridViewRow>().Last().Selected = true;
              
                grdDocuments.SelectionChanged += grdDocuments_SelectionChanged;
        }

        #endregion


       
        private void Insert()
        {
            if (grdDocuments.Rows.Count>0 && grdDocuments.SelectedRows.Count != 1) 
            {
                buttonToolTip.ToolTipTitle = "خطا";
                buttonToolTip.UseFading = true;
                buttonToolTip.UseAnimation = true;
                buttonToolTip.IsBalloon = true;
                buttonToolTip.ShowAlways = false;
                //buttonToolTip.AutoPopDelay = 100;
                buttonToolTip.InitialDelay = 0;
                IWin32Window win = this;
                buttonToolTip.Show("لطفا نسخه را انتخاب کنید.", win, 3000);
                return;
            }
            
            if (MenuTop1ToolStripMenuItem.Checked == true)// اگر کارتابل 
            {
                int index3 = 0;
                if (grdIntermittenc.SelectedRows.Count > 0)
                    index3 = grdIntermittenc.SelectedRows[0].Index;
          
                XmlDocument doc = new XmlDocument();
                string xml = "<labResultList>";
                List<LabResult> LabResultList = new List<LabResult>();

                foreach (DataRow row in ControlDT.Rows)
                {
                    CheckBox chkTrue = tabControl2.TabPages[0].Controls.Find("t" + row["NameLabItem"].ToString(), true).FirstOrDefault() as CheckBox;
                    CheckBox chkfal = tabControl2.TabPages[0].Controls.Find("f" + row["NameLabItem"].ToString(), true).FirstOrDefault() as CheckBox;
                    TextBox txt = tabControl2.TabPages[0].Controls.Find(row["NameLabItem"].ToString(), true).FirstOrDefault() as TextBox;
                    LabResult labResult = new LabResult();
                    string tmpStr = "";
                    if (txt.Text != null)
                        tmpStr = txt.Text;
                    if (tmpStr != string.Empty && tmpStr.ToString() != "" && tmpStr != null)
                    {
                        labResult.ID =Convert.ToInt32( chkTrue.Tag);
                        labResult.IDdocument = Convert.ToInt32(grdDocuments.SelectedRows[0].Cells["ID"].Value);
                        labResult.IDItemLab = Convert.ToInt32(chkTrue.Tag);
                        labResult.valueItemLab = tmpStr;
                        if (chkTrue.Checked == false && chkfal.Checked == false) labResult.StatusItem = true; else 
                        labResult.StatusItem = chkTrue.Checked == true ? true : false;
                        LabResultList.Add(labResult);
                    }

                }



                if (LabResultList != null && LabResultList.Count > 0)
                {
                    foreach (LabResult lr in LabResultList)
                    {
                        if (lr.IDItemLab != 0 && lr.IDItemLab.ToString() != "")
                            xml += string.Format(@"<labResultList ID=""{0}"" IDDocument=""{1}"" IDItemLab=""{2}"" ValueItemLab=""{3}"" StatusItem=""{4}""",
                                            lr.ID,
                                            lr.IDDocument, lr.IDItemLab, lr.ValueItemLab,lr.StatusItem);

                        xml += "  />";
                    }
                }

                xml += "</labResultList>";
                doc.InnerXml = xml;

                SqlParameter[] param;
                param = new SqlParameter[3];
                bool result;
                int index = 0;

                if (!String.IsNullOrEmpty(xml))
                param[index++] = new SqlParameter("@XmlDocument", xml);
                param[index++] = new SqlParameter("@TableName", "LabResult");
                result = Convert.ToBoolean(this.da.ExecuteScalarSP("SetVerifyLabResultInfo", param));
                if (result)
                {
                    buttonToolTip.ToolTipTitle = "ثبت";
                    buttonToolTip.UseFading = true;
                    buttonToolTip.UseAnimation = true;
                    buttonToolTip.IsBalloon = true;
                    buttonToolTip.ShowAlways = false;
                    buttonToolTip.AutoPopDelay = 100;
                    buttonToolTip.InitialDelay = 0;
                    IWin32Window win = this;
                    buttonToolTip.Show("ثبت با موفقیت انجام شد.", win, 3000);
                    // var msg = "ثبت با موفقیت انجام شد"; MessageForm.Show(msg, "ثبت", MessageFormIcons.Info, MessageFormButtons.Ok, Properties.Settings.Default.Color);
                    GridDataSourceDS = da.ExecuteCommand("GetLabsForVerifyByDoctor", DepartmentID);
                    if (GridDataSourceDS != null && GridDataSourceDS.Tables.Count > 0 && GridDataSourceDS.Tables[0].Rows.Count > 0)
                    {
                        FillGrid(GridDataSourceDS.Tables[0]);
                       // grdIntermittenc.Rows.OfType<DataGridViewRow>().First().Selected = true;
                        //if (grdIntermittenc.Rows.Count > 0)
                        //    grdIntermittenc.Rows[0].Selected = false;
                        if (grdIntermittenc.Rows.Count >= index3 + 1)
                            grdIntermittenc.Rows[index3].Selected = true;
            
                        MenuTop1ToolStripMenuItem.Text = "";
                        MenuTop1ToolStripMenuItem.Text = grdIntermittenc.Rows.Count.ToString() + " " + "کارتابل";
                      
                    }
                    else 
                    {
                        grdIntermittenc.SelectionChanged -= grdIntermittenc_SelectionChanged;
                        dt.Rows.Clear();
                        grdIntermittenc.DataSource = dt;
                        grdIntermittenc.SelectionChanged += grdIntermittenc_SelectionChanged;
                        grdDocuments.SelectionChanged -= grdDocuments_SelectionChanged;
                        DocumentDT.Rows.Clear();
                        grdDocuments.DataSource = DocumentDT;
                        grdDocuments.SelectionChanged += grdDocuments_SelectionChanged;
                        MenuTop1ToolStripMenuItem.Text = "";
                        MenuTop1ToolStripMenuItem.Text = "0"+ " " + "کارتابل";
                        foreach (Control c in tabControl2.TabPages[0].Controls)
                        {
                            if (c is CheckBox)
                                ((CheckBox)c).Checked = false;
                            if (c is TextBox)
                                ((TextBox)c).Text = "";
                        }
                    }
                  
                    
                }
                else
                {
                    var msg = "در روند ثبت خطایی رخ داده است."; MessageForm.Show(msg, "ثبت", MessageFormIcons.Warning, MessageFormButtons.Ok, Properties.Settings.Default.Color);
                }

            }
            else if (grdDocuments.SelectedRows.Count>0&&
                  (Convert.ToInt32(tabControl1.SelectedTab.Tag) == 2)
                &&
                CheckIFThereIsResultForDocument(Convert.ToInt32(grdDocuments.SelectedRows[0].Cells["ID"].Value),  Convert.ToInt16(grdDocuments.SelectedRows[0].Cells["DocumentType"].Value)))
            {
                int width = pbComment.Size.Width;
                int height = pbComment.Size.Height;
                using (Bitmap bmp = new Bitmap(width, height))
                {
                    pbComment.DrawToBitmap(bmp, new Rectangle(0, 0, width, height));
                    ImageConverter converter = new ImageConverter();
                    SqlParameter[] param;
                    param = new SqlParameter[5];
                    int index = 0;
                    param[index++] = new SqlParameter("@CommentImage", (byte[])converter.ConvertTo(bmp, typeof(byte[])));
                    param[index++] = new SqlParameter("@IDDocument", Convert.ToInt32(grdDocuments.SelectedRows[0].Cells["ID"].Value));
                    param[index++] = new SqlParameter("@ID",Convert.ToInt32( pbComment.Tag));


                    if (Convert.ToInt32(da.ExecuteScalarSP("SetCommentImage", param)) == 1)
                    {
                        buttonToolTip.ToolTipTitle = "ثبت";
                        buttonToolTip.UseFading = true;
                        buttonToolTip.UseAnimation = true;
                        buttonToolTip.IsBalloon = true;
                        buttonToolTip.ShowAlways = false;
                        buttonToolTip.AutoPopDelay = 100;
                        buttonToolTip.InitialDelay = 0;
                        IWin32Window win = this;
                        buttonToolTip.Show("ثبت با موفقیت انجام شد.", win, 3000);
                       
                    }
                    else
                    {
                        var msg = "در روند ثبت خطایی رخ داده است."; MessageForm.Show(msg, "ثبت", MessageFormIcons.Warning, MessageFormButtons.Ok, Properties.Settings.Default.Color);

                    }
                }

            }
            else
            {
                int width = pictureBox1.Size.Width;
                int height = pictureBox1.Size.Height;
                using (Bitmap bmp = new Bitmap(width, height))
                {
                    pictureBox1.DrawToBitmap(bmp, new Rectangle(0, 0, width, height));
                    ImageConverter converter = new ImageConverter();
                    SqlParameter[] param;
                    param = new SqlParameter[5];
                    int index = 0;
                    param[index++] = new SqlParameter("@Image", (byte[])converter.ConvertTo(bmp, typeof(byte[])));
                    param[index++] = new SqlParameter("@NationalityCode", Id);
                    param[index++] = new SqlParameter("@DateModified", DateTime.Now);
                    if (Convert.ToInt32(tabControl1.SelectedTab.Tag) == 4)

                        param[index++] = new SqlParameter("@DocumentType", tcDescriptionDetails.SelectedTab.Tag);
                    else
                        param[index++] = new SqlParameter("@DocumentType", tabControl1.SelectedTab.Tag);
                    param[index++] = new SqlParameter("@IDSection", DepartmentID);
                    if (Convert.ToInt32(da.ExecuteScalarSP("SetPrescription", param)) == 1)
                    {
                        buttonToolTip.ToolTipTitle = "ثبت";
                        buttonToolTip.UseFading = true;
                        buttonToolTip.UseAnimation = true;
                        buttonToolTip.IsBalloon = true;
                        buttonToolTip.ShowAlways = false;
                        buttonToolTip.AutoPopDelay = 100;
                        buttonToolTip.InitialDelay = 0;
                        IWin32Window win = this;
                        buttonToolTip.Show("ثبت با موفقیت انجام شد.", win, 3000);
                        FillDocumentsGrid();
                        if (grdDocuments.Rows.Count > 0)
                            grdDocuments.Rows.OfType<DataGridViewRow>().Last().Selected = true;

                    }
                    else
                    {
                        var msg = "در روند ثبت خطایی رخ داده است."; MessageForm.Show(msg, "ثبت", MessageFormIcons.Warning, MessageFormButtons.Ok, Properties.Settings.Default.Color);

                    }
                }

            }

        }
        private void button1_Click(object sender, EventArgs e)
        {
            if(ISDoctor)
            {
                Insert();
                if (pictureBox1.Image != null)
                {
                    pictureBox1.Image.Dispose();
                    pictureBox1.Image = null;
                }
                pictureBox1.Invalidate();
                pictureBox1.Enabled = true;

            }
            else if (ISSecretory)

            {
                if (grdDocuments.SelectedRows.Count!= 1)
                    return;
                SqlParameter[] param;
                param = new SqlParameter[2];
                int index = 0;
               
                int IDCenter =Convert.ToInt32( grdDocuments.SelectedRows[0].Cells["CenterIDSent"].Value);
                param[index++] = new SqlParameter("@IDCenter", IDCenter);
                param[index++] = new SqlParameter("@IDDocument", Convert.ToInt32(grdDocuments.SelectedRows[0].Cells["ID"].Value));
                if (Convert.ToInt32(da.ExecuteScalarSP("SetReportError", param)) == 1)
                {
                    buttonToolTip.ToolTipTitle = "ثبت خطا";
                    buttonToolTip.UseFading = true;
                    buttonToolTip.UseAnimation = true;
                    buttonToolTip.IsBalloon = true;
                    buttonToolTip.ShowAlways = false;
                    buttonToolTip.AutoPopDelay = 100;
                    buttonToolTip.InitialDelay = 0;
                    IWin32Window win = this;
                    buttonToolTip.Show(" ثبت خطای مرکز " + cmbCenters.Text + "  ثبت شد . ", btnSave, MousePosition,3000);
                }

            }
        }
        private void button2_Click(object sender, EventArgs e)
        {  
             if(grdIntermittenc.SelectedRows.Count>0)
            {
                int currentRow = grdIntermittenc.SelectedRows[0].Index;
                 string value = "";
                int index1 = 0;
            if(currentRow==grdIntermittenc.Rows.Count-1)
                   value = (grdIntermittenc.Rows[0].Cells["CodeCol"].Value).ToString();
              
            else   value = (grdIntermittenc.Rows[currentRow+1].Cells["CodeCol"].Value).ToString();
              
            
          if ((MenuTop4ToolStripMenuItem.Checked == true && ISDoctor)  && grdDocuments.Rows.Count>0)
            {
                SqlParameter[] param;
                param = new SqlParameter[2];
                int index = 0;
                param[index++] = new SqlParameter("@NationalityCode", Id);
                param[index++] = new SqlParameter("@IDSection", DepartmentID);
                if (Convert.ToInt32(da.ExecuteScalarSP("SetVisiteForaInttermitence", param)) == 1)
                {
                   //$ menuStrip1_ItemClicked(null, null);
                  
                    //
                    GridDataSourceDS = null;
                    GridDataSourceDS = da.ExecuteCommand("GetAllDoctorIntermittences", DepartmentID);
                    MenuTop3ToolStripMenuItem.Text = "";
                    if (GridDataSourceDS != null && GridDataSourceDS.Tables.Count > 0 && GridDataSourceDS.Tables[0].Rows.Count > 0)
                    {
                        MenuTop3ToolStripMenuItem.Text = GridDataSourceDS.Tables[0].Rows.Count.ToString() + " " + "کل بیماران";

                    }
                    else
                    {
                        MenuTop3ToolStripMenuItem.Text = "0" + " " + "کل بیماران";

                    }
                    GridDataSourceDS = null;
                    GridDataSourceDS = da.ExecuteCommand("GetLabsForVerifyByDoctor", DepartmentID);
                    MenuTop1ToolStripMenuItem.Text = "";
                    if (GridDataSourceDS != null && GridDataSourceDS.Tables.Count > 0 && GridDataSourceDS.Tables[0].Rows.Count > 0)
                    {
                        MenuTop1ToolStripMenuItem.Text = GridDataSourceDS.Tables[0].Rows.Count.ToString() + " " + "کارتابل";
                    }
                    else
                    {
                        MenuTop1ToolStripMenuItem.Text = "0" + " " + "کارتابل";
                    }


                    GridDataSourceDS = null;
                    GridDataSourceDS = da.ExecuteCommand("GetTodayIntermittences", DepartmentID);
                    MenuTop4ToolStripMenuItem.Text = "";
                    
                    if (GridDataSourceDS != null && GridDataSourceDS.Tables.Count > 0 && GridDataSourceDS.Tables[0].Rows.Count > 0)
                    {
                        MenuTop4ToolStripMenuItem.Text = GridDataSourceDS.Tables[0].Rows.Count.ToString() + " " + "نویت های امروز";
                        FillGrid(GridDataSourceDS.Tables[0]);

                    }
                    else
                    {
                        MenuTop4ToolStripMenuItem.Text = "0" + " " + "نویت های امروز";
                    }


                    SelectMenuTop(MenuTop4ToolStripMenuItem);
                     if (grdIntermittenc.Rows.Count > 0)
                     {
                         if (-1 < currentRow + 1 && currentRow < grdIntermittenc.Rows.Count+1)
                         {
                             grdIntermittenc.SelectionChanged -= grdIntermittenc_SelectionChanged;
                             grdDocuments.SelectionChanged -= grdDocuments_SelectionChanged;
                             DocumentDT.Rows.Clear();
                             grdDocuments.DataSource = DocumentDT;
                             grdDocuments.SelectionChanged += grdDocuments_SelectionChanged;
                             grdIntermittenc.ClearSelection();  grdIntermittenc.SelectionChanged += grdIntermittenc_SelectionChanged;
                             if(currentRow-1==-1)
                                 grdIntermittenc.Rows[0].Selected = true;

                             else         foreach (DataGridViewRow row in grdIntermittenc.Rows)
                    {
                        if (row.Cells[1].Value.ToString().Equals(value))
                        {
                            row.Selected = true;
                            break;
                        }
                    }

                             //else if(currentRow==grdIntermittenc.Rows.Count)
                             //    grdIntermittenc.Rows[currentRow-1].Selected = true;
                             //else   grdIntermittenc.Rows[currentRow].Selected = true;
                         }
                         //grdIntermittenc.Rows[currentRow].Selected = true;
                        
                     }
                     else
                     {
                         grdDocuments.SelectionChanged -= grdDocuments_SelectionChanged;
                         DocumentDT.Rows.Clear();
                         grdDocuments.DataSource = DocumentDT;

                         grdDocuments.SelectionChanged += grdDocuments_SelectionChanged;
                         if (pictureBox1.Image != null)
                         {
                             pictureBox1.Image.Dispose();
                             pictureBox1.Image = null;
                         }
                         pictureBox1.Invalidate();
                         pictureBox1.Enabled = true;

                     }
                }
                else
                {

                }



               
                

            }
          else if (-1 < currentRow + 1 && currentRow + 1 < grdIntermittenc.Rows.Count)
                {

                  //  grdIntermittenc.SelectionChanged -= grdIntermittenc_SelectionChanged; 
              grdIntermittenc.ClearSelection();
                    grdIntermittenc.Rows[currentRow + 1].Selected = true;
                    grdIntermittenc.SelectionChanged += grdIntermittenc_SelectionChanged;

                }
          
            }
           
     
           
        }
        private void setcontrols()
        {
            //pnl.Padding = new Padding(0, 0, 0, 0);
            //pnl.Margin = new Padding(0, 0, 0, 0);
            //pnl.Location = tabControl1.TabPages[1].Location;// new Point(tabControl1.TabPages[1].Location.Y - 7, tabControl1.TabPages[1].Location.X);
            //pnl.Height = tabControl1.TabPages[0].Size.Height;
            //pnl.Width = tabControl1.TabPages[0].Size.Width;
        pnl.AutoScroll = true;
        int i = 0;
        try
        {
            ControlDT = da.ExecuteCommand("GetLabItems").Tables[0];
            txtTeamNames = new TextBox[ControlDT.Rows.Count];
            Label[] LabelTeamNames = new Label[ControlDT.Rows.Count];
            foreach (DataRow row in ControlDT.Rows)// (int i = 0; i < txtTeamNames.Length; i++)
            {

                var lbl = new Label();
                int y = pnl.Location.Y + 17;
                LabelTeamNames[i] = lbl;
                lbl.Name = "lbl" + row["NameLabItem"].ToString();
                lbl.Text = " :" + row["NameLabItem"].ToString();
                lbl.Location = new Point(pnl.Location.X + 10, y + (i * 28));
                lbl.Visible = true;
                lbl.AutoSize = true;
                lbl.Tag = row["NameLabItem"].ToString();
                var txt = new TextBox();
                txt.Enabled = false;
                txtTeamNames[i] = txt;
                txt.Name = row["NameLabItem"].ToString();
                txt.Tag = row;
                txt.Location = new Point(pnl.Location.X + 120, y + (i * 28));
                txt.Visible = true;
                pnl.Controls.Add(txt);
                pnl.Controls.Add(lbl);

                i++;



            }
        }
        catch
        {
            var msg = "tabControl1_Selecting"; MessageForm.Show(msg, "ثبت", MessageFormIcons.Warning, MessageFormButtons.Ok, Properties.Settings.Default.Color);
        }

        pnl.Visible = false;


        }
        private void grdIntermittenc_SelectionChanged(object sender, EventArgs e)
        {
            
            if (MenuTop4ToolStripMenuItem.Checked || MenuTop3ToolStripMenuItem.Checked)
            {
                if (pictureBox1.Image != null)
                {
                    pictureBox1.Image.Dispose();
                    pictureBox1.Image = null;
                }
                pictureBox1.Invalidate();
                pictureBox1.Enabled = true;

                cmbCenters.Text = "";
                cmbCenters.DataSource = null;
                FillDocumentsGrid();
                if (grdDocuments.Rows.Count > 0)
                    grdDocuments.Rows.OfType<DataGridViewRow>().Last().Selected = true;
                else
                    tabControl1.Visible = true;
            }
            else if (MenuTop1ToolStripMenuItem.Checked)
            {
                btnSave.Enabled = true;
                foreach (Control c in tabControl2.TabPages[0].Controls)
                {
                    if (c is CheckBox)
                        ((CheckBox)c).Checked = false;
                    if (c is TextBox)
                        ((TextBox)c).Text = "";
                }
                FillDocumentsGrid();
                if (grdDocuments.Rows.Count > 0)
                    grdDocuments.Rows.OfType<DataGridViewRow>().Last().Selected = true;
            }

        }
        private void tabPage2_Click(object sender, EventArgs e)
        {
            tabPage2.Controls.Add(pictureBox1);
            tabPage2.Controls.SetChildIndex(pictureBox1, 0);

        }
        private void tcDescriptionDetails_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (e.TabPage == null)
                return;
            e.TabPage.Controls.Add(pictureBox1);
            e.TabPage.Controls.SetChildIndex(pictureBox1, 0);
            pictureBox1.BackColor= e.TabPage.BackColor;
            //pictureBox1.Enabled = true;
            //if (Convert.ToInt32(e.TabPage.Tag) == 4)
            //{
            //    tcDescriptionDetails.Visible = true;fse
            //    tabPage4.Controls.Add(tcDescriptionDetails);
            //    pictureBox1.Visible = false;
            //}
            //else
            //{
            //    pictureBox1.Visible = true;
            //    tcDescriptionDetails.Visible = false;
            //    tabPage4.Controls.Remove(tcDescriptionDetails);
            //}

        }
        private void FillCombo(short Type)
        {
            cmbCenters.Items.Clear();
            centersDT = new DataTable();
            SqlParameter[] param;
            param = new SqlParameter[1];
            int index = 0;
            param[index++] = new SqlParameter("@CenterType", Type);
            DataSet dds = new DataSet();
            dds= da.ExecuteSP("GetCentersBriefInfo", param);
            if (dds == null || dds == new DataSet() || dds.Tables.Count == 0) return;
            centersDT = dds.Tables[0];
             
            foreach (DataRow row in centersDT.Rows)
            {

                cmbCenters.Items.Add(new ComboItem(row["NameCenters"].ToString(), Convert.ToInt32(row["IDCenters"])));
               
            }
          
        }
        public class ComboItem : object
	{
            public String m_Name;
        public int m_Value;
		
		public ComboItem(String name, int in_value)
		{
			m_Name	= name;
		
			m_Value	= in_value;
		}

		public override string ToString()
		{
			return m_Name;
		}

	};
        private void textBox1_TextChanged(object sender, EventArgs e)
        {    
            
            DataTable dtSearch = new DataTable();
          
            DataTable dtSearched = new DataTable();

            if (!(textBox1.Text.Trim() == "" || textBox1.Text == string.Empty) && grdIntermittenc.Rows.Count > 0)
            {  dtSearch = GridDataSourceDS.Tables[0].Copy();
                if (IntOrChar)
                {
                    DataRow[] resultss = dtSearch.AsEnumerable().Where(row => row.Field<string>("NationalityCode").Contains(textBox1.Text.Trim())).Select(row => row).ToArray<DataRow>();
                    dtSearched = dtSearch.Copy();
                    dtSearched.Rows.Clear();

                    foreach (DataRow row in resultss)
                    {
                        dtSearched.ImportRow(row);
                    }
                    FillGrid(dtSearched);
                }
                else
                {
                    DataRow[] resultss = dtSearch.AsEnumerable().Where(row => row.Field<string>("Name").Contains(textBox1.Text.Trim())).Select(row => row).ToArray<DataRow>();
                    dtSearched = dtSearch.Copy();
                    dtSearched.Rows.Clear();

                    foreach (DataRow row in resultss)
                    { 
                        dtSearched.ImportRow(row); }
                    FillGrid(dtSearched);
                }
 
            }
            else
            { FillGrid(GridDataSourceDS.Tables[0]); }   
        }
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Char.IsDigit(e.KeyChar) || (e.KeyChar == (char)Keys.Back)))
            {
                IntOrChar = true;
            }
            else { IntOrChar = false; }
            if (e.KeyChar == '\b')
            {
                e.Handled = false;
                return;
            }
           
           
        }
        private void cmbCenters_SelectedValueChanged(object sender, EventArgs e)
        {
             
            if (grdDocuments.SelectedRows.Count!= 1)
                return;
            SqlParameter[] param;
            param = new SqlParameter[3];
            int index = 0;
            ComboItem centerIDSent = ((ComboItem)cmbCenters.SelectedItem);
            if (centerIDSent == null)
                return;
                int IDCenter = Convert.ToInt32(centerIDSent.m_Value);
                param[index++] = new SqlParameter("@DocumentType", 2);
                param[index++] = new SqlParameter("@IDCenter", IDCenter);
                param[index++] = new SqlParameter("@IDDocument", Convert.ToInt32(grdDocuments.SelectedRows[0].Cells["ID"].Value));
                if (Convert.ToInt32(da.ExecuteScalarSP("SetCenterForDocument", param)) == 1)
                {
                    buttonToolTip.ToolTipTitle = "ثبت";
                    buttonToolTip.UseFading = true;
                    buttonToolTip.UseAnimation = true;
                    buttonToolTip.IsBalloon = true;
                    buttonToolTip.ShowAlways = false;
                    buttonToolTip.AutoPopDelay = 100;
                    buttonToolTip.InitialDelay = 0;
                    IWin32Window win = this;
                    buttonToolTip.Show(" مرکز " + cmbCenters.Text + " برای این نسخه ثبت شد . ", win, MousePosition, 5000);
                  
                    if (grdDocuments.SelectedRows.Count >0)
                    {
                        grdDocuments.SelectedRows[0].Cells["CenterIDSent"].Value = IDCenter;
                        btnSave.Enabled = true;
                        gbInsertCenter.Visible = true;
                        cmbCenters.Enabled = false;
                       
                    }
                   
                }


           
        }
        private void grdDocuments_SelectionChanged(object sender, EventArgs e)
        { 
            // if(grdDocuments.SelectedRows.Count!=1) return;

            // if (grdDocuments.SelectedRows.Count != 1) return;
            if (grdDocuments.SelectedRows.Count == 0 && grdDocuments.CurrentRow != null)
            {
                int i = grdDocuments.CurrentRow.Index;
                grdDocuments.SelectionChanged -= grdDocuments_SelectionChanged;
                grdDocuments.Rows[i].Selected = true;
                grdDocuments.SelectionChanged += grdDocuments_SelectionChanged;
            }
            pictureBox1.Visible = true;
            pnl.Visible = false;
            cmbCenters.Text = "";
            cmbCenters.SelectedItem = null;


            if (pbComment.Image != null)
            {
                pbComment.Image.Dispose();
                pbComment.Image = null;
            }
            pbComment.Invalidate();
            pbComment.Enabled = true;

            if (pictureBox1.Image != null)
            {
                pictureBox1.Image.Dispose();
                pictureBox1.Image = null;
            }
            pictureBox1.Invalidate();
            pictureBox1.Enabled = false;// هرگاه جدید کلیک شد باید امکان ویرایش وود داشته باشد و در غر این صورت عکس غیر قابل ویرایش باشد
            Byte[] imageData1 = new Byte[0];

            Byte[] imageData = new Byte[0];
            short documentType = -2;
            int CenterIDSent = -1;
            if (grdDocuments.SelectedRows.Count != 1) return;
            CenterIDSent = grdDocuments.SelectedRows[0].Cells["CenterIDSent"].Value != DBNull.Value ? Convert.ToInt32(grdDocuments.SelectedRows[0].Cells["CenterIDSent"].Value) : 0;
            documentType = Convert.ToInt16(grdDocuments.SelectedRows[0].Cells["DocumentType"].Value);
            //tabControl1.TabPages[documentType - 1].Controls.Add(pictureBox1);
            SetStar();
            if (ISSecretory)
            {
                tabControl2.TabPages[0].Controls.Clear();
                FillCombo(Convert.ToInt16(grdDocuments.SelectedRows[0].Cells["DocumentType"].Value));
                if (documentType == 1)
                {


                    tabControl2.SelectedIndex = 0;
                    tabControl1.SelectedIndex = documentType - 1;
                    if (CenterIDSent == 0)
                    {
                        tabControl1.Visible = false;
                        tabControl2.Visible = true;
                        cmbCenters.Enabled = false;
                        btnSave.Enabled = false;
                        gbInsertCenter.Visible = true;
                        SendToDrugStore();
                        CheckAnswerOFDrugStors();
                    }
                    else
                    {
                        tabControl1.Visible = true;
                        tabControl2.Visible = false;
                        imageData = (Byte[])(grdDocuments.SelectedRows[0].Cells["image"].Value);
                        if (imageData != null)
                        {
                            MemoryStream stream = new MemoryStream(imageData);
                            pictureBox1.Image = Image.FromStream(stream);
                        }
                        DataRow dr = centersDT.AsEnumerable().SingleOrDefault(r => r.Field<int>("IDCenters") == CenterIDSent);
                        if (dr != null)
                        {
                            ComboItem i = new ComboItem(dr["NameCenters"].ToString(), CenterIDSent);
                            gbInsertCenter.Visible = true; gbInsertCenter.Enabled = false;
                            cmbCenters.SelectedText = dr["NameCenters"].ToString();
                        }
                        btnSave.Enabled = true;
                        gbInsertCenter.Enabled = false;
                        gbInsertCenter.Visible = true;

                    }
                }
                else if (documentType == 2 || documentType == 3)
                {



                    if (CheckIFThereIsResultForDocument(Convert.ToInt32(grdDocuments.SelectedRows[0].Cells["ID"].Value), documentType))
                    {
                        tabControl1.SelectedIndex = documentType - 1;
                        pictureBox1.Visible = false;  //tabControl1.TabPages[documentType - 1].Controls.Remove(pictureBox1);
                        tabControl1.TabPages[documentType - 1].Controls.Add(pnl);

                        if (documentType == 2)
                        {
                            foreach (Control c in pnl.Controls)// (int i = 0; i < txtTeamNames.Length; i++)
                            {
                                if ("TextBox" == c.GetType().Name)
                                    c.Text = "";
                            }
                            SqlParameter[] param;
                            param = new SqlParameter[1];
                            int index = 0;
                            param[index++] = new SqlParameter("@IDDocument", Convert.ToInt32(grdDocuments.SelectedRows[0].Cells["ID"].Value));
                            try
                            {
                                DataTable itemsDt1 = new DataTable();
                                DataSet ItemDs = da.ExecuteSP("GetLabItemsByDocumentID", param);
                                if (ItemDs != null && ItemDs.Tables.Count > 0)
                                {
                                    itemsDt1 = ItemDs.Tables[0];
                                    if (itemsDt1.Rows.Count > 0)
                                        FillLabItem1(itemsDt1);
                                    DataTable commentDT = new DataTable();
                                    if (ItemDs.Tables.Count > 1)
                                    {
                                        commentDT = ItemDs.Tables[1];

                                        if (commentDT.Rows.Count > 0)
                                        {
                                            imageData1 = (Byte[])(commentDT.Rows[0]["image"]);
                                            if (imageData1 != null)
                                            {
                                                MemoryStream stream = new MemoryStream(imageData1);
                                                pbComment.Image = Image.FromStream(stream);
                                            }
                                        }
                                    }
                                }
                                pbComment.Enabled = false;
                            }
                            catch
                            {
                                var msg = " نمایش نتایج آزمایش ناموفق است."; MessageForm.Show(msg, "خطا", MessageFormIcons.Warning, MessageFormButtons.Ok, Properties.Settings.Default.Color);
                            }
                            pnl.Visible = true;
                            btnBackGround.Visible = true;
                            pbComment.Visible = true;
                            //  return;
                        }
                        else if (documentType == 3)
                        {
                            
                            if (grdDocuments.CurrentRow == null) return;
                            tabControl1.TabPages[2].Controls.Clear(); i = 1;
                            path = Path.GetDirectoryName(Application.ExecutablePath) + @"\Docs" + @"\" + (grdDocuments.CurrentRow.Cells["ID"].Value).ToString();

                            // If directory does not exist, don't even try 
                            if (Directory.Exists(path))
                            {
                                foreach (var path1 in Directory.GetFiles(path))
                                {
                                    FileInfo fi = new FileInfo(path1);
                                    string text = fi.Name;
                                    if (text != "Thumbs.db")
                                    {
                                        Font font = new Font("B Nazanin", 10.0f, FontStyle.Bold);
                                        LinkLabel l = new LinkLabel();
                                        Button btn = new Button();
                                        btn.Image = Properties.Resources.delete_icon;
                                        btn.ForeColor = Color.White;
                                        btn.Font = font;
                                        btn.Text = "";
                                        btn.Name = text;
                                        btn.BackColor = Color.FromName("Control"); btn.ForeColor = Color.White;
                                        btn.Click += btn_Click;
                                        btn.FlatStyle = FlatStyle.Flat;
                                        btn.Visible = false;
                                        btn.Size = new System.Drawing.Size(23, 23);
                                        btn.UseVisualStyleBackColor = true;
                                        btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
                                        l.Visible = true;
                                        l.Text = text;
                                        l.Name = text; l.ForeColor = Color.Black;
                                        l.Tag = path + @"\" + text; btn.Tag = path + @"\" + text;
                                        l.Location = new Point(tabControl1.TabPages[0].Location.X, tabControl1.TabPages[0].Location.Y + i);
                                        btn.Location = new Point(l.Location.X + 130, tabControl1.TabPages[0].Location.Y + i);
                                        i = i + 20; tabControl1.TabPages[0].AutoScroll = true;
                                        // listBox1.Items.Add(text,"");
                                        tabControl1.TabPages[2].Controls.Add(l);
                                        tabControl1.TabPages[2].Controls.Add(btn);

                                        l.LinkClicked += linkLabel1_LinkClicked;
                                    }
                                }


                                return;
                            }

                        }
                    }

                        else
                        {

                            tabControl1.Visible = true;
                            tabControl2.Visible = false;
                            tabControl2.SelectedIndex = 0;
                            gbInsertCenter.Visible = true;
                            tabControl1.SelectedIndex = documentType - 1;
                            //if (documentType == 5)
                            //    tcDescriptionDetails.SelectedIndex = 0;
                            //else if (documentType == 6)
                            //    tcDescriptionDetails.SelectedIndex = 1;
                            //else if (documentType == 7)
                            //    tcDescriptionDetails.SelectedIndex = 2;
                            //else if (documentType == 8)
                            //    tcDescriptionDetails.SelectedIndex = 3;
                            imageData = (Byte[])(grdDocuments.SelectedRows[0].Cells["image"].Value);
                            if (imageData != null)
                            {
                                MemoryStream stream = new MemoryStream(imageData);
                                pictureBox1.Image = Image.FromStream(stream);
                            }

                        }
                        if (CenterIDSent == 0)
                        {
                            cmbCenters.Enabled = true;
                            btnSave.Enabled = false;
                            gbInsertCenter.Enabled = true;
                        }
                        else
                        {
                            DataRow dr = centersDT.AsEnumerable().SingleOrDefault(r => r.Field<int>("IDCenters") == CenterIDSent);
                            if (dr != null)
                            {
                                ComboItem i = new ComboItem(dr["NameCenters"].ToString(), CenterIDSent);
                                gbInsertCenter.Visible = true; gbInsertCenter.Enabled = false;
                                cmbCenters.SelectedText = dr["NameCenters"].ToString();
                            }
                            btnSave.Enabled = true;
                            gbInsertCenter.Enabled = false;


                        }






                    }
                    else if (documentType >= 4)
                    {
                        tabControl1.Visible = true;
                        tabControl2.Visible = false;
                        gbInsertCenter.Enabled = false;
                        tabControl1.SelectedIndex = 3;
                        if (documentType == 5)
                            tcDescriptionDetails.SelectedIndex = 0;
                        else if (documentType == 6)
                            tcDescriptionDetails.SelectedIndex = 1;
                        else if (documentType == 7)
                            tcDescriptionDetails.SelectedIndex = 2;
                        else if (documentType == 8)
                            tcDescriptionDetails.SelectedIndex = 3;

                        imageData = (Byte[])(grdDocuments.SelectedRows[0].Cells["image"].Value);
                        if (imageData != null)
                        {
                            MemoryStream stream = new MemoryStream(imageData);
                            pictureBox1.Image = Image.FromStream(stream);
                        }
                    }

                
            }
                else if (ISDoctor)
                {
                    DataTable itemsDt = new DataTable();
                    tabControl1.SelectedIndex = documentType - 1;
                    if (MenuTop1ToolStripMenuItem.Checked)
                    {
                        tabControl1.Visible = false;
                        tabControl2.Visible = true;
                        tabControl2.SelectedIndex = 0;
                        SqlParameter[] param;
                        param = new SqlParameter[1];
                        int index = 0;
                        param[index++] = new SqlParameter("@IDDocument", Convert.ToInt32(grdDocuments.SelectedRows[0].Cells["ID"].Value));
                        DataSet ds = new DataSet();
                        ds = da.ExecuteSP("GetLabItemsByDocumentID", param);
                        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                        {
                            itemsDt = ds.Tables[0];
                            FillLabItem(itemsDt);
                        }
                    }
                    else
                    {
                        if ((documentType == 2 || documentType == 3) && CheckIFThereIsResultForDocument(Convert.ToInt32(grdDocuments.SelectedRows[0].Cells["ID"].Value), documentType))
                        {
                            tabControl1.SelectedIndex = documentType - 1;
                            pictureBox1.Visible = false;  //tabControl1.TabPages[documentType - 1].Controls.Remove(pictureBox1);
                            tabControl1.TabPages[documentType - 1].Controls.Add(pnl);


                            if (documentType == 2)
                            {
                                foreach (Control c in pnl.Controls)// (int i = 0; i < txtTeamNames.Length; i++)
                                {
                                    if ("TextBox" == c.GetType().Name)
                                        c.Text = "";
                                }
                                SqlParameter[] param;
                                param = new SqlParameter[1];
                                int index = 0;
                                param[index++] = new SqlParameter("@IDDocument", Convert.ToInt32(grdDocuments.SelectedRows[0].Cells["ID"].Value));
                                try
                                {
                                    DataTable itemsDt1 = new DataTable();
                                    DataSet ItemDs = da.ExecuteSP("GetLabItemsByDocumentID", param);
                                    if (ItemDs != null && ItemDs.Tables.Count > 0)
                                    {
                                        itemsDt1 = ItemDs.Tables[0];
                                        if (itemsDt1.Rows.Count > 0)
                                            FillLabItem1(itemsDt1);
                                        DataTable commentDT = new DataTable();
                                        if (ItemDs.Tables.Count > 1)
                                        {
                                            commentDT = ItemDs.Tables[1];

                                            if (commentDT.Rows.Count > 0)
                                            {
                                                imageData1 = (Byte[])(commentDT.Rows[0]["image"]);
                                                if (imageData1 != null)
                                                {
                                                    MemoryStream stream = new MemoryStream(imageData1);
                                                    pbComment.Image = Image.FromStream(stream);
                                                }
                                            }
                                        }
                                    }
                                }
                                catch
                                {
                                    var msg = " نمایش نتایج آزمایش ناموفق است."; MessageForm.Show(msg, "خطا", MessageFormIcons.Warning, MessageFormButtons.Ok, Properties.Settings.Default.Color);
                                }
                                pnl.Visible = true;

                                btnBackGround.Visible = true;
                                pbComment.Visible = true;
                                return;
                            }
                            else if (documentType == 3)
                            {
                                pnl.Visible = false;
                                pictureBox1.Visible = false;
                                if (grdDocuments.CurrentRow == null) return;
                                tabControl1.TabPages[2].Controls.Clear(); i = 1;
                                path = Path.GetDirectoryName(Application.ExecutablePath) + @"\Docs" + @"\" + (grdDocuments.CurrentRow.Cells["ID"].Value).ToString();

                                // If directory does not exist, don't even try 
                                if (Directory.Exists(path))
                                {
                                    foreach (var path1 in Directory.GetFiles(path))
                                    {
                                        FileInfo fi = new FileInfo(path1);
                                        string text = fi.Name;
                                        if (text != "Thumbs.db")
                                        {
                                            Font font = new Font("B Nazanin", 10.0f, FontStyle.Bold);
                                            LinkLabel l = new LinkLabel();
                                            Button btn = new Button();
                                            btn.Image = Properties.Resources.delete_icon;
                                            btn.ForeColor = Color.White;
                                            btn.Font = font;
                                            btn.Text = "";
                                            btn.Name = text;
                                            btn.BackColor = Color.FromName("Control"); btn.ForeColor = Color.White;
                                            btn.Click += btn_Click;
                                            btn.FlatStyle = FlatStyle.Flat;
                                            btn.Visible = false;
                                            btn.Size = new System.Drawing.Size(23, 23);
                                            btn.UseVisualStyleBackColor = true;
                                            btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
                                            l.Visible = true;
                                            l.Text = text;
                                            l.Name = text; l.ForeColor = Color.Black;
                                            l.Tag = path + @"\" + text; btn.Tag = path + @"\" + text;
                                            l.Location = new Point(tabControl1.TabPages[0].Location.X, tabControl1.TabPages[0].Location.Y + i);
                                            btn.Location = new Point(l.Location.X + 130, tabControl1.TabPages[0].Location.Y + i);
                                            i = i + 20; tabControl1.TabPages[0].AutoScroll = true;
                                            // listBox1.Items.Add(text,"");
                                            tabControl1.TabPages[2].Controls.Add(l);
                                            tabControl1.TabPages[2].Controls.Add(btn);

                                            l.LinkClicked += linkLabel1_LinkClicked;
                                        }
                                    }

                                    return;
                                }

                            }}
                            else if (documentType >= 4)
                            {
                                tabControl1.Visible = true;
                                tabControl2.Visible = false;
                                tabControl2.SelectedIndex = 0;
                                tabControl1.SelectedIndex = 3;
                                if (documentType == 5)
                                    tcDescriptionDetails.SelectedIndex = 0;
                                else if (documentType == 6)
                                    tcDescriptionDetails.SelectedIndex = 1;
                                else if (documentType == 7)
                                    tcDescriptionDetails.SelectedIndex = 2;
                                else if (documentType == 8)
                                    tcDescriptionDetails.SelectedIndex = 3;
                                imageData = (Byte[])(grdDocuments.SelectedRows[0].Cells["image"].Value);
                                if (imageData != null)
                                {
                                    MemoryStream stream = new MemoryStream(imageData);
                                    pictureBox1.Image = Image.FromStream(stream);
                                }
                            }

                            else
                            {
                                tabControl1.Visible = true;
                                tabControl2.Visible = false;
                                tabControl2.SelectedIndex = 0;
                                tabControl1.SelectedIndex = documentType - 1;
                                imageData = (Byte[])(grdDocuments.SelectedRows[0].Cells["image"].Value);
                                if (imageData != null)
                                {
                                    MemoryStream stream = new MemoryStream(imageData);
                                    pictureBox1.Image = Image.FromStream(stream);
                                }

                            }
                        
                    }



                
            }
        }

              private void btn_Click(object sender, EventArgs e)
        {
          MessageFormResult   result = MessageForm.Show("آیا مطمئن به حذف هستید؟", "خطای فایل", MessageFormIcons.Warning, MessageFormButtons.YesNo, color);
          if (result == MessageFormResult.Yes)
            {
               Button btn = (Button)sender;
            if (File.Exists(btn.Tag.ToString()))
            {
                System.IO.File.Delete(btn.Tag.ToString());
                LinkLabel ll = tabControl1.TabPages[0].Controls.Find(btn.Name.ToString(), true).FirstOrDefault() as LinkLabel;
                ll.Dispose();
                btn.Dispose();

                if (tabControl1.TabPages[0].Controls.Count == 0)
                {
                    SqlParameter[] param;
                    param = new SqlParameter[2];
                  
                    int index = 0;
                    //if(btnGold.Image=Properties
                    if (grdDocuments.SelectedRows.Count < 1) return;
                    param[index++] = new SqlParameter("@IDDocument", Convert.ToInt32(grdDocuments.CurrentRow.Cells["ID"].Value));
                    
                    this.da.ExecuteScalarSP("DeleteRadiologyResult", param);
                }


            }
            }
          else if (result == MessageFormResult.No)
            {
                return;
            }
            else
            {
                return;
            } 
           

            }
        
  private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LinkLabel ll = (LinkLabel)sender;

            if (!File.Exists(ll.Tag.ToString()))
            {
                return;
            }

            // combine the arguments together
            // it doesn't matter if there is a space after ','
         //   string argument = @"/select, " + btnRequest.Tag.ToString();

            System.Diagnostics.Process.Start( ll.Tag.ToString());
        }

        private void SetStar()
        {
            long IDDocument;
            IDDocument = Convert.ToInt64(grdDocuments.SelectedRows[0].Cells["ID"].Value);
            SqlParameter[] param;
            param = new SqlParameter[1];
            int index = 0;
            param[index++] = new SqlParameter("@ID", IDDocument);
            short Gold = 0;
            DataSet dsStar = new DataSet(); dsStar = da.ExecuteSP("GetStar", param);
            if (dsStar == null || dsStar.Tables.Count == 0 || dsStar.Tables[0].Rows.Count == 0) return;
            else
            {
               if( dsStar.Tables[0].Rows[0][0]!=DBNull.Value)
                Gold = Convert.ToInt16(dsStar.Tables[0].Rows[0][0]);
            }
            {
                if (Gold==1)
                
                {
                    btnGold.Image = Properties.Resources._1;
                    btnGold.Tag = 1;
                }
                else 
                {
                    btnGold.Image = Properties.Resources._0;
                    btnGold.Tag = 0;

                }
            }
        }
        private bool CheckIFThereIsResultForDocument(int IDDocument,short documentType)
        {
            if (documentType == 2)
            {
                SqlParameter[] param;
                param = new SqlParameter[2];
                int index = 0;
                param[index++] = new SqlParameter("@DocumentType", documentType);
                param[index++] = new SqlParameter("@IDDocument", IDDocument);

                dsResult = da.ExecuteSP("GetLabItemsByDocumentID", param);
                if (dsResult != null && dsResult.Tables.Count > 0 && dsResult.Tables[0].Rows.Count > 0)
                {
                    return true;

                }
                return false;
            }
            else   if (documentType == 3)
            {
                SqlParameter[] param;
                param = new SqlParameter[2];
                int index = 0;
                param[index++] = new SqlParameter("@DocumentType", documentType);
                param[index++] = new SqlParameter("@IDDocument", IDDocument);
                bool result;
                result = Convert.ToBoolean (da.ExecuteScalarSP ("CheckRadiologyHasResult", param));
                if (result)
                {
                    return true;

                }
                return false;
            }
            else return false;

        }

        private void FillLabItem1(DataTable labItemDT)
        {
            if (MenuTop3ToolStripMenuItem.Checked)
                foreach (Control c in pnl.Controls)// (int i = 0; i < txtTeamNames.Length; i++)
                {
                    if ("TextBox" == c.GetType().Name)

                        c.Enabled = false;


                }

            foreach (DataRow row in labItemDT.Rows)// (int i = 0; i < txtTeamNames.Length; i++)
            {
                TextBox tbx = this.pnl.Controls.Find(row["NameLabItem"].ToString(), true).FirstOrDefault() as TextBox;
                if (tbx != null)
                {

                    if (MenuTop3ToolStripMenuItem.Checked && (Convert.ToBoolean(row["StatusItem"])) == false && tbx.Text == "")
                    { tbx.ForeColor = Color.Red; }
                    else tbx.ForeColor = Color.Black;
                    tbx.Text = row["ValueItemLab"].ToString();
                    //tbx.Enabled = true;
                    tbx.Tag = row;
                }




            }


        }
        private void FillLabItem(DataTable labItemDT)
        {
            foreach (Control c in tabControl2.TabPages[0].Controls)
            {
                if (c is CheckBox)
                    ((CheckBox)c).Checked = false;
                if (c is TextBox)
                    ((TextBox)c).Text = "";

            }
            foreach (DataRow row in labItemDT.Rows)
            {
                TextBox tbx = this.tabControl2.TabPages[0].Controls.Find(row["NameLabItem"].ToString(), true).FirstOrDefault() as TextBox;
                CheckBox chtrue = this.tabControl2.TabPages[0].Controls.Find("t" + row["NameLabItem"].ToString(), true).FirstOrDefault() as CheckBox;
                CheckBox chfalse = this.tabControl2.TabPages[0].Controls.Find("f" + row["NameLabItem"].ToString(), true).FirstOrDefault() as CheckBox;
                if (chfalse == null) return;
                chtrue.Tag = Convert.ToInt32(row["ID"]);
                chfalse.Tag = Convert.ToInt32(row["ID"]);
                tbx.Text = row["ValueItemLab"].ToString();
                tbx.Tag = row;
                if (row["StatusItem"]== DBNull.Value)
                {
                    chtrue.Checked = false;
                    chfalse.Checked = false;
                }
                else   if (row["StatusItem"]!= DBNull.Value && Convert.ToBoolean(row["StatusItem"]))
                {
                    chtrue.Checked = true;
                    chfalse.Checked = false;
                }
                else
                {
                    chfalse.Checked = true;
                    chtrue.Checked = false;
                }
            }


        }
        private void button1_Click_1(object sender, EventArgs e)// NEW
        {
            if (pictureBox1.Image != null)
            {

                pictureBox1.Image.Dispose();
                pictureBox1.Image = null;
            }
            pictureBox1.Invalidate();
            pictureBox1.Enabled = true;

            if(  tabControl1.SelectedIndex==3)
            {

                pnl.Visible = false;
                pictureBox1.Visible = true;
            }
            if (pnl.Visible == true )
            {
                pnl.Visible = false;
                pictureBox1.Visible = true;
            }
        }
        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e != null)
            {centersDT= new DataTable();
                DepartmentID = Convert.ToInt16(e.ClickedItem.Tag);// get the ID of Clicked Tab
            }
            SqlParameter[] param;
            param = new SqlParameter[1];
            int index = 0;
            string eventlog = "Get Department info by DepartmentID=" + DepartmentID;
            try
            {
                if (DepartmentSelected != null)
                    if (1==1)//DepartmentSelected != DepartmentID)
                    {
                      
                        GridDataSourceDS = null;
                        GridDataSourceDS = da.ExecuteCommand("GetAllDoctorIntermittences", DepartmentID);
                        MenuTop3ToolStripMenuItem.Text = "";
                        MenuTop3ToolStripMenuItem.Text = GridDataSourceDS.Tables[0].Rows.Count.ToString() + " " + "کل بیماران";
                        if (MenuTop3ToolStripMenuItem.Checked && 
                        (GridDataSourceDS != null && GridDataSourceDS.Tables.Count > 0 && GridDataSourceDS.Tables[0].Rows.Count > 0)) FillGrid(GridDataSourceDS.Tables[0]);
                        GridDataSourceDS = null;
                        GridDataSourceDS = da.ExecuteCommand("GetLabsForVerifyByDoctor", DepartmentID);
                        MenuTop1ToolStripMenuItem.Text = "";
                        MenuTop1ToolStripMenuItem.Text = GridDataSourceDS.Tables[0].Rows.Count.ToString() + " " + "کارتابل";
                        if (MenuTop1ToolStripMenuItem.Checked && 
                        (GridDataSourceDS != null && GridDataSourceDS.Tables.Count > 0 && GridDataSourceDS.Tables[0].Rows.Count > 0)) FillGrid(GridDataSourceDS.Tables[0]);
                        GridDataSourceDS = null;
                        GridDataSourceDS = da.ExecuteCommand("GetTodayIntermittences", DepartmentID);
                        if (MenuTop4ToolStripMenuItem.Checked && 
                        (GridDataSourceDS != null && GridDataSourceDS.Tables.Count > 0 && GridDataSourceDS.Tables[0].Rows.Count > 0)) FillGrid(GridDataSourceDS.Tables[0]);
                        MenuTop4ToolStripMenuItem.Text = "";
                        MenuTop4ToolStripMenuItem.Text = GridDataSourceDS.Tables[0].Rows.Count.ToString() + " " + "نویت های امروز";
                        DepartmentSelected = DepartmentID;//save selected Depertment ID as A Public Variable
                        if ((GridDataSourceDS == null || GridDataSourceDS.Tables.Count== 0 || GridDataSourceDS.Tables[0].Rows.Count == 0))
                        {
                            dt.Rows.Clear();
                            grdIntermittenc.DataSource=dt;

                            DocumentDT.Rows.Clear();
                            grdDocuments.DataSource = DocumentDT;
                        }
                    }
                if (e != null)
                {
                    SelectMenuRight(e.ClickedItem);
                    SelectMenuTop(MenuTop4ToolStripMenuItem);
                }               
            }
            catch
            {
                NewMethod_eventlog(eventlog, 15008);
                throw;
            }
        }
        private void menuStrip1_MouseEnter(object sender, EventArgs e)
        {
            Cursor = System.Windows.Forms.Cursors.Hand;//دیزاین
        }
        private void menuStrip1_MouseLeave(object sender, EventArgs e)
        {
            Cursor = System.Windows.Forms.Cursors.Default;//دیزاین
        }
        private void SendToDrugStore()
        {

            //if (grdDocuments.CurrentRow != null && grdDocuments.CurrentRow.Cells["CenterIDSent"].Value.ToString() != "")
            //{

            //    tabControl2.Visible = false;
            //    tabControl1.Visible = true;
            //    return;
            //}
           
            int y = 0;
            int x= 0;
            tabControl2.TabPages[0].AutoScroll = true;
            int i = 0; 
            SqlParameter[] param;
            param = new SqlParameter[1];
            int index = 0;
            param[index++] = new SqlParameter("@CenterType", 1);
            DataSet ds= new DataSet();
            ds= da.ExecuteSP("GetCentersBriefInfo", param);
                 
             if(ds!= null && ds.Tables.Count>0 && ds.Tables[0].Rows.Count>0)
             {
                centersDT = ds.Tables[0];
                CheckBoxTeamNames= new CheckBox[centersDT.Rows.Count]; CheckBoxTeamNames1= new CheckBox[centersDT.Rows.Count];
                btnTeamNames = new Button[centersDT.Rows.Count];
                Label[] LabelTeamNames = new Label[centersDT.Rows.Count];
                Font font = new Font("B Nazanin", 10.0f, FontStyle.Bold);

                foreach (DataRow row in centersDT.Rows)// (int i = 0; i < txtTeamNames.Length; i++)
                {
                    var lbl = new Label();
                    LabelTeamNames[i] = lbl;
                    lbl.Name = "lbl" + row["NameCenters"].ToString();
                    lbl.Text = " :" + "داروخانه " + row["NameCenters"].ToString(); 
                    lbl.AutoSize = true;
                    lbl.ForeColor = Color.Black;
                    //if (30 + tabControl1.TabPages[1].Location.Y + (i) * 30 >= tabControl1.TabPages[1].Location.Y + tabControl1.TabPages[1].Height - 30)
                    //{ x = 210; y = -(tabControl1.TabPages[1].Height - 30); }
                    lbl.Location = new Point(tabControl1.TabPages[0].Location.X + 7, tabControl1.TabPages[0].Location.Y + y + 5 + (i * 53));
                    lbl.Visible = true;
                 
                   
                    var btnRequest = new Button();
                    btnRequest.FlatStyle = FlatStyle.Flat;
                    btnRequest.ForeColor = Color.White;
                    btnRequest.Font = font;
                    btnRequest.Text = "ارسال";
                    btnRequest.Name = "Request" + row["IDCenters"].ToString();
                    btnRequest.BackColor = color;
                    btnRequest.Width = 65; btnRequest.Height = 50;
                    btnRequest.Tag = row["IDCenters"].ToString();
                    btnTeamNames[i] = btnRequest;
                    btnRequest.Location = new Point(tabControl1.TabPages[0].Location.X + 110, tabControl1.TabPages[0].Location.Y + y + (i * 53));
                    btnRequest.Visible = true;
                    btnRequest.Click += btnRequest_Click;
                    //if (30 + tabControl1.TabPages[1].Location.Y + (i) * 30 >= tabControl1.TabPages[1].Location.Y + tabControl1.TabPages[1].Height - 30)
                    //{ x = 210; y = -(tabControl1.TabPages[1].Height - 30); }
                  

                    var btnSend = new Button();
                    btnSend.FlatStyle = FlatStyle.Flat;
                    btnSend.ForeColor = Color.White;
                    btnSend.Font = font;
                    btnSend.Text = "";
                    btnSend.Name = row["IDCenters"].ToString();
                    btnSend.BackColor = Color.FromName("Control"); btnSend.ForeColor = Color.White;
                    btnSend.Width = 65; btnSend.Height = 50;
                    btnSend.Tag = row["IDCenters"].ToString(); btnSend.Enabled = false;
                    btnTeamNames[i] = btnSend;
                    btnSend.Location = new Point(tabControl1.TabPages[0].Location.X + 192, tabControl1.TabPages[0].Location.Y + y + (i * 53));
                    btnSend.Visible = true;
                    btnSend.UseVisualStyleBackColor = true;
                    btnSend.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
                    btnSend.Click += btnSend_Click;
                    btnSend.Image = Properties.Resources.right11;
                    //if (30 + tabControl1.TabPages[1].Location.Y + (i) * 30 >= tabControl1.TabPages[1].Location.Y + tabControl1.TabPages[1].Height - 30)
                    //{ x = 210; y = -(tabControl1.TabPages[1].Height - 30); }
                   


                    tabControl2.TabPages[0].Controls.Add(lbl);
                    tabControl2.TabPages[0].Controls.Add(btnSend);
                    tabControl2.TabPages[0].Controls.Add(btnRequest);

                    i++;
                }

           }
        
        }
        private void MenuTop1ToolStripMenuItem_Click(object sender, EventArgs e)//کارتابل
        {

            foreach (Control c in tabControl2.TabPages[0].Controls)
            {
                if (c is CheckBox)
                    ((CheckBox)c).Checked = false;
                if (c is TextBox)
                    ((TextBox)c).Text = "";

            }
            dt.Rows.Clear();
            grdIntermittenc.DataSource = dt;
            btnNew.Enabled = false;
            tabControl2.Visible = true;
            tabControl1.Visible = false;
            SelectMenuTop(MenuTop1ToolStripMenuItem); 
            MenuTop1ToolStripMenuItem.Text = "";
            //tabControl2.TabPages[0].Controls.Clear();
            grdDocuments.SelectionChanged -= grdDocuments_SelectionChanged;
            grdDocuments.DataSource = null;
            grdDocuments.SelectionChanged += grdDocuments_SelectionChanged;

            GridDataSourceDS = da.ExecuteCommand("GetLabsForVerifyByDoctor", DepartmentID);
            if (GridDataSourceDS != null && GridDataSourceDS.Tables.Count > 0 && GridDataSourceDS.Tables[0].Rows.Count > 0)
            {
                FillGrid(GridDataSourceDS.Tables[0]);
                MenuTop1ToolStripMenuItem.Text = grdIntermittenc.Rows.Count.ToString() + " " + "کارتابل";
                grdIntermittenc.Rows.OfType<DataGridViewRow>().First().Selected = true;
            }
            else
            { 
                MenuTop1ToolStripMenuItem.Text = "0" + " " + "کارتابل"; 
            
            }
            

        }
        private void btnSend_Click(object sender, EventArgs e)
        {
           


            Button btnSend = (Button)sender;
            if (grdDocuments.SelectedRows.Count!=1)
                return;


            int IDCenter = Convert.ToInt32(btnSend.Tag);


            SqlParameter[] param;
            param = new SqlParameter[3];
            int index = 0;
         

            param[index++] = new SqlParameter("@DocumentType", 1);
           
            param[index++] = new SqlParameter("@IDCenter", IDCenter);
            // param[index++] = new SqlParameter("@DateReply", DateTime.Now);
            param[index++] = new SqlParameter("@IDDocument", Convert.ToInt32(grdDocuments.SelectedRows[0].Cells["ID"].Value));

            if (Convert.ToInt32(da.ExecuteScalarSP("SetCenterForDocument", param)) == 1)
            {
                timer1.Stop();
                foreach (DataRow r in centersDT.Rows)
                {
                    
                    Button btnRequest = this.Controls.Find("Request" + r["IDCenters"].ToString(), true).FirstOrDefault() as Button;
                    if (btnSend.Name == r["IDCenters"].ToString() )
                    {
                        cmbCenters.Text = r["NameCenters"].ToString();
                    }
                    if (btnSend.Name != r["IDCenters"].ToString() && btnRequest != null)
                    {
                        btnRequest.Enabled = false;
                        btnRequest.ForeColor = Color.White;
                        btnRequest.BackColor = Color.FromName("Control");
                        btnRequest.Text = "ارسال"; btnRequest.Image = null;

                    } 
                 
                    
                 }
            
                buttonToolTip.ToolTipTitle = "ثبت";
                buttonToolTip.UseFading = true;
                buttonToolTip.UseAnimation = true;
                buttonToolTip.IsBalloon = true;
                buttonToolTip.ShowAlways = false;
                //buttonToolTip.AutoPopDelay = 100;
                buttonToolTip.InitialDelay = 0;
                //buttonToolTip.AutoPopDelay = 5000;
                IWin32Window win = this;
                buttonToolTip.Show( " مرکز " +""+ " برای این نسخه ثبت شد . ", win, MousePosition,5000);
                if (grdDocuments.SelectedRows.Count!=1)
                {
                    btnSave.Enabled = true;

                    grdDocuments.SelectedRows[0].Cells["CenterIDSent"].Value = IDCenter;
                    gbInsertCenter.Visible = true;
                    cmbCenters.Enabled = false;
                   // cmbCenters.Text = "";
                }
                //int index1 = -2;
                //if (grdDocuments.SelectedRows.Count>0)
                //{ index1 = grdDocuments.SelectedRows[0].Index; }
                //else  if (grdDocuments.CurrentRow != null)
                //{ index1 = grdDocuments.CurrentRow.Index; }
                //grdDocuments.SelectionChanged -= grdDocuments_SelectionChanged;
                ////FillDocumentsGrid();
                //grdDocuments.SelectionChanged += grdDocuments_SelectionChanged;
                //grdDocuments.Rows[index1].Selected = true;
            }

            else
            {
               
            }
        }
        private void btnRequest_Click(object sender, EventArgs e)
        {

            
            Button btnRequest = (Button)sender;
            if (grdDocuments.SelectedRows.Count!= 1)
                return;

            int IdDocument = Convert.ToInt32(grdDocuments.SelectedRows[0].Cells["ID"].Value);
            int IDCenter = Convert.ToInt32(btnRequest.Tag);
            SqlParameter[] param;
            param = new SqlParameter[4];
            int index = 0;
            
            param[index++] = new SqlParameter("@DocumentType", 1);
            param[index++] = new SqlParameter("@IDCenter", IDCenter);
           // param[index++] = new SqlParameter("@DateReply", DateTime.Now);
            param[index++] = new SqlParameter("@IDDocument", Convert.ToInt32(grdDocuments.SelectedRows[0].Cells["ID"].Value));

            if (Convert.ToInt32(da.ExecuteScalarSP("SetCenterForDocument", param)) == 1)
            {
                btnRequest.BackColor = Color.Transparent; btnRequest.UseVisualStyleBackColor = true;
                btnRequest.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
                btnRequest.Image = Properties.Resources.hourglass;//دیزاین
                btnRequest.Text = "";
              

            }
            timer1.Start();
                return;
          
        }
        private void checkBoxt_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox checkbox = (CheckBox)sender;
            if (checkbox.Checked == true)
            {


                   CheckBox chkf = this.Controls.Find("f" + checkbox.Name.Substring(1).ToString(), true).FirstOrDefault() as CheckBox;
                    if (chkf.Checked == true)
                        chkf.Checked = false;
                    return;
            }
        }
        private void checkBoxf_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox fch = new CheckBox();
            CheckBox checkbox = (CheckBox)sender;
            if (checkbox.Checked == true)
            {
                CheckBox chkTrue = this.Controls.Find("t" + checkbox.Name.Substring(1).ToString(), true).FirstOrDefault() as CheckBox;
                if (chkTrue.Checked == true)
                        chkTrue.Checked = false;
                return;
            }
        }
        private void MenuTop4ToolStripMenuItem_Click(object sender, EventArgs e)//نوبت امروز
        {
            dt.Rows.Clear();
            grdIntermittenc.DataSource = dt;
            if (ISSecretory)
            {
                //tabControl2.TabPages[0].Controls.Clear();
                cmbCenters.Text = "";
                cmbCenters.DataSource = null;
                btnSave.Enabled = false;
            }
            GridDataSourceDS = null;
            btnNew.Enabled = true;
            tabControl2.Visible= false;// = false;
            tabControl1.Show();// = true;
            SelectMenuTop(MenuTop4ToolStripMenuItem);
            MenuTop4ToolStripMenuItem.Text = "";
            if (pictureBox1.Image != null)
            {
                pictureBox1.Image.Dispose();
                pictureBox1.Image = null;
            }
            pictureBox1.Invalidate();
            pictureBox1.Enabled = true;

            grdDocuments.SelectionChanged -= grdDocuments_SelectionChanged;
            grdDocuments.DataSource = null;
            grdDocuments.SelectionChanged += grdDocuments_SelectionChanged;
            GridDataSourceDS = da.ExecuteCommand("GetTodayIntermittences", DepartmentID);

            if (GridDataSourceDS == null || GridDataSourceDS.Tables.Count == 0 || GridDataSourceDS.Tables[0].Rows.Count == 0)
            {
                
                MenuTop4ToolStripMenuItem.Text = "0" + " " + "نویت های امروز";
                return;
            }
            else
            {
                MenuTop4ToolStripMenuItem.Text = GridDataSourceDS.Tables[0].Rows.Count.ToString() + " " + "نویت های امروز";
            
            FillGrid(GridDataSourceDS.Tables[0]);
            grdIntermittenc.Rows.OfType<DataGridViewRow>().First().Selected = true;
            }
          
           
        }
        private void MenuTop4ToolStripMenuItem_MouseEnter(object sender, EventArgs e)
        {
            Cursor = System.Windows.Forms.Cursors.Hand;//دیزاین
        }
        private void MenuTop4ToolStripMenuItem_MouseLeave(object sender, EventArgs e)
        {
            Cursor = System.Windows.Forms.Cursors.Default;//دیزاین
        }
        private void MenuTop3ToolStripMenuItem_Click(object sender, EventArgs e)//کل بیماران
        {
            dt.Rows.Clear();
            grdIntermittenc.DataSource = dt;
            if (ISSecretory)
            {
                //tabControl2.TabPages[0].Controls.Clear();
                cmbCenters.Text = "";
                cmbCenters.DataSource = null;
                btnSave.Enabled = false;
            } GridDataSourceDS = null;
            btnNew.Enabled = true;
            tabControl2.Hide();
            tabControl1.Show();
            SelectMenuTop(MenuTop3ToolStripMenuItem);
            MenuTop3ToolStripMenuItem.Text = "";
            if (pictureBox1.Image != null)
            {

                pictureBox1.Image.Dispose();
                pictureBox1.Image = null;
            }
            pictureBox1.Invalidate();
            pictureBox1.Enabled = true;
            grdDocuments.SelectionChanged -= grdDocuments_SelectionChanged;
            grdDocuments.DataSource = null;
            grdDocuments.SelectionChanged += grdDocuments_SelectionChanged;
            GridDataSourceDS = da.ExecuteCommand("GetAllDoctorIntermittences", DepartmentID);

            if (GridDataSourceDS == null || GridDataSourceDS.Tables.Count == 0 || GridDataSourceDS.Tables[0].Rows.Count == 0)
            {
                MenuTop3ToolStripMenuItem.Text = "0" + " " + "کل بیماران";
                return;
            }
            else
            {
                
                FillGrid(GridDataSourceDS.Tables[0]);
                MenuTop3ToolStripMenuItem.Text = grdIntermittenc.Rows.Count.ToString() + " " + "کل بیماران";
                grdIntermittenc.Rows.OfType<DataGridViewRow>().First().Selected = true;   
            }
          
        }
        private void CheckAnswerOFDrugStors()
        {

            if (grdDocuments.SelectedRows.Count==0 )
                return;
            if (grdDocuments.SelectedRows[0].Cells["CenterIDSent"].Value.ToString() != "") return;
            if (centersDT.Rows.Count == 0)
                return;


            foreach (DataRow row in centersDT.Rows)// (int i = 0; i < txtTeamNames.Length; i++)ffillg
            {
                if (grdDocuments.SelectedRows.Count!= 1)
                    return;

                Button btnSend1 = this.Controls.Find(row["IDCenters"].ToString(), true).FirstOrDefault() as Button;
                Button btnRequest1 = this.Controls.Find("Request" + row["IDCenters"].ToString(), true).FirstOrDefault() as Button;
                if (btnSend1 == null)
                    return;

                DataSet astatusOFrequest = new DataSet();


                SqlParameter[] param1;
                param1 = new SqlParameter[3];
                int index1 = 0;



                param1[index1++] = new SqlParameter("@IDCenter", Convert.ToInt32(row["IDCenters"]));
                // param[index++] = new SqlParameter("@DateReply", DateTime.Now);
                param1[index1++] = new SqlParameter("@IDDocument", Convert.ToInt32(grdDocuments.SelectedRows[0].Cells["ID"].Value));
                astatusOFrequest = da.ExecuteSP("GetastatusOFDrugStoreRequest", param1);
                if (astatusOFrequest != null && astatusOFrequest.Tables.Count > 0 && astatusOFrequest.Tables[0].Rows.Count > 0)
                {
                     if (astatusOFrequest.Tables[0].Rows[0]["HavingReply"].ToString()=="" ||  Convert.ToInt16(astatusOFrequest.Tables[0].Rows[0]["HavingReply"]) == -1)
                        {
                            btnSend1.Enabled = false;
                            btnSend1.ForeColor = Color.White;
                            btnSend1.BackColor = color;
                            //btnRequest.Enabled = false;
                            btnRequest1.Click -= btnRequest_Click;
                            btnRequest1.BackColor = Color.Transparent; btnRequest1.Text = "";
                            btnRequest1.Image = Properties.Resources.hourglass;
                        }
                      else  if (Convert.ToInt16(astatusOFrequest.Tables[0].Rows[0]["HavingReply"]) == 0)
                        {
                            btnSend1.Enabled = false;
                            btnSend1.ForeColor = Color.White;
                            btnSend1.BackColor = Color.FromName("Control");
                            //btnRequest.Enabled = false;
                            btnRequest1.Click -= btnRequest_Click;
                            btnRequest1.BackColor = Color.Transparent; btnRequest1.Text = "";
                            btnRequest1.Image = Properties.Resources._1422945227_Delete;
                        }
                        else if (Convert.ToInt16(astatusOFrequest.Tables[0].Rows[0]["HavingReply"]) == 1)
                        {
                            btnSend1.Enabled = true;
                            btnSend1.ForeColor = Color.Black;
                            btnSend1.BackColor = Color.FromName("Control");
                            //btnRequest.Enabled = false;
                            btnRequest1.Click -= btnRequest_Click;
                            btnRequest1.BackColor = Color.Transparent; btnRequest1.Text = "";
                            btnRequest1.Image = Properties.Resources.check;
                        }
                        
                    }
              



                else
                {


                    SqlParameter[] param;
                    param = new SqlParameter[1];
                    int index = 0;

                    DataSet AnswerDS = new DataSet();

                    param[index++] = new SqlParameter("@IDDocument", Convert.ToInt32(grdDocuments.SelectedRows[0].Cells["ID"].Value));

                    AnswerDS = da.ExecuteSP("GetAnswerFromDrugStores", param);
                    if (AnswerDS != null && AnswerDS.Tables.Count > 0 && AnswerDS.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow r in AnswerDS.Tables[0].Rows)
                        {
                            if ( r["HavingReply"] != DBNull.Value && Convert.ToBoolean(r["HavingReply"]))
                            {

                                Button btnSend = this.Controls.Find(r["IDCenter"].ToString(), true).FirstOrDefault() as Button;
                                Button btnRequest = this.Controls.Find("Request" + r["IDCenter"].ToString(), true).FirstOrDefault() as Button;
                                if (btnSend == null)
                                    return;
                                btnSend.Enabled = true;
                                btnSend.ForeColor = Color.Black;
                                btnSend.BackColor = color;
                                //btnRequest.Enabled = false;
                                btnRequest.Click -= btnRequest_Click;
                                btnRequest.BackColor = Color.Transparent; btnRequest.Text = "";
                                btnRequest.Image = Properties.Resources.check;
                            }
                            if (r["HavingReply"] != DBNull.Value && !Convert.ToBoolean(r["HavingReply"]))
                            {

                                Button btnSend = this.Controls.Find(r["IDCenter"].ToString(), true).FirstOrDefault() as Button;
                                Button btnRequest = this.Controls.Find("Request" + r["IDCenter"].ToString(), true).FirstOrDefault() as Button;
                                if (btnSend == null)
                                    return;
                                btnSend.Enabled = false;
                                btnSend.ForeColor = Color.White;
                                btnSend.BackColor = Color.FromName("Control");
                                //btnRequest.Enabled = false;
                                btnRequest.Click -= btnRequest_Click;
                                btnRequest.BackColor = Color.Transparent; btnRequest.Text = "";
                                btnRequest.Image = Properties.Resources._1422945227_Delete;
                            }
                        }
                    }

                }



            }
                }
        private void timer1_Tick(object sender, EventArgs e)
        {

            if (ISSecretory && grdDocuments.SelectedRows.Count > 0 && Convert.ToInt16(grdDocuments.SelectedRows[0].Cells["DocumentType"].Value) == 1) 
            {
              CheckAnswerOFDrugStors();
            }
        }
        private void button3_MouseEnter(object sender, EventArgs e)
        {
            button3.BackColor = Color.White;
        }
        //   private void timer2_Tick(object sender, EventArgs e)
       // {
            ////SqlParameter[] param;
            ////param = new SqlParameter[1];
            ////int inde = 0;
            ////param[inde++] = new SqlParameter("@TableName", this.Tag.ToString());
            //////return new SqlBinary(this.dataAccess.ExecuteScalarSP("spGetLastTimeStamp", param) as byte[]);
            ////Object timeStamp = this.da.ExecuteScalarSP("GetLastTimeStamp", param);
            
  


            ////lastTimeStamp =timeStamp.ToString() == "-2" ? new DateTime() : Convert.ToDateTime(timeStamp);
        
            ////if ( ((System.DateTime)(timeStamp)).TimeOfDay.CompareTo(lastTimeStamp.TimeOfDay) != 0)// timeStamp.CompareTo(lastTimeStamp) != 0)
            ////{
            //    int index1 = 0;
            //    int index = 0;
            //    if (grdIntermittenc.SelectedRows.Count > 0)
            //        index = grdIntermittenc.SelectedRows[0].Index;
            //    if (grdDocuments.SelectedRows.Count > 0)
            //        index1 = grdDocuments.SelectedRows[0].Index;

            //    //  menuStrip1_ItemClicked(null,null);
            //    //grdIntermittenc.SelectionChanged -= grdIntermittenc_SelectionChanged;
            //    GridDataSourceDS = null;
            //    GridDataSourceDS = da.ExecuteCommand("GetAllDoctorIntermittences", DepartmentID);
            //    MenuTop3ToolStripMenuItem.Text = "";
            //    if (MenuTop3ToolStripMenuItem.Checked) FillGrid(GridDataSourceDS.Tables[0]);


            //    if (GridDataSourceDS != null && GridDataSourceDS.Tables.Count > 0 && GridDataSourceDS.Tables[0].Rows.Count > 0)
            //    {
            //        MenuTop3ToolStripMenuItem.Text = GridDataSourceDS.Tables[0].Rows.Count.ToString() + " " + "کل بیماران";



            //    }
            //    else
            //    {
            //        MenuTop3ToolStripMenuItem.Text = "0" + " " + "کل بیماران";

            //    }



            //    GridDataSourceDS = null;
            //    GridDataSourceDS = da.ExecuteCommand("GetLabsForVerifyByDoctor", DepartmentID);
            //    MenuTop1ToolStripMenuItem.Text = "";
            //    if (MenuTop1ToolStripMenuItem.Checked) FillGrid(GridDataSourceDS.Tables[0]);
            //    if (GridDataSourceDS != null && GridDataSourceDS.Tables.Count > 0 && GridDataSourceDS.Tables[0].Rows.Count > 0)
            //    {
            //        MenuTop1ToolStripMenuItem.Text = GridDataSourceDS.Tables[0].Rows.Count.ToString() + " " + "کارتابل";



            //    }
            //    else
            //    {
            //        MenuTop1ToolStripMenuItem.Text = "0" + " " + "کارتابل";
            //    }


            //    GridDataSourceDS = null;
            //    GridDataSourceDS = da.ExecuteCommand("GetTodayIntermittences", DepartmentID);
            //    MenuTop4ToolStripMenuItem.Text = "";
            //    if (MenuTop4ToolStripMenuItem.Checked
            //        ) FillGrid(GridDataSourceDS.Tables[0]);
            //    if (GridDataSourceDS != null && GridDataSourceDS.Tables.Count > 0 && GridDataSourceDS.Tables[0].Rows.Count > 0)
            //    {
            //        MenuTop4ToolStripMenuItem.Text = GridDataSourceDS.Tables[0].Rows.Count.ToString() + " " + "نویت های امروز";


            //    }
            //    else
            //    {
            //        MenuTop4ToolStripMenuItem.Text = "0" + " " + "نویت های امروز";
            //    }
            //    if (grdIntermittenc.Rows.Count > 0)
            //        grdIntermittenc.Rows[0].Selected = false;
            //    if (grdIntermittenc.Rows.Count >= index + 1)
            //        grdIntermittenc.Rows[index].Selected = true;
            //    grdDocuments.SelectionChanged -= grdDocuments_SelectionChanged;
            //   // grdIntermittenc_CellClick(null, null);
            //    grdDocuments.SelectionChanged += grdDocuments_SelectionChanged;

            //    // FillDocumentsGrid();
            //    //if (grdDocuments.Rows.Count > 0)
            //    //    grdDocuments.Rows[0].Selected = false;
            //    //if (grdDocuments.Rows.Count >= index1 + 1)
            //    //    grdDocuments.Rows[index1].Selected = true;

            //    if (MenuTop1ToolStripMenuItem.Checked)
            //    {
            //        tabControl1.Visible = false;
            //        tabControl2.Visible = true;
            //    }
            //    //grdDocuments.SelectionChanged -= grdDocuments_SelectionChanged;
            //    //  FillDocumentsGrid();
            //    //  grdDocuments.SelectionChanged += grdDocuments_SelectionChanged;
            //    //   grdIntermittenc.SelectionChanged+= grdIntermittenc_SelectionChanged;

            //    //if (MenuTop1ToolStripMenuItem.Checked) SelectMenuTop(MenuTop1ToolStripMenuItem);
            //    //else  if (MenuTop3ToolStripMenuItem.Checked) SelectMenuTop(MenuTop3ToolStripMenuItem);
            //    //else  if (MenuTop4ToolStripMenuItem.Checked) SelectMenuTop(MenuTop4ToolStripMenuItem);
            //    //if (grdIntermittenc.Rows.Count >= i + 1)

            //    // grdIntermittenc.Rows[i].Selected = true;    
            //    // }
           
               
            //    timeStamp = lastTimeStamp;
            ////}

           
              


        //}
        #region ColorBox
        private void ColorCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            colorBox1.Visible = panel4.Visible = ColorCheckBox.Checked;
        }

        private void colorBox1_ColorChange(Color color)
        {
            this.color = color;
            Properties.Settings.Default.Color = color;
            Properties.Settings.Default.Save();
            SetColor();
        }

        private void colorBox1_Leave(object sender, EventArgs e)
        {
            ColorCheckBox.Checked = false;
        }
        #endregion
        private void grdDocuments_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = grdDocuments.CurrentRow.Index;
            grdDocuments.Rows[index].Selected = true;
           // grdDocuments_SelectionChanged(null, null);
        }
        private void timer2_Tick(object sender, EventArgs e)
        {
            int oldRowCounts = grdIntermittenc.Rows.Count;
            int newRowCounts = 0;
            int index = 0;
            if (grdIntermittenc.SelectedRows.Count > 0)
                index = grdIntermittenc.SelectedRows[0].Index;
            

            DataSet ds = new DataSet();
            if (MenuTop4ToolStripMenuItem.Checked)
            {
                ds = da.ExecuteCommand("GetTodayIntermittences", DepartmentID);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    newRowCounts = ds.Tables[0].Rows.Count;
                }
                if (newRowCounts > oldRowCounts)
                {
                    System.Media.SystemSounds.Asterisk.Play();
                    // buttonToolTip.ToolTipTitle = " جدید";
                    buttonToolTip.UseFading = true;
                    buttonToolTip.BackColor = Color.Yellow;
                    buttonToolTip.UseAnimation = true;
                    buttonToolTip.IsBalloon = true;
                    buttonToolTip.ShowAlways = false;
                    //buttonToolTip.AutoPopDelay = 100;
                    buttonToolTip.InitialDelay = 0;
                    IWin32Window win = this;
                    buttonToolTip.Show("نوبت جدیدی اضافه شد.", btnCync);
                }
                  return;
            }
            DataSet dsall = new DataSet();
            if (MenuTop3ToolStripMenuItem.Checked)
            {
                dsall = da.ExecuteCommand("GetAllDoctorIntermittences", DepartmentID);
                if (dsall != null && dsall.Tables.Count > 0 && dsall.Tables[0].Rows.Count > 0)
                {
                    newRowCounts = dsall.Tables[0].Rows.Count;
                }
                if (newRowCounts > oldRowCounts)
                {
                    System.Media.SystemSounds.Asterisk.Play();
                    // buttonToolTip.ToolTipTitle = " جدید";
                    buttonToolTip.UseFading = true; buttonToolTip.BackColor = Color.Yellow;
                    buttonToolTip.UseAnimation = true;
                    buttonToolTip.IsBalloon = true;
                    buttonToolTip.ShowAlways = false;
                    //buttonToolTip.AutoPopDelay = 100;
                    buttonToolTip.InitialDelay = 0;
                    IWin32Window win = this;
                    buttonToolTip.Show("به بیماران کل بیماری اضافه شد.", btnCync);
                }
            return;

            }
            DataSet dskarabl = new DataSet();
             if (MenuTop1ToolStripMenuItem.Checked)
            {
                dskarabl = da.ExecuteCommand("GetLabsForVerifyByDoctor", DepartmentID);
                if (dskarabl != null && dskarabl.Tables.Count > 0 && dskarabl.Tables[0].Rows.Count > 0)
                {
                    newRowCounts = dskarabl.Tables[0].Rows.Count;
                }
                if (newRowCounts > oldRowCounts)
                {
                    System.Media.SystemSounds.Asterisk.Play();
                    // buttonToolTip.ToolTipTitle = " جدید";
                    buttonToolTip.UseFading = true; 
                    buttonToolTip.BackColor = Color.Yellow;
                    buttonToolTip.UseAnimation = true;
                    buttonToolTip.IsBalloon = true;
                    buttonToolTip.ShowAlways = false;
                    //buttonToolTip.AutoPopDelay = 100;
                    buttonToolTip.InitialDelay = 0;
                    IWin32Window win = this;
                    buttonToolTip.Show("بیماری به کارتابل اضافه شد.", btnCync);
                }
                return;

            }

            //if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            //{
            //    MenuTop4ToolStripMenuItem.Text = ds.Tables[0].Rows.Count.ToString() + " " + "نویت های امروز";
            //    if (MenuTop4ToolStripMenuItem.Checked)
            //    {
            //        GridDataSourceDS = ds;
            //        FillGrid(ds.Tables[0]);
            //    }
            //}
            //else
            //{
            //    MenuTop4ToolStripMenuItem.Text = "0" + " " + "نویت های امروز";
            //}


            //if (dsall != null && dsall.Tables.Count > 0 && dsall.Tables[0].Rows.Count > 0)
            //{
            //    MenuTop3ToolStripMenuItem.Text = dsall.Tables[0].Rows.Count.ToString() + " " + "کل بیماران";
            //    if (MenuTop3ToolStripMenuItem.Checked)
            //    {
            //        GridDataSourceDS = dsall;
            //        FillGrid(dsall.Tables[0]);
            //    }

            //}
            //else
            //{
            //    MenuTop3ToolStripMenuItem.Text = "0" + " " + "کل بیماران";
            //}


            //if (dskarabl != null && dskarabl.Tables.Count > 0 && dskarabl.Tables[0].Rows.Count > 0)
            //{
            //    MenuTop1ToolStripMenuItem.Text = dskarabl.Tables[0].Rows.Count.ToString() + " " + "کارتابل";
            //    if (MenuTop1ToolStripMenuItem.Checked)
            //    {
            //        GridDataSourceDS = dskarabl;
            //        FillGrid(dskarabl.Tables[0]);
            //    }

            //}
            //else
            //{
            //    MenuTop1ToolStripMenuItem.Text = "0" + " " + "کارتابل";
            //}

            //if (grdIntermittenc.Rows.Count > 0)
            //    grdIntermittenc.Rows[0].Selected = false;
            //if (grdIntermittenc.Rows.Count >= index + 1)
            //    grdIntermittenc.Rows[index].Selected = true;

            //grdIntermittenc.CellClick += grdIntermittenc_CellClick;
            //grdIntermittenc.SelectionChanged += grdIntermittenc_SelectionChanged;

            //newRowCounts = grdIntermittenc.Rows.Count;
            //if (newRowCounts > oldRowCounts)
            //{
            //    System.Media.SystemSounds.Asterisk.Play();
            //}

        
        
      

































        //    //SqlParameter[] param;
        //    //param = new SqlParameter[1];
        //    //int inde = 0;
        //    //param[inde++] = new SqlParameter("@TableName", this.Tag.ToString());
        //    ////return new SqlBinary(this.dataAccess.ExecuteScalarSP("spGetLastTimeStamp", param) as byte[]);
        //    //Object timeStamp = this.da.ExecuteScalarSP("GetLastTimeStamp", param);




        //    //lastTimeStamp =timeStamp.ToString() == "-2" ? new DateTime() : Convert.ToDateTime(timeStamp);

        //    //if ( ((System.DateTime)(timeStamp)).TimeOfDay.CompareTo(lastTimeStamp.TimeOfDay) != 0)// timeStamp.CompareTo(lastTimeStamp) != 0)
        //    //{ 
        //    grdDocuments.SelectionChanged -= grdDocuments_SelectionChanged;
        //    grdIntermittenc.SelectionChanged -= grdIntermittenc_SelectionChanged;
        //    int index1 = 0;
        //    int index = 0;
        //    if (grdIntermittenc.SelectedRows.Count > 0)
        //        index = grdIntermittenc.SelectedRows[0].Index;
        //    if (grdDocuments.SelectedRows.Count > 0)
        //        index1 = grdDocuments.SelectedRows[0].Index;
          
        //    //  menuStrip1_ItemClicked(null,null);
        //    //grdIntermittenc.SelectionChanged -= grdIntermittenc_SelectionChanged;
        //    GridDataSourceDS = null;
        //    GridDataSourceDS = da.ExecuteCommand("GetAllDoctorIntermittences", DepartmentID);
        //    MenuTop3ToolStripMenuItem.Text = "";
        //    if (MenuTop3ToolStripMenuItem.Checked)
        //    {
        //        grdIntermittenc.SelectionChanged -= grdIntermittenc_SelectionChanged;
        //        FillGrid(GridDataSourceDS.Tables[0]);
        //        //grdIntermittenc.SelectionChanged += grdIntermittenc_SelectionChanged;
        //    }
        //    if (GridDataSourceDS != null && GridDataSourceDS.Tables.Count > 0 && GridDataSourceDS.Tables[0].Rows.Count > 0)
        //    {
        //        MenuTop3ToolStripMenuItem.Text = GridDataSourceDS.Tables[0].Rows.Count.ToString() + " " + "کل بیماران";



        //    }
        //    else
        //    {
        //        MenuTop3ToolStripMenuItem.Text = "0" + " " + "کل بیماران";

        //    }



        //    GridDataSourceDS = null;
        //    GridDataSourceDS = da.ExecuteCommand("GetLabsForVerifyByDoctor", DepartmentID);
        //    MenuTop1ToolStripMenuItem.Text = "";
        //    if (MenuTop1ToolStripMenuItem.Checked)
        //    {
        //        grdDocuments.SelectionChanged -= grdDocuments_SelectionChanged;
        //        grdIntermittenc.SelectionChanged -= grdIntermittenc_SelectionChanged;
        //        FillGrid(GridDataSourceDS.Tables[0]);
        //        //grdIntermittenc.SelectionChanged += grdIntermittenc_SelectionChanged;
        //        //grdDocuments.SelectionChanged += grdDocuments_SelectionChanged;
        //    }
        //    if (GridDataSourceDS != null && GridDataSourceDS.Tables.Count > 0 && GridDataSourceDS.Tables[0].Rows.Count > 0)
        //    {
        //        MenuTop1ToolStripMenuItem.Text = GridDataSourceDS.Tables[0].Rows.Count.ToString() + " " + "کارتابل";



        //    }
        //    else
        //    {
        //        MenuTop1ToolStripMenuItem.Text = "0" + " " + "کارتابل";
        //    }


        //    GridDataSourceDS = null;
        //    GridDataSourceDS = da.ExecuteCommand("GetTodayIntermittences", DepartmentID);
        //    MenuTop4ToolStripMenuItem.Text = "";
        //    if (MenuTop4ToolStripMenuItem.Checked)
                
        //    {
              
        //        FillGrid(GridDataSourceDS.Tables[0]);
        //        //grdIntermittenc.SelectionChanged += grdIntermittenc_SelectionChanged;
        //        //grdDocuments.SelectionChanged += grdDocuments_SelectionChanged;
        //    }
        //    if (GridDataSourceDS != null && GridDataSourceDS.Tables.Count > 0 && GridDataSourceDS.Tables[0].Rows.Count > 0)
        //    {
        //        MenuTop4ToolStripMenuItem.Text = GridDataSourceDS.Tables[0].Rows.Count.ToString() + " " + "نویت های امروز";


        //    }
        //    else
        //    {
        //        MenuTop4ToolStripMenuItem.Text = "0" + " " + "نویت های امروز";
        //    }
        //    if (grdIntermittenc.Rows.Count > 0)
        //        grdIntermittenc.Rows[0].Selected = false;
        //    if (grdIntermittenc.Rows.Count >= index + 1)
        //        grdIntermittenc.Rows[index].Selected = true;
           

        //   // grdDocuments.SelectionChanged -= grdDocuments_SelectionChanged;
        //    // grdIntermittenc_CellClick(null, null);
        //  //  grdDocuments.SelectionChanged += grdDocuments_SelectionChanged;

        //    // FillDocumentsGrid();
        //    if (grdDocuments.Rows.Count > 0)
        //        grdDocuments.Rows[0].Selected = false;
        //    if (grdDocuments.Rows.Count >= index1 + 1)
        //        grdDocuments.Rows[index1].Selected = true;
        //grdIntermittenc.SelectionChanged += grdIntermittenc_SelectionChanged;
        //    grdDocuments.SelectionChanged += grdDocuments_SelectionChanged;
        //    //if (MenuTop1ToolStripMenuItem.Checked)
        //    //{
        //    //    tabControl1.Visible = false;
        //    //    tabControl2.Visible = true;
        //    //}
        //    //grdDocuments.SelectionChanged -= grdDocuments_SelectionChanged;
        //    //  FillDocumentsGrid();
        //    //  grdDocuments.SelectionChanged += grdDocuments_SelectionChanged;
        //    //   grdIntermittenc.SelectionChanged+= grdIntermittenc_SelectionChanged;

        //    //if (MenuTop1ToolStripMenuItem.Checked) SelectMenuTop(MenuTop1ToolStripMenuItem);
        //    //else  if (MenuTop3ToolStripMenuItem.Checked) SelectMenuTop(MenuTop3ToolStripMenuItem);
        //    //else  if (MenuTop4ToolStripMenuItem.Checked) SelectMenuTop(MenuTop4ToolStripMenuItem);
        //    //if (grdIntermittenc.Rows.Count >= i + 1)

        //    // grdIntermittenc.Rows[i].Selected = true;    
        //    // }


        //    //timeStamp = lastTimeStamp;
        //    //}

           
              
        }
        private void grdIntermittenc_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (grdIntermittenc.Rows.Count>0)
            grdIntermittenc.Rows[grdIntermittenc.CurrentRow.Index].Selected = true;
        }
        private void button1_Click_2(object sender, EventArgs e)
        {

            if (Id == null || Id == "") return;
            DataTable settingDT = new DataTable();
            settingDT = da.ExecuteCommand("GetSetting").Tables[0];

            if ( settingDT.Rows[0]["TypeOfDocumentDetail"] !=DBNull.Value && Convert.ToBoolean(settingDT.Rows[0]["TypeOfDocumentDetail"]))
            { 
                
                if (grdIntermittenc.SelectedRows.Count==1)
            Id = ( grdIntermittenc.SelectedRows[0].Cells[1].Value).ToString();
            if (Id == "0")
            { Id = (grdIntermittenc.Rows[0].Cells[1].Value).ToString(); }
                DocumentsDetails dd = new DocumentsDetails( Id.Trim());
                dd.ShowDialog();
            }
            else
            System.Diagnostics.Process.Start(settingDT.Rows[0]["DocumentUrl"].ToString().Replace("%1",Id.Trim()));
            panel1.Visible = false;
        }

        private void btnAttach_Click(object sender, EventArgs e)
        {

            panel1.Visible = true;
        }

        private void gbInsertCenter_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click_3(object sender, EventArgs e)
        {
            myBrush.Color = button1.BackColor;
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            myBrush.Color = button2.BackColor;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            myBrush.Color = Color.Red;
        }

        private void button6_Click(object sender, EventArgs e)
        {

            size = (byte)1;
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            size = (byte)2;
        }

        private void btnBackGround_Click(object sender, EventArgs e)
        {
            SqlParameter[] param;
            param = new SqlParameter[1];
            int index = 0;

            DataSet BackGroundDS = new DataSet();

            param[index++] = new SqlParameter("@IDDocument", Convert.ToInt32(grdDocuments.SelectedRows[0].Cells["ID"].Value));

            BackGroundDS = da.ExecuteSP("GetBackGround", param);
            if (BackGroundDS != null && BackGroundDS.Tables.Count > 0 && BackGroundDS.Tables[0].Rows.Count > 0)
            {
                BackGround bg = new BackGround(BackGroundDS.Tables[0]);
                bg.ShowDialog();
            }
            else
            {
                var msg = "سابقه ای برای نمایش وجو ندارد."; MessageForm.Show(msg, "", MessageFormIcons.Warning, MessageFormButtons.Ok, color);
            }
        }

        private void pbComment_MouseMove(object sender, MouseEventArgs e)
        {
            Pen _Pen = new Pen(myBrush);
            if (size == (byte)2)
                _Pen.Width = 2;
            else
                _Pen.Width = 1;

            _Pen.EndCap = LineCap.Round;
            _Pen.StartCap = LineCap.Round;

            if (_Previous != null)
            {
                if (pbComment.Image == null)
                {
                    Bitmap bmp = new Bitmap(pbComment.Width, pbComment.Height);
                    using (Graphics g = Graphics.FromImage(bmp))
                    {
                        g.Clear(pbComment.BackColor);
                    }
                    pbComment.Image = bmp;
                }
                using (Graphics g = Graphics.FromImage(pbComment.Image))
                {
                    g.DrawLine(_Pen, _Previous.Value.X, _Previous.Value.Y, e.X, e.Y);
                }
                pbComment.Invalidate();
                pbComment.Enabled = true;

                _Previous = new Point(e.X, e.Y);
            }
        }

        private void pbComment_MouseDown(object sender, MouseEventArgs e)
        {
            _Previous = new Point(e.X, e.Y);
            pbComment_MouseMove(sender, e);
        }

        private void pbComment_MouseUp(object sender, MouseEventArgs e)
        {
            _Previous = null;
        }

        private void grdDocuments_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            if (grdIntermittenc.SelectedRows.Count == 0) { panel1.Visible = false; return; }


            DataSet imageDS = new DataSet();
            imageDS = da.GetpationtInfo("GetCustomerImageInfo", grdIntermittenc.SelectedRows[0].Cells[1].Value.ToString());

            if (imageDS != null && imageDS.Tables.Count > 0 && imageDS.Tables[0].Rows.Count > 0)
            {
                ShowAttachments sa = new ShowAttachments(grdIntermittenc.SelectedRows[0].Cells[1].Value.ToString(),0);
                panel1.Visible = false;
                sa.ShowDialog(); return;
            }
            else
            {
                //  buttonToolTip.ToolTipTitle = "پ";
                buttonToolTip.UseFading = true;
                buttonToolTip.UseAnimation = true;
                buttonToolTip.IsBalloon = true;
                buttonToolTip.ShowAlways = false;
                buttonToolTip.AutoPopDelay = 100;
                buttonToolTip.InitialDelay = 0;
                IWin32Window win = this;
                buttonToolTip.Show("پیوستی جهت نمایش وجود ندارد.", win, MousePosition, 3000);


            } panel1.Visible = false;

        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            if (grdIntermittenc.SelectedRows.Count == 0) { panel1.Visible = false; return; }


            DataSet imageDS = new DataSet();
            imageDS = da.GetpationtInfo("GetCustomerImageInfo", grdIntermittenc.SelectedRows[0].Cells[1].Value.ToString());

            if (imageDS != null && imageDS.Tables.Count > 0 && imageDS.Tables[0].Rows.Count > 0)
            {
                ShowAttachments sa = new ShowAttachments(grdIntermittenc.SelectedRows[0].Cells[1].Value.ToString(),0);
                panel1.Visible = false;
                sa.ShowDialog(); return;
            }
            else
            {
                //  buttonToolTip.ToolTipTitle = "پ";
                buttonToolTip.UseFading = true;
                buttonToolTip.UseAnimation = true;
                buttonToolTip.IsBalloon = true;
                buttonToolTip.ShowAlways = false;
                buttonToolTip.AutoPopDelay = 100;
                buttonToolTip.InitialDelay = 0;
                IWin32Window win = this;
                buttonToolTip.Show("پیوستی جهت نمایش وجود ندارد.", win, MousePosition, 3000);


            } panel1.Visible = false;

        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            if (grdIntermittenc.SelectedRows.Count == 0) { panel1.Visible = false; return; }


            DataSet imageDS = new DataSet();
            imageDS = da.GetpationtInfo("GetCustomerImageInfo", grdIntermittenc.SelectedRows[0].Cells[1].Value.ToString());

            if (imageDS != null && imageDS.Tables.Count > 0 && imageDS.Tables[0].Rows.Count > 0)
            {
                ShowAttachments sa = new ShowAttachments(grdIntermittenc.SelectedRows[0].Cells[1].Value.ToString(),0);
              panel1.Visible = false;
              sa.ShowDialog(); return;
            }
            else
            {
                //  buttonToolTip.ToolTipTitle = "پ";
                buttonToolTip.UseFading = true;
                buttonToolTip.UseAnimation = true;
                buttonToolTip.IsBalloon = true;
                buttonToolTip.ShowAlways = false;
                buttonToolTip.AutoPopDelay = 100;
                buttonToolTip.InitialDelay = 0;
                IWin32Window win = this;
                buttonToolTip.Show("پیوستی جهت نمایش وجود ندارد.", win, MousePosition, 3000);


            } 

        }

        private void menuStrip3_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
          

        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
  if (grdIntermittenc.SelectedRows.Count == 0) { panel1.Visible = false; return; }

            DataSet imageDS = new DataSet();
            imageDS = da.GetpationtInfo("GetCustomerImageInfo", grdIntermittenc.SelectedRows[0].Cells[1].Value.ToString());

            if (imageDS != null && imageDS.Tables.Count > 0 && imageDS.Tables[0].Rows.Count > 0)
            {
                ShowAttachments sa = new ShowAttachments(grdIntermittenc.SelectedRows[0].Cells[1].Value.ToString(),0);
                panel1.Visible = false;
                sa.ShowDialog(); return;
            }
            else
            {
                //  buttonToolTip.ToolTipTitle = "پ";
                buttonToolTip.UseFading = true;
                buttonToolTip.UseAnimation = true;
                buttonToolTip.IsBalloon = true;
                buttonToolTip.ShowAlways = false;
                buttonToolTip.AutoPopDelay = 100;
                buttonToolTip.InitialDelay = 0;
                IWin32Window win = this;
                buttonToolTip.Show("پیوستی جهت نمایش وجود ندارد.", win, MousePosition, 3000);


            } panel1.Visible = false;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (grdDocuments.SelectedRows.Count == 0)
                return;
            SqlParameter[] param;
            param = new SqlParameter[2];
            bool result;
            int index = 0;
            //if(btnGold.Image=Properties
            if (grdDocuments.SelectedRows.Count < 1) return;
            param[index++] = new SqlParameter("@IDDocument", Convert.ToInt32(grdDocuments.SelectedRows[0].Cells["ID"].Value));
            if (Convert.ToInt32(btnGold.Tag) == 0)
            {
                param[index++] = new SqlParameter("@Gold", true);
            }
            if (Convert.ToInt32(btnGold.Tag) == 1)
            {
                param[index++] = new SqlParameter("@Gold", false);
            }
            result = Convert.ToBoolean(this.da.ExecuteScalarSP("SetDocumenGold", param));

            if (result) {

                if (Convert.ToInt32(btnGold.Tag) == 0)
                {
                    btnGold.Image = Properties.Resources._1;
                    btnGold.Tag = 1;
                }
                else  if (Convert.ToInt32(btnGold.Tag) == 1)
                {
                  btnGold.Image = Properties.Resources._0;
                  btnGold.Tag = 0;

                }
              

}
        }

        private void DoctorKartable_FormClosed(object sender, FormClosedEventArgs e)
        {
            //ShowAttachments sa = new ShowAttachments(Properties.Resources.check.ToString(),3); sa.ShowDialog(); 
          
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            
            int oldRowCounts = grdIntermittenc.Rows.Count;
            int newRowCounts = 0;
            int index = 0;
            if (grdIntermittenc.SelectedRows.Count > 0)
                index = grdIntermittenc.SelectedRows[0].Index;
            grdIntermittenc.CellClick -= grdIntermittenc_CellClick;
            grdIntermittenc.SelectionChanged -= grdIntermittenc_SelectionChanged;

            DataSet ds = new DataSet();
            ds = da.ExecuteCommand("GetTodayIntermittences", DepartmentID);

            DataSet dsall = new DataSet();
            dsall = da.ExecuteCommand("GetAllDoctorIntermittences", DepartmentID);

            DataSet dskarabl = new DataSet();
            dskarabl = da.ExecuteCommand("GetLabsForVerifyByDoctor", DepartmentID);


            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                MenuTop4ToolStripMenuItem.Text = ds.Tables[0].Rows.Count.ToString() + " " + "نویت های امروز";
                if (MenuTop4ToolStripMenuItem.Checked)
                {
                    GridDataSourceDS = ds;
                    FillGrid(ds.Tables[0]);
                }
            }
            else
            {
                MenuTop4ToolStripMenuItem.Text = "0" + " " + "نویت های امروز";
            }


            if (dsall != null && dsall.Tables.Count > 0 && dsall.Tables[0].Rows.Count > 0)
            {
                MenuTop3ToolStripMenuItem.Text = dsall.Tables[0].Rows.Count.ToString() + " " + "کل بیماران";
                if (MenuTop3ToolStripMenuItem.Checked)
                {
                    GridDataSourceDS = dsall;
                    FillGrid(dsall.Tables[0]);
                }

            }
            else
            {
                MenuTop3ToolStripMenuItem.Text = "0" + " " + "کل بیماران";
            }


            if (dskarabl != null && dskarabl.Tables.Count > 0 && dskarabl.Tables[0].Rows.Count > 0)
            {
                MenuTop1ToolStripMenuItem.Text = dskarabl.Tables[0].Rows.Count.ToString() + " " + "کارتابل";
                if (MenuTop1ToolStripMenuItem.Checked)
                {
                    GridDataSourceDS = dskarabl;
                    FillGrid(dskarabl.Tables[0]);
                }

            }
            else
            {
                MenuTop1ToolStripMenuItem.Text = "0" + " " + "کارتابل";
            }

            if (grdIntermittenc.Rows.Count > 0)
                grdIntermittenc.Rows[0].Selected = false;
            if (grdIntermittenc.Rows.Count >= index + 1)
                grdIntermittenc.Rows[index].Selected = true;

            grdIntermittenc.CellClick += grdIntermittenc_CellClick;
            grdIntermittenc.SelectionChanged += grdIntermittenc_SelectionChanged;

            newRowCounts = grdIntermittenc.Rows.Count;
            if (newRowCounts > oldRowCounts)
            {
               // System.Media.SystemSounds.Asterisk.Play();
            } buttonToolTip.Hide(this);
        }
      
       

     
        }
    }

