using MesbahComponent;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
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
    public partial class Lablatory : Form
    {
        #region Variables
        private PictureBox pictureBox1 = new PictureBox();
        private int IDCenter;
        private string serial = "201302IP001336001652";
        private string PATH = Application.StartupPath + @"\setting.xml";
        private DataTable DoctDT = new DataTable();
        private DataTable DocumentDT = new DataTable();
        private DataTable ControlDT = new DataTable();
        SolidBrush myBrush = new SolidBrush(Color.Black);
        private ToolStripMenuItem menuActiveTop;
        private Bitmap drawing;
        private DataAccess da = new DataAccess();
        private DataTable dt = new DataTable();
        private DataTable dtDoc = new DataTable();
        private DataTable smsDt = new DataTable();
        private string  Id;
        private Color color;
        private TextBox[] txtTeamNames = new TextBox[1];
        public DataTable GridDataSourceDt;
        private bool IntOrChar;
        #endregion
        public Lablatory()
        {
            InitializeComponent();
            SetColor();
            SelectMenuTop(MenuTop4ToolStripMenuItem);
            //tabControl1.TabPages[1].Controls.Add(pictureBox1);
            //pictureBox1.MouseDown += new MouseEventHandler(pictureBox1_MouseDown);
            //pictureBox1.MouseMove += new MouseEventHandler(pictureBox1_MouseMove);
            //pictureBox1.MouseUp += new MouseEventHandler(pictureBox1_MouseUp);

        }
        private void Lock()
        {
           
            USBSerialNumber usb = new USBSerialNumber();
            if (usb.getSerialNumberFromDriveLetter("a:") != null)
            {
                if (usb.getSerialNumberFromDriveLetter("a:") == serial)
                    return;
                else
                {
                    var msg = "شناسایی قفل ناموفق است."; MessageForm.Show(msg, "خطای قفل", MessageFormIcons.Warning, MessageFormButtons.Ok, color);
                    this.Close();
                    System.Environment.Exit(1);
                }
            }
            else if (usb.getSerialNumberFromDriveLetter("b:") != null)
            {
                if (usb.getSerialNumberFromDriveLetter("b:") == serial)
                    return;
                else
                {
                    var msg = "شناسایی قفل ناموفق است."; MessageForm.Show(msg, "خطای قفل", MessageFormIcons.Warning, MessageFormButtons.Ok, color);
                    this.Close();
                    System.Environment.Exit(1);
                }
            }
            else if (usb.getSerialNumberFromDriveLetter("c:") != null)
            {
                if (usb.getSerialNumberFromDriveLetter("c:") == serial)
                    return;
                else
                {
                    var msg = "شناسایی قفل ناموفق است."; MessageForm.Show(msg, "خطای قفل", MessageFormIcons.Warning, MessageFormButtons.Ok, color);
                    this.Close();
                    System.Environment.Exit(1);
                }
            }
            else if (usb.getSerialNumberFromDriveLetter("d:") != null)
            {
                if (usb.getSerialNumberFromDriveLetter("d:") == serial)
                    return;
                else
                {
                    var msg = "شناسایی قفل ناموفق است."; MessageForm.Show(msg, "خطای قفل", MessageFormIcons.Warning, MessageFormButtons.Ok, color);
                    this.Close();
                    System.Environment.Exit(1);
                }
            }
            else if (usb.getSerialNumberFromDriveLetter("e:") != null)
            {
                if (usb.getSerialNumberFromDriveLetter("e:") == serial)
                    return;
                else
                {
                    var msg = "شناسایی قفل ناموفق است."; MessageForm.Show(msg, "خطای قفل", MessageFormIcons.Warning, MessageFormButtons.Ok, color);
                    this.Close();
                    System.Environment.Exit(1);
                }
            }

            else if (usb.getSerialNumberFromDriveLetter("f:") != null)
            {
                if (usb.getSerialNumberFromDriveLetter("f:") == serial)
                    return;
                else
                {
                    var msg = "شناسایی قفل ناموفق است."; MessageForm.Show(msg, "خطای قفل", MessageFormIcons.Warning, MessageFormButtons.Ok, color);
                    this.Close();
                    System.Environment.Exit(1);
                }
            }

            else if (usb.getSerialNumberFromDriveLetter("g:") != null)
            {
                if (usb.getSerialNumberFromDriveLetter("g:") == serial)
                    return;
                else
                {
                    var msg = "شناسایی قفل ناموفق است."; MessageForm.Show(msg, "خطای قفل", MessageFormIcons.Warning, MessageFormButtons.Ok, color);
                    this.Close();
                    System.Environment.Exit(1);
                }
            }

            else if (usb.getSerialNumberFromDriveLetter("h:") != null)
            {
                if (usb.getSerialNumberFromDriveLetter("h:") == serial)
                    return;
                else
                {
                    var msg = "شناسایی قفل ناموفق است."; MessageForm.Show(msg, "خطای قفل", MessageFormIcons.Warning, MessageFormButtons.Ok, color);
                    this.Close();
                    System.Environment.Exit(1);
                }
            }

            else if (usb.getSerialNumberFromDriveLetter("i:") != null)
            {
                if (usb.getSerialNumberFromDriveLetter("i:") == serial)
                    return;
                else
                {
                    var msg = "شناسایی قفل ناموفق است."; MessageForm.Show(msg, "خطای قفل", MessageFormIcons.Warning, MessageFormButtons.Ok, color);
                    this.Close();
                    System.Environment.Exit(1);
                }
            }

            else if (usb.getSerialNumberFromDriveLetter("j:") != null)
            {
                if (usb.getSerialNumberFromDriveLetter("j:") == serial)
                    return;
                else
                {
                    var msg = "شناسایی قفل ناموفق است."; MessageForm.Show(msg, "خطای قفل", MessageFormIcons.Warning, MessageFormButtons.Ok, color);
                    this.Close();
                    System.Environment.Exit(1);
                }
            }

            else if (usb.getSerialNumberFromDriveLetter("k:") != null)
            {
                if (usb.getSerialNumberFromDriveLetter("k:") == serial)
                    return;
                else
                {
                    var msg = "شناسایی قفل ناموفق است."; MessageForm.Show(msg, "خطای قفل", MessageFormIcons.Warning, MessageFormButtons.Ok, color);
                    this.Close();
                    System.Environment.Exit(1);
                }
            }

            else if (usb.getSerialNumberFromDriveLetter("l:") != null)
            {
                if (usb.getSerialNumberFromDriveLetter("l:") == serial)
                    return;
                else
                {
                    var msg = "شناسایی قفل ناموفق است."; MessageForm.Show(msg, "خطای قفل", MessageFormIcons.Warning, MessageFormButtons.Ok, color);
                    this.Close();
                    System.Environment.Exit(1);
                }
            }

            else if (usb.getSerialNumberFromDriveLetter("m:") != null)
            {
                if (usb.getSerialNumberFromDriveLetter("m:") == serial)
                    return;
                else
                {
                    var msg = "شناسایی قفل ناموفق است."; MessageForm.Show(msg, "خطای قفل", MessageFormIcons.Warning, MessageFormButtons.Ok, color);
                    this.Close();
                    System.Environment.Exit(1);
                }
            }

            else if (usb.getSerialNumberFromDriveLetter("n:") != null)
            {
                if (usb.getSerialNumberFromDriveLetter("n:") == serial)
                    return;
                else
                {
                    var msg = "شناسایی قفل ناموفق است."; MessageForm.Show(msg, "خطای قفل", MessageFormIcons.Warning, MessageFormButtons.Ok, color);
                    this.Close();
                    System.Environment.Exit(1);
                }
            }

            else if (usb.getSerialNumberFromDriveLetter("o:") != null)
            {
                if (usb.getSerialNumberFromDriveLetter("o:") == serial)
                    return;
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
        private void ChangeKeboardLayout(int culturenumber)
        {
            System.Globalization.CultureInfo CultureInfo = new System.Globalization.CultureInfo(culturenumber);
            // CultureInfo = new System.Globalization.CultureInfo(1);
            // CultureInfo = new System.Globalization.CultureInfo(2);
            InputLanguage c = InputLanguage.FromCulture(CultureInfo);
            InputLanguage.CurrentInputLanguage = c;
            //System.Globalization.CultureInfo culinfo=new System.Globalization.CultureInfo.GetCultures(System.Globalization.CultureTypes.NeutralCultures);
            //change
            //ChangeKeboardLayout(
        }
        private void Lablatory_Load(object sender, EventArgs e)
        {
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

            DateTime now = DateTime.Now;
            DateTime Update_New = DateTime.Parse("08/02/2015 12:00:00 AM");
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
                this.Show();
            else if (logon.ShowDialog() != DialogResult.OK)
            {
                this.Show();
            }
            SqlParameter[] param;
            param = new SqlParameter[2];
            int index = 0;
            param[index++] = new SqlParameter("@Serial", serial);
            DataSet result = new DataSet(); result = (da.ExecuteSP("GetSerial", param));
            if (result == null || result.Tables.Count == 0 || result.Tables[0].Rows.Count == 0 || result.Tables[0].Columns.Count == 0 || result.Tables[0].Rows[0]["IDCenters"]==DBNull.Value)
            { 
                var msg = "شناسایی مرکز ناموفق است."; MessageForm.Show(msg, "خطای اطلاعات مرکز", MessageFormIcons.Warning, MessageFormButtons.Ok, color);
            }
            else
            {
          // IDCenter = 8;
           IDCenter = Convert.ToInt32(result.Tables[0].Rows[0]["IDCenters"]); this.Text += " " + result.Tables[0].Rows[0]["NameCenters"].ToString();
            }

       
            WindowState = FormWindowState.Maximized;
            setLook();
            GridSet();
            GridDocumentsSet();
            //SqlParameter[] param;
            //param = new SqlParameter[1];
            //int index = 0;
            //param[index++] = new SqlParameter("@IDCenter",IDCenter);
            //GridDataSourceDt = da.ExecuteSP("GetCenetrsIntermittencee", param).Tables[0];
            //FillGrid(GridDataSourceDt);
            MenuTop4ToolStripMenuItem_Click(null, null);
            //SetColor(); 
            tabControl1_Selecting(null, null);
            
            grdIntermittenc_CellClick(null, null);
            timer1.Start();
        }

        private void setLook()
        {
           panel1.Size= pictureBox1.Size = tabPage1.Size;


            drawing = new Bitmap(pictureBox1.Width, pictureBox1.Height, pictureBox1.CreateGraphics());
            Graphics.FromImage(drawing).Clear(Color.White);
            tabControl1.TabPages[0].Controls.Add(pictureBox1);
            WindowState = FormWindowState.Maximized;
            color = Properties.Settings.Default.Color;
            // grdDocuments.BackgroundColor = ControlPaint.LightLight(ControlPaint.LightLight(ControlPaint.LightLight(ControlPaint.LightLight(color))));
            pictureBox1.Enabled = false;


        }

        private void SetColor()
        {
            color = Properties.Settings.Default.Color;
            SendSMSPanelWithBorder.BorderColor = color;
            button1.BackColor = color;
            btnNextPatiant.BackColor = color;
            //grdDocuments.ColumnHeadersDefaultCellStyle.BackColor = color;
            grdDocuments.RowsDefaultCellStyle.SelectionBackColor =  ControlPaint.LightLight(ControlPaint.LightLight(ControlPaint.LightLight(color)));
            //grdDocuments.AlternatingRowsDefaultCellStyle.BackColor = ControlPaint.LightLight(ControlPaint.LightLight(ControlPaint.LightLight(ControlPaint.LightLight(color))));
            grdIntermittenc.ColumnHeadersDefaultCellStyle.BackColor = color;
            grdIntermittenc.RowsDefaultCellStyle.SelectionBackColor = ControlPaint.LightLight(color);
            grdIntermittenc.AlternatingRowsDefaultCellStyle.BackColor = ControlPaint.LightLight(ControlPaint.LightLight(ControlPaint.LightLight(ControlPaint.LightLight(color))));

        }

        private void GridSet()// 
        {

            dt = new DataTable();

            dt.Columns.Add(IDIntermittence.Name);//شناسه
            dt.Columns.Add(CodeCol.Name);// تاریخ نوبت
            dt.Columns.Add(CustomerCol.Name);// کد ملی بیمار
            grdIntermittenc.DataSource = dt;

        }

        private void GridDocumentsSet()// 
        {
            grdDocuments.DataSource = null;
            dtDoc = new DataTable();

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

            DataGridViewTextBoxColumn CenterIDSent = new DataGridViewTextBoxColumn();
            CenterIDSent.Name = "CenterIDSent";
            CenterIDSent.HeaderText = "CenterIDSent";
            CenterIDSent.Visible = false;
            CenterIDSent.Width = 5;
            CenterIDSent.DataPropertyName = "CenterIDSent";

            //DataGridViewButtonColumn ReportErrorColumn = new DataGridViewButtonColumn();
            //ReportErrorColumn.Name = "ReportError";
            //ReportErrorColumn.HeaderText = "ReportError";
            //ReportErrorColumn.DataPropertyName = "ReportError";
            //ReportErrorColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            //ReportErrorColumn.MinimumWidth =100;
            //ReportErrorColumn.Width = 100;
            //grdDocuments.Columns.Add(ReportErrorColumn);
            //ReportErrorColumn.UseColumnTextForButtonValue = true;


            //DataGridViewComboBoxColumn cmb = new DataGridViewComboBoxColumn();
            //cmb.HeaderText = "SelectData";
            //cmb.Name = "SelectData";
            //cmb.MaxDropDownItems = 4;
            //cmb.Items.Add("True");
            //cmb.Items.Add("False");
            //grdDocuments.Columns.Add(cmb);


            grdDocuments.DataSource = dtDoc;


        }


        private void FillGrid(DataTable GridDataSourceDS)
        {
            if (GridDataSourceDS == null) return;

             smsDt.Rows.Clear();
            if (grdIntermittenc.Rows.Count > 0)
                grdIntermittenc.Rows.Clear();
            if (grdIntermittenc.DataSource != null)
                smsDt = (DataTable)grdIntermittenc.DataSource;// پاک کردن داده های قبلی گرید

            foreach (DataRow row in GridDataSourceDS.Rows)
            {

                DataRow dr = smsDt.Rows.Add();
                dr["IDIntermittence"] = 0;
                dr["CodeCol"] = row["NationalityCode"];
                dr["CustomerCol"] = row["Name"];
                Int32 index = grdIntermittenc.Rows.Count - 1;
          


            }
            if (smsDt.Rows.Count > 0)
            {
                grdIntermittenc.DataSource = smsDt;
                grdIntermittenc.Columns["IDIntermittence"].Visible = false;// در هر حالتی ستون آی دی نمایش داده نشود
                this.grdIntermittenc.Columns["CustomerCol"].DefaultCellStyle.Alignment = this.grdIntermittenc.Columns["CodeCol"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            
            }//  if (grdIntermittenc.Rows.Count>0)
  //   grdIntermittenc.Rows[0].Selected = true;

        }
        private byte[] ObjectToByteArray(Object obj)
        {
            if (obj == null)
                return null;
            BinaryFormatter bf = new BinaryFormatter();
            MemoryStream ms = new MemoryStream();
            bf.Serialize(ms, obj);
            return ms.ToArray();

        }
        private void FillDocumentsGrid()
        {
            DocumentDT.Rows.Clear();//= new DataTable();
            grdDocuments.DataSource = DocumentDT;
            if (grdIntermittenc.SelectedRows.Count>0 && grdIntermittenc.SelectedRows[0] != null)
                Id = (grdIntermittenc.SelectedRows[0].Cells[1].Value).ToString();
            if (Id == "0")
            { Id = (grdIntermittenc.Rows[0].Cells[1].Value).ToString(); }
            SqlParameter[] param;
            param = new SqlParameter[3];
            int index = 0;
            param[index++] = new SqlParameter("@NationalityCode", Id);
            param[index++] = new SqlParameter("@CenterID", IDCenter);
            param[index++] = new SqlParameter("@DocumentType", 2);

            if(MenuTop4ToolStripMenuItem.Checked)
            {
                DataSet ds = new DataSet();
                try
                {
                    ds = da.ExecuteSP("GetCentersDocumentInfo", param);
                    if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                        DocumentDT = ds.Tables[0]; grdDocuments.DataSource = DocumentDT;
                }
                catch
                {
                    var msg = "FillDocument"; MessageForm.Show(msg, "ثبت", MessageFormIcons.Warning, MessageFormButtons.Ok, Properties.Settings.Default.Color);
                }
            }
         
            else if (MenuTop3ToolStripMenuItem.Checked)
            {
                try
                {
                    DataSet ds1 = new DataSet();
                    ds1 = da.ExecuteSP("GetErrorLablatoryDocumentInfo", param);
                    if (ds1 != null && ds1.Tables.Count > 0 && ds1.Tables[0].Rows.Count > 0)
                        DocumentDT = ds1.Tables[0]; grdDocuments.DataSource = DocumentDT;
                }
                catch
                {
                    var msg = "FillDocument"; MessageForm.Show(msg, "ثبت", MessageFormIcons.Warning, MessageFormButtons.Ok, Properties.Settings.Default.Color);
                }

            }
            
            //if (grdDocuments.Rows.Count > 0)
            //grdDocuments.Rows.Clear();// = null;
        
          
            if (grdDocuments.Rows.Count > 0)
            { 
                grdDocuments.Columns["CenterIDSent"].Visible = grdDocuments.Columns["ID"].Visible =
                grdDocuments.Columns["DocumentType"].Visible = false;
                this.grdDocuments.Columns["DateModified"].MinimumWidth = 13; this.grdDocuments.Columns["DateModified"].FillWeight = 13;
                this.grdDocuments.Columns["DateModified"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight; this.grdDocuments.Columns["DateModified"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                  
            // grdDocuments.Columns["image"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            this.grdDocuments.Columns["image"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            grdDocuments.SelectionChanged -= grdDocuments_SelectionChanged;
            grdDocuments.ClearSelection();
            grdDocuments.SelectionChanged += grdDocuments_SelectionChanged;

                grdDocuments.Rows.OfType<DataGridViewRow>().Last().Selected = true;

                grdDocuments.FirstDisplayedScrollingRowIndex = grdDocuments.RowCount - 1;
            }

        }
        static string GetString(byte[] bytes)
        {
            char[] chars = new char[bytes.Length / sizeof(char)];
            System.Buffer.BlockCopy(bytes, 0, chars, 0, bytes.Length - 1);
            return new string(chars);
        }

        private void grdIntermittenc_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            foreach (Control c in tabControl1.TabPages[0].Controls)
            {
                if (c is TextBox)
                { ((TextBox)c).Text = ""; ((TextBox)c).Enabled = false; }
            }
            pictureBox1.Enabled = true;

            if (pictureBox1.Image != null)
            {

                pictureBox1.Image.Dispose();
                pictureBox1.Image = null;
            }
            pictureBox1.Invalidate();
            Byte[] imageData = new Byte[0];
            FillDocumentsGrid();
            if (DocumentDT.Rows.Count > 0)
            {


                imageData = (Byte[])(DocumentDT.Rows[DocumentDT.Rows.Count - 1]["image"]);
                short documentType = Convert.ToInt16(DocumentDT.Rows[DocumentDT.Rows.Count - 1]["DocumentType"]);
                //switch (documentType)
                //{
                //    case 1:
                //        tabControl1.SelectedIndex = documentType - 1;
                //        break;
                //    case 2:
                //        tabControl1.SelectedIndex = documentType - 1;
                //        break;
                //    case 3:
                //        tabControl1.SelectedIndex = documentType - 1;
                //        break;
                //}
                if (imageData != null)
                {
                    MemoryStream stream = new MemoryStream(imageData);
                    pictureBox1.Image = Image.FromStream(stream);
                }
             //   grdDocuments.SelectionChanged -= grdDocuments_SelectionChanged;
             ////   grdDocuments.Rows[0].Selected = true;
             //   grdDocuments.SelectionChanged += grdDocuments_SelectionChanged;
                return;
            }
            else
            {
                if (pictureBox1.Image != null)
                {

                    pictureBox1.Image.Dispose();
                    pictureBox1.Image = null;
                }

                pictureBox1.Invalidate();
                tabControl1.SelectedIndex = 0;
            }
        }

        private void Insert()
        {


            if (grdDocuments.SelectedRows.Count == 0 && grdDocuments.CurrentRow == null)
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
                XmlDocument doc = new XmlDocument();
                string xml = "<labResultList>";
                List<LabResult> labResultList = new List<LabResult>();

            if (MenuTop4ToolStripMenuItem.Checked)
            {
                

                foreach (DataRow row in ControlDT.Rows)// (int i = 0; i < txtTeamNames.Length; i++)
                {
                    TextBox tbx = this.Controls.Find(row["NameLabItem"].ToString(), true).FirstOrDefault() as TextBox;
                    LabResult labResult = new LabResult();
                    // TextBox textBox1 = txtTeamNames.Where(x => Convert.ToInt32(x.Tag) == i).FirstOrDefault();
                    string tmpStr = "";

                    if (tbx.Text != null)
                        tmpStr = tbx.Text;
                    if (tmpStr != string.Empty && tmpStr != "" && tmpStr != null)
                    {
                        labResult.IDdocument = grdDocuments.SelectedRows.Count > 0 ? Convert.ToInt32(grdDocuments.SelectedRows[0].Cells["ID"].Value) : Convert.ToInt32(grdDocuments.CurrentRow.Cells["ID"].Value);
                        labResult.IDItemLab = Convert.ToInt32(((DataRow)tbx.Tag)["IDLabItem"]);// Convert.ToInt32(txtTeamNames[row].Tag);
                        labResult.valueItemLab = tmpStr;
                        labResultList.Add(labResult);
                    }

                }



                if (labResultList != null && labResultList.Count > 0)
                {
                    foreach (LabResult lr in labResultList)
                    {
                        if (lr.IDItemLab != 0 && lr.IDItemLab.ToString() != "")
                            xml += string.Format(@"<labResultList ID=""{0}"" IDDocument=""{1}"" IDItemLab=""{2}"" ValueItemLab=""{3}""",
                                            lr.ID,
                                            lr.IDDocument, lr.IDItemLab, lr.ValueItemLab);

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
                // param[index++] = new SqlParameter("@OverallInsertFieldCount", overallInsertFieldCount);
                param[index++] = new SqlParameter("@TableName", "LabResult");
                result = Convert.ToBoolean(this.da.ExecuteScalarSP("SetLabResultInfo", param));
                if (result)
                {
                    var msg = "ثبت با موفقیت انجام شد"; MessageForm.Show(msg, "ثبت", MessageFormIcons.Info, MessageFormButtons.Ok, Properties.Settings.Default.Color);
                    MenuTop4ToolStripMenuItem_Click(null, null);
                }
                else
                {
                    var msg = "در روند ثبت خطایی رخ داده است."; MessageForm.Show(msg, "ثبت", MessageFormIcons.Warning, MessageFormButtons.Ok, Properties.Settings.Default.Color);
                }
            }
            else if (MenuTop3ToolStripMenuItem.Checked)
            {
                foreach (DataRow row in ControlDT.Rows)// (int i = 0; i < txtTeamNames.Length; i++)
                {
                    TextBox tbx = this.Controls.Find(row["NameLabItem"].ToString(), true).FirstOrDefault() as TextBox;
                    LabResult labResult = new LabResult();
                    // TextBox textBox1 = txtTeamNames.Where(x => Convert.ToInt32(x.Tag) == i).FirstOrDefault();
                    string tmpStr = "";

                    if (tbx.Text != null)
                        tmpStr = tbx.Text;
                    if (tmpStr != string.Empty && tmpStr != "" && tmpStr != null)
                    {
                        labResult.ID =Convert.ToInt32( ((DataRow)tbx.Tag)["ID"]);//  Convert.ToInt32( tbx.Tag);
                        labResult.IDdocument = grdDocuments.SelectedRows.Count > 0 ? Convert.ToInt32(grdDocuments.SelectedRows[0].Cells["ID"].Value) : Convert.ToInt32(grdDocuments.CurrentRow.Cells["ID"].Value);
                        labResult.IDItemLab = Convert.ToInt32(((DataRow)tbx.Tag)["IDItemLab"]);// Convert.ToInt32(txtTeamNames[row].Tag);
                        labResult.SecondValueItemLab = tmpStr;
                        labResultList.Add(labResult);
                    }

                }



                if (labResultList != null && labResultList.Count > 0)
                {
                    foreach (LabResult lr in labResultList)
                    {
                        if (lr.IDItemLab != 0 && lr.IDItemLab.ToString() != "")
                            xml += string.Format(@"<labResultList ID=""{0}"" SecondValueItemLab=""{1}""",
                                            lr.ID,
                                             lr.SecondValueItemLab);

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
                // param[index++] = new SqlParameter("@OverallInsertFieldCount", overallInsertFieldCount);
                param[index++] = new SqlParameter("@TableName", "LabResult");
                result = Convert.ToBoolean(this.da.ExecuteScalarSP("SetErrorLabResultInfo", param));
                if (result)
                {
                    var msg = "ثبت با موفقیت انجام شد"; MessageForm.Show(msg, "ثبت", MessageFormIcons.Info, MessageFormButtons.Ok, Properties.Settings.Default.Color);
                    MenuTop3ToolStripMenuItem_Click(null, null);
                }
                else
                {
                    var msg = "در روند ثبت خطایی رخ داده است."; MessageForm.Show(msg, "ثبت", MessageFormIcons.Warning, MessageFormButtons.Ok, Properties.Settings.Default.Color);
                }
         
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Insert();
            //if (pictureBox1.Image != null)
            //{

            //    pictureBox1.Image.Dispose();
            //    pictureBox1.Image = null;
            //}
            //pictureBox1.Invalidate();
            //if (grdDocuments.Rows.Count > 0)
            //{
            //    grdDocuments.SelectionChanged -= grdDocuments_SelectionChanged;
            //    grdDocuments.Rows.OfType<DataGridViewRow>().Last().Selected = true;

            //    grdDocuments.SelectionChanged += grdDocuments_SelectionChanged;
            //}
        }

        private void btnNextPatiant_Click(object sender, EventArgs e)
        {
            if (grdIntermittenc.Rows.Count == 0) return;
            int currentRow =
           grdIntermittenc.CurrentRow.Index;
            //grdIntermittenc.Rows[currentRow ].Selected = false;
            if (-1 < currentRow + 1 && currentRow + 1 < grdIntermittenc.Rows.Count)
            {
                grdIntermittenc.CurrentCell = grdIntermittenc.Rows[currentRow + 1].Cells[1];
                grdIntermittenc.Rows[currentRow + 1].Selected = true;
                grdIntermittenc_CellClick(null, null);
            }
        }

        private void tabControl1_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (e!= null &&  e.TabPage.Name.ToString() == tabPage2.Name)
            {
                tabPage2.Controls.Add(pictureBox1);
                tabPage2.Controls.SetChildIndex(pictureBox1, 0);
            }
            else
            {
                int i = 0;
                try
                {
                    ControlDT = da.ExecuteCommand("GetLabItems").Tables[0];
                    txtTeamNames = new TextBox[ControlDT.Rows.Count];
                    Label[] LabelTeamNames = new Label[ControlDT.Rows.Count];
                    foreach (DataRow row in ControlDT.Rows)// (int i = 0; i < txtTeamNames.Length; i++)
                    {

                        var lbl = new Label();

                        LabelTeamNames[i] = lbl;
                        lbl.Name = "lbl" + row["NameLabItem"].ToString();
                        lbl.Text = " :" + row["NameLabItem"].ToString();
                        lbl.Location = new Point(panel1.Location.X + 10, panel1.Location.Y + (i * 28));
                        lbl.Visible = true;
                        lbl.AutoSize = true;
                        lbl.Tag = row["NameLabItem"].ToString();
                        var txt = new TextBox();
                        txt.Enabled = true;
                        txtTeamNames[i] = txt;
                        txt.Name = row["NameLabItem"].ToString();
                        txt.Tag = row;
                        txt.Location = new Point(panel1.Location.X + 120, panel1.Location.Y + (i * 28));
                        txt.Visible = true;
                        panel1.Controls.Add(txt);
                        panel1.Controls.Add(lbl);



                        i++;



                    }
                }
                catch
                {
                    var msg = "tabControl1_Selecting"; MessageForm.Show(msg, "ثبت", MessageFormIcons.Warning, MessageFormButtons.Ok, Properties.Settings.Default.Color);
                }
            }
        }
        #region LabREsultInfo
        public class LabResult// اینفوی اطلاعات بیمار
        {
            public string SecondValueItemLab;
            public string valueItemLab;
            public int iDItemLab;
            public bool statusItem;
            public long   id;
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
            public LabResult( int IDdocument,int id, int iDItemLab, string valueItemLab)
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

            public int  IDItemLab
            {
                get { return iDItemLab; }
                set { iDItemLab = value; }
            }

            public string ValueItemLab
            {
                get { return valueItemLab; }
                set { valueItemLab = value; }
            }

            public bool  StatusItem
            {
                get { return statusItem; }
                set { statusItem = value; }
            }
            public long  ID
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
        private void grdDocuments_SelectionChanged(object sender, EventArgs e)
        {
            DataTable  itemsDt = new DataTable();
            if (pictureBox1.Image != null)
            {

                pictureBox1.Image.Dispose();
                pictureBox1.Image = null;
            }
            pictureBox1.Invalidate();
            tabControl1.SelectedIndex = 0;
           
            Byte[] imageData = new Byte[0];
            if (grdDocuments.CurrentRow != null && grdDocuments.CurrentRow.Index >= 0)
            {
                if (grdDocuments.SelectedRows.Count== 0 || grdDocuments.SelectedRows[0].Cells["image"].Value.ToString() == "")
                    return;
                imageData = (Byte[])(grdDocuments.CurrentRow.Cells["image"].Value);
                short documentType = Convert.ToInt16(grdDocuments.CurrentRow.Cells["DocumentType"].Value);
                //switch (documentType)
                //{
                //    case 1:
                //        tabControl1.SelectedIndex = documentType - 1;
                //        break;
                //    case 2:
                //        tabControl1.SelectedIndex = documentType - 1;
                //        break;
                //    case 3:
                //        tabControl1.SelectedIndex = documentType - 1;
                //        break;
                //}
                if (imageData != null)
                {
                    MemoryStream stream = new MemoryStream(imageData);
                    pictureBox1.Image = Image.FromStream(stream);
                }
                //  ((ComboItem)cmbCenters.SelectedValue).m_Value  = Convert.ToInt32(grdDocuments.CurrentRow.Cells["DocumentType"].Value);

                if (grdDocuments.SelectedRows[0].Cells["ID"].Value.ToString() == "")
                    return;

                foreach (Control c in panel1.Controls)// (int i = 0; i < txtTeamNames.Length; i++)
                {
                  if("TextBox"==c.GetType().Name)
                  
                    c.Text = "";

                   
                }
                SqlParameter[] param;
                param = new SqlParameter[1];
                int index = 0;
                param[index++] = new SqlParameter("@IDDocument", Convert.ToInt32(grdDocuments.SelectedRows[0].Cells["ID"].Value));
                try
                {
                    itemsDt = da.ExecuteSP("GetLabItemsByDocumentID", param).Tables[0];
                    if (itemsDt.Rows.Count > 0)
                        FillLabItem(itemsDt);
                }
                catch
                {
                    var msg = " grdDocuments_SelectionChanged"; MessageForm.Show(msg, "ثبت", MessageFormIcons.Warning, MessageFormButtons.Ok, Properties.Settings.Default.Color);
                }

                return;

            }
        }
        private void FillLabItem(DataTable labItemDT)
        
        {
            if (MenuTop3ToolStripMenuItem.Checked)
            foreach (Control c in panel1.Controls)// (int i = 0; i < txtTeamNames.Length; i++)
            {
                if ("TextBox" == c.GetType().Name)

                    c.Enabled = false;


            }
          
            foreach (DataRow row in labItemDT.Rows)// (int i = 0; i < txtTeamNames.Length; i++)
            {
                TextBox tbx = this.Controls.Find(row["NameLabItem"].ToString(), true).FirstOrDefault() as TextBox;
                if (tbx != null)
                {
                    
                    if (MenuTop3ToolStripMenuItem.Checked &&(Convert.ToBoolean( row["StatusItem"]))==false && tbx.Text=="")
                    { tbx.ForeColor = Color.Red; } else tbx.ForeColor = Color.Black;
                     tbx.Text = row["ValueItemLab"].ToString();
                     tbx.Enabled = true;
                     tbx.Tag = row;
                }
               

              

            }
        
        
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            DataTable dtSearch = new DataTable();
      
            DataTable dtSearched = new DataTable();

            if (!(textBox1.Text.Trim() == "" || textBox1.Text == string.Empty) &&   grdIntermittenc.Rows.Count>0)
            {      dtSearch = GridDataSourceDt.Copy();
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
                        dtSearched.ImportRow(row);
                    }
                    FillGrid(dtSearched);
                }

            }
            else
            { FillGrid(GridDataSourceDt); }   
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

        private void MenuTop4ToolStripMenuItem_Click(object sender, EventArgs e)// نسخه آزمایش
        {
            tabControl1.TabPages[1].Show();

            SelectMenuTop(MenuTop4ToolStripMenuItem);
            int index3 = 0;
            if (grdIntermittenc.SelectedRows.Count > 0)
                index3 = grdIntermittenc.SelectedRows[0].Index;
            SqlParameter[] param;
            param = new SqlParameter[1];
            int index = 0;
            param[index++] = new SqlParameter("@IDCenter", IDCenter);

            DataSet dss= new DataSet();


            dss= da.ExecuteSP("GetLabErrorIntermittence", param);
            MenuTop3ToolStripMenuItem.Text = "";
            if (dss != null && dss.Tables.Count > 0 && dss.Tables[0].Rows.Count > 0)
            {
                GridDataSourceDt = dss.Tables[0];
                MenuTop3ToolStripMenuItem.Text = GridDataSourceDt.Rows.Count.ToString() + " " + "خطای آزمایش";
            }
            else MenuTop3ToolStripMenuItem.Text = "0" + " " + "خطای آزمایش";
            dss = new DataSet();
            GridDataSourceDt = new DataTable();
            SqlParameter[] param1;
            param1 = new SqlParameter[2];
            int index1 = 0;   MenuTop4ToolStripMenuItem.Text = "";
            param1[index1++] = new SqlParameter("@IDCenter", IDCenter);
            param1[index1++] = new SqlParameter("@DocumentType", 2); 
            dss= da.ExecuteSP("GetCenetrsIntermittence", param1);
            if (dss != null && dss.Tables.Count > 0 && dss.Tables[0].Rows.Count > 0)
            {
                GridDataSourceDt = dss.Tables[0];
               
       
            //    SelectMenuTop(MenuTop4ToolStripMenuItem);
             
                MenuTop4ToolStripMenuItem.Text = GridDataSourceDt.Rows.Count.ToString() + " " + "نسخه ی آزمایش";
            } else
            MenuTop4ToolStripMenuItem.Text = "0"+ " " + "نسخه ی آزمایش";
             foreach (DataRow row in ControlDT.Rows)// (int i = 0; i < txtTeamNames.Length; i++)
             {
                 TextBox tbx = this.Controls.Find(row["NameLabItem"].ToString(), true).FirstOrDefault() as TextBox;
                 tbx.Text = "";
             }
             if (GridDataSourceDt.Rows.Count > 0)
             {
                 //grdIntermittenc.Rows[0].Selected = true;
              

                 
                 FillGrid(GridDataSourceDt);grdIntermittenc.CellClick -= grdIntermittenc_CellClick;
                 grdIntermittenc.ClearSelection();
                 if (grdIntermittenc.Rows.Count > 0)
                     grdIntermittenc.Rows[0].Selected = false;
                 if (grdIntermittenc.Rows.Count >= index3 + 1)
                     grdIntermittenc.Rows[index3].Selected = true;
                 grdIntermittenc.CellClick += grdIntermittenc_CellClick;   grdIntermittenc_CellClick(null, null);
             }
             else {
                 grdDocuments.SelectionChanged -= grdDocuments_SelectionChanged;
              grdDocuments.DataSource = null;
   
                 grdDocuments.SelectionChanged += grdDocuments_SelectionChanged;
                 if (pictureBox1.Image != null)
                 {
                     pictureBox1.Image.Dispose();
                     pictureBox1.Image = null;
                 }
                 pictureBox1.Invalidate();
             }
             foreach (Control c in panel1.Controls)// (int i = 0; i < txtTeamNames.Length; i++)
             {
                 if ("TextBox" == c.GetType().Name)
                 {
                     c.Enabled = true;
                         c.ForeColor= Color.Black;
                 }

             }
             //if (grdIntermittenc.Rows.Count > 0)
             //    grdIntermittenc.Rows[0].Selected = false;
             //if (grdIntermittenc.Rows.Count >= index3 + 1)
             //    grdIntermittenc.Rows[index3].Selected = true;
        }
        private void SelectMenuTop(ToolStripMenuItem menuItem)//تنظیمات دیزاین منو نمایش بخش ها
        {
           

            MenuTop3ToolStripMenuItem.Checked = false;
            MenuTop4ToolStripMenuItem.Checked = false;
           

            MenuTop3ToolStripMenuItem.BackColor = Color.Transparent;
            MenuTop4ToolStripMenuItem.BackColor = Color.Transparent;
           
            MenuTop3ToolStripMenuItem.ForeColor = Color.Black;
            MenuTop4ToolStripMenuItem.ForeColor = Color.Black;
            menuItem.Checked = true;
            menuItem.BackColor = color;
            menuItem.ForeColor = Color.White;
            menuActiveTop = menuItem;
        }

        private void MenuTop4ToolStripMenuItem_MouseEnter(object sender, EventArgs e)
        {
            Cursor = System.Windows.Forms.Cursors.Hand;//دیزاین
        }

        private void MenuTop4ToolStripMenuItem_MouseLeave(object sender, EventArgs e)
        {
            Cursor = System.Windows.Forms.Cursors.Default;//دیزاین
        }

        private void MenuTop3ToolStripMenuItem_Click(object sender, EventArgs e)// خطای آزمایش 
        {
            tabControl1.TabPages[1].Hide();
            int index3 = 0;
            if (grdIntermittenc.SelectedRows.Count > 0)
                index3 = grdIntermittenc.SelectedRows[0].Index;

            SqlParameter[] param;
            param = new SqlParameter[2];
            int index = 0;
            param[index++] = new SqlParameter("@IDCenter", IDCenter);
            param[index++] = new SqlParameter("@DocumentType", 2);
            DataSet dds = new DataSet();
            dds = da.ExecuteSP("GetCenetrsIntermittence", param);
            if (dds != null && dds.Tables.Count > 0 && dds.Tables[0].Rows.Count > 0)
            {
                GridDataSourceDt = dds.Tables[0];

                MenuTop4ToolStripMenuItem.Text = "";
                MenuTop4ToolStripMenuItem.Text = GridDataSourceDt.Rows.Count.ToString() + " " + "نسخه ی آزمایش";
            }
            else
            {
                MenuTop4ToolStripMenuItem.Text = "";
                MenuTop4ToolStripMenuItem.Text = "0" + " " + "نسخه ی آزمایش";
            }
            GridDataSourceDt = null;SelectMenuTop(MenuTop3ToolStripMenuItem);
            SqlParameter[] param1;
            param1 = new SqlParameter[1];
            int index1 = 0;
            param1[index1++] = new SqlParameter("@IDCenter", IDCenter);
            DataSet ddds = new DataSet();
            ddds = da.ExecuteSP("GetLabErrorIntermittence", param1);
            if (ddds != null && ddds.Tables.Count > 0 && ddds.Tables[0].Rows.Count > 0)
            {
                GridDataSourceDt = ddds.Tables[0];

                MenuTop3ToolStripMenuItem.Text = "";
                MenuTop3ToolStripMenuItem.Text = GridDataSourceDt.Rows.Count.ToString() + " " + "خطای آزمایش";
                grdIntermittenc.CellClick -= grdIntermittenc_CellClick;
                FillGrid(GridDataSourceDt);

                grdIntermittenc.ClearSelection();
                if (grdIntermittenc.Rows.Count > 0)
                    grdIntermittenc.Rows[0].Selected = false;
                if (grdIntermittenc.Rows.Count >= index3 + 1)
                    grdIntermittenc.Rows[index3].Selected = true;
                grdIntermittenc.CellClick += grdIntermittenc_CellClick; grdIntermittenc_CellClick(null, null);
            }
            else
            {


                if (GridDataSourceDt== null ||GridDataSourceDt.Rows.Count == 0)
                {
                    foreach (DataRow row in ControlDT.Rows)// (int i = 0; i < txtTeamNames.Length; i++)
                    {
                        TextBox tbx = this.Controls.Find(row["NameLabItem"].ToString(), true).FirstOrDefault() as TextBox;
                        tbx.Text = "";
                    }
                    smsDt.Rows.Clear();
                    if (grdIntermittenc.Rows.Count > 0)
                        grdIntermittenc.Rows.Clear();
                    if (grdIntermittenc.DataSource != null)

                        smsDt = (DataTable)grdIntermittenc.DataSource;// پاک کردن داده های قبلی گرید

                    DocumentDT.Rows.Clear();//= new DataTable();
                    grdDocuments.DataSource = DocumentDT;
                    return;
                }
                //FillGrid(GridDataSourceDt);
                //FillDocumentsGrid();
                if (grdIntermittenc.Rows.Count > 0)
                {
                    //  grdIntermittenc.Rows[0].Selected = true;
                    grdIntermittenc_CellClick(null, null);
                }
                else
                {
                    grdDocuments.SelectionChanged -= grdDocuments_SelectionChanged;
                    grdDocuments.DataSource = null;

                    grdDocuments.SelectionChanged += grdDocuments_SelectionChanged;
                    if (pictureBox1.Image != null)
                    {
                        pictureBox1.Image.Dispose();
                        pictureBox1.Image = null;
                    }
                    pictureBox1.Invalidate();
                }
            }
        }
        private void button3_MouseEnter(object sender, EventArgs e)
        {
            button3.BackColor = Color.White;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            int oldRowCounts = grdIntermittenc.Rows.Count;
            int newRowCounts = 0;
            int index = 0;
            if (grdIntermittenc.SelectedRows.Count > 0)
                index = grdIntermittenc.SelectedRows[0].Index;
            SqlParameter[] param1;
            param1 = new SqlParameter[2];
            int index1 = 0;
            param1[index1++] = new SqlParameter("@IDCenter", IDCenter);
            param1[index1++] = new SqlParameter("@DocumentType", 2);

            
            MenuTop4ToolStripMenuItem.Text = "";
                DataSet ds = new DataSet(); ds = da.ExecuteSP("GetCenetrsIntermittence", param1);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {  grdIntermittenc.CellClick -= grdIntermittenc_CellClick;
                    MenuTop4ToolStripMenuItem.Text = ds.Tables[0].Rows.Count.ToString() + " " + "نسخه آزمایش";


                    GridDataSourceDt = ds.Tables[0];

                    if
            (MenuTop4ToolStripMenuItem.Checked) { FillGrid(GridDataSourceDt); //SelectMenuTop(MenuTop4ToolStripMenuItem);
                    }
                   // grdIntermittenc.CellClick += grdIntermittenc_CellClick;
                   
                }
                else
                {

                    if
                  (MenuTop4ToolStripMenuItem.Checked)
                    {
                        dt.Rows.Clear();
                        grdIntermittenc.DataSource = dt;
                    }
                  //  grdDocuments.DataSource = null;
                    MenuTop4ToolStripMenuItem.Text = "";
                    MenuTop4ToolStripMenuItem.Text = "0" + " " + "نسخه آزمایش";
                }
            

             if (9==9)
            {
                MenuTop3ToolStripMenuItem.Text = "";
                DataSet ds1 = new DataSet();
                SqlParameter[] param;
                param = new SqlParameter[2];
                int index2 = 0;
                param[index2++] = new SqlParameter("@IDCenter", IDCenter);
                 
                 
                 ds1 = da.ExecuteSP("GetLabErrorIntermittence", param);
                if (ds1 != null && ds.Tables.Count > 0 && ds1.Tables[0].Rows.Count > 0)
                {
                    MenuTop3ToolStripMenuItem.Text = ds1.Tables[0].Rows.Count.ToString() + " " + "خطای آزمایش";

                     grdIntermittenc.CellClick -= grdIntermittenc_CellClick;
                    GridDataSourceDt = ds1.Tables[0];

                    if
                    (MenuTop3ToolStripMenuItem.Checked) { FillGrid(GridDataSourceDt);//SelectMenuTop(MenuTop3ToolStripMenuItem);
                    }
                   
                    

                }
                else
                {

                    if
                   (MenuTop3ToolStripMenuItem.Checked)
                    {
                        dt.Rows.Clear();
                        grdIntermittenc.DataSource = dt;
                    }
                   // grdDocuments.DataSource = null;
                    MenuTop3ToolStripMenuItem.Text = "";
                    MenuTop3ToolStripMenuItem.Text = "0" + " " + "خطای آزمایش";
                } 
            }
            if (grdIntermittenc.Rows.Count > 0)
                        grdIntermittenc.Rows[0].Selected = false;
                    if (grdIntermittenc.Rows.Count >= index + 1)
                        grdIntermittenc.Rows[index].Selected = true;
            
            grdIntermittenc.CellClick += grdIntermittenc_CellClick;

            newRowCounts = grdIntermittenc.Rows.Count;
            if (newRowCounts > oldRowCounts)
            { System.Media.SystemSounds.Asterisk.Play(); }
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
      
    }
}
