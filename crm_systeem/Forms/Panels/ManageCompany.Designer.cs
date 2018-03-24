namespace crm_systeem.Forms.Panels
{
    partial class ManageCompany
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonCompanyConfirm = new System.Windows.Forms.Button();
            this.buttonCompanyReturn = new System.Windows.Forms.Button();
            this.buttonCompanyDelete = new System.Windows.Forms.Button();
            this.labelCompanyName = new System.Windows.Forms.Label();
            this.labelCompanyAddress = new System.Windows.Forms.Label();
            this.labelCompanyInternship = new System.Windows.Forms.Label();
            this.labelCompanyInternshipDifferentiation = new System.Windows.Forms.Label();
            this.textBoxCompanyName = new System.Windows.Forms.TextBox();
            this.textBoxCompanyAddress = new System.Windows.Forms.TextBox();
            this.comboBoxCompanyInternship = new System.Windows.Forms.ComboBox();
            this.comboBoxCompanyInternshipDifferentiation = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // buttonCompanyConfirm
            // 
            this.buttonCompanyConfirm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.buttonCompanyConfirm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCompanyConfirm.ForeColor = System.Drawing.Color.White;
            this.buttonCompanyConfirm.Location = new System.Drawing.Point(8, 581);
            this.buttonCompanyConfirm.Name = "buttonCompanyConfirm";
            this.buttonCompanyConfirm.Size = new System.Drawing.Size(155, 30);
            this.buttonCompanyConfirm.TabIndex = 0;
            this.buttonCompanyConfirm.UseVisualStyleBackColor = false;
            this.buttonCompanyConfirm.Click += new System.EventHandler(this.buttonCompanyConfirm_Click);
            // 
            // buttonCompanyReturn
            // 
            this.buttonCompanyReturn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.buttonCompanyReturn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCompanyReturn.ForeColor = System.Drawing.Color.White;
            this.buttonCompanyReturn.Location = new System.Drawing.Point(745, 581);
            this.buttonCompanyReturn.Name = "buttonCompanyReturn";
            this.buttonCompanyReturn.Size = new System.Drawing.Size(155, 30);
            this.buttonCompanyReturn.TabIndex = 1;
            this.buttonCompanyReturn.Text = "Annuleren";
            this.buttonCompanyReturn.UseVisualStyleBackColor = false;
            this.buttonCompanyReturn.Click += new System.EventHandler(this.buttonCompanyReturn_Click);
            // 
            // buttonCompanyDelete
            // 
            this.buttonCompanyDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.buttonCompanyDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCompanyDelete.ForeColor = System.Drawing.Color.White;
            this.buttonCompanyDelete.Location = new System.Drawing.Point(583, 581);
            this.buttonCompanyDelete.Name = "buttonCompanyDelete";
            this.buttonCompanyDelete.Size = new System.Drawing.Size(155, 30);
            this.buttonCompanyDelete.TabIndex = 2;
            this.buttonCompanyDelete.Text = "Verwijderen";
            this.buttonCompanyDelete.UseVisualStyleBackColor = false;
            this.buttonCompanyDelete.Click += new System.EventHandler(this.buttonCompanyDelete_Click);
            // 
            // labelCompanyName
            // 
            this.labelCompanyName.AutoSize = true;
            this.labelCompanyName.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCompanyName.Location = new System.Drawing.Point(5, 5);
            this.labelCompanyName.Name = "labelCompanyName";
            this.labelCompanyName.Size = new System.Drawing.Size(154, 29);
            this.labelCompanyName.TabIndex = 3;
            this.labelCompanyName.Text = "Bedrijfsnaam";
            // 
            // labelCompanyAddress
            // 
            this.labelCompanyAddress.AutoSize = true;
            this.labelCompanyAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCompanyAddress.Location = new System.Drawing.Point(5, 50);
            this.labelCompanyAddress.Name = "labelCompanyAddress";
            this.labelCompanyAddress.Size = new System.Drawing.Size(76, 29);
            this.labelCompanyAddress.TabIndex = 4;
            this.labelCompanyAddress.Text = "Adres";
            // 
            // labelCompanyInternship
            // 
            this.labelCompanyInternship.AutoSize = true;
            this.labelCompanyInternship.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCompanyInternship.Location = new System.Drawing.Point(5, 95);
            this.labelCompanyInternship.Name = "labelCompanyInternship";
            this.labelCompanyInternship.Size = new System.Drawing.Size(136, 29);
            this.labelCompanyInternship.TabIndex = 5;
            this.labelCompanyInternship.Text = "Soort stage";
            // 
            // labelCompanyInternshipDifferentiation
            // 
            this.labelCompanyInternshipDifferentiation.AutoSize = true;
            this.labelCompanyInternshipDifferentiation.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCompanyInternshipDifferentiation.Location = new System.Drawing.Point(5, 140);
            this.labelCompanyInternshipDifferentiation.Name = "labelCompanyInternshipDifferentiation";
            this.labelCompanyInternshipDifferentiation.Size = new System.Drawing.Size(148, 29);
            this.labelCompanyInternshipDifferentiation.TabIndex = 6;
            this.labelCompanyInternshipDifferentiation.Text = "Differentiatie";
            // 
            // textBoxCompanyName
            // 
            this.textBoxCompanyName.BackColor = System.Drawing.Color.Olive;
            this.textBoxCompanyName.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxCompanyName.Location = new System.Drawing.Point(230, 5);
            this.textBoxCompanyName.Name = "textBoxCompanyName";
            this.textBoxCompanyName.Size = new System.Drawing.Size(674, 35);
            this.textBoxCompanyName.TabIndex = 7;
            // 
            // textBoxCompanyAddress
            // 
            this.textBoxCompanyAddress.BackColor = System.Drawing.Color.Olive;
            this.textBoxCompanyAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxCompanyAddress.Location = new System.Drawing.Point(230, 50);
            this.textBoxCompanyAddress.Name = "textBoxCompanyAddress";
            this.textBoxCompanyAddress.Size = new System.Drawing.Size(674, 35);
            this.textBoxCompanyAddress.TabIndex = 8;
            // 
            // comboBoxCompanyInternship
            // 
            this.comboBoxCompanyInternship.BackColor = System.Drawing.Color.Olive;
            this.comboBoxCompanyInternship.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCompanyInternship.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxCompanyInternship.FormattingEnabled = true;
            this.comboBoxCompanyInternship.Items.AddRange(new object[] {
            "Geen stage",
            "Stage",
            "Afstudeerstage",
            "Stage en Afstudeerstage"});
            this.comboBoxCompanyInternship.Location = new System.Drawing.Point(230, 95);
            this.comboBoxCompanyInternship.Name = "comboBoxCompanyInternship";
            this.comboBoxCompanyInternship.Size = new System.Drawing.Size(674, 37);
            this.comboBoxCompanyInternship.TabIndex = 9;
            this.comboBoxCompanyInternship.SelectionChangeCommitted += new System.EventHandler(this.comboBoxCompanyInternshipChange_Click);
            // 
            // comboBoxCompanyInternshipDifferentiation
            // 
            this.comboBoxCompanyInternshipDifferentiation.BackColor = System.Drawing.Color.Olive;
            this.comboBoxCompanyInternshipDifferentiation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCompanyInternshipDifferentiation.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxCompanyInternshipDifferentiation.FormattingEnabled = true;
            this.comboBoxCompanyInternshipDifferentiation.Items.AddRange(new object[] {
            "Geen stage",
            "ISM",
            "IMS",
            "B&M",
            "NSE",
            "SE"});
            this.comboBoxCompanyInternshipDifferentiation.Location = new System.Drawing.Point(230, 140);
            this.comboBoxCompanyInternshipDifferentiation.Name = "comboBoxCompanyInternshipDifferentiation";
            this.comboBoxCompanyInternshipDifferentiation.Size = new System.Drawing.Size(674, 37);
            this.comboBoxCompanyInternshipDifferentiation.TabIndex = 10;
            this.comboBoxCompanyInternshipDifferentiation.SelectionChangeCommitted += new System.EventHandler(this.comboBoxCompanyInternshipDifferentiationChange_Click);
            // 
            // ManageCompany
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.comboBoxCompanyInternshipDifferentiation);
            this.Controls.Add(this.comboBoxCompanyInternship);
            this.Controls.Add(this.textBoxCompanyAddress);
            this.Controls.Add(this.textBoxCompanyName);
            this.Controls.Add(this.labelCompanyInternshipDifferentiation);
            this.Controls.Add(this.labelCompanyInternship);
            this.Controls.Add(this.labelCompanyAddress);
            this.Controls.Add(this.labelCompanyName);
            this.Controls.Add(this.buttonCompanyDelete);
            this.Controls.Add(this.buttonCompanyReturn);
            this.Controls.Add(this.buttonCompanyConfirm);
            this.Name = "ManageCompany";
            this.Size = new System.Drawing.Size(908, 616);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonCompanyConfirm;
        private System.Windows.Forms.Button buttonCompanyReturn;
        private System.Windows.Forms.Button buttonCompanyDelete;
        private System.Windows.Forms.Label labelCompanyName;
        private System.Windows.Forms.Label labelCompanyAddress;
        private System.Windows.Forms.Label labelCompanyInternship;
        private System.Windows.Forms.Label labelCompanyInternshipDifferentiation;
        private System.Windows.Forms.TextBox textBoxCompanyName;
        private System.Windows.Forms.TextBox textBoxCompanyAddress;
        private System.Windows.Forms.ComboBox comboBoxCompanyInternship;
        private System.Windows.Forms.ComboBox comboBoxCompanyInternshipDifferentiation;
    }
}
