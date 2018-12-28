using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ClinicMesbah
{
    public partial class ShowAttachments : Form
    {
        public ShowAttachments()
        {
            InitializeComponent();
        }
        private string nationalityCode;
        private DataSet DS;
        private DataAccess da = new DataAccess();
        private byte formType;
        public ShowAttachments(string nationalityCode, byte formType)
        {
            InitializeComponent();
            this.nationalityCode = nationalityCode;
            this.formType = formType;
        }
    
        private void ShowAttachments_Load(object sender, EventArgs e)
        {

            if (formType == ((byte)0))
            {
                DataSet imageDS = new DataSet();
                imageDS = da.GetpationtInfo("GetCustomerImageInfo", nationalityCode);
                Byte[] imageData = new Byte[0];
                if (imageDS != null && imageDS.Tables.Count > 0 && imageDS.Tables[0].Rows.Count > 0)
                {
                    imageData = (Byte[])(imageDS.Tables[0].Rows[0]["Customerimage"]);
                    if (imageData != null)
                    {
                        MemoryStream stream = new MemoryStream(imageData); pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
                        //pictureBox1.Image = Image.FromStream(stream);
                        pictureBox1.BackgroundImage = Image.FromStream(stream);
                    }
                }
            }

            else 
            { Bitmap bmp;
                if (formType == ((byte)1))// OPEN DOCTOR
                 bmp = new Bitmap(Properties.Resources._1);
                    else if (formType == ((byte)2))//CLOSE APP
                 bmp = new Bitmap(Properties.Resources._0);
                 else  if (formType == ((byte)3))// CLOSE DOCTOR
                 bmp = new Bitmap(Properties.Resources.check);//OPEN APP
                else   bmp = new Bitmap(Properties.Resources._1422945227_Delete);
                using (Graphics g = Graphics.FromImage(bmp))
                {
                    g.Clear(pictureBox1.BackColor);
                }
                pictureBox1.Image = bmp;
               
               pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
                        //pictureBox1.Image = Image.FromStream(stream);
                    
                
            }
        }
       
    }
}
