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
            this.txtEditor1 = new System.Windows.Forms.TextBox();
            this.patternInput = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // chooseFilesButton
            // 
            this.chooseFilesButton.Location = new System.Drawing.Point(303, 15);
            this.chooseFilesButton.Margin = new System.Windows.Forms.Padding(4);
            this.chooseFilesButton.Name = "chooseFilesButton";
            this.chooseFilesButton.Size = new System.Drawing.Size(104, 55);
            this.chooseFilesButton.TabIndex = 0;
            this.chooseFilesButton.Text = "Choose files";
            this.chooseFilesButton.UseVisualStyleBackColor = true;
            this.chooseFilesButton.Click += new System.EventHandler(this.chooseFilesButtonOnClick);
            // 
            // compareButton
            // 
            this.compareButton.Location = new System.Drawing.Point(744, 15);
            this.compareButton.Margin = new System.Windows.Forms.Padding(4);
            this.compareButton.Name = "compareButton";
            this.compareButton.Size = new System.Drawing.Size(119, 55);
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
            // txtEditor1
            // 
            this.txtEditor1.Location = new System.Drawing.Point(314, 123);
            this.txtEditor1.Margin = new System.Windows.Forms.Padding(4);
            this.txtEditor1.Multiline = true;
            this.txtEditor1.Name = "txtEditor1";
            this.txtEditor1.ReadOnly = true;
            this.txtEditor1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtEditor1.Size = new System.Drawing.Size(549, 368);
            this.txtEditor1.TabIndex = 6;
            // 
            // patternInput
            // 
            this.patternInput.Location = new System.Drawing.Point(460, 31);
            this.patternInput.Margin = new System.Windows.Forms.Padding(4);
            this.patternInput.Multiline = true;
            this.patternInput.Name = "patternInput";
            this.patternInput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.patternInput.Size = new System.Drawing.Size(227, 29);
            this.patternInput.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(500, 11);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(148, 17);
            this.label2.TabIndex = 8;
            this.label2.Text = "Proszę podać pattern:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1165, 554);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.patternInput);
            this.Controls.Add(this.txtEditor1);
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
        private System.Windows.Forms.TextBox txtEditor1;
        private System.Windows.Forms.TextBox patternInput;
        private System.Windows.Forms.Label label2;
    }
}

