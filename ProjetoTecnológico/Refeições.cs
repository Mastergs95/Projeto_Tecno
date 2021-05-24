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
using System.IO;
using System.Drawing.Drawing2D;

namespace ProjetoTecnológico
{
    public partial class Refeições : MetroFramework.Forms.MetroForm
    {
        int t = 1;
        int qnt;
        byte[] ft;
        byte[] fot;
        int id;
        int x = 185;
        int y = 280;
        int p = 140;
        int k = 120;
        int i = 1;
        int px=280;
        int py=120;
        double preco;
        int j = 0;
        const int DRAG_HANDLE_SIZE = 7;
        public Refeições()
        {
            InitializeComponent();
            
        }

        public byte[] ImageToByteArray(System.Drawing.Image imageIn)
        {
            using (var ms = new MemoryStream())
            {
                imageIn.Save(ms, imageIn.RawFormat);
                return ms.ToArray();
            }
        }

        private void picturebox_click(object sender, EventArgs e)
        {
            
            id = (int)((PictureBox)sender).Tag;
            DataTable rf = BLL1.Refeicao.loadRefs(id);

            try
            {
                foreach (DataRow row in rf.Rows)
                {
                    Globais.prato = row["nome"].ToString();
                    fot = (byte[])row["foto"];
                    preco = Convert.ToDouble(row["preco"]);
                    pictureBox6.Image = byteArrayToImage(fot);
                }
            }
            catch (Exception erro)
            {
                if (guna2DataGridView1.RowCount == 0)
                {
                    throw new Exception("Erro ao consultar a Refeições por código. Detalhes: " + erro);
                }

            }


            //DateTime.Now.ToString()

            panel5.Visible = true;
        }
        private void Refeições_Load(object sender, EventArgs e)
        {
            guna2DataGridView1.Rows.Clear();
            guna2DataGridView1.Rows.Add(15);
            
            //guna2DataGridView1.Rows[j].Height = 60;
            int l = 373+74;
            this.Controls.Add(panel5);
            panel5.Location = new Point(500, 200);
            panel1.AutoScroll = true;
            panel2.Visible = false;
            toolStripStatusLabel9.Text = Globais.user;
            DataTable dt = BLL1.Refeicao.loadRefeições();
            MakeLabelRounded();
            panel4.AutoScrollMinSize = new Size(0, 1000);
            this.Controls.Add(panel4);
       
            //panel6.Height = 64;
            //panel6.Location = new Point(500, 10);
            //this.Controls.Add(panel6);
            //this.Controls.Add(label5);
            //label5.Location= new Point(500, 100);
            foreach (DataRow row in dt.Rows)
            {
                //picturebox
                PictureBox picturebox = new PictureBox();
                Rectangle myEllipse = new Rectangle(150, 150, -150, -150);
                GraphicsPath mypath = new GraphicsPath();
                mypath.AddEllipse(myEllipse);
                picturebox.Region = new Region(mypath);
                picturebox.Location = new Point(p, k);
                picturebox.Name = "p" + i;
                picturebox.Size = new Size(150, 150);
                picturebox.BringToFront();
                ft = (byte[])row["foto"];
                picturebox.Image = byteArrayToImage(ft);
                picturebox.SizeMode = PictureBoxSizeMode.StretchImage;
                picturebox.Tag= (int)row["id_refeicao"];
                picturebox.Click += picturebox_click;
                panel4.Controls.Add(picturebox);


                //Border


                //label
                Label label = new Label();
                label.BackColor = System.Drawing.Color.Transparent;
                label.Location = new Point(x, y);
                label.Name = "l" + i;
                label.Text = row["Nome"].ToString();
                label.Size = new Size(100, 30);
                label.BringToFront();
                label.Font = new Font("Century Gothic", 12);
                panel4.Controls.Add(label);
                this.Controls.Add(panel4);

                //label Price
                Label labell = new Label();
                labell.BackColor = System.Drawing.Color.Transparent;
                labell.Location = new Point(px,py);
                labell.Name = "ls" + i;
                labell.Text = row["Preco"].ToString()+"€";
                labell.Size = new Size(100, 30);
                labell.BringToFront();
                labell.Font = new Font("Century Gothic", 12);
                panel4.Controls.Add(labell);
                this.Controls.Add(panel4);

                x += 300;
                p += 300;
                px += 300;
                if (i % 3 == 0)
                {
                    x = 185;
                    y += 250;
                    p = 140;
                    k += 250;
                    px = 280;
                    py += 250;
                    
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
        public Image byteArrayToImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            Image returnImage = Image.FromStream(ms);
            return returnImage;
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }



        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

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
            //panel3.Controls.Add(pictureBox2);
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
            //panel3.Controls.Add(pictureBox2);
            pictureBox2.Location = new System.Drawing.Point(181, 26);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.ImageLocation = System.Windows.Forms.Application.StartupPath + @"\default.png";
            pictureBox2.Size = new System.Drawing.Size(45, 39);
            //
          
        }

        private void label_2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
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

        private void pictureBox3_Click_2(object sender, EventArgs e)
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

        private void guna2CirclePictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Tem a certeza que pretende fechar o programa?", "Sair do Programa", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
            else if (result == DialogResult.No)
            {
                //
            }
        }

        private void label4_Click_1(object sender, EventArgs e)
        {

        }
        private void MakeLabelRounded()
        {

            GraphicsPath gp = new GraphicsPath();

            gp.AddEllipse(0, 0, label4.Width, label4.Height);

            label4.Region = new Region(gp);

            label4.Invalidate();

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (panel2.Visible == false)
            {
                panel2.Visible = true;
            }
            else
            {
                panel2.Visible = false ;
            }
            

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
      
        private void button3_Click(object sender, EventArgs e)
        {
           
            
           
            
           
            
            do
            {

                guna2DataGridView1.Rows[j].Cells[0].Value = Globais.prato;
                guna2DataGridView1.Rows[j].Cells[1].Value = metroLabel1.Text;
                guna2DataGridView1.Rows[j].Cells[2].Value = preco;
                guna2DataGridView1.Rows[j].Cells[3].Value = pictureBox6.Image;
                guna2DataGridView1.Rows[j].Cells[4].Value = Image.FromFile(@"C:\Users\119190\Desktop\pt\Images\icon_lixo.png");
                j += 1;

            } while (j> 10);
                
            
            
           
            for (int i = 0; i < guna2DataGridView1.Columns.Count; i++)
            {
                if (guna2DataGridView1.Columns[i] is DataGridViewImageColumn)
                {
                    ((DataGridViewImageColumn)guna2DataGridView1.Columns[i]).ImageLayout = DataGridViewImageCellLayout.Zoom;
                }
                
            }
            panel5.Visible = false;

        
        }

     

        private void button4_Click(object sender, EventArgs e)
        {
            panel5.Visible = false;
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            qnt += 1;

            metroLabel1.Text = Convert.ToString(qnt);
        }

        private void pictureBox4_Click(object sender, EventArgs e)
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

        private void panel8_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel9_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 4) 
            {
                guna2DataGridView1.Rows.RemoveAt(e.RowIndex);

            }
        }
    }
}

