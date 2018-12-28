using ImageThumbnailDataGridView;
using MesbahComponent;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace ClinicMesbah
{
    public partial class Document : Form
    {
        private bool bimehF = false;
        private bool kartmelliF = false;
        private bool shenasnameF = false;
        private bool attachF = false;
        private DataTable smsDt = new DataTable();
        private int _imageSize = 50;
        private int _currentStartImageIndex = 0;
        private int _currentEndImageIndex = 0; 
        private int _numberPreviewImages = 100;
        private List<string> _files = null;
        public string _mobileNumber;
        private Color color;
        private string nasionalityCode; private string TelORMobile;
        private OpenFileDialog openFileDialog1 = new OpenFileDialog();
        private DataAccess da = new DataAccess();
        private string shenasnameh;
        private string bimesh;
        private string kartMelli;
        private string customerImage;
        private short DepartmentID;


        public Document(short DepartmentID)
        {
            InitializeComponent();
            this.DepartmentID = DepartmentID;
            txtNationalityCode.Enabled = true;
            btnAttachDelete.Enabled = btnbimehDelete.Enabled = btnKartMelliDelete.Enabled = btnShenasnamedDelete.Enabled = false;
        }
        public Document(string nasionalityCode , string TelORMobile)
        {
            InitializeComponent();
            this.nasionalityCode = nasionalityCode;
            this.TelORMobile = TelORMobile;
            button4.Enabled = false;
        }
        private void setcolor()
        {
            color = Properties.Settings.Default.Color;
            gbEnergy.BackColor =ControlPaint.LightLight(ControlPaint.LightLight( ControlPaint.LightLight(ControlPaint.LightLight((ControlPaint.LightLight(color))))));
              btnKartmelli.BackColor=btnshenas.BackColor=btnBimeh.BackColor=  btnAttach.BackColor=  button3.BackColor = color;
              button4.BackColor = button1.BackColor = color;
           btnSelectPic.BackColor= button2.BackColor = color;
      
           dataViewImages.BackgroundColor = ControlPaint.LightLight(ControlPaint.LightLight((ControlPaint.LightLight(color))));
           dataViewImages.RowsDefaultCellStyle.SelectionBackColor = ControlPaint.LightLight(color);
     
        }
        private bool IsMobileNumberValid(string mobileNumber)
        {

            _mobileNumber = CleanNumber(mobileNumber);


            _mobileNumber = _mobileNumber.TrimStart(new char[] { '0' });


            if (_mobileNumber.StartsWith("98"))
            {
                _mobileNumber = _mobileNumber.Remove(0, 2);
            }


            if (!_mobileNumber.StartsWith("9"))
            {
                return false;
            }


            if (_mobileNumber.Length != 10)
            {
                return false;
            }

            return true;
        }
        private string CleanNumber(string phone)
        {
            Regex digitsOnly = new Regex(@"[^\d]");
            return digitsOnly.Replace(phone, "");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string eventlog = "set a Document for a NationalityCode=" + txtNationalityCode.Text;
            try
            {
                if(txtNationalityCode.Text==string.Empty)
                {
                    var msg = "لطفا کد ملی را وارد نمایید";
                    MessageForm.Show(msg, "ثبت", MessageFormIcons.Warning, MessageFormButtons.Ok, Properties.Settings.Default.Color);

                    txtNationalityCode.Focus(); return;
                }
    //           if(pictureBox1.Image!= null)// if(dataViewImages.Rows.Count>0)
                Insert();
                int result = da.InsertPatient("SetCostumerInfo", txtNationalityCode.Text, txtName.Text, txtLastName.Text, txtFather.Text, txtAdress.Text, txtisurance.Text, txtTel.Text, txtMobile.Text);
                if (result > 0)
                {
                    var msg = "ثبت با موفقیت انجام شد";
                    MessageForm.Show(msg, "ثبت", MessageFormIcons.Info, MessageFormButtons.Ok, Properties.Settings.Default.Color);

                    button4.Enabled = false;
                    txtAdress.Enabled = false;
                    txtFather.Enabled = false;
                    txtisurance.Enabled = false;
                    txtLastName.Enabled = false;
                    txtMobile.Enabled = false;
                    txtName.Enabled = false;
                    txtTel.Enabled = false;
                    txtNationalityCode.Enabled = false;
                    btnAttach.Enabled = false; btnshenas.Enabled = false; btnKartmelli.Enabled = false; btnBimeh.Enabled = false; button2.Enabled = false;
                    if (bimehF)
                        btnBimeh.Image = Properties.Resources.check;
                    if( kartmelliF)
                        btnKartmelli.Image = Properties.Resources.check;
                    if(shenasnameF)
                        btnshenas.Image = Properties.Resources.check;
                    if(attachF)
                      btnAttach.Image = Properties.Resources.check;
                    
                }
                else
                {
                    var msg = "ثبت ناموفق بود";
                    MessageForm.Show(msg, "ثبت", MessageFormIcons.Warning, MessageFormButtons.Ok, Properties.Settings.Default.Color);
                
                   // timer1.Start();
                }


            }
            catch (Exception e1)
            {


                NewMethod_eventlog(eventlog, 17000);
                throw;
            }

        }
        private static void NewMethod_eventlog(string eventlog, int id)
        {
            EventLog log = new EventLog();
            //log.taskca
            log.Source = "application";
            log.WriteEntry(eventlog, EventLogEntryType.Information, id);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Document_Load(object sender, EventArgs e)
        {
            if (!Properties.Settings.Default.clinic)
            {
                label4.Text = "شماره عضویت";
                btnBimeh.Visible = false;
                pictureBox4.Visible = false;
            
            }


            setcolor();

           // System.Timers.Timer aTimer = new System.Timers.Timer(10000);

            // Hook up the Elapsed event for the timer.
            //aTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
            
            // Set the Interval to 2 seconds (2000 milliseconds).
            timer1.Interval = 500;
            timer1.Enabled = false;
            if (nasionalityCode == null) return;
            DataSet ds = new DataSet();

            txtNationalityCode.Text = nasionalityCode;

            if (TelORMobile.Trim() != nasionalityCode.Trim())
            {
                if (IsMobileNumberValid(TelORMobile))
                    txtMobile.Text = TelORMobile;
                else
                    txtTel.Text = TelORMobile;
            }
                string eventlog = "Get a Document by a NationalityCode=" + nasionalityCode;
                try
                {
                  
                    ds = da.GetpationtInfo("GetCustomerInfo", nasionalityCode);
                    if (ds != null)
                    {
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            txtAdress.Text = ds.Tables[0].Rows[0]["Adress"].ToString();
                            txtFather.Text = ds.Tables[0].Rows[0]["FatherName"].ToString();
                            txtisurance.Text = ds.Tables[0].Rows[0]["IsuranceID"].ToString();
                            txtLastName.Text = ds.Tables[0].Rows[0]["Lname"].ToString();
                            txtMobile.Text = ds.Tables[0].Rows[0]["Mobile"].ToString();
                            txtName.Text = ds.Tables[0].Rows[0]["Fname"].ToString();
                            txtTel.Text = ds.Tables[0].Rows[0]["Telphone"].ToString();
                        }
                    }
                    DataSet imageDS = new DataSet();
                    Byte[] imageData = new Byte[0];
                    Byte[] imageBimeh = new Byte[0];
                    Byte[] imageShenasname = new Byte[0];
                    Byte[] imageKartmelli = new Byte[0];

                    imageDS = da.GetpationtInfo("GetCustomerImageInfo", nasionalityCode);
                    if (imageDS != null && imageDS.Tables.Count > 0 && imageDS.Tables[0].Rows.Count > 0 && imageDS.Tables[0].Rows[0]["Customerimage"]!=DBNull.Value)
                    {
                        imageData = (Byte[])(imageDS.Tables[0].Rows[0]["Customerimage"]);
                        if (imageData != null)
                        {
                            MemoryStream stream = new MemoryStream(imageData); pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
                            pictureBox1.BackgroundImage = Image.FromStream(stream);
                            btnAttach.Image = Properties.Resources.check;
                        }
                    }

                    if (imageDS != null && imageDS.Tables.Count > 0 && imageDS.Tables[0].Rows.Count > 0 && imageDS.Tables[0].Rows[0]["KartMelli"]!=DBNull.Value)
                    {
                        imageKartmelli = (Byte[])(imageDS.Tables[0].Rows[0]["KartMelli"]);
                        if (imageKartmelli != null)
                        {
                            MemoryStream stream = new MemoryStream(imageKartmelli); pictureBox3.BackgroundImageLayout = ImageLayout.Stretch;
                            pictureBox3.BackgroundImage = Image.FromStream(stream);
                            btnKartmelli.Image = Properties.Resources.check;
                        }
                    }
                    if (imageDS != null && imageDS.Tables.Count > 0 && imageDS.Tables[0].Rows.Count > 0 && imageDS.Tables[0].Rows[0]["ShenasName"]!=DBNull.Value)
                    {
                        imageShenasname = (Byte[])(imageDS.Tables[0].Rows[0]["ShenasName"]);
                        if (imageShenasname != null)
                        {
                            MemoryStream stream = new MemoryStream(imageShenasname); pictureBox2.BackgroundImageLayout = ImageLayout.Stretch;
                            pictureBox2.BackgroundImage = Image.FromStream(stream);
                            btnshenas.Image = Properties.Resources.check;
                        }
                    }
                    if (imageDS != null && imageDS.Tables.Count > 0 && imageDS.Tables[0].Rows.Count > 0 &&(imageDS.Tables[0].Rows[0]["Bimeh"])!=DBNull.Value)
                    {
                        imageBimeh = (Byte[])(imageDS.Tables[0].Rows[0]["Bimeh"]);
                        if (imageBimeh != null)
                        {
                            MemoryStream stream = new MemoryStream(imageBimeh); pictureBox4.BackgroundImageLayout = ImageLayout.Stretch;
                            pictureBox4.BackgroundImage = Image.FromStream(stream);
                            btnBimeh.Image = Properties.Resources.check;
                        }
                    }
                }
                catch
                {
                    NewMethod_eventlog(eventlog, 17001);
                    throw;
                }
               
        }

        private void FillGrid(DataTable imageDT)
        {
            foreach (DataRow row in imageDT.Rows)
            {

                DataRow dr = smsDt.Rows.Add();
                dr["IDIntermittence"] = (row["ID"]);
                dr["CodeCol"] = row["NationalityCode"];
                dr["CustomerCol"] = row["Name"];
                Int32 index = dataViewImages.Rows.Count - 1;
                dataViewImages.Rows[index].Tag = row;

            }

            dataViewImages.DataSource = smsDt;
        }

        private void txtNationalityCode_KeyDown(object sender, KeyEventArgs e)
        {
            //char c = Convert.ToChar(e.PlatformKeyCode);
            //if (!char.IsDigit(c))
            //{
            //    e.Handled = true;
            //}
        }

        private void txtisurance_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\b')
            {
                e.Handled = false;
                return;
            }
            if (!(Char.IsDigit(e.KeyChar) || (e.KeyChar == (char)Keys.Back)))
                e.Handled = true;
        }

        private void txtMobile_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\b')
            {
                e.Handled = false;
                return;
            }
            if (!(Char.IsDigit(e.KeyChar) || (e.KeyChar == (char)Keys.Back)))
                e.Handled = true;
            if (txtMobile.Text.Length > 10)
            {
                e.Handled = true;
            }
        }

        private void txtTel_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\b')
            {
                e.Handled = false;
                return;
            }
            if (!(Char.IsDigit(e.KeyChar) || (e.KeyChar == (char)Keys.Back)))
                e.Handled = true;
        }

        private void txtNationalityCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\b')
            {
                e.Handled = false;
                return;
            }
            if (!(Char.IsDigit(e.KeyChar) || (e.KeyChar == (char)Keys.Back)))
                e.Handled = true;
            if (txtNationalityCode.Text.Length > 9)
            {
                e.Handled = true;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (button1.BackColor == Color.Gray)
            { button1.BackColor = Color.Red; }
            else
            { button1.BackColor = Color.Gray; }
        }

        private void button3_Click(object sender, EventArgs e)
        {
          

            string Id = txtNationalityCode.Text.Trim();
            if (Id == null || Id == "") return;
            DataTable settingDT = new DataTable();
            settingDT = da.ExecuteCommand("GetSetting").Tables[0];

            if (settingDT.Rows[0]["TypeOfDocumentDetail"] !=DBNull.Value  && Convert.ToBoolean(settingDT.Rows[0]["TypeOfDocumentDetail"]))
            {
                DocumentsDetails dd = new DocumentsDetails( txtNationalityCode.Text.Trim());
                dd.ShowDialog();
            }
            else
                System.Diagnostics.Process.Start(settingDT.Rows[0]["DocumentUrl"].ToString().Replace("%1", Id)); 


        }

        private void gbEnergy_Enter(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog(this) != DialogResult.OK)
            {
                return;
            }

            _files = new List<string>();
            _files.AddRange(openFileDialog.FileNames);
            _files.Sort();

            if (_numberPreviewImages == 1)
            {
                _currentStartImageIndex = 0;
                _currentEndImageIndex = 1;
            }
            else
            {
                _currentEndImageIndex = _currentStartImageIndex + _numberPreviewImages - 1;
            }

            this.LoadImages();


        }

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

        #region DocumentsImages
        public class DocumentsImages// اینفوی اطلاعات بیمار
        {
            public byte[] image;
            public byte[] bimeh;
            public byte[] kartMelli;
            public byte[] shenasname;

            public long idDocumentImage;
            public string nationalityCode;
            public DocumentsImages()
            { }
            public DocumentsImages(byte[] bimeh, byte[] kartMelli, byte[] shenasname, byte[] image, long idDocumentImage, string nationalityCode)
            {
                this.shenasname = shenasname;
                this.kartMelli = kartMelli;
                this.bimeh = bimeh;
                this.image = image;
                this.idDocumentImage = idDocumentImage;
                this.nationalityCode = nationalityCode;
               
            }
            public byte[] Image
            {
                get { return image; }
                set { image = value; }
            }
            public byte[] Shenasname
            {
                get { return shenasname; }
                set { shenasname = value; }
            }
            public byte[] KartMelli
            {
                get { return kartMelli; }
                set { kartMelli = value; }
            }
            public byte[] Bimeh
            {
                get { return bimeh; }
                set { bimeh = value; }
            }

            public long IdDocumentImage
            {
                get { return idDocumentImage; }
                set { idDocumentImage = value; }
            }
            public string NationalityCode
            {
                get { return nationalityCode; }
                set { nationalityCode = value; }
            }
            

        }
        #endregion
        private void trackBarImageSize_Scroll(object sender, EventArgs e)
        {

        }
        private void Insert()
        {

          

            XmlDocument doc = new XmlDocument();
         
            List<DocumentsImages> documentsImages = new List<DocumentsImages>();
            ImageConverter converter = new ImageConverter();

            DocumentsImages documentsImage = new DocumentsImages();

            //Image img = pictureBox1.Image as Image;
            //byte[] buf = null;
            //if (img != null)
            //{
            //    using (MemoryStream s = new MemoryStream())
            //    {
            //        img.Save(s, ImageFormat.Png);
            //        buf = s.ToArray();
            //    }
            //}

            //  path = fileDialog.FileName;

            //FileStream fs = new FileStream(openFileDialog1.FileName, FileMode.Open, FileAccess.Read);

            //byte[] picArray = new byte[fs.Length];

             Image imgBimeh=pictureBox4.Image ;
             Image img = pictureBox1.Image; 
            Image imgShenas = pictureBox2.Image; 
            Image imgKartMell = pictureBox3.Image;
            if (customerImage != null)
            {
                img = Image.FromFile(customerImage);
                documentsImage.Image = (byte[])converter.ConvertTo(img, typeof(byte[]));
                
                 attachF = true;
            }
            if (bimesh != null)
            {
                imgBimeh = Image.FromFile(bimesh);
                documentsImage.Bimeh = (byte[])converter.ConvertTo(imgBimeh, typeof(byte[]));
                 bimehF = true;
                
            }
            if (shenasnameh != null)
            {
                imgShenas = Image.FromFile(shenasnameh);
                documentsImage.Shenasname = (byte[])converter.ConvertTo(imgShenas, typeof(byte[]));
                 shenasnameF = true;
            }
            if (kartMelli != null)
            {
                imgKartMell = Image.FromFile(kartMelli);
                documentsImage.KartMelli = (byte[])converter.ConvertTo(imgKartMell, typeof(byte[]));
                 kartmelliF = true;

            }
            documentsImage.NationalityCode = txtNationalityCode.Text;
            documentsImage.IdDocumentImage = 0;//Convert.ToInt32(dataViewImages.CurrentRow.Tag) == 0 ? 0 : Convert.ToInt32(dataViewImages.CurrentRow.Tag);
            documentsImages.Add(documentsImage);

            //    }
            //}








   string xml = "<DocumentsImages>";
            if (documentsImages != null && documentsImages.Count > 0)
            {
                foreach (DocumentsImages lr in documentsImages)
                {

                    xml += string.Format(@"<DocumentsImages idDocumentImage=""{0}"" NationalityCode=""{1}"" Customerimage=""{2}""",
                                        lr.IdDocumentImage,
                                        lr.NationalityCode.Trim(),
                                      (byte[])converter.ConvertTo((img), typeof(byte[])));

                    xml += "  />";
                }
            }

            xml += "</DocumentsImages>";
            doc.InnerXml = xml;


            SqlParameter[] param;
            param = new SqlParameter[10];
            bool result;
            int index = 0;
            
            //if (!String.IsNullOrEmpty(xml))
            param[index++] = new SqlParameter("@idDocumentImage", 0);
            param[index++] = new SqlParameter("@NationalityCode", txtNationalityCode.Text.Trim());
            // param[index++] = new SqlParameter("@OverallInsertFieldCount", overallInsertFieldCount);

            if (attachF)
            param[index++] = new SqlParameter("@Customerimage", (byte[])converter.ConvertTo(img, typeof(byte[])));

            if (bimehF)
            param[index++] = new SqlParameter("@Bimeh", (byte[])converter.ConvertTo(imgBimeh, typeof(byte[])));

            if (shenasnameF)
            param[index++] = new SqlParameter("@ShenasName", (byte[])converter.ConvertTo(imgShenas, typeof(byte[])));

            if (kartmelliF)
            param[index++] = new SqlParameter("@KartMelli", (byte[])converter.ConvertTo(imgKartMell, typeof(byte[])));

            param[index++] = new SqlParameter("@attachF", attachF);
            param[index++] = new SqlParameter("@bimehF", bimehF);
            param[index++] = new SqlParameter("@shenasnameF", shenasnameF);
            param[index++] = new SqlParameter("@kartmelliF", kartmelliF);

            result = Convert.ToBoolean(this.da.ExecuteScalarSP("SetDocumentsImagesInfos", param));
            if (result)
            {
                // var msg = "ثبت با موفقیت انجام شد"; MessageForm.Show(msg, "ثبت", MessageFormIcons.Info, MessageFormButtons.Ok, Properties.Settings.Default.Color);


            }
            else 
            {
                var msg = "ثبت عکس ناموفق بود."; MessageForm.Show(msg, "ثبت", MessageFormIcons.Info, MessageFormButtons.Ok, Properties.Settings.Default.Color);

            }
        }

        public byte[] ImageToByteArray(Image img)
        {
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            img.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            return ms.ToArray();
        }

        private void btnAttach_Click(object sender, EventArgs e)
        {

             openFileDialog1.Filter = "Images|*.png;*.bmp;*.jpg";
               ImageFormat format = ImageFormat.Png;
                if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    string ext = System.IO.Path.GetExtension(openFileDialog1.FileName);
                    customerImage = openFileDialog1.FileName;
                    try
                    {
                       pictureBox1.BackgroundImage = Image.FromFile(openFileDialog1.FileName);
                       pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
                     
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error loading image" + ex.Message);
                    }
                
            }

                _files = new List<string>();
                _files.AddRange(openFileDialog.FileNames);
                _files.Sort();

                if (_numberPreviewImages == 1)
                {
                    _currentStartImageIndex = 0;
                    _currentEndImageIndex = 1;
                }
                else
                {
                    _currentEndImageIndex = _currentStartImageIndex + _numberPreviewImages - 1;
                }

                this.LoadImages();
        }

        private void txtAdress_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_DoubleClick(object sender, EventArgs e)
        {
            if (txtNationalityCode.Text.Trim()==string.Empty) return;
            ShowAttachments sa = new ShowAttachments(txtNationalityCode.Text.Trim(),0);

            sa.ShowDialog();
        }

        private void btnshenas_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Images|*.png;*.bmp;*.jpg";
            ImageFormat format = ImageFormat.Png;
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string ext = System.IO.Path.GetExtension(openFileDialog1.FileName);
                shenasnameh = openFileDialog1.FileName;
                try
                {
                    pictureBox2.BackgroundImage = Image.FromFile(openFileDialog1.FileName);
                    pictureBox2.BackgroundImageLayout = ImageLayout.Stretch;

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading image" + ex.Message);
                }

            }
        }

        private void btnKartmelli_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Images|*.png;*.bmp;*.jpg";
            ImageFormat format = ImageFormat.Png;
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string ext = System.IO.Path.GetExtension(openFileDialog1.FileName);
                kartMelli = openFileDialog1.FileName;
                try
                {
                    pictureBox3.BackgroundImage = Image.FromFile(openFileDialog1.FileName);
                    pictureBox3.BackgroundImageLayout = ImageLayout.Stretch;

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading image" + ex.Message);
                }

            }
        }

        private void btnBimeh_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Images|*.png;*.bmp;*.jpg";
            ImageFormat format = ImageFormat.Png;
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string ext = System.IO.Path.GetExtension(openFileDialog1.FileName);
                bimesh = openFileDialog1.FileName;
                try
                {
                    pictureBox4.BackgroundImage = Image.FromFile(openFileDialog1.FileName);
                    pictureBox4.BackgroundImageLayout = ImageLayout.Stretch;

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading image" + ex.Message);
                }

            }
        }

        private void btnbimehDelete_Click(object sender, EventArgs e)
        {
            if (txtNationalityCode.Text == string.Empty)
            {
                var msg = "لطفا کد ملی را وارد نمایید";
                MessageForm.Show(msg, "ثبت", MessageFormIcons.Warning, MessageFormButtons.Ok, Properties.Settings.Default.Color);

                txtNationalityCode.Focus(); return;
            }
            SqlParameter[] param;
            param = new SqlParameter[2];
            int index = 0;
            param[index++] = new SqlParameter("@type", 4);
            param[index++] = new SqlParameter("@NationalityCode", txtNationalityCode.Text.Trim());
          
            if (Convert.ToBoolean (da.ExecuteScalarSP("DeleteCustomerImage", param)))
            {
                if (pictureBox4.Image != null)
                {
                    pictureBox4.Image.Dispose();
                    pictureBox4.Image = null;
                }
                pictureBox4.Invalidate();
            }
        }

        private void btnKartMelliDelete_Click(object sender, EventArgs e)
        {
            if (txtNationalityCode.Text == string.Empty)
            {
                var msg = "لطفا کد ملی را وارد نمایید";
                MessageForm.Show(msg, "ثبت", MessageFormIcons.Warning, MessageFormButtons.Ok, Properties.Settings.Default.Color);

                txtNationalityCode.Focus(); return;
            }
            SqlParameter[] param;
            param = new SqlParameter[2];
            int index = 0;
            param[index++] = new SqlParameter("@type", 3);
            param[index++] = new SqlParameter("@NationalityCode", txtNationalityCode.Text.Trim());
            if (Convert.ToBoolean(da.ExecuteScalarSP("DeleteCustomerImage", param)))
            {
                if (pictureBox3.Image != null)
                {
                    pictureBox3.Image.Dispose();
                    pictureBox3.Image = null;
                }
                pictureBox3.Invalidate();
            }
        }

        private void btnShenasnamedDelete_Click(object sender, EventArgs e)
        {
            if (txtNationalityCode.Text == string.Empty)
            {
                var msg = "لطفا کد ملی را وارد نمایید";
                MessageForm.Show(msg, "ثبت", MessageFormIcons.Warning, MessageFormButtons.Ok, Properties.Settings.Default.Color);

                txtNationalityCode.Focus(); return;
            }
            SqlParameter[] param;
            param = new SqlParameter[2];
            int index = 0;
            param[index++] = new SqlParameter("@type", 2);
            param[index++] = new SqlParameter("@NationalityCode", txtNationalityCode.Text.Trim());

            if (Convert.ToBoolean(da.ExecuteScalarSP("DeleteCustomerImage", param)))
            {
                if (pictureBox2.Image != null)
                {
                    pictureBox2.Image.Dispose();
                    pictureBox2.Image = null;
                }
                pictureBox2.Invalidate();
            }
        }

        private void btnAttachDelete_Click(object sender, EventArgs e)
        {
            if (txtNationalityCode.Text == string.Empty)
            {
                var msg = "لطفا کد ملی را وارد نمایید";
                MessageForm.Show(msg, "ثبت", MessageFormIcons.Warning, MessageFormButtons.Ok, Properties.Settings.Default.Color);

                txtNationalityCode.Focus(); return;
            }
            SqlParameter[] param;
            param = new SqlParameter[2];
            int index = 0;
            param[index++] = new SqlParameter("@type", 1);
            param[index++] = new SqlParameter("@NationalityCode", txtNationalityCode.Text.Trim());

            if (Convert.ToBoolean(da.ExecuteScalarSP("DeleteCustomerImage", param)))
            {
                if (pictureBox1.Image != null)
                {
                    pictureBox1.Image.Dispose();
                    pictureBox1.Image = null;
                }
                pictureBox1.Invalidate();
            }
        }

        private void button4_Click_1(object sender, EventArgs e)
        {


            if (txtNationalityCode.Text == string.Empty)
            {
                var msg = "لطفا کد ملی را وارد نمایید";
                MessageForm.Show(msg, "ثبت", MessageFormIcons.Warning, MessageFormButtons.Ok, Properties.Settings.Default.Color);

                txtNationalityCode.Focus(); return;
            }

             SqlParameter[] param;
            param = new SqlParameter[2];
            int index = 0;
            param[index++] = new SqlParameter("@DepartmentID", DepartmentID);
            param[index++] = new SqlParameter("@NationalityCode", txtNationalityCode.Text.Trim());
            DataSet nobatDS = new DataSet();
            nobatDS = da.ExecuteSP("SetIntermittenceHandly", param);
            if (Convert.ToInt32(nobatDS.Tables[0].Rows[0][0]) == -2)

            {
                var msg = "ظرفیت نوبت دهی امروز، برای بخش انتخابی تمام شده است.";
                MessageForm.Show(msg, "خطا", MessageFormIcons.Warning, MessageFormButtons.Ok, Properties.Settings.Default.Color);

                // if user choose yes we add item 
                // if setting configured by admin 


                DialogResult dialogResult = MessageBox.Show("نوبت خارج از صف", "آیا شما با ثبت این نوبت برای این بخش خارج از صف استاندارد موافق هستید؟", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    //do something
                    // متاسفانه مدیر شما موافق نیست.



                    //
                    SqlParameter[] param2;
                    param2 = new SqlParameter[2];
                    int index2 = 0;
                    param2[index2++] = new SqlParameter("@DepartmentID", DepartmentID);
                    param2[index2++] = new SqlParameter("@NationalityCode", txtNationalityCode.Text.Trim());
                    DataSet nobatDS2 = new DataSet();
                    nobatDS = da.ExecuteSP("SetIntermittenceHandlyInsert", param);

                }
                else if (dialogResult == DialogResult.No)
                {
                    //do something else
                }

           }
            else if (Convert.ToInt32(nobatDS.Tables[0].Rows[0][0]) == 1)
            {
                var msg =" نوبت در ساعت  "+nobatDS.Tables[1].Rows[0][0].ToString().Substring(0,5)+" با موفقیت ثبت شد. " ;
                MessageForm.Show(msg, "خطا", MessageFormIcons.Warning, MessageFormButtons.Ok, Properties.Settings.Default.Color);
         button4.Enabled=false;
            }
             else if (Convert.ToInt32(nobatDS.Tables[0].Rows[0][0]) == 0)
            {
                var msg ="ثبت نوبت ناموفق بود.";
                MessageForm.Show(msg, "خطا", MessageFormIcons.Warning, MessageFormButtons.Ok, Properties.Settings.Default.Color);

            }
        }

       

    }
}
