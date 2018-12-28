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
    public partial class DrugStore : Form
    {
        #region Variables
        private PictureBox pictureBox1 = new PictureBox();
        private DateTime timeStamp;//SqlBinary
        private DateTime lastTimeStamp;//SqlBinary

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
        private string Id;
        private int IDCenter;
        private string serial = "1401461905819145";
        private Color color;
        private TextBox[] txtTeamNames = new TextBox[1];
        public DataTable GridDataSourceDt;
        private bool IntOrChar;
        #endregion

        public DrugStore()
        {
            InitializeComponent();
            SetColor();
            SelectMenuTop(MenuTop4ToolStripMenuItem);
            tabControl1.TabPages[0].Controls.Add(pictureBox1);
           
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
        private void DrugStore_Load(object sender, EventArgs e)
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
          //Lock();
           this.Hide();
            ConnectionString logon = new ConnectionString();
               WindowState = FormWindowState.Maximized;
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
            DataSet result= new DataSet(); result = (da.ExecuteSP("GetSerial", param));

            //if (result == null || result.Tables.Count == 0 || result.Tables[0].Rows.Count == 0 || result.Tables[0].Columns.Count == 0)
            //{
            //    var msg = "شناسایی مرکز ناموفق است."; MessageForm.Show(msg, "خطای اطلاعات مرکز", MessageFormIcons.Warning, MessageFormButtons.Ok, color);
            //}
            //else
            //{
             IDCenter = 9;
                //   IDCenter = Convert.ToInt32(result.Tables[0].Rows[0]["IDCenters"]); this.Text += " " + result.Tables[0].Rows[0]["NameCenters"].ToString();
           // }


         
            GridSet();
            GridDocumentsSet();
            WindowState = FormWindowState.Maximized;
            SqlParameter[] param1;
            param1 = new SqlParameter[2];
            int index1 = 0;
            param1[index1++] = new SqlParameter("@IDCenter", IDCenter);
            param1[index1++] = new SqlParameter("@DocumentType",1);DataSet ssd= new DataSet();
            ssd=  da.ExecuteSP("GetCenetrsIntermittence", param1); setLook();
            if (ssd != null && ssd.Tables.Count > 0 && ssd.Tables[0].Rows.Count > 0)
            {
                GridDataSourceDt = ssd.Tables[0];
                FillGrid(GridDataSourceDt);


                MenuTop4ToolStripMenuItem_Click(null, null);
                grdIntermittenc_CellClick(null, null);

                grdDocuments.Rows.OfType<DataGridViewRow>().Last().Selected = true;
                timer1.Start();
            }
            else { timer1.Start(); MenuTop4ToolStripMenuItem.Text = "0" + " " + "نسخه دارو"; }
           
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
                    serial = usb.getSerialNumberFromDriveLetter("j:");
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
        private void setLook()
        {
            pictureBox1.Size = tabPage1.Size;

            tabControl1.Visible = true;
            drawing = new Bitmap(pictureBox1.Width, pictureBox1.Height, pictureBox1.CreateGraphics());
            Graphics.FromImage(drawing).Clear(Color.White);
            tabControl1.TabPages[0].Controls.Add(pictureBox1);
         
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
            //grdDocuments.RowsDefaultCellStyle.SelectionBackColor = ControlPaint.LightLight(color);
            //grdDocuments.AlternatingRowsDefaultCellStyle.BackColor = ControlPaint.LightLight(ControlPaint.LightLight(ControlPaint.LightLight(ControlPaint.LightLight(color))));
            grdIntermittenc.ColumnHeadersDefaultCellStyle.BackColor = color;
            grdIntermittenc.RowsDefaultCellStyle.SelectionBackColor = ControlPaint.LightLight(color);
            grdIntermittenc.AlternatingRowsDefaultCellStyle.BackColor = ControlPaint.LightLight(ControlPaint.LightLight(ControlPaint.LightLight(ControlPaint.LightLight(color))));

        }

        private void GridSet()// 
        {

            dt = new DataTable();
           
            dt.Columns.Add(IDIntermittence.Name);//
            dt.Columns.Add(CodeCol.Name);//
            dt.Columns.Add(CustomerCol.Name);//
            dt.Columns.Add(DateModified.Name);// 
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


            DataGridViewTextBoxColumn IDDrugStoreReply = new DataGridViewTextBoxColumn();
            IDDrugStoreReply.Name = "IDDrugStoreReply";
            IDDrugStoreReply.HeaderText = "IDDrugStoreReply";
            IDDrugStoreReply.Visible = false;
            IDDrugStoreReply.Width = 5;
            IDDrugStoreReply.DataPropertyName = "IDDrugStoreReply";

            DataGridViewTextBoxColumn DateModified = new DataGridViewTextBoxColumn();
            DateModified.Name = "DateModified";
            DateModified.HeaderText = "DateModified";
            DateModified.Visible = false;
            DateModified.Width = 5;
            DateModified.DataPropertyName = "DateModified";
            
            grdDocuments.DataSource = dtDoc;


        }

        private void FillGrid(DataTable GridDataSourceDS )
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
                dr["IDIntermittence"] = (row["ID"]);
                dr["CodeCol"] = row["NationalityCode"];
                dr["CustomerCol"] = row["Name"];
                Int32 index = grdIntermittenc.Rows.Count - 1;
                //grdIntermittenc.Rows[index].Tag = row;


            }
            grdIntermittenc.DataSource = smsDt;
            grdIntermittenc.Columns["IDIntermittence"].Visible = false;// در هر حالتی ستون آی دی نمایش داده نشود
            this.grdIntermittenc.Columns["CustomerCol"].DefaultCellStyle.Alignment = this.grdIntermittenc.Columns["CodeCol"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            if (grdIntermittenc.Rows.Count > 0)
                grdIntermittenc.Rows[0].Selected = true;

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
            if (grdIntermittenc.CurrentRow != null)
                Id = (grdIntermittenc.CurrentRow.Cells[1].Value).ToString();
            if (Id == "0")
            { Id = (grdIntermittenc.Rows[0].Cells[1].Value).ToString(); }
            SqlParameter[] param;
            param = new SqlParameter[3];
            int index = 0;
            param[index++] = new SqlParameter("@NationalityCode", Id);
            param[index++] = new SqlParameter("@CenterID", IDCenter);
            param[index++] = new SqlParameter("@DocumentType", 1);
            DataSet dds = new DataSet(); dds = da.ExecuteSP("GetCentersDocumentInfo", param);
            if (dds == null || dds.Tables.Count == 0 || dds.Tables[0].Rows.Count == 0) return;
            {
                DocumentDT =dds.Tables[0];

                //if (grdDocuments.Rows.Count > 0)
                //grdDocuments.Rows.Clear();// = null;
                grdDocuments.SelectionChanged -= grdDocuments_SelectionChanged;
                grdDocuments.DataSource = DocumentDT;
            
            grdDocuments.SelectionChanged += grdDocuments_SelectionChanged;
            if (grdDocuments.Rows.Count > 0)
            {
            grdDocuments.Columns["CenterIDSent"].Visible = grdDocuments.Columns["ID"].Visible =
            grdDocuments.Columns["DocumentType"].Visible = false;
            grdDocuments.Columns["IDDrugStoreReply"].Visible = false; this.grdDocuments.Columns["DateModified"].MinimumWidth = 13; this.grdDocuments.Columns["DateModified"].FillWeight = 13;
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

        }  
        private void SelectMenuTop(ToolStripMenuItem menuItem)//تنظیمات دیزاین منو نمایش بخش ها
        {
            MenuTop4ToolStripMenuItem.Checked = false;
            MenuTop4ToolStripMenuItem.BackColor = Color.Transparent;
            MenuTop4ToolStripMenuItem.ForeColor = Color.Black;
            menuItem.Checked = true;
            menuItem.BackColor = color;
            menuItem.ForeColor = Color.White;
            menuActiveTop = menuItem;
        }
        static string GetString(byte[] bytes)
        {
            char[] chars = new char[bytes.Length / sizeof(char)];
            System.Buffer.BlockCopy(bytes, 0, chars, 0, bytes.Length - 1);
            return new string(chars);
        }  
        private void Insert(bool havingStatus)
        {
            int iddo;
            SqlParameter[] param;
            param = new SqlParameter[5];
            int index = 0;
            if (grdDocuments.CurrentRow == null && grdDocuments.SelectedRows.Count==0)
                return;
            if (grdDocuments.SelectedRows.Count != 0)
                iddo = Convert.ToInt32(grdDocuments.SelectedRows[0].Cells["IDDrugStoreReply"].Value);
            else if (grdDocuments.CurrentRow != null)
            { iddo = Convert.ToInt32(grdDocuments.CurrentRow.Cells["IDDrugStoreReply"].Value); }
            else return;
            param[index++] = new SqlParameter("@IDDrugStoreReply",   iddo);
            param[index++] = new SqlParameter("@IDDocument",Convert.ToInt32( grdDocuments.CurrentRow.Cells["ID"].Value));
            param[index++] = new SqlParameter("@HavingReply",havingStatus );
            param[index++] = new SqlParameter("@DateReply", DateTime.Now);
            param[index++] = new SqlParameter("@IDCenter", IDCenter);
            if (Convert.ToInt32(da.ExecuteScalarSP("SetDrugStoreReply", param)) == 1)
            {
                var msg = "ثبت با موفقیت انجام شد"; MessageForm.Show(msg, "ثبت", MessageFormIcons.Info, MessageFormButtons.Ok, Properties.Settings.Default.Color);
                FillDocumentsGrid();
                if (MenuTop4ToolStripMenuItem.Checked == true)
                    MenuTop4ToolStripMenuItem_Click(null, null);


            }
            else
            {
                var msg = "در روند ثبت خطایی رخ داده است."; MessageForm.Show(msg, "ثبت", MessageFormIcons.Warning, MessageFormButtons.Ok, Properties.Settings.Default.Color);

                
            }
        }

        private void grdIntermittenc_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            foreach (DataRow row in ControlDT.Rows)// (int i = 0; i < txtTeamNames.Length; i++)
            {
                TextBox tbx = this.Controls.Find(row["NameLabItem"].ToString(), true).FirstOrDefault() as TextBox;
                tbx.Text = "";
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
      

        private void MenuTop4ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            //int i = grdIntermittenc.Rows[0].Selected = true;
            MenuTop4ToolStripMenuItem.Text = "";
            SqlParameter[] param1;
            param1 = new SqlParameter[2];
            int index1 = 0;
            param1[index1++] = new SqlParameter("@IDCenter", IDCenter);
            param1[index1++] = new SqlParameter("@DocumentType", 1);
            DataSet dsg = new DataSet(); dsg = da.ExecuteSP("GetCenetrsIntermittence", param1);
            if (dsg != null && dsg != new DataSet() && dsg.Tables.Count > 0 && dsg.Tables[0].Rows.Count > 0)
            {
                GridDataSourceDt = dsg.Tables[0];//همه نسخه ها ی مربوط به این داروخانه را می آورد چه امروز چه فردا و انایی که منشی بهش سند کره را ن ه 
                FillGrid(GridDataSourceDt);
                if (grdIntermittenc.Rows.Count > 0)
                {
                    grdIntermittenc.Rows[0].Selected = true;
                    grdIntermittenc_CellClick(null, null);
                }
                MenuTop4ToolStripMenuItem.Text = GridDataSourceDt.Rows.Count.ToString() + " " + "نسخه ی دارو";
            }
            else
            {
                grdIntermittenc.SelectionChanged -= grdDocuments_SelectionChanged;
                smsDt.Rows.Clear();grdIntermittenc.SelectionChanged += grdDocuments_SelectionChanged;
                grdIntermittenc.DataSource= smsDt;
                
                MenuTop4ToolStripMenuItem.Text = "0" + " " + "نسخه ی دارو"; }
            SelectMenuTop(MenuTop4ToolStripMenuItem);
           
        

            if (grdIntermittenc.Rows.Count > 0)
            {
                grdIntermittenc.Rows[0].Selected = true;
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

        private void button1_Click(object sender, EventArgs e)
        {
            Insert(true);
        }
 
        private void btnNextPatiant_Click(object sender, EventArgs e)
        {
            Insert(false);
        }

        private void grdDocuments_SelectionChanged(object sender, EventArgs e)
        {
            DataTable itemsDt = new DataTable();
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
                if (grdDocuments.CurrentRow.Cells["image"].Value.ToString() == "")
                    return;
                imageData = (Byte[])(grdDocuments.CurrentRow.Cells["image"].Value);
                short documentType = Convert.ToInt16(grdDocuments.CurrentRow.Cells["DocumentType"].Value);
                
                if (imageData != null)
                {
                    MemoryStream stream = new MemoryStream(imageData);
                    pictureBox1.Image = Image.FromStream(stream);
                }
             


            }
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            DataTable dtSearch = new DataTable();
            
            DataTable dtSearched = new DataTable();

            if (!(textBox1.Text.Trim() == "" || textBox1.Text == string.Empty) && grdIntermittenc.Rows.Count > 0)
            {dtSearch = GridDataSourceDt.Copy();
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
            param1[index1++] = new SqlParameter("@DocumentType",1);
            DataSet ds1 = new DataSet();
            ds1 = da.ExecuteSP("GetCenetrsIntermittence", param1); MenuTop4ToolStripMenuItem.Text = "";
            if (ds1 != null && ds1.Tables.Count > 0 && ds1.Tables[0].Rows.Count > 0)
            {
                GridDataSourceDt = ds1.Tables[0];
                grdIntermittenc.CellClick -= grdIntermittenc_CellClick;
                FillGrid(GridDataSourceDt);
                {

                    MenuTop4ToolStripMenuItem.Text = GridDataSourceDt.Rows.Count.ToString() + " " + "نسخه دارو";

                }
                grdIntermittenc.CellClick += grdIntermittenc_CellClick;
                if (grdIntermittenc.Rows.Count > 0)
                    grdIntermittenc.Rows[0].Selected = false;
                if (grdIntermittenc.Rows.Count >= index + 1)
                    grdIntermittenc.Rows[index].Selected = true;
            }
            else
            {
              smsDt.Rows.Clear();
              grdIntermittenc.DataSource = smsDt;
                grdDocuments.DataSource = null;
                MenuTop4ToolStripMenuItem.Text = "";
                MenuTop4ToolStripMenuItem.Text = "0" + " " + "نسخه دارو";
            }

            newRowCounts = grdIntermittenc.Rows.Count;
            if (newRowCounts > oldRowCounts)
            { System.Media.SystemSounds.Asterisk.Play(); }
        }

        
    }
}
