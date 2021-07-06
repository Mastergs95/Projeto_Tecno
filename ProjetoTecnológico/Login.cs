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
using System.Diagnostics;

namespace ProjetoTecnológico
{
    public partial class Login : MetroFramework.Forms.MetroForm
    {
        DataTable dt;
        bool adm;
        string password;
        DataTable Table;
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
            toolStripProgressBar1.Visible = false;
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
              //  adm = (bool)dt.Rows[0][2];
               // Globais.admin = adm;
      
           


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
                    toolStripProgressBar1.Visible = true;
                    for (int i = 1; i <= 10000; i++)
                    {
                        


                        toolStripProgressBar1.PerformStep();

                    }
                        if (toolStripProgressBar1.Value >= 500)
                        {
                            toolStripStatusLabel1.Text = "Doringo Application";
                            Globais.user = textBox1.Text;
                            MetroFramework.MetroMessageBox.Show(this, "\n\nPressione OK para continuar", "Bem Vindo á DorinGo", MessageBoxButtons.OK, MessageBoxIcon.Question);
                            textBox1.Clear();
                            textBox2.Clear();
                            toolStripProgressBar1.Visible = false;
                            Principal f3 = new Principal();
                            f3.Show();
                            this.Hide();
                        }



                    


                   

                }
                else
                {

                    Globais.user = textBox1.Text;
                    toolStripProgressBar1.Visible = true;
                    for (int i = 1; i <= 1000; i++)
                    {
                            toolStripProgressBar1.PerformStep();
                    }
                    if (toolStripProgressBar1.Value == 1000)
                    {
                        toolStripStatusLabel1.Text = "Doringo Application";
                        MetroFramework.MetroMessageBox.Show(this, "\n\nPressione OK para continuar", "Bem Vindo á DorinGo", MessageBoxButtons.OK, MessageBoxIcon.Question);
                        textBox1.Clear();
                        textBox2.Clear();
                        toolStripProgressBar1.Visible = false;
                        Globais.admin = false;
                        Refeições f3 = new Refeições();
                        f3.Show();
                        this.Hide();
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

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.facebook.com/Doringo-Catering-108579274721684/");
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://mastergs95.github.io/");
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.instagram.com/doringoofficial/");
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://twitter.com/doringoofficial");
        }

        private void statusStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void textBox1_MouseHover(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Introduza o utilizador";
        }

        private void textBox2_MouseHover(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Introduza a sua senha";
        }

        private void button1_MouseHover(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Clique para fazer login";
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {

            Form3 f3 = new Form3();
            f3.Show();
            Globais.user = "as";
            DataTable tb = BLL1.Logins.SelectCliente(Globais.user);

            pictureBox11.Enabled = false;
           





        }

        private void Login_MouseClick(object sender, MouseEventArgs e)
        {
          
        }

        private void pictureBox9_MouseHover(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Reportar um problema";
        }

        private void pictureBox10_MouseHover(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Visite a nossa página do twitter";
        }

        private void pictureBox8_MouseHover(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Visite a nossa página do facebook";
        }

        private void pictureBox7_MouseHover(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Visite a nossa página do instagram";
        }
    }
}
