using AmirCalendar;
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

using System;
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
using AmirCalendar;
using System.Diagnostics;
using System.Xml;


using System.Windows.Forms;

namespace ClinicMesbah
{
    public partial class Calender : Form
    {
        bool CalenderEnable;
        string CalenderFor = "";
        Color color;
        int SID;
        private ToolStripMenuItem menuActiveTop;
        string SectionName;
        DataTable ShiftDt = new DataTable(); DataTable weeklyDt = new DataTable(); DataTable SectionSMSDT = new DataTable();
        DataAccess da = new DataAccess();
        public Calender(int SectionID, string SectionName)
        {
            InitializeComponent();
            SID = SectionID;
            this.SectionName = SectionName;
        }
        public class ComboboxItem
        {
            public string Text { get; set; }
            public object Value { get; set; }

            public override string ToString()
            {
                return Text;
            }
        }
        private void Calender_Load(object sender, EventArgs e)
        {
            this.Text = this.Text +" "+ SectionName;
            //FarsiDate f = new FarsiDate();
            //lastInterm
            SqlParameter[] param;
            param = new SqlParameter[1];
            int index = 0;
            param[index++] = new SqlParameter("@SectionID", SID);
            int x = Convert.ToInt32(FarsiDateHelper.GetShortFarsiDate(DateTime.Now).Split('/')[2]);
            CalenderEnable = x < 25 ? true : false;
           
         //   f.FarsiSelectedDate= FarsiDateHelper.GetLongFarsiDate(Convert.ToDateTime(da.ExecuteSP("GetLast", param).Tables[0].Rows[0][0])) ;
        //    
           // CalenderFor = string.Format("این برنامه از تاریخ :" + "{0}/{1}/{2}}", f.FarsiYear, (f.FarsiMonth + 1), f.FarsiDay + "اعمال می شود.");
      //   f.FarsiSelectedDate = CalenderFor;
          //  farsiCalendar1.Value = f;
          // farsiCalendar1.
           // lblMonth.Text =  datePicker.Value.FarsiSelectedDate.Split('/')[1] .Value.FarsiSelectedDate.Split('/')[1].
            fillcmb();
            fillcolor();
            pnlHoliday.Location = pnlWeeklyHour.Location;
            pnlHoliday.Visible = false;
            fillGrid();
            fillGridSMS();
            if (Environment.UserDomainName == "clinics" &&
            Environment.UserName == "rashidi")
            {
                cmbDayOfWeek.Enabled = cmbShift.Enabled = true;

            }
            SelectMenuTop(MenuItem1ToolStripMenuItem);
        }

