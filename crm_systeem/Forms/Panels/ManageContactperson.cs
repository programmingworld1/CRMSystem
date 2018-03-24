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
    public partial class ManageContactperson : UserControl
    {
        ContactpersonController ContactpersonDB = new ContactpersonController();
        List<Contactperson> ContactpersonList;
        List<ContactpersonPeriod> ContactpersonPeriodList;
        Contactperson ContactpersonToEdit;
        Dictionary<int, string> UserNames = new Dictionary<int, string>();
        Dictionary<int, string> CompanyNames = new Dictionary<int, string>();
        User ActivePerson;
        int DeleteById;
        ListViewItem ListViewActors;
        string Manage;
        char[] letters = { '@', '/', '!', '#', '$', '%', '^', '&', '*', '(', ')', '-', '_', '|', ';', '<', '>', '.', ',' };
        public ManageContactperson(ref List<User> UserList, ref List<Company> CompanyList, ref List<Contactperson> ContactpersonLists, ref List<ContactpersonPeriod> ContactpersonPeriodLists, User ActivePersons, ListViewItem ListViewActor, string Manages)
        {
            Manage = Manages;
            ListViewActors = ListViewActor;
            ActivePerson = ActivePersons;
            ContactpersonList = ContactpersonLists;
            ContactpersonPeriodList = ContactpersonPeriodLists;
            InitializeComponent();
            prepareScreen(ref UserList, ref CompanyList);
        }
        // Maakt het scherm klaar voor zowel het toevoegen als bewerken
        private void prepareScreen(ref List<User> UserList, ref List<Company> CompanyList)
        {
            buttonContactpersonConfirm.Text = Manage;
            foreach (var item in CompanyList)
            {
                CompanyNames.Add(item.id, item.name);
            }
            comboBoxContactpersonCompanyID.DataSource = new BindingSource(CompanyNames, null);
            comboBoxContactpersonCompanyID.ValueMember = "Key";
            comboBoxContactpersonCompanyID.DisplayMember = "Value";
            foreach (var item in UserList)
            {
                UserNames.Add(item.id, item.lastname + ", " + item.firstname[0] + ". " + item.insertion);
            }
            comboBoxContactpersonHHSContact.DataSource = new BindingSource(UserNames, null);
            comboBoxContactpersonHHSContact.ValueMember = "Key";
            comboBoxContactpersonHHSContact.DisplayMember = "Value";
            if (Manage.Equals("Toevoegen"))
            {
                Controls.Remove(buttonContactpersonDelete);
            }
            else
            {
                foreach (var item in ContactpersonList)
                {
                    if (item.id.ToString() == ListViewActors.SubItems[0].Text)
                    {
                        ContactpersonToEdit = item;
                        textBoxContactpersonFirstName.Text = item.firstname;
                        textBoxContactpersonInsertion.Text = item.insertion;
                        textBoxContactpersonLastName.Text = item.lastname;
                        textBoxContactpersonEmail.Text = item.email;
                        textBoxContactpersonPhonenumber.Text = item.phonenumber.ToString();
                        comboBoxContactpersonCompanyID.SelectedValue = item.company_id;
                        textBoxContactpersonFunction.Text = item.function;
                        comboBoxContactpersonNextTime.Text = item.next_time.ToString();
                        comboBoxContactpersonRating.Text = item.rating.ToString();
                        textBoxContactpersonComment.Text = item.comment;
                        comboBoxContactpersonHHSContact.SelectedValue = item.contact_hhs;
                    }
                }
            }
        }
        // Voert de uiteindelijke actie uit voor het toevoegen of bewerken
        private void buttonContactpersonConfirm_Click(object sender, EventArgs e)
        {
            bool existContactperson = false;
            if (textBoxContactpersonFirstName.Text.Any(char.IsDigit) || textBoxContactpersonInsertion.Text.Any(char.IsDigit) || textBoxContactpersonLastName.Text.Any(char.IsDigit) || !textBoxContactpersonPhonenumber.Text.All(char.IsDigit) || textBoxContactpersonFunction.Text.Any(char.IsDigit) || textBoxContactpersonFirstName.Text.IndexOfAny(letters) > 0 || textBoxContactpersonLastName.Text.IndexOfAny(letters) > 0 || textBoxContactpersonInsertion.Text.IndexOfAny(letters) > 0 || textBoxContactpersonFunction.Text.IndexOfAny(letters) > 0 || textBoxContactpersonFirstName.Text.Equals("") || textBoxContactpersonLastName.Text.Equals("") || textBoxContactpersonEmail.Text.Equals("") || textBoxContactpersonEmail.Text.IndexOf('@') == (-1) || textBoxContactpersonEmail.Text.IndexOf('.') == -1 || textBoxContactpersonPhonenumber.Text.Equals("") || textBoxContactpersonPhonenumber.Text.Length != 10 || comboBoxContactpersonCompanyID.Text.Equals("") || textBoxContactpersonFunction.Text.Equals("") || comboBoxContactpersonNextTime.Text.Equals("") || comboBoxContactpersonRating.Text.Equals("") || comboBoxContactpersonHHSContact.Text.Equals(""))
            {
                MessageBox.Show("Vul alle velden correct in aub (met uitsluiting van tussenvoegsel en commentaar)");
            }
            else
            // Add functionality
            if (Manage.Equals("Toevoegen"))
            {
                Console.WriteLine("buttonContactpersonConfirm_Click is clicked");
                foreach (var item in ContactpersonList)
                {
                    if (item.phonenumber.Equals(textBoxContactpersonPhonenumber.Text) || item.email.Equals(textBoxContactpersonEmail.Text))
                    {
                        existContactperson = true;
                        MessageBox.Show("E-mail of telefoonnummer bestaat al");
                    }
                }
                if(existContactperson == false)
                {
                    Contactperson Contactperson = new Contactperson { firstname = textBoxContactpersonFirstName.Text, insertion = textBoxContactpersonInsertion.Text, lastname = textBoxContactpersonLastName.Text, email = textBoxContactpersonEmail.Text, phonenumber = textBoxContactpersonPhonenumber.Text, company_id = Int32.Parse(comboBoxContactpersonCompanyID.SelectedValue.ToString()), function = textBoxContactpersonFunction.Text, next_time = comboBoxContactpersonNextTime.SelectedItem.ToString(), rating = comboBoxContactpersonRating.SelectedItem.ToString(), comment = textBoxContactpersonComment.Text, contact_hhs = Int32.Parse(comboBoxContactpersonHHSContact.SelectedValue.ToString()), created_by = ActivePerson.id };
                    bool Transaction = ContactpersonDB.InsertContactperson(Contactperson);
                    if (Transaction == true)
                    {
                        Contactperson ContactpersonInserted = new Contactperson { id = ContactpersonDB.PrimaryKey, firstname = textBoxContactpersonFirstName.Text, insertion = textBoxContactpersonInsertion.Text, lastname = textBoxContactpersonLastName.Text, email = textBoxContactpersonEmail.Text, phonenumber = textBoxContactpersonPhonenumber.Text, company_id = Int32.Parse(comboBoxContactpersonCompanyID.SelectedValue.ToString()), function = textBoxContactpersonFunction.Text, next_time = comboBoxContactpersonNextTime.SelectedItem.ToString(), rating = comboBoxContactpersonRating.SelectedItem.ToString(), comment = textBoxContactpersonComment.Text, contact_hhs = Int32.Parse(comboBoxContactpersonHHSContact.SelectedValue.ToString()), created_by = ActivePerson.id };
                        ContactpersonList.Add(ContactpersonInserted);
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
                foreach (var item in ContactpersonList)
                {
                    if (item.id != ContactpersonToEdit.id)
                    {
                        if (item.phonenumber.Equals(textBoxContactpersonPhonenumber.Text) || item.email.Equals(textBoxContactpersonEmail.Text))
                        {
                            existContactperson = true;
                            MessageBox.Show("E-mail of telefoonnummer bestaat al");
                        }
                    }
                }
                if(existContactperson == false)
                {
                    ContactpersonToEdit.firstname = textBoxContactpersonFirstName.Text;
                    ContactpersonToEdit.insertion = textBoxContactpersonInsertion.Text;
                    ContactpersonToEdit.lastname = textBoxContactpersonLastName.Text;
                    ContactpersonToEdit.email = textBoxContactpersonEmail.Text;
                    ContactpersonToEdit.phonenumber = textBoxContactpersonPhonenumber.Text;
                    ContactpersonToEdit.company_id = Int32.Parse(comboBoxContactpersonCompanyID.SelectedValue.ToString());
                    ContactpersonToEdit.function = textBoxContactpersonFunction.Text;
                    ContactpersonToEdit.next_time = comboBoxContactpersonNextTime.SelectedItem.ToString();
                    ContactpersonToEdit.rating = comboBoxContactpersonRating.SelectedItem.ToString();
                    ContactpersonToEdit.comment = textBoxContactpersonComment.Text;
                    ContactpersonToEdit.contact_hhs = Int32.Parse(comboBoxContactpersonHHSContact.SelectedValue.ToString());

                    bool Transaction = ContactpersonDB.UpdateContactperson(ContactpersonToEdit);
                    if (Transaction == true)
                    {
                        foreach (var item in ContactpersonList)
                        {
                            if (ContactpersonToEdit.id == item.id)
                            {
                                item.firstname = ContactpersonToEdit.firstname;
                                item.insertion = ContactpersonToEdit.insertion;
                                item.lastname = ContactpersonToEdit.lastname;
                                item.email = ContactpersonToEdit.email;
                                item.phonenumber = ContactpersonToEdit.phonenumber;
                                item.company_id = ContactpersonToEdit.company_id;
                                item.function = ContactpersonToEdit.function;
                                item.next_time = ContactpersonToEdit.next_time;
                                item.rating = ContactpersonToEdit.rating;
                                item.comment = ContactpersonToEdit.comment;
                                item.contact_hhs = ContactpersonToEdit.contact_hhs;
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
        private void buttonContactpersonDelete_Click(object sender, EventArgs e)
        {
            bool Transaction = ContactpersonDB.DeleteContactperson(ContactpersonToEdit);
            if (Transaction == true)
            {
                for (int i = 0; i < ContactpersonPeriodList.Count; i++)
                {
                    if (ContactpersonToEdit.id == ContactpersonPeriodList[i].contactperson_id)
                    {
                        ContactpersonList.RemoveAt(i--);
                    }
                }
                foreach (var item in ContactpersonList)
                {
                    if (item.id == ContactpersonToEdit.id)
                    {
                        DeleteById = ContactpersonList.IndexOf(item);

                    }
                }
                ContactpersonList.RemoveAt(DeleteById);
                this.Hide();
            }
            else
            {
                MessageBox.Show("Het verwijderen is mislukt!");
            }
        }
        private void buttonContactpersonReturn_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
