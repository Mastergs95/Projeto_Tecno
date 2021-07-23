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
using DataAccessLayer;
using System.Security.Cryptography;
using System.IO;

namespace ProjetoTecnológico
{
    public partial class Principal : MetroFramework.Forms.MetroForm
    {
        byte[] foti;
        byte[] foto_array;
        byte[] fota;
        byte[] foto_cv;
        int id_pack;
        byte[] foto;
        byte[] fotos;
        byte[] fote;
        string password;
        DataTable dt;
        int id;
        int x = 1;
        int NºFuncionario;
        bool status;

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


        public Principal()
        {
            InitializeComponent();
        }

        private void Principal_Load(object sender, EventArgs e)
        {
            guna2DataGridView7.DataSource = BLL1.Refeicao.loadPedido();
            guna2DataGridView9.DataSource = BLL1.Refeicao.loadPedidot();
            toolStripStatusLabel9.Text = Globais.user;
            TransparetBackground(label1);
            guna2DataGridView5.DataSource = BLL1.Refeicao.loadRefeições();
            guna2DataGridView6.DataSource = BLL1.Refeicao.loadRefeições();
            guna2DataGridView4.DataSource = BLL1.Logins.queryLoad();
            guna2DataGridView3.DataSource = BLL1.Logins.queryFunc();
            guna2DataGridView1.DataSource = BLL1.Refeicao.loadPacks();
            guna2DataGridView2.DataSource = BLL1.Refeicao.loadPacks();

            if (Globais.admin == true)

            {
                metroTile3.Visible = true;
            }
            else if (Globais.admin == false)
            {
                metroTile3.Visible = false;
            }
            //pictureBox3.Image.RotateFlip(RotateFlipType.Rotate180FlipNone);
            pictureBox4.ImageLocation = System.Windows.Forms.Application.StartupPath + @"\default.png";
            pictureBox7.ImageLocation = System.Windows.Forms.Application.StartupPath + @"\default.png";
            pictureBox5.ImageLocation = System.Windows.Forms.Application.StartupPath + @"\default.png";
        }

        private void metroLabel1_Click(object sender, EventArgs e)
        {

        }


