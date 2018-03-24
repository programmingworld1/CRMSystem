using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace crm_systeem.Models
{
    public class Search
    {
        ListView ListViewActors;
        bool isManage;
        public Search(ListView ListViewActor, bool isManages)
        {
            isManage = isManages;
            ListViewActors = ListViewActor;
        }
        // Bekijkt wat je zoekt en filtert daarop
        public void SearchItems(tableToDisplay CurrentChoice, string comboBoxSearch, string textBoxSearch, List<User> UserList, List<Company> CompanyList, List<Contactperson> ContactpersonList, List<ContactpersonPeriod> ContactpersonPeriodList, List<Period> PeriodList)
        {
            ListViewActors.Items.Clear();
            // Kijkt op welk gedeelte van de pagina je bent
            if (CurrentChoice == tableToDisplay.user)
            {
                foreach (var item in UserList)
                {
                    // Bekijkt wat je precies wilt zoeken
                    if (comboBoxSearch.ToString().Equals("Weergeef Alles"))
                    {
                        searchShow(item, UserList, CompanyList, ContactpersonList, ContactpersonPeriodList, PeriodList);
                    }
                    else if (comboBoxSearch.Equals("Gebruikersnaam") && textBoxSearch.Equals(item.username, StringComparison.InvariantCultureIgnoreCase)) // als de combobox niet leeg is
                    {
                        searchShow(item, UserList, CompanyList, ContactpersonList, ContactpersonPeriodList, PeriodList);
                    }
                    else if (comboBoxSearch.Equals("Voornaam") && textBoxSearch.Equals(item.firstname, StringComparison.InvariantCultureIgnoreCase)) // als de combobox niet leeg is
                    {
                        searchShow(item, UserList, CompanyList, ContactpersonList, ContactpersonPeriodList, PeriodList);
                    }
                    else if (comboBoxSearch.Equals("Type") && textBoxSearch.Equals(item.type, StringComparison.InvariantCultureIgnoreCase)) // als de combobox niet leeg is
                    {
                        searchShow(item, UserList, CompanyList, ContactpersonList, ContactpersonPeriodList, PeriodList);
                    }
                    else if (comboBoxSearch.Equals("Volledige Achternaam") && textBoxSearch.Equals(item.insertion + " " + item.lastname, StringComparison.InvariantCultureIgnoreCase)) // als de combobox niet leeg is
                    {
                        searchShow(item, UserList, CompanyList, ContactpersonList, ContactpersonPeriodList, PeriodList);
                    }
                }
            }
            if (CurrentChoice == tableToDisplay.company)
            {
                foreach (var item in CompanyList)
                {
                    if (comboBoxSearch.Equals("Weergeef Alles"))
                    {
                        searchShow(item, UserList, CompanyList, ContactpersonList, ContactpersonPeriodList, PeriodList);
                    }
                    else if (comboBoxSearch != null && textBoxSearch.Equals("")) // als de combobox niet leeg is
                    {
                        if (comboBoxSearch.Equals(item.internship))
                        {
                            searchShow(item, UserList, CompanyList, ContactpersonList, ContactpersonPeriodList, PeriodList);
                        }
                    }
                    else if (comboBoxSearch != null && textBoxSearch != null) // op beide kunnen zoeken
                    {
                        if (comboBoxSearch == item.internship)
                        {
                            if (textBoxSearch.Equals(item.internship_differentiation, StringComparison.InvariantCultureIgnoreCase) || textBoxSearch.Equals(item.name, StringComparison.InvariantCultureIgnoreCase)) // met zoekveld zoeken
                            {
                                searchShow(item, UserList, CompanyList, ContactpersonList, ContactpersonPeriodList, PeriodList);
                            }
                        }
                    }
                }
            }
            if (CurrentChoice == tableToDisplay.contactperson_period)
            {
                foreach (var item in ContactpersonPeriodList)
                {
                    if (comboBoxSearch.Equals("Weergeef Alles"))
                    {
                        searchShow(item, UserList, CompanyList, ContactpersonList, ContactpersonPeriodList, PeriodList);
                    }
                    else if (comboBoxSearch.Equals("Periode") && textBoxSearch.Equals(item.period_name, StringComparison.InvariantCultureIgnoreCase)) // als de combobox niet leeg is
                    {
                        searchShow(item, UserList, CompanyList, ContactpersonList, ContactpersonPeriodList, PeriodList);
                    }
                    else if (comboBoxSearch.Equals("Differentiatie") && textBoxSearch.Equals(item.differentiation, StringComparison.InvariantCultureIgnoreCase)) // als de combobox niet leeg is
                    {
                        searchShow(item, UserList, CompanyList, ContactpersonList, ContactpersonPeriodList, PeriodList);
                    }
                    else if (comboBoxSearch.Equals("Jaar") && textBoxSearch.Equals(item.year.ToString(), StringComparison.InvariantCultureIgnoreCase)) // als de combobox niet leeg is
                    {
                        searchShow(item, UserList, CompanyList, ContactpersonList, ContactpersonPeriodList, PeriodList);
                    }
                }
            }
            if (CurrentChoice == tableToDisplay.contactperson)
            {
                foreach (var item in ContactpersonList)
                {
                    if (comboBoxSearch.Equals("Weergeef Alles"))
                    {
                        searchShow(item, UserList, CompanyList, ContactpersonList, ContactpersonPeriodList, PeriodList);
                    }
                    else if (comboBoxSearch.Equals("Voornaam") && textBoxSearch.Equals(item.firstname, StringComparison.InvariantCultureIgnoreCase)) // als de combobox niet leeg is
                    {
                        searchShow(item, UserList, CompanyList, ContactpersonList, ContactpersonPeriodList, PeriodList);
                    }
                    else if (comboBoxSearch.Equals("Volledige Achternaam") && textBoxSearch.Equals(item.insertion + " " + item.lastname, StringComparison.InvariantCultureIgnoreCase)) // als de combobox niet leeg is
                    {
                        searchShow(item, UserList, CompanyList, ContactpersonList, ContactpersonPeriodList, PeriodList);
                    }
                    else
                    {
                        foreach (var company in CompanyList)
                        {
                            if (item.company_id == company.id) // als de combobox niet leeg is
                            {
                                if (comboBoxSearch.Equals("Bedrijfsnaam") && textBoxSearch.Equals(company.name, StringComparison.InvariantCultureIgnoreCase))
                                {
                                    searchShow(item, UserList, CompanyList, ContactpersonList, ContactpersonPeriodList, PeriodList);
                                }
                            }
                        }
                    }
                }
            }
        }
        // Lata het zien in de listview wat je in de methode hierboven hebt opgegeven
        private void searchShow(object item, List<User> UserList, List<Company> CompanyList, List<Contactperson> ContactpersonList, List<ContactpersonPeriod> ContactpersonPeriodList, List<Period> PeriodList)
        {
            if (item is User)
            {
                ListViewItem ListViewItem = new ListViewItem((item as User).id.ToString());
                ListViewItem.SubItems.Add((item as User).username);
                ListViewItem.SubItems.Add((item as User).firstname);
                ListViewItem.SubItems.Add((item as User).insertion);
                ListViewItem.SubItems.Add((item as User).lastname);
                ListViewItem.SubItems.Add((item as User).type);
                ListViewItem.SubItems.Add((item as User).email);
                if (isManage == false)
                {
                    ListViewItem.SubItems.RemoveAt(0);
                }
                ListViewActors.Items.Add(ListViewItem);
            }
            else if (item is Company)
            {
                ListViewItem ListViewItem = new ListViewItem((item as Company).id.ToString());
                ListViewItem.SubItems.Add((item as Company).name);
                ListViewItem.SubItems.Add((item as Company).address);
                ListViewItem.SubItems.Add((item as Company).internship);
                ListViewItem.SubItems.Add((item as Company).internship_differentiation);
                foreach (var contactperson in ContactpersonList)
                {
                    if ((item as Company).id == contactperson.company_id)
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
                if (isManage == false)
                {
                    ListViewItem.SubItems.RemoveAt(0);
                }
                ListViewActors.Items.Add(ListViewItem);
            }
            else if (item is Contactperson)
            {
                ListViewItem ListViewItem = new ListViewItem((item as Contactperson).id.ToString());
                ListViewItem.SubItems.Add((item as Contactperson).firstname);
                ListViewItem.SubItems.Add((item as Contactperson).insertion);
                ListViewItem.SubItems.Add((item as Contactperson).lastname);
                ListViewItem.SubItems.Add((item as Contactperson).email);
                ListViewItem.SubItems.Add((item as Contactperson).phonenumber.ToString());
                foreach (var company in CompanyList)
                {
                    if ((item as Contactperson).company_id == company.id)
                    {
                        ListViewItem.SubItems.Add(company.name);
                    }
                }
                ListViewItem.SubItems.Add((item as Contactperson).function);
                ListViewItem.SubItems.Add((item as Contactperson).next_time);
                foreach (var user in UserList)
                {
                    if ((item as Contactperson).contact_hhs == user.id)
                    {
                        ListViewItem.SubItems.Add(user.lastname + ", " + user.firstname[0] + ". " + user.insertion);
                    }
                }
                foreach (var user in UserList)
                {
                    if ((item as Contactperson).created_by == user.id)
                    {
                        ListViewItem.SubItems.Add(user.lastname + ", " + user.firstname[0] + ". " + user.insertion);
                    }
                }
                if (isManage == false)
                {
                    ListViewItem.SubItems.RemoveAt(0);
                }
                ListViewActors.Items.Add(ListViewItem);
            }
            else if (item is ContactpersonPeriod)
            {
                ListViewItem ListViewItem = new ListViewItem((item as ContactpersonPeriod).period_name);
                if (isManage == true)
                {
                    ListViewItem.SubItems.Add((item as ContactpersonPeriod).contactperson_id.ToString());
                }
                else
                {
                    foreach (var contactperson in ContactpersonList)
                    {
                        if ((item as ContactpersonPeriod).contactperson_id == contactperson.id)
                        {
                            ListViewItem.SubItems.Add(contactperson.lastname + ", " + contactperson.firstname[0] + ". " + contactperson.insertion);
                        }
                    }
                }
                ListViewItem.SubItems.Add((item as ContactpersonPeriod).differentiation);
                ListViewItem.SubItems.Add((item as ContactpersonPeriod).year.ToString());
                ListViewItem.SubItems.Add((item as ContactpersonPeriod).helped_with);
                ListViewActors.Items.Add(ListViewItem);
            }
        }
    }
}