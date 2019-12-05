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
            
            if(openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {

            }
            else
            {
                MessageBox.Show("Changement annulée", "Alerte", MessageBoxButtons.OK);
            }
        }
    }
}
