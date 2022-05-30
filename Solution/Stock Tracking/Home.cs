using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using System.IO;
using System.Drawing.Imaging;
using System.Data.SQLite;
using System.Dynamic;

namespace StockTracking
{

    public partial class Home : MyForm
    {
        public Home()
        {
            InitializeComponent();
        }

        private List<Image> images = new List<Image>();
        //private List<MyForm> client_windows = new List<MyForm>();
        public Dictionary<int, Product> products = new Dictionary<int, Product>();

        public class Product
        {
            
            public string name;
            public float price;
            public Image image;
            public int id;

            public Product(string name, float price, Image image, int id) {
                
                this.name = name;
                this.price = price;
                this.image = image;
                this.id = id;

            }

        }

        private void loadForm(object sender, EventArgs e)
        {

            load();

        }

        public void load() {

            listView1.Clear();
            images.Clear();

            loadClients();
            loadProducts();
            //createWindows();

        }

        private void loadProducts(){

            dataGridView1.Rows.Clear();
            products.Clear();
            Database.Open();

            using (var cmd = Database.CreateCommand())
            {

                cmd.CommandText = "SELECT id, name, image, price FROM Products ORDER BY name";
                using (var dataReader = cmd.ExecuteReader())
                {

                    while (dataReader.Read())
                    {

                        var name = dataReader.GetString(1);
                        var base64 = dataReader.GetString(2);
                        var price = dataReader.GetFloat(3);
                        var id = dataReader.GetInt32(0);

                        var image = Base64ToImage(base64);

                        products.Add(id, new Product(name, price, image, id));

                    }

                }
            
            }

            Database.Close();
            updateProductList();

        }

        /* private void createWindows() {

            client_windows.Clear();
            for (int i = 0; i < listView1.Items.Count; i++ )
            {
                StockInterface sif = new StockInterface(this, i);
                client_windows.Add(sif);
            }
        
        } */

        private void updateProductList() {

            dataGridView1.Rows.Clear();
            foreach(var prod in products){
                dataGridView1.Rows.Add(new object[] {prod.Value.id, prod.Value.name, prod.Value.price, prod.Value.image});
            }

        }

        private void updateListView(bool sizeChange = true) {

            imageList1.Images.Clear();

            if (sizeChange) {
                büyükToolStripMenuItem.Checked = false;
                ortaToolStripMenuItem.Checked = false;
                küçükToolStripMenuItem.Checked = false;

                switch (Config.list_view_size)
                {
                    case 1:
                        küçükToolStripMenuItem.Checked = true;
                        imageList1.ImageSize = new Size(32, 32);
                        break;
                    case 0:
                        ortaToolStripMenuItem.Checked = true;
                        imageList1.ImageSize = new Size(64, 64);
                        break;
                    case -1:
                        büyükToolStripMenuItem.Checked = true;
                        imageList1.ImageSize = new Size(96, 96);
                        break;
                }

            }

            Image[] imagesCopy = new Image[images.Count];
            images.CopyTo(imagesCopy, 0);
            imageList1.Images.AddRange(imagesCopy);
            
        }

        public void loadClients()
        {

            Database.Open();

            using (var cmd = Database.CreateCommand())
            {
                cmd.CommandText = "SELECT row, name, img FROM Clients ORDER BY row ASC";
                using (var dataReader = cmd.ExecuteReader())
                {

                    while (dataReader.Read())
                    {

                        var name = dataReader.GetString(1);
                        var base64 = dataReader.GetString(2);
                        var row = dataReader.GetInt32(0);

                        var image = Base64ToImage(base64);
                        images.Add(image);

                        var item = new ListViewItem();

                        item.Text = name;
                        item.ImageIndex = row;

                        listView1.Items.Add(item);

                    }
                }
            }

            Database.Close();
            updateListView(false);

        }

        public static string banned = "\\'\"";
        public static string htmlspecialcharacters(string text) { 
            
            var ret = "";
            foreach(var x in text){

                bool check = false;
                foreach(var y in banned){

                    if (x == y)
                    {
                        ret += "\\" + x;
                        check = true;
                        break;
                    }

                }
                if (!check)
                    ret += x;

            }

            return ret;

        }

        public static Image Base64ToImage(string base64String)
        {

            byte[] imageBytes = Convert.FromBase64String(base64String);
            using (var ms = new MemoryStream(imageBytes, 0, imageBytes.Length))
            {
                Image image = Image.FromStream(ms, true);
                return image;
            }

        }

        public void addClient(String name, Image image, ImageFormat format) {


            string base64String;
            using (MemoryStream m = new MemoryStream())
            {
                image.Save(m, format);
                byte[] imageBytes = m.ToArray();
                base64String = Convert.ToBase64String(imageBytes);
            }

            images.Add(image);
            updateListView(false);

            ListViewItem item = new ListViewItem();
            item.Text = name;
            item.ImageIndex = images.Count - 1;
            listView1.Items.Add(item);

            Database.Open();

            using (var cmd = Database.CreateCommand())
            {
                cmd.CommandText = @"INSERT INTO Clients (row, name, img) VALUES (" + (listView1.Items.Count - 1) + ", '" + name + "', '" + base64String + "')";
                cmd.ExecuteNonQuery();
            }

            Database.Close();

            //client_windows.Add(new StockInterface(this, listView1.Items.Count - 1));

        }

