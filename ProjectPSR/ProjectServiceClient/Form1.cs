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
        List<string> filesToSendList = new List<string>();
        List<string> filesToDisplayList = new List<string>();
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

            if (letterByLetterRadioButton.Checked)
            {
                sendDataForCompareLetterByLetter();
            }
            else if (wordByWordRadioButton.Checked)
            {
                sendDataForCompareWordByWord();
            }
            else
            {
                MessageBox.Show("Proszę wybrać metodę porównania", "Błąd!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void sendDataForCompareLetterByLetter()
        {
            int pattern = int.Parse(patternInput.Text);
            for (int i = 0; i < filesToSendList.Count() - 1; i++)
            {
                filesToDisplayList.Add(filesToSendList[i]);
                filesList.Items.Add("|" + filesToSendList[i].Substring(filesToSendList[i].LastIndexOf('\\') + 1));

                for (int j = 0; j < filesToSendList.Count(); j++)
                {
                    if (i < j)
                    {
                        double probabilityPercent = client.compareFileLetterByLetterAndCalculateProbability(filesToSendList[i], filesToSendList[j], pattern);

                        filesToDisplayList.Add(filesToSendList[j]);
                        filesList.Items.Add("   |" + filesToSendList[j].Substring(filesToSendList[j].LastIndexOf('\\') + 1)
                            + " " + probabilityPercent.ToString() + "%");

                       // textEditorFirstFile.Text = client.compareFileLetterByLetter(filesToSendList[i], filesToSendList[j], pattern).ToString();
                    }
                }
            }
        }

        public void sendDataForCompareWordByWord()
        {

        }

        public void filesListItemOnClick(object sender, System.EventArgs e)
        {
            int index = filesList.SelectedIndex;

            if (textEditorFirstFile.TextLength == 0)
                textEditorFirstFile.Text = File.ReadAllText(filesToDisplayList[index]);

            else if (textEditorSecondFile.TextLength == 0)
                textEditorSecondFile.Text = File.ReadAllText(filesToDisplayList[index]);

            else
            {
                clearTextEditors();
                textEditorFirstFile.Text = File.ReadAllText(filesToDisplayList[index]);
            }
        }

        private void clearButtonOnClick(object sender, EventArgs e)
        {
            clearTextEditors();
        }

        private void clearTextEditors()
        {
            textEditorFirstFile.Text = "";
            textEditorSecondFile.Text = "";
        }
    }
}
