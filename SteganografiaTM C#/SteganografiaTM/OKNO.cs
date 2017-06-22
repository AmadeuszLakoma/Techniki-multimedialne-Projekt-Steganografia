using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace SteganografiaTM
{
    public partial class OKNO : Form
    {
        int w,A;
        string kod;
        public OKNO()
        {

            InitializeComponent();
        }

        private void OtworzPlikKlik(object sender, EventArgs e)
        {
            OpenFileDialog openDialog = new OpenFileDialog();
            openDialog.Filter = "Image Files (*.bmp, *.png, *.jpg) | *.bmp; *.png; *.jpg";

            if (openDialog.ShowDialog() == DialogResult.OK)
            {
                PoleSciezki.Text = openDialog.FileName.ToString();
                Podglad.ImageLocation = PoleSciezki.Text;
            }
        }


        int POTENGAN(int n) //liczenie potęgi
        { int  i;
            int pot;
            A = 2 * n;// zwracanie długości ciągów bitowych
            w = 1;
            pot = 2 * n;
            for (i = 1; i <= pot; i++)
            {
                w = w * 2;   
            }
            return w;
        }

        void BIN()//ciągi binarne i zapis do pliku
        {
            String s;
            int ls, ls1;
            {
              int  i = 0;
              
               
                FileStream PLIKBIN = new FileStream(@"f.txt", FileMode.Create);
               
                for (i = 1; i <= w; i++)
                {
               
                    s = Convert.ToString(i, 2);
                    s = s.PadLeft(A, '0');//uzupełnianie "0" z lewej stroy
                    int length = s.Length;
                    int[] tablica = s.ToCharArray().Select(q => int.Parse(q.ToString())).ToArray();

                    ls = 0;
                    ls1 = 0;
                    for (int ll = 1; ll <= length; ll++)

                    {

                        Console.WriteLine("s = " + tablica[ll-1]);
                        if (s[ll-1] == '0') ls++; // LICZENIE ZER
                        if (s[ll-1] == '1') ls1++;
                        if (ls >= ls1)//sprawdzanie czy '0' jest co najmniej tyle amo co '1' - optymalizacja !!
                        {
                         //   Console.WriteLine("ls = " + ls + " ls1 = " + ls1);
                          //  Console.WriteLine("ll = " + ll + " len = " + length);
                            if (ll == length)//ciągi o zadanej długości
                                if (ls == ls1)//tyle samo '0' i '1'
                                {
                                    byte[] bdata = Encoding.Default.GetBytes(s + Environment.NewLine);
                                    PLIKBIN.Write(bdata, 0, bdata.Length);
                                }
                        }
                        else break;
                    }
                }
                PLIKBIN.Close();

            }
        }

        private void Generuj_Click(object sender, EventArgs e)
        {
           int n = Int32.Parse(PodajN.Text);
            if (n >= 0 && n <= 10)
            {
                POTENGAN(n);
                BIN();
                int licznik = 0;

                foreach (string linie in File.ReadLines(@"f.txt"))//ile lini
                {
                    if (linie != String.Empty) ++licznik;
                }
                MessageBox.Show("Wygenerowano! " + licznik);
            }
            else MessageBox.Show("Nie wygenerowano! ");
            
        }


        private void UkryjKlik(object sender, EventArgs e)
        {
            Bitmap img = new Bitmap(PoleSciezki.Text);

            for (int i = 0; i < img.Width; i++)
            {
                for (int j = 0; j < img.Height; j++)
                {
                    Color pixel = img.GetPixel(i, j);

                    if (i < 1 && j < PoleWiadomosci.TextLength)
                    {
              
                        
                        char litera = Convert.ToChar(PoleWiadomosci.Text.Substring(j, 1));
                        int wartosc = Convert.ToInt32(litera);
                        int kodint = Convert.ToInt32(kod);
                        // Console.WriteLine();
                        
                       // for (;(wartosc+kodint)>255;)
                        //{ kodint = kodint / 10; }
                        MessageBox.Show("wartosc " + wartosc + " kod " + kodint);
                        img.SetPixel(i, j, Color.FromArgb(pixel.R, pixel.G, wartosc+kodint));
                    }

                    if (i == img.Width - 1 && j == img.Height - 1)
                    {
                        img.SetPixel(i, j, Color.FromArgb(pixel.R, pixel.G, PoleWiadomosci.TextLength));
                    }
                }
            }

            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.Filter = "Image Files (*.png, *.jpg) | *.png; *.jpg";
           
            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                PoleSciezki.Text = saveFile.FileName.ToString();
                Podglad.ImageLocation = PoleSciezki.Text;

                img.Save(PoleSciezki.Text);
            }
        }

        private void WprowadzKod_Click(object sender, EventArgs e)
        {
            int n = Int32.Parse(PodajN.Text);
            if (n >= 0 && n <= 100)
            {

                int licznik = 0;

                foreach (string linie in File.ReadLines(@"C:\RM\f.txt"))
                {
                    if (linie != String.Empty) ++licznik;
                    if (licznik == n) {
                        MessageBox.Show("Linia " + linie);
                        kod = linie;
                    }
                }
                
                ///////////////////////////////////////////////
            }
            else MessageBox.Show("Nie wygenerowano! ");
        }

        private void OdkryjKlik(object sender, EventArgs e)
        {
            Bitmap img = new Bitmap(PoleSciezki.Text);
            string wiadomosc = "";

            Color lastpixel = img.GetPixel(img.Width - 1, img.Height - 1);
            int DlugoscWiadomosci = lastpixel.B;
            int kodint = Convert.ToInt32(kod);

                for (int i = 0; i < img.Width; i++)
                {
                    for (int j = 0; j < img.Height; j++)
                    {
                        Color pixel = img.GetPixel(i, j);

                        if (i < 1 && j < DlugoscWiadomosci)
                        {
                            int wartosc = pixel.B;
                     //   for (; (wartosc + kodint) > 255;)
                    //    { kodint = kodint / 10; }
                        if (wartosc - kodint >= 0)
                            {
                                char c = Convert.ToChar(wartosc-kodint);
                                MessageBox.Show("Wartosc " + wartosc + " kodint " + kodint + " c " + c);
                                string litera = System.Text.Encoding.ASCII.GetString(new byte[] { Convert.ToByte(c) });
                                wiadomosc = wiadomosc + litera;
                            }

                        }
                    }
                }
          
            PoleWiadomosci.Text = wiadomosc;
        }
    }
}
