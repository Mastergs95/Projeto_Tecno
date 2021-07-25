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
    public partial class Form1 : MetroFramework.Forms.MetroForm
    {
        string password;
        string cfpassword;
        DataTable dt;
        string usuario;
        bool adm;
        string p;
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            pictureBox9.Image.RotateFlip(RotateFlipType.Rotate90FlipNone);
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
        private void pictureBox6_Click(object sender, EventArgs e)
        {
            pictureBox7.Visible = true;
            pictureBox6.Visible = false;
            textBox3.UseSystemPasswordChar = false;
        }
        private void pictureBox7_Click(object sender, EventArgs e)
        {
            pictureBox6.Visible = true;
            pictureBox7.Visible = false;
            textBox3.UseSystemPasswordChar = true;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            password = getHashSha256(textBox2.Text);
            usuario = textBox1.Text;
            p = textBox2.Text;
            cfpassword = textBox3.Text;
            dt = BLL1.Logins.queryUser(usuario);
            if (usuario == "" || p == "" || cfpassword == "")
            {
                label5.Visible = true;
            }
            else if (p != cfpassword)
            {
            }
            else if (dt.Rows.Count > 0)
            {
            }
            else if (p == cfpassword && dt.Rows.Count == 0)
            {
                adm = true;
                int i = BLL1.Logins.insertLogin(password, usuario, adm);
                textBox2.Clear();
            }
            if (usuario != textBox9.Text)
            {
                MessageBox.Show("Introduza o nome de utilizador correto(*)");
                label3.Visible = true;
                label4.Visible = true;
            }
            if (p == cfpassword && dt.Rows.Count == 0 && textBox4.Text!="" && textBox5.Text != "" && textBox6.Text != "" && textBox7.Text != "" && textBox8.Text != "" && textBox9.Text != "" && usuario == textBox9.Text)
            {
                BLL1.Logins.insertFuncionario(textBox4.Text, textBox5.Text, textBox6.Text, textBox7.Text, textBox8.Text, textBox9.Text);
                MessageBox.Show("Registado com sucesso!");
                textBox4.Clear();
                textBox5.Clear();
                textBox6.Clear();
                textBox7.Clear();
                textBox8.Clear();
                textBox9.Clear();
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                label3.Visible = false;
                label4.Visible = false;
                label4.Visible = false;
            }
          
         
















        }
        private void label1_Click(object sender, EventArgs e)
        {
            MetroFramework.MetroMessageBox.Show(this, "\nA DorinGgo funciona com base na confiança e na transparência.Este compromisso transpõe-se para a relação do dia-a-dia com os nossos clientes. A privacidade e a segurança dos dados que nos confia são, para nós, uma prioridade.", "Política de Dados", MessageBoxButtons.OK);
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!char.IsDigit(e.KeyChar))

            {
                e.Handled = true;
            }

        }

        private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar))

            {
                e.Handled = true;
            }
        }
    }
}

    