        private void fillGrid()
        {     
            string eventlog = "Fill WeeklyPlan for SectionID"+SID;//
        try
        {
            SqlParameter[] param;
            param = new SqlParameter[1];
            int index = 0;

            param[index++] = new SqlParameter("@SectionID", SID);

            DataGridView.AutoGenerateColumns = false;
            weeklyDt = da.ExecuteSP("GetWeeklyPlan", param).Tables[0];
            DataGridView.DataSource = weeklyDt;
        }
        catch
        {
            NewMethod_eventlog(eventlog, 16009);
                    throw;
        }
        }
        private void fillGridSMS()
        {
         
            try
            {
                SqlParameter[] param;
                param = new SqlParameter[1];
                int index = 0;

                param[index++] = new SqlParameter("@SectionID", SID);

                grdSMS.AutoGenerateColumns = false;
                DataSet DS= new System.Data.DataSet();DS=da.ExecuteSP("GetSectionSMS", param);
                if (DS != null && DS.Tables.Count > 0 && DS.Tables[0].Rows.Count > 0)
                {
                    SectionSMSDT = DS.Tables[0];
                    grdSMS.DataSource = SectionSMSDT;
                }
            }
            catch
            {

                throw;
            }
        }
        private void fillcolor()
        {
             color = Properties.Settings.Default.Color;
            
            //   Properties.Settings.Default.GridText = dataGridView1.Rows[0].Cells[0].Value.ToString();


            // Color C = Properties.Settings.Default.myColor;

            //menuStrip1.BackColor = color;
            //MenuItem2ToolStripMenuItem.BackColor = color;
 
            btnAdd2.BackColor = color;
            btnNew.BackColor = color;
            btnCancel2.BackColor = color;

            btnAdd2.BackColor = color;
            btnSaveSMS.BackColor = btnNewSMS.BackColor = btnDeleteSMS.BackColor = color;
            btnNew.BackColor = color;
            //menuStrip1.BackColor = color;
            btnNew.BackColor = color;
            btnAdd2.BackColor = color;
            grdSMS.ColumnHeadersDefaultCellStyle.BackColor = DataGridView.ColumnHeadersDefaultCellStyle.BackColor = color;
          grdSMS .RowsDefaultCellStyle.SelectionBackColor = DataGridView.RowsDefaultCellStyle.SelectionBackColor = ControlPaint.LightLight(color);
          grdSMS.AlternatingRowsDefaultCellStyle.BackColor = DataGridView.AlternatingRowsDefaultCellStyle.BackColor = ControlPaint.LightLight(ControlPaint.LightLight(ControlPaint.LightLight(ControlPaint.LightLight(color))));
    
 
            this.Size = new Size(this.Size.Width, 450);
            pnlWeeklyHour.Visible = true;
            pnlWeeklyHour.Location = pnlHoliday.Location;
            this.Size = new Size(this.Size.Width, 450);
        }
      private  bool ParseWithTwentyFourthHourToNextDay(string input)// جت تشخیص اینکه فرمت ساعت درست است یا خیر
        {

            Regex rgx = new Regex("[0-9]{2}:[0-9]{2}:[0-9]{2}");
            if (rgx.IsMatch(input))
            { return true; }
            
             else return false;
        }
        private void fillcmb()
        {
            Dictionary<string, int> Day = new Dictionary<string, int>();
            Day.Add("شنبه",7);
            Day.Add("یکشنبه",1);
            Day.Add("دوشنبه",2);
            Day.Add("سه شنبه",3);
            Day.Add("چهارشنبه",4);
            Day.Add("پنج شنبه",5);
            Day.Add("جمعه",6);

                                            cmbDayOfWeek.DataSource = new BindingSource(Day, null);
                                            cmbDayOfWeek.DisplayMember = "Key";
                                             cmbDayOfWeek.ValueMember = "Value";
//shiftcombobox
                                             string eventlog = "Fill Combo Shift" + SID;//
                                             try
                                             {
                                                 ShiftDt = da.ExecuteCommand("GetShift").Tables[0];
                                                 foreach (DataRow dr in ShiftDt.Rows)
                                                 {
                                                     //ComboboxItem item = new ComboboxItem();
                                                     //item.Text =(dr["ShiftName"]).ToString();
                                                     //item.Value = Convert.ToInt32( dr["ID"]);
                                                     //cmbShift.Items.Add(item);

                                                 }
                                                 cmbShift.DataSource = ShiftDt;
                                                 cmbShift.DisplayMember = ShiftDt.Columns[1].ToString();
                                                 cmbShift.ValueMember = (ShiftDt.Columns[2].ToString());
                                             }
                                             catch
                                             {
                                                 NewMethod_eventlog(eventlog, 16010);
                                                 throw;
                                             }
                                }

        private void txtShift_TextChanged(object sender, EventArgs e)
        {

        }

        private void MenuItem1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pnlWeeklyHour.Visible = true;
            pnlSMS.Visible = pnlHoliday.Visible = false; SelectMenuTop(MenuItem1ToolStripMenuItem);
        }

