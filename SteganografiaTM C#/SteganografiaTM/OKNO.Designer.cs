namespace SteganografiaTM
{
    partial class OKNO
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Podglad = new System.Windows.Forms.PictureBox();
            this.OtworzPlik = new System.Windows.Forms.Button();
            this.Ukryj = new System.Windows.Forms.Button();
            this.Odkryj = new System.Windows.Forms.Button();
            this.PoleSciezki = new System.Windows.Forms.TextBox();
            this.PoleWiadomosci = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Generuj = new System.Windows.Forms.Button();
            this.PodajN = new System.Windows.Forms.TextBox();
            this.WprowadzKod = new System.Windows.Forms.Button();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.Podglad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.SuspendLayout();
            // 
            // Podglad
            // 
            this.Podglad.Location = new System.Drawing.Point(12, 12);
            this.Podglad.Name = "Podglad";
            this.Podglad.Size = new System.Drawing.Size(442, 223);
            this.Podglad.TabIndex = 0;
            this.Podglad.TabStop = false;
            // 
            // OtworzPlik
            // 
            this.OtworzPlik.Location = new System.Drawing.Point(12, 256);
            this.OtworzPlik.Name = "OtworzPlik";
            this.OtworzPlik.Size = new System.Drawing.Size(75, 23);
            this.OtworzPlik.TabIndex = 1;
            this.OtworzPlik.Text = "Otwórz";
            this.OtworzPlik.UseVisualStyleBackColor = true;
            this.OtworzPlik.Click += new System.EventHandler(this.OtworzPlikKlik);
            // 
            // Ukryj
            // 
            this.Ukryj.Location = new System.Drawing.Point(12, 365);
            this.Ukryj.Name = "Ukryj";
            this.Ukryj.Size = new System.Drawing.Size(75, 23);
            this.Ukryj.TabIndex = 2;
            this.Ukryj.Text = "Ukryj";
            this.Ukryj.UseVisualStyleBackColor = true;
            this.Ukryj.Click += new System.EventHandler(this.UkryjKlik);
            // 
            // Odkryj
            // 
            this.Odkryj.Location = new System.Drawing.Point(93, 365);
            this.Odkryj.Name = "Odkryj";
            this.Odkryj.Size = new System.Drawing.Size(75, 23);
            this.Odkryj.TabIndex = 3;
            this.Odkryj.Text = "Odkryj";
            this.Odkryj.UseVisualStyleBackColor = true;
            this.Odkryj.Click += new System.EventHandler(this.OdkryjKlik);
            // 
            // PoleSciezki
            // 
            this.PoleSciezki.Enabled = false;
            this.PoleSciezki.Location = new System.Drawing.Point(107, 256);
            this.PoleSciezki.Name = "PoleSciezki";
            this.PoleSciezki.Size = new System.Drawing.Size(347, 20);
            this.PoleSciezki.TabIndex = 4;
            this.PoleSciezki.TextChanged += new System.EventHandler(this.PoleSciezki_TextChanged);
            // 
            // PoleWiadomosci
            // 
            this.PoleWiadomosci.Location = new System.Drawing.Point(107, 291);
            this.PoleWiadomosci.MaxLength = 50;
            this.PoleWiadomosci.Name = "PoleWiadomosci";
            this.PoleWiadomosci.Size = new System.Drawing.Size(347, 20);
            this.PoleWiadomosci.TabIndex = 5;
            this.PoleWiadomosci.TextChanged += new System.EventHandler(this.PoleWiadomosci_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 291);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Dane tekstowe";
            // 
            // Generuj
            // 
            this.Generuj.Location = new System.Drawing.Point(392, 368);
            this.Generuj.Name = "Generuj";
            this.Generuj.Size = new System.Drawing.Size(75, 23);
            this.Generuj.TabIndex = 7;
            this.Generuj.Text = "Generuj";
            this.Generuj.UseVisualStyleBackColor = true;
            this.Generuj.Visible = false;
            this.Generuj.Click += new System.EventHandler(this.GenerujKlik);
            // 
            // PodajN
            // 
            this.PodajN.Location = new System.Drawing.Point(173, 368);
            this.PodajN.Name = "PodajN";
            this.PodajN.Size = new System.Drawing.Size(75, 20);
            this.PodajN.TabIndex = 8;
            this.PodajN.Visible = false;
            // 
            // WprowadzKod
            // 
            this.WprowadzKod.Location = new System.Drawing.Point(320, 368);
            this.WprowadzKod.Name = "WprowadzKod";
            this.WprowadzKod.Size = new System.Drawing.Size(75, 23);
            this.WprowadzKod.TabIndex = 9;
            this.WprowadzKod.Text = "Kod";
            this.WprowadzKod.UseVisualStyleBackColor = true;
            this.WprowadzKod.Visible = false;
            this.WprowadzKod.Click += new System.EventHandler(this.WprowadzKodKlik);
            // 
            // trackBar1
            // 
            this.trackBar1.Enabled = false;
            this.trackBar1.Location = new System.Drawing.Point(254, 365);
            this.trackBar1.Maximum = 5;
            this.trackBar1.Minimum = 1;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(60, 45);
            this.trackBar1.TabIndex = 10;
            this.trackBar1.Value = 1;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(15, 342);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(49, 17);
            this.checkBox1.TabIndex = 11;
            this.checkBox1.Text = "KOD";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(244, 339);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(210, 20);
            this.textBox1.TabIndex = 12;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // OKNO
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(466, 393);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.trackBar1);
            this.Controls.Add(this.WprowadzKod);
            this.Controls.Add(this.PodajN);
            this.Controls.Add(this.Generuj);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.PoleWiadomosci);
            this.Controls.Add(this.PoleSciezki);
            this.Controls.Add(this.Odkryj);
            this.Controls.Add(this.Ukryj);
            this.Controls.Add(this.OtworzPlik);
            this.Controls.Add(this.Podglad);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "OKNO";
            this.Text = "SteganografiaTM";
            ((System.ComponentModel.ISupportInitialize)(this.Podglad)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox Podglad;
        private System.Windows.Forms.Button OtworzPlik;
        private System.Windows.Forms.Button Ukryj;
        private System.Windows.Forms.Button Odkryj;
        private System.Windows.Forms.TextBox PoleSciezki;
        private System.Windows.Forms.TextBox PoleWiadomosci;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Generuj;
        private System.Windows.Forms.TextBox PodajN;
        private System.Windows.Forms.Button WprowadzKod;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.TextBox textBox1;
    }
}

