using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Imaging;

namespace StockTracking
{
    public partial class AddClient : Form
    {

        private Home home;
        private bool edit = false;
        private int id = 0;
        public AddClient(Home home)
        {

            this.home = home;
            InitializeComponent();

            ImageCodecInfo[] codecs = ImageCodecInfo.GetImageEncoders();
            string sep = "|";
            dlg.Filter = "All files (*.*)|*.*";
            foreach (var c in codecs)
            {
                string codecName = c.CodecName.Substring(8).Replace("Codec", "Files").Trim();
                dlg.Filter = String.Format("{0}{1}{2} ({3})|{3}", dlg.Filter, sep, codecName, c.FilenameExtension);
            }

            dlg.DefaultExt = ".png"; // Default file extension 

        }
        
        public AddClient(Home home, int id, string name, Image image) : this(home) {
            
            this.Text = "Müşteri Düzenle";
            button1.Text = "Kaydet";
            pictureBox1.Image = image;
            textBox1.Text = name;
            edit = true;
            this.id = id;
            button1.Enabled = false;

        }

        Image img = null;
        ImageFormat format = null;

        private void button1_Click(object sender, EventArgs e)
        {

            if (img == null && !edit) {
                MessageBox.Show("Lütfen görsel ekleyiniz.", home.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if(textBox1.Text.Length < 2){
                MessageBox.Show("Lütfen daha uzun bir isim yazınız.", home.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (textBox1.Text.Length > 32)
            {
                MessageBox.Show("Lütfen daha kısa bir isim yazınız.", home.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!edit)
                this.home.addClient(textBox1.Text, img, format);
            else
            {
                this.home.editClient(id, textBox1.Text, img, format);
            }
            this.Close();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
            dlg.ShowDialog();

        }

        private void dlg_FileOk(object sender, CancelEventArgs e)
        {

            try
            {
                
                var image = Image.FromFile(dlg.FileName);
                img = new Bitmap(image, new Size(96, 96));
                format = image.RawFormat;
                pictureBox1.Image = img;
                button1.Enabled = true;

            }
            catch
            {
                MessageBox.Show("Eklemek istediğiniz dosya desteklenmiyor.", home.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Cancel = true;
            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            button1.Enabled = true;
        }

    }
}
