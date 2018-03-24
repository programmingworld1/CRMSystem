using System;
using crm_systeem.Models;
using crm_systeem.Database;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace crm_systeem.Forms.Panels
{
    public partial class ManageUser : UserControl
    {
        UserController UserDB = new UserController();
        List<User> UserList;
        List<Contactperson> ContactpersonList;
        List<ContactpersonPeriod> ContactpersonPeriodList;
        User UserToEdit;
        PasswordGeneration PasswordGeneration = new PasswordGeneration();
        int DeleteById;
        ListViewItem ListViewActors;
        string Manage;
        char[] letters = { '@', '/', '!', '#', '$', '%', '^', '&', '*', '(', ')', '-', '_', '|', ';', '<', '>', '.', ',' };
        public ManageUser(ref List<User> UserLists, ref List<Contactperson> ContactpersonLists, ref List<ContactpersonPeriod> ContactpersonPeriodLists, ListViewItem ListViewActor, string Manages)
        {
            Manage = Manages;
            UserList = UserLists;
            ContactpersonList = ContactpersonLists;
            ContactpersonPeriodList = ContactpersonPeriodLists;
            ListViewActors = ListViewActor;
            InitializeComponent();
            prepareScreen();
        }
        // Maakt het scherm klaar voor zowel het toevoegen als bewerken
        private void prepareScreen()
        {
            buttonUserConfirm.Text = Manage;
            if (Manage.Equals("Toevoegen"))
            {
                Controls.Remove(buttonUserDelete);
                Controls.Remove(buttonResetPassword);
            }
            else
            {
                foreach (var item in UserList)
                {
                    if (item.id.ToString() == ListViewActors.SubItems[0].Text)
                    {
                        UserToEdit = item;
                        textBoxUserName.Text = item.username;
                        textBoxUserFirstName.Text = item.firstname;
                        textBoxUserInsertion.Text = item.insertion;
                        textBoxUserLastName.Text = item.lastname;
                        textBoxUserEmail.Text = item.email;
                        comboBoxUserType.Text = item.type;
                    }
                }
            }
        }
        // Voert de uiteindelijke actie uit voor het toevoegen of bewerken
        private void buttonUserConfirm_Click(object sender, EventArgs e)
        {
            bool existUser = false;
            if (textBoxUserFirstName.Text.Any(char.IsDigit) || textBoxUserInsertion.Text.Any(char.IsDigit) || textBoxUserLastName.Text.Any(char.IsDigit) || textBoxUserName.Text.Equals("") || textBoxUserFirstName.Text.Equals("") || textBoxUserLastName.Text.Equals("") || textBoxUserEmail.Text.Equals("") || textBoxUserEmail.Text.IndexOf('@') == (-1) || textBoxUserEmail.Text.IndexOf('.') == -1 || comboBoxUserType.Text.Equals("") || textBoxUserFirstName.Text.IndexOfAny(letters) > 0 || textBoxUserInsertion.Text.IndexOfAny(letters) > 0 || textBoxUserLastName.Text.IndexOfAny(letters) > 0)
            {
                MessageBox.Show("Vul alle velden correct in aub (met uitsluiting van tussenvoegsel)");
            }
            else
            // Add functionality
            if (Manage.Equals("Toevoegen"))
            {
                Console.WriteLine("buttonUserConfirm_Click is clicked");
                foreach (var item in UserList)
                {
                    if (item.username.Equals(textBoxUserName.Text) || item.email.Equals(textBoxUserEmail.Text))
                    {
                        MessageBox.Show("Gebruikersnaam of E-mail bestaat al");
                        existUser = true;
                    }
                }
                if (existUser == false)
                {
                    User User = new User { username = textBoxUserName.Text, password = PasswordGeneration.GeneratePassword(), firstname = textBoxUserFirstName.Text, insertion = textBoxUserInsertion.Text, lastname = textBoxUserLastName.Text, email = textBoxUserEmail.Text, type = comboBoxUserType.SelectedItem.ToString() };
                    bool Transaction = UserDB.InsertUser(User);
                    if (Transaction == true)
                    {
                        User UserInserted = new User { id = UserDB.PrimaryKey, username = textBoxUserName.Text, password = User.password, firstname = textBoxUserFirstName.Text, insertion = textBoxUserInsertion.Text, lastname = textBoxUserLastName.Text, email = textBoxUserEmail.Text, type = comboBoxUserType.SelectedItem.ToString() };
                        UserList.Add(UserInserted);
                        EmailBot EmailBot = new EmailBot(User.username, User.password, User.email, "account");
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Het toevoegen is mislukt!");
                    }
                }
            }

            // Edit functionality
            else
            {
                foreach (var item in UserList)
                {
                    if (item.id != UserToEdit.id)
                    {
                        if (item.username.Equals(textBoxUserName.Text) || item.email.Equals(textBoxUserEmail.Text))
                        {
                            MessageBox.Show("Gebruikersnaam of E-mail bestaat al");
                            existUser = true;
                        }
                    }
                }
                if(existUser == false)
                {
                    UserToEdit.username = textBoxUserName.Text;
                    UserToEdit.firstname = textBoxUserFirstName.Text;
                    UserToEdit.insertion = textBoxUserInsertion.Text;
                    UserToEdit.lastname = textBoxUserLastName.Text;
                    UserToEdit.email = textBoxUserEmail.Text;
                    UserToEdit.type = comboBoxUserType.SelectedItem.ToString();

                    bool Transaction = UserDB.UpdateUser(UserToEdit);
                    if (Transaction == true)
                    {
                        foreach (var item in UserList)
                        {
                            if (UserToEdit.id == item.id)
                            {
                                item.username = UserToEdit.username;
                                item.firstname = UserToEdit.firstname;
                                item.insertion = UserToEdit.insertion;
                                item.lastname = UserToEdit.lastname;
                                item.email = UserToEdit.email;
                                item.type = UserToEdit.type;
                            }
                        }
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Het wijzigen is mislukt!");
                    }
                }
            }
        }
        // Voert de uiteindelijke actie uit voor het verwijderen
        private void buttonUserDelete_Click(object sender, EventArgs e)
        {
            bool Transaction = UserDB.DeleteUser(UserToEdit);
            if (Transaction == true)
            {
                for(int i = 0; i < ContactpersonList.Count; i++)
                {
                    if (UserToEdit.id == ContactpersonList[i].contact_hhs || UserToEdit.id == ContactpersonList[i].created_by)
                    {
                        for (int j = 0; j < ContactpersonPeriodList.Count; j++)
                        {
                            if (ContactpersonList[i].id == ContactpersonPeriodList[j].contactperson_id)
                            {
                                ContactpersonPeriodList.RemoveAt(j--);
                            }
                        }
                        ContactpersonList.RemoveAt(i--);
                    }
                }
                foreach (var item in UserList)
                {
                    if (item.id == UserToEdit.id)
                    {
                        DeleteById = UserList.IndexOf(item);

                    }
                }
                UserList.RemoveAt(DeleteById);
                this.Hide();
            }
            else
            {
                MessageBox.Show("Het verwijderen is mislukt!");
            }
        }
        // Voert de uiteindelijke actie uit voor het herstellen van iemands wachtwoord
        private void buttonResetPassword_Click(object sender, EventArgs e)
        {
            DialogResult resetPasswordbox = MessageBox.Show("Weet je zeker dat je voor deze gebruiker het wachtwoord wilt resetten?", "Wachtwoord resetten", MessageBoxButtons.YesNo);

            if (resetPasswordbox == DialogResult.Yes)
            {
                PasswordGeneration.GeneratePassword();
                bool Transaction = UserDB.ChangeUserPassword(UserToEdit);
                if(Transaction == true)
                {
                    EmailBot EmailBot = new EmailBot(UserToEdit.username, UserToEdit.password, UserToEdit.email, "password");
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Het wachtwoord resetten is mislukt!");
                }
            }
        }
        private void buttonUserReturn_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
