namespace ProjectServiceClient
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
            this.patternInput = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.filesList = new System.Windows.Forms.ListBox();
            this.wordByWordRadioButton = new System.Windows.Forms.RadioButton();
            this.letterByLetterRadioButton = new System.Windows.Forms.RadioButton();
            this.clearButton = new System.Windows.Forms.Button();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.txtBoxFirstFile = new System.Windows.Forms.RichTextBox();
            this.colorDialog2 = new System.Windows.Forms.ColorDialog();
            this.txtBoxSecondFile = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // chooseFilesButton
            // 
            this.chooseFilesButton.Location = new System.Drawing.Point(384, 12);
            this.chooseFilesButton.Name = "chooseFilesButton";
            this.chooseFilesButton.Size = new System.Drawing.Size(176, 40);
            this.chooseFilesButton.TabIndex = 0;
            this.chooseFilesButton.Text = "Wybierz pliki";
            this.chooseFilesButton.UseVisualStyleBackColor = true;
            this.chooseFilesButton.Click += new System.EventHandler(this.chooseFilesButtonOnClick);
            // 
            // compareButton
            // 
            this.compareButton.Location = new System.Drawing.Point(430, 398);
            this.compareButton.Name = "compareButton";
            this.compareButton.Size = new System.Drawing.Size(231, 29);
            this.compareButton.TabIndex = 4;
            this.compareButton.Text = "Porównaj";
            this.compareButton.UseVisualStyleBackColor = true;
            this.compareButton.Click += new System.EventHandler(this.compareButtonOnClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(481, 402);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 5;
            // 
            // patternInput
            // 
            this.patternInput.Location = new System.Drawing.Point(580, 28);
            this.patternInput.Multiline = true;
            this.patternInput.Name = "patternInput";
            this.patternInput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.patternInput.Size = new System.Drawing.Size(197, 24);
            this.patternInput.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(624, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Proszę podać pattern:";
            // 
            // filesList
            // 
            this.filesList.FormattingEnabled = true;
            this.filesList.Location = new System.Drawing.Point(9, 12);
            this.filesList.Margin = new System.Windows.Forms.Padding(2);
            this.filesList.Name = "filesList";
            this.filesList.Size = new System.Drawing.Size(360, 381);
            this.filesList.TabIndex = 10;
            this.filesList.SelectedIndexChanged += new System.EventHandler(this.filesListItemOnClick);
            // 
            // wordByWordRadioButton
            // 
            this.wordByWordRadioButton.AutoSize = true;
            this.wordByWordRadioButton.Location = new System.Drawing.Point(806, 34);
            this.wordByWordRadioButton.Margin = new System.Windows.Forms.Padding(2);
            this.wordByWordRadioButton.Name = "wordByWordRadioButton";
            this.wordByWordRadioButton.Size = new System.Drawing.Size(162, 17);
            this.wordByWordRadioButton.TabIndex = 11;
            this.wordByWordRadioButton.TabStop = true;
            this.wordByWordRadioButton.Text = "Porównanie słowo po słowie";
            this.wordByWordRadioButton.UseVisualStyleBackColor = true;
            // 
            // letterByLetterRadioButton
            // 
            this.letterByLetterRadioButton.AutoSize = true;
            this.letterByLetterRadioButton.Location = new System.Drawing.Point(806, 12);
            this.letterByLetterRadioButton.Margin = new System.Windows.Forms.Padding(2);
            this.letterByLetterRadioButton.Name = "letterByLetterRadioButton";
            this.letterByLetterRadioButton.Size = new System.Drawing.Size(154, 17);
            this.letterByLetterRadioButton.TabIndex = 12;
            this.letterByLetterRadioButton.TabStop = true;
            this.letterByLetterRadioButton.Text = "Porównanie znak po znaku";
            this.letterByLetterRadioButton.UseVisualStyleBackColor = true;
            // 
            // clearButton
            // 
            this.clearButton.Location = new System.Drawing.Point(781, 398);
            this.clearButton.Margin = new System.Windows.Forms.Padding(2);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(235, 29);
            this.clearButton.TabIndex = 13;
            this.clearButton.Text = "Wyczyść";
            this.clearButton.UseVisualStyleBackColor = true;
            this.clearButton.Click += new System.EventHandler(this.clearButtonOnClick);
            // 
            // txtBoxFirstFile
            // 
            this.txtBoxFirstFile.Location = new System.Drawing.Point(384, 92);
            this.txtBoxFirstFile.Name = "txtBoxFirstFile";
            this.txtBoxFirstFile.Size = new System.Drawing.Size(344, 301);
            this.txtBoxFirstFile.TabIndex = 14;
            this.txtBoxFirstFile.Text = "";
            // 
            // txtBoxSecondFile
            // 
            this.txtBoxSecondFile.Location = new System.Drawing.Point(734, 92);
            this.txtBoxSecondFile.Name = "txtBoxSecondFile";
            this.txtBoxSecondFile.Size = new System.Drawing.Size(333, 301);
            this.txtBoxSecondFile.TabIndex = 15;
            this.txtBoxSecondFile.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1097, 450);
            this.Controls.Add(this.txtBoxSecondFile);
            this.Controls.Add(this.txtBoxFirstFile);
            this.Controls.Add(this.clearButton);
            this.Controls.Add(this.letterByLetterRadioButton);
            this.Controls.Add(this.wordByWordRadioButton);
            this.Controls.Add(this.filesList);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.patternInput);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.compareButton);
            this.Controls.Add(this.chooseFilesButton);
            this.Name = "Form1";
            this.Text = "Komparator";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button chooseFilesButton;
        private System.Windows.Forms.Button compareButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox patternInput;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox filesList;
        private System.Windows.Forms.RadioButton wordByWordRadioButton;
        private System.Windows.Forms.RadioButton letterByLetterRadioButton;
        private System.Windows.Forms.Button clearButton;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.RichTextBox txtBoxFirstFile;
        private System.Windows.Forms.ColorDialog colorDialog2;
        private System.Windows.Forms.RichTextBox txtBoxSecondFile;
    }
}

