using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace TP1DotNet
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            String finfo = "info.txt";
            textBox1.Text = File.ReadAllText(finfo);
        }






        private void Ok_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
