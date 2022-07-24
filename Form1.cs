using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ПочтовыйКлиетн
{
    public partial class Form1 : Form
    {
        public OpenFileDialog dialog = new OpenFileDialog();
        string d;
        public Form1()
        {
            InitializeComponent();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dialog.ShowDialog() == DialogResult.Cancel)
                return;
            d = dialog.FileName;
            label6.Text = "вы прикрепили файл";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                if (textBox1.Text.Contains("@gmail.com") == true)
                    smtp = new SmtpClient("smtp.gmail.com", 587);
                if (textBox1.Text.Contains("@mail.ru") == true)
                    smtp = new SmtpClient("smtp.mail.ru", 465);
                if (textBox1.Text.Contains("@yandex.ru") == true)
                    smtp = new SmtpClient("smtp.yandex.ru", 25);
                string q = textBox1.Text;
                string w = textBox2.Text;
                string t = textBox3.Text;
                string r = textBox4.Text;
                MailAddress address = new MailAddress(q, r);
                MailAddress mail = new MailAddress(t);
                MailMessage mailMessage = new MailMessage(address, mail);
                if ((label6.Text) != (""))
                    mailMessage.Attachments.Add(new Attachment(d));
                
                mailMessage.Subject = textBox4.Text;
                mailMessage.Body = richTextBox1.Text;
                mailMessage.IsBodyHtml = true;
                SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
                smtpClient.Credentials = new NetworkCredential(q, w);
                smtpClient.EnableSsl = true;
                smtpClient.Send(mailMessage);
            }
            catch
            {
                MessageBox.Show("Не верное заполнение данных. \n Поробуйте ещё");
            }
        }
    }
}
