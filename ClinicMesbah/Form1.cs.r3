﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MesbahComponent;
using MesbahComponent.Grid;
using System.Threading;
using System.Media;
using System.Text.RegularExpressions;
using System.Data.SqlClient;
using System.Timers;

namespace ClinicMesbah
{
    public partial class Form1 : Form
    {
        //private ToolStripMenuItem menuActiveRight;
       // private ToolStripMenuItem menuActiveTop;

        public short DepartmentSelected;

        #region Variables 
       // DataTable dt = new DataTable();
        List<DataMesbah> lst = new List<DataMesbah>();
        public static SystemSound Beep { get; set; }
        private short DepartmentID = 0;
        private DataSet DepartementInfo = new DataSet();
        private DataSet sectionDS = new DataSet();
        private Byte witchDay;
        private ToolStripMenuItem menuActiveRight;
        private ToolStripMenuItem menuActiveTop;
        private DataTable dt = new DataTable();
        private DataTable smsDt = new DataTable();
        bool sentsms = false;
        public string IDs = "";
        private DataAccess da = new DataAccess();
        public string _mobileNumber;
        private List<Patient> patientList = new List<Patient>();
        private Patient patient = new Patient();
        private byte status = 0;//0=sms, 1= tel
        private int columnCount;
        //private short DepartmentID;
        private float IndexSortOld;
        private float IndexSortNew;
        public DataSet GridDataSource;
        private List<String> columnsKey;
        private bool showdeleteDialogbox = true; private bool exchangeclicked = false;
        private bool haveChekBoxColumn;
        public bool pasteRow;
        private bool rowsSelectedForCopy;
        private bool rowSelectedForCopy;
        private int startime;
        private int endtime;
        private Color backColor;
        private int steps=1;

        private bool todaytelephon=true;
        private bool todaySMS = true;
        private bool todayagainConnect = true;
        private bool todayfinalyTry = true;

        private bool tomarowtelephon = true;
        private bool tomarowSMS = true;
        private bool tomarowagainConnect = true;
        private bool tomarowfinalyTry = true;
        #endregion
        
        public Form1()
        {
            InitializeComponent();
            SelectMenuRight(MenuItem1ToolStripMenuItem);
            SelectMenuTop(MenuTop4ToolStripMenuItem);
           //dt.Columns.Add(CustomerCol.Name);
            //dt.Columns.Add(NumberCol.Name);
            //dt.Columns.Add(StateCol.Name);
            //dt.Rows.Add("مهدی احمدیان", "09194568941", "");
            //dt.Rows.Add("صابر طبابایی", "09191651665", "");
            //dt.Rows.Add("علی احمدی", "09123356546", "");
            //dt.Rows.Add("امیر نیازی", "09356946665", "");
            //dt.Rows.Add("مجتبی لاجوردی", "0910158646", "");
            //dt.Rows.Add("محسن هاشمی", "093665464646", "");
            //dt.Rows.Add("مرتضی موحدی", "0910158646", "");
            //dt.Rows.Add("مصطفی رفیعی", "093665464646", "");
            //SMSDataGridView.DataSource = dt;
            ////var s= lst.Select(a => a.Id);
            ////Thread s = new Thread(() => { MessageBox.Show("asdadasd"); });
            //lst.Add(new DataMesbah { CustomerName = "مهدی احمدیان", CustomerNumber = "09194568941", Id = 0, Time = "05:00" });
            //lst.Add(new DataMesbah { CustomerName = "صابر طبابایی", CustomerNumber = "09191651665", Id = 0, Time = "05:00" });
            //lst.Add(new DataMesbah { CustomerName = "علی احمدی", CustomerNumber = "09123356546", Id = 0, Time = "06:00" });
            //lst.Add(new DataMesbah { CustomerName = "امیر نیازی", CustomerNumber = "09356946665", Id = 0, Time = "06:00" });
            //lst.Add(new DataMesbah { CustomerName = "مجتبی لاجوردی", CustomerNumber = "0910158646", Id = 0, Time = "07:00" });
            //lst.Add(new DataMesbah { CustomerName = "محسن هاشمی", CustomerNumber = "093665464646", Id = 0, Time = "07:00" });
            //lst.Add(new DataMesbah { CustomerName = "مرتضی موحدی", CustomerNumber = "09195464646", Id = 0, Time = "07:00" });
            //lst.Add(new DataMesbah { CustomerName = "مصطفی رفیعی", CustomerNumber = "09198951656", Id = 0, Time = "05:00" });
            ////اگر در یک ساعتی هیچ آی دی مقدار داری وجود نداشته باشد آن ردیف خالی نمایش داده  می شود
            //lst.Add(new DataMesbah { CustomerName = "مصطفی رفیعی", CustomerNumber = "09198951656", Id = null, Time = "09:00" });
            //lst.Add(new DataMesbah { CustomerName = "مصطفی رفیعی", CustomerNumber = "09198951656", Id = null, Time = "09:00" });
            //gridMesbah1.DataSource = lst;

            //colorBox1.ColorActive = Color.SteelBlue;
        }

        private void checkForTime_Elapsed(object sender, ElapsedEventArgs e)
        {
           // throw new NotImplementedException();
            //if(tim)
        }

