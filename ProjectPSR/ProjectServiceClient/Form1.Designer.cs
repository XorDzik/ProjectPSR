﻿namespace ProjectServiceClient
{
    partial class Form1
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.chooseFilesButton = new System.Windows.Forms.Button();
            this.compareButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textEditorFirstFile = new System.Windows.Forms.TextBox();
            this.patternInput = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textEditorSecondFile = new System.Windows.Forms.TextBox();
            this.filesList = new System.Windows.Forms.ListBox();
            this.wordByWordRadioButton = new System.Windows.Forms.RadioButton();
            this.letterByLetterRadioButton = new System.Windows.Forms.RadioButton();
            this.clearButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // chooseFilesButton
            // 
            this.chooseFilesButton.Location = new System.Drawing.Point(303, 15);
            this.chooseFilesButton.Margin = new System.Windows.Forms.Padding(4);
            this.chooseFilesButton.Name = "chooseFilesButton";
            this.chooseFilesButton.Size = new System.Drawing.Size(173, 55);
            this.chooseFilesButton.TabIndex = 0;
            this.chooseFilesButton.Text = "Choose files";
            this.chooseFilesButton.UseVisualStyleBackColor = true;
            this.chooseFilesButton.Click += new System.EventHandler(this.chooseFilesButtonOnClick);
            // 
            // compareButton
            // 
            this.compareButton.Location = new System.Drawing.Point(776, 495);
            this.compareButton.Margin = new System.Windows.Forms.Padding(4);
            this.compareButton.Name = "compareButton";
            this.compareButton.Size = new System.Drawing.Size(249, 36);
            this.compareButton.TabIndex = 4;
            this.compareButton.Text = "Compare";
            this.compareButton.UseVisualStyleBackColor = true;
            this.compareButton.Click += new System.EventHandler(this.compareButtonOnClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(407, 495);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 17);
            this.label1.TabIndex = 5;
            // 
            // textEditorFirstFile
            // 
            this.textEditorFirstFile.Location = new System.Drawing.Point(208, 113);
            this.textEditorFirstFile.Margin = new System.Windows.Forms.Padding(4);
            this.textEditorFirstFile.Multiline = true;
            this.textEditorFirstFile.Name = "textEditorFirstFile";
            this.textEditorFirstFile.ReadOnly = true;
            this.textEditorFirstFile.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textEditorFirstFile.Size = new System.Drawing.Size(479, 370);
            this.textEditorFirstFile.TabIndex = 6;
            // 
            // patternInput
            // 
            this.patternInput.Location = new System.Drawing.Point(538, 34);
            this.patternInput.Margin = new System.Windows.Forms.Padding(4);
            this.patternInput.Multiline = true;
            this.patternInput.Name = "patternInput";
            this.patternInput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.patternInput.Size = new System.Drawing.Size(261, 29);
            this.patternInput.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(598, 13);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(148, 17);
            this.label2.TabIndex = 8;
            this.label2.Text = "Proszę podać pattern:";
            // 
            // textEditorSecondFile
            // 
            this.textEditorSecondFile.Location = new System.Drawing.Point(695, 113);
            this.textEditorSecondFile.Margin = new System.Windows.Forms.Padding(4);
            this.textEditorSecondFile.Multiline = true;
            this.textEditorSecondFile.Name = "textEditorSecondFile";
            this.textEditorSecondFile.ReadOnly = true;
            this.textEditorSecondFile.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textEditorSecondFile.Size = new System.Drawing.Size(486, 370);
            this.textEditorSecondFile.TabIndex = 9;
            // 
            // filesList
            // 
            this.filesList.FormattingEnabled = true;
            this.filesList.ItemHeight = 16;
            this.filesList.Location = new System.Drawing.Point(12, 15);
            this.filesList.Name = "filesList";
            this.filesList.Size = new System.Drawing.Size(189, 468);
            this.filesList.TabIndex = 10;
            this.filesList.SelectedIndexChanged += new System.EventHandler(this.filesListItemOnClick);
            // 
            // wordByWordRadioButton
            // 
            this.wordByWordRadioButton.AutoSize = true;
            this.wordByWordRadioButton.Location = new System.Drawing.Point(840, 42);
            this.wordByWordRadioButton.Name = "wordByWordRadioButton";
            this.wordByWordRadioButton.Size = new System.Drawing.Size(204, 21);
            this.wordByWordRadioButton.TabIndex = 11;
            this.wordByWordRadioButton.TabStop = true;
            this.wordByWordRadioButton.Text = "Porównanie słowo po słowie";
            this.wordByWordRadioButton.UseVisualStyleBackColor = true;
            // 
            // letterByLetterRadioButton
            // 
            this.letterByLetterRadioButton.AutoSize = true;
            this.letterByLetterRadioButton.Location = new System.Drawing.Point(840, 15);
            this.letterByLetterRadioButton.Name = "letterByLetterRadioButton";
            this.letterByLetterRadioButton.Size = new System.Drawing.Size(199, 21);
            this.letterByLetterRadioButton.TabIndex = 12;
            this.letterByLetterRadioButton.TabStop = true;
            this.letterByLetterRadioButton.Text = "Porównanie znak po znaku";
            this.letterByLetterRadioButton.UseVisualStyleBackColor = true;
            // 
            // clearButton
            // 
            this.clearButton.Location = new System.Drawing.Point(303, 495);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(251, 35);
            this.clearButton.TabIndex = 13;
            this.clearButton.Text = "Clear";
            this.clearButton.UseVisualStyleBackColor = true;
            this.clearButton.Click += new System.EventHandler(this.clearButtonOnClick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1194, 554);
            this.Controls.Add(this.clearButton);
            this.Controls.Add(this.letterByLetterRadioButton);
            this.Controls.Add(this.wordByWordRadioButton);
            this.Controls.Add(this.filesList);
            this.Controls.Add(this.textEditorSecondFile);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.patternInput);
            this.Controls.Add(this.textEditorFirstFile);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.compareButton);
            this.Controls.Add(this.chooseFilesButton);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Komparator";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button chooseFilesButton;
        private System.Windows.Forms.Button compareButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textEditorFirstFile;
        private System.Windows.Forms.TextBox patternInput;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textEditorSecondFile;
        private System.Windows.Forms.ListBox filesList;
        private System.Windows.Forms.RadioButton wordByWordRadioButton;
        private System.Windows.Forms.RadioButton letterByLetterRadioButton;
        private System.Windows.Forms.Button clearButton;
    }
}