        public void editClient(int id, string name, Image image, ImageFormat format) {

            string base64String = null;

            if(image != null){
                
                using (MemoryStream m = new MemoryStream())
                {
                    image.Save(m, format);
                    byte[] imageBytes = m.ToArray();
                    base64String = Convert.ToBase64String(imageBytes);
                }
                
                images[id] = image;

            }
           
            updateListView(false);
            listView1.Items[id].Text = name;

            Database.Open();

            using (var cmd = Database.CreateCommand())
            {
                if (base64String == null)
                    cmd.CommandText = string.Format(@"UPDATE Clients SET name='{0}' WHERE row={1}", name, id);
                else
                    cmd.CommandText = string.Format(@"UPDATE Clients SET name='{0}', img='{1}' WHERE row={2}", name, base64String, id);

                cmd.ExecuteNonQuery();
            }

            Database.Close();

        }

        public void addProduct(string name, float price, Image image, ImageFormat format)
        {


            string base64String;
            using (MemoryStream m = new MemoryStream())
            {
                image.Save(m, format);
                byte[] imageBytes = m.ToArray();
                base64String = Convert.ToBase64String(imageBytes);
            }

            Database.Open();

            using (var cmd = Database.CreateCommand())
            {

                cmd.CommandText = string.Format(@"INSERT INTO Products (name, image, price) VALUES ('{0}', '{1}', '{2}'); SELECT last_insert_rowid();", name, base64String, price.ToString(System.Globalization.CultureInfo.InvariantCulture));

                var id = Convert.ToInt32((long)cmd.ExecuteScalar());
                this.products.Add(id, new Product(name, price, image, id));
                updateProductList();

            }

            Database.Close();

        }

        public static bool HasProperty(dynamic obj, string name)
        {
            Type objType = obj.GetType();

            if (objType == typeof(ExpandoObject))
            {
                return ((IDictionary<string, object>)obj).ContainsKey(name);
            }

            return objType.GetProperty(name) != null;
        }

        public void editProduct(int id, dynamic modified)
        {

            Database.Open();

            Product product = this.products[id];

            using (var cmd = Database.CreateCommand())
            {

                if (HasProperty(modified, "image"))
                {

                    var image = (Image)modified.image;
                    using (MemoryStream m = new MemoryStream())
                    {
                        image.Save(m, modified.format);
                        byte[] imageBytes = m.ToArray();
                        var base64String = Convert.ToBase64String(imageBytes);
                        cmd.CommandText = string.Format(@"UPDATE Clients SET name='{0}', price='{1}', img='{2}' WHERE id={3}", modified.name, modified.price, base64String, id);
                    }
                    product.image = image;

                } else
                    cmd.CommandText = string.Format(@"UPDATE Products SET name='{0}', price='{1}' WHERE id={2}", modified.name, modified.price.ToString(), id.ToString());

                cmd.ExecuteNonQuery();

            }


            
            product.name = modified.name;
            product.price = modified.price;

            updateProductList();
            Database.Close();

        }

        private void listViewSizeChange(object sender, EventArgs e)
        {

            if (sender.Equals(büyükToolStripMenuItem))
            {
                Config.list_view_size = -1;
            }
            else if (sender.Equals(ortaToolStripMenuItem))
            {
                Config.list_view_size = 0;
            }
            else if (sender.Equals(küçükToolStripMenuItem))
            {
                Config.list_view_size = 1;
            }

            Configuration.SaveConfiguration(Config);
            updateListView();

        }

        private void çıkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Environment.Exit(0);
        }

        private void yeniMüşteriToolStripMenuItem_Click(object sender, EventArgs e)
        {

            AddClient client = new AddClient(this);
            client.ShowDialog();

        }

        private void listView1_MouseClick(object sender, MouseEventArgs e)
        {

            if (e.Button == MouseButtons.Right && listView1.FocusedItem != null && listView1.FocusedItem.Bounds.Contains(e.Location))
                listViewItemContextMenu.Show(Cursor.Position);

        }

