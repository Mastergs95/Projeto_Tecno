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
    public partial class Refeições : MetroFramework.Forms.MetroForm
    {

        int x = 400; 
            int y=300;
        int i = 1;
        public Refeições()
        {
            InitializeComponent();
        }

        private void Refeições_Load(object sender, EventArgs e)
        {
            panel1.AutoScroll = true;
            label_2.Text = "Utilizador: " + Globais.user;

            DataTable dt = BLL1.Refeicao.loadRefeições();

            foreach (DataRow row in dt.Rows)
            {
                
                Label label = new Label();
                label.Location = new Point(x, y);
                label.Name = "l" + i;
                label.Text = row["Nome"].ToString();
                label.Size = new Size(77, 21);
                label.BringToFront();
                Controls.Add(label);
                x += 250;
                
                if (i % 3==0)
                {
                    y +=200;
                    x = 400;
                }
                if (i % 6 == 0)
                {
                    y += 400;
                    x = 400;
                }
                i += 1;

            }
        }
            void TransparetBackground(Control C)
        {
            C.Visible = false;

            C.Refresh();
            Application.DoEvents();

            Rectangle screenRectangle = RectangleToScreen(this.ClientRectangle);
            int titleHeight = screenRectangle.Top - this.Top;
            int Right = screenRectangle.Left - this.Left;

            Bitmap bmp = new Bitmap(this.Width, this.Height);
            this.DrawToBitmap(bmp, new Rectangle(0, 0, this.Width, this.Height));
            Bitmap bmpImage = new Bitmap(bmp);
            bmp = bmpImage.Clone(new Rectangle(C.Location.X + Right, C.Location.Y + titleHeight, C.Width, C.Height), bmpImage.PixelFormat);
            C.BackgroundImage = bmp;

            C.Visible = true;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Refeições f1 = new Refeições();
            int c = 0;

            //Abrir form minimizado
            foreach (Form fr in Application.OpenForms)
            {

                if (fr.Name=="Principal")
                {
                    fr.Show();
                }
               
                
            }
            this.Close();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Tem a certeza que pretende terminar sessão?", "Terminar Sessão", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                foreach (Form fr in Application.OpenForms)
                {
                    fr.Show();
                }
                this.Close();
            }
            else if (result == DialogResult.No)
            {
                //...
            }
        }

        private void pictureBox3_Click_1(object sender, EventArgs e)
        {
            if (button1.Visible == false)
            {
                button1.Visible = true;
            }
            else
            {
                button1.Visible = false;
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
          
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Icon trash on panel
            PictureBox pictureBox2 = new PictureBox();
            panel3.Controls.Add(pictureBox2);
            pictureBox2.Location = new System.Drawing.Point(181, 26);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.ImageLocation = System.Windows.Forms.Application.StartupPath + @"\default.png";
            pictureBox2.Size = new System.Drawing.Size(45, 39);
            //
            
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            //Icon trash on panel
            PictureBox pictureBox2 = new PictureBox();
            panel3.Controls.Add(pictureBox2);
            pictureBox2.Location = new System.Drawing.Point(181, 26);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.ImageLocation = System.Windows.Forms.Application.StartupPath + @"\default.png";
            pictureBox2.Size = new System.Drawing.Size(45, 39);
            //
        }
    }
}
