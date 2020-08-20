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
        List<String> filesToSendList = new List<String>();
        List<double> probabilitiesList = new List<double>();


        public Form1()
        {
            InitializeComponent();
        }

        private void chooseFilesButtonOnClick(object sender, EventArgs e)
        {
            if (filesList.Items.Count > 0)
                filesList.Items.Clear();

            OpenFileDialog openFileDialog = new OpenFileDialog();
            
            openFileDialog.Filter = "Text files (*.txt)|*.txt";
            openFileDialog.Multiselect = true;

            if (openFileDialog.ShowDialog() == DialogResult.OK) 
            {
                foreach (String file in openFileDialog.FileNames)
                    filesToSendList.Add(file);
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
            for (int i = 0; i < filesToSendList.Count() - 1; i++)
            {
                filesList.Items.Add("|" + filesToSendList[i].Substring(filesToSendList[i].LastIndexOf('\\') + 1));
                for (int j = 0; j < filesToSendList.Count(); j++) 
                {
                    if (i < j)
                    {
                        double probabilityPercent = client.compareFileLetterByLetterAndCalculateProbability(filesToSendList[i], filesToSendList[j], pattern);
                        
                        filesList.Items.Add("   |" + filesToSendList[j].Substring(filesToSendList[j].LastIndexOf('\\') + 1)
                            + " " + probabilityPercent.ToString() + "%");

                        textEditorFirstFile.Text = client.compareFileLetterByLetter(filesToSendList[i], filesToSendList[j], pattern).ToString();
                    }
                }
            }
        }
    }
}
