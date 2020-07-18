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
        private double levehsteinDistance;
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
            {
                if (textPattern.Text.Length > 0 && (Int32.Parse(textPattern.Text) >= 10))
                {
                    // Zmienna odpowiadająca za to co ile znakow tekst jest dzielony na czesci
                    int pattern = Int32.Parse(textPattern.Text);

                    // Pattern nie moze byc wiekszy niz dlugosc pierwszego tekstu
                    if (pattern <= txtEditor1.Text.Length)
                    {
                        // Podzielone na części listy gotowe do wysylania
                        List<string> firstFileChunkText = createChunkToSend(txtEditor1.Text, pattern).ToList();
                        List<string> secondFileChunkText = createChunkToSend(txtEditor2.Text, pattern).ToList();

                        //Sprawdzenie czy pierwsza lista jest wieksza od drugiej jezeli tak to dodaje puste znaki zeby liczba elementow byla ta sama
                        if (firstFileChunkText.Count > secondFileChunkText.Count)
                        {
                            for (int j = secondFileChunkText.Count; j < firstFileChunkText.Count; j++)
                            {
                                secondFileChunkText.Add(" ");
                            }
                        }

                        // Ta pętla wykoprzystuje wielowatkowosc, automatycznie zleca rownolegle wykonanie instrukcji wszystkim rdzeniom procka.
                        // wysylamy rownolegle do serwera fragmenty tekstow podzielonych wg przekazanego przez uzytkownika patternu
                        // sumujemy dystans tych wszystkich czesci i liczymy procent z tego
                        Parallel.For(0, firstFileChunkText.Count, delegate (int i)
                        {
                            double chunkLevenhsteinDistance = client.calculateLevenhstein(firstFileChunkText.ElementAt(i).ToString(), secondFileChunkText.ElementAt(i).ToString());
                            levehsteinDistance += chunkLevenhsteinDistance;
                        });

                        label1.Text = "Procent zgodności pierwszego pliku z drugim = " + client.percentCalculate(levehsteinDistance, txtEditor1.TextLength).ToString() + "%";
                        levehsteinDistance = 0;
                    }
                    else
                    {
                        MessageBox.Show("Pattern nie moze byc wiekszy od ilosci znakow pierwszego tekstu", "Błąd!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                    MessageBox.Show("Proszę wpisać pattern większy lub równy 10", "Błąd!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                MessageBox.Show("Proszę wybrać oba pliki w celu porównania", "Błąd!", MessageBoxButtons.OK, MessageBoxIcon.Error);            
        }

        static IEnumerable<string> createChunkToSend(string str, int pattern)
        {
            for (int i = 0; i < str.Length; i += pattern)
                yield return str.Substring(i, Math.Min(pattern, str.Length - i));
        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
