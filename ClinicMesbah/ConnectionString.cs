using EncryptStringSample;
using MesbahComponent;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace ClinicMesbah
{
    public partial class ConnectionString : Form
    {
        private XmlDocument doc;
        private bool connected=false;
        private string PATH = @"d:\sample.xml";
        DataAccess da = new DataAccess();
        private int current = 0;
        private Color color;

        public ConnectionString()
        {
            InitializeComponent();
        }
        private void setcolor()
        {
            color = Properties.Settings.Default.Color;
            gbConnectToBank.BackColor =ControlPaint.LightLight( ControlPaint.LightLight(ControlPaint.LightLight(ControlPaint.LightLight((ControlPaint.LightLight(color))))));
            button2.BackColor= 
            button1.BackColor=
            button3.BackColor = color;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            //Create an xml document
            doc = new XmlDocument();

            //If there is no current file, then create a new one
            if (!System.IO.File.Exists(PATH))
            {
                //Create neccessary nodes
                XmlDeclaration declaration = doc.CreateXmlDeclaration("1.0", "UTF-8", "yes");
                XmlComment comment = doc.CreateComment("This is an XML Generated File");
                XmlElement root = doc.CreateElement("servers");
                XmlElement server = doc.CreateElement("server");
               // XmlAttribute sql = doc.CreateAttribute("sql");
                XmlElement svr_name = doc.CreateElement("svr_name");
                XmlElement db_name = doc.CreateElement("db_name");
                XmlElement db_login = doc.CreateElement("db_login");
                XmlElement db_passWord = doc.CreateElement("db_passWord");

                //Add the values for each nodes
                //   sql.Value = textBox1.Text;
                svr_name.InnerText = txtSRVName.Text;
                db_name.InnerText = txtDBName.Text;
                db_login.InnerText = txtLogin.Text;
                db_passWord.InnerText =

                    StringCipher.Encrypt(txtPassWord.Text, "9ge340");// Encrypt(txtPassWord.Text, true);// txtPassWord.Text;

                //Construct the document
                doc.AppendChild(declaration);
                doc.AppendChild(comment);
                doc.AppendChild(root);
                root.AppendChild(server);
              //  server.Attributes.Append(sql);
                server.AppendChild(svr_name);
                server.AppendChild(db_name);
                server.AppendChild(db_login);
                server.AppendChild(db_passWord);

                doc.Save(PATH);
            }
            else //If there is already a file
            {
                //Load the XML File
                doc.Load(PATH);

                //Get the root element
                XmlElement root = doc.DocumentElement;

                XmlElement server = doc.CreateElement("server");
                XmlElement srv_name = doc.CreateElement("srv_name");
                XmlElement db_name = doc.CreateElement("db_name");
                //XmlElement gender = doc.CreateElement("Gender");
                XmlElement db_login = doc.CreateElement("db_login");
                XmlElement db_passWord = doc.CreateElement("db_passWord");
                //Add the values for each nodes
                srv_name.InnerText = txtSRVName.Text;
                db_name.InnerText = txtDBName.Text;
                //gender.InnerText = textBox2.Text;
                db_login.InnerText = txtLogin.Text;
                db_passWord.InnerText = Encrypt(txtPassWord.Text, "9ge340");// StringCipher.Decrypt(txtPassWord.Text, txtPassWord.Text);// Encrypt(txtPassWord.Text, true);// txtPassWord.Text;
            
                //Construct the Person element
                server.AppendChild(srv_name);
                server.AppendChild(db_name);
                server.AppendChild(db_login);
                server.AppendChild(db_passWord);
                //person.AppendChild(gender);

                  //Add the New person element to the end of the root element
                root.AppendChild(server);

                //Save the document
                doc.Save(PATH);
            }

            //Show confirmation message


            try
            {
                using (SqlConnection con = new SqlConnection(da.GetConnectionString()))
                {

                    SqlCommand command = new SqlCommand();
                    con.Open(); con.Close();

                    // this.Hide();
                    //Form1 Form1 = new Form1();// نمایش فرم تنظیمات
                    ////Form1.Show();
                    var msg = " اتصال به بانک با موفقیت انجام شد. ";
                    MessageForm.Show(msg, "اتصال به بانک", MessageFormIcons.Info, MessageFormButtons.Ok, color);
                    connected = true;
                    txtDBName.Enabled=
                    txtLogin.Enabled=
                    txtSRVName.Enabled=
                    txtPassWord.Enabled=button2.Enabled=
                    button1.Enabled = false;
                    button3.BackColor = Color.White;
                    button3.BackColor = color;
                    button3.BackColor = Color.White;
                    button3.BackColor = color;
                    //this.Close();

                }

            }
            catch
            {
                var msg = "اطلاعات اتصال به بانک درست نمی باشد. ";
                MessageForm.Show(msg, "خطا در اتصال به بانک", MessageFormIcons.Warning, MessageFormButtons.Ok, color);

                //this.Close();

            }
            //MessageBox.Show("Details have been added to the XML File.");

            //Reset text fields for new input
            //txtSRVName.Text = String.Empty;
            //txtDBName.Text = String.Empty;
            //textBoxGender.Text = String.Empty;
        }

        private void ConnectionString_Load(object sender, EventArgs e)
        {
            txtPassWord.PasswordChar = '*';
            setcolor();
            //string s = System.Reflection.Assembly.GetEntryAssembly().Location;
            string appPath = Application.StartupPath;
            PATH = appPath + @"\setting.xml";
            doc = new XmlDocument();

            //If there is no current file, then create a new one
            if (!System.IO.File.Exists(PATH))
            {
                //Create neccessary nodes
                XmlDeclaration declaration = doc.CreateXmlDeclaration("1.0", "UTF-8", "yes");
                XmlComment comment = doc.CreateComment("This is an XML Generated File");
                XmlElement root = doc.CreateElement("servers");
                XmlElement server = doc.CreateElement("server");
               // XmlAttribute sql = doc.CreateAttribute("sql");
                XmlElement svr_name = doc.CreateElement("svr_name");
                XmlElement db_name = doc.CreateElement("db_name");
                XmlElement db_login = doc.CreateElement("db_login");
                XmlElement db_passWord = doc.CreateElement("db_passWord");


                //Add the values for each nodes
                //  sql.Value = textBox1.Text;
                svr_name.InnerText = txtSRVName.Text;
                db_name.InnerText = txtDBName.Text;
                db_login.InnerText = txtLogin.Text;
                db_passWord.InnerText = Encrypt(txtPassWord.Text, "9ge340");
              
                //Construct the document
                doc.AppendChild(declaration);
                doc.AppendChild(comment);
                doc.AppendChild(root);
                root.AppendChild(server);
                //  server.Attributes.Append(sql);
                 server.AppendChild(svr_name);
                server.AppendChild(db_name);
                server.AppendChild(db_login);
                server.AppendChild(db_passWord);
                doc.Save(PATH);
            }
            else
            {

                doc = new XmlDocument();
                doc.Load(PATH);

                XmlElement root = doc.DocumentElement;

                XmlElement server = doc.CreateElement("server");

                XmlElement currentPosition;
                //Get root element
                server = doc.DocumentElement;

                //Determine maximum possible index
                int max = server.GetElementsByTagName("server").Count - 1;


                //Get the record at the current index
                currentPosition = (XmlElement)root.ChildNodes[max];
                if (currentPosition != null)
                {
                   txtSRVName.Text= currentPosition.ChildNodes[0].InnerText;
                   txtDBName.Text =  currentPosition.GetElementsByTagName("db_name")[0].InnerText;
                   txtLogin.Text = currentPosition.ChildNodes[2].InnerText;
                   txtPassWord.Text = Decrypt(currentPosition.ChildNodes[3].InnerText, "9ge340");
                }
                try
                {
                    using (SqlConnection con = new SqlConnection(da.GetConnectionString()))
                    {
              
                        SqlCommand command = new SqlCommand();
                        con.Open(); con.Close();
                        
                        // this.Hide();
                        //Form1 Form1 = new Form1();// نمایش فرم تنظیمات
                        //Form1.Show();
                        //var msg = " اتصال به بانک با موفقیت انجام شد. ";
                        //MessageForm.Show(msg, "اتصال به بانک", MessageFormIcons.Info, MessageFormButtons.Ok, color);
                        connected = true;

                       this.Close();
                    }
                    
                }
                catch
                {
                    var msg = "اطلاعات اتصال به بانک صحیح نمی باشد. ";
                    MessageForm.Show(msg, "خطا در اتصال به بانک", MessageFormIcons.Warning, MessageFormButtons.Ok, color);
               
                    //this.Close();
 
                }
            }
        }
        //public string  GetServerNameAndDBName()
        //{
        //    if (System.IO.File.Exists(PATH))
        //    {
        //        doc = new XmlDocument();
        //        doc.Load(PATH);

        //        XmlElement root = doc.DocumentElement;

        //        XmlElement server = doc.CreateElement("server");

        //        XmlElement currentPosition;
        //        //Get root element
        //        server = doc.DocumentElement;

        //        //Determine maximum possible index
        //        int max = server.GetElementsByTagName("server").Count ;


        //        //Get the record at the current index
        //        currentPosition = (XmlElement)root.ChildNodes[current++];

        //        if (currentPosition != null)
        //        {
        //            label4.Text = currentPosition.ChildNodes[0].InnerText;//.GetElementsByTagName("srv_name")[1].InnerText;//currentPosition.GetElementsByTagName["srv_name"].Value;
        //            label5.Text = currentPosition.GetElementsByTagName("db_name")[0].InnerText;
        //            //label4.Text = currentPosition.Attributes["srv_name"].Value;
        //            //label5.Text = currentPosition.GetElementsByTagName("db_name")[0].InnerText;
        //        }
                
        //        //if (currentPosition != null)
        //        //{
        //        //    currentPosition = (XmlElement)root.ChildNodes[++current];

        //        //    label6.Text = currentPosition.Attributes["srv_name"].Value;
        //        //    label7.Text = currentPosition.GetElementsByTagName("db_name")[0].InnerText;
        //        //}

        //    }
            
        //    return label4.Text + "*" + label5.Text;
        //}
        private void button2_Click(object sender, EventArgs e)
        {
            if (System.IO.File.Exists(PATH))
            {
                doc = new XmlDocument();
                doc.Load(PATH);

                XmlElement root = doc.DocumentElement;

                XmlElement server = doc.CreateElement("server");

                XmlElement currentPosition;
                //Get root element
                server = doc.DocumentElement;

                //Determine maximum possible index
                int max = server.GetElementsByTagName("server").Count - 1;


                //Get the record at the current index
                currentPosition = (XmlElement)root.ChildNodes[max];

                if (currentPosition != null)
                {
                    //label4.Text =currentPosition.GetElementsByTagName("srv_name")[0].InnerText;//currentPosition.GetElementsByTagName["srv_name"].Value;
                    //label5.Text = currentPosition.GetElementsByTagName("db_name")[1].InnerText;
                }

                if (currentPosition != null)
                {
                    currentPosition = (XmlElement)root.ChildNodes[++current];

                    //label6.Text = currentPosition.Attributes["srv_name"].Value;
                    //label7.Text = currentPosition.GetElementsByTagName("db_name")[0].InnerText;
                }

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (connected == false)
                System.Environment.Exit(1);
               else
            this.Close();
        }

        private void ConnectionString_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (connected == false)
                System.Environment.Exit(1);
            //else
            //    this.Close();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {

             button1_Click(null, null);
            //if (!System.IO.File.Exists(PATH))
            //{
            //    var msg = "اطلاعات اتصال به بانک را وارد کنید. ";
            //    MessageForm.Show(msg, "خطا در اتصال به بانک", MessageFormIcons.Warning, MessageFormButtons.Ok, color);
            //    return;
            //}
            //try
            //{
            //    using (SqlConnection con = new SqlConnection(da.GetServerNameAndDBName()))
            //    {

            //        SqlCommand command = new SqlCommand();
            //        con.Open(); con.Close();

            //        // this.Hide();
            //        //Form1 Form1 = new Form1();// نمایش فرم تنظیمات
            //        //Form1.Show();
            //        //var msg = " اتصال به بانک با موفقیت انجام شد. ";
            //        //MessageForm.Show(msg, "اتصال به بانک", MessageFormIcons.Info, MessageFormButtons.Ok, color);
            //        connected = true;

            //        this.Close();
            //    }

            //}
            //catch
            //{
            //    var msg = "اطلاعات اتصال به بانک صحیح نمی باشد. ";
            //    MessageForm.Show(msg, "خطا در اتصال به بانک", MessageFormIcons.Warning, MessageFormButtons.Ok, color);

            //    //this.Close();

            //}
        }

        private const string initVector = "tu89geji340t89u2";

        private const int keysize = 256;

        public static string Encrypt(string Text, string Key)
        {
            byte[] initVectorBytes = Encoding.UTF8.GetBytes(initVector);
            byte[] plainTextBytes = Encoding.UTF8.GetBytes(Text);
            PasswordDeriveBytes password = new PasswordDeriveBytes(Key, null);
            byte[] keyBytes = password.GetBytes(keysize / 8);
            RijndaelManaged symmetricKey = new RijndaelManaged();
            symmetricKey.Mode = CipherMode.CBC;
            ICryptoTransform encryptor = symmetricKey.CreateEncryptor(keyBytes, initVectorBytes);
            MemoryStream memoryStream = new MemoryStream();
            CryptoStream cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write);
            cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length);
            cryptoStream.FlushFinalBlock();
            byte[] Encrypted = memoryStream.ToArray();
            memoryStream.Close();
            cryptoStream.Close();
            return Convert.ToBase64String(Encrypted);
        }

        public static string Decrypt(string EncryptedText, string Key)
        {
            byte[] initVectorBytes = Encoding.ASCII.GetBytes(initVector);
            byte[] DeEncryptedText = Convert.FromBase64String(EncryptedText);
            PasswordDeriveBytes password = new PasswordDeriveBytes(Key, null);
            byte[] keyBytes = password.GetBytes(keysize / 8);
            RijndaelManaged symmetricKey = new RijndaelManaged();
            symmetricKey.Mode = CipherMode.CBC;
            ICryptoTransform decryptor = symmetricKey.CreateDecryptor(keyBytes, initVectorBytes);
            MemoryStream memoryStream = new MemoryStream(DeEncryptedText);
            CryptoStream cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read);
            byte[] plainTextBytes = new byte[DeEncryptedText.Length];
            int decryptedByteCount = cryptoStream.Read(plainTextBytes, 0, plainTextBytes.Length);
            memoryStream.Close();
            cryptoStream.Close();
            return Encoding.UTF8.GetString(plainTextBytes, 0, decryptedByteCount);
        }

       

        
    }
}