        private void metroButton1_Click(object sender, EventArgs e)
        {
            //Abrir form minimizado
            foreach (Form fr in Application.OpenForms)
            {
                fr.WindowState = FormWindowState.Normal;
            }
            this.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
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

        private void metroTile1_Click(object sender, EventArgs e)
        {


            tabControl.Visible = true;
            tabControl2.Visible = false;
            tabControl1.Visible = false;
            tabControl3.Visible = false;
            tabControl4.Visible = false;
            pictureBox1.Visible = false;




        }

        private void metroTile3_Click(object sender, EventArgs e)
        {

            tabControl.Visible = false;
            tabControl1.Visible = true;
            tabControl2.Visible = false;
            tabControl3.Visible = false;
            tabControl4.Visible = false;
            pictureBox1.Visible = false;



        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void metroTile4_Click(object sender, EventArgs e)
        {
            tabControl.Visible = false;
            tabControl1.Visible = false;
            tabControl2.Visible = true;
            tabControl3.Visible = false;
            tabControl4.Visible = false;
            pictureBox1.Visible = false;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        //Editar Refeições
        private void numericUpDown5_Click(object sender, EventArgs e)
        {
            numericUpDown5.ReadOnly = false;
            if (textBox4.ReadOnly == false & numericUpDown5.ReadOnly == false & numericUpDown6.ReadOnly == false & numericUpDown7.ReadOnly == false & numericUpDown8.ReadOnly == false & numericUpDown14.ReadOnly == false)
            {
                metroButton2.Enabled = true;

            }
        }

        private void textBox5_Click(object sender, EventArgs e)
        {


            if (textBox4.ReadOnly == false & numericUpDown5.ReadOnly == false & numericUpDown6.ReadOnly == false & numericUpDown7.ReadOnly == false & numericUpDown8.ReadOnly == false & numericUpDown14.ReadOnly == false)
            {
                metroButton2.Enabled = true;

            }
        }

        private void textBox4_Click(object sender, EventArgs e)
        {
            textBox4.ReadOnly = false;
            if (textBox4.ReadOnly == false & numericUpDown5.ReadOnly == false & false & numericUpDown6.ReadOnly == false & numericUpDown7.ReadOnly == false & numericUpDown8.ReadOnly == false)
            {
                metroButton2.Enabled = true;

            }

        }
        private void numericUpDown6_Click(object sender, EventArgs e)
        {
            numericUpDown6.ReadOnly = false;
            if (textBox4.ReadOnly == false & numericUpDown5.ReadOnly == false & numericUpDown6.ReadOnly == false & numericUpDown7.ReadOnly == false & numericUpDown8.ReadOnly == false & numericUpDown14.ReadOnly == false)
            {
                metroButton2.Enabled = true;

            }
        }

        private void numericUpDown7_Click(object sender, EventArgs e)
        {
            numericUpDown7.ReadOnly = false;
            if (textBox4.ReadOnly == false & numericUpDown5.ReadOnly == false & numericUpDown6.ReadOnly == false & numericUpDown7.ReadOnly == false & numericUpDown8.ReadOnly == false & numericUpDown14.ReadOnly == false)
            {
                metroButton2.Enabled = true;

            }
        }

        private void numericUpDown8_Click(object sender, EventArgs e)
        {
            numericUpDown5.ReadOnly = false;
            if (textBox4.ReadOnly == false & numericUpDown5.ReadOnly == false & numericUpDown6.ReadOnly == false & numericUpDown7.ReadOnly == false & numericUpDown8.ReadOnly == false & numericUpDown14.ReadOnly == false)
            {
                metroButton2.Enabled = true;

            }
        }




        //Adicionar Refeições
        private void textBox1_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox1.ReadOnly = false;
            if (textBox1.ReadOnly == false & numericUpDown1.ReadOnly == false & numericUpDown2.ReadOnly == false & numericUpDown3.ReadOnly == false & numericUpDown4.ReadOnly == false & numericUpDown13.ReadOnly == false)
            {
                metroButton1.Enabled = true;

            }
        }

        private void textBox3_Click(object sender, EventArgs e)
        {

            if (textBox1.ReadOnly == false & numericUpDown1.ReadOnly == false & numericUpDown2.ReadOnly == false & numericUpDown3.ReadOnly == false & numericUpDown4.ReadOnly == false & numericUpDown13.ReadOnly == false)
            {
                metroButton1.Enabled = true;

            }
        }



        private void numericUpDown1_Click(object sender, EventArgs e)
        {
            numericUpDown1.Value = 0;
            numericUpDown1.ReadOnly = false;
            if (textBox1.ReadOnly == false & numericUpDown1.ReadOnly == false & numericUpDown2.ReadOnly == false & numericUpDown3.ReadOnly == false & numericUpDown4.ReadOnly == false & numericUpDown13.ReadOnly == false)
            {
                metroButton1.Enabled = true;

            }
        }

        private void numericUpDown2_Click(object sender, EventArgs e)
        {
            numericUpDown2.Value = 0;
            numericUpDown2.ReadOnly = false;
            if (textBox1.ReadOnly == false & numericUpDown1.ReadOnly == false & numericUpDown2.ReadOnly == false & numericUpDown3.ReadOnly == false & numericUpDown4.ReadOnly == false & numericUpDown13.ReadOnly == false)
            {
                metroButton1.Enabled = true;

            }
        }

        private void numericUpDown3_Click(object sender, EventArgs e)
        {
            numericUpDown3.Value = 0;
            numericUpDown3.ReadOnly = false;
            if (textBox1.ReadOnly == false & numericUpDown1.ReadOnly == false & numericUpDown2.ReadOnly == false & numericUpDown3.ReadOnly == false & numericUpDown4.ReadOnly == false & numericUpDown13.ReadOnly == false)
            {
                metroButton1.Enabled = true;

            }
        }

        private void numericUpDown4_Click(object sender, EventArgs e)
        {
            numericUpDown4.Value = 0;
            numericUpDown4.ReadOnly = false;
            if (textBox1.ReadOnly == false & numericUpDown1.ReadOnly == false & numericUpDown2.ReadOnly == false & numericUpDown3.ReadOnly == false & numericUpDown4.ReadOnly == false & numericUpDown13.ReadOnly == false)
            {
                metroButton1.Enabled = true;

            }
        }
        private void metroButton12_Click(object sender, EventArgs e)
        {
            Image img;
            openFileDialog1.CheckFileExists = true;
            openFileDialog1.DefaultExt = "png";
            openFileDialog1.Title = "Localizar Imagens";
            openFileDialog1.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox7.Image = Image.FromFile(openFileDialog1.FileName);
            }
            fote = ImageToByteArray(pictureBox7.Image);
        }
        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //  metroButton5.Enabled = true;
        }