        private void colorBox1_ColorChange(Color color)
        {
            Properties.Settings.Default.Color = color;
            //   Properties.Settings.Default.GridText = dataGridView1.Rows[0].Cells[0].Value.ToString();
        
           
           // Color C = Properties.Settings.Default.myColor;
            TopPanelWithBorder.BorderColor = color;
            BottomPanelWithBorder.BorderColor = color;
            RightPanelWithBorder.BorderColor = color;
            MenuRightPanelWithBorder.BorderColor = color;
            SendSMSPanelWithBorder.BorderColor = color;
            ColorCheckBox.BackColor = color;
            menuActiveRight.BackColor = color;
            menuActiveTop.BackColor = color;
            SendSMSButton.BackColor = color;
            SMSDataGridView.ColumnHeadersDefaultCellStyle.BackColor = color;
            SMSDataGridView.RowsDefaultCellStyle.SelectionBackColor = ControlPaint.LightLight(color);
            SMSDataGridView.AlternatingRowsDefaultCellStyle.BackColor = ControlPaint.LightLight(ControlPaint.LightLight(ControlPaint.LightLight(ControlPaint.LightLight(color))));
            button1.BackColor = color;
            button2.BackColor = color;
            button3.BackColor = color;
            btnToday.BackColor = color;
            btnTomarow.BackColor = color;
            //button4.BackColor = color;
            //button5.BackColor = color;
            //button6.BackColor = color;
            gridMesbah1.RowsBorderColor = color;
            gridMesbah1.CellsBorderColor = ControlPaint.Dark(color);
            gridMesbah1.CellsForColor = ControlPaint.DarkDark(color);
            gridMesbah1.CellsButtonColor = color;
            SendSMSColorProgressBar.BarColor = ControlPaint.LightLight(color);
        }

        private void colorBox1_Leave(object sender, EventArgs e)
        {
            ColorCheckBox.Checked = false;
          //  Properties.Settings.Default.myColor = Color.AliceBlue;
         //   Properties.Settings.Default.GridText = dataGridView1.Rows[0].Cells[0].Value.ToString();

          //  Properties.Settings.Default.Save();
        }

        private void ColorCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            colorBox1.Visible=panel4.Visible = ColorCheckBox.Checked;
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            button1.Image = Properties.Resources.Dental;
            button1.Text = string.Empty;
        }

        private void button2_MouseEnter(object sender, EventArgs e)
        {
            button2.Image = Properties.Resources.GREY;
            button2.Text = string.Empty;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.Image = null;
           button1.Text = "داروخانه";
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            button2.Image = null;
            button2.Text = "پزشک";
        }

        private void MenuItem1ToolStripMenuItem_MouseEnter(object sender, EventArgs e)
        {
            Cursor = System.Windows.Forms.Cursors.Hand;
        }

        private void MenuItem1ToolStripMenuItem_MouseLeave(object sender, EventArgs e)
        {
            Cursor = System.Windows.Forms.Cursors.Default;
        }

