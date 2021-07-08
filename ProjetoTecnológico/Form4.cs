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
    public partial class Form4 : MetroFramework.Forms.MetroForm
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            DataTable dt = BLL1.Logins.selectFunc(Globais.user);
            if (dt == null)
            {
                MessageBox.Show("Finalize primeiro a sua compra para aceder a este painel");
            }
            else
            {
                foreach (DataRow row in dt.Rows)
                {
                    textBox1.Text = row["Nome"].ToString();
                    textBox2.Text = row["Telefone"].ToString();
                    textBox3.Text = row["email"].ToString();
                    textBox4.Text = row["NIF"].ToString();
                    textBox5.Text = row["Morada"].ToString();
                    textBox6.Text = row["Usuario"].ToString();
                }
            }
        }
    }
}
