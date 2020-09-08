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
                        DateTime t1 = DateTime.Now;
                        theSameElementsPosTmp = client.compareFileLetterByLetter(filesToSendList[i], filesToSendList[j], pattern);
                        
                        DateTime t3 = DateTime.Now;
                        TimeSpan communicationTime = t3 - t1;
                        
                        int z = 0;
                        foreach (KeyValuePair<int, string> kvp in theSameElementsPosTmp)
                        {
                            if (!theSameElementsPos.ContainsKey(kvp.Key))
                                theSameElementsPos.Add(kvp.Key, kvp.Value);
                       
                            theSameLettersLength += kvp.Value.Length;
                            z++;
                        }
                        double percentProbability = client.percentCalculate(theSameLettersLength, File.ReadAllText(filesToSendList[i]).Length);

                        if (percentProbability > 100)
                            percentProbability = 100;

                        filesToDisplayList.Add(filesToSendList[j]);

                        DateTime t2 = DateTime.Now;
                        TimeSpan totalTime = t2.Subtract(t1);

                        filesList.Items.Add("   |" + filesToSendList[j].Substring(filesToSendList[j].LastIndexOf('\\') + 1) + " " + 
                            percentProbability.ToString() + "%; t_c=" + totalTime.TotalMilliseconds.ToString() + "; t_k=" + communicationTime.TotalMilliseconds.ToString());
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
                        DateTime t1 = DateTime.Now;
                        theSameElementsPosTmp = client.compareFileWordByWord(filesToSendList[i], filesToSendList[j], pattern);

                        DateTime t3 = DateTime.Now;
                        TimeSpan communicationTime = t3 - t1;

                        foreach (KeyValuePair<int, string> kvp in theSameElementsPosTmp)
                        {
                            if (!theSameElementsPos.ContainsKey(kvp.Key))
                                theSameElementsPos.Add(kvp.Key, kvp.Value);

                            theSameLettersLength += kvp.Value.Length;
                        }

                        double percentProbability = client.percentCalculate(theSameLettersLength, File.ReadAllText(filesToSendList[i]).Length);
                        if (percentProbability > 100)
                            percentProbability = 100;

                        filesToDisplayList.Add(filesToSendList[j]);

                        DateTime t2 = DateTime.Now;
                        TimeSpan totalTime = t2.Subtract(t1);

                        filesList.Items.Add("   |" + filesToSendList[j].Substring(filesToSendList[j].LastIndexOf('\\') + 1) + 
                            " " + percentProbability.ToString() + "%; t_c=" + totalTime.TotalMilliseconds.ToString() + "; t_k=" + communicationTime.TotalMilliseconds.ToString());
                        theSameLettersLength = 0;
                    }
                }
            }
        }

        public void filesListItemOnClick(object sender, System.EventArgs e)
        {
            Object itemSelectedName = filesList.SelectedItem;

            if (txtBoxFirstFile.TextLength == 0)
                txtBoxFirstFile.Text = File.ReadAllText(filesToDisplayList[filesList.SelectedIndex]);
            else if (txtBoxSecondFile.TextLength == 0)
                txtBoxSecondFile.Text = File.ReadAllText(filesToDisplayList[filesList.SelectedIndex]);
            else
            {
                clearTextEditors();
                txtBoxFirstFile.Text = File.ReadAllText(filesToDisplayList[filesList.SelectedIndex]);
            }

            if (txtBoxFirstFile.TextLength > 0 && txtBoxSecondFile.TextLength > 0)
            {
                colorTheSameTextFragments(txtBoxFirstFile, theSameElementsPos, itemSelectedName);
                colorTheSameTextFragments(txtBoxSecondFile, theSameElementsPos, itemSelectedName);
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

        private void colorTheSameTextFragments(RichTextBox richTextBox, IDictionary<int, string> theSameElementsPos, Object itemSelectedName)
        {
            if (itemSelectedName.ToString().Contains("100%"))
            {
                richTextBox.SelectAll();
                richTextBox.SelectionColor = Color.Green;
                return;
            }

            if (!itemSelectedName.ToString().Contains("0%"))
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
