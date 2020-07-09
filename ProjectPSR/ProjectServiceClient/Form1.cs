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
using ProjectServiceClient.DiffFilesInterfaceRef;
using System.ServiceModel;

namespace ProjectServiceClient
{
    public partial class Form1 : Form
    {

        DiffFilesInterfaceRef.DiffFilesInterfaceClient client = new DiffFilesInterfaceRef.DiffFilesInterfaceClient();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text files (*.txt)|*.txt";
            txtEditor1.ReadOnly = true;
            txtEditor1.BackColor = SystemColors.Window;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
                txtEditor1.Text = File.ReadAllText(openFileDialog.FileName);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text files (*.txt)|*.txt";
            txtEditor2.ReadOnly = true;
            txtEditor2.BackColor = SystemColors.Window;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
                txtEditor2.Text = File.ReadAllText(openFileDialog.FileName);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if ((txtEditor1.Text.Length > 0) && (txtEditor2.Text.Length > 0))
                label1.Text = "Procent zgodności drugiego pliku z pierwszym = " + client.calculateLevenhstein(txtEditor1.Text, txtEditor2.Text).ToString() + "%";           
            else 
                MessageBox.Show("Proszę wybrać oba pliki w celu porównania", "Błąd!", MessageBoxButtons.OK, MessageBoxIcon.Error);            
        }
    }
}
