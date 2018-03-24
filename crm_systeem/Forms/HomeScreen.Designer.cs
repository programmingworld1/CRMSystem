namespace crm_systeem
{
    partial class HomeScreen
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
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem("");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HomeScreen));
            this.buttonManage = new System.Windows.Forms.Button();
            this.pictureBoxHeader = new System.Windows.Forms.PictureBox();
            this.pictureBoxBottomBar = new System.Windows.Forms.PictureBox();
            this.buttonHome = new System.Windows.Forms.Button();
            this.pictureBoxMenuBar = new System.Windows.Forms.PictureBox();
            this.buttonSearch = new System.Windows.Forms.Button();
            this.textBoxSearch = new System.Windows.Forms.TextBox();
            this.menuStripUser = new System.Windows.Forms.MenuStrip();
            this.ListViewActors = new System.Windows.Forms.ListView();
            this.menuStripDatabaseSelect = new System.Windows.Forms.MenuStrip();
            this.comboBoxSearch = new System.Windows.Forms.ComboBox();
            this.buttonManageAdd = new System.Windows.Forms.Button();
            this.buttonManageEdit = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxHeader)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBottomBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMenuBar)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonManage
            // 
            this.buttonManage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.buttonManage.FlatAppearance.BorderSize = 0;
            this.buttonManage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonManage.ForeColor = System.Drawing.Color.White;
            this.buttonManage.Location = new System.Drawing.Point(100, 50);
            this.buttonManage.Name = "buttonManage";
            this.buttonManage.Size = new System.Drawing.Size(100, 36);
            this.buttonManage.TabIndex = 1;
            this.buttonManage.Text = "Beheer";
            this.buttonManage.UseVisualStyleBackColor = false;
            this.buttonManage.Click += new System.EventHandler(this.buttonManage_Click);
            // 
            // pictureBoxHeader
            // 
            this.pictureBoxHeader.BackColor = System.Drawing.Color.Olive;
            this.pictureBoxHeader.Location = new System.Drawing.Point(-3, 0);
            this.pictureBoxHeader.Name = "pictureBoxHeader";
            this.pictureBoxHeader.Size = new System.Drawing.Size(914, 50);
            this.pictureBoxHeader.TabIndex = 6;
            this.pictureBoxHeader.TabStop = false;
            // 
            // pictureBoxBottomBar
            // 
            this.pictureBoxBottomBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.pictureBoxBottomBar.Location = new System.Drawing.Point(-3, 702);
            this.pictureBoxBottomBar.Name = "pictureBoxBottomBar";
            this.pictureBoxBottomBar.Size = new System.Drawing.Size(914, 36);
            this.pictureBoxBottomBar.TabIndex = 7;
            this.pictureBoxBottomBar.TabStop = false;
            // 
            // buttonHome
            // 
            this.buttonHome.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.buttonHome.FlatAppearance.BorderSize = 0;
            this.buttonHome.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonHome.ForeColor = System.Drawing.Color.White;
            this.buttonHome.Location = new System.Drawing.Point(0, 50);
            this.buttonHome.Name = "buttonHome";
            this.buttonHome.Size = new System.Drawing.Size(100, 36);
            this.buttonHome.TabIndex = 0;
            this.buttonHome.Text = "Home";
            this.buttonHome.UseVisualStyleBackColor = false;
            this.buttonHome.Click += new System.EventHandler(this.buttonHome_Click);
            // 
            // pictureBoxMenuBar
            // 
            this.pictureBoxMenuBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.pictureBoxMenuBar.Location = new System.Drawing.Point(100, 50);
            this.pictureBoxMenuBar.Name = "pictureBoxMenuBar";
            this.pictureBoxMenuBar.Size = new System.Drawing.Size(814, 36);
            this.pictureBoxMenuBar.TabIndex = 8;
            this.pictureBoxMenuBar.TabStop = false;
            // 
            // buttonSearch
            // 
            this.buttonSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSearch.Location = new System.Drawing.Point(821, 58);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(75, 20);
            this.buttonSearch.TabIndex = 10;
            this.buttonSearch.Text = "Zoeken";
            this.buttonSearch.UseVisualStyleBackColor = true;
            this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);
            // 
            // textBoxSearch
            // 
            this.textBoxSearch.Location = new System.Drawing.Point(682, 58);
            this.textBoxSearch.Name = "textBoxSearch";
            this.textBoxSearch.Size = new System.Drawing.Size(133, 20);
            this.textBoxSearch.TabIndex = 9;
            // 
            // menuStripUser
            // 
            this.menuStripUser.AutoSize = false;
            this.menuStripUser.BackColor = System.Drawing.Color.Transparent;
            this.menuStripUser.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStripUser.GripMargin = new System.Windows.Forms.Padding(2);
            this.menuStripUser.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this.menuStripUser.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.menuStripUser.Location = new System.Drawing.Point(738, 13);
            this.menuStripUser.Name = "menuStripUser";
            this.menuStripUser.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.menuStripUser.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.menuStripUser.Size = new System.Drawing.Size(161, 24);
            this.menuStripUser.Stretch = false;
            this.menuStripUser.TabIndex = 12;
            this.menuStripUser.Text = "menuStrip1";
            // 
            // ListViewActors
            // 
            this.ListViewActors.BackColor = System.Drawing.SystemColors.Window;
            this.ListViewActors.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ListViewActors.FullRowSelect = true;
            listViewItem1.StateImageIndex = 0;
            this.ListViewActors.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1});
            this.ListViewActors.Location = new System.Drawing.Point(12, 101);
            this.ListViewActors.MultiSelect = false;
            this.ListViewActors.Name = "ListViewActors";
            this.ListViewActors.Size = new System.Drawing.Size(884, 558);
            this.ListViewActors.TabIndex = 20;
            this.ListViewActors.UseCompatibleStateImageBehavior = false;
            this.ListViewActors.View = System.Windows.Forms.View.Details;
            this.ListViewActors.DoubleClick += new System.EventHandler(this.ListViewActors_DoubleClick);
            // 
            // menuStripDatabaseSelect
            // 
            this.menuStripDatabaseSelect.AutoSize = false;
            this.menuStripDatabaseSelect.BackColor = System.Drawing.Color.Transparent;
            this.menuStripDatabaseSelect.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStripDatabaseSelect.GripMargin = new System.Windows.Forms.Padding(2);
            this.menuStripDatabaseSelect.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this.menuStripDatabaseSelect.Location = new System.Drawing.Point(12, 13);
            this.menuStripDatabaseSelect.Name = "menuStripDatabaseSelect";
            this.menuStripDatabaseSelect.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.menuStripDatabaseSelect.Size = new System.Drawing.Size(120, 24);
            this.menuStripDatabaseSelect.Stretch = false;
            this.menuStripDatabaseSelect.TabIndex = 21;
            // 
            // comboBoxSearch
            // 
            this.comboBoxSearch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSearch.FormattingEnabled = true;
            this.comboBoxSearch.Location = new System.Drawing.Point(555, 58);
            this.comboBoxSearch.Name = "comboBoxSearch";
            this.comboBoxSearch.Size = new System.Drawing.Size(121, 21);
            this.comboBoxSearch.TabIndex = 22;
            this.comboBoxSearch.SelectionChangeCommitted += new System.EventHandler(this.comboBoxSearch_Click);
            // 
            // buttonManageAdd
            // 
            this.buttonManageAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.buttonManageAdd.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(24)))));
            this.buttonManageAdd.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(94)))));
            this.buttonManageAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonManageAdd.ForeColor = System.Drawing.Color.White;
            this.buttonManageAdd.Location = new System.Drawing.Point(8, 667);
            this.buttonManageAdd.Name = "buttonManageAdd";
            this.buttonManageAdd.Size = new System.Drawing.Size(155, 30);
            this.buttonManageAdd.TabIndex = 23;
            this.buttonManageAdd.Text = "Toevoegen";
            this.buttonManageAdd.UseVisualStyleBackColor = false;
            this.buttonManageAdd.Click += new System.EventHandler(this.buttonManageAdd_Click);
            // 
            // buttonManageEdit
            // 
            this.buttonManageEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.buttonManageEdit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(24)))));
            this.buttonManageEdit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(94)))));
            this.buttonManageEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonManageEdit.ForeColor = System.Drawing.Color.White;
            this.buttonManageEdit.Location = new System.Drawing.Point(745, 667);
            this.buttonManageEdit.Name = "buttonManageEdit";
            this.buttonManageEdit.Size = new System.Drawing.Size(155, 30);
            this.buttonManageEdit.TabIndex = 24;
            this.buttonManageEdit.Text = "Wijzigen";
            this.buttonManageEdit.UseVisualStyleBackColor = false;
            this.buttonManageEdit.Click += new System.EventHandler(this.buttonManageEdit_Click);
            // 
            // HomeScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(908, 739);
            this.Controls.Add(this.buttonManageEdit);
            this.Controls.Add(this.buttonManageAdd);
            this.Controls.Add(this.comboBoxSearch);
            this.Controls.Add(this.menuStripDatabaseSelect);
            this.Controls.Add(this.ListViewActors);
            this.Controls.Add(this.menuStripUser);
            this.Controls.Add(this.buttonSearch);
            this.Controls.Add(this.textBoxSearch);
            this.Controls.Add(this.pictureBoxMenuBar);
            this.Controls.Add(this.pictureBoxBottomBar);
            this.Controls.Add(this.pictureBoxHeader);
            this.Controls.Add(this.buttonHome);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStripUser;
            this.MaximizeBox = false;
            this.Name = "HomeScreen";
            this.Text = "HHS CRM";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.HomeScreen_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxHeader)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBottomBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMenuBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button buttonManage;
        private System.Windows.Forms.PictureBox pictureBoxHeader;
        private System.Windows.Forms.PictureBox pictureBoxBottomBar;
        private System.Windows.Forms.Button buttonHome;
        private System.Windows.Forms.PictureBox pictureBoxMenuBar;
        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.TextBox textBoxSearch;
        private System.Windows.Forms.MenuStrip menuStripUser;
        private System.Windows.Forms.ListView ListViewActors;
        private System.Windows.Forms.MenuStrip menuStripDatabaseSelect;
        private System.Windows.Forms.ComboBox comboBoxSearch;
        private System.Windows.Forms.Button buttonManageAdd;
        private System.Windows.Forms.Button buttonManageEdit;
    }
}