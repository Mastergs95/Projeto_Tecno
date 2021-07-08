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
namespace ProjetoTecnológico
{
    public partial class Form3 : MetroFramework.Forms.MetroForm
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            DataTable dt = BLL1.Logins.SelectCliente(Globais.user);
            if (dt == null)
            {
                MessageBox.Show("Finalize primeiro a sua compra para aceder a este painel");
            }
            else
            {
                foreach (DataRow row in dt.Rows)
                {
                    textBox1.Text = row["Usuario"].ToString();
                    textBox2.Text = row["Nome"].ToString();
                    textBox3.Text = row["Telefone"].ToString();
                    textBox4.Text = row["NIB"].ToString();
                    textBox5.Text = row["email"].ToString();
                }
            }
                    
          
        }
        private void Form3_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }

        private void Form3_FormClosing(object sender, FormClosingEventArgs e)
        {
            Globais.infouser = true;
        }

        private void Form3_Leave(object sender, EventArgs e)
        {
           
        }
    }
}
