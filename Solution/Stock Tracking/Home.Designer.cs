namespace StockTracking
{
    partial class Home
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Home));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.listViewItemContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.düzenleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kaldırToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.listView1 = new System.Windows.Forms.ListView();
            this.label2 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.image = new System.Windows.Forms.DataGridViewImageColumn();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.goToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.yeniDefterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.içeAktarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dışaAktarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.çıkToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.düzenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.yeniMüşteriToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.yeniÜrünToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.seçeneklerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tercihlerToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.küçükToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ortaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.büyükToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.yardımToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.youtubeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pikodToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listViewItemContextMenu.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(96, 96);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // listViewItemContextMenu
            // 
            this.listViewItemContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.toolStripSeparator2,
            this.düzenleToolStripMenuItem,
            this.kaldırToolStripMenuItem});
            this.listViewItemContextMenu.Name = "contextMenuStrip1";
            this.listViewItemContextMenu.Size = new System.Drawing.Size(117, 76);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.openToolStripMenuItem.Text = "Aç";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click_1);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(113, 6);
            // 
            // düzenleToolStripMenuItem
            // 
            this.düzenleToolStripMenuItem.Name = "düzenleToolStripMenuItem";
            this.düzenleToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.düzenleToolStripMenuItem.Text = "Düzenle";
            this.düzenleToolStripMenuItem.Click += new System.EventHandler(this.düzenleToolStripMenuItem_Click);
            // 
            // kaldırToolStripMenuItem
            // 
            this.kaldırToolStripMenuItem.Name = "kaldırToolStripMenuItem";
            this.kaldırToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.kaldırToolStripMenuItem.Text = "Kaldır";
            this.kaldırToolStripMenuItem.Click += new System.EventHandler(this.kaldırToolStripMenuItem_Click);
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.DefaultExt = "db";
            this.saveFileDialog1.FileName = "Data.db";
            this.saveFileDialog1.Filter = "Veritabanı (*.db)|*.db|Tüm Dosyalar (*.*)|*.*";
            this.saveFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.saveFileDialog1_FileOk);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.DefaultExt = "db";
            this.openFileDialog1.FileName = "data.db";
            this.openFileDialog1.Filter = "Veritabanı (*.db)|*.db|Tüm Dosyalar (*.*)|*.*";
            this.openFileDialog1.InitialDirectory = "%USERPROFILE%\\Desktop";
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.menuStrip1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(882, 308);
            this.panel1.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel2.Controls.Add(this.listView1);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(348, 24);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(10, 0, 10, 10);
            this.panel2.Size = new System.Drawing.Size(534, 284);
            this.panel2.TabIndex = 2;
            // 
            // listView1
            // 
            this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView1.HideSelection = false;
            this.listView1.LargeImageList = this.imageList1;
            this.listView1.Location = new System.Drawing.Point(10, 25);
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.listView1.Size = new System.Drawing.Size(514, 249);
            this.listView1.SmallImageList = this.imageList1;
            this.listView1.TabIndex = 0;
            this.listView1.TileSize = new System.Drawing.Size(100, 100);
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listView1_MouseClick);
            this.listView1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listView1_MouseDoubleClick);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.SystemColors.ControlLight;
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Location = new System.Drawing.Point(10, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(514, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "Müşterileri Düzenle:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel3.Controls.Add(this.dataGridView1);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(0, 24);
            this.panel3.Name = "panel3";
            this.panel3.Padding = new System.Windows.Forms.Padding(10, 0, 0, 10);
            this.panel3.Size = new System.Drawing.Size(348, 284);
            this.panel3.TabIndex = 1;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.name,
            this.price,
            this.image});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(10, 25);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidth = 64;
            this.dataGridView1.RowTemplate.ContextMenuStrip = this.contextMenuStrip1;
            this.dataGridView1.RowTemplate.Height = 64;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(338, 249);
            this.dataGridView1.TabIndex = 2;
            // 
            // id
            // 
            this.id.HeaderText = "id";
            this.id.MaxInputLength = 32;
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Visible = false;
            // 
            // name
            // 
            this.name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.name.HeaderText = "Ürün Adı";
            this.name.MinimumWidth = 50;
            this.name.Name = "name";
            this.name.ReadOnly = true;
            // 
            // price
            // 
            this.price.HeaderText = "Fiyat";
            this.price.MinimumWidth = 50;
            this.price.Name = "price";
            this.price.ReadOnly = true;
            this.price.Width = 50;
            // 
            // image
            // 
            this.image.HeaderText = "Görsel";
            this.image.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.image.MinimumWidth = 64;
            this.image.Name = "image";
            this.image.ReadOnly = true;
            this.image.Width = 64;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem2,
            this.toolStripMenuItem3});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(117, 48);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(116, 22);
            this.toolStripMenuItem2.Text = "Düzenle";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(116, 22);
            this.toolStripMenuItem3.Text = "Kaldır";
            this.toolStripMenuItem3.Click += new System.EventHandler(this.toolStripMenuItem3_Click);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Location = new System.Drawing.Point(10, 0);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(5);
            this.label1.Size = new System.Drawing.Size(338, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Ürünleri Düzenle:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.goToolStripMenuItem,
            this.düzenToolStripMenuItem,
            this.seçeneklerToolStripMenuItem,
            this.yardımToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(882, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // goToolStripMenuItem
            // 
            this.goToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.yeniDefterToolStripMenuItem,
            this.içeAktarToolStripMenuItem,
            this.dışaAktarToolStripMenuItem,
            this.toolStripSeparator1,
            this.çıkToolStripMenuItem});
            this.goToolStripMenuItem.Name = "goToolStripMenuItem";
            this.goToolStripMenuItem.Size = new System.Drawing.Size(51, 20);
            this.goToolStripMenuItem.Text = "Dosya";
            // 
            // yeniDefterToolStripMenuItem
            // 
            this.yeniDefterToolStripMenuItem.Name = "yeniDefterToolStripMenuItem";
            this.yeniDefterToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.yeniDefterToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.yeniDefterToolStripMenuItem.Text = "Yeni Defter";
            this.yeniDefterToolStripMenuItem.Click += new System.EventHandler(this.yeniDefterToolStripMenuItem_Click);
            // 
            // içeAktarToolStripMenuItem
            // 
            this.içeAktarToolStripMenuItem.Name = "içeAktarToolStripMenuItem";
            this.içeAktarToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.içeAktarToolStripMenuItem.Text = "İçe Aktar";
            this.içeAktarToolStripMenuItem.Click += new System.EventHandler(this.içeAktarToolStripMenuItem_Click);
            // 
            // dışaAktarToolStripMenuItem
            // 
            this.dışaAktarToolStripMenuItem.Name = "dışaAktarToolStripMenuItem";
            this.dışaAktarToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.dışaAktarToolStripMenuItem.Text = "Dışa Aktar";
            this.dışaAktarToolStripMenuItem.Click += new System.EventHandler(this.dışaAktarToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(171, 6);
            // 
            // çıkToolStripMenuItem
            // 
            this.çıkToolStripMenuItem.Name = "çıkToolStripMenuItem";
            this.çıkToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.çıkToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.çıkToolStripMenuItem.Text = "Çık";
            this.çıkToolStripMenuItem.Click += new System.EventHandler(this.çıkToolStripMenuItem_Click);
            // 
            // düzenToolStripMenuItem
            // 
            this.düzenToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.yeniMüşteriToolStripMenuItem,
            this.yeniÜrünToolStripMenuItem});
            this.düzenToolStripMenuItem.Name = "düzenToolStripMenuItem";
            this.düzenToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.düzenToolStripMenuItem.Text = "Düzen";
            // 
            // yeniMüşteriToolStripMenuItem
            // 
            this.yeniMüşteriToolStripMenuItem.Name = "yeniMüşteriToolStripMenuItem";
            this.yeniMüşteriToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.yeniMüşteriToolStripMenuItem.Text = "Yeni Müşteri";
            this.yeniMüşteriToolStripMenuItem.Click += new System.EventHandler(this.yeniMüşteriToolStripMenuItem_Click);
            // 
            // yeniÜrünToolStripMenuItem
            // 
            this.yeniÜrünToolStripMenuItem.Name = "yeniÜrünToolStripMenuItem";
            this.yeniÜrünToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.yeniÜrünToolStripMenuItem.Text = "Yeni Ürün";
            this.yeniÜrünToolStripMenuItem.Click += new System.EventHandler(this.yeniÜrünToolStripMenuItem_Click);
            // 
            // seçeneklerToolStripMenuItem
            // 
            this.seçeneklerToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tercihlerToolStripMenuItem1});
            this.seçeneklerToolStripMenuItem.Name = "seçeneklerToolStripMenuItem";
            this.seçeneklerToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
            this.seçeneklerToolStripMenuItem.Text = "Araçlar";
            // 
            // tercihlerToolStripMenuItem1
            // 
            this.tercihlerToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.küçükToolStripMenuItem,
            this.ortaToolStripMenuItem,
            this.büyükToolStripMenuItem});
            this.tercihlerToolStripMenuItem1.Name = "tercihlerToolStripMenuItem1";
            this.tercihlerToolStripMenuItem1.Size = new System.Drawing.Size(148, 22);
            this.tercihlerToolStripMenuItem1.Text = "Simge Boyutu";
            // 
            // küçükToolStripMenuItem
            // 
            this.küçükToolStripMenuItem.Name = "küçükToolStripMenuItem";
            this.küçükToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.küçükToolStripMenuItem.Text = "Küçük";
            this.küçükToolStripMenuItem.Click += new System.EventHandler(this.listViewSizeChange);
            // 
            // ortaToolStripMenuItem
            // 
            this.ortaToolStripMenuItem.Name = "ortaToolStripMenuItem";
            this.ortaToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.ortaToolStripMenuItem.Text = "Orta";
            this.ortaToolStripMenuItem.Click += new System.EventHandler(this.listViewSizeChange);
            // 
            // büyükToolStripMenuItem
            // 
            this.büyükToolStripMenuItem.Checked = true;
            this.büyükToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.büyükToolStripMenuItem.Name = "büyükToolStripMenuItem";
            this.büyükToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.büyükToolStripMenuItem.Text = "Büyük";
            this.büyükToolStripMenuItem.Click += new System.EventHandler(this.listViewSizeChange);
            // 
            // yardımToolStripMenuItem
            // 
            this.yardımToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.youtubeToolStripMenuItem,
            this.pikodToolStripMenuItem});
            this.yardımToolStripMenuItem.Name = "yardımToolStripMenuItem";
            this.yardımToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
            this.yardımToolStripMenuItem.Text = "Yardım";
            // 
            // youtubeToolStripMenuItem
            // 
            this.youtubeToolStripMenuItem.Name = "youtubeToolStripMenuItem";
            this.youtubeToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.youtubeToolStripMenuItem.Text = "Youtube";
            this.youtubeToolStripMenuItem.Click += new System.EventHandler(this.youtubeToolStripMenuItem_Click);
            // 
            // pikodToolStripMenuItem
            // 
            this.pikodToolStripMenuItem.Name = "pikodToolStripMenuItem";
            this.pikodToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.pikodToolStripMenuItem.Text = "Proje";
            this.pikodToolStripMenuItem.Click += new System.EventHandler(this.pikodToolStripMenuItem_Click);
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(882, 308);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Home";
            this.Text = "Sipariş Takibi";
            this.Load += new System.EventHandler(this.loadForm);
            this.listViewItemContextMenu.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem goToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dışaAktarToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem çıkToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem yeniDefterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem içeAktarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem seçeneklerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tercihlerToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem büyükToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ortaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem küçükToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem düzenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem yeniMüşteriToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip listViewItemContextMenu;
        private System.Windows.Forms.ToolStripMenuItem kaldırToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem yardımToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pikodToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem düzenleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem youtubeToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        public System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ToolStripMenuItem yeniÜrünToolStripMenuItem;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewTextBoxColumn price;
        private System.Windows.Forms.DataGridViewImageColumn image;


    }
}

