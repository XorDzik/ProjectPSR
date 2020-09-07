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
        IDictionary<int, string> theSameElementsPos = new Dictionary<int, string>();
        IDictionary<int, string> theSameElementsPosTmp = new Dictionary<int, string>();
        int indexTmp = -1;
        int index = -1;

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
                foreach (string file in openFileDialog.FileNames)
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
                sendDataForCompareLetterByLetter();
            else if (wordByWordRadioButton.Checked)
                sendDataForCompareWordByWord();
            else
                MessageBox.Show("Proszę wybrać metodę porównania", "Błąd!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public void sendDataForCompareLetterByLetter()
        {
            int theSameLettersLength = 0;
            int pattern = int.Parse(patternInput.Text);

            for (int i = 0; i < filesToSendList.Count() - 1; i++)
            {
                filesToDisplayList.Add(filesToSendList[i]);
                filesList.Items.Add("|" + filesToSendList[i].Substring(filesToSendList[i].LastIndexOf('\\') + 1));

                for (int j = 0; j < filesToSendList.Count(); j++)
                {
                    if (i < j)
                    {
                        theSameElementsPosTmp = client.compareFileLetterByLetter(filesToSendList[i], filesToSendList[j], pattern);

                        foreach (KeyValuePair<int, string> kvp in theSameElementsPosTmp)
                        {
                            if (!theSameElementsPos.Contains(kvp))
                                theSameElementsPos.Add(kvp.Key, kvp.Value);
                       
                            theSameLettersLength += kvp.Value.Length;
                        }

                        double percentProbability = client.percentCalculate(theSameLettersLength, File.ReadAllText(filesToSendList[i]).Length);
                        filesToDisplayList.Add(filesToSendList[j]);
                        filesList.Items.Add("   |" + filesToSendList[j].Substring(filesToSendList[j].LastIndexOf('\\') + 1) + " " + percentProbability.ToString() + "%");
                    }
                }
            }
        }

        public void sendDataForCompareWordByWord()
        {
            int theSameLettersLength = 0;
            int pattern = int.Parse(patternInput.Text);

            for (int i = 0; i < filesToSendList.Count() - 1; i++)
            {
                filesToDisplayList.Add(filesToSendList[i]);
                filesList.Items.Add("|" + filesToSendList[i].Substring(filesToSendList[i].LastIndexOf('\\') + 1));

                for (int j = 0; j < filesToSendList.Count(); j++)
                {
                    if (i < j)
                    {
                        theSameElementsPosTmp = client.compareFileWordByWord(filesToSendList[i], filesToSendList[j], pattern);

                        foreach (KeyValuePair<int, string> kvp in theSameElementsPosTmp)
                        {
                            if (!theSameElementsPos.Contains(kvp))
                                theSameElementsPos.Add(kvp.Key, kvp.Value);

                            theSameLettersLength += kvp.Value.Length;
                        }

                        double percentProbability = client.percentCalculate(theSameLettersLength, File.ReadAllText(filesToSendList[i]).Length);
                        filesToDisplayList.Add(filesToSendList[j]);
                        filesList.Items.Add("   |" + filesToSendList[j].Substring(filesToSendList[j].LastIndexOf('\\') + 1) + " " + percentProbability.ToString() + "%");
                        theSameLettersLength = 0;
                    }
                }
            }
        }

        public void filesListItemOnClick(object sender, System.EventArgs e)
        {
            if (index == -1)
                index = filesList.SelectedIndex;
            else
                indexTmp = filesList.SelectedIndex;

            if (txtBoxFirstFile.TextLength == 0)
                txtBoxFirstFile.Text = File.ReadAllText(filesToDisplayList[index]);
            else if (txtBoxSecondFile.TextLength == 0)
                txtBoxSecondFile.Text = File.ReadAllText(filesToDisplayList[indexTmp]);
            else
            {
                clearTextEditors();
                txtBoxFirstFile.Text = File.ReadAllText(filesToDisplayList[index]);
            }

            if (index != -1 && indexTmp != -1)
            {
                colorTheSameTextFragments(txtBoxFirstFile, theSameElementsPos, filesToDisplayList[indexTmp]);
                colorTheSameTextFragments(txtBoxSecondFile, theSameElementsPos, filesToDisplayList[indexTmp]);
                index = -1;
                indexTmp = -1;
            }
        }

        private void clearButtonOnClick(object sender, EventArgs e)
        {
            clearTextEditors();
            filesToSendList.Clear();
        }

        private void clearTextEditors()
        {
            txtBoxFirstFile.Text = "";
            txtBoxSecondFile.Text = "";
        }

        private void colorTheSameTextFragments(RichTextBox richTextBox, IDictionary<int, string> theSameElementsPos, string secondFileName)
        {
            if (!secondFileName.Contains("0%"))
            {
                foreach (KeyValuePair<int, string> kvp in theSameElementsPos)
                {                 
                    if (txtBoxFirstFile.Text.Contains(kvp.Value) && txtBoxSecondFile.Text.Contains(kvp.Value))
                    {
                        richTextBox.Select(kvp.Key, kvp.Value.Length);
                        richTextBox.SelectionColor = Color.Green;
                    }
                }
            }
        }
    }
}
