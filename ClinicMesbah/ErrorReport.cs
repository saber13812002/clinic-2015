using MesbahComponent;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;


namespace ClinicMesbah
{
    public partial class ErrorReport : Form
    {
        
        private Color color;
        public ErrorReport()
        {
            InitializeComponent();
        }
       
        private void setcolor()
        {
            color = Properties.Settings.Default.Color;
            gbConnectToBank.BackColor = ControlPaint.LightLight(ControlPaint.LightLight(ControlPaint.LightLight(ControlPaint.LightLight((ControlPaint.LightLight(color))))));
            button3.BackColor = color;
        }
    }
}