        private void metroButton1_Click_1(object sender, EventArgs e)
        {
            fote = ImageToByteArray(pictureBox7.Image);
            if (textBox1.Text == "" || comboBox3.Text == "" || numericUpDown1.Value.ToString() == "0" || numericUpDown2.Value.ToString() == "0,00" || numericUpDown3.Value.ToString() == "0,00" || numericUpDown4.Value.ToString() == "0,00" || numericUpDown13.Value.ToString() == "0,00")
            {
                MessageBox.Show("Preencha todos os campos");
            }
            else if (textBox1.Text != "" && comboBox3.Text != "" && numericUpDown1.Value.ToString() != "0" && numericUpDown2.Value.ToString() != "0,00" && numericUpDown3.Value.ToString() != "0,00" && numericUpDown4.Value.ToString() != "0,00" && numericUpDown13.Value.ToString() != "0,00")
            {

                BLL1.Refeicao.insertRefeições(textBox1.Text, comboBox3.Text, Convert.ToInt32(numericUpDown1.Value), numericUpDown2.Value, numericUpDown3.Value, numericUpDown4.Value, fote, Convert.ToDouble(numericUpDown13.Value));
                metroProgressBar1.Visible = true;
                for (var i = 0; i <= 1000; i++)
                {
                    metroProgressBar1.Value = i + 1;
                }
                if (metroProgressBar1.Value == 1000)
                {
                    DialogResult result = MessageBox.Show("Dados inseridos com sucesso", "Adicionar Refeições", MessageBoxButtons.OK);
                    if (result == DialogResult.OK)
                    {
                        textBox1.Clear();

                        numericUpDown1.Value = 0;
                        numericUpDown2.Value = 0;
                        numericUpDown3.Value = 0;
                        numericUpDown4.Value = 0;
                        numericUpDown13.Value = 0;
                        textBox1.ReadOnly = true;

                        numericUpDown1.ReadOnly = true;
                        numericUpDown2.ReadOnly = true;
                        numericUpDown3.ReadOnly = true;
                        numericUpDown4.ReadOnly = true;
                        metroButton1.Enabled = false;
                        metroProgressBar1.Visible = false;
                        pictureBox7.ImageLocation = System.Windows.Forms.Application.StartupPath + @"\default.png";
                    }
                    guna2DataGridView5.DataSource = BLL1.Refeicao.loadRefeições();
                    guna2DataGridView6.DataSource = BLL1.Refeicao.loadRefeições();
                }




            }
        }



        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {




        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            fota = ImageToByteArray(pictureBox8.Image);
            if (textBox4.Text == "" || comboBox2.Text == "" || numericUpDown5.Value.ToString() == "0" || numericUpDown6.Value.ToString() == "0,00" || numericUpDown7.Value.ToString() == "0,00" || numericUpDown8.Value.ToString() == "0,00" || numericUpDown14.Value.ToString() == "0,00")
            {
                MessageBox.Show("Preencha todos os campos");
            }

            else if (textBox4.Text != "" && comboBox2.Text != "" && numericUpDown5.Value.ToString() != "0" && numericUpDown6.Value.ToString() != "0,00" && numericUpDown7.Value.ToString() != "0,00" && numericUpDown8.Value.ToString() != "0,00" && numericUpDown14.Value.ToString() != "0,00")
            {
                metroProgressBar2.Visible = true;
                BLL1.Refeicao.updateRefeições(id, textBox4.Text, comboBox2.Text, Convert.ToInt32(numericUpDown5.Value), numericUpDown6.Value, numericUpDown7.Value, numericUpDown8.Value, fota, Convert.ToDouble(numericUpDown14.Value));

                for (var i = 0; i <= 1000; i++)
                {
                    metroProgressBar2.Value = i + 1;
                }
                if (metroProgressBar2.Value == 1000)
                {
                    DialogResult result = MessageBox.Show("Dados editados com sucesso", "Editar Refeições", MessageBoxButtons.OK);
                    if (result == DialogResult.OK)
                    {
                        textBox4.Clear();

                        numericUpDown5.Value = 0;
                        numericUpDown6.Value = 0;
                        numericUpDown7.Value = 0;
                        numericUpDown8.Value = 0;
                        numericUpDown14.Value = 0;
                        textBox4.ReadOnly = true;

                        numericUpDown5.ReadOnly = true;
                        numericUpDown6.ReadOnly = true;
                        numericUpDown7.ReadOnly = true;
                        numericUpDown8.ReadOnly = true;
                        metroButton2.Enabled = false;
                        metroProgressBar2.Visible = false;
                        pictureBox8.Image = null;
                        guna2DataGridView5.DataSource = BLL1.Refeicao.loadRefeições();
                        guna2DataGridView6.DataSource = BLL1.Refeicao.loadRefeições();
                    }

                }
            }
        }

