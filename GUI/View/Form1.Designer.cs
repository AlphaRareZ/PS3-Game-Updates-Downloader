using System.Windows.Forms;

namespace GUI
{
    partial class PS3UpdatesDownloaderGUI
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PS3UpdatesDownloaderGUI));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.searchBox = new System.Windows.Forms.TextBox();
            this.searchLabel = new System.Windows.Forms.Label();
            this.refreshDatabaseButton = new System.Windows.Forms.Button();
            this.downloadButton = new System.Windows.Forms.Button();
            this.searchButton = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.BrowseButton = new System.Windows.Forms.Button();
            this.DownloadDirLabel = new System.Windows.Forms.Label();
            this.DownloadDirTextBox = new System.Windows.Forms.TextBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.ColumnHeadersVisible = false;
            this.dataGridView1.Location = new System.Drawing.Point(12, 188);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(776, 270);
            this.dataGridView1.TabIndex = 0;
            // 
            // searchBox
            // 
            this.searchBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchBox.Location = new System.Drawing.Point(225, 54);
            this.searchBox.Name = "searchBox";
            this.searchBox.Size = new System.Drawing.Size(422, 28);
            this.searchBox.TabIndex = 4;
            // 
            // searchLabel
            // 
            this.searchLabel.AutoSize = true;
            this.searchLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchLabel.Location = new System.Drawing.Point(18, 57);
            this.searchLabel.Name = "searchLabel";
            this.searchLabel.Size = new System.Drawing.Size(108, 24);
            this.searchLabel.TabIndex = 5;
            this.searchLabel.Text = "Search Box";
            // 
            // refreshDatabaseButton
            // 
            this.refreshDatabaseButton.BackgroundImage = global::GUI.Resource1.refreshIcon;
            this.refreshDatabaseButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.refreshDatabaseButton.Location = new System.Drawing.Point(672, 135);
            this.refreshDatabaseButton.Name = "refreshDatabaseButton";
            this.refreshDatabaseButton.Size = new System.Drawing.Size(55, 47);
            this.refreshDatabaseButton.TabIndex = 8;
            this.refreshDatabaseButton.UseVisualStyleBackColor = true;
            this.refreshDatabaseButton.Click += new System.EventHandler(this.RefreshDatabaseButton_Click);
            // 
            // downloadButton
            // 
            this.downloadButton.BackgroundImage = global::GUI.Resource1.downloadIcon;
            this.downloadButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.downloadButton.Location = new System.Drawing.Point(733, 135);
            this.downloadButton.Name = "downloadButton";
            this.downloadButton.Size = new System.Drawing.Size(55, 47);
            this.downloadButton.TabIndex = 7;
            this.downloadButton.UseVisualStyleBackColor = true;
            this.downloadButton.Click += new System.EventHandler(this.DownloadButton_Click);
            // 
            // searchButton
            // 
            this.searchButton.BackgroundImage = global::GUI.Resource1.searchIcon;
            this.searchButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.searchButton.Location = new System.Drawing.Point(653, 53);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(74, 29);
            this.searchButton.TabIndex = 6;
            this.searchButton.UseVisualStyleBackColor = true;
            this.searchButton.Click += new System.EventHandler(this.SearchButton_Click);
            // 
            // BrowseButton
            // 
            this.BrowseButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.BrowseButton.Location = new System.Drawing.Point(653, 91);
            this.BrowseButton.Name = "BrowseButton";
            this.BrowseButton.Size = new System.Drawing.Size(34, 28);
            this.BrowseButton.TabIndex = 11;
            this.BrowseButton.Text = "...";
            this.BrowseButton.UseVisualStyleBackColor = true;
            this.BrowseButton.Click += new System.EventHandler(this.BrowseButton_Click);
            // 
            // DownloadDirLabel
            // 
            this.DownloadDirLabel.AutoSize = true;
            this.DownloadDirLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DownloadDirLabel.Location = new System.Drawing.Point(18, 91);
            this.DownloadDirLabel.Name = "DownloadDirLabel";
            this.DownloadDirLabel.Size = new System.Drawing.Size(183, 24);
            this.DownloadDirLabel.TabIndex = 10;
            this.DownloadDirLabel.Text = "Downloads Directory";
            // 
            // DownloadDirTextBox
            // 
            this.DownloadDirTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DownloadDirTextBox.Location = new System.Drawing.Point(225, 91);
            this.DownloadDirTextBox.Name = "DownloadDirTextBox";
            this.DownloadDirTextBox.Size = new System.Drawing.Size(422, 28);
            this.DownloadDirTextBox.TabIndex = 9;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(12, 464);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(776, 23);
            this.progressBar1.TabIndex = 12;
            // 
            // PS3UpdatesDownloaderGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::GUI.Resource1.sony_playstation_wallpaper_preview;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(797, 515);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.BrowseButton);
            this.Controls.Add(this.DownloadDirLabel);
            this.Controls.Add(this.DownloadDirTextBox);
            this.Controls.Add(this.refreshDatabaseButton);
            this.Controls.Add(this.downloadButton);
            this.Controls.Add(this.searchButton);
            this.Controls.Add(this.searchLabel);
            this.Controls.Add(this.searchBox);
            this.Controls.Add(this.dataGridView1);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PS3UpdatesDownloaderGUI";
            this.Text = "PS3 Game Updates Downloader";
            this.Load += new System.EventHandler(this.PS3GamesUpdater_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox searchBox;
        private System.Windows.Forms.Label searchLabel;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.Button downloadButton;
        private System.Windows.Forms.Button refreshDatabaseButton;
        private FolderBrowserDialog folderBrowserDialog1;
        private Button BrowseButton;
        private Label DownloadDirLabel;
        private TextBox DownloadDirTextBox;
        public ProgressBar progressBar1;
    }
}

