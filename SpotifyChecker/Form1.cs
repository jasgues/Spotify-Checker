using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using checkdll;

namespace SpotifyChecker
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string[] idpass = { };     
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                   
                    StreamReader oku = new StreamReader(openFileDialog1.FileName);
                    string satir = oku.ReadLine();
                    while (satir != null)
                    {
                        listBox1.Items.Add(satir);
                        satir = oku.ReadLine();
                    }
                }
                listBox1.SelectedIndex = 0;
            }
            catch (Exception)
            {
                MessageBox.Show("Dosya açarken hata oluştu.");
            }

        }
        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }
        int satirr = 0;
        string[] cımbız = { };       
        private void timer1_Tick(object sender, EventArgs e)
        {
            cımbız = listBox1.SelectedItem.ToString().Split(':');                    
            int baslangic = Jasgues.Checker(cımbız[0], cımbız[1]).IndexOf("status") + 9;
            int bitis = Jasgues.Checker(cımbız[0], cımbız[1]).Substring(baslangic).IndexOf(",");
            string gelenbilgiler = Jasgues.Checker(cımbız[0], cımbız[1]).Substring(baslangic, bitis);

            if (gelenbilgiler == "true")
                listBox2.Items.Add(cımbız[0] + ":" + cımbız[1]);

            listBox1.SelectedIndex = satirr;
            satirr++;
            if (satirr >= listBox1.Items.Count)
                 timer1.Stop();              
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            timer1.Stop();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            StreamWriter dosya;
            dosya = File.AppendText("hesaplar.txt");
            for (int i = 0; i < listBox2.Items.Count-1; i++)
            {
                dosya.WriteLine(listBox2.Items[i]);
                MessageBox.Show("Programın bulunduğu klasörde, hesaplar.txt dosyasına kaydedildi.");
            }
            
            dosya.Close();
        }
    }
}