        private void metroButton5_Click(object sender, EventArgs e)
        {
            BLL1.Refeicao.deleteRefeições(id);
            for (var i = 0; i <= 1000; i++)
            {
                metroProgressBar3.Value = i + 1;
            }
            if (metroProgressBar3.Value == 1000)
            {
                DialogResult result = MessageBox.Show("Dados Apagados com sucesso", "Apagar Refeições Refeições", MessageBoxButtons.OK);
                if (result == DialogResult.OK)
                {
                    textBox17.Clear();
                    textBox18.Clear();
                    numericUpDown12.Value = 0;
                    numericUpDown11.Value = 0;
                    numericUpDown10.Value = 0;
                    numericUpDown9.Value = 0;
                    metroButton5.Enabled = false;
                    metroProgressBar2.Visible = false;
                    guna2DataGridView5.DataSource = BLL1.Refeicao.loadRefeições();
                    guna2DataGridView6.DataSource = BLL1.Refeicao.loadRefeições();
                    textBox4.Clear();

                    numericUpDown5.Value = 0;
                    numericUpDown6.Value = 0;
                    numericUpDown7.Value = 0;
                    numericUpDown8.Value = 0;
                    textBox4.ReadOnly = true;

                    numericUpDown5.ReadOnly = true;
                    numericUpDown6.ReadOnly = true;
                    numericUpDown7.ReadOnly = true;
                    numericUpDown8.ReadOnly = true;
                    metroButton2.Enabled = false;
                    metroProgressBar2.Visible = false;
                    pictureBox9.Image = null;
                }
            }
        }
        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {


        }

        private void metroButton3_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            f1.Show();

        }

        private void tabPage4_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void dataGridView4_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

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
        private void metroButton4_Click(object sender, EventArgs e)
        {
            password = getHashSha256(textBox11.Text);
            bool ad;
            if (metroCheckBox1.Checked == true)
            {
                ad = true;
            }
            else
            {
                ad = false;
            }
            if (textBox13.Text == Globais.user)
            {
                MessageBox.Show("Não pode editar este utilizador");
            }
            if (textBox11.Text != "" & textBox13.Text != Globais.user)
            {
                BLL1.Logins.updateLogin(textBox13.Text, password, ad);
                MessageBox.Show("Conta Atualizada");
                textBox13.Clear();
                textBox11.Clear();
                metroCheckBox1.Checked = false;
                guna2DataGridView4.DataSource = BLL1.Logins.queryLoad();


            }




        }

