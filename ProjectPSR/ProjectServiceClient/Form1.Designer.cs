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
            this.button1 = new System.Windows.Forms.Button();
            this.txtEditor1 = new System.Windows.Forms.TextBox();
            this.txtEditor2 = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(179, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(78, 45);
            this.button1.TabIndex = 0;
            this.button1.Text = "Open file 1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtEditor1
            // 
            this.txtEditor1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtEditor1.Location = new System.Drawing.Point(12, 63);
            this.txtEditor1.Multiline = true;
            this.txtEditor1.Name = "txtEditor1";
            this.txtEditor1.ReadOnly = true;
            this.txtEditor1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtEditor1.Size = new System.Drawing.Size(413, 300);
            this.txtEditor1.TabIndex = 1;
            // 
            // txtEditor2
            // 
            this.txtEditor2.Location = new System.Drawing.Point(431, 63);
            this.txtEditor2.Multiline = true;
            this.txtEditor2.Name = "txtEditor2";
            this.txtEditor2.ReadOnly = true;
            this.txtEditor2.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtEditor2.Size = new System.Drawing.Size(413, 300);
            this.txtEditor2.TabIndex = 3;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(609, 12);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(78, 45);
            this.button2.TabIndex = 2;
            this.button2.Text = "Open file 2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(86, 378);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(100, 60);
            this.button3.TabIndex = 4;
            this.button3.Text = "Compare";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(305, 402);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 5;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(874, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.txtEditor2);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.txtEditor1);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Komparator";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtEditor1;
        private System.Windows.Forms.TextBox txtEditor2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label1;
    }
}

