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
using System.Threading;
using System.Drawing.Printing;

namespace ProjetoTecnológico
{
    public partial class Refeições : MetroFramework.Forms.MetroForm
    {
        int pedido = 0;
        DataTable def;
        int itens = 0;
        int litens = 0;
        bool vs = true;
        bool vz = true;
        int t = 1;
        int qnt;
        byte[] ft;
        byte[] fot;
        int id;
        //Refeiçoes
        int x = 140;
        int y = 280;
        int p = 140;
        int k = 120;
        int i = 1;
        int px = 280;
        int py = 120;
        //packs
        int q = 150;
        int w = 280;
        int a = 140;
        int s = 120;
        int l = 1;
        int xq = 280;
        int xw = 120;
        //
        double preco;
        int j = 0;
        int m;
        const int DRAG_HANDLE_SIZE = 7;
        string pic;
        
        public Refeições()
        {
            InitializeComponent();
            printDocument1.PrintPage += new PrintPageEventHandler(printDocument1_PrintPage);
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
            panel2.Visible = false;
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
                    label10.Text = Globais.prato;
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
            pic = ((PictureBox)sender).Name;
            panel5.Visible = true;





        }
        private void Refeições_Load(object sender, EventArgs e)
        {
            panel4.Visible = true;
            panel8.Visible = false;
            panel7.Visible = false;
            metroTile1.Enabled = false;
            metroTile4.Enabled = true;
            
            if (vz == true)
            {


                guna2DataGridView1.Rows.Clear();
                guna2DataGridView1.Rows.Add(10);

                //guna2DataGridView1.Rows[j].Height = 60;
                int l = 373 + 74;
                this.Controls.Add(panel5);
                panel5.Location = new Point(500, 200);
                panel1.AutoScroll = true;
                panel2.Visible = false;
                toolStripStatusLabel9.Text = Globais.user;
                def = BLL1.Refeicao.loadRefeições();
                MakeLabelRounded();
                panel4.AutoScrollMinSize = new Size(0, 1000);
                this.Controls.Add(panel4);

                //panel6.Height = 64;
                //panel6.Location = new Point(500, 10);
                //this.Controls.Add(panel6);
                //this.Controls.Add(label5);
                //label5.Location= new Point(500, 100);
                foreach (DataRow row in def.Rows)
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
                    picturebox.Tag = (int)row["id_refeicao"];
                    picturebox.Click += picturebox_click;
                    panel4.Controls.Add(picturebox);


                    //Border


                    //label
                    Label label = new Label();
                    label.BackColor = System.Drawing.Color.Transparent;
                    label.Location = new Point(x, y);
                    label.Name = "l" + i;
                    label.Text = row["Nome"].ToString();
                    label.Size = new Size(200, 50);
                    label.BringToFront();
                    label.Font = new Font("Century Gothic", 12);
                    panel4.Controls.Add(label);
                    this.Controls.Add(panel4);

                    //label Price
                    Label labell = new Label();
                    labell.BackColor = System.Drawing.Color.Transparent;
                    labell.Location = new Point(px, py);
                    labell.Name = "ls" + i;
                    labell.Text = row["Preco"].ToString() + "€";
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
                        x = 140;
                        y += 250;
                        p = 140;
                        k += 250;
                        px = 280;
                        py += 250;

                    }

                    i += 1;

                }
            }
            vz = false;

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
                foreach (DataGridViewRow row in guna2DataGridView3.Rows)
                {
                    guna2DataGridView3.Rows.RemoveAt(row.Index);
                }
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

            gp.AddEllipse(0, 0, label3.Width, label3.Height);

            label3.Region = new Region(gp);

            label3.Invalidate();

            GraphicsPath gl = new GraphicsPath();

            gl.AddEllipse(0, 0, label4.Width, label4.Height);

            label4.Region = new Region(gl);

            label4.Invalidate();

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

            if (String.IsNullOrEmpty((string)guna2DataGridView1.Rows[0].Cells[0].Value))
            {
                label2.Visible = true;
                panel2.Visible = false;



            }
            else
            {
                label2.Visible = false;
                if (panel2.Visible == false)
                {
                    panel2.Visible = true;
                }
                else
                {
                    panel2.Visible = false;
                }
            }




        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            pictureBox2.Enabled = true;


            foreach (Control x in panel4.Controls)
            {
                if (x is PictureBox)
                {
                    if (x.Name == pic)
                    {
                        x.Enabled = false;
                    }
                }
            }




