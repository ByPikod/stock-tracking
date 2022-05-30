using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.Dynamic;

namespace StockTracking
{
    public partial class AddProduct : Form
    {

        private Home home;
        private dynamic modified = null;
        private int id = 0;

        public AddProduct(Home home)
        {

            this.home = home;
            modified = new ExpandoObject();
            modified.edit = false;
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

        public AddProduct(Home home, int id, string name, float price, Image image): this(home) {
            
            textBox1.Text = name;
            textBox2.Text = price.ToString();
            pictureBox1.Image = image;

            this.id = id;
            button1.Enabled = false;
            button1.Text = "Düzenle";
            Text = "Ürün Düzenle";

            modified.name = name;
            modified.price = price;
            modified.edit = true;

        }

        Image img = null;
        ImageFormat format = null;

        private void button1_Click(object sender, EventArgs e)
        {

            if (img == null && modified.edit == false) {
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

            float sayi;
            try
            {
                sayi = float.Parse(textBox2.Text, System.Globalization.CultureInfo.InvariantCulture);
            }
            catch {
                MessageBox.Show("Fiyatı doğru formatta biçtiğinize emin olun.", home.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if(sayi < 1f){
                
                MessageBox.Show("Lütfen sıfırdan büyük bir fiyat biçiniz.", home.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            if (modified == null)
                this.home.addProduct(textBox1.Text, sayi, img, format);
            else
                this.home.editProduct(id, modified);
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
                
                Image image = Image.FromFile(dlg.FileName);
                img = new Bitmap(image, new Size(96, 96));
                format = image.RawFormat;
                modified.format = format;
                pictureBox1.Image = img;
                button1.Enabled = true;
                modified.image = img;

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
            modified.name = textBox1.Text;

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            
            button1.Enabled = true;
            modified.price = textBox2.Text;

        }

    }
}
