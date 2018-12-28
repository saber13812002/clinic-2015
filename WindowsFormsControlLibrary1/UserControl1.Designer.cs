namespace WindowsFormsControlLibrary1
{
    partial class UserControl1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            AmirCalendar.FarsiDate farsiDate1 = new AmirCalendar.FarsiDate();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.farsiCalendar1 = new AmirCalendar.FarsiCalendar();
            this.SuspendLayout();
            // 
            // farsiCalendar1
            // 
            this.farsiCalendar1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.farsiCalendar1.Location = new System.Drawing.Point(69, 39);
            this.farsiCalendar1.Name = "farsiCalendar1";
            this.farsiCalendar1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.farsiCalendar1.Size = new System.Drawing.Size(347, 21);
            this.farsiCalendar1.TabIndex = 1;
            farsiDate1.FarsiSelectedDate = "1393/09/19";
            this.farsiCalendar1.Value = farsiDate1;
            // 
            // UserControl1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.farsiCalendar1);
            this.Name = "UserControl1";
            this.Size = new System.Drawing.Size(432, 150);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private AmirCalendar.FarsiCalendar farsiCalendar1;
    }
}
