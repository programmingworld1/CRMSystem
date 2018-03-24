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
    public partial class ManageContactpersonPeriod : UserControl
    {
        ContactpersonPeriodController ContactpersonPeriodDB = new ContactpersonPeriodController();
        List<ContactpersonPeriod> ContactpersonPeriodList;
        ContactpersonPeriod ContactpersonPeriodToEdit;
        Dictionary<int, string> ContactpersonNames = new Dictionary<int, string>();
        List<string> PeriodNames = new List<string>();
        int DeleteById;
        ListViewItem ListViewActors;
        char[] letters = { '@', '/', '!', '#', '$', '%', '^', '&', '*', '(', ')', '-', '_', '|', ';', '<', '>', '.', ',' };
        public ManageContactpersonPeriod(ref List<ContactpersonPeriod> ContactpersonPeriodLists, ref List<Contactperson> ContactpersonList, ref List<Period> PeriodList, ListViewItem ListViewActor)
        {
            ListViewActors = ListViewActor;
            ContactpersonPeriodList = ContactpersonPeriodLists;
            InitializeComponent();
            prepareScreen(ref ContactpersonList, ref PeriodList);
        }
        // Maakt het scherm klaar voor zowel het toevoegen als bewerken
        private void prepareScreen(ref List<Contactperson> ContactpersonList, ref List<Period> PeriodList)
        {
            foreach (var item in ContactpersonList)
            {
                ContactpersonNames.Add(item.id, item.lastname + ", " + item.firstname[0] + ". " + item.insertion);
            }
            comboBoxContactpersonPeriodContactpersonID.DataSource = new BindingSource(ContactpersonNames, null);
            comboBoxContactpersonPeriodContactpersonID.ValueMember = "Key";
            comboBoxContactpersonPeriodContactpersonID.DisplayMember = "Value";
            foreach (var item in PeriodList)
            {
                PeriodNames.Add(item.name);
            }
            comboBoxContactpersonPeriodPeriodName.DataSource = new BindingSource(PeriodNames, null);
            comboBoxContactpersonPeriodPeriodName.DisplayMember = "Name";
            for (int year = 1950; year <= DateTime.Now.Year; year++)
            {
                comboBoxContactpersonPeriodYear.Items.Add(year);
            }
        }
        // Voert de uiteindelijke actie uit voor het toevoegen
        private void buttonContactpersonPeriodConfirm_Click(object sender, EventArgs e)
        {
            if (textBoxContactpersonPeriodHelpedWith.Text.IndexOfAny(letters) > 0 || comboBoxContactpersonPeriodContactpersonID.Text.Equals("") || comboBoxContactpersonPeriodPeriodName.Text.Equals("") || comboBoxContactpersonPeriodYear.Text.Equals("") || comboBoxContactpersonPeriodDifferentiation.Text.Equals("") || textBoxContactpersonPeriodHelpedWith.Text.Equals(""))
            {
                MessageBox.Show("Vul alle velden correct in aub");
            }
            else
            {
                ContactpersonPeriod ContactpersonPeriod = new ContactpersonPeriod { contactperson_id = Int32.Parse(comboBoxContactpersonPeriodContactpersonID.SelectedValue.ToString()), period_name = comboBoxContactpersonPeriodPeriodName.SelectedValue.ToString(), year = Int32.Parse(comboBoxContactpersonPeriodYear.SelectedItem.ToString()), differentiation = comboBoxContactpersonPeriodDifferentiation.SelectedItem.ToString(), helped_with = textBoxContactpersonPeriodHelpedWith.Text };
                bool Transaction = ContactpersonPeriodDB.InsertContactpersonPeriod(ContactpersonPeriod);
                if (Transaction == true)
                {
                    ContactpersonPeriodList.Add(ContactpersonPeriod);
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Het toevoegen is mislukt!");
                }
            }
        }
        // Voert de uiteindelijke actie uit voor het verwijderen
        public void buttonContactpersonPeriodDelete_Click()
        {
            foreach (var item in ContactpersonPeriodList)
            {
                if (item.period_name.ToString() == ListViewActors.SubItems[0].Text && item.contactperson_id.ToString() == ListViewActors.SubItems[1].Text && item.year.ToString() == ListViewActors.SubItems[3].Text)
                {
                    ContactpersonPeriodToEdit = item;
                }
            }
            bool Transaction = ContactpersonPeriodDB.DeleteContactpersonPeriod(ContactpersonPeriodToEdit);
            if (Transaction == true)
            {
                foreach (var item in ContactpersonPeriodList)
                {
                    if (item.contactperson_id == ContactpersonPeriodToEdit.contactperson_id && item.period_name == ContactpersonPeriodToEdit.period_name && item.year == ContactpersonPeriodToEdit.year)
                    {
                        DeleteById = ContactpersonPeriodList.IndexOf(item);
                    }
                }
                ContactpersonPeriodList.RemoveAt(DeleteById);
            }
            else
            {
                MessageBox.Show("Het verwijderen is mislukt!");
            }
        }
        private void buttonContactpersonPeriodReturn_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
