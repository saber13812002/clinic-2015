using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ClinicMesbah
{
    public partial class BackGround : Form
       
    {
        private DataTable DT = new DataTable(); 
        private Color color = Properties.Settings.Default.Color;
        public BackGround()
        {
            InitializeComponent();
        }
        public BackGround(DataTable DT)
        {
            InitializeComponent();
            this.DT = DT;
            grdBackGround.DataSource = DT;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
         
        }

        #region SetColor
        private void SetColor()
        {
            color = Properties.Settings.Default.Color;
                      grdBackGround.ColumnHeadersDefaultCellStyle.BackColor = color;
            //toolStripMenuItem1.BackColor = toolStripMenuItem2.BackColor = toolStripMenuItem3.BackColor = toolStripMenuItem4.BackColor = toolStripMenuItem5.BackColor
            grdBackGround.RowsDefaultCellStyle.SelectionBackColor = ControlPaint.LightLight(color);
            grdBackGround.AlternatingRowsDefaultCellStyle.BackColor = ControlPaint.LightLight(ControlPaint.LightLight(ControlPaint.LightLight(ControlPaint.LightLight(color))));
            
        }
        #endregion
    }
}