            do
            {

                itens += 1;
                label4.Text = Convert.ToString(itens);
                if (j < 10)
                {
                    
                    guna2DataGridView1.Rows[j].Cells[0].Value = Globais.prato;
                    guna2DataGridView1.Rows[j].Cells[1].Value = metroLabel1.Text;
                    int qunti = Convert.ToInt32(metroLabel1.Text);
                    guna2DataGridView1.Rows[j].Cells[2].Value = preco*qunti;
                    guna2DataGridView1.Rows[j].Cells[3].Value = pictureBox6.Image;
                    guna2DataGridView1.Rows[j].Cells[5].Value = id;
                    // guna2DataGridView1.Rows[j].Cells[4].Value = Image.FromFile(@"C:\Users\119190\Desktop\pt\Images\icon_lixo.png");
                    j += 1;


                }

                else
                {
                    MessageBox.Show("Carrinho Cheio!");
                    itens = 10;
                }
            } while (j > 10);




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

            metroLabel1.Text = "1";
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



        private void guna2DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 4 & String.IsNullOrWhiteSpace((string)guna2DataGridView1.Rows[0].Cells[0].Value))
                {
                    MessageBox.Show("Nenhum item adicionado ao carrinho", "Erro Refeições",
      MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (e.ColumnIndex == 4)
                {
                    guna2DataGridView1.Rows.RemoveAt(e.RowIndex);
                    guna2DataGridView1.Rows.Add(1);
                    foreach (Control x in panel4.Controls)
                    {
                        if (x is PictureBox)
                        {
                            if (x.Name == pic)
                            {
                                x.Enabled = true;
                            }
                        }
                    }

                    if (itens == 0)
                    {
                        itens = 0;
                        label4.Text = Convert.ToString(itens);
                    }
                    else
                    {
                        itens -= 1;
                        label4.Text = Convert.ToString(itens);
                    }


                    j -= 1;
                }

            }
            catch (Exception erro) { }
        }

        private void metroTile1_Click(object sender, EventArgs e)
        {
            panel4.Visible = true;
            panel8.Visible = false;
            panel7.Visible = false;
            metroTile1.Enabled = false;
            metroTile4.Enabled = true;

            if (vz == true)
            {


                guna2DataGridView1.Rows.Clear();
                guna2DataGridView1.Rows.Add(10);

                //guna2DataGridView1.Rows[j].Height = 60;
                
                this.Controls.Add(panel5);
                panel5.Location = new Point(500, 200);
                panel1.AutoScroll = true;
                panel2.Visible = false;
                toolStripStatusLabel9.Text = Globais.user;
                def = BLL1.Refeicao.loadRefeições();
                MakeLabelRounded();
                panel4.AutoScrollMinSize = new Size(0, 1000);
                this.Controls.Add(panel4);

                //panel6.Height = 64;
                //panel6.Location = new Point(500, 10);
                //this.Controls.Add(panel6);
                //this.Controls.Add(label5);
                //label5.Location= new Point(500, 100);
                foreach (DataRow row in def.Rows)
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
                    picturebox.Tag = (int)row["id_refeicao"];
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
                    labell.Location = new Point(px, py);
                    labell.Name = "ls" + i;
                    labell.Text = row["Preco"].ToString() + "€";
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
            vz = false;
        }

        private void metroTile4_Click(object sender, EventArgs e)
        {

            panel4.Visible = false;
            panel2.Visible = false;
            panel7.Visible = true;
            metroTile1.Enabled = true;
            metroTile4.Enabled = false;
            if (vs == true)
            {


                guna2DataGridView2.Rows.Clear();
                guna2DataGridView2.Rows.Add(10);

                //guna2DataGridView1.Rows[j].Height = 60;
                
                this.Controls.Add(panel7);
               // panel7.Location = new Point(500, 200);
                panel1.AutoScroll = true;
                panel8.Visible = false;
                toolStripStatusLabel9.Text = Globais.user;
                DataTable dt = BLL1.Refeicao.loadPacks();
                MakeLabelRounded();
                panel7.AutoScrollMinSize = new Size(0, 1000);
                this.Controls.Add(panel7);

                foreach (DataRow row in dt.Rows)
                {
                    //picturebox
                    PictureBox pictureboxx = new PictureBox();
                    Rectangle myEllipse = new Rectangle(150, 150, -150, -150);
                    GraphicsPath mypath = new GraphicsPath();
                    mypath.AddEllipse(myEllipse);
                    pictureboxx.Region = new Region(mypath);
                    pictureboxx.Location = new Point(a, s);
                    pictureboxx.Name = "p" + l;
                    pictureboxx.Size = new Size(150, 150);
                    pictureboxx.BringToFront();
                    ft = (byte[])row["foto"];
                    pictureboxx.Image = byteArrayToImage(ft);
                    pictureboxx.SizeMode = PictureBoxSizeMode.StretchImage;
                    pictureboxx.Tag = (int)row["Id_pack"];
                    pictureboxx.Click += pictureboxx_click;
                    panel7.Controls.Add(pictureboxx);


                    //Border


                    //label
                    Label label = new Label();
                    label.BackColor = System.Drawing.Color.Transparent;
                    label.Location = new Point(q, w);
                    label.Name = "l" + l;
                    label.Text = row["nome"].ToString();
                    label.Size = new Size(200, 50);
                    label.BringToFront();
                    label.Font = new Font("Century Gothic", 12);
                    panel7.Controls.Add(label);
                    this.Controls.Add(panel7);

                    //label Price
                    Label labell = new Label();
                    labell.BackColor = System.Drawing.Color.Transparent;
                    labell.Location = new Point(xq, xw);
                    labell.Name = "ls" + l;
                    labell.Text = row["preco"].ToString() + "€";
                    labell.Size = new Size(100, 50);
                    labell.BringToFront();
                    labell.Font = new Font("Century Gothic", 12);
                    panel7.Controls.Add(labell);
                    this.Controls.Add(panel7);

                    q += 300;
                    a += 300;
                    xq += 300;
                    if (l % 3 == 0)
                    {
                        q = 150;
                        w += 250;
                        a = 140;
                        s += 250;
                        xq = 280;
                        xw += 250;

                    }

                    l += 1;

                }
            }
            vs = false;
        }
        private void pictureboxx_click(object sender, EventArgs e)
        {
            panel8.Visible = false;

            id = (int)((PictureBox)sender).Tag;
            DataTable rp = BLL1.Refeicao.loadPk(id);

            try
            {
                foreach (DataRow row in rp.Rows)
                {
                    Globais.pack = row["nome"].ToString();
                    fot = (byte[])row["foto"];
                    preco = Convert.ToDouble(row["preco"]);
                    pictureBox10.Image = byteArrayToImage(fot);
                    label9.Text = "Pack " + Globais.pack;

                }
            }
            catch (Exception erro)
            {

                if (guna2DataGridView2.RowCount == 0)
                {
                    throw new Exception("Erro ao consultar a Packs por código. Detalhes: " + erro);
                }

            }


            //DateTime.Now.ToString()
            pic = ((PictureBox)sender).Name;
            panel9.Visible = true;

        }

        private void button2_Click_2(object sender, EventArgs e)
        {
            pictureBox7.Enabled = true;



            foreach (Control x in panel7.Controls)
            {
                if (x is PictureBox)
                {
                    if (x.Name == pic)
                    {
                        x.Enabled = false;
                    }
                }
            }


            do
            {
                litens += 1;
                label3.Text = Convert.ToString(litens);
                if (m < 10)
                {

                    guna2DataGridView2.Rows[m].Cells[0].Value = Globais.pack;
                    guna2DataGridView2.Rows[m].Cells[1].Value = metroLabel4.Text;
                    guna2DataGridView2.Rows[m].Cells[2].Value = preco;
                    guna2DataGridView2.Rows[m].Cells[3].Value = pictureBox10.Image;
                    // guna2DataGridView1.Rows[j].Cells[4].Value = Image.FromFile(@"C:\Users\119190\Desktop\pt\Images\icon_lixo.png");
                    m += 1;


                }
                else
                {
                    MessageBox.Show("Carrinho Cheio!");
                    litens = 10;
                }
            } while (m > 10);




            for (int i = 0; i < guna2DataGridView2.Columns.Count; i++)
            {
                if (guna2DataGridView2.Columns[i] is DataGridViewImageColumn)
                {
                    ((DataGridViewImageColumn)guna2DataGridView2.Columns[i]).ImageLayout = DataGridViewImageCellLayout.Zoom;
                }

            }
            panel9.Visible = false;
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty((string)guna2DataGridView2.Rows[0].Cells[0].Value))
            {
                label7.Visible = true;
                panel8.Visible = false;



            }
            else
            {
                label7.Visible = false;
                if (panel8.Visible == false)
                {
                    panel8.Visible = true;
                }
                else
                {
                    panel8.Visible = false;
                }
            }
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            qnt += 1;

            metroLabel4.Text = Convert.ToString(qnt);
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            if (qnt == 1)
            {
                qnt = 1;
                metroLabel4.Text = Convert.ToString(qnt);
            }
            else
            {
                qnt -= 1;
            }
            metroLabel4.Text = Convert.ToString(qnt);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            panel9.Visible = false;

            metroLabel4.Text = "1";
        }

        private void pictureBox11_Click(object sender, EventArgs e)
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

        private void guna2DataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 4 & String.IsNullOrWhiteSpace((string)guna2DataGridView2.Rows[0].Cells[0].Value))
                {
                    MessageBox.Show("Nenhum item adicionado ao carrinho", "Erro Packs",
      MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (e.ColumnIndex == 4)
                {
                    foreach (Control x in panel7.Controls)
                    {
                        if (x is PictureBox)
                        {
                            if (x.Name == pic)
                            {
                                x.Enabled = true;
                            }
                        }
                    }
                    guna2DataGridView2.Rows.RemoveAt(e.RowIndex);
                    guna2DataGridView2.Rows.Add(1);
                    m -= 1;
                    if (litens == 0)
                    {
                        litens = 0;
                        label3.Text = Convert.ToString(litens);
                    }
                    else
                    {
                        litens -= 1;
                        label3.Text = Convert.ToString(litens);
                    }
                }

            }
            catch (Exception erro) { }
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace((string)guna2DataGridView2.Rows[0].Cells[0].Value))
            {
                MessageBox.Show("Nenhum item adicionado ao carrinho", "Erro Packs",
                MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {

                string data = DateTime.Now.ToString("dd-MM-yyyy");
                foreach (DataGridViewRow row in guna2DataGridView1.Rows)
                {
                    int pos = row.Index;
                    if (String.IsNullOrWhiteSpace((string)guna2DataGridView1.Rows[pos].Cells[0].Value))
                    { }
                    else
                    {
                        guna2DataGridView1.Rows[pos].Cells[0].Value.ToString();
                        panel12.Visible = true;
                        panel12.BringToFront();

                    }

                }
            }


            guna2DataGridView2.Visible = false;
            panel10.Visible = true;
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {

            if (String.IsNullOrWhiteSpace((string)guna2DataGridView1.Rows[0].Cells[0].Value))
            {
                MessageBox.Show("Nenhum item adicionado ao carrinho", "Erro Refeições",
                MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {
                guna2DataGridView2.Rows.Add(10);
                if (String.IsNullOrWhiteSpace((string)guna2DataGridView2.Rows[0].Cells[0].Value))
                {
                    Globais.pack = "NULL";
                }
                else
                {
                    Globais.pack = guna2DataGridView2.Rows[0].Cells[0].Value.ToString();
                }
            }
            bool r = false;
            string data = DateTime.Now.ToString("dd-MM-yyyy");
            foreach (DataGridViewRow row in guna2DataGridView1.Rows)
            {
                int pos = row.Index;


                if (String.IsNullOrWhiteSpace((string)guna2DataGridView1.Rows[pos].Cells[0].Value))
                { }
                else
                {
                    panel12.Visible = true;
                    panel12.BringToFront();
                }

            }








            guna2DataGridView1.Visible = false;
            guna2DataGridView2.Visible = false;
            panel10.Visible = true;
            panel6.Visible = false;
            panel2.Visible = false;
            metroTile4.Enabled = false;
        }
        

        private void guna2CirclePictureBox1_Click_1(object sender, EventArgs e)
        {
            foreach (DataRow row in def.Rows)
            {
                if (row["Nome"].ToString() == guna2TextBox1.Text)
                {

                }
            }
        }

        private void metroButton3_Click(object sender, EventArgs e)
        {
            try
            {
                CaptureScreen();
                printDocument1.Print();
                
            }
            catch(Exception l) { }
            metroButton4.Enabled = true;
            metroButton3.Enabled = false;

        }
        private void CaptureScreen()
        {
            Graphics myGraphics = this.CreateGraphics();
            Size s = this.panel10.Size;
            memoryImage = new Bitmap(s.Width, s.Height, myGraphics);
            Graphics memoryGraphics = Graphics.FromImage(memoryImage);
            memoryGraphics.CopyFromScreen(this.Location.X + this.panel10.Location.X, this.Location.Y + this.panel10.Location.Y + 30, 0, 0, s);
        }

        private PrintDocument printDocument1 = new PrintDocument();
        Bitmap memoryImage;
        private void printDocument1_PrintPage(System.Object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            var image = new Bitmap(this.Width, this.Height);
            var graphics = Graphics.FromImage(image);
            graphics.CopyFromScreen(this.Location.X+400, this.Location.Y-200, 0, 0, this.Size);
            e.Graphics.DrawImage(image, 0, 0);
        }

        private void metroButton4_Click(object sender, EventArgs e)
        {
           

        }

        private void metroButton5_Click(object sender, EventArgs e)
        {

           
        }

        private void panel11_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            
            string datehj = DateTime.Now.ToString();
            MessageBox.Show(datehj + dateTimePicker1.Value.ToShortDateString());
            if (textBox7.Text == "" || textBox6.Text == ""  || Convert.ToDateTime(dateTimePicker1.Value.ToString()) < Convert.ToDateTime(datehj) || Convert.ToDateTime(dateTimePicker1.Value.ToString()) == Convert.ToDateTime(datehj))
            {
                MessageBox.Show("Por favor preencha todos os campos ou insira uma data válida");
            }
            else
            {
                //insertpedido
                int hr = dateTimePicker2.Value.Hour;
                int min = dateTimePicker2.Value.Minute;
                string hrt;
                if (min < 10)
                {
                    hrt = Convert.ToString(hr + ":0" + min);
                }
                else
                {
                    hrt = Convert.ToString(hr + ":" + min);
                }
                
                string dat = dateTimePicker2.Value.ToShortDateString();
                BLL1.Refeicao.insertPedido(Globais.user, dat,textBox6.Text,textBox7.Text,textBox8.Text, hrt,false);
                //
                Globais.idpedido = (int)BLL1.Refeicao.querymaxid();

                foreach (DataGridViewRow row in guna2DataGridView1.Rows)
                {

                    int pos = row.Index;
                    
                       if (guna2DataGridView1.Rows[pos].Cells[5].Value != null)
                    {
                        int idref = (int)guna2DataGridView1.Rows[pos].Cells[5].Value;
                        int qta= Convert.ToInt32(guna2DataGridView1.Rows[pos].Cells[1].Value);
                       
                        BLL1.Refeicao.insertReforid(Globais.idpedido, idref,qta);
                    }
                           
                }
                int precot =0;
                foreach (DataGridViewRow row in guna2DataGridView1.Rows)
                {

                    int pos = row.Index;

                    if (guna2DataGridView1.Rows[pos].Cells[2].Value != null)
                    {
                        precot += Convert.ToInt32(guna2DataGridView1.Rows[pos].Cells[2].Value);
                        
                    }
                }
                textBox5.Text = Convert.ToString(precot);
                String datatd = DateTime.Now.ToString("dd/MM/yyyy");
                string useri = "teste";
                guna2DataGridView3.DataSource = BLL1.Refeicao.queryRefid(Globais.idpedido, 30);
                panel12.Visible = false;
                // guna2DataGridView3.DataSource = BLL1.Refeicao.loadPedido();
            }

           
           
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text.Length == 9 && textBox3.Text.Length == 9 && textBox4.Text != "")
            {
                metroButton3.Enabled = true;
            }
            else
            {
                metroButton3.Enabled = false;
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text.Length == 9 && textBox3.Text.Length == 9 && textBox4.Text != "")
            {
                metroButton3.Enabled = true;
            }
            else
            {
                metroButton3.Enabled = false;
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text.Length == 9 && textBox3.Text.Length == 9 && textBox4.Text != "")
            {
                metroButton3.Enabled = true;
            }
            else
            {
                metroButton3.Enabled = false;
            }
            if (textBox3.Text.Length == 9)
            {
                label21.Visible = true;
                label21.BringToFront();
            }
            else
            {
                label21.Visible = false;
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text.Length==9 && textBox3.Text.Length==9  && textBox4.Text != "")
            {
                metroButton3.Enabled = true;

            }
            else
            {
                metroButton3.Enabled = false;
            }
            if (textBox2.Text.Length == 9)
            {
                label18.Visible = true;
                label18.BringToFront();
            }
            else
            {
                label18.Visible = false;
            }
          
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text.Length == 9 && textBox3.Text.Length == 9 && textBox4.Text != "")
            {
                metroButton3.Enabled = true;
            }
            else
            {
                metroButton3.Enabled = false;
            }
        }

        private void metroLabel10_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            Login l1 = new Login();
            l1.Show();
            this.Hide();
        }

        private void metroButton4_Click_1(object sender, EventArgs e)
        {
            //BLL1.Logins.insertCliente(Globais.user, textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text);
            panel11.Visible = true;
            panel11.BringToFront();
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(textBox2.Text, "[^0-9]"))
            {
                MessageBox.Show("Please enter only numbers.");
                textBox2.Text = textBox2.Text.Remove(textBox2.Text.Length - 1);
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(textBox3.Text, "[^0-9]"))
            {
                MessageBox.Show("Please enter only numbers.");
                textBox3.Text = textBox3.Text.Remove(textBox3.Text.Length - 1);
            }
        }

        private void panel11_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void toolStripStatusLabel9_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3();
            f3.Show();
        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}





