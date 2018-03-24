using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace crm_systeem
{
    class EmailBot
    {
        // Het bestand waar error berichten naar toe geschreven worden wanneer er een fout plaatsvindt
        string filePath = @"..\..\..\Error_log.txt";

        // Een string die de inhoud van de email bevat
        string emailContents;

        // Een string die de titel van de email bevat
        string emailSubject;

        /// <summary>
        /// Verstuur een email naar het emailadres dat binnenkomt via de attribuut "_email". Er kunnen 2 soorten emails gestuurd worden. Een email bij wanneer een gebruiker een nieuw account heeft gekregen en een email die gestuurd wordt wanneer een wachtwoord gereset wordt.
        /// </summary>
        /// <param name="_userName">De gebruikersnaam van de persoon waarna de email wordt verstuurd</param>
        /// <param name="_password">Het password van de persoon waarna de email wordt verstuurd</param>
        /// <param name="_email">Het emailadres van de persoon waarna de email wordt verstuurd</param>
        private void SendEmail(string _userName, string _password, string _email, string _type_mail)
        {
            if (_type_mail.Equals("password"))
            {
                emailContents = "Beste " + _userName + ",\nJe wachtwoord is veranderd.\nJouw nieuwe wachtwoord is:\n" + _password + "\n\nHeb je deze wijziging niet zelf aangevraagd, neem dan contact op met hhscrmemailservice@gmail.com.";
                emailSubject = "Wachtwoord wijziging HHS CRM";
            }
            else
            {
                emailContents = "Beste " + _userName + ",\nEr is een account voor u aangemaakt.\nJouw wachtwoord is:\n" + _password + "\n\nHeb je hierom niet gevraagd, neem dan contact op met hhscrmemailservice@gmail.com.";
                emailSubject = "Nieuw account HHS CRM";
            }
            try
            {


                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
                mail.From = new MailAddress("hhscrmemailservice@gmail.com");

                // Hier komt de email van de gebruiker
                mail.To.Add(_email);
                mail.Subject = emailSubject;
                mail.Body = emailContents;

                SmtpServer.Port = 587;
                SmtpServer.Credentials = new System.Net.NetworkCredential("hhscrmemailservice@gmail.com", "4LE12F%@");
                SmtpServer.EnableSsl = true;

                SmtpServer.Send(mail);
            }
            catch (Exception ex)
            {
                using (StreamWriter writer = new StreamWriter(filePath, true))
                {
                    writer.WriteLine("Message : " + ex.Message + Environment.NewLine + ex.StackTrace
                    + Environment.NewLine + "Date : " + DateTime.Now.ToString() + Environment.NewLine);
                }
            }
        }


        public EmailBot(string _userName, string _password, string _email, string _type_mail)
        {
            SendEmail(_userName, _password, _email, _type_mail);
        }
    }
}
