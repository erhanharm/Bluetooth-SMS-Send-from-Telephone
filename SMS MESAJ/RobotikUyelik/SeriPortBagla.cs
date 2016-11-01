/*
 * 
 * Erhan HARMANKAYA
 * Haziran 2009
 * www.harmankaya.org
 * erhan@harmankaya.org 
 * 
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;
using System.Threading;


namespace RobotikUyelik
{
    public partial class SeriPortBagla : Form
    {
        public SeriPortBagla()
        {
            InitializeComponent();
        }

    
        SerialPort sp = new SerialPort();

        //yeni bir port yarat

        
        private void SeriPortBagla_Load(object sender, EventArgs e)
        {
            label2.Text = "Baðlantý  Ayarlanmadý.";
            label1.Text = "160";
            textBox3.MaxLength = 160;
          
        }

        private void button2_Click(object sender, EventArgs e)
        {


            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (sp.IsOpen)
            {
                MessageBox.Show("Port Zaten Açýk!");
            }
            else
            {
                try
                {


                    sp.BaudRate = int.Parse("33600");
                    sp.DataBits = int.Parse("8");
                    sp.StopBits = System.IO.Ports.StopBits.One;
                    sp.Parity = System.IO.Ports.Parity.None;
                    sp.PortName = textBox1.Text;
                    sp.Open();
                    label2.Text = "Baðlantý Baþlatýldý.";
                    SeriPortBagla.ActiveForm.Show();
                }
                catch (Exception EX)
                {
                    MessageBox.Show(EX.ToString());
                  
                }
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            try
            {
                sp.Close();
                label2.Text = "Baðlantý Kapatýldý.";
            }
            catch(Exception exim)
            {

                MessageBox.Show(exim.ToString());

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (sp.IsOpen)
                {
                    label2.Text = "Mesaj Gönderiliyor";
                    Thread.Sleep(500);
                    sp.Write("AT+CMGF=1" + (Char)13);
                    sp.Write(String.Format("AT+CMGS=\"{0}\"" + (Char)13, textBox2.Text));
                    sp.Write(String.Format("{0}" + (Char)26 + (Char)13, trDuzelt(textBox3.Text)));
                    label2.Text = "Mesaj Gönderildi";

                }
            }
            catch
            {
                label2.Text = "Mesaj Gönderilemedi";
            }
        }

        public string trDuzelt(string a)
        {
            a = a.Replace("Ý", "I");
            a = a.Replace("Ü", "U");
            a = a.Replace("Ç", "C");
            a = a.Replace("Þ", "S");
            a = a.Replace("Ö", "O");
            a = a.Replace("Ð", "G");
            a = a.Replace("ý", "I");
            a = a.Replace("ü", "U");
            a = a.Replace("þ", "S");
            a = a.Replace("ç", "C");
            a = a.Replace("ð", "G");
            a = a.Replace("ö", "O");
            return a;
        }

       

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void listView2_DoubleClick(object sender, EventArgs e)
        {
           
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox2.Text = "";
            textBox3.Text = "";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();

            string[] ports = SerialPort.GetPortNames();

            foreach (string port in ports)
            {
                comboBox1.Items.Add(port.ToString());
            }

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        int sayac;

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

            sayac = 160 - textBox3.Text.Length;
            label1.Text = sayac.ToString();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.harmankaya.org/"); 
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            textBox1.Text = comboBox1.SelectedItem.ToString();

        }

    }
}