        private void MenuItem2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
          pnlSMS.Visible=  pnlWeeklyHour.Visible = false;
            pnlHoliday.Visible = true; SelectMenuTop(MenuItem2ToolStripMenuItem);
        }

        private void pnlDailyHour_Paint(object sender, PaintEventArgs e)
        {


        }

        private void farsiCalendar1_DateChanged(object sender, AmirCalendar.FarsiDatePickerEventArgs e)
        {

        }

        private void farsiCalendar2_DateChanged(object sender, AmirCalendar.FarsiDatePickerEventArgs e)
        {
           
            var datePicker = (FarsiCalendar)sender;
            var mes = string.Format("Old FarsiDate: {0}New FarsiDate: {1}DatePicker Format: {2}Persian SelectedDate: {3}Gregorian SelectedDate: {4}" +
                                    "Number Of Days In Persian SelectedMonth: {5}Persian Year: {6}Persian Month: {7}Persian Day: {8}Persian selectedDate In Long Format: {9}Is Holiday: {10}",
                                    e.OldFarsiDate + Environment.NewLine,
                                    e.NewFarsiDate + Environment.NewLine,
                                    datePicker.Value.Format + Environment.NewLine,
                                    datePicker.Value.FarsiSelectedDate + Environment.NewLine,
                                    datePicker.Value.GregorianSelectedDate.ToShortDateString() + Environment.NewLine,
                                    datePicker.Value.NumberOfDaysInFarsiSelectedMonth + Environment.NewLine,
                                    datePicker.Value.FarsiYear + Environment.NewLine,
                                    datePicker.Value.FarsiMonth + Environment.NewLine,
                                    datePicker.Value.FarsiDay + Environment.NewLine,
                                    FarsiDateHelper.GetLongFarsiDate(datePicker.Value.GregorianSelectedDate) + Environment.NewLine,
                                    FarsiDateHelper.IsHolidayFarsiDate(datePicker.Value.FarsiSelectedDate) ? "تعطیل" : "غیر تعطیل");
         
            MessageForm.Show(mes,"k",MessageFormIcons.Error,MessageFormButtons.YesNo,Color.Red);
        }

        private void txtStartSobh_TextChanged(object sender, EventArgs e)
        {
            txtStartSobh.MaxLength = 5;
            DeleteChars();
            if (txtStartSobh.Text.Length == 1)
                if (Convert.ToInt32(txtStartSobh.Text) > 2)
                { SendKeys.Send("{BACKSPACE}"); return; }
                else if (txtStartSobh.Text.Length == 2)
                    if (Convert.ToInt32(txtStartSobh.Text) > 24)
                    { SendKeys.Send("{BACKSPACE}"); return; }
            if (txtStartSobh.Text.Length == 2)
                txtStartSobh.Text += ":";

            txtStartSobh.SelectionStart = txtStartSobh.Text.Length;
        }
        private void DeleteChars()
        {

            if (!txtStartSobh.Text.EndsWith("0") && !txtStartSobh.Text.EndsWith("1") && !txtStartSobh.Text.EndsWith("2") && !txtStartSobh.Text.EndsWith("3") && !txtStartSobh.Text.EndsWith("4") && !txtStartSobh.Text.EndsWith("5") && !txtStartSobh.Text.EndsWith("6") && !txtStartSobh.Text.EndsWith("7") && !txtStartSobh.Text.EndsWith("8") && !txtStartSobh.Text.EndsWith("9") && !txtStartSobh.Text.EndsWith(":"))

                SendKeys.Send("{BACKSPACE}");

        }

        private void txtEndSobh_TextChanged(object sender, EventArgs e)
        {
            txtEndSobh.MaxLength = 5;
            DeleteChars();
            if (txtEndSobh.Text.Length == 1)
                if (Convert.ToInt32(txtEndSobh.Text) > 2)
                { SendKeys.Send("{BACKSPACE}"); return; }
                else if (txtEndSobh.Text.Length == 2)
                    if (Convert.ToInt32(txtEndSobh.Text) > 24)
                    { SendKeys.Send("{BACKSPACE}"); return; }
            if (txtEndSobh.Text.Length == 2)
                txtEndSobh.Text += ":";

            txtEndSobh.SelectionStart = txtEndSobh.Text.Length;
        }

      
        private void cmbShift_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbShift.SelectedIndex != -1)
            {
                if (DataGridView.SelectedRows.Count == 0)
                    foreach (DataRow dr in ShiftDt.Rows)
                    {

                        if ((int)dr[0]  ==  (int)((DataRowView)( cmbShift.SelectedItem))[0])
                        {
                            // string s = dr[0].ToString();
                            txtEndSobh.Text = dr[3].ToString();
                            txtStartSobh.Text = dr[2].ToString();
                        }
                    }
            }
            else
            {
                txtEndSobh.Text = "";
                txtStartSobh.Text = "";
            }
        }

       
        

        private void chEnabled_CheckStateChanged(object sender, EventArgs e)
        {
            txtEndSobh.Enabled = txtStartSobh.Enabled = !chEnabled.Checked;
        }

        private void farsiCalendar1_DateChanged_1(object sender, FarsiDatePickerEventArgs e)
        {
            var datePicker = (FarsiCalendar)sender;
           
              SqlParameter[] param;
            param = new SqlParameter[3];
            int index = 0; 
            param[index++] = new SqlParameter("@Month", datePicker.Value.FarsiSelectedDate.Split('/')[1] );
            param[index++] = new SqlParameter("@Day", datePicker.Value.FarsiSelectedDate.Split('/')[2]) ;
              param[index++] = new SqlParameter("@SectionID",SID) ;
              bool IsHoliday;
              string eventlog = "GetHolidays  for SectionID=" + SID + "Month=" + datePicker.Value.FarsiSelectedDate.Split('/')[1] + "Day=" + datePicker.Value.FarsiSelectedDate.Split('/')[2];
             try
             {
                 IsHoliday = Convert.ToBoolean(da.ExecuteSP("GetHolidays", param).Tables[0].Rows[0][0]);
             }
             catch
             {
                 NewMethod_eventlog(eventlog, 16011);
                 throw;
             }
           
            var mes = string.Format("روز:"+"{0}" +
                                     " {1}",  datePicker.Value.FarsiSelectedDate   
                                     , FarsiDateHelper.GetLongFarsiDate(datePicker.Value.GregorianSelectedDate)  ,
                                  "این روز تعطیل است. آیا غیر تعطیل باشد؟"  );

            if (!IsHoliday)
            {
                SqlParameter[] p ;
                p  = new SqlParameter[2];
                int i  = 0;
                p[i++] = new SqlParameter("@DayOfWeek",( FarsiDateHelper.DayOfWeeknum(datePicker.Value.GregorianSelectedDate) ));
                p [i ++] = new SqlParameter("@DepID", SID);

            int z= (int)(datePicker.Value.GregorianSelectedDate.DayOfWeek);
                DataTable shifts = da.ExecuteSP("checkForHolidays", p ).Tables[0];
                var mess = "";
                if (shifts.Rows.Count != 0)
                {
                    mess = string.Format("این روز دارای:" + "{0}" + "شیفت فعال است. آیا این روز تعطیل باشد؟", shifts.Rows.Count );

                    foreach (DataRow dr in shifts.Rows)
                        mess = mess + string.Format(" {0}:" + "از" + " {1} " + "تا" + " {2} ", dr["ShiftName"], dr["StartTime"], dr["EndTime"] + Environment.NewLine);
                    MessageFormResult r = MessageForm.Show(mess, "", MessageFormIcons.Question, MessageFormButtons.YesNo, color);
                    if (r == MessageFormResult.Yes)
                    {
                        SqlParameter[] pa;
                        pa = new SqlParameter[3];
                        int ind = 0;
                        pa[ind++] = new SqlParameter("@SectionID", SID);
                        pa[ind++] = new SqlParameter("@Month", datePicker.Value.FarsiSelectedDate.Split('/')[1]);
                        pa[ind++] = new SqlParameter("@Day", datePicker.Value.FarsiSelectedDate.Split('/')[2]);

                        string eventlog1 = "SetHolidays  for SectionID=" + SID + "Month=" + datePicker.Value.FarsiSelectedDate.Split('/')[1] + "Day=" + datePicker.Value.FarsiSelectedDate.Split('/')[2];
                         try
                         {
                             da.ExecuteSP("SetHolidays", pa);
                         }
                         catch
                         {
                             NewMethod_eventlog(eventlog1, 16012);
                             throw;
                         }
                    }
                }
                else
                {
                    MessageFormResult r = MessageForm.Show(mes, "", MessageFormIcons.Question, MessageFormButtons.YesNo, color);
                    if (r == MessageFormResult.Yes)
                    {
                        SqlParameter[] pa1;
                        pa1 = new SqlParameter[3];
                        int ind1 = 0;

                        pa1[ind1++] = new SqlParameter("@SectionID", -1);
                        pa1[ind1++] = new SqlParameter("@Month", datePicker.Value.FarsiSelectedDate.Split('/')[1]);
                        pa1[ind1++] = new SqlParameter("@Day", datePicker.Value.FarsiSelectedDate.Split('/')[2]);

                        string eventlog2 = "CheckForSetHolidy  for SectionID=" + -1 + "Month=" + datePicker.Value.FarsiSelectedDate.Split('/')[1] + "Day=" + datePicker.Value.FarsiSelectedDate.Split('/')[2];
                        try
                        {
                            if (Convert.ToBoolean(da.ExecuteScalarSP("CheckForsetHoliday", pa1)))
                            { }
                            else
                            {
                                string mess1;
                                mess1 = string.Format("روز:" + " {0}",
                              FarsiDateHelper.GetLongFarsiDate(datePicker.Value.GregorianSelectedDate) +
                                                              "این روز دارای نوبت است و نمی تواند تعطیل باشد.");
                                MessageForm.Show(mess1, "", MessageFormIcons.Warning, MessageFormButtons.Ok, color);
                                return;
                            }
                        }
                        catch
                        {
                            NewMethod_eventlog(eventlog2, 16014);
                            throw;
                        }
                        SqlParameter[] pa;
                        pa = new SqlParameter[3];
                        int ind = 0;
                        pa[ind++] = new SqlParameter("@SectionID", SID);
                        pa[ind++] = new SqlParameter("@Month", datePicker.Value.FarsiSelectedDate.Split('/')[1]);
                        pa[ind++] = new SqlParameter("@Day", datePicker.Value.FarsiSelectedDate.Split('/')[2]);

                        string eventlog1 = "DeleteHolidays  for SectionID=" + SID + "Month=" + datePicker.Value.FarsiSelectedDate.Split('/')[1] + "Day=" + datePicker.Value.FarsiSelectedDate.Split('/')[2];
                         try
                         {
                        da.ExecuteSP("DelHolidays", pa);
                         }
                         catch
                         {
                             NewMethod_eventlog(eventlog1, 16013);
                             throw;
                         }
                    }
                }
            }
            else
            {
                var notH = string.Format("روز:" + "{0}" +
                                " {1}",

                            //   e.NewFarsiDate + Environment.NewLine,

                               datePicker.Value.FarsiSelectedDate + Environment.NewLine,
                    //  datePicker.Value.GregorianSelectedDate.ToShortDateString() + Environment.NewLine,
                    //datePicker.Value.NumberOfDaysInFarsiSelectedMonth + Environment.NewLine,
                    //FarsiDateHelper.GetLongFarsiDate(datePicker.Value.GregorianSelectedDate) + Environment.NewLine,
                              IsHoliday ? "این روز تعطیل است. آیا غیر تعطیل باشد؟" : "این روز غیرتعطیل است. آیا تعطیل باشد؟");
                MessageFormResult r = MessageForm.Show(notH, "", MessageFormIcons.Question, MessageFormButtons.YesNo, color);
                if (r == MessageFormResult.Yes)
                {
                    SqlParameter[] par;
                    par = new SqlParameter[3];
                    int ind = 0;
                    par[ind++] = new SqlParameter("@SectionID", SID);
                    par[ind++] = new SqlParameter("@Month", datePicker.Value.FarsiSelectedDate.Split('/')[1]);
                    par[ind++] = new SqlParameter("@Day", datePicker.Value.FarsiSelectedDate.Split('/')[2]);
                    string eventlog1 = "DeleteHolidays  for SectionID=" + SID + "Month=" + datePicker.Value.FarsiSelectedDate.Split('/')[1] + "Day=" + datePicker.Value.FarsiSelectedDate.Split('/')[2];
                       try
                       {

                           da.ExecuteSP("DelHolidays", par);
                       }
                       catch
                       {
                           NewMethod_eventlog(eventlog1, 16013);
                           throw;
                       }
                }
            }
             
        }

        private void farsiCalendar1_DockChanged(object sender, EventArgs e)
        {

        }

        private void DataGridView_SelectionChanged_1(object sender, EventArgs e)
        {
            if (DataGridView.SelectedRows.Count != 0)
            {
                cmbShift.Enabled = false; cmbDayOfWeek.Enabled = false;
                int index = DataGridView.SelectedRows[0].Index;
                chEnabled.Checked = !Convert.ToBoolean(DataGridView.Rows[index].Cells[3].Value);
                //txtStartTime.Text = DataGridView.Rows[index].Cells[2].Value.ToString();
                txtEndSobh.Text = DataGridView.Rows[index].Cells[5].Value.ToString();
                txtStartSobh.Text = DataGridView.Rows[index].Cells[4].Value.ToString();
                cmbShift.SelectedIndex = cmbShift.FindStringExact(DataGridView.Rows[index].Cells[2].Value.ToString());
                foreach (DataRowView row in cmbShift.Items)
                    if (Convert.ToInt32(row[0]) == Convert.ToInt32(DataGridView.Rows[index].Cells[6].Value))
                        cmbShift.SelectedItem = row;
                cmbDayOfWeek.SelectedIndex = cmbDayOfWeek.FindStringExact(DataGridView.Rows[index].Cells[1].Value.ToString());

            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            DataGridView.ClearSelection();
            cmbShift.SelectedIndex = -1;
            cmbShift.Enabled = true;
            cmbDayOfWeek.Enabled = true;
            cmbDayOfWeek.SelectedIndex = -1;

        }
        
        private void btnAdd2_Click(object sender, EventArgs e)
        {

            if (cmbDayOfWeek.SelectedItem == null)
            {
                var msg = "لطفا روز را انتخاب کنید "; MessageForm.Show(msg, "ثبت", MessageFormIcons.Warning, MessageFormButtons.Ok, Properties.Settings.Default.Color);
                return;
            }

            if (cmbShift.SelectedItem == null)
            {
                var msg = "لطفا نام شیفت را انتخاب کنید "; MessageForm.Show(msg, "ثبت", MessageFormIcons.Warning, MessageFormButtons.Ok, Properties.Settings.Default.Color);
                return;
            }

            if (txtStartSobh.Text == null || txtStartSobh.Text == "")
            {
                var msg = "لطفا شروع را وارد کنید "; MessageForm.Show(msg, "ثبت", MessageFormIcons.Warning, MessageFormButtons.Ok, Properties.Settings.Default.Color);
                return;
            }

            if (txtEndSobh.Text == null || txtEndSobh.Text == "")
            {
                var msg = "لطفا پایان را درست وارد کنید "; MessageForm.Show(msg, "ثبت", MessageFormIcons.Warning, MessageFormButtons.Ok, Properties.Settings.Default.Color);
                return;
            }
            if (!ParseWithTwentyFourthHourToNextDay(txtStartSobh.Text))
            {
                var msg = "لطفا فرمت ساعت شروع را اصلاح کنید "; MessageForm.Show(msg, "ثبت", MessageFormIcons.Warning, MessageFormButtons.Ok, Properties.Settings.Default.Color);
                return;
            }
            if (!ParseWithTwentyFourthHourToNextDay(txtEndSobh.Text))
            {
                var msg = "لطفا فرمت ساعت پایان را اصلاح کنید "; MessageForm.Show(msg, "ثبت", MessageFormIcons.Warning, MessageFormButtons.Ok, Properties.Settings.Default.Color);
                return;
            }
            string eventlog = "SetShift information";//
            try
            {
                SqlParameter[] param;
                param = new SqlParameter[7];
                int index = 0;

                if (DataGridView.SelectedRows.Count == 0)
                {//new 
                    param[index++] = new SqlParameter("@ID", Convert.ToInt32(0));

                }
                else
                {//update
                    param[index++] = new SqlParameter("@ID", (Convert.ToInt32(DataGridView.Rows[DataGridView.SelectedRows[0].Index].Cells[0].Value)));

                }
                param[index++] = new SqlParameter("@Active", !chEnabled.Checked);

                param[index++] = new SqlParameter("@DayOfWeek", Convert.ToInt32(cmbDayOfWeek.SelectedValue));
                // if (txtStartSobh.Text)
                param[index++] = new SqlParameter("@StartTime", (Convert.ToDateTime(txtStartSobh.Text)).TimeOfDay);
                param[index++] = new SqlParameter("@EndTime", (Convert.ToDateTime(txtEndSobh.Text)).TimeOfDay);
                //   param[index++] = new SqlParameter("@Active", !chActive.Checked);
                param[index++] = new SqlParameter("@ShiftID", (int)((DataRowView)(cmbShift.SelectedItem))[0]);
                param[index++] = new SqlParameter("@SectionID", SID);
                if (Convert.ToInt32(da.ExecuteScalarSP("SetShift", param)) == 1)
                {
                    var msg = "ثبت با موفقیت انجام شد"; MessageForm.Show(msg, "ثبت", MessageFormIcons.Info, MessageFormButtons.Ok, Properties.Settings.Default.Color);
                    //  MessageBox.Show("ثبت با موفقیت انجام شد."); 
                    fillGrid(); cmbDayOfWeek.Enabled = false; cmbShift.Enabled = false;

                }
                else
                {
                    var msg = "در روند ثبت خطایی رخ داده است."; MessageForm.Show(msg, "ثبت", MessageFormIcons.Warning, MessageFormButtons.Ok, Properties.Settings.Default.Color);

                    //  MessageBox.Show("در روند ثبت خطایی رخ داده است.");
                }
            }
            catch
            {
                NewMethod_eventlog(eventlog, 16008);
                throw;
            }
        }

        private void pnlWeeklyHour_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnCancel2_Click(object sender, EventArgs e)
        {
            
            int shiftID = 0;
            if (DataGridView.CurrentRow != null && DataGridView.CurrentRow.Cells[0].Value != null)
                shiftID = Convert.ToInt32(DataGridView.CurrentRow.Cells[0].Value);
            //  ExecuteScalarSP
            string eventlog = "DeleteWeeklyWorkingHours By ShiftID=" + shiftID;//
            if (shiftID != 0)
            {
                try
                {
                    SqlParameter[] param;
                    param = new SqlParameter[1];
                    param[0] = new SqlParameter("@ID", shiftID);
                    da.ExecuteScalarSP("DeleteWeeklyWorkingHours", param);
                    var msg = "حذف با موفقیت انجام شد"; MessageForm.Show(msg, "حذف", MessageFormIcons.Info, MessageFormButtons.Ok, Properties.Settings.Default.Color);
                    fillGrid();
                }
                catch
                {
                    NewMethod_eventlog(eventlog, 16007);
                    throw;
                }
            }

        }
        private static void NewMethod_eventlog(string eventlog, int id)
        {
            EventLog log = new EventLog();
            //log.taskca
            log.Source = "application";
            log.WriteEntry(eventlog, EventLogEntryType.Information, id);
        }
        private void SelectMenuTop(ToolStripMenuItem menuItem)//تنظیمات دیزاین منو نمایش بخش ها
        {
            MenuItem1ToolStripMenuItem.Checked = false;
            MenuItem2ToolStripMenuItem.Checked = false; MenuItem3ToolStripMenuItem.Checked = false;
             MenuItem4ToolStripMenuItem.Checked = false;
            MenuItem1ToolStripMenuItem.BackColor = Color.Transparent;
            MenuItem2ToolStripMenuItem.BackColor = Color.Transparent;
             MenuItem4ToolStripMenuItem.BackColor = Color.Transparent;
             MenuItem3ToolStripMenuItem.BackColor = Color.Transparent;
            MenuItem1ToolStripMenuItem.ForeColor = Color.Black;
            MenuItem3ToolStripMenuItem.ForeColor = Color.Black;
            MenuItem2ToolStripMenuItem.ForeColor = Color.Black;
            MenuItem4ToolStripMenuItem.ForeColor = Color.Black;
            //menuItem.Checked = true;
            menuItem.BackColor = color;
            menuItem.ForeColor = Color.White;
            menuActiveTop = menuItem;
        }

        private void MenuItem1ToolStripMenuItem_MouseLeave(object sender, System.EventArgs e)
        {
            Cursor = System.Windows.Forms.Cursors.Default;//دیزاین
        }

        private void MenuItem1ToolStripMenuItem_MouseEnter(object sender, System.EventArgs e)
        {
            Cursor = System.Windows.Forms.Cursors.Hand;//دیزاین

        }

        private void پیامکToolStripMenuItem_Click(object sender, System.EventArgs e)
        {   pnlHoliday.Visible = false;
            pnlSMS.Visible = true;pnlWeeklyHour.Visible = false;

            SelectMenuTop(MenuItem3ToolStripMenuItem); pnlSMS.Visible = true;
        }

        private void btnSaveSMS_Click(object sender, System.EventArgs e)
        {




            if (txtText.Text == null || txtText.Text == "")
            {
                var msg = "لطفا متن را وارد کنید "; MessageForm.Show(msg, "ثبت", MessageFormIcons.Warning, MessageFormButtons.Ok, Properties.Settings.Default.Color);
                return;
            }

           
            string eventlog = "SetShift information";//
            try
            {
                SqlParameter[] param;
                param = new SqlParameter[3];
                int index = 0;

                if (grdSMS.SelectedRows.Count == 0)
                {
                    param[index++] = new SqlParameter("@ID", Convert.ToInt32(0));

                }
                else
                {
                    param[index++] = new SqlParameter("@ID", (Convert.ToInt32(grdSMS.Rows[grdSMS.SelectedRows[0].Index].Cells[0].Value)));

                }

                param[index++] = new SqlParameter("@Text", txtText.Text);
                param[index++] = new SqlParameter("@SectionID", SID);
                if (Convert.ToInt32(da.ExecuteScalarSP("SetSectionSMS", param)) == 1)
                {
                    var msg = "ثبت با موفقیت انجام شد"; MessageForm.Show(msg, "ثبت", MessageFormIcons.Info, MessageFormButtons.Ok, Properties.Settings.Default.Color);
                    //  MessageBox.Show("ثبت با موفقیت انجام شد."); 
                    fillGridSMS(); txtText.Enabled = true;

                }
                else
                {
                    var msg = "در روند ثبت خطایی رخ داده است."; MessageForm.Show(msg, "ثبت", MessageFormIcons.Warning, MessageFormButtons.Ok, Properties.Settings.Default.Color);

                    //  MessageBox.Show("در روند ثبت خطایی رخ داده است.");
                }
            }
            catch
            {
                NewMethod_eventlog(eventlog, 16008);
                throw;
            }
        }

        private void grdSMS_SizeChanged(object sender, System.EventArgs e)
        {

        }

        private void grdSMS_SelectionChanged(object sender, System.EventArgs e)
        {
            if (grdSMS.SelectedRows.Count != 0)
            {
              txtText.Enabled = true;
              int index = grdSMS.SelectedRows[0].Index;
             
                //txtStartTime.Text = DataGridView.Rows[index].Cells[2].Value.ToString();
              txtText.Text = grdSMS.Rows[index].Cells[1].Value.ToString();
                   
            }

        }

        private void btnNewSMS_Click(object sender, System.EventArgs e)
        {
            grdSMS.ClearSelection();
           txtText.Enabled=
            true; txtText.Text =
            "";
        }

        private void btnDeleteSMS_Click(object sender, System.EventArgs e)
        {
            int SectionSMSID = 0;
            if (grdSMS.CurrentRow != null && grdSMS.CurrentRow.Cells[0].Value != null)
                SectionSMSID = Convert.ToInt32(grdSMS.CurrentRow.Cells[0].Value);
            //  ExecuteScalarSP
             if (SectionSMSID != 0)
            {
                try
                {
                    SqlParameter[] param;
                    param = new SqlParameter[1];
                    param[0] = new SqlParameter("@SectionSMSID", SectionSMSID);
                    da.ExecuteScalarSP("DeleteSectionSMS", param);
                    var msg = "حذف با موفقیت انجام شد"; MessageForm.Show(msg, "حذف", MessageFormIcons.Info, MessageFormButtons.Ok, Properties.Settings.Default.Color);
                    fillGridSMS();
                }
                catch
                {
                    
                    throw;
                }
            }

        }

    }
}
