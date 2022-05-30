using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Data.SQLite;
using System.IO;

namespace StockTracking
{
    static class Program
    {

        private static ConfigObject config;
        public static ConfigObject Config
        {
            get { return config; }
        }

        private static SQLiteConnection conn;
        public static SQLiteConnection SQL
        {
            get { return conn; }
        }

        [STAThread]
        static void Main()
        {

            config = Configuration.Initialize();
            createDatabase();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Home());

        }

        public static void createDatabase() {

            try
            {

                conn = new SQLiteConnection("Data Source=data.db;Version=3");
                SQL.Open();

            }catch {
                try
                {

                    SQL.Close();
                    GC.Collect();
                    GC.WaitForPendingFinalizers();
                    File.Delete("data.db");
                }
                catch { }

                MessageBox.Show("Veritabanını içe aktarırken bir sorun oluştu! İçeri aktarılan veritabanı siliniyor.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // Clients
            using (var cmd = SQL.CreateCommand()) {

                cmd.CommandText = @"CREATE TABLE IF NOT EXISTS Clients (
                    row INTEGER NOT NULL,
                    name TEXT NOT NULL,
                    img TEXT NOT NULL,
                    PRIMARY KEY(row)
                )";
                cmd.ExecuteNonQuery();

            }
           

            // Products
            using (var cmd = SQL.CreateCommand())
            {

                cmd.CommandText = @"CREATE TABLE IF NOT EXISTS Products (
                    id INTEGER PRIMARY KEY AUTOINCREMENT,
                    name TEXT NOT NULL,
                    image TEXT NOT NULL,
                    price FLOAT NOT NULL
                )";
                cmd.ExecuteNonQuery();

            }

            // Orders
            using (var cmd = SQL.CreateCommand())
            {

                cmd.CommandText = @"CREATE TABLE IF NOT EXISTS Orders (
                    id INTEGER PRIMARY KEY AUTOINCREMENT,
                    timestamp INTEGER,
                    product_id INTEGER NOT NULL,
                    client_id INTEGER NOT NULL,
                    count INTEGER NOT NULL,
                    description TEXT,
                    FOREIGN KEY(product_id) REFERENCES Products(id),
                    FOREIGN KEY(client_id) REFERENCES Clients(id)
                )";
                cmd.ExecuteNonQuery();
            
            }

            SQL.Close();

        }

    }
}
