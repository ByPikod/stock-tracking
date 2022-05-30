using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Dynamic;

namespace StockTracking
{
    public partial class StockInterface : MyForm
    {
        
        private Home home;
        private int id;

        private int _currentPage = 1;
        private int currentPage { 
            
            get {
                
                return _currentPage;

            }
            set {
                
                _currentPage = value;
                loadPage();

            }

        }

        private int maxPages;
        private int rowCount;
        private string searchQuery = "";

        public StockInterface(Home home, int id)
        {
            InitializeComponent();

            Database.Open();

            using (var cmd = Database.CreateCommand())
            {

                cmd.CommandText = string.Format("SELECT name FROM Clients WHERE row={0}", id);
                using (var reader = cmd.ExecuteReader())
                {

                    var read = reader.Read();

                    if (!read)
                    {
                        MessageBox.Show("Ulaşılmaya çalışılan müşteri bulunamadı.", home.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    Text = "Müşteri: " + reader.GetString(0);
                }

            }

            button6.Text = maxPages.ToString() + ". Sayfa";
            label1.Text = currentPage.ToString() + ". Sayfa";
            label6.Text = "Toplam "+rowCount+" kayıt listelendi.";

            Database.Close();
            
            this.home = home;
            this.id = id;

        }

        public void loadPage()
        {

            dataGridView1.Rows.Clear();
            Database.Open();


            using(var cmd = Database.CreateCommand()){

                cmd.CommandText = "SELECT COUNT(*) FROM Orders as o INNER JOIN Products AS p ON o.product_id = p.id WHERE o.client_id = '" + id + "' " + searchQuery;
                rowCount = Convert.ToInt32(cmd.ExecuteScalar());
                maxPages = (rowCount / 10) + 1;

            }

            button6.Text = maxPages + ". Sayfa";
            label1.Text = currentPage + ". Sayfa";
            label6.Text = "Toplam " + rowCount + " kayıt listelendi.";

            using(var cmd = Database.CreateCommand()){

                int offset = (currentPage - 1) * 10;
                cmd.CommandText = "SELECT o.id, o.timestamp, o.product_id, o.count, o.description FROM Orders as o INNER JOIN Products as p ON o.product_id = p.id WHERE o.client_id = '" + id + "' "+searchQuery+" ORDER BY o.timestamp DESC LIMIT 10 OFFSET " + offset.ToString();
                using (var reader = cmd.ExecuteReader()) {

                    while (reader.Read())
                    {

                        int identity = reader.GetInt32(0);
                        long timestamp = reader.GetInt64(1);
                        int product_id = reader.GetInt32(2);
                        int count = reader.GetInt32(3);
                        string description = reader.GetString(4);
                        var product = home.products[product_id];

                        dataGridView1.Rows.Add(new object[] { identity, product.image, product.name, new DateTime(1970, 1, 1).AddSeconds(timestamp).ToShortDateString(), count, product.price, product.price * count, description });

                    }

                }

            }
            
            if(currentPage >= maxPages){
                button2.Enabled = false;
                button6.Enabled = false;
            }
            else
            {
                button2.Enabled = true;
                button6.Enabled = true;
            }

            if (currentPage <= 1)
            {
                button1.Enabled = false;
                button7.Enabled = false;
            }
            else {
                button1.Enabled = true;
                button7.Enabled = true;
            }

            Database.Close();
            dataGridView1.ClearSelection();
            selectionId = 0;
            resetForm();
            

        }

        private void StockInterface_FormClosing(object sender, FormClosingEventArgs e)
        {


        }

        private void StockInterface_Load(object sender, EventArgs e)
        {

            foreach (var val in home.products.Values)
            {
                comboBox1.Items.Add(val.name);
            }

            comboBox1.SelectedIndex = 0;
            pictureBox1.Image = home.products.ElementAt(comboBox1.SelectedIndex).Value.image;
            dateTimePicker1.Value = DateTime.Now;

            loadPage();

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            pictureBox1.Image = home.products.ElementAt(comboBox1.SelectedIndex).Value.image;
        }

        private dynamic checkCompatibility() {
            
            dynamic ret = new ExpandoObject();
            ret.error = true;

            try {
                ret.count = int.Parse(textBox2.Text);
            }catch{
                ret.errorText = "Lütfen ürün adetine geçerli bir sayı giriniz.";
                return ret;
            }

            ret.product = home.products.ElementAt(comboBox1.SelectedIndex).Value;
            ret.timestamp = dateTimePicker1.Value;
            ret.description = richTextBox1.Text;

            ret.error = false;
            return ret;

        }

        private void button4_Click(object sender, EventArgs e)
        {

            dynamic order = checkCompatibility();
            if(order.error){
                MessageBox.Show(order.errorText, home.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Database.Open();

            using(var cmd = Database.CreateCommand()){

                var cmdText = !button8.Enabled ? 
                    "INSERT INTO Orders (timestamp, product_id, client_id, count, description) VALUES ({0}, {1}, {2}, {3}, @description)"
                    :
                    "UPDATE Orders SET timestamp={0}, product_id={1}, client_id={2}, count={3}, description=@description WHERE id="+selectionId
                    ;
                long unix = (long) order.timestamp.Subtract(new DateTime(1970, 1, 1)).TotalSeconds;
                cmd.CommandText = string.Format(cmdText, unix.ToString(), order.product.id.ToString(), id.ToString(), order.count.ToString());
                cmd.Parameters.AddWithValue("@description", order.description);
                cmd.ExecuteNonQuery();

            }

            Database.Close();
            selectionId = 0;
            resetForm();
            loadPage();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            currentPage += 1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            currentPage -= 1;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            currentPage = maxPages;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            currentPage = 1;
        }

        private void StockInterface_FormClosed(object sender, FormClosedEventArgs e)
        {

            GC.Collect();

        }

        int selectionId = 0;
        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            
            if (Database.State == ConnectionState.Open) return;
            if (dataGridView1.SelectedCells.Count < 1) return;

            selectionId = (int) dataGridView1.SelectedRows[0].Cells[0].Value;

            Database.Open();

            using(var cmd = Database.CreateCommand()){

                cmd.CommandText = string.Format("SELECT * FROM Orders WHERE id="+selectionId);

                using (var reader = cmd.ExecuteReader()){

                    reader.Read();
                    var timestamp = reader.GetInt64(1); 
                    var product_id = reader.GetInt32(2);
                    var count = reader.GetInt32(4);
                    var description = reader.GetString(5);

                    int product_index = 0;
                    foreach (var v in home.products.Keys)
                    {
                        
                        if(v == product_id){
                            break;
                        }
                        product_index++;

                    }

                    comboBox1.SelectedIndex = product_index;
                    textBox2.Text = count.ToString();
                    dateTimePicker1.Value = new DateTime(1970, 1, 1).AddSeconds(timestamp);
                    richTextBox1.Text = description;

                    button5.Enabled = true;
                    button8.Enabled = true;
                    button4.Text = "Düzenle";
                    button4.Font = new Font(button4.Font, FontStyle.Bold);

                }

            }

            Database.Close();

        }

        public void resetForm() {

            comboBox1.SelectedIndex = 0;
            pictureBox1.Image = home.products.ElementAt(comboBox1.SelectedIndex).Value.image;
            textBox2.Text = "";
            button4.Text = "Ekle";
            dateTimePicker1.Value = DateTime.Now;
            richTextBox1.Text = null;
            button5.Enabled = false;
            button8.Enabled = false;
            button4.Font = new Font(button4.Font, FontStyle.Regular);

        }

        private void button8_Click(object sender, EventArgs e)
        {
            dataGridView1.ClearSelection();
            selectionId = 0;
            resetForm();
        }

        private void button5_Click(object sender, EventArgs e)
        {

            DialogResult res = MessageBox.Show("Kayıt sonsuza kadar silinecek.", home.Text, MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (res == DialogResult.Cancel) return;
            
            Database.Open();

            using(var cmd = Database.CreateCommand()){
                
                cmd.CommandText = "DELETE FROM Orders WHERE id="+selectionId;
                cmd.ExecuteNonQuery();

            }

            Database.Close();

            selectionId = 0;
            loadPage();
            resetForm();

        }

        
        private void button3_Click(object sender, EventArgs e)
        {
        
            if (textBox1.Text == string.Empty) {
                
                this.Close();
                return;

            } else textBox1.Text = "";
            
            searchQuery = "";
            loadPage();
        
        }

        private void button9_Click(object sender, EventArgs e)
        {
            
            if (textBox1.Text == string.Empty) {
            
                button3.PerformClick();
                return;
            
            }

            var str = Home.htmlspecialcharacters(textBox1.Text);
            searchQuery = "AND (o.description LIKE '%"+str+"%' OR p.name LIKE '%"+str+"%')";
            loadPage();

        }
        

    }
}
