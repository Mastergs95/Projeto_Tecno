using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace ProjetoTecnológico
{
    public partial class AddCarrinho : MetroFramework.Forms.MetroForm
    {
        int qnt=1;
        public AddCarrinho()
        {
            InitializeComponent();
        }
       
       
        private void AddCarrinho_Load(object sender, EventArgs e)
        {
            this.Text = Globais.prato;
            //this.TopMost = true;
            metroLabel1.Text = Convert.ToString(qnt);

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            qnt += 1;
            
            metroLabel1.Text = Convert.ToString(qnt);
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            
            if (qnt == 1)
            {
                qnt = 1;
                metroLabel1.Text = Convert.ToString(qnt);
            }
            else
            {
                qnt -= 1;
            }
            metroLabel1.Text = Convert.ToString(qnt);
        }

     

        private void button1_Click(object sender, EventArgs e)
        {
           
            foreach (Form fr in Application.OpenForms)
            {

                if (fr.Name == "Refeições")
                {
                    fr.WindowState = FormWindowState.Maximized;
                    fr.Enabled = true;
                }


            }
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            PictureBox picture2 = new PictureBox();
            Refeições F1 = new Refeições();
            Panel F2 = new Panel();
            
            foreach (Control c in F1.Controls)
                if (c.Name == "panel4")
                {
                    foreach (Control a in F2.Controls)
                        if (a.Name == "panel2")
                        {
                            foreach (Control t in a.Controls)
                                if (t.Name == "panel3")
                                {

                                    c.Controls.Add(pictureBox2);
                                    picture2.Location = new System.Drawing.Point(181, 26);
                                    picture2.SizeMode = PictureBoxSizeMode.StretchImage;
                                    picture2.ImageLocation = System.Windows.Forms.Application.StartupPath + @"\default.png";
                                    picture2.Size = new System.Drawing.Size(45, 39);
                                    

                                    foreach (Form fr in Application.OpenForms)


                                        if (fr.Name == "Refeições")
                                        {
                                            fr.WindowState = FormWindowState.Maximized;
                                            fr.Enabled = true;
                                        }

                                    this.Close();
                                }
                        }
                }


        }
    }
}
