using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SQLite;

namespace StockTracking
{
    public class MyForm : Form
    {

        protected ConfigObject Config {

            get {
                return Program.Config;
            }

        }

        protected SQLiteConnection Database
        {
            get {
                return Program.SQL;
            }
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MyForm));
            this.SuspendLayout();
            // 
            // MyForm
            // 
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MyForm";
            this.ResumeLayout(false);

        }
        
    }

    public class MyPanel : Panel
    {

        public Button AcceptButton { get; set; }
        public Button CancelButton { get; set; }

        protected override bool ProcessDialogKey(Keys keyData)
        {

            if (keyData == Keys.Enter)
            {
                AcceptButton.PerformClick();
                return true;
            }
            else if (keyData == Keys.Escape)
            {
                CancelButton.PerformClick();
                return true;
            }

            return base.ProcessDialogKey(keyData);

        }

    }

    public class MyGroupbox : GroupBox
    {
        public Button AcceptButton { get; set; }
        public Button CancelButton { get; set; }

        protected override bool ProcessDialogKey(Keys keyData)
        {

            if (keyData == Keys.Enter)
            {
                AcceptButton.PerformClick();
                return true;
            }else if (keyData == Keys.Escape)
            {
                CancelButton.PerformClick();
                return true;
            }

            return base.ProcessDialogKey(keyData);

        }

    }

}
