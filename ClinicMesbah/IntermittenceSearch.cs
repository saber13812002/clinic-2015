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
    public partial class IntermittenceSearch : Form
    {
        public IntermittenceSearch(short DepartmentID)
        {
            InitializeComponent();
            this.DepartmentID = DepartmentID;
        }
        #region Variables
         private short DepartmentID = 0;
        public short DepartmentSelected;
        private DataSet DepartementInfo = new DataSet();
        private DataTable DoctDT = new DataTable();
        private DataTable DocumentDT = new DataTable();
        private DataAccess da = new DataAccess();
        private DataTable dt = new DataTable();
        private DataTable dtDoc = new DataTable();
        private DataTable smsDt = new DataTable();
        private string Id;
        private Color color = Properties.Settings.Default.Color;
        public DataSet GridDataSourceDS;
        private bool IntOrChar;

        private byte SearchType;//اگر 1 باشد براساس نام اگر 2 براساس کد ملی اگر 3 بر اساس شماره تماس جستجو می کند
        #endregion
        
        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            SearchType = (byte)2;

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            DataTable dtSearch = new DataTable();

            DataTable dtSearched = new DataTable();

            if (!(textBox1.Text.Trim() == "" || textBox1.Text == string.Empty) && grdIntermittenc.Rows.Count > 0)
            {
                dtSearch = GridDataSourceDS.Tables[0].Copy();
                if (IntOrChar)// && (SearchType == (byte)2 || SearchType == (byte)3))
                { DataRow[] resultss;
                    //if(SearchType == (byte)2)
                    resultss = dtSearch.AsEnumerable().Where(row => row.Field<string>("NationalityCode").Contains(textBox1.Text.Trim())).Select(row => row).ToArray<DataRow>();
                    //else
                    //    resultss = dtSearch.AsEnumerable().Where(row => row.Field<string>("Telphone").Contains(textBox1.Text.Trim())).Select(row => row).ToArray<DataRow>();
                    
                    dtSearched = dtSearch.Copy();
                    dtSearched.Rows.Clear();

                    foreach (DataRow row in resultss)
                    {
                        dtSearched.ImportRow(row);
                    }
                    FillGrid(dtSearched);
                }
           
                else //if( SearchType == (byte)1)
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

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            SearchType = (byte)1;
        }
        #region SetColor
        private void SetColor()
        {
            color = Properties.Settings.Default.Color;
            grdIntermittenc.ColumnHeadersDefaultCellStyle.BackColor = color;
            //toolStripMenuItem1.BackColor = toolStripMenuItem2.BackColor = toolStripMenuItem3.BackColor = toolStripMenuItem4.BackColor = toolStripMenuItem5.BackColor
            grdIntermittenc.RowsDefaultCellStyle.SelectionBackColor = ControlPaint.LightLight(color);
            grdIntermittenc.AlternatingRowsDefaultCellStyle.BackColor = ControlPaint.LightLight(ControlPaint.LightLight(ControlPaint.LightLight(ControlPaint.LightLight(color))));
           
        }
        #endregion
        private void IntermittenceSearch_Load(object sender, EventArgs e)
        {

            SetColor();
            GridSet();
            GridDataSourceDS = da.ExecuteCommand("GetSearchIntermittences");

            if (GridDataSourceDS == null || GridDataSourceDS.Tables.Count == 0 || GridDataSourceDS.Tables[0].Rows.Count == 0)
            {

              //  MenuTop4ToolStripMenuItem.Text = "0" + " " + "نویت های امروز";
                return;
            }
            else
            {
              //  MenuTop4ToolStripMenuItem.Text = GridDataSourceDS.Tables[0].Rows.Count.ToString() + " " + "نویت های امروز";

                FillGrid(GridDataSourceDS.Tables[0]);
                grdIntermittenc.Rows.OfType<DataGridViewRow>().First().Selected = true;
            }
        }
        #region GridSet
        private void GridSet()
        {
            dt = new DataTable();
            dt.Columns.Add(IDIntermittence.Name);
            dt.Columns.Add(CodeCol.Name);
            dt.Columns.Add(CustomerCol.Name);
            dt.Columns.Add(DateModifiedCol.Name);
            dt.Columns.Add(TelphoneCol.Name);
            dt.Columns.Add(SectionCol.Name);dt.Columns.Add(StatusCol.Name);
            dt.Columns.Add(VisitedCol.Name);
            
            grdIntermittenc.DataSource = dt;
        }
      
        #endregion

        private void FillGrid(DataTable GridDataSourceDS)
        {
            if (GridDataSourceDS == null) return;
          //  grdIntermittenc.SelectionChanged -= grdIntermittenc_SelectionChanged;
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
                dr["StatusCol"] = row["Status"];
                dr["TelphoneCol"] = row["Telphone"];
                dr["SectionCol"] = row["SectionID"];
                dr["VisitedCol"] = row["Visited"]; dr["DateModifiedCol"] = row["DateModified"];
      
                Int32 index = grdIntermittenc.Rows.Count - 1;
                grdIntermittenc.Rows[index].Tag = row;

            }

            grdIntermittenc.DataSource = smsDt;
            grdIntermittenc.Columns["IDIntermittence"].Visible = false;
            this.grdIntermittenc.Columns["CustomerCol"].DefaultCellStyle.Alignment =
            this.grdIntermittenc.Columns["CodeCol"].DefaultCellStyle.Alignment =
            DataGridViewContentAlignment.MiddleRight;
            grdIntermittenc.ClearSelection();
            //grdIntermittenc.SelectionChanged += grdIntermittenc_SelectionChanged;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            SearchType = (byte)3;

        }
    }
}
