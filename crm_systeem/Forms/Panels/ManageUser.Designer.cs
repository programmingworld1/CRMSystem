namespace crm_systeem.Forms.Panels
{
    partial class ManageUser
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
            this.buttonUserConfirm = new System.Windows.Forms.Button();
            this.buttonUserReturn = new System.Windows.Forms.Button();
            this.buttonUserDelete = new System.Windows.Forms.Button();
            this.buttonResetPassword = new System.Windows.Forms.Button();
            this.labelUserName = new System.Windows.Forms.Label();
            this.labelUserFirstName = new System.Windows.Forms.Label();
            this.labelUserInsertion = new System.Windows.Forms.Label();
            this.labelUserLastName = new System.Windows.Forms.Label();
            this.labelUserEmail = new System.Windows.Forms.Label();
            this.labelUserType = new System.Windows.Forms.Label();
            this.textBoxUserName = new System.Windows.Forms.TextBox();
            this.textBoxUserFirstName = new System.Windows.Forms.TextBox();
            this.textBoxUserInsertion = new System.Windows.Forms.TextBox();
            this.textBoxUserLastName = new System.Windows.Forms.TextBox();
            this.textBoxUserEmail = new System.Windows.Forms.TextBox();
            this.comboBoxUserType = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // buttonUserConfirm
            // 
            this.buttonUserConfirm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.buttonUserConfirm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonUserConfirm.ForeColor = System.Drawing.Color.White;
            this.buttonUserConfirm.Location = new System.Drawing.Point(8, 581);
            this.buttonUserConfirm.Name = "buttonUserConfirm";
            this.buttonUserConfirm.Size = new System.Drawing.Size(155, 30);
            this.buttonUserConfirm.TabIndex = 0;
            this.buttonUserConfirm.UseVisualStyleBackColor = false;
            this.buttonUserConfirm.Click += new System.EventHandler(this.buttonUserConfirm_Click);
            // 
            // buttonUserReturn
            // 
            this.buttonUserReturn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.buttonUserReturn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonUserReturn.ForeColor = System.Drawing.Color.White;
            this.buttonUserReturn.Location = new System.Drawing.Point(745, 581);
            this.buttonUserReturn.Name = "buttonUserReturn";
            this.buttonUserReturn.Size = new System.Drawing.Size(155, 30);
            this.buttonUserReturn.TabIndex = 1;
            this.buttonUserReturn.Text = "Annuleren";
            this.buttonUserReturn.UseVisualStyleBackColor = false;
            this.buttonUserReturn.Click += new System.EventHandler(this.buttonUserReturn_Click);
            // 
            // buttonUserDelete
            // 
            this.buttonUserDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.buttonUserDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonUserDelete.ForeColor = System.Drawing.Color.White;
            this.buttonUserDelete.Location = new System.Drawing.Point(583, 581);
            this.buttonUserDelete.Name = "buttonUserDelete";
            this.buttonUserDelete.Size = new System.Drawing.Size(155, 30);
            this.buttonUserDelete.TabIndex = 2;
            this.buttonUserDelete.Text = "Verwijderen";
            this.buttonUserDelete.UseVisualStyleBackColor = false;
            this.buttonUserDelete.Click += new System.EventHandler(this.buttonUserDelete_Click);
            // 
            // buttonResetPassword
            // 
            this.buttonResetPassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.buttonResetPassword.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonResetPassword.ForeColor = System.Drawing.Color.White;
            this.buttonResetPassword.Location = new System.Drawing.Point(421, 581);
            this.buttonResetPassword.Name = "buttonResetPassword";
            this.buttonResetPassword.Size = new System.Drawing.Size(155, 30);
            this.buttonResetPassword.TabIndex = 3;
            this.buttonResetPassword.Text = "Reset wachtwoord";
            this.buttonResetPassword.UseVisualStyleBackColor = false;
            this.buttonResetPassword.Click += new System.EventHandler(this.buttonResetPassword_Click);
            // 
            // labelUserName
            // 
            this.labelUserName.AutoSize = true;
            this.labelUserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelUserName.Location = new System.Drawing.Point(5, 5);
            this.labelUserName.Name = "labelUserName";
            this.labelUserName.Size = new System.Drawing.Size(191, 29);
            this.labelUserName.TabIndex = 4;
            this.labelUserName.Text = "Gebruikersnaam";
            // 
            // labelUserFirstName
            // 
            this.labelUserFirstName.AutoSize = true;
            this.labelUserFirstName.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelUserFirstName.Location = new System.Drawing.Point(5, 50);
            this.labelUserFirstName.Name = "labelUserFirstName";
            this.labelUserFirstName.Size = new System.Drawing.Size(123, 29);
            this.labelUserFirstName.TabIndex = 5;
            this.labelUserFirstName.Text = "Voornaam";
            // 
            // labelUserInsertion
            // 
            this.labelUserInsertion.AutoSize = true;
            this.labelUserInsertion.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelUserInsertion.Location = new System.Drawing.Point(5, 95);
            this.labelUserInsertion.Name = "labelUserInsertion";
            this.labelUserInsertion.Size = new System.Drawing.Size(178, 29);
            this.labelUserInsertion.TabIndex = 6;
            this.labelUserInsertion.Text = "Tussenvoegsel";
            // 
            // labelUserLastName
            // 
            this.labelUserLastName.AutoSize = true;
            this.labelUserLastName.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelUserLastName.Location = new System.Drawing.Point(5, 140);
            this.labelUserLastName.Name = "labelUserLastName";
            this.labelUserLastName.Size = new System.Drawing.Size(140, 29);
            this.labelUserLastName.TabIndex = 7;
            this.labelUserLastName.Text = "Achternaam";
            // 
            // labelUserEmail
            // 
            this.labelUserEmail.AutoSize = true;
            this.labelUserEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelUserEmail.Location = new System.Drawing.Point(5, 185);
            this.labelUserEmail.Name = "labelUserEmail";
            this.labelUserEmail.Size = new System.Drawing.Size(135, 29);
            this.labelUserEmail.TabIndex = 8;
            this.labelUserEmail.Text = "Emailadres";
            // 
            // labelUserType
            // 
            this.labelUserType.AutoSize = true;
            this.labelUserType.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelUserType.Location = new System.Drawing.Point(5, 230);
            this.labelUserType.Name = "labelUserType";
            this.labelUserType.Size = new System.Drawing.Size(68, 29);
            this.labelUserType.TabIndex = 9;
            this.labelUserType.Text = "Type";
            // 
            // textBoxUserName
            // 
            this.textBoxUserName.BackColor = System.Drawing.Color.Olive;
            this.textBoxUserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxUserName.Location = new System.Drawing.Point(230, 5);
            this.textBoxUserName.Name = "textBoxUserName";
            this.textBoxUserName.Size = new System.Drawing.Size(674, 35);
            this.textBoxUserName.TabIndex = 10;
            // 
            // textBoxUserFirstName
            // 
            this.textBoxUserFirstName.BackColor = System.Drawing.Color.Olive;
            this.textBoxUserFirstName.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxUserFirstName.Location = new System.Drawing.Point(230, 50);
            this.textBoxUserFirstName.Name = "textBoxUserFirstName";
            this.textBoxUserFirstName.Size = new System.Drawing.Size(674, 35);
            this.textBoxUserFirstName.TabIndex = 11;
            // 
            // textBoxUserInsertion
            // 
            this.textBoxUserInsertion.BackColor = System.Drawing.Color.Olive;
            this.textBoxUserInsertion.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxUserInsertion.Location = new System.Drawing.Point(230, 95);
            this.textBoxUserInsertion.Name = "textBoxUserInsertion";
            this.textBoxUserInsertion.Size = new System.Drawing.Size(674, 35);
            this.textBoxUserInsertion.TabIndex = 12;
            // 
            // textBoxUserLastName
            // 
            this.textBoxUserLastName.BackColor = System.Drawing.Color.Olive;
            this.textBoxUserLastName.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxUserLastName.Location = new System.Drawing.Point(230, 140);
            this.textBoxUserLastName.Name = "textBoxUserLastName";
            this.textBoxUserLastName.Size = new System.Drawing.Size(674, 35);
            this.textBoxUserLastName.TabIndex = 13;
            // 
            // textBoxUserEmail
            // 
            this.textBoxUserEmail.BackColor = System.Drawing.Color.Olive;
            this.textBoxUserEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxUserEmail.Location = new System.Drawing.Point(230, 185);
            this.textBoxUserEmail.Name = "textBoxUserEmail";
            this.textBoxUserEmail.Size = new System.Drawing.Size(674, 35);
            this.textBoxUserEmail.TabIndex = 14;
            // 
            // comboBoxUserType
            // 
            this.comboBoxUserType.BackColor = System.Drawing.Color.Olive;
            this.comboBoxUserType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxUserType.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxUserType.FormattingEnabled = true;
            this.comboBoxUserType.Items.AddRange(new object[] {
            "Docent",
            "Student",
            "Beheerder"});
            this.comboBoxUserType.Location = new System.Drawing.Point(230, 230);
            this.comboBoxUserType.Name = "comboBoxUserType";
            this.comboBoxUserType.Size = new System.Drawing.Size(674, 37);
            this.comboBoxUserType.TabIndex = 15;
            // 
            // ManageUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.comboBoxUserType);
            this.Controls.Add(this.textBoxUserEmail);
            this.Controls.Add(this.textBoxUserLastName);
            this.Controls.Add(this.textBoxUserInsertion);
            this.Controls.Add(this.textBoxUserFirstName);
            this.Controls.Add(this.textBoxUserName);
            this.Controls.Add(this.labelUserType);
            this.Controls.Add(this.labelUserEmail);
            this.Controls.Add(this.labelUserLastName);
            this.Controls.Add(this.labelUserInsertion);
            this.Controls.Add(this.labelUserFirstName);
            this.Controls.Add(this.labelUserName);
            this.Controls.Add(this.buttonResetPassword);
            this.Controls.Add(this.buttonUserDelete);
            this.Controls.Add(this.buttonUserReturn);
            this.Controls.Add(this.buttonUserConfirm);
            this.Name = "ManageUser";
            this.Size = new System.Drawing.Size(908, 616);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonUserConfirm;
        private System.Windows.Forms.Button buttonUserReturn;
        private System.Windows.Forms.Button buttonUserDelete;
        private System.Windows.Forms.Button buttonResetPassword;
        private System.Windows.Forms.Label labelUserName;
        private System.Windows.Forms.Label labelUserFirstName;
        private System.Windows.Forms.Label labelUserInsertion;
        private System.Windows.Forms.Label labelUserLastName;
        private System.Windows.Forms.Label labelUserEmail;
        private System.Windows.Forms.Label labelUserType;
        private System.Windows.Forms.TextBox textBoxUserName;
        private System.Windows.Forms.TextBox textBoxUserFirstName;
        private System.Windows.Forms.TextBox textBoxUserInsertion;
        private System.Windows.Forms.TextBox textBoxUserLastName;
        private System.Windows.Forms.TextBox textBoxUserEmail;
        private System.Windows.Forms.ComboBox comboBoxUserType;
    }
}
