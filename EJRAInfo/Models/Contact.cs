using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Net.Mail;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace EJRAInfo.Models
{
    public class ContactViewModel
    {
        [Required(ErrorMessage = "Your email address is required")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Please enter a valid email address")]
        [Display(Name = "Your email address")]
        public string From { get; set; }

        [Required]
        [Display(Name = "Subject")]
        public string Subject { get; set; }

        [Required]
        [Display(Name = "Message")]
        [DataType(DataType.MultilineText)]
        public string Message { get; set; }

        public int BookingWeekID { get; set; }
        public string WeekDate { get; set; }
    }

    public class Contact
    {
        public string From { get; set; }
        public string To { get; set; }
        public string Subject { get; set; }

        public string Message { get; set; }

        public Contact()
        {
            To = null;
        }
    }

    public class Email
    {
        public string EmailAccount { get; set; }
        public string EmailPassword { get; set; }
        public string EMailClient { get; set; }
        public string DefaultEmailFrom { get; set; }

        public Email()
        {
            EmailAccount = "peter@pugwash.com";
            EmailPassword = "ARD1329";
            EMailClient = "smtp.pugwash.com";
            DefaultEmailFrom = "info@OxfordEJRAGroup.net";

        }

        public Email(string emailAccount, string emailPassword, string eMailClient, string defaultEmailFrom)
        {
            EmailAccount = emailAccount;
            EmailPassword = emailPassword;
            EMailClient = eMailClient;
            DefaultEmailFrom = defaultEmailFrom;


        }

        public void Send(Contact contact)
        {
            MailMessage mail = new MailMessage(
                DefaultEmailFrom,
                contact.To ?? DefaultEmailFrom,
                contact.Subject,
                contact.Message + "\n\nFrom\n\n" + contact.From);
            mail.ReplyToList.Add(contact.From);

            try
            {
                using (SmtpClient smtpClient = new SmtpClient(EMailClient))
                {
                    smtpClient.UseDefaultCredentials = false;
                    smtpClient.Credentials = new NetworkCredential(EmailAccount, EmailPassword);
                    smtpClient.Send(mail);
                }
            }
            catch (Exception e)
            {
                
            }
        }
    }
}