        private void kaldırToolStripMenuItem_Click(object sender, EventArgs e)
        {

            DialogResult res = MessageBox.Show("Bunu yaparsanız müşteri ve müşteriye dair tüm kayıtlar sonsuza kadar silinecek.", Text, MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (res == DialogResult.Cancel) return;

            Database.Open();

            var id = listView1.FocusedItem.Index;
            using (var cmd = Database.CreateCommand())
            {


                cmd.CommandText = "DELETE FROM Orders WHERE client_id=" + id + "; DELETE FROM HandledOrders WHERE client_id=" + id;
                cmd.ExecuteNonQuery();

                cmd.CommandText = string.Format(
                    @"DELETE FROM Clients WHERE row = '{0}' LIMIT 1;" +
                    @"UPDATE Clients SET row=row-1 WHERE row > {0}",
                    id);

                var reader = cmd.ExecuteNonQuery();
            

                if (reader == 0)
                {
                    MessageBox.Show("Bir hata oluştu, lütfen uygulamayı yeniden başlatın.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else {

                    for (int i = id+1; i < listView1.Items.Count; i++ )
                    {
                        var item = listView1.Items[i];
                        item.ImageIndex = item.ImageIndex - 1;
                    }

                    images.RemoveAt(id);
                    //client_windows.RemoveAt(id);
                    listView1.Items.RemoveAt(id);
                    updateListView(false);

                }

            }

            Database.Close();

        }

        private void pikodToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("İş Adamları M.T.A.L 2021-2022 eğitim yılı 2. dönem \"veritabanı\" kullanımı içeren otomasyon/sipariş takibi uygulamaları proje ödevi.\n\nYahya Batulu\nyahyabatulu0@gmail.com", Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void youtubeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.youtube.com/c/Pikod");
        }

        private void yeniDefterToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if(File.Exists("data.db")){
                try
                {
                    File.Delete("data.db");
                }
                catch {
                    MessageBox.Show("Veritabanı silinirken bir hata oluştu. Başka bir uygulama tarafından kullanılıyor olabilir.", Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            Program.createDatabase();
            load();

        }

        private void içeAktarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            DialogResult res = MessageBox.Show("Eğer bunu yaparsanız bu defterdeki veriler sonsuza kadar yok olacak. İçeri aktarmak istediğinize emin misiniz ?", Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.No) return;
            openFileDialog1.ShowDialog();

        }

        private void dışaAktarToolStripMenuItem_Click(object sender, EventArgs e)
        {

            DateTime date = DateTime.Now;
            saveFileDialog1.FileName = "Stok Takip Defter "+date.Day+"-"+date.Month+"-"+date.Year;
            saveFileDialog1.ShowDialog();

        }

        private void Home_FormClosing(object sender, FormClosingEventArgs e)
        {

            /*DialogResult res = MessageBox.Show("Çıkmak istediğinize emin misiniz ?", Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.No)
            {
                e.Cancel = true;
            }*/

        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

            var self = (SaveFileDialog) sender;
            var path = self.FileName;
            if (File.Exists(path)) {
                try
                {
                    File.Delete(path);
                }
                catch {
                    MessageBox.Show("Dosya dışa aktarılırken bir hata oluştu.", Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            
            File.Copy("data.db", path);

        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

            var self = (OpenFileDialog) sender;
            try
            {
                
                Database.Close();
                GC.Collect();
                GC.WaitForPendingFinalizers();
                File.Delete("data.db");

            }
            catch { }

            if(File.Exists("data.db")) {
                try
                {

                    Database.Close();
                    GC.Collect();
                    GC.WaitForPendingFinalizers();
                    File.Delete("data.db");

                }
                catch (Exception err) {
                    MessageBox.Show("İçeri aktarma işlemi esnasında bir hata oluştu: \n\n" + err.ToString(), Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            File.Copy(self.FileName, "data.db");

            Program.createDatabase();
            load();

        }

        private void düzenleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            var focused = listView1.FocusedItem;
            AddClient edit = new AddClient(this, focused.Index, focused.Text, images[focused.ImageIndex]);
            edit.ShowDialog();

        }

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {

            if (e.Button == MouseButtons.Left && listView1.FocusedItem != null)
            {
                new StockInterface(this, listView1.FocusedItem.Index).Show();
            }

        }

        private void openToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            new StockInterface(this, listView1.FocusedItem.Index).Show();
        }

        private void yeniÜrünToolStripMenuItem_Click(object sender, EventArgs e)
        {

            AddProduct product = new AddProduct(this);
            product.ShowDialog();
        
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            

        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {

            var rows = dataGridView1.SelectedRows[0];
            var id = (int) rows.Cells[0].Value;
            var name = (string)rows.Cells[1].Value;
            var price = (float)rows.Cells[2].Value;
            var image = (Image)rows.Cells[3].Value;

            var product = new AddProduct(this, id, name, price, image);
            product.ShowDialog();

        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {

            int id = (int) dataGridView1.SelectedRows[0].Cells[0].Value;
            
            DialogResult res = MessageBox.Show("Bunu yaparsanız ürün ve ürünle bağlantılı tüm kayıtlar sonsuza kadar silinecek.", Text, MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (res == DialogResult.Cancel) return;

            Database.Open();

            using (var cmd = Database.CreateCommand())
            {

                cmd.CommandText = string.Format("DELETE FROM Products WHERE id={0} LIMIT 1", id);
                cmd.ExecuteNonQuery();

                cmd.CommandText = "DELETE FROM Orders WHERE product_id=" + id + "; DELETE FROM HandledOrders WHERE product_id=" + id;
                cmd.ExecuteNonQuery();

            }

            Database.Close();

            loadProducts();
        }

    }
}