        private void textBox13_TextChanged(object sender, EventArgs e)
        {
            if (textBox13.Text != "" && textBox11.Text != "")
            {
                metroButton4.Enabled = true;
            }
            else
            {
                metroButton4.Enabled = false;
            }
        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {
            if (textBox13.Text != "" && textBox11.Text != "")
            {
                metroButton4.Enabled = true;
            }
            else
            {
                metroButton4.Enabled = false;
            }
        }

        private void dataGridView4_CellClick(object sender, DataGridViewCellEventArgs e)
        {


        }

        private void metroButton6_Click(object sender, EventArgs e)
        {
            if (metroCheckBox2.Checked)
            {
                status = true;
            }
            else
            {
                status = false;
            }

            if (textBox10.Text != "" && textBox2.Text != "" && textBox6.Text != "" && textBox7.Text != "" && textBox8.Text != "" && textBox9.Text != "")
            {
                BLL1.Logins.updateFunc(NºFuncionario, textBox10.Text, textBox2.Text, textBox6.Text, textBox7.Text, textBox8.Text, textBox9.Text, status);
                MessageBox.Show("Dados editados com sucesso");
                guna2DataGridView3.DataSource = BLL1.Logins.queryFunc();
                textBox10.Clear();
                textBox2.Clear();
                textBox6.Clear();
                textBox7.Clear();
                textBox8.Clear();
                textBox9.Clear();
            }
        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {
            if (textBox10.Text != "" && textBox2.Text != "" && textBox6.Text != "" && textBox7.Text != "" && textBox8.Text != "" && textBox9.Text != "")
            {
                metroButton6.Enabled = true;
            }
            else
            {
                metroButton6.Enabled = false;
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox10.Text != "" && textBox2.Text != "" && textBox6.Text != "" && textBox7.Text != "" && textBox8.Text != "" && textBox9.Text != "")
            {
                metroButton6.Enabled = true;
            }
            else
            {
                metroButton6.Enabled = false;
            }
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            if (textBox10.Text != "" && textBox2.Text != "" && textBox6.Text != "" && textBox7.Text != "" && textBox8.Text != "" && textBox9.Text != "")
            {
                metroButton6.Enabled = true;
            }
            else
            {
                metroButton6.Enabled = false;
            }
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            if (textBox10.Text != "" && textBox2.Text != "" && textBox6.Text != "" && textBox7.Text != "" && textBox8.Text != "" && textBox9.Text != "")
            {
                metroButton6.Enabled = true;
            }
            else
            {
                metroButton6.Enabled = false;
            }
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            if (textBox10.Text != "" && textBox2.Text != "" && textBox6.Text != "" && textBox7.Text != "" && textBox8.Text != "" && textBox9.Text != "")
            {
                metroButton6.Enabled = true;
            }
            else
            {
                metroButton6.Enabled = false;
            }
        }



        private void metroButton3_Click_2(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            f1.Show();
        }
        public byte[] ImageToByteArray(System.Drawing.Image imageIn)
        {
            using (var ms = new MemoryStream())
            {
                imageIn.Save(ms, imageIn.RawFormat);
                return ms.ToArray();
            }
        }
        private void metroButton7_Click(object sender, EventArgs e)
        {
            Image img;
            openFileDialog1.CheckFileExists = true;
            openFileDialog1.DefaultExt = "png";
            openFileDialog1.Title = "Localizar Imagens";
            openFileDialog1.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox4.Image = Image.FromFile(openFileDialog1.FileName);
            }
            foto = ImageToByteArray(pictureBox4.Image);


        }

        private void tabPage5_Click(object sender, EventArgs e)
        {

        }

        private void metroLabel10_Click(object sender, EventArgs e)
        {

        }

        private void metroButton8_Click(object sender, EventArgs e)
        {
            if (textBox15.Text == "" || textBox14.Text == "" || textBox12.Text == "" || numericUpDown16.Value == 0)
            {
                MessageBox.Show("Preencha todos os campos");
            }
            else
            {
                DialogResult result = MessageBox.Show("Dados inseridos com sucesso", "Adicionar Packs", MessageBoxButtons.OK);
                if (result == DialogResult.OK)
                {
                    foto = ImageToByteArray(pictureBox4.Image);
                    int x = BLL1.Refeicao.insertPacks(textBox15.Text, textBox12.Text, textBox14.Text, foto, Convert.ToDouble(numericUpDown16.Value));
                    guna2DataGridView1.DataSource = BLL1.Refeicao.loadPacks();
                    guna2DataGridView2.DataSource = BLL1.Refeicao.loadPacks();
                    textBox12.Clear();
                    textBox14.Clear();
                    textBox15.Clear();
                }
            }




        }

        private void textBox15_TextChanged(object sender, EventArgs e)
        {
            if (textBox15.Text != "" && textBox14.Text != "" && textBox12.Text != "" && numericUpDown16.Value != 0)
            {
                metroButton8.Enabled = true;
            }
            else
            {
                metroButton8.Enabled = false;
            }

        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {
            if (textBox15.Text != "" && textBox14.Text != "" && textBox12.Text != "" && numericUpDown16.Value != 0)
            {
                metroButton8.Enabled = true;
            }
            else
            {
                metroButton8.Enabled = false;
            }

        }

        private void textBox14_TextChanged(object sender, EventArgs e)
        {
            if (textBox15.Text != "" && textBox14.Text != "" && textBox12.Text != "" && numericUpDown16.Value != 0)
            {
                metroButton8.Enabled = true;
            }
            else
            {
                metroButton8.Enabled = false;
            }

        }

        private void metroButton9_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Dados editados com sucesso", "Editar Packs", MessageBoxButtons.OK);
            if (result == DialogResult.OK)
            {
                fotos = ImageToByteArray(pictureBox5.Image);
                BLL1.Refeicao.updatePacks(id_pack, textBox20.Text, textBox16.Text, textBox19.Text, fotos, Convert.ToDouble(numericUpDown17.Value));
                textBox16.Clear();
                textBox20.Clear();
                textBox19.Clear();
                numericUpDown17.Value = 0;
                guna2DataGridView1.DataSource = BLL1.Refeicao.loadPacks();
                guna2DataGridView2.DataSource = BLL1.Refeicao.loadPacks();

            }
            if (textBox16.Text == "" || textBox20.Text == "" || textBox19.Text == "" || numericUpDown17.Value == 0)
            {
                MessageBox.Show("Preencha todos os campos");
            }

        }

        private void dataGridView5_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        public Image byteArrayToImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            Image returnImage = Image.FromStream(ms);
            return returnImage;
        }
        private void dataGridView5_CellClick(object sender, DataGridViewCellEventArgs e)
        {


            try
            {
                id_pack = Convert.ToInt32(guna2DataGridView1.Rows[e.RowIndex].Cells[0].Value);
                textBox16.Text = guna2DataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                textBox19.Text = guna2DataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                textBox20.Text = guna2DataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                foto_array = (byte[])guna2DataGridView1.Rows[e.RowIndex].Cells[4].Value;
                pictureBox5.Image = byteArrayToImage(foto_array);
                textBox16.ReadOnly = false;
                textBox19.ReadOnly = false;
                textBox20.ReadOnly = false;
            }

            catch (Exception erro)
            {
                if (guna2DataGridView1.RowCount == 0)
                {
                    throw new Exception("Erro ao consultar packs por código. Detalhes: " + erro);
                }
            }
        }

