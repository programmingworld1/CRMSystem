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
    public partial class ManageCompany : UserControl
    {
        CompanyController CompanyDB = new CompanyController();
        List<Company> CompanyList;
        List<Contactperson> ContactpersonList;
        List<ContactpersonPeriod> ContactpersonPeriodList;
        Company CompanyToEdit;
        int DeleteById;
        ListViewItem ListViewActors;
        string Manage;
        char[] letters = { '@', '/', '!', '#', '$', '%', '^', '&', '*', '(', ')', '-', '_', '|', ';', '<', '>', '.', ',' };
        public ManageCompany(ref List<Company> CompanyLists, ref List<Contactperson> ContactpersonLists, ref List<ContactpersonPeriod> ContactpersonPeriodLists, ListViewItem ListViewActor, string Manages)
        {
            Manage = Manages;
            ListViewActors = ListViewActor;
            CompanyList = CompanyLists;
            ContactpersonList = ContactpersonLists;
            ContactpersonPeriodList = ContactpersonPeriodLists;
            InitializeComponent();
            prepareScreen();
        }
        // Maakt het scherm klaar voor zowel het toevoegen als bewerken
        private void prepareScreen()
        {
            buttonCompanyConfirm.Text = Manage;
            if (Manage.Equals("Toevoegen"))
            {
                Controls.Remove(buttonCompanyDelete);
            }
            else
            {
                foreach (var item in CompanyList)
                {
                    if (item.id.ToString() == ListViewActors.SubItems[0].Text)
                    {
                        CompanyToEdit = item;
                        textBoxCompanyName.Text = item.name;
                        textBoxCompanyAddress.Text = item.address;
                        comboBoxCompanyInternship.Text = item.internship;
                        comboBoxCompanyInternshipDifferentiation.Text = item.internship_differentiation;
                    }
                }
            }
        }
        // Zorgt ervoor dat je als je geen stage selecteert je ook geen differentiatie bij geen stage kan hebben
        private void comboBoxCompanyInternshipChange_Click(object sender, EventArgs e)
        {
            if (comboBoxCompanyInternship.SelectedItem.ToString().Equals("Geen stage"))
            {
                comboBoxCompanyInternshipDifferentiation.SelectedItem = "Geen stage";
                comboBoxCompanyInternshipDifferentiation.Enabled = false;
            }
            else
            {
                if (comboBoxCompanyInternshipDifferentiation.SelectedItem != null)
                {
                    if (comboBoxCompanyInternshipDifferentiation.SelectedItem.ToString().Equals("Geen stage"))
                    {
                        comboBoxCompanyInternshipDifferentiation.SelectedItem = null;
                    }
                }
                comboBoxCompanyInternshipDifferentiation.Enabled = true;
            }
        }
        // Zorgt ervoor als je geen stage selecteert dat er bij soort stage ook geen stage is geselecteerd
        private void comboBoxCompanyInternshipDifferentiationChange_Click(object sender, EventArgs e)
        {
            if (comboBoxCompanyInternshipDifferentiation.SelectedItem.ToString().Equals("Geen stage"))
            {
                comboBoxCompanyInternship.SelectedItem = "Geen stage";
                comboBoxCompanyInternshipDifferentiation.Enabled = false;
            }
            else
            {
                comboBoxCompanyInternshipDifferentiation.Enabled = true;
            }
        }
        // Voert de uiteindelijke actie uit voor het toevoegen of bewerken
        private void buttonCompanyConfirm_Click(object sender, EventArgs e)
        {
            bool existCompany = false;
            if (textBoxCompanyName.Text.Equals("") || textBoxCompanyAddress.Text.Equals("") || comboBoxCompanyInternship.Text.Equals("") || comboBoxCompanyInternshipDifferentiation.Text.Equals("") || textBoxCompanyAddress.Text.IndexOfAny(letters) > 0)
            {
                MessageBox.Show("Vul alle velden correct in aub");
            }
            else
            // Add functionality
            if (Manage.Equals("Toevoegen"))
            {
                Console.WriteLine("buttonCompanyConfirm_Click is clicked");
                foreach (var item in CompanyList)
                {
                    if (item.name.Equals(textBoxCompanyName.Text) || item.address.Equals(textBoxCompanyAddress.Text))
                    {
                        existCompany = true;
                        MessageBox.Show("Bedrijfsnaam of Adres bestaat al");
                    }
                }
                if(existCompany == false)
                {
                    Company Company = new Company { name = textBoxCompanyName.Text, address = textBoxCompanyAddress.Text, internship = comboBoxCompanyInternship.SelectedItem.ToString(), internship_differentiation = comboBoxCompanyInternshipDifferentiation.SelectedItem.ToString() };
                    bool Transaction = CompanyDB.InsertCompany(Company);
                    if (Transaction == true)
                    {
                        Company CompanyInserted = new Company { id = CompanyDB.PrimaryKey, name = textBoxCompanyName.Text, address = textBoxCompanyAddress.Text, internship = comboBoxCompanyInternship.SelectedItem.ToString(), internship_differentiation = comboBoxCompanyInternshipDifferentiation.SelectedItem.ToString() };
                        CompanyList.Add(CompanyInserted);
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
                foreach (var item in CompanyList)
                {
                    if (item.id != CompanyToEdit.id)
                    {
                        if (item.name.Equals(textBoxCompanyName.Text) || item.address.Equals(textBoxCompanyAddress.Text))
                        {
                            existCompany = true;
                            MessageBox.Show("Bedrijfsnaam of Adres bestaat al");
                        }
                    }
                }
                if(existCompany == false)
                {
                    CompanyToEdit.name = textBoxCompanyName.Text;
                    CompanyToEdit.address = textBoxCompanyAddress.Text;
                    CompanyToEdit.internship = comboBoxCompanyInternship.SelectedItem.ToString();
                    CompanyToEdit.internship_differentiation = comboBoxCompanyInternshipDifferentiation.SelectedItem.ToString();

                    bool Transaction = CompanyDB.UpdateCompany(CompanyToEdit);
                    if (Transaction == true)
                    {
                        foreach (var item in CompanyList)
                        {
                            if (CompanyToEdit.id == item.id)
                            {
                                item.name = CompanyToEdit.name;
                                item.address = CompanyToEdit.address;
                                item.internship = CompanyToEdit.internship;
                                item.internship_differentiation = CompanyToEdit.internship_differentiation;
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
        private void buttonCompanyDelete_Click(object sender, EventArgs e)
        {
            bool Transaction = CompanyDB.DeleteCompany(CompanyToEdit);
            if (Transaction == true)
            {
                for (int i = 0; i < ContactpersonList.Count; i++)
                {
                    if (CompanyToEdit.id == ContactpersonList[i].company_id)
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
                foreach (var item in CompanyList)
                {
                    if (item.id == CompanyToEdit.id)
                    {
                        DeleteById = CompanyList.IndexOf(item);

                    }
                }
                CompanyList.RemoveAt(DeleteById);
                this.Hide();
            }
            else
            {
                MessageBox.Show("Het verwijderen is mislukt!");
            }
        }
        private void buttonCompanyReturn_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
