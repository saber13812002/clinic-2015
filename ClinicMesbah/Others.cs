using MesbahComponent;
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
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Xml;
using USBDriveSerialNumber;
using ImageThumbnailDataGridView;
using System.Drawing.Imaging;
using Microsoft.Win32;
using System.Threading;

namespace ClinicMesbah
{
       
    public partial class Others : Form
    {
        #region Variables
        private PictureBox pictureBox1 = new PictureBox();
        private List<string> _files = null;
        private int _numberPreviewImages = 100;
        private int _imageSize = 50;
        private int _currentStartImageIndex = 0;
        private int _currentEndImageIndex = 0; private DateTime timeStamp;//SqlBinary
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
        private string serial = "000000000207";
        private Color color; int i = 1; 
        private TextBox[] txtTeamNames = new TextBox[1];
        public DataTable GridDataSourceDt;
        private bool IntOrChar;
        private string path;
        #endregion
        public Others()
        {
            InitializeComponent();
            SetColor();
            SelectMenuTop(MenuTop4ToolStripMenuItem);
            tabControl1.TabPages[1].Controls.Add(pictureBox1);
            
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
        private void Others_Load(object sender, EventArgs e)
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
         //   Lock();
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
            //if (result == null || result.Tables.Count == 0 || result.Tables[0].Rows.Count == 0 || result.Tables[0].Columns.Count==0)
            //{
            //    var msg = "شناسایی مرکز ناموفق است."; MessageForm.Show(msg, "خطای اطلاعات مرکز", MessageFormIcons.Warning, MessageFormButtons.Ok, color);
            //}
            //else
            //{
           IDCenter = 23;
            //IDCenter = Convert.ToInt32(result.Tables[0].Rows[0]["IDCenters"]); this.Text += " " + result.Tables[0].Rows[0]["NameCenters"].ToString();
            //}



          
            GridSet();
            GridDocumentsSet();
            WindowState = FormWindowState.Maximized;
            SqlParameter[] param1;
            param1 = new SqlParameter[2];
            int index1 = 0;
            param1[index1++] = new SqlParameter("@IDCenter", IDCenter);
            param1[index1++] = new SqlParameter("@DocumentType", 1);
            DataSet dss = new DataSet(); dss = da.ExecuteSP("GetCenetrsIntermittence", param1);
            if (dss != null && dss.Tables.Count > 0 && dss.Tables[0].Rows.Count > 0)
            {
                GridDataSourceDt = dss.Tables[0];
                FillGrid(GridDataSourceDt);
            }
            setLook();
            MenuTop4ToolStripMenuItem_Click(null, null);
            grdIntermittenc_CellClick(null, null);
            timer1.Enabled = true;
            timer1.Start();
     
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
        private void setLook()
        {
            pictureBox1.Size = tabPage1.Size;

            tabControl1.Visible = true;
            drawing = new Bitmap(pictureBox1.Width, pictureBox1.Height, pictureBox1.CreateGraphics());
            Graphics.FromImage(drawing).Clear(Color.White);
            tabControl1.TabPages[1].Controls.Add(pictureBox1);
            WindowState = FormWindowState.Maximized;
            color = Properties.Settings.Default.Color;
            // grdDocuments.BackgroundColor = ControlPaint.LightLight(ControlPaint.LightLight(ControlPaint.LightLight(ControlPaint.LightLight(color))));
            pictureBox1.Enabled = false;


        }

        private void SetColor()
        {
           
            color = Properties.Settings.Default.Color;
            SendSMSPanelWithBorder.BorderColor = color;
            button1.BackColor = color; btnSave.BackColor= color;
            btnNextPatiant.BackColor = color;
            //grdDocuments.ColumnHeadersDefaultCellStyle.BackColor = color;
            grdDocuments.RowsDefaultCellStyle.SelectionBackColor = ControlPaint.LightLight(color);
            //grdDocuments.AlternatingRowsDefaultCellStyle.BackColor = ControlPaint.LightLight(ControlPaint.LightLight(ControlPaint.LightLight(ControlPaint.LightLight(color))));
            grdIntermittenc.ColumnHeadersDefaultCellStyle.BackColor = color;
            grdIntermittenc.RowsDefaultCellStyle.SelectionBackColor = ControlPaint.LightLight(color);
            grdIntermittenc.AlternatingRowsDefaultCellStyle.BackColor = ControlPaint.LightLight(ControlPaint.LightLight(ControlPaint.LightLight(ControlPaint.LightLight(color))));
            dataViewImages.BackgroundColor = ControlPaint.LightLight(ControlPaint.LightLight((ControlPaint.LightLight(color))));
            dataViewImages.RowsDefaultCellStyle.SelectionBackColor = ControlPaint.LightLight(color);
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
            imgColumn.ImageLayout = DataGridViewImageCellLayout.Stretch;
            DataGridViewTextBoxColumn CenterIDSent = new DataGridViewTextBoxColumn();
            CenterIDSent.Name = "CenterIDSent";
            CenterIDSent.HeaderText = "CenterIDSent";
            CenterIDSent.Visible = false;
            CenterIDSent.Width = 5;
            CenterIDSent.DataPropertyName = "CenterIDSent";


            //DataGridViewTextBoxColumn IDDrugStoreReply = new DataGridViewTextBoxColumn();
            //IDDrugStoreReply.Name = "IDDrugStoreReply";
            //IDDrugStoreReply.HeaderText = "IDDrugStoreReply";
            //IDDrugStoreReply.Visible = false;
            //IDDrugStoreReply.Width = 5;
            //IDDrugStoreReply.DataPropertyName = "IDDrugStoreReply";

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
               // dr["IDIntermittence"] = (row["ID"]);
                dr["CodeCol"] = row["NationalityCode"];
                dr["CustomerCol"] = row["Name"];
                Int32 index = grdIntermittenc.Rows.Count - 1;
                //grdIntermittenc.Rows[index].Tag = row;


            }
            grdIntermittenc.DataSource = smsDt;
         //   grdIntermittenc.Columns["IDIntermittence"].Visible = false;// در هر حالتی ستون آی دی نمایش داده نشود
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
            param[index++] = new SqlParameter("@DocumentType", 3);
            bool isAtleatAFile = false;
            DataSet dss = new DataSet();
            dss= da.ExecuteSP("GetCentersDocumentInfo", param);
            if (dss != null && dss.Tables.Count > 0 && dss.Tables[0].Rows.Count > 0)
            {
                DocumentDT = dss.Tables[0];

                //if (grdDocuments.Rows.Count > 0)
                //grdDocuments.Rows.Clear();// = null;
                grdDocuments.SelectionChanged -= grdDocuments_SelectionChanged;
                if (DocumentDT.Rows.Count != 0)
              foreach(DataRow row in DocumentDT.Rows)
              {
                  path = Path.GetDirectoryName(Application.ExecutablePath) + @"\Docs" + @"\" + (row["ID"]).ToString();

                  if (Directory.Exists(path))
                  {
                      foreach (var path1 in Directory.GetFiles(path))
                      {
                          FileInfo fi = new FileInfo(path1);
                          string text = fi.Name;
                          if (text != "Thumbs.db")
                          isAtleatAFile = true;
                      }
                      if (isAtleatAFile)
                      row.Delete();  
                      
                      // if (DocumentDT.Rows.Count == 0) break;
                  }

            }
                DocumentDT.AcceptChanges();
                grdDocuments.DataSource = DocumentDT;
              
                grdDocuments.Columns["CenterIDSent"].Visible = grdDocuments.Columns["ID"].Visible =
                grdDocuments.Columns["DocumentType"].Visible = false;
                this.grdDocuments.Columns["DateModified"].MinimumWidth = 13; this.grdDocuments.Columns["DateModified"].FillWeight = 13;
                this.grdDocuments.Columns["DateModified"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight; this.grdDocuments.Columns["DateModified"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                  
                // grdDocuments.Columns["image"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                this.grdDocuments.Columns["image"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                if (DocumentDT.Rows.Count == 0) return;
               
                
                grdDocuments.SelectionChanged += grdDocuments_SelectionChanged;
                grdDocuments.Rows.OfType<DataGridViewRow>().Last().Selected = true;
                //grdDocuments.Rows[grdDocuments.Rows.Count-1].Selected=true;
                int i = grdDocuments.Rows.Count - 1;
                grdDocuments.CurrentCell = grdDocuments.Rows[i].Cells[0];
                grdDocuments.FirstDisplayedScrollingRowIndex = grdDocuments.RowCount - 1; 
               
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


        //private void LoadImages()
        //{
        //    try
        //    {
        //        if (_files == null)
        //        {
        //            return;
        //        }

        //        if (this.WindowState == FormWindowState.Minimized)
        //        {
        //            return;
        //        }

        //        dataViewImages.Rows.Clear();
        //        dataViewImages.Columns.Clear();

        //        int numColumnsForWidth = (dataViewImages.Width - 10) / (_imageSize + 20);
        //        int numRows = 0;

        //        int numImagesRequired = 0;

        //        if (_currentEndImageIndex > _files.Count)
        //        {
        //            // Are we requesting to display more images than we actually have? If so then reduce
        //            if (_currentStartImageIndex == 0)
        //            {
        //                numImagesRequired = _files.Count;
        //            }
        //            else
        //            {
        //                numImagesRequired = (_currentEndImageIndex - _currentStartImageIndex) - (_currentEndImageIndex - _files.Count);
        //            }
        //        }
        //        else
        //        {
        //            // Calculated the number of rows we will need for normal use
        //            numImagesRequired = _currentEndImageIndex - _currentStartImageIndex;
        //        }

        //        numRows = numImagesRequired / numColumnsForWidth;

        //        // Do we have a an overfill for a row
        //        if (numImagesRequired % numColumnsForWidth > 0)
        //        {
        //            numRows += 1;
        //        }

        //        // Catch when we have less images than the maximum number of columns for the DataGridView width
        //        if (numImagesRequired < numColumnsForWidth)
        //        {
        //            numColumnsForWidth = numImagesRequired;
        //        }

        //        int numGeneratedCells = numRows * numColumnsForWidth;

        //        // Dynamically create the columns
        //        for (int index = 0; index < numColumnsForWidth; index++)
        //        {
        //            DataGridViewImageColumn image = new DataGridViewImageColumn();
        //            dataViewImages.Columns.Add(image);

        //            dataViewImages.Columns[index].Width = _imageSize + 20;

        //            DataGridViewTextBoxColumn IDRadiologyImage = new DataGridViewTextBoxColumn();
        //            IDRadiologyImage.Visible = false;
        //            dataViewImages.Columns.Add(IDRadiologyImage);



                   
        //        }

        //        // Create the rows
        //        for (int index = 0; index < numRows; index++)
        //        {
        //            dataViewImages.Rows.Add();
        //            dataViewImages.Rows[index].Height = _imageSize + 20;
        //        }



        //        int columnIndex = 0;// dataViewImages.Columns.Count >2 ? dataViewImages.Columns.Count : 0;
        //        int rowIndex = 0;// dataViewImages.Rows.Count > 2 ? dataViewImages.Rows.Count - 1 : 0;

        //        for (int index = _currentStartImageIndex; index < _currentStartImageIndex + numImagesRequired; index++)
        //        {
        //            // Load the image from the file and add to the DataGridView
                   
        //            Image image = Helper.ResizeImage(_files[index], _imageSize, _imageSize, false);
        //            dataViewImages.Rows[rowIndex].Cells[columnIndex].Value = image;
        //            dataViewImages.Rows[rowIndex].Cells[columnIndex].ToolTipText = Path.GetFileName(_files[index]);

        //            // Have we reached the end column? if so then start on the next row
        //            if (columnIndex == numColumnsForWidth - 1)
        //            {
        //                rowIndex++;
        //                columnIndex = 0;
        //            }
        //            else
        //            {
        //                columnIndex++;
        //            }
        //        }

        //        // Blank the unused cells
        //        if (numGeneratedCells > numImagesRequired)
        //        {
        //            for (int index = 0; index < numGeneratedCells - numImagesRequired; index++)
        //            {
        //                DataGridViewCellStyle dataGridViewCellStyle = new DataGridViewCellStyle();
        //                dataGridViewCellStyle.NullValue = null;
        //                dataGridViewCellStyle.Tag = "BLANK";
        //                dataViewImages.Rows[rowIndex].Cells[columnIndex + index].Style = dataGridViewCellStyle;
        //            }
        //        }

        //        //if (_currentStartImageIndex == 0)
        //        //{
        //        //    btnPreviousImages.Enabled = false;
        //        //}
        //        //else
        //        //{
        //        //    btnPreviousImages.Enabled = true;
        //        //}

        //        //if (_currentEndImageIndex < _files.Count)
        //        //{
        //        //    btnNextImages.Enabled = true;
        //        //}
        //        //else
        //        //{
        //        //    btnNextImages.Enabled = false;
        //        //}
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex);
        //    }
        //}
        private void LoadImages()
        {
            try
            {
                if (_files == null)
                {
                    return;
                }

                if (this.WindowState == FormWindowState.Minimized)
                {
                    return;
                }

                dataViewImages.Rows.Clear();
                dataViewImages.Columns.Clear();

                int numColumnsForWidth = (dataViewImages.Width - 10) / (_imageSize + 20);
                int numRows = 0;

                int numImagesRequired = 0;

                if (_currentEndImageIndex > _files.Count)
                {
                    // Are we requesting to display more images than we actually have? If so then reduce
                    if (_currentStartImageIndex == 0)
                    {
                        numImagesRequired = _files.Count;
                    }
                    else
                    {
                        numImagesRequired = (_currentEndImageIndex - _currentStartImageIndex) - (_currentEndImageIndex - _files.Count);
                    }
                }
                else
                {
                    // Calculated the number of rows we will need for normal use
                    numImagesRequired = _currentEndImageIndex - _currentStartImageIndex;
                }

                numRows = numImagesRequired / numColumnsForWidth;

                // Do we have a an overfill for a row
                if (numImagesRequired % numColumnsForWidth > 0)
                {
                    numRows += 1;
                }

                // Catch when we have less images than the maximum number of columns for the DataGridView width
                if (numImagesRequired < numColumnsForWidth)
                {
                    numColumnsForWidth = numImagesRequired;
                }

                int numGeneratedCells = numRows * numColumnsForWidth;

                // Dynamically create the columns
                for (int index = 0; index < numColumnsForWidth; index++)
                {
                    DataGridViewImageColumn dataGridViewColumn = new DataGridViewImageColumn();

                    dataViewImages.Columns.Add(dataGridViewColumn);
                    dataViewImages.Columns[index].Width = _imageSize + 20;
                }

                // Create the rows
                for (int index = 0; index < numRows; index++)
                {
                    dataViewImages.Rows.Add();
                    dataViewImages.Rows[index].Height = _imageSize + 20;
                }

                int columnIndex = 0;
                int rowIndex = 0;

                for (int index = _currentStartImageIndex; index < _currentStartImageIndex + numImagesRequired; index++)
                {
                    // Load the image from the file and add to the DataGridView
                    Image image = Helper.ResizeImage(_files[index], _imageSize, _imageSize, false);
                    dataViewImages.Rows[rowIndex].Cells[columnIndex].Value = image;
                    dataViewImages.Rows[rowIndex].Cells[columnIndex].ToolTipText = Path.GetFileName(_files[index]);

                    // Have we reached the end column? if so then start on the next row
                    if (columnIndex == numColumnsForWidth - 1)
                    {
                        rowIndex++;
                        columnIndex = 0;
                    }
                    else
                    {
                        columnIndex++;
                    }
                }

                // Blank the unused cells
                if (numGeneratedCells > numImagesRequired)
                {
                    for (int index = 0; index < numGeneratedCells - numImagesRequired; index++)
                    {
                        DataGridViewCellStyle dataGridViewCellStyle = new DataGridViewCellStyle();
                        dataGridViewCellStyle.NullValue = null;
                        dataGridViewCellStyle.Tag = "BLANK";
                        dataViewImages.Rows[rowIndex].Cells[columnIndex + index].Style = dataGridViewCellStyle;
                    }
                }

                //if (_currentStartImageIndex == 0)
                //{
                //    btnPreviousImages.Enabled = false;
                //}
                //else
                //{
                //    btnPreviousImages.Enabled = true;
                //}

                //if (_currentEndImageIndex < _files.Count)
                //{
                //    btnNextImages.Enabled = true;
                //}
                //else
                //{
                //    btnNextImages.Enabled = false;
                //}
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        #region RadiologyImagesInfo
        public class RadiologyImages// اینفوی اطلاعات بیمار
        {
            public byte[]  image;
            public string ImageDescription;
            public long id;
            public int IDdocument;
            public DateTime creationDate;
            public int iDCenter;
            public RadiologyImages()
            { }
            public RadiologyImages(byte[] image, string ImageDescription, DateTime creationDate, long id, int IDdocument, int iDCenter)
            {
                this.ImageDescription = ImageDescription;
                this.creationDate = creationDate;
                this.image = image;
                this.id = id;
                this.IDdocument = IDdocument;
                this.iDCenter = iDCenter;
            }


            public byte[] Image
            {
                get { return image; }
                set { image = value; }
            }

            public DateTime CreationDate
            {
                get { return creationDate; }
                set { creationDate = value; }
            }

            public string IMageDescription
            {
                get { return ImageDescription; }
                set { ImageDescription = value; }
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
            public int IDCenter
            {
                get { return iDCenter; }
                set { iDCenter = value; }
            }

        }
        #endregion
        private void Insert()
        {

           if (grdDocuments.CurrentRow == null) return;
            XmlDocument doc = new XmlDocument();
            string xml = "<RadiologyImages>";
            List<RadiologyImages> RadiologyImages = new List<RadiologyImages>();
            ImageConverter converter = new ImageConverter();
 
            foreach (DataGridViewRow row in dataViewImages.Rows)// (int i = 0; i < txtTeamNames.Length; i++)
            {
                
                foreach (DataGridViewCell cell in row.Cells)
                {
                    
                        //DO your Stuff here..

                        RadiologyImages RadiologyImage = new RadiologyImages();

                        Image img = cell.Value as Image;
                        byte[] buf = null;
                        if (img != null)
                        {
                            using (MemoryStream s = new MemoryStream())
                            {
                                img.Save(s, ImageFormat.Png);
                                buf = s.ToArray();
                            }
                        }


                        RadiologyImage.image = buf;
                        RadiologyImage.IDCenter = IDCenter;
                        RadiologyImage.ID = Convert.ToInt32(dataViewImages.CurrentRow.Tag) == 0 ? 0 : Convert.ToInt32(dataViewImages.CurrentRow.Tag);
                        RadiologyImage.IDdocument = Convert.ToInt32(grdDocuments.CurrentRow.Cells["ID"].Value);
                        RadiologyImage.CreationDate = DateTime.Now;// Convert.ToInt32(txtTeamNames[row].Tag);
                        RadiologyImage.IMageDescription = "";
                        RadiologyImages.Add(RadiologyImage);
                    
                }
            }

          



            if (RadiologyImages != null && RadiologyImages.Count > 0)
            {
                foreach (RadiologyImages lr in RadiologyImages)
                {

                    xml += string.Format(@"<RadiologyImages IDRadiologyResult=""{0}"" IDDocument=""{1}"" IDCenter=""{2}"" ImageDescription=""{3}"" DateCreation=""{4}"" ImageRadiology=""{5}""",
                                        lr.ID,
                                        lr.IDDocument,
                                        lr.IDCenter,
                                        lr.IMageDescription,
                                        lr.CreationDate,
                                      (lr.Image));

                    xml += "  />";
                }
            }

            xml += "</RadiologyImages>";
            doc.InnerXml = xml;


            SqlParameter[] param;
            param = new SqlParameter[3];
            bool result;
            int index = 0;

            if (!String.IsNullOrEmpty(xml))
                param[index++] = new SqlParameter("@XmlDocument", xml);
            // param[index++] = new SqlParameter("@OverallInsertFieldCount", overallInsertFieldCount);
            param[index++] = new SqlParameter("@TableName", "RadiologyResult");
            result = Convert.ToBoolean(this.da.ExecuteScalarSP("SetRadiologyImagesInfo", param));
            if (result)
            {
                var msg = "ثبت با موفقیت انجام شد"; MessageForm.Show(msg, "ثبت", MessageFormIcons.Info, MessageFormButtons.Ok, Properties.Settings.Default.Color);

               
                    if (MenuTop4ToolStripMenuItem.Checked == true)
                        MenuTop4ToolStripMenuItem_Click(null, null);

            }
        }

        private void grdIntermittenc_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            int oldRowCounts = grdIntermittenc.Rows.Count;
            int newRowCounts = 0;
            string value = "";
            int index = 0;
            if (grdIntermittenc.SelectedRows.Count > 0)
            { value = (grdIntermittenc.SelectedRows[0].Cells["CodeCol"].Value).ToString();
            index = grdIntermittenc.SelectedRows[0].Index;
            }
            SqlParameter[] param1;
            param1 = new SqlParameter[2];
            int index1 = 0;
            param1[index1++] = new SqlParameter("@IDCenter", IDCenter);
            param1[index1++] = new SqlParameter("@DocumentType", 3);
            DataSet ds1 = new DataSet();
            ds1 = da.ExecuteSP("GetCenetrsIntermittence", param1);
            if (ds1 != null && ds1.Tables.Count > 0 && ds1.Tables[0].Rows.Count >= 0)
            {
                GridDataSourceDt = ds1.Tables[0];

                if (ds1.Tables[0].Rows.Count < oldRowCounts)
                {
                    grdIntermittenc.CellClick -= grdIntermittenc_CellClick;
                    MenuTop4ToolStripMenuItem.Text = "";
                    FillGrid(GridDataSourceDt);
                    {

                        MenuTop4ToolStripMenuItem.Text = GridDataSourceDt.Rows.Count.ToString() + " " + "نسخه";

                    }
                    grdIntermittenc.CellClick += grdIntermittenc_CellClick;
                    if (grdIntermittenc.Rows.Count > 0)
                        grdIntermittenc.Rows[0].Selected = false;
                    //if (grdIntermittenc.Rows.Count >= index + 1)
                    //{ grdIntermittenc.Rows[index - 1].Selected = true;
                    //grdIntermittenc.CurrentCell = grdIntermittenc.Rows[index - 1].Cells[1];
                    //}
                    //else if (grdIntermittenc.Rows.Count == index)
                    //{ grdIntermittenc.Rows[grdIntermittenc.Rows.Count - 1].Selected = true;

                    //grdIntermittenc.CurrentCell = grdIntermittenc.Rows[grdIntermittenc.Rows.Count - 1].Cells[1];
                    //}

                    if (index - 1 == -1)
                        grdIntermittenc.Rows[0].Selected = true;

                    foreach (DataGridViewRow row in grdIntermittenc.Rows)
                    {
                        if (row.Cells[1].Value.ToString().Equals(value))
                        {
                            row.Selected = true;
                            break;
                        }
                    }
          //          DataGridViewRow row = grdIntermittenc.Rows
          //.Cast<DataGridViewRow>()
          //.Where(r => r.Cells["CodeCol"].Value.ToString().Equals(index))
          //.First();
          //          row.Selected = true;
                    //else if (index == grdIntermittenc.Rows.Count || index + 1 > grdIntermittenc.Rows.Count || index+1 < grdIntermittenc.Rows.Count) //|| index + 1 > grdIntermittenc.Rows.Count || index< grdIntermittenc.Rows.Count)
                    //{
                    //    grdIntermittenc.Rows[index - 1].Selected = true;
                    //    grdIntermittenc.CurrentCell = grdIntermittenc.Rows[index - 1].Cells[1];
                    //}
                   
                    //else
                    //{
                    //    grdIntermittenc.Rows[index].Selected = true;
                    //    grdIntermittenc.CurrentCell = grdIntermittenc.Rows[index ].Cells[1];
                    //}
                }
            }
            else
            {
                dt.Rows.Clear();
                grdIntermittenc.DataSource = dt;
                grdDocuments.DataSource = null;
                MenuTop4ToolStripMenuItem.Text = "";
                MenuTop4ToolStripMenuItem.Text = "0" + " " + "نسخه";
            }

          //  newRowCounts = grdIntermittenc.Rows.Count;
            // if (newRowCounts > oldRowCounts)
            // { System.Media.SystemSounds.Asterisk.Play(); }



            pictureBox1.Enabled = true;

            if (pictureBox1.Image != null)
            {

                pictureBox1.Image.Dispose();
                pictureBox1.Image = null;
            }
            pictureBox1.Invalidate();
            Byte[] imageData = new Byte[0];
            FillDocumentsGrid();
            if  (DocumentDT!= null && DocumentDT.Rows.Count > 0)
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

            SqlParameter[] param1;
            param1 = new SqlParameter[2];
            int index1 = 0;    MenuTop4ToolStripMenuItem.Text = "";
            param1[index1++] = new SqlParameter("@IDCenter", IDCenter);
            param1[index1++] = new SqlParameter("@DocumentType", 3);
            DataSet dsg = new DataSet(); dsg = da.ExecuteSP("GetCenetrsIntermittence", param1);
            if (dsg != null && dsg != new DataSet() && dsg.Tables.Count > 0 && dsg.Tables[0].Rows.Count > 0)
            {
                GridDataSourceDt = dsg.Tables[0];//همه نسخه ها ی مربوط به این داروخانه را می آورد چه امروز چه فردا و انایی که منشی بهش سند کره را ن ه 
                FillGrid(GridDataSourceDt); MenuTop4ToolStripMenuItem.Text = GridDataSourceDt.Rows.Count.ToString() + " " + "نسخه";
            }
            else { MenuTop4ToolStripMenuItem.Text ="0" + " " + "نسخه"; }
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
            
            //if (openFileDialog.ShowDialog(this) != DialogResult.OK)
            //{
            //    return;
            //}

            //_files = new List<string>();
            //_files.AddRange(openFileDialog.FileNames);
            //_files.Sort();

            //if (_numberPreviewImages == 1)
            //{
            //    _currentStartImageIndex = 0;
            //    _currentEndImageIndex = 1;
            //}
            //else
            //{
            //    _currentEndImageIndex = _currentStartImageIndex + _numberPreviewImages - 1;
            //}

            //this.LoadImages();

            if (grdIntermittenc.CurrentRow == null)
                return;

            path = Path.GetDirectoryName(Application.ExecutablePath) + @"\Docs" + @"\" + (grdDocuments.CurrentRow.Cells["ID"].Value).ToString();

            // If directory does not exist, don't even try 
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            
            //saveFileDialog1.InitialDirectory = path;

            openFileDialog.Title = "Save Files";

            openFileDialog.CheckFileExists = true;

            openFileDialog.CheckPathExists = true;

            //saveFileDialog1.DefaultExt = "txt";

           // saveFileDialog1.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog1.Filter = "All Files (*.*)|*.*";
            openFileDialog.FilterIndex = 2;

           // saveFileDialog1.RestoreDirectory = true;



            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                SqlParameter[] param;
                param = new SqlParameter[2];
                bool result;
                int index = 0;
                //if(btnGold.Image=Properties
                if (grdDocuments.CurrentRow==null) return;
                param[index++] = new SqlParameter("@IDDocument", Convert.ToInt32(grdDocuments.CurrentRow.Cells["ID"].Value));

                param[index++] = new SqlParameter("@IDCenter", IDCenter);



                result = Convert.ToBoolean(this.da.ExecuteScalarSP("SetRadiologyResult", param));


                
              
                FileInfo fi = new FileInfo(openFileDialog.FileName);
                string text = fi.Name;    var msg = "فایل تکراری است.";
                if (File.Exists(path + @"\" + text))
                {
                    MessageForm.Show(msg, "خطای فایل", MessageFormIcons.Warning, MessageFormButtons.Ok, color);
                    return;
                   
                } 


                Font font = new Font("B Nazanin", 10.0f, FontStyle.Bold);
                System.IO.File.Copy(openFileDialog.FileName, path + @"\" + text);
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
                btn.Size = new System.Drawing.Size(23, 23);
                btn.UseVisualStyleBackColor = true;
                btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
                l.Visible = true;
                l.Text = text;
                l.Name = text; l.ForeColor = Color.Black;
                l.Tag = path + @"\" + text; btn.Tag = path + @"\" + text;
                l.Location = new Point(tabControl1.TabPages[0].Location.X, tabControl1.TabPages[0].Location.Y + i);
                btn.Location = new Point(l.Location.X+130, tabControl1.TabPages[0].Location.Y + i);
                i = i + 20; tabControl1.TabPages[0].AutoScroll = true;
               // listBox1.Items.Add(text,"");
                tabControl1.TabPages[0].Controls.Add(l);
                tabControl1.TabPages[0].Controls.Add(btn); 
               
                l.LinkClicked += linkLabel1_LinkClicked;
               
             
            }

            //foreach (var path1 in Directory.GetFiles(path))
            //{

            //    LinkLabel l = new LinkLabel();
            //    l.Visible = true;
            //    panel1.Visible = true;
            //    l.Name = path1;
            //    l.Tag = System.IO.Path.GetFileName(path);
            //    panel1.Controls.Add(l);
            //}


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
                    param[index++] = new SqlParameter("@IDCenter", IDCenter);
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

        //private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        //{
        //    Button btnRequest = (Button)sender;
        //    string filePath = @"E:\test.txt";
        //    if (!File.Exists(  e.Link.Tag.ToString() ))
        //    {
        //        return;
        //    }

        //    // combine the arguments together
        //    // it doesn't matter if there is a space after ','
        //    string argument = @"/select, " +  e.Link.Tag.ToString() ;

        //    System.Diagnostics.Process.Start("explorer.exe", argument);
        //}

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
            if (grdDocuments.CurrentRow == null) return;
            tabControl1.TabPages[0].Controls.Clear(); i = 1;
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
                        tabControl1.TabPages[0].Controls.Add(l);
                        tabControl1.TabPages[0].Controls.Add(btn);

                        l.LinkClicked += linkLabel1_LinkClicked;
                    }




                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            DataTable dtSearch = new DataTable();
            
            DataTable dtSearched = new DataTable();

            if (!(textBox1.Text.Trim() == "" || textBox1.Text == string.Empty) && grdIntermittenc.Rows.Count>0)
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

        private void button3_MouseEnter(object sender, EventArgs e)
        {
            button3.BackColor = Color.White;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //SqlParameter[] param;
            //param = new SqlParameter[1];
            //int inde = 0;
            //param[inde++] = new SqlParameter("@TableName", this.Tag.ToString());
            ////return new SqlBinary(this.dataAccess.ExecuteScalarSP("spGetLastTimeStamp", param) as byte[]);
            //Object timeStamp = this.da.ExecuteScalarSP("GetLastTimeStamp", param);




            //lastTimeStamp = timeStamp.ToString() == "-2" ? new DateTime() : Convert.ToDateTime(timeStamp);

            //if (((System.DateTime)(timeStamp)).TimeOfDay.CompareTo(lastTimeStamp.TimeOfDay) != 0)// timeStamp.CompareTo(lastTimeStamp) != 0)
            //{
            int oldRowCounts = grdIntermittenc.Rows.Count;
            int newRowCounts = 0;
         
                SqlParameter[] param1;
                param1 = new SqlParameter[2];
                int index1 = 0;
                param1[index1++] = new SqlParameter("@IDCenter", IDCenter);
                param1[index1++] = new SqlParameter("@DocumentType", 3);
                DataSet ds1 = new DataSet();
                ds1 = da.ExecuteSP("GetCenetrsIntermittence", param1); 
                if (ds1 != null && ds1.Tables.Count > 0 && ds1.Tables[0].Rows.Count >= 0)
                {
                    newRowCounts = ds1.Tables[0].Rows.Count;
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
                buttonToolTip.Show("بیمار جدید به لیست اضافه شد.", win, this.Size.Width, this.Size.Height);
                                             
                return;
            
            
            }
        }

        private void btnNextPatiant_Click(object sender, EventArgs e)
        {
            if (grdIntermittenc.Rows.Count == 0) return;
            int currentRow = grdIntermittenc.CurrentRow.Index;
            //grdIntermittenc.Rows[currentRow ].Selected = false;
            if (-1 < currentRow + 1 && currentRow + 1 < grdIntermittenc.Rows.Count)
            {
                grdIntermittenc.CurrentCell = grdIntermittenc.Rows[currentRow + 1].Cells[1];
                grdIntermittenc.Rows[currentRow + 1].Selected = true;
                grdIntermittenc_CellClick(null, null);
            }
            if (MenuTop4ToolStripMenuItem.Checked)
                SelectMenuTop(MenuTop4ToolStripMenuItem);
           
            timer1_Tick(null, null);
        
        }

        private void trackBarImageSize_Scroll(object sender, EventArgs e)
        {
            if (trackBarImageSize.Value == 0)
            {
                _imageSize = 50;
            }
            else
            {
                _imageSize = 50 * (trackBarImageSize.Value + 1);
            }

            this.LoadImages();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            tabControl1.TabPages[0].Controls.Clear();
            int oldRowCounts = grdIntermittenc.Rows.Count;
            int newRowCounts = 0;
            int index = 0;
            if (grdIntermittenc.SelectedRows.Count > 0)
                index = grdIntermittenc.SelectedRows[0].Index;
            SqlParameter[] param1;
            param1 = new SqlParameter[2];
            int index1 = 0;
            param1[index1++] = new SqlParameter("@IDCenter", IDCenter);
            param1[index1++] = new SqlParameter("@DocumentType", 3);
            DataSet ds1 = new DataSet();
            ds1 = da.ExecuteSP("GetCenetrsIntermittence", param1); MenuTop4ToolStripMenuItem.Text = "";
            if (ds1 != null && ds1.Tables.Count > 0 && ds1.Tables[0].Rows.Count > 0)
            {
                GridDataSourceDt = ds1.Tables[0];
                grdIntermittenc.CellClick -= grdIntermittenc_CellClick;
                FillGrid(GridDataSourceDt);
                {

                    MenuTop4ToolStripMenuItem.Text = GridDataSourceDt.Rows.Count.ToString() + " " + "نسخه";

                }
                grdIntermittenc.CellClick += grdIntermittenc_CellClick;
                if (grdIntermittenc.Rows.Count > 0)
                    grdIntermittenc.Rows[0].Selected = false;
                if (grdIntermittenc.Rows.Count >= index + 1)
                    grdIntermittenc.Rows[index].Selected = true;

            }
            else
            {
                dt.Rows.Clear();
                grdIntermittenc.DataSource = dt;
                grdDocuments.DataSource = null;
                MenuTop4ToolStripMenuItem.Text = "";
                MenuTop4ToolStripMenuItem.Text = "0" + " " + "نسخه";
            }
            buttonToolTip.Hide(this);
            newRowCounts = grdIntermittenc.Rows.Count;
           // if (newRowCounts > oldRowCounts)
           // { System.Media.SystemSounds.Asterisk.Play(); }
             //کامنت به علت تغییر آپلود نوع
            //Insert();
            //dataViewImages.Rows.Clear();
            //dataViewImages.Columns.Clear();

             
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
          // listBox1.SelectedValue
        }

        private void dataViewImages_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }



    }
}