        private void metroButton10_Click(object sender, EventArgs e)
        {
            Image img;
            openFileDialog1.CheckFileExists = true;
            openFileDialog1.DefaultExt = "png";
            openFileDialog1.Title = "Localizar Imagens";
            openFileDialog1.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox5.Image = Image.FromFile(openFileDialog1.FileName);
            }
            fotos = ImageToByteArray(pictureBox5.Image);
        }

        private void textBox20_TextChanged(object sender, EventArgs e)
        {
            if (textBox19.Text != "" && textBox20.Text != "" && textBox16.Text != "" && numericUpDown17.Value != 0)
            {
                metroButton9.Enabled = true;
            }
            else
            {
                metroButton9.Enabled = false;
            }

        }

        private void textBox16_TextChanged(object sender, EventArgs e)
        {
            if (textBox19.Text != "" && textBox20.Text != "" && textBox16.Text != "" && numericUpDown17.Value != 0)
            {
                metroButton9.Enabled = true;
            }
            else
            {
                metroButton9.Enabled = false;
            }
        }

        private void textBox19_TextChanged(object sender, EventArgs e)
        {
            if (textBox19.Text != "" && textBox20.Text != "" && textBox16.Text != "" && numericUpDown17.Value != 0)
            {
                metroButton9.Enabled = true;
            }
            else
            {
                metroButton9.Enabled = false;
            }
        }

        private void dataGridView6_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void metroButton11_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show("Dados apagados com sucesso", "Eliminar Packs", MessageBoxButtons.OK);
                if (result == DialogResult.OK)
                {
                    BLL1.Refeicao.deletePacks(id_pack);
                    textBox21.Clear();
                    textBox22.Clear();
                    textBox23.Clear();
                    numericUpDown18.Value = 0;
                    guna2DataGridView1.DataSource = BLL1.Refeicao.loadPacks();
                    guna2DataGridView2.DataSource = BLL1.Refeicao.loadPacks();
                }
            }
            catch (Exception erro)
            {
                if (guna2DataGridView2.RowCount == 0)
                {
                    throw new Exception("Erro ao consultar packs por código. Detalhes: " + erro);
                }
            }
        }

        private void metroButton13_Click(object sender, EventArgs e)
        {
            Image img;
            openFileDialog1.CheckFileExists = true;
            openFileDialog1.DefaultExt = "png";
            openFileDialog1.Title = "Localizar Imagens";
            openFileDialog1.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox8.Image = Image.FromFile(openFileDialog1.FileName);
            }
            foto = ImageToByteArray(pictureBox8.Image);
        }

        private void label19_Click(object sender, EventArgs e)
        {

        }

        private void guna2DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                id_pack = Convert.ToInt32(guna2DataGridView1.Rows[e.RowIndex].Cells[0].Value);
                textBox20.Text = guna2DataGridView2.Rows[e.RowIndex].Cells[1].Value.ToString();
                textBox16.Text = guna2DataGridView2.Rows[e.RowIndex].Cells[2].Value.ToString();
                textBox19.Text = guna2DataGridView2.Rows[e.RowIndex].Cells[3].Value.ToString();
                foto_array = (byte[])guna2DataGridView2.Rows[e.RowIndex].Cells[4].Value;
                pictureBox6.Image = byteArrayToImage(foto_array);
                numericUpDown17.Value = Convert.ToDecimal(guna2DataGridView2.Rows[e.RowIndex].Cells[5].Value);
                metroButton9.Enabled = true;
            }

            catch (Exception erro)
            {
                if (guna2DataGridView2.RowCount == 0)
                {
                    throw new Exception("Erro ao consultar packs por código. Detalhes: " + erro);
                }
            }
        }

        private void guna2DataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                id_pack = Convert.ToInt32(guna2DataGridView2.Rows[e.RowIndex].Cells[0].Value);
                textBox23.Text = guna2DataGridView2.Rows[e.RowIndex].Cells[1].Value.ToString();
                textBox21.Text = guna2DataGridView2.Rows[e.RowIndex].Cells[2].Value.ToString();
                textBox22.Text = guna2DataGridView2.Rows[e.RowIndex].Cells[3].Value.ToString();
                foto_array = (byte[])guna2DataGridView2.Rows[e.RowIndex].Cells[4].Value;
                pictureBox6.Image = byteArrayToImage(foto_array);
                numericUpDown18.Value = Convert.ToDecimal(guna2DataGridView2.Rows[e.RowIndex].Cells[5].Value);
                metroButton9.Enabled = true;
            }

            catch (Exception erro)
            {
                if (guna2DataGridView2.RowCount == 0)
                {
                    throw new Exception("Erro ao consultar packs por código. Detalhes: " + erro);
                }
            }
        }

        private void textBox24_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2DataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                NºFuncionario = Convert.ToInt32(guna2DataGridView3.Rows[e.RowIndex].Cells[0].Value);
                textBox10.Text = guna2DataGridView3.Rows[e.RowIndex].Cells[1].Value.ToString();
                textBox2.Text = guna2DataGridView3.Rows[e.RowIndex].Cells[2].Value.ToString();
                textBox6.Text = guna2DataGridView3.Rows[e.RowIndex].Cells[3].Value.ToString();
                textBox7.Text = guna2DataGridView3.Rows[e.RowIndex].Cells[4].Value.ToString();
                textBox8.Text = guna2DataGridView3.Rows[e.RowIndex].Cells[5].Value.ToString();
                textBox9.Text = guna2DataGridView3.Rows[e.RowIndex].Cells[6].Value.ToString();
                foreach (DataGridViewRow row in guna2DataGridView3.Rows)
                {
                    if (Convert.ToBoolean(row.Cells[7].Value = true))
                    {
                        metroCheckBox2.Checked = true;
                    }
                    else
                    {
                        metroCheckBox2.Checked = false;
                    }
                }
            }
            catch (Exception erro)
            {
                if (guna2DataGridView3.RowCount == 0)
                {
                    throw new Exception("Erro ao consultar Funcionário por código. Detalhes: " + erro);
                }
            }
            metroButton6.Enabled = true;
        }

        private void guna2DataGridView4_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                textBox13.Text = guna2DataGridView4.Rows[e.RowIndex].Cells[0].Value.ToString();
            }
            catch (Exception erro)
            {
                if (guna2DataGridView4.RowCount == 0)
                {
                    throw new Exception("Erro ao consultar Login por código. Detalhes: " + erro);
                }
            }

            foreach (DataGridViewRow row in guna2DataGridView4.Rows)
            {
                if (Convert.ToBoolean(row.Cells[2].Value = true))
                {
                    metroCheckBox1.Checked = true;
                }
                else
                {
                    metroCheckBox1.Checked = false;
                }
            }
        }

        private void guna2DataGridView5_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                id = Convert.ToInt32(guna2DataGridView5.Rows[e.RowIndex].Cells[0].Value);

                if (id != 0)
                {
                    textBox4.Text = guna2DataGridView5.Rows[e.RowIndex].Cells[1].Value.ToString();
                    comboBox2.Text = guna2DataGridView5.Rows[e.RowIndex].Cells[2].Value.ToString();
                    numericUpDown5.Value = Convert.ToDecimal(guna2DataGridView5.Rows[e.RowIndex].Cells[3].Value);
                    numericUpDown6.Value = Convert.ToDecimal(guna2DataGridView5.Rows[e.RowIndex].Cells[4].Value);
                    numericUpDown7.Value = Convert.ToDecimal(guna2DataGridView5.Rows[e.RowIndex].Cells[5].Value);
                    numericUpDown8.Value = Convert.ToDecimal(guna2DataGridView5.Rows[e.RowIndex].Cells[6].Value);
                    foto_cv = (byte[])guna2DataGridView5.Rows[e.RowIndex].Cells[7].Value;
                    pictureBox8.Image = byteArrayToImage(foto_cv);
                    numericUpDown14.Value = Convert.ToDecimal(guna2DataGridView5.Rows[e.RowIndex].Cells[8].Value);
                    metroButton2.Enabled = true;
                }
            }
            catch (Exception erro)
            {
                if (guna2DataGridView5.RowCount == 0)
                {
                    throw new Exception("Erro ao consultar a Refeições por código. Detalhes: " + erro);
                }
            }
        }

        private void guna2DataGridView6_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                id = Convert.ToInt32(guna2DataGridView6.Rows[e.RowIndex].Cells[0].Value);
                if (id != 0)
                {
                    id = Convert.ToInt32(guna2DataGridView6.Rows[e.RowIndex].Cells[0].Value);
                    textBox17.Text = guna2DataGridView6.Rows[e.RowIndex].Cells[1].Value.ToString();
                    textBox18.Text = guna2DataGridView6.Rows[e.RowIndex].Cells[2].Value.ToString();
                    numericUpDown12.Value = Convert.ToDecimal(guna2DataGridView6.Rows[e.RowIndex].Cells[3].Value);
                    numericUpDown11.Value = Convert.ToDecimal(guna2DataGridView6.Rows[e.RowIndex].Cells[4].Value);
                    numericUpDown10.Value = Convert.ToDecimal(guna2DataGridView6.Rows[e.RowIndex].Cells[5].Value);
                    numericUpDown9.Value = Convert.ToDecimal(guna2DataGridView6.Rows[e.RowIndex].Cells[6].Value);
                    foti = (byte[])guna2DataGridView6.Rows[e.RowIndex].Cells[7].Value;
                    pictureBox9.Image = byteArrayToImage(foti);
                    numericUpDown15.Value = Convert.ToDecimal(guna2DataGridView6.Rows[e.RowIndex].Cells[6].Value);
                    metroButton5.Enabled = true;
                }
            }
            catch (Exception erro)
            {
                if (guna2DataGridView6.RowCount == 0)
                {
                    throw new Exception("Erro ao consultar a Refeições por código. Detalhes: " + erro);
                }

            }
        }

        private void toolStripStatusLabel9_Click(object sender, EventArgs e)
        {
            Form4 f4 = new Form4();
            f4.Show();
        }

        private void numericUpDown4_ValueChanged(object sender, EventArgs e)
        {

        }

        private void numericUpDown13_ValueChanged(object sender, EventArgs e)
        {

        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void numericUpDown13_Click(object sender, EventArgs e)
        {
            numericUpDown13.Value = 0;
            numericUpDown13.ReadOnly = false;
            if (textBox1.ReadOnly == false & numericUpDown1.ReadOnly == false & numericUpDown2.ReadOnly == false & numericUpDown3.ReadOnly == false & numericUpDown4.ReadOnly == false & numericUpDown13.ReadOnly == false)
            {
                metroButton1.Enabled = true;

            }
        }

        private void numericUpDown14_Click(object sender, EventArgs e)
        {
            numericUpDown14.ReadOnly = false;
            if (textBox4.ReadOnly == false & numericUpDown5.ReadOnly == false & numericUpDown6.ReadOnly == false & numericUpDown7.ReadOnly == false & numericUpDown8.ReadOnly == false & numericUpDown14.ReadOnly == false)
            {
                metroButton2.Enabled = true;

            }
        }

        private void numericUpDown16_ValueChanged(object sender, EventArgs e)
        {
            if (textBox15.Text != "" && textBox14.Text != "" && textBox12.Text != "" && numericUpDown16.Value != 0)
            {
                metroButton8.Enabled = true;
            }
            else
            {
                metroButton8.Enabled = false;
            }
        }

        private void numericUpDown17_ValueChanged(object sender, EventArgs e)
        {
            if (textBox19.Text != "" && textBox20.Text != "" && textBox16.Text != "" && numericUpDown17.Value != 0)
            {
                metroButton9.Enabled = true;
            }
            else
            {
                metroButton9.Enabled = false;
            }
        }

        private void numericUpDown16_Click(object sender, EventArgs e)
        {
            numericUpDown16.ReadOnly = false;
        }

        private void numericUpDown17_Click(object sender, EventArgs e)
        {
            numericUpDown17.ReadOnly = false;
        }

        private void metroTile5_Click(object sender, EventArgs e)
        {
            tabControl.Visible = false;
            tabControl1.Visible = false;
            tabControl2.Visible = false;
            tabControl3.Visible = true;
            pictureBox1.Visible = false;
        }

        private void tabPage8_Click(object sender, EventArgs e)
        {

        }

        private void tabPage6_Click(object sender, EventArgs e)
        {

        }

        private void metroTile2_Click(object sender, EventArgs e)
        {
            tabControl.Visible = false;
            tabControl1.Visible = false;
            tabControl2.Visible = false;
            tabControl3.Visible = false;
            tabControl4.Visible = true;
            pictureBox1.Visible = false;
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(textBox2.Text, "[^0-9]"))
            {
                MessageBox.Show("Please enter only numbers.");
                textBox2.Text = textBox2.Text.Remove(textBox2.Text.Length - 1);
            }
        }

        private void metroButton14_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in guna2DataGridView7.Rows)
            {
                int idp=0;
                bool et=false;
                int pos = row.Index;
                if (guna2DataGridView7.Rows[pos].Cells[6].Selected == true)
                    {
                    idp = (int)guna2DataGridView7.Rows[pos].Cells[0].Value;
                    et = Convert.ToBoolean(guna2DataGridView7.Rows[pos].Cells[7].Value);

                }
                BLL1.Refeicao.updatePedido(idp, et);
                guna2DataGridView7.DataSource = BLL1.Refeicao.loadPedido();
                guna2DataGridView9.DataSource = BLL1.Refeicao.loadPedidot();
            }
        }
    }
}


