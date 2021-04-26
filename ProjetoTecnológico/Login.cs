using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLogicLayer;
using System.Security.Cryptography;

namespace ProjetoTecnológico
{
    public partial class Login : MetroFramework.Forms.MetroForm
    {
        DataTable dt;
        bool adm;
        string password;
        
        public Login()
        {
            InitializeComponent();
        }

        public static string getHashSha256(string password)
        {
            byte[] bytes = Encoding.Unicode.GetBytes(password);
            SHA256Managed hashstring = new SHA256Managed();
            byte[] hash = hashstring.ComputeHash(bytes);
            string hashString = string.Empty;
            foreach (byte x in hash)
            {
                hashString += String.Format("{0:x2}", x);
            }
            return hashString;
        }

        private void Login_Load(object sender, EventArgs e)
        {
            //ShowInTaskbar = false;
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            pictureBox4.Visible = true;
            pictureBox5.Visible = false;
            textBox2.UseSystemPasswordChar = false;

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            pictureBox5.Visible = true;
            pictureBox4.Visible = false;
            textBox2.UseSystemPasswordChar = true;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            f1.Show();
            this.WindowState = FormWindowState.Minimized;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            password = getHashSha256(textBox2.Text);
            dt = BLL1.Logins.queryLogin(password, textBox1.Text);
            //adm = (bool)dt.Rows[0][2];
            //Globais.admin = adm;
         
            if (textBox1.Text == "" || textBox2.Text == "")
            {
                MetroFramework.MetroMessageBox.Show(this, "\n\nUsername ou Password Incorretos", "ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
          


            if (dt.Rows.Count > 0)
            {
                adm = (bool)dt.Rows[0][2];
                Globais.admin = adm;

                if (adm)
                {
                    metroProgressBar1.Visible = true;
                    Globais.user = textBox1.Text;
                    for (var i = 0; i <= 1000; i++)
                    {
                        metroProgressBar1.Value = i + 1;
                    }
                    if (metroProgressBar1.Value == 1000)
                    {
                        MetroFramework.MetroMessageBox.Show(this, "\n\nPressione OK para continuar", "Bem Vindo á DorinGo", MessageBoxButtons.OK, MessageBoxIcon.Question);
                        Principal f3 = new Principal();
                        f3.Show();
                        textBox1.Clear();
                        textBox2.Clear();
                        this.Hide();
                        metroProgressBar1.Visible = false;
                    }

                }
                else
                {
                    metroProgressBar1.Visible = true;
                    Globais.user = textBox1.Text;
                    for (var i = 0; i <= 1000; i++)
                    {
                        metroProgressBar1.Value = i + 1;
                    }
                    if (metroProgressBar1.Value == 1000)
                    {
                        MetroFramework.MetroMessageBox.Show(this, "\n\nPressione OK para continuar", "Bem Vindo á DorinGo", MessageBoxButtons.OK, MessageBoxIcon.Question);
                        Principal f3 = new Principal();
                        f3.Show();
                        textBox1.Clear();
                        textBox2.Clear();
                        this.Hide();
                        metroProgressBar1.Visible = false;
                        Globais.admin = false;
                    }
                }

            }
            else
            {
                MetroFramework.MetroMessageBox.Show(this, "\n\nUsername ou Password Incorretos", "ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void metroLabel1_Click(object sender, EventArgs e)
        {

        }

        private void metroProgressBar1_Click(object sender, EventArgs e)
        {

        }
    }
}
