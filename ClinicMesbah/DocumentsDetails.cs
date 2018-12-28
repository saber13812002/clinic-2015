using MesbahComponent;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ClinicMesbah
{
    public partial class DocumentsDetails : Form
    {
        public string _mobileNumber;
        private Color color;
        private string nasionalityCode; private string TelORMobile;
        DataAccess da = new DataAccess();
        public DocumentsDetails(string nasionalityCode)
        {
           
            InitializeComponent(); 
            
            this.nasionalityCode = nasionalityCode;
        }
        private void setcolor()
        {
            color = Properties.Settings.Default.Color;
            this.BackColor = ControlPaint.LightLight(ControlPaint.LightLight((ControlPaint.LightLight(color))));
            button2.BackColor = color;
        }
        private void DocumentsDetails_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
            setcolor();
        }

        private void gbInsertCenter_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter_1(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {


     //        SqlParameter[] param;
     //       param = new SqlParameter[40];
     //       int index = 0;
     //       param[index++] = new SqlParameter("@Doctor", );
     //       param[index++] = new SqlParameter("@Feild", );
     //       param[index++] = new SqlParameter("@age", );
     //       param[index++] = new SqlParameter("@general", );
     //       param[index++] = new SqlParameter("@job", );
     //       param[index++] = new SqlParameter("@unitLiving", );
     //       param[index++] = new SqlParameter("@bloodpresure", );
     //       param[index++] = new SqlParameter("@diyabet", );
     //       param[index++] = new SqlParameter("@kabedi", );
     //       param[index++] = new SqlParameter("@posti", );
     //       param[index++] = new SqlParameter("@jarahi", );
     //       param[index++] = new SqlParameter("@hiv", );
     //       param[index++] = new SqlParameter("@riyavi", );
     //       param[index++] = new SqlParameter("@pokitokhan", );
     //       param[index++] = new SqlParameter("", );
     //       param[index++] = new SqlParameter("", );
     //       param[index++] = new SqlParameter("", );
     //       param[index++] = new SqlParameter("", );
     //       param[index++] = new SqlParameter("", );
     //       param[index++] = new SqlParameter("", );
     //       param[index++] = new SqlParameter("", );
     //       param[index++] = new SqlParameter("", );
     //       param[index++] = new SqlParameter("", );
     //       param[index++] = new SqlParameter("", );
     //       param[index++] = new SqlParameter("", );
     //       param[index++] = new SqlParameter("", );
     //       param[index++] = new SqlParameter("", );
     //       param[index++] = new SqlParameter("", );
     //       param[index++] = new SqlParameter("", );
     //       param[index++] = new SqlParameter("", );

     //       DataSet ds = new DataSet();

     //   bit  =NULL,
     //   bit = NULL,
     //   bit  =NULL,
     //   bit  =NULL,
     //   bit = NULL,
     //   bit  =NULL,
     //   bit = NULL,
     //@alerji   bit  =NULL,
     //@govareshi   bit  =NULL,
     //@tiroeid   bit  =NULL,
     //@mafasel   bit = NULL,
     //@kolyavi   bit = NULL,
     //@asabravan   bit = NULL,
     //@ghalbi   bit = NULL,
     //@cheshm   bit = NULL,
     //@halghobini   bit  =NULL,
     //@Otherill   NVARCHAR(500) =NULL,
     //@RR   nvarchar (20) =NULL,
     //@HR   nvarchar (20) =NULL,
     //@OT   nvarchar (20) =NULL,
     //@BP   nvarchar (20) =NULL,
     //@BW   nvarchar (20) =NULL,
     //@shekayatasli   nvarchar (1000) =NULL,
     //@alayemhengammoeje   nvarchar (1000)= NULL,
     //@baliniavaliye   nvarchar (1000)= NULL,
     //@azmayeshat   nvarchar (1000)= NULL,
     //@sonografi   nvarchar (1000) =NULL,
     //@andoskopi   nvarchar (1000)= NULL,
     //@anjografi   nvarchar (1000) =NULL,
     //@patoloji   nvarchar (1000)= NULL,
     //@kolonoskopi   nvarchar (1000) =NULL,
     //@laproskopi   nvarchar (1000)= NULL,
     //@moshavere   nvarchar (1000) =NULL,
     //@tajvizdaro   nvarchar (1000)= NULL,
     //@NationalityCode   nvarchar (10) =NULL

















     //       int result = da.ExecuteScalarSP("SetCostumerInfo", 
                
              
                
     //           );
               
     //       if (result > 0)
     //       {
     //           var msg = "ثبت با موفقیت انجام شد";
     //           MessageForm.Show(msg, "ثبت", MessageFormIcons.Info, MessageFormButtons.Ok, Properties.Settings.Default.Color);


     //           txtAdress.Enabled = false;
     //           txtFather.Enabled = false;
     //           txtisurance.Enabled = false;
     //           txtLastName.Enabled = false;
     //           txtMobile.Enabled = false;
     //           txtName.Enabled = false;
     //           txtTel.Enabled = false;
     //           txtNationalityCode.Enabled = false;
     //           button2.Enabled = false;

     //       }
     //       else
     //       {
     //           var msg = "ثبت ناموفق بود";
     //           MessageForm.Show(msg, "ثبت", MessageFormIcons.Warning, MessageFormButtons.Ok, Properties.Settings.Default.Color);

     //           timer1.Start();
     //       }
        }
    }
}
