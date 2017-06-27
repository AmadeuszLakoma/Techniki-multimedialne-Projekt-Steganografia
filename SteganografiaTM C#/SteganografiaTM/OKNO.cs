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
 
        int w, A;//w - wynik potegowania, dlugosc pojedyczego ciagu
        string kod;// reprezentacja kodu na string
        public OKNO()//glowne okno
        {

            InitializeComponent(); //inicjalizacja elementów z Form
        }
     
        int POTENGAN(int n) /*!liczenie potęgi, pobranie n*/
        {
                int i;// kolejna iteracja
                int pot;// do jakiej potegi
                A = 2 * n;//!< zwracanie długości ciągów bitowych
                w = 1;//przypisanie do wyniku 1 na start bo zero razy cokolwiek daje 0
                pot = 2 * n;//potega jest wielokrotnoscia n
                for (i = 1; i <= pot; i++)// wykonuj do potegi
                {
                    w = w * 2;//przypisywanie wyniku
                }
                return w;//zwraca wynik potegowania
            }

        void BIN()//!<ciągi binarne i zapis do pliku
        {
            String s;//lancuch znakow
            int ls, ls1;//zmienne pomocnicze do zliczania
            {
                int ile = 0;//zliczanie wielokrotności kod, tzn sumy wszystkich znakow kodu

                FileStream PLIKBIN = new FileStream(@"f.txt", FileMode.Create);//utworzenie pliku do zapisu

                for (int i = 1; i <= w; i++)//z;iczaj do liczby ciagow
                {
               
                    s = Convert.ToString(i, 2);//zamien wartosc na system 2 typu string
                    s = s.PadLeft(A, '1');//!<uzupełnianie "1" z lewej strony
            
                    int[] tablica = s.ToCharArray().Select(q => int.Parse(q.ToString())).ToArray();//zamien s typu string na tablice int
                    ls = 0;
                    ls1 = 0;
                    for (int ll = 1; ll <= s.Length; ll++)//wykonuj do dlugosci lancucha

                    { 
                        if (s[ll - 1] == '1') ls++; //!< LICZENIE 1
                        if (s[ll - 1] == '0') ls1++; //!< LICZENIE 0
                        if (ls >= ls1)//!<sprawdzanie czy '1' jest co najmniej tyle amo co '0' - optymalizacja !!
                        {
                            if (ll == s.Length)//!<ciągi o zadanej długości
                                if (ls == ls1 && ile<PoleWiadomosci.TextLength)//!<tyle samo '0' i '1'
                                {
                                ile=ile+A;//zlicz jak dlugi jest ciag
                                    byte[] bdata = Encoding.Default.GetBytes(s/* + Environment.NewLine*/);//tablica typu byte złożona z poszczegónych bajtów stringa
                                    PLIKBIN.Write(bdata, 0, bdata.Length);// zapis do pliku
                                }
                        }
                        else break;
                    }
                }
                PLIKBIN.Close();//zamknij plik

            }
        }
        private void OtworzPlikKlik(object sender, EventArgs e)// otwieranie pliku
        {
            OpenFileDialog openDialog = new OpenFileDialog();//utowrzenie obiektu 
            openDialog.Filter = "Image Files (*.bmp, *.png, *.jpg) | *.bmp; *.png; *.jpg";

            if (openDialog.ShowDialog() == DialogResult.OK)
            {
                PoleSciezki.Text = openDialog.FileName.ToString();//pobranie lokalizacji
                Podglad.ImageLocation = PoleSciezki.Text;//Pobranie lokalizaji do wszytania
                Podglad.SizeMode = PictureBoxSizeMode.StretchImage;//skalowanie
            }
        }
   


        private void UkryjKlik(object sender, EventArgs e)
        {
            Bitmap img = new Bitmap(PoleSciezki.Text); //uwtorzenie nowej bitmapy

            for (int i = 0; i < img.Width; i++)//do szerokości
            {
                for (int j = 0; j < img.Height; j++)//do wysokości
                {
                    Color pixel = img.GetPixel(i, j);//pobranie koluru piksela

                    if (i < 1 && j < PoleWiadomosci.TextLength)//do długości wiadomosci do ukrycia
                    {
                        char litera = Convert.ToChar(PoleWiadomosci.Text.Substring(j, 1));//przechowaj pojedyncza litere

                        int wartosc = Convert.ToInt32(litera);//zamien na wartosc calkowita
                        if (wartosc >= 0 && wartosc <= 255)//sprawdzanie zakresu dla ASCII dziesietnie
                        {
                            if (checkBox1.Checked)//jesli zaznaczono "KOD"
                            {
                                char kodchar = Convert.ToChar(kod.Substring(j, 1));//pojednycze znaki kodu
                                int kodint = Convert.ToInt32(kodchar);//zamiana na wartosci calkowite
                                img.SetPixel(i, j, Color.FromArgb(pixel.R, pixel.G, wartosc ^ kodint));//ustaw wartosc pisela, dokladniej skladowej koloru niebieskiego dla RGB z wartościa kodu
                            }
                            else img.SetPixel(i, j, Color.FromArgb(pixel.R, pixel.G, wartosc));//ustawienie bez kodowania
                        }else  MessageBox.Show("Znak poza zakresem! ");//ostrzezenie o niestandardowytch znakach
                    }
                    if (i == img.Width - 1 && j == img.Height - 1)
                    {
                        img.SetPixel(i, j, Color.FromArgb(pixel.R, pixel.G, PoleWiadomosci.TextLength));//oznaczenie konca zamiany pikseli
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

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
    
            int n = Int32.Parse(trackBar1.Value.ToString());
            if (checkBox1.Checked)
            {
                POTENGAN(n);
                BIN();
                int licznik = 0;
                foreach (string linie in File.ReadLines(@"f.txt"))//!<ile lini
                {
                    if (linie != String.Empty) ++licznik;
                }
                foreach (string linie in File.ReadLines(@"f.txt"))//odczytuj linie dopók nie koniec lini
                {
                    if (linie != String.Empty)
                        textBox1.Text = ("Kod " + linie);
                    kod = linie;

                }
            }
                ///////////////////////////////////////////////
          

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                trackBar1.Enabled = true;//aktywny suwak
            }
            else
            {
              
                trackBar1.Enabled = false;//suwak nieaktywny
            }
        }

        private void PoleSciezki_TextChanged(object sender, EventArgs e)
        {
       
        }

        private void PoleWiadomosci_TextChanged(object sender, EventArgs e)
        {//zmiana parametrow suwaka w zaleznosci od dlugosci wiadomosci
            if (PoleWiadomosci.TextLength < 3)
            {
                this.trackBar1.Minimum = 1;
            }
            else 

            if (PoleWiadomosci.TextLength < 5)
            {
                this.trackBar1.Minimum = 2;
            }else
            if (PoleWiadomosci.TextLength < 9)
            {
                this.trackBar1.Minimum = 3;
            }else
            if (PoleWiadomosci.TextLength < 19)
            {
                this.trackBar1.Minimum = 4;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
    
        }

        private void OdkryjKlik(object sender, EventArgs e)
        {
            Bitmap img = new Bitmap(PoleSciezki.Text);
            string wiadomosc = "";
            char c;
            Color OstatniPiksel = img.GetPixel(img.Width - 1, img.Height - 1);//warunek rozpoznania ostaniego piksela zawierajacego dane
            int DlugoscWiadomosci = OstatniPiksel.B;     
           

            for (int i = 0; i < img.Width; i++)
                {
                    for (int j = 0; j < img.Height; j++)
                    {
                        Color pixel = img.GetPixel(i, j);

                        if (i < 1 && j < DlugoscWiadomosci)
                        {
                            int wartosc = pixel.B;

                        {
                            if (checkBox1.Checked)
                            {
                                char kodchar = Convert.ToChar(kod.Substring(j, 1));
                                int kodint = Convert.ToInt32(kodchar);

                                c = Convert.ToChar(wartosc^kodint);
                                string litera = System.Text.Encoding.ASCII.GetString(new byte[] { Convert.ToByte(c) });
                                wiadomosc = wiadomosc + litera;
                             //   MessageBox.Show("Wartosc " + wartosc + " kodint " + kodint + " c " + c);
                            }
                            else
                            {
                                c = Convert.ToChar(wartosc);
                          
                                string litera = System.Text.Encoding.ASCII.GetString(new byte[] { Convert.ToByte(c) });
                                wiadomosc = wiadomosc + litera;
                            }
                        }
                        }
                    }
                }
          
            PoleWiadomosci.Text = wiadomosc;
        }
        private void GenerujKlik(object sender, EventArgs e)
        {
            /*  int n = Int32.Parse(PodajN.Text);
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
               else MessageBox.Show("Nie wygenerowano! ");*/

        }
        private void WprowadzKodKlik(object sender, EventArgs e)
        {
            /*    int n = Int32.Parse(PodajN.Text);
                if (n >= 0 && n <= 100)
                {

                    int licznik = 0;

                    foreach (string linie in File.ReadLines(@"f.txt"))
                    {
                        if (linie != String.Empty) ++licznik;
                        if (licznik == 1) {
                            MessageBox.Show("Linia " + linie);
                            kod = linie;
                        }
                    }

                    ///////////////////////////////////////////////
                }
                else MessageBox.Show("Nie wygenerowano! ");*/
        }
    }
}
