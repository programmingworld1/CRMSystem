namespace crm_systeem.Forms.Panels
{
    partial class PasswordChange
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
            this.buttonConfirmPasswordChange = new System.Windows.Forms.Button();
            this.buttonCancelPasswordChange = new System.Windows.Forms.Button();
            this.labelOldPassword = new System.Windows.Forms.Label();
            this.labelNewPassword = new System.Windows.Forms.Label();
            this.labelNewPassword02 = new System.Windows.Forms.Label();
            this.textBoxOldPassword = new System.Windows.Forms.TextBox();
            this.textBoxNewPassword = new System.Windows.Forms.TextBox();
            this.textBoxNewPassword02 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // buttonConfirmPasswordChange
            // 
            this.buttonConfirmPasswordChange.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.buttonConfirmPasswordChange.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(24)))));
            this.buttonConfirmPasswordChange.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(94)))));
            this.buttonConfirmPasswordChange.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonConfirmPasswordChange.ForeColor = System.Drawing.Color.White;
            this.buttonConfirmPasswordChange.Location = new System.Drawing.Point(8, 581);
            this.buttonConfirmPasswordChange.Name = "buttonConfirmPasswordChange";
            this.buttonConfirmPasswordChange.Size = new System.Drawing.Size(155, 30);
            this.buttonConfirmPasswordChange.TabIndex = 0;
            this.buttonConfirmPasswordChange.Text = "Bevestigen";
            this.buttonConfirmPasswordChange.UseVisualStyleBackColor = false;
            this.buttonConfirmPasswordChange.Click += new System.EventHandler(this.buttonConfirmPasswordChange_Click);
            // 
            // buttonCancelPasswordChange
            // 
            this.buttonCancelPasswordChange.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.buttonCancelPasswordChange.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(24)))));
            this.buttonCancelPasswordChange.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(94)))));
            this.buttonCancelPasswordChange.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCancelPasswordChange.ForeColor = System.Drawing.Color.White;
            this.buttonCancelPasswordChange.Location = new System.Drawing.Point(745, 581);
            this.buttonCancelPasswordChange.Name = "buttonCancelPasswordChange";
            this.buttonCancelPasswordChange.Size = new System.Drawing.Size(155, 30);
            this.buttonCancelPasswordChange.TabIndex = 1;
            this.buttonCancelPasswordChange.Text = "Annuleren";
            this.buttonCancelPasswordChange.UseVisualStyleBackColor = false;
            this.buttonCancelPasswordChange.Click += new System.EventHandler(this.buttonCancelPasswordChange_Click);
            // 
            // labelOldPassword
            // 
            this.labelOldPassword.AutoSize = true;
            this.labelOldPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelOldPassword.Location = new System.Drawing.Point(20, 20);
            this.labelOldPassword.Name = "labelOldPassword";
            this.labelOldPassword.Size = new System.Drawing.Size(233, 33);
            this.labelOldPassword.TabIndex = 2;
            this.labelOldPassword.Text = "Oud wachtwoord";
            // 
            // labelNewPassword
            // 
            this.labelNewPassword.AutoSize = true;
            this.labelNewPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNewPassword.Location = new System.Drawing.Point(20, 77);
            this.labelNewPassword.Name = "labelNewPassword";
            this.labelNewPassword.Size = new System.Drawing.Size(259, 33);
            this.labelNewPassword.TabIndex = 3;
            this.labelNewPassword.Text = "Nieuw wachtwoord";
            // 
            // labelNewPassword02
            // 
            this.labelNewPassword02.AutoSize = true;
            this.labelNewPassword02.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNewPassword02.Location = new System.Drawing.Point(20, 134);
            this.labelNewPassword02.Name = "labelNewPassword02";
            this.labelNewPassword02.Size = new System.Drawing.Size(290, 33);
            this.labelNewPassword02.TabIndex = 4;
            this.labelNewPassword02.Text = "Bevestig wachtwoord";
            // 
            // textBoxOldPassword
            // 
            this.textBoxOldPassword.BackColor = System.Drawing.Color.Olive;
            this.textBoxOldPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxOldPassword.Location = new System.Drawing.Point(370, 20);
            this.textBoxOldPassword.Name = "textBoxOldPassword";
            this.textBoxOldPassword.PasswordChar = '*';
            this.textBoxOldPassword.Size = new System.Drawing.Size(525, 40);
            this.textBoxOldPassword.TabIndex = 5;
            // 
            // textBoxNewPassword
            // 
            this.textBoxNewPassword.BackColor = System.Drawing.Color.Olive;
            this.textBoxNewPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxNewPassword.Location = new System.Drawing.Point(370, 77);
            this.textBoxNewPassword.Name = "textBoxNewPassword";
            this.textBoxNewPassword.PasswordChar = '*';
            this.textBoxNewPassword.Size = new System.Drawing.Size(525, 40);
            this.textBoxNewPassword.TabIndex = 6;
            // 
            // textBoxNewPassword02
            // 
            this.textBoxNewPassword02.BackColor = System.Drawing.Color.Olive;
            this.textBoxNewPassword02.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxNewPassword02.Location = new System.Drawing.Point(370, 134);
            this.textBoxNewPassword02.Name = "textBoxNewPassword02";
            this.textBoxNewPassword02.PasswordChar = '*';
            this.textBoxNewPassword02.Size = new System.Drawing.Size(525, 40);
            this.textBoxNewPassword02.TabIndex = 7;
            // 
            // PasswordChange
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.textBoxNewPassword02);
            this.Controls.Add(this.textBoxNewPassword);
            this.Controls.Add(this.textBoxOldPassword);
            this.Controls.Add(this.labelNewPassword02);
            this.Controls.Add(this.labelNewPassword);
            this.Controls.Add(this.labelOldPassword);
            this.Controls.Add(this.buttonCancelPasswordChange);
            this.Controls.Add(this.buttonConfirmPasswordChange);
            this.Name = "PasswordChange";
            this.Size = new System.Drawing.Size(908, 616);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonConfirmPasswordChange;
        private System.Windows.Forms.Button buttonCancelPasswordChange;
        private System.Windows.Forms.Label labelOldPassword;
        private System.Windows.Forms.Label labelNewPassword;
        private System.Windows.Forms.Label labelNewPassword02;
        private System.Windows.Forms.TextBox textBoxOldPassword;
        private System.Windows.Forms.TextBox textBoxNewPassword;
        private System.Windows.Forms.TextBox textBoxNewPassword02;
    }
}
