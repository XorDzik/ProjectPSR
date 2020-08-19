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
        DiffFilesInterfaceClient client = new DiffFilesInterfaceRef.DiffFilesInterfaceClient();
        List<String> filesToSend = new List<String>();


        public Form1()
        {
            InitializeComponent();
        }

        private void chooseFilesButtonOnClick(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            
            openFileDialog.Filter = "Text files (*.txt)|*.txt";
            openFileDialog.Multiselect = true;

            if (openFileDialog.ShowDialog() == DialogResult.OK) 
            {
                foreach (String file in openFileDialog.FileNames)
                    filesToSend.Add(file);
            }
        }

        private void compareButtonOnClick(object sender, EventArgs e)
        {
            if (patternInput.TextLength == 0)
            {
                MessageBox.Show("Proszę podać pattern", "Błąd!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int pattern = int.Parse(patternInput.Text);
            for (int i = 0; i < filesToSend.Count(); i++)
            {
                for (int j = 0; j < filesToSend.Count(); j++) 
                {
                    if (i < j)
                    {
                        int howManyTheSameLetter = client.compareFileLetterByLetter(filesToSend[i], filesToSend[j], pattern);
                        txtEditor1.Text = howManyTheSameLetter.ToString();
                        // wyslij dwa pliki do porownania do serwera
                    }
                }
            }
        }
    }
}