        private void MenuItem1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SelectMenuRight(MenuItem1ToolStripMenuItem);
        }

        private void MenuItem2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SelectMenuRight(MenuItem2ToolStripMenuItem);
        }

        private void MenuItem3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SelectMenuRight(MenuItem3ToolStripMenuItem);
        }

        private void MenuItem4ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SelectMenuRight(MenuItem4ToolStripMenuItem);
        }

        private void SelectMenuRight(ToolStripMenuItem menuItem)
        {
            MenuItem1ToolStripMenuItem.Checked = false;
            MenuItem2ToolStripMenuItem.Checked = false;
            MenuItem3ToolStripMenuItem.Checked = false;
            MenuItem4ToolStripMenuItem.Checked = false;
            MenuItem1ToolStripMenuItem.BackColor = Color.Transparent;
            MenuItem2ToolStripMenuItem.BackColor = Color.Transparent;
            MenuItem3ToolStripMenuItem.BackColor = Color.Transparent;
            MenuItem4ToolStripMenuItem.BackColor = Color.Transparent;
            MenuItem1ToolStripMenuItem.ForeColor = Color.Black;
            MenuItem2ToolStripMenuItem.ForeColor = Color.Black;
            MenuItem3ToolStripMenuItem.ForeColor = Color.Black;
            MenuItem4ToolStripMenuItem.ForeColor = Color.Black;
            menuItem.Checked = true;
            menuItem.BackColor = colorBox1.ColorActive;
            menuItem.ForeColor = Color.White;
            menuActiveRight = menuItem;
        }

        private void SelectMenuTop(ToolStripMenuItem menuItem)
        {
            MenuTop1ToolStripMenuItem.Checked = false;
            MenuTop2ToolStripMenuItem.Checked = false;
            MenuTop3ToolStripMenuItem.Checked = false;
            MenuTop4ToolStripMenuItem.Checked = false;
            MenuTop1ToolStripMenuItem.BackColor = Color.Transparent;
            MenuTop2ToolStripMenuItem.BackColor = Color.Transparent;
            MenuTop3ToolStripMenuItem.BackColor = Color.Transparent;
            MenuTop4ToolStripMenuItem.BackColor = Color.Transparent;
            MenuTop1ToolStripMenuItem.ForeColor = Color.Black;
            MenuTop2ToolStripMenuItem.ForeColor = Color.Black;
            MenuTop3ToolStripMenuItem.ForeColor = Color.Black;
            MenuTop4ToolStripMenuItem.ForeColor = Color.Black;
            menuItem.Checked = true;
            menuItem.BackColor = colorBox1.ColorActive;
            menuItem.ForeColor = Color.White;
            menuActiveTop = menuItem;
        }

        private void MenuTop1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
           steps = 3;
            SendSMSButton.Text = "اتمام ارتباط دوباره ";
            //SendSMSButton.Tag = 3;
            
            status =3;
            DataSet IntermittenceDS = new DataSet();
            IntermittenceDS = da.ExecuteCommand("GetTelSecodTime", DepartmentID, witchDay);
            GridSetTel();
            FillTelGrid(IntermittenceDS);
            SelectMenuTop(MenuTop1ToolStripMenuItem);
            //if (againConnect == false)
            //    SMSDataGridView.Enabled= false;
           //  if (steps != 3) SendSMSButton.Enabled = false; else SendSMSButton.Enabled = true;
            if (witchDay == 0)
            {
                SMSDataGridView.Enabled = todayagainConnect;
                SendSMSButton.Enabled = todayagainConnect;

                if (todayagainConnect) SMSDataGridView.BackgroundColor = Color.White; else SMSDataGridView.BackgroundColor = Color.LightGray;
            }
            if (witchDay ==1)
            {
                SMSDataGridView.Enabled = tomarowagainConnect;
                SendSMSButton.Enabled = tomarowagainConnect;

                if (tomarowagainConnect) SMSDataGridView.BackgroundColor = Color.White; else SMSDataGridView.BackgroundColor = Color.LightGray;
            }
        }

        private void MenuTop2ToolStripMenuItem_Click(object sender, EventArgs e)
        { 
            steps = 4;
            SendSMSButton.Text = "قطعی کردن کلی";
            SendSMSButton.Tag = 4;
            //SelectMenuTop(MenuTop2ToolStripMenuItem);
            //status = 0;
            //int result = da.Insert("SetSmsInfo", IDs);
            //if (result == 1)
            //    MessageBox.Show("sms Sent");
            //else if (result == -2)
            //    MessageBox.Show("Failed");
            //DataSet IntermittenceDS = new DataSet();
            //IntermittenceDS = da.ExecuteCommand("", DepartmentID, witchDay);
            //// grdDecisive.GridDataSource = null;
            //// grdDecisive = new UserControlGridIn();

            //GridSetTel();
            //FillTelGrid(IntermittenceDS);
            
            status = 3;
            DataSet IntermittenceDS = new DataSet();
            IntermittenceDS = da.ExecuteCommand("GetTelSecodTime", DepartmentID, witchDay);
            GridSetTel();
            FillTelGrid(IntermittenceDS);
            SelectMenuTop(MenuTop2ToolStripMenuItem);
            //if (finalyTry == false)
            //    SMSDataGridView.Enabled = false;
            // if (steps != 4) SendSMSButton.Enabled = false; else SendSMSButton.Enabled = true;

            if (witchDay == 0)
            {
                SMSDataGridView.Enabled = todayfinalyTry;
                SendSMSButton.Enabled = todayfinalyTry;
                if (todayfinalyTry) SMSDataGridView.BackgroundColor = Color.White; else SMSDataGridView.BackgroundColor = Color.LightGray;
            }
            if (witchDay == 1)
            {
                SMSDataGridView.Enabled =tomarowfinalyTry;
                SendSMSButton.Enabled = tomarowfinalyTry;
                if (tomarowfinalyTry) SMSDataGridView.BackgroundColor = Color.White; else SMSDataGridView.BackgroundColor = Color.LightGray;
         
            }
        }

        private void MenuTop3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            steps = 2;
            SendSMSButton.Text = "اتمام تماس ها ";
      
            
            status = 1;
            DataSet IntermittenceDS = new DataSet();
            IntermittenceDS = da.ExecuteCommand("GetTelFirstTime", DepartmentID, witchDay);
            GridSetTel();
            FillTelGrid(IntermittenceDS);
            SelectMenuTop(MenuTop3ToolStripMenuItem);
           //if (telephon == false)
           //    SMSDataGridView.Enabled = false; //if (steps != 2) SendSMSButton.Enabled = false; else SendSMSButton.Enabled = true;

            if (witchDay == 0)
            {
                SMSDataGridView.Enabled = todaytelephon;
                SendSMSButton.Enabled = todaytelephon;
                if (todaytelephon) SMSDataGridView.BackgroundColor = Color.White; else SMSDataGridView.BackgroundColor = Color.LightGray;
            }
            if (witchDay == 1)
            {
                SMSDataGridView.Enabled = tomarowtelephon;
                SendSMSButton.Enabled = tomarowtelephon;
                if (tomarowtelephon) SMSDataGridView.BackgroundColor = Color.White; else SMSDataGridView.BackgroundColor = Color.LightGray;
           
            }
        }

        private void MenuTop4ToolStripMenuItem_Click(object sender, EventArgs e)// تماس دوباره
        {
            SendSMSButton.Text = "ارسال پیامک ها";
      
            steps = 1;
            status = 0;
            DataSet IntermittenceDS = new DataSet();
            IntermittenceDS = da.ExecuteCommand("GetTelFirstTime", DepartmentID, witchDay);
            GridSetTel();
            FillTelGrid(IntermittenceDS);
            SelectMenuTop(MenuTop4ToolStripMenuItem);
           
            //SelectMenuTop(MenuTop4ToolStripMenuItem);
            //SendSMSButton.Visible = Convert.ToBoolean(da.GetColumnCount("getSentStatus", DepartmentID));

            //status = 0;
            //int result = da.Insert("SetSmsInfo", IDs);
            //if (result == 1)
            //    MessageBox.Show("sms Sent");
            //else if (result == -2)
            //    MessageBox.Show("Failed");
            //DataSet IntermittenceDS = new DataSet();
            //IntermittenceDS = da.ExecuteCommand("", DepartmentID, witchDay);
            //GridSetTel();
            //FillTelGrid(IntermittenceDS);
            //if (SMS == false)
            if (witchDay == 0)
            {
                SMSDataGridView.Enabled = todaySMS;
                SendSMSButton.Enabled = todaySMS;
                if (todaySMS) SMSDataGridView.BackgroundColor = Color.White; else SMSDataGridView.BackgroundColor = Color.LightGray;
            }
            if (witchDay ==1)
            {
                SMSDataGridView.Enabled = tomarowSMS;
                SendSMSButton.Enabled = tomarowSMS;
                if (tomarowSMS) SMSDataGridView.BackgroundColor = Color.White; else SMSDataGridView.BackgroundColor = Color.LightGray;
            }
        }

        private void FillTelGrid(DataSet IntermittenceDS)
        {
           
            smsDt.Rows.Clear();
            if (SMSDataGridView.Rows.Count > 0)
                SMSDataGridView.Rows.Clear();
            if (SMSDataGridView.DataSource != null)
                smsDt = (DataTable)SMSDataGridView.DataSource;

            foreach (DataRow row in IntermittenceDS.Tables[0].Rows)
            {

                if ((status == 0 && IsMobileNumberValid(row["Telphone"].ToString())) || (status == 1 && !IsMobileNumberValid(row["Telphone"].ToString())) || status == 3)
                {
                    DataRow dr = smsDt.Rows.Add();
                    dr["ID"] = (row["ID"]);
                    dr["TimeCol"] = PersianDate.GetPersianDate(
                    Convert.ToDateTime(row["VisitDateTime"])).TimeOfDay.ToString().Substring(0,5);
                    dr["CustomerCol"] = row["NationalityCode"];
                    dr["NumberCol"] = row["Telphone"];
                    dr["StateCol"] = Convert.ToBoolean(row["Status"]);
                    dr["SectionCol"] = row["DepartmentName"];
                    Int32 index = SMSDataGridView.Rows.Count - 1;
                    SMSDataGridView.Rows[index].Tag = row;
                }

            }
            SMSDataGridView.DataSource = smsDt;
            StyleSMSGrid();
            SMSDataGridView.Columns["StateCol"].Visible = status == 0 ? false : true;
            SMSDataGridView.Columns["ID"].Visible = false;
            foreach (DataGridViewRow Row in SMSDataGridView.Rows)
            {
                if (Convert.ToBoolean(Row.Cells["StateCol"].Value))
                {
                    Row.DefaultCellStyle.BackColor = Color.LightGreen;
                    Row.ReadOnly = true;
                }
            }
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

        private void SendSMSButton_Click(object sender, EventArgs e)
        {
            if (steps == 1)
            {
            if (SendSMSColorProgressBar.Value == 100) 
                SendSMSColorProgressBar.Value = 0;
               
                SendSMS();
                SendSMSButton.Text = "ارسال شد";
                if (witchDay == 0)
                {
                    MenuTop4ToolStripMenuItem.Enabled= todaySMS = false;
                    MenuTop1ToolStripMenuItem.Enabled = todayagainConnect = false;
                    MenuTop3ToolStripMenuItem.Enabled = todaytelephon = true;
                    MenuTop2ToolStripMenuItem.Enabled = todayfinalyTry = false;
                }
                if (witchDay == 1)
                {
                    MenuTop4ToolStripMenuItem.Enabled = tomarowSMS = false;
                    MenuTop1ToolStripMenuItem.Enabled = tomarowagainConnect = false;
                    MenuTop3ToolStripMenuItem.Enabled = tomarowtelephon = true;
                    MenuTop2ToolStripMenuItem.Enabled = tomarowfinalyTry = false;
                }
            }
            if (steps == 2)
            {
                if (witchDay == 0)
                {
                    todaySMS = false;
                }
                if (witchDay ==1)
                {
                    tomarowSMS = false;

                }
                SendSMSButton.Enabled = SMSDataGridView.Enabled = false;
                SMSDataGridView.BackgroundColor = Color.LightGray;


                if (witchDay == 0)
                {
                    MenuTop4ToolStripMenuItem.Enabled = todaySMS = false;
                    MenuTop1ToolStripMenuItem.Enabled = todayagainConnect = true;
                    MenuTop3ToolStripMenuItem.Enabled = todaytelephon = false;
                    MenuTop2ToolStripMenuItem.Enabled = todayfinalyTry = false;
                }
                if (witchDay == 1)
                {
                    MenuTop4ToolStripMenuItem.Enabled = tomarowSMS = false;
                    MenuTop1ToolStripMenuItem.Enabled = tomarowagainConnect = true;
                    MenuTop3ToolStripMenuItem.Enabled = tomarowtelephon = false;
                    MenuTop2ToolStripMenuItem.Enabled = tomarowfinalyTry = false;
                }
            }
            if (steps == 3)
            { 
                //againConnect = false;
                if (witchDay == 0)
                {
                    todayagainConnect = false;
                }
                if (witchDay == 1)
                {
                    tomarowagainConnect = false;

                }

                SendSMSButton.Enabled = SMSDataGridView.Enabled = false;
                SMSDataGridView.BackgroundColor = Color.LightGray;
 

                if (witchDay == 0)
                {
                    MenuTop4ToolStripMenuItem.Enabled = todaySMS = false;
                    MenuTop1ToolStripMenuItem.Enabled = todayagainConnect = false;
                    MenuTop3ToolStripMenuItem.Enabled = todaytelephon = false;
                    MenuTop2ToolStripMenuItem.Enabled = todayfinalyTry = true;
                }
                if (witchDay == 1)
                {
                    MenuTop4ToolStripMenuItem.Enabled = tomarowSMS = false;
                    MenuTop1ToolStripMenuItem.Enabled = tomarowagainConnect = false;
                    MenuTop3ToolStripMenuItem.Enabled = tomarowtelephon = false;
                    MenuTop2ToolStripMenuItem.Enabled = tomarowfinalyTry = true;
                }


                //SMS = false;
                //againConnect = false;
                //telephon = false;
                //finalyTry = true;

            }
            if (steps == 4)
            {

                if (witchDay == 0)
                {
                    todayfinalyTry = false;
                }
                if (witchDay == 1)
                {
                    tomarowfinalyTry = false;

                }
                //finalyTry = false;
                SendSMSButton.Enabled = SMSDataGridView.Enabled = false;
                SMSDataGridView.BackgroundColor = Color.LightGray;
       
                for (int i = 0; i < SMSDataGridView.Rows.Count; i++)
                {
                    int result1 = 0;
                    result1 = da.UpdateIntermittence("SetDecisiveIntermittence", Convert.ToInt32(((DataRow)SMSDataGridView.Rows[i].Tag)["ID"]), true);
                }
                GridSet();
                FillGrid();
                GridSetTel();

                if (witchDay == 0)
                {
                    MenuTop4ToolStripMenuItem.Enabled = todaySMS = false;
                    MenuTop1ToolStripMenuItem.Enabled = todayagainConnect = false;
                    MenuTop3ToolStripMenuItem.Enabled = todaytelephon = false;
                    MenuTop2ToolStripMenuItem.Enabled = todayfinalyTry = false;
                }
                if (witchDay == 1)
                {
                    MenuTop4ToolStripMenuItem.Enabled = tomarowSMS = false;
                    MenuTop1ToolStripMenuItem.Enabled = tomarowagainConnect = false;
                    MenuTop3ToolStripMenuItem.Enabled = tomarowtelephon = false;
                    MenuTop2ToolStripMenuItem.Enabled = tomarowfinalyTry = false;
                }


                //SMS = false;
                //againConnect = false;
                //telephon = false;
                //finalyTry = false;
                
            }
        }

        private void SendSMS()
        {
            string IDs = "";
            foreach (DataRow dr in smsDt.Rows)
              IDs+=','+  dr["ID"].ToString();
                  
            int result = da.Insert("SetSmsInfo", IDs);
            if (result == 1)
            // MessageBox.Show("sms Sent");
            {
                SendSMSColorProgressBar.Value = 0;// smsDt.Rows.Count;
                timer1.Enabled = !timer1.Enabled;
                SendSMSButton.Enabled = SMSDataGridView.Enabled = false;
                SMSDataGridView.BackgroundColor = Color.LightGray;
                if (witchDay == 0)
                {
                    todaySMS = false;
                }
                if (witchDay == 1)
                {
                    tomarowSMS = false;

                }
                //SMS = false;
            }
            else if (result == -2)
                MessageBox.Show("در روند ارسال خطایی رخ داده"); 
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (SendSMSColorProgressBar.Value == 100)
            {
                timer1.Enabled = false;
                return;
            }
            SendSMSColorProgressBar.Value += CheckSentSms();
        }

        private int CheckSentSms()
        {
             return Convert.ToInt32(da.ExecuteCommand("GetSentSmsCount").Tables[0].Rows[0][0]);
        }
        #region Info
        public class Patient
        {
            public string nationalID;
            public string name;
            public byte index;
            public byte status;
            public PersianDate date;
            public int departmentID;
            public Patient()
            { }
            public Patient(string nationalID, byte index, string name, byte status, PersianDate date, int departmentID)
            {
                this.nationalID = nationalID;
                this.index = index;
                this.name = name;
                this.status = status;
                this.date = date;
                this.departmentID = DepartmentID;

            }
            public Patient(byte index, string name, byte status)
            {

                this.index = index;
                this.name = name;
                this.status = status;

            }

            public string NationalID
            {
                get { return nationalID; }
                set { nationalID = value; }
            }

            public byte Index
            {
                get { return index; }
                set { index = value; }
            }

            public string Name
            {
                get { return name; }
                set { name = value; }
            }

            public byte Status
            {
                get { return status; }
                set { status = value; }
            }
            public PersianDate Date
            {
                get { return date; }
                set { date = value; }
            }
            public int DepartmentID
            {
                get { return departmentID; }
                set { departmentID = value; }
            }

        }
        #endregion
        private void gridMesbah1_CellClickAdd(object sender, GridMesbahCellEventArgs e)
        {
            //var msg = "ttachAdd= RowIndex:" + e.RowIndex.ToString() + " CellIndex:" + e.CellIndex.ToString() + " Id:" + (sender as CellGrid).Id.ToString();
            //MessageForm.Show(msg, (sender as CellGrid).CustomerName, MessageFormIcons.Info, MessageFormButtons.Ok, colorBox1.ColorActive);
            string nationalityCode = gridMesbah1.Rows[e.RowIndex - 1].Cells[e.CellIndex - 1].Id.ToString();
            string TELOrMobile= gridMesbah1.Rows[e.RowIndex - 1].Cells[e.CellIndex - 1].CustomerNumber.ToString();
            Document document = new Document("0" + nationalityCode, TELOrMobile);

            document.Load += delegate
            {
                document.Location = new Point(MousePosition.X-500, MousePosition.Y);
            };
            document.ShowDialog();
            GridSet();
            FillGrid();
        }
        #region GridSet
        private void GridSet()
        {

        }

        private void GridSetTel()
        {
            //SMSDataGridView.DataSource = null;
            dt = new DataTable();

            dt.Columns.Add(ID.Name);
            dt.Columns.Add(TimeCol.Name);
            dt.Columns.Add(CustomerCol.Name);
            dt.Columns.Add(NumberCol.Name);
            dt.Columns.Add(StateCol.Name);
            dt.Columns.Add(SectionCol.Name);
            SMSDataGridView.DataSource = dt;
        }


        #endregion

        #region FillMenu
        private void FillMenu()
        {
            menuStrip1.Items.Clear();
            int i = 0;
            ToolStripMenuItem[] items = new ToolStripMenuItem[sectionDS.Tables[0].Rows.Count]; // You would obviously calculate this value at runtime
            foreach (DataRow Row in sectionDS.Tables[0].Rows)
            {
                items[i] = new ToolStripMenuItem();
                items[i].Name = "Item" + i.ToString();
                items[i].Tag = Row["DepartmentID"];
                items[i].Text = Row["DepartmentName"].ToString();
                items[i].Click += new EventHandler(MenuItemClickHandler);
                menuStrip1.Items.Add(items[i]);
                i++;
            }

          //  MenuItemClickHandler(null, null);

        }

        private void MenuItemClickHandler(object sender, EventArgs e)
        {
          
            ToolStripMenuItem clickedItem = (ToolStripMenuItem)sender;
            DepartmentID = Convert.ToInt16(clickedItem.Tag);
            SqlParameter[] param;
            param = new SqlParameter[1];
            int index = 0;

            if (DepartmentSelected != null)
                if (DepartmentSelected != DepartmentID)
                {
                    param[index++] = new SqlParameter("@DepartementId", DepartmentID);
                    DepartementInfo = da.ExecuteCommand("GetDepartementInfo", DepartmentID);
                    if (DepartementInfo.Tables[0].Rows.Count > 0)
                    {
                        startime = DepartementInfo.Tables[0].Rows[0]["StartTime"].ToString() != "" ? Convert.ToInt16(DepartementInfo.Tables[0].Rows[0]["StartTime"].ToString()) : 0;
                        endtime = DepartementInfo.Tables[0].Rows[0]["EndTime"].ToString() != "" ? Convert.ToInt16(DepartementInfo.Tables[0].Rows[0]["EndTime"].ToString()) : 0;
                    }

                    FillGrid();
                    DepartmentSelected = DepartmentID;
                }
        }
        #endregion
        #region FillGrid
        private void FillGrid()
        {

            DataSet PatientCalanderDS = new DataSet();
            PatientCalanderDS = da.ExecuteCommand("GetCalendar", DepartmentID, witchDay);
            patientList = new List<Patient>();
            dt = new DataTable();
            gridMesbah1.DataSource = null;
            List<DataMesbah> lst = new List<DataMesbah>();
            
            foreach (DataRow Row in PatientCalanderDS.Tables[0].Rows)
            {
                int? id = 0;
                if(Row["NationalityCode"]!=null)
                    id = Convert.ToInt32((Row["NationalityCode"]));
                //DateTime d = Convert.ToDateTime((Row["Time"]));
                //if(d<)
                lst.Add(new DataMesbah { CustomerName = Row["Fname"].ToString() + " " + Row["Lname"].ToString(), CustomerNumber = Row["Telphone"].ToString(), Id = id, Time = ((System.DateTime)Row["Date"]).Hour.ToString()});// + ":" + ((System.DateTime)Row["Date"]).Minute.ToString()).ToString() });
                
            }
          
           gridMesbah1.DataSource = lst;

         //  colorBox1_ColorChange(colorBox1.ColorActive);
         //  backColor = colorBox1.ColorActive;
        }

        #endregion
        private void gridMesbah1_CellClickAttach(object sender, GridMesbahCellEventArgs e)
        {
            //var msg = "Attach= RowIndex:" + e.RowIndex.ToString() + " CellIndex:" + e.CellIndex.ToString() + " Id:" + (sender as CellGrid).Id.ToString();
            //MessageForm.Show(msg, (sender as CellGrid).CustomerName, MessageFormIcons.Info, MessageFormButtons.Ok, colorBox1.ColorActive);
        
        }

        private void gridMesbah1_CellClickDelete(object sender, GridMesbahCellEventArgs e)
        {
            //var msg = "Delete= RowIndex:" + e.RowIndex.ToString() + " CellIndex:" + e.CellIndex.ToString() + " Id:" + (sender as CellGrid).Id.ToString();
            //MessageForm.Show(msg, (sender as CellGrid).CustomerName, MessageFormIcons.Info, MessageFormButtons.Ok, colorBox1.ColorActive);

            var msg = "لغو نوبت بیمار مورد نظر تایید شد."; MessageForm.Show(msg, (sender as CellGrid).CustomerName, MessageFormIcons.Info, MessageFormButtons.Ok, colorBox1.ColorActive);
       
            gridMesbah1.Rows[e.RowIndex].Cells[e.CellIndex].BackColor = Color.Red;
        }

        private void gridMesbah1_CellClickForward(object sender, GridMesbahCellEventArgs e)
        {
            //var msg = "Forward= RowIndex:" + e.RowIndex.ToString() + " CellIndex:" + e.CellIndex.ToString() + " Id:" + (sender as CellGrid).Id.ToString();
            //MessageForm.Show(msg, (sender as CellGrid).CustomerName, MessageFormIcons.Info, MessageFormButtons.Ok, colorBox1.ColorActive);
            gridMesbah1.Rows[e.RowIndex-1].Cells[e.CellIndex-1].BackColor = Color.Gray;
            var msg = "ویزیت بیمار مورد نظر تایید شد."; MessageForm.Show(msg, (sender as CellGrid).CustomerName, MessageFormIcons.Info, MessageFormButtons.Ok, colorBox1.ColorActive);
       
        }

        private void button1_Click(object sender, EventArgs e)
        {


            //if (gridMesbah1.Rows.Count == 0) return;حذف یک سطر
            //gridMesbah1.Rows.Remove(0);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //gridMesbah1.Rows.Add();اضافه کردن یک سطر
            //gridMesbah1.Rows[gridMesbah1.Rows.Count - 1].Time = "07:50";
            //gridMesbah1.DataSource = lst; پرکردن تقویم
            //colorBox1_ColorChange(colorBox1.ColorActive);//این خط برای حفظ استایل هست که در نسخه ی بعدی یرطرف گشته و نیازی نیست
       }

        private void button3_Click(object sender, EventArgs e)
        {
            Form set = new Setting();

            set.Show();

            //gridMesbah1.DataSource = null;خالی کردن تقویم
        }

        private void button4_Click(object sender, EventArgs e)
        {
           
        }

        private void button5_Click(object sender, EventArgs e)
        {
           
        }

        private void StyleSMSGrid()
        {
            //SMSDataGridView.Columns[CustomerCol.Name].HeaderText = "نام بیمار";
            //SMSDataGridView.Columns[NumberCol.Name].HeaderText = "شماره موبایل";
            //SMSDataGridView.Columns[StateCol.Name].HeaderText = "وضعیت پیامک";
            //SMSDataGridView.Columns[CustomerCol.Name].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            //SMSDataGridView.Columns[NumberCol.Name].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            //SMSDataGridView.Columns[StateCol.Name].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            //SMSDataGridView.Columns[CustomerCol.Name].Width = 92;
            //SMSDataGridView.Columns[NumberCol.Name].Width = 110;
            //SMSDataGridView.Columns[StateCol.Name].Width = 100;
        }

        private void button6_Click(object sender, EventArgs e)
        {
              }

        private void Form1_Load(object sender, EventArgs e)
        {
         Color color = Properties.Settings.Default.Color;
           
           TopPanelWithBorder.BorderColor = color;
           BottomPanelWithBorder.BorderColor = color;
           RightPanelWithBorder.BorderColor = color;
           MenuRightPanelWithBorder.BorderColor = color;
           SendSMSPanelWithBorder.BorderColor = color;
           ColorCheckBox.BackColor = color;
           menuActiveRight.BackColor = color;
           menuActiveTop.BackColor = color;
           SendSMSButton.BackColor = color;
           SMSDataGridView.ColumnHeadersDefaultCellStyle.BackColor = color;
           SMSDataGridView.RowsDefaultCellStyle.SelectionBackColor = ControlPaint.LightLight(color);
           SMSDataGridView.AlternatingRowsDefaultCellStyle.BackColor = ControlPaint.LightLight(ControlPaint.LightLight(ControlPaint.LightLight(ControlPaint.LightLight(color))));
           button1.BackColor = color;
           button2.BackColor = color;
           button3.BackColor = color;
           btnToday.BackColor = color;
           btnTomarow.BackColor = color;
           //button4.BackColor = color;
           //button5.BackColor = color;
           //button6.BackColor = color;
           gridMesbah1.RowsBorderColor = color;
           gridMesbah1.CellsBorderColor = ControlPaint.Dark(color);
           gridMesbah1.CellsForColor = ControlPaint.DarkDark(color);
           gridMesbah1.CellsButtonColor = color;
           SendSMSColorProgressBar.BarColor = ControlPaint.LightLight(color);
            const double interval60minutes = 60 * 60 * 1000;
            //System.Windows.Forms.Timer checkForTime = new System.Threading.Timer(interval60minutes);
            //checkForTime.Elapsed += new ElapsedEventHandler(checkForTime_Elapsed);
            //checkForTime.Elapsed = true;
            
          //  FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            WindowState = FormWindowState.Maximized;
            sectionDS = da.ExecuteCommand("GetActiveDep");
            FillMenu();
            DepartmentID = Convert.ToInt16(menuStrip1.Items[0].Tag);
            //menuStrip1.Items[0].Click += new EventHandler(MenuItemClickHandler);
           // MenuItem1ToolStripMenuItem.CheckState = CheckState.Checked;
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            columnCount = da.GetColumnCount("GetColumnCount");
            btnDay_Click(null, null);
           //FillGrid();
            this.ActiveControl = SMSDataGridView; 
        }

        private void SMSDataGridView_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex == 4 && !(Convert.ToBoolean( SMSDataGridView.CurrentCell.Value)))
            {
                int result1 = 0;
                result1 = da.UpdateIntermittence("SetDecisiveIntermittence", Convert.ToInt32(((DataRow)SMSDataGridView.CurrentRow.Tag)["ID"]), true);
                int i = SMSDataGridView.CurrentRow.Index;
                SMSDataGridView.CurrentRow.DefaultCellStyle.BackColor = Color.LightGreen;
                GridSet();
                FillGrid();
            }

        }

        private void btnDay_Click(object sender, EventArgs e)
        {   
            btnToday.ForeColor = Color.Black;
            btnTomarow.ForeColor = Color.White;
              witchDay = 0;
            MenuTop4ToolStripMenuItem.Checked= MenuTop4ToolStripMenuItem.Enabled;
            MenuTop3ToolStripMenuItem.Checked = MenuTop3ToolStripMenuItem.Enabled;
            MenuTop1ToolStripMenuItem.Checked = MenuTop1ToolStripMenuItem.Enabled;
            MenuTop2ToolStripMenuItem.Checked = MenuTop2ToolStripMenuItem.Enabled;
            if(steps==1 )
           MenuTop4ToolStripMenuItem_Click(null, null);
            if (steps == 2)
                MenuTop3ToolStripMenuItem_Click(null, null);
            if (steps == 3)
                MenuTop1ToolStripMenuItem_Click(null, null);
            if (steps == 4)
                MenuTop2ToolStripMenuItem_Click(null, null);

           FillGrid();
       
          
        }

        private void button7_Click(object sender, EventArgs e)
        {     btnTomarow.ForeColor = Color.Black;
            btnToday.ForeColor = Color.White;
           
             witchDay = 1;
             MenuTop4ToolStripMenuItem.Checked = MenuTop4ToolStripMenuItem.Enabled;
             MenuTop3ToolStripMenuItem.Checked = MenuTop3ToolStripMenuItem.Enabled;
             MenuTop1ToolStripMenuItem.Checked = MenuTop1ToolStripMenuItem.Enabled;
             MenuTop2ToolStripMenuItem.Checked = MenuTop2ToolStripMenuItem.Enabled;

             if (steps == 1)
                 MenuTop4ToolStripMenuItem_Click(null, null);
             if (steps == 2)
                 MenuTop3ToolStripMenuItem_Click(null, null);
             if (steps == 3)
                 MenuTop1ToolStripMenuItem_Click(null, null);
             if (steps == 4)
                 MenuTop2ToolStripMenuItem_Click(null, null);

            FillGrid();
       
        } 

        private void button3_MouseEnter(object sender, EventArgs e)
        {
            button3.Text = string.Empty;
        }

        private void button3_MouseLeave(object sender, EventArgs e)
        {
            button3.Text = "تنظیمات";
        }

        private void btnToday_MouseEnter(object sender, EventArgs e)
        {
            btnToday.Text = string.Empty;
        }

        private void btnToday_MouseLeave(object sender, EventArgs e)
        {
            btnToday.Text = "امروز";
        }

        private void btnTomarow_MouseEnter(object sender, EventArgs e)
        {
            btnTomarow.Text = string.Empty;
        }

        private void btnTomarow_MouseLeave(object sender, EventArgs e)
        {
            btnTomarow.Text = "فردا";
        }

        private void SMSDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (SMSDataGridView.CurrentRow!=null && SMSDataGridView.CurrentRow.Cells["StateCol"].Value != DBNull.Value && !Convert.ToBoolean(SMSDataGridView.CurrentRow.Cells["StateCol"].Value))
                   SMSDataGridView.CurrentRow.DefaultCellStyle.BackColor = Color.LightGreen;
            //if (SMSDataGridView.CurrentRow != null && SMSDataGridView.CurrentRow.Cells["StateCol"].Value != DBNull.Value && Convert.ToBoolean(SMSDataGridView.CurrentRow.Cells["StateCol"].Value))
            //    SMSDataGridView.CurrentRow.Cells["StateCol"].Value = false;

           
             
        }

        private void SMSDataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            //if (SMSDataGridView.CurrentRow!= null && SMSDataGridView.CurrentRow.Cells["StateCol"].Value!= DBNull.Value &&  Convert.ToBoolean(SMSDataGridView.CurrentRow.Cells["StateCol"].Value))
            //    SMSDataGridView.CurrentRow.DefaultCellStyle.BackColor = Color.LightGreen;
        }

        private void SMSDataGridView_KeyUp(object sender, KeyEventArgs e)
        {
            //if (e.KeyValue == 32)
            //{
            //    FillGrid();
            //}
        }

       
    }
}
