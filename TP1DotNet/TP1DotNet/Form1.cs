using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TP1DotNet
{
    public partial class Form1 : Form
    {
        Form2 frm2 = new Form2();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void ButtonQuitter(object sender, EventArgs e)
        {
            Close();
        }

        private void QuitterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void OuvrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.InitialDirectory = @"C:\Temp";
            openFileDialog1.Filter = "Jpeg (*.jpg)|*.jpg|PNG (*.png)|*.png|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 0;
            openFileDialog1.FileName = "";
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                try
                {
                    string filePath = openFileDialog1.FileName.ToString();
                    pictureBox1.Load(filePath);
                    textBox1.Text = openFileDialog1.FileName;
                    pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
                }
                catch
                {
                    MessageBox.Show("Problème d'ouverture", "Alerte", MessageBoxButtons.OK,MessageBoxIcon.Error);
                }


            }
            else
            {
                MessageBox.Show("Changement annulée", "Alerte", MessageBoxButtons.OK);
            }
        }


        public static bool GrayScale(Bitmap bmp)
        {
            try
            {
                for (int y = 0; y < bmp.Height; y++)
                {
                    for (int x = 0; x < bmp.Width; x++)
                    {
                        Color c = bmp.GetPixel(x, y);
                        int luma = (int)(c.R * 0.3 + c.G * 0.59 + c.B * 0.11);
                        bmp.SetPixel(x, y, Color.FromArgb(luma, luma, luma));
                    }
                }
                return true;
            }
            catch (Exception) { return false; }
        }

        public static bool InvertColors(Bitmap bmp)
        {
            Color cSource;
            Color cDest;
            try
            {
                for (int y = 0; y < bmp.Height; y++)
                {
                    for (int x = 0; x < bmp.Width; x++)
                    {
                        cSource = bmp.GetPixel(x, y);
                        cDest = Color.FromArgb(255 - cSource.R, 255 - cSource.G, 255 - cSource.B);
                        bmp.SetPixel(x, y, cDest);
                    }
                }
                return true;
            }
            catch (Exception) { return false; }
        }

        public static bool ToGreen(Bitmap bmp)
        {
            Color cSource;
            Color cDest;
            try
            {
                for (int y = 0; y < bmp.Height; y++)
                {
                    for (int x = 0; x < bmp.Width; x++)
                    {
                        cSource = bmp.GetPixel(x, y);
                        cDest = Color.FromArgb(0, cSource.G, 0);
                        bmp.SetPixel(x, y, cDest);
                    }
                }
                return true;
            }
            catch (Exception) { return false; }
        }

        public static bool ToBlue(Bitmap bmp)
        {
            Color cSource;
            Color cDest;
            try
            {
                for (int y = 0; y < bmp.Height; y++)
                {
                    for (int x = 0; x < bmp.Width; x++)
                    {
                        cSource = bmp.GetPixel(x, y);
                        cDest = Color.FromArgb(0, 0, cSource.B);
                        bmp.SetPixel(x, y, cDest);
                    }
                }
                return true;
            }
            catch (Exception) { return false; }
        }

        public static bool ToRed(Bitmap bmp)
        {
            Color cSource;
            Color cDest;
            try
            {
                for (int y = 0; y < bmp.Height; y++)
                {
                    for (int x = 0; x < bmp.Width; x++)
                    {
                        cSource = bmp.GetPixel(x, y);
                        cDest = Color.FromArgb(cSource.R, 0, 0);
                        bmp.SetPixel(x, y, cDest);
                    }
                }
                return true;
            }
            catch (Exception) { return false; }
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(textBox1.Text))
            {
                Bitmap paribas = new Bitmap(textBox1.Text);
                switch (comboBox1.SelectedIndex)
                {
                    case 1:
                        ToBlue(paribas);
                        break;
                    case 2:
                        ToRed(paribas);
                        break;
                    case 3:
                        ToGreen(paribas);
                        break;
                    case 4:
                        InvertColors(paribas);
                        break;
                    case 5:
                        GrayScale(paribas);
                        break;                            
                }
                pictureBox1.Image = paribas;
                pictureBox1.Invalidate();
            }
        }

        private void Strech_CheckedChanged(object sender, EventArgs e)
        {
            if(Strech.Checked == true)
            {          
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            else
            {
                pictureBox1.SizeMode = PictureBoxSizeMode.Normal;
                pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
            }
            
        }

        private void AproposToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frm2.ShowDialog();
        }
    }
}
