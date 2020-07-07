using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;
using System.IO;
using System.Windows;

namespace ProjectServiceClient
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
                txtEditor1.Text = File.ReadAllText(openFileDialog.FileName);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
                txtEditor2.Text = File.ReadAllText(openFileDialog.FileName);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if((txtEditor1.Text.Length > 0)&&(txtEditor2.Text.Length > 0)){
               label1.Text = "Tutaj wyskoczy zgodność pliku";
            }
            else {
                MessageBox.Show("Proszę wybrać oba pliki w celu porównania", "Błąd!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }
    }
}
