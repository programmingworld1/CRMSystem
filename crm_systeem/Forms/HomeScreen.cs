using crm_systeem.Database;
using crm_systeem.Forms;
using crm_systeem.Models;
using crm_systeem.Forms.Panels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace crm_systeem
{
    public enum tableToDisplay
    {
        user,
        contactperson,
        company,
        contactperson_period
    }

    public partial class HomeScreen : Form
    {
        // De controllers waarmee de queries worden gedaan
        UserController UserDB = new UserController();
        CompanyController CompanyDB = new CompanyController();
        ContactpersonController ContactpersonDB = new ContactpersonController();
        ContactpersonPeriodController ContactpersonPeriodDB = new ContactpersonPeriodController();
        PeriodController PeriodDB = new PeriodController();

        // De lijsten die van de DB worden gemaakt
        List<User> UserList = new List<User>();
        List<Company> CompanyList = new List<Company>();
        List<Contactperson> ContactpersonList = new List<Contactperson>();
        List<ContactpersonPeriod> ContactpersonPeriodList = new List<ContactpersonPeriod>();
        List<Period> PeriodList = new List<Period>();

        // Een object die na het inloggen de gegevens bevat van de ingelogde persoon
        User ActivePerson;
        bool firstTime = false;
        // Bepaalt of je in het beheerders of het zoekgedeelte zit in het systeem
        bool isManage = false;
        tableToDisplay CurrentChoice;
        /// <summary>
        /// Laat je allemaal verschillende lijsten zien met gegevens uit de database over het crm systeem
        /// </summary>
        /// <param name="UserList"></param>
        private void PopulateList(tableToDisplay choice)
        {
            ListViewActors.Clear();
            CurrentChoice = choice;
            comboBoxSearch.Items.Clear();
            isManaging();
            // Laat de user tab zien
            if (choice == tableToDisplay.user)
            {
                comboBoxSearch.Items.Add("Weergeef Alles");
                comboBoxSearch.Items.Add("Gebruikersnaam");
                comboBoxSearch.Items.Add("Voornaam");
                comboBoxSearch.Items.Add("Volledige Achternaam");
                comboBoxSearch.Items.Add("Type");
                comboBoxSearch.SelectedItem = "Weergeef Alles";
                textBoxSearch.Enabled = false;
                // Voeg de columns toe
                ListViewActors.Columns.Add("ID");
                ListViewActors.Columns.Add("Gebruikersnaam");
                ListViewActors.Columns.Add("Voornaam");
                ListViewActors.Columns.Add("Tussenvoegsel");
                ListViewActors.Columns.Add("Achternaam");
                ListViewActors.Columns.Add("Type");
                ListViewActors.Columns.Add("Emailadres");

                foreach (var item in UserList)
                {
                    ListViewItem ListViewItem = new ListViewItem(item.id.ToString());
                    ListViewItem.SubItems.Add(item.username);
                    ListViewItem.SubItems.Add(item.firstname);
                    ListViewItem.SubItems.Add(item.insertion);
                    ListViewItem.SubItems.Add(item.lastname);
                    ListViewItem.SubItems.Add(item.type);
                    ListViewItem.SubItems.Add(item.email);
                    ListViewActors.Items.Add(ListViewItem);
                }
                if (isManage == false)
                {
                    ListViewActors.Columns.RemoveAt(0);
                }
            }
            // Laat de company table zien
            else if (choice == tableToDisplay.contactperson)
            {
                comboBoxSearch.Items.Add("Weergeef Alles");
                comboBoxSearch.Items.Add("Voornaam");
                comboBoxSearch.Items.Add("Volledige Achternaam");
                if (isManage == false)
                {
                    comboBoxSearch.Items.Add("Bedrijfsnaam");
                }
                comboBoxSearch.SelectedItem = "Weergeef Alles";
                textBoxSearch.Enabled = false;

                // Voeg de columns toe
                ListViewActors.Columns.Add("ID");
                ListViewActors.Columns.Add("Voornaam");
                ListViewActors.Columns.Add("Tussenvoegsel");
                ListViewActors.Columns.Add("Achternaam");
                ListViewActors.Columns.Add("Emailadres");
                ListViewActors.Columns.Add("Telefoonnummer");
                ListViewActors.Columns.Add("Bedrijfsnaam");
                ListViewActors.Columns.Add("Functie");
                ListViewActors.Columns.Add("Volgende keer");
                ListViewActors.Columns.Add("HHS Contact");
                ListViewActors.Columns.Add("Gemaakt door");

                // Voeg de data van ListViewActors toe (De columns die docent mag zien)
                foreach (var item in ContactpersonList)
                {
                    ListViewItem ListViewItem = new ListViewItem(item.id.ToString());
                    ListViewItem.SubItems.Add(item.firstname);
                    ListViewItem.SubItems.Add(item.insertion);
                    ListViewItem.SubItems.Add(item.lastname);
                    ListViewItem.SubItems.Add(item.email);
                    ListViewItem.SubItems.Add(item.phonenumber.ToString());
                    foreach (var company in CompanyList)
                    {
                        if (item.company_id == company.id)
                        {
                            ListViewItem.SubItems.Add(company.name);
                        }
                    }
                    ListViewItem.SubItems.Add(item.function);
                    ListViewItem.SubItems.Add(item.next_time);
                    foreach (var user in UserList)
                    {
                        if (item.contact_hhs == user.id)
                        {
                            ListViewItem.SubItems.Add(user.lastname + ", " + user.firstname[0] + ". " + user.insertion);
                        }
                    }
                    foreach (var user in UserList)
                    {
                        if (item.created_by == user.id)
                        {
                            ListViewItem.SubItems.Add(user.lastname + ", " + user.firstname[0] + ". " + user.insertion);
                        }
                    }
                    ListViewActors.Items.Add(ListViewItem);
                }
                if (isManage == false)
                {
                    ListViewActors.Columns.RemoveAt(0);
                }
            }

            // Laat de contactperson table zien
            else if (choice == tableToDisplay.company)
            {
                comboBoxSearch.Items.Add("Weergeef Alles");
                comboBoxSearch.Items.Add("Stage");
                comboBoxSearch.Items.Add("Afstudeerstage");
                comboBoxSearch.Items.Add("Stage en Afstudeerstage");
                comboBoxSearch.SelectedItem = "Weergeef Alles";
                textBoxSearch.Enabled = false;

                ListViewActors.Columns.Add("ID");
                ListViewActors.Columns.Add("Bedrijfsnaam");
                ListViewActors.Columns.Add("Adres");
                ListViewActors.Columns.Add("Soort stage");
                ListViewActors.Columns.Add("Differentiatie");
                ListViewActors.Columns.Add("Contactpersoon");
                ListViewActors.Columns.Add("Email");
                ListViewActors.Columns.Add("HHS Contact");
                ListViewActors.Columns.Add("HHS Email");

                // Voeg de data van listViewUsers toe (De columns die docent mag zien)
                foreach (var item in CompanyList)
                {
                    ListViewItem ListViewItem = new ListViewItem(item.id.ToString());
                    ListViewItem.SubItems.Add(item.name);
                    ListViewItem.SubItems.Add(item.address);
                    ListViewItem.SubItems.Add(item.internship);
                    ListViewItem.SubItems.Add(item.internship_differentiation);
                    foreach (var contactperson in ContactpersonList)
                    {
                        if (item.id == contactperson.company_id)
                        {
                            ListViewItem.SubItems.Add(contactperson.lastname + ", " + contactperson.firstname[0] + ". " + contactperson.insertion);
                            ListViewItem.SubItems.Add(contactperson.email);
                            foreach (var user in UserList)
                            {
                                ListViewItem.SubItems.Add(user.lastname + ", " + user.firstname[0] + ". " + user.insertion);
                                ListViewItem.SubItems.Add(user.email);
                            }
                        }
                    }
                    if (firstTime == false)
                    {
                        ListViewItem.SubItems.RemoveAt(0);
                    }
                    ListViewActors.Items.Add(ListViewItem);
                }
                if (isManage == false)
                {
                    firstTime = true;
                    ListViewActors.Columns.RemoveAt(0);
                }
                else
                {
                    ListViewActors.Columns.RemoveAt(8);
                    ListViewActors.Columns.RemoveAt(7);
                    ListViewActors.Columns.RemoveAt(6);
                    ListViewActors.Columns.RemoveAt(5);
                }
            }
            else if (choice == tableToDisplay.contactperson_period)
            {
                comboBoxSearch.Items.Add("Weergeef Alles");
                comboBoxSearch.Items.Add("Periode");
                comboBoxSearch.Items.Add("Differentiatie");
                comboBoxSearch.Items.Add("Jaar");
                comboBoxSearch.SelectedItem = "Weergeef Alles";
                textBoxSearch.Enabled = false;

                // Voeg de columns toe
                ListViewActors.Columns.Add("Periode");
                ListViewActors.Columns.Add("Contactpersoon");
                ListViewActors.Columns.Add("Differentiatie");
                ListViewActors.Columns.Add("Jaar");
                ListViewActors.Columns.Add("Geholpen met");

                // Voeg de data van ListViewActors toe (De columns die docent mag zien)
                foreach (var item in ContactpersonPeriodList)
                {
                    ListViewItem ListViewItem = new ListViewItem(item.period_name);
                    if (isManage == true)
                    {
                        ListViewItem.SubItems.Add(item.contactperson_id.ToString());
                    }
                    else
                    {
                        foreach (var contactperson in ContactpersonList)
                        {
                            if (item.contactperson_id == contactperson.id)
                            {
                                ListViewItem.SubItems.Add(contactperson.lastname + ", " + contactperson.firstname[0] + ". " + contactperson.insertion);
                            }
                        }
                    }
                    ListViewItem.SubItems.Add(item.differentiation);
                    ListViewItem.SubItems.Add(item.year.ToString());
                    ListViewItem.SubItems.Add(item.helped_with);
                    ListViewActors.Items.Add(ListViewItem);
                }
            }
            ListViewActors.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            ListViewActors.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }
        // Bekijkt of iemand op het beheerders gedeelte is om bepaalde knoppen te weergeven
        private void isManaging()
        {
            if(isManage == true)
            {
                Controls.Add(buttonManageAdd);
                Controls.Add(buttonManageEdit);
                buttonManageEdit.Text = "Wijzigen";
                if (CurrentChoice == tableToDisplay.contactperson_period)
                {
                    buttonManageEdit.Text = "Verwijderen";
                }
            }
            else
            {
                Controls.Remove(buttonManageAdd);
                Controls.Remove(buttonManageEdit);
            }
        }
        private void ListViewActors_DoubleClick(object sender, EventArgs e)
        {
            if (CurrentChoice == tableToDisplay.contactperson)
            {
                string contactpersonName = "";
                string contactpersonRating = "";
                string contactpersonComment = "";

                foreach (var item in ContactpersonList)
                {
                    if (item.id == Int32.Parse(ListViewActors.FocusedItem.Text))//(item.id.ToString().Equals(ListViewActors.FocusedItem))
                    {
                        contactpersonName = item.firstname;
                        contactpersonRating = item.rating;
                        contactpersonComment = item.comment;
                    }
                }
                MessageBox.Show("Dit is de beoordeling van " + contactpersonName + ".\n" + contactpersonName + " heeft momenteel de beoordeling \"" + contactpersonRating + "\".\nCommentaar bij " + contactpersonName + ": " + contactpersonComment, "Beoordeling contactpersoon");
            }
        }
        /// <summary>
        /// Maak van het Login object een User object die alle gegevens van het account bevat
        /// </summary>
        /// <param name="Login">Het Login object waarmee is ingelogd</param>
        private void SelectUser(Login Login)
        {
            foreach (var item in UserList)
            {
                if (Login.username == item.username)
                {
                    ActivePerson = item;
                }
            }
        }
        #region GUI elements for ToolStripMenu
        ToolStripMenuItem ToolStripMenuDatabaseSelect = new ToolStripMenuItem("Maak een keuze");
        #endregion
        // Zorgt voor de knoppen in het systeem waar bepaalde permissions voor gelden
        private void CreateGuiElements()
        {
            #region Menustrip
            ToolStripMenuItem ToolStripMenuUser = new ToolStripMenuItem(ActivePerson.lastname + ", " + ActivePerson.firstname[0] + ". " + ActivePerson.insertion);
            if (ActivePerson.type == "Beheerder" || ActivePerson.type == "Docent")
            {
                ToolStripMenuUser.DropDownItems.Add("Wijzig wachtwoord");
                ToolStripMenuUser.DropDownItems[0].Click += ChangePassword_Click;
                ToolStripMenuUser.DropDownItems.Add("Logout");
                ToolStripMenuUser.DropDownItems[1].Click += Signout_Click;
            }
            else
            {
                ToolStripMenuUser.DropDownItems.Add("Logout");
                ToolStripMenuUser.DropDownItems[0].Click += Signout_Click;
            }
            menuStripUser.Items.Add(ToolStripMenuUser);
            menuStripUser.Parent = pictureBoxHeader;

            if (ActivePerson.type == "Beheerder" || ActivePerson.type == "Docent")
            {
                ToolStripMenuDatabaseSelect.DropDownItems.Add("Contactpersonen");
                ToolStripMenuDatabaseSelect.DropDownItems[0].Click += menuStripDatabaseContactperson_Click;
                ToolStripMenuDatabaseSelect.DropDownItems.Add("Perioden");
                ToolStripMenuDatabaseSelect.DropDownItems[1].Click += menuStripDatabasePeriod_Click;
                ToolStripMenuDatabaseSelect.DropDownItems.Add("Bedrijven");
                ToolStripMenuDatabaseSelect.DropDownItems[2].Click += menuStripDatabaseCompany_Click;
                if (ActivePerson.type == "Beheerder")
                {
                    ToolStripMenuDatabaseSelect.DropDownItems.Add("Gebruikers");
                    ToolStripMenuDatabaseSelect.DropDownItems[3].Click += menuStripDatabaseUser_Click;
                }
            }
            else if (ActivePerson.type == "Student")
            {
                ToolStripMenuDatabaseSelect.DropDownItems.Add("Bedrijven");
                ToolStripMenuDatabaseSelect.DropDownItems[0].Click += menuStripDatabaseCompany_Click;
            }
            menuStripDatabaseSelect.Items.Add(ToolStripMenuDatabaseSelect);
            menuStripDatabaseSelect.Parent = pictureBoxHeader;
            #endregion

            #region Buttons Menu
            if (ActivePerson.type == "Beheerder" || ActivePerson.type == "Docent")
            {
                Controls.Add(buttonManage);
                pictureBoxMenuBar.Location = new Point(200, 50);
            }
            #endregion
        }
        private void comboBoxSearch_Click(object sender, EventArgs e)
        {
            if (comboBoxSearch.SelectedItem.ToString().Equals("Weergeef Alles"))
            {
                textBoxSearch.Text = "";
                textBoxSearch.Enabled = false;
            }
            else
            {
                textBoxSearch.Enabled = true;
            }
        }
        private void ChangePassword_Click(object sender, EventArgs e)
        {
            PasswordChange PasswordChange = new PasswordChange(ActivePerson);
            PasswordChange.Size = new Size(908, 616);
            PasswordChange.Location =  new Point(0, 86);
            this.Controls.Add(PasswordChange);
            PasswordChange.BringToFront();
        }
        private void Signout_Click(object sender, EventArgs e)
        {
            this.Hide();
            UserList = null;
            LoginScreen LoginScreen = new LoginScreen();
            LoginScreen.Show();
        }
        private void HomeScreen_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
        public HomeScreen(Login Login)
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;

            // Pak de gegevens uit de DB en maak er lijsten van
            UserList = UserDB.GetUserList();
            CompanyList = CompanyDB.GetCompanyList();
            ContactpersonList = ContactpersonDB.GetContactpersonList();
            ContactpersonPeriodList = ContactpersonPeriodDB.GetContactpersonPeriodList();
            PeriodList = PeriodDB.GetPeriodList();

            // Maak van een "Login" object een "User", "Student" of "Teacher" object en haal de gegevens op van de persoon die ingelogd is.
            SelectUser(Login);
            // Maakt de listview op voor het begin
            PopulateList(tableToDisplay.company);
            // Maakt bepaalde knoppen met permissions voor docenten en beheerders
            CreateGuiElements();
        }
        private void menuStripDatabaseUser_Click(object sender, EventArgs e)
        {
            textBoxSearch.Text = null;
            PopulateList(tableToDisplay.user);
        }
        private void menuStripDatabaseCompany_Click(object sender, EventArgs e)
        {
            textBoxSearch.Text = null;
            PopulateList(tableToDisplay.company);
        }
        private void menuStripDatabaseContactperson_Click(object sender, EventArgs e)
        {
            textBoxSearch.Text = null;
            PopulateList(tableToDisplay.contactperson);
        }
        private void menuStripDatabasePeriod_Click(object sender, EventArgs e)
        {
            textBoxSearch.Text = null;
            PopulateList(tableToDisplay.contactperson_period);
        }
        // Gaat naar het zoekgedeelte van het systeem
        private void buttonSearch_Click(object sender, EventArgs e)
        {
            Search Search = new Search(ListViewActors, isManage);
            Search.SearchItems(CurrentChoice, comboBoxSearch.SelectedItem.ToString(), textBoxSearch.Text, UserList, CompanyList, ContactpersonList, ContactpersonPeriodList, PeriodList);
        }
        private void buttonHome_Click(object sender, EventArgs e)
        {
            isManage = false;
            if (CurrentChoice == tableToDisplay.company)
            {
                PopulateList(tableToDisplay.company);
            }
            else if (CurrentChoice == tableToDisplay.user)
            {
                PopulateList(tableToDisplay.user);
            }
            else if (CurrentChoice == tableToDisplay.contactperson)
            {
                PopulateList(tableToDisplay.contactperson);
            }
            else if (CurrentChoice == tableToDisplay.contactperson_period)
            {
                PopulateList(tableToDisplay.contactperson_period);
            }
        }
        private void buttonManage_Click(object sender, EventArgs e)
        {
            isManage = true;
            if (CurrentChoice == tableToDisplay.company)
            {
                PopulateList(tableToDisplay.company);
            }
            else if (CurrentChoice == tableToDisplay.user)
            {
                PopulateList(tableToDisplay.user);
            }
            else if (CurrentChoice == tableToDisplay.contactperson)
            {
                PopulateList(tableToDisplay.contactperson);
            }
            else if (CurrentChoice == tableToDisplay.contactperson_period)
            {
                PopulateList(tableToDisplay.contactperson_period);
            }
        }
        // Gaat naar de usercontrols voor het toevoegen van data
        private void buttonManageAdd_Click(object sender, EventArgs e)
        {
            if (CurrentChoice == tableToDisplay.company)
            {
                ManageCompany ManageCompany = new ManageCompany(ref CompanyList, ref ContactpersonList, ref ContactpersonPeriodList, ListViewActors.FocusedItem, "Toevoegen");
                ManageCompany.Size = new Size(908, 616);
                ManageCompany.Location = new Point(0, 86);
                this.Controls.Add(ManageCompany);
                ManageCompany.BringToFront();
            }
            else if (CurrentChoice == tableToDisplay.user)
            {
                ManageUser ManageUser = new ManageUser(ref UserList, ref ContactpersonList, ref ContactpersonPeriodList, ListViewActors.FocusedItem, "Toevoegen");
                ManageUser.Size = new Size(908, 616);
                ManageUser.Location = new Point(0, 86);
                this.Controls.Add(ManageUser);
                ManageUser.BringToFront();
            }
            else if (CurrentChoice == tableToDisplay.contactperson)
            {
                ManageContactperson ManageContactperson = new ManageContactperson(ref UserList, ref CompanyList, ref ContactpersonList, ref ContactpersonPeriodList, ActivePerson, ListViewActors.FocusedItem, "Toevoegen");
                ManageContactperson.Size = new Size(908, 616);
                ManageContactperson.Location = new Point(0, 86);
                this.Controls.Add(ManageContactperson);
                ManageContactperson.BringToFront();
            }
            else if (CurrentChoice == tableToDisplay.contactperson_period)
            {
                ManageContactpersonPeriod ManageContactpersonPeriod = new ManageContactpersonPeriod(ref ContactpersonPeriodList, ref ContactpersonList, ref PeriodList, ListViewActors.FocusedItem);
                ManageContactpersonPeriod.Size = new Size(908, 616);
                ManageContactpersonPeriod.Location = new Point(0, 86);
                this.Controls.Add(ManageContactpersonPeriod);
                ManageContactpersonPeriod.BringToFront();
            }
        }
        // Gaat naar de usercontrols voor het bewerken/verwijderen van data
        private void buttonManageEdit_Click(object sender, EventArgs e)
        {
            if (ListViewActors.FocusedItem != null)
            {
                if (CurrentChoice == tableToDisplay.company)
                {
                    ManageCompany ManageCompany = new ManageCompany(ref CompanyList, ref ContactpersonList, ref ContactpersonPeriodList, ListViewActors.FocusedItem, "Wijzigen");
                    ManageCompany.Size = new Size(908, 616);
                    ManageCompany.Location = new Point(0, 86);
                    this.Controls.Add(ManageCompany);
                    ManageCompany.BringToFront();
                }
                else if (CurrentChoice == tableToDisplay.user)
                {
                    ManageUser ManageUser = new ManageUser(ref UserList, ref ContactpersonList, ref ContactpersonPeriodList,ListViewActors.FocusedItem, "Wijzigen");
                    ManageUser.Size = new Size(908, 616);
                    ManageUser.Location = new Point(0, 86);
                    this.Controls.Add(ManageUser);
                    ManageUser.BringToFront();
                }
                else if (CurrentChoice == tableToDisplay.contactperson)
                {
                    ManageContactperson ManageContactperson = new ManageContactperson(ref UserList, ref CompanyList, ref ContactpersonList, ref ContactpersonPeriodList, ActivePerson, ListViewActors.FocusedItem, "Wijzigen");
                    ManageContactperson.Size = new Size(908, 616);
                    ManageContactperson.Location = new Point(0, 86);
                    this.Controls.Add(ManageContactperson);
                    ManageContactperson.BringToFront();
                }
                else if (CurrentChoice == tableToDisplay.contactperson_period)
                {
                    ManageContactpersonPeriod ManageContactpersonPeriod = new ManageContactpersonPeriod(ref ContactpersonPeriodList, ref ContactpersonList, ref PeriodList, ListViewActors.FocusedItem);
                    ManageContactpersonPeriod.buttonContactpersonPeriodDelete_Click();
                }
            }
        }
    }
}