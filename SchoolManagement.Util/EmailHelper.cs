using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Util
{
    public class EmailHelper
    {
        
        public EmailHelper()
        {

        }
        public static void SendRegisterted(string registeredCustomerEmail,string userName, string password)
        {
            var schoolEmail = "sliititpscmc@gmail.com";
            var passowrd = "1qaz2wsx@";

            MailMessage message = new MailMessage(schoolEmail,registeredCustomerEmail);

            string mailBody = "User Name :-" + userName +" " + "Password:-" + password + Environment.NewLine + "Please Don't Reply(Auto genarated Email_SMTP Server)"+ Environment.NewLine
                + "Deparment of Computer Science and Software Engineering -  SLIIT(ITP2021_B06_G04(SMCS))" + Environment.NewLine+ "_RESTful API Debugging_ASP.net core";

            message.Subject = "Registerted Successfull";

            message.Body = mailBody;

            message.BodyEncoding = Encoding.UTF8;

            message.IsBodyHtml = true;

            SmtpClient client = new SmtpClient("smtp.gmail.com", 587);

            System.Net.NetworkCredential networkCredential = new

            System.Net.NetworkCredential(schoolEmail, passowrd);

            client.EnableSsl = true;

            client.UseDefaultCredentials = false;

            client.Credentials = networkCredential;

            try
            {
                client.Send(message);
            }
            catch(Exception ex)
            {
                throw ex;
            }



        }

        public static void SendForgotPasswordEmailLink(string userEmail, string routLink)
        {

            var schoolEmail = "theeventprojectg259@gmail.com";
            var passowrd = "1qaz2wsx@";

            MailMessage message = new MailMessage(schoolEmail, userEmail);

            string mailBody = "Get Link:-" + routLink;

            message.Subject = "School Management Reset Password";

            message.Body = mailBody;

            message.BodyEncoding = Encoding.UTF8;

            message.IsBodyHtml = true;

            SmtpClient client = new SmtpClient("smtp.gmail.com", 587);

            System.Net.NetworkCredential networkCredential = new

            System.Net.NetworkCredential(schoolEmail, passowrd);

            client.EnableSsl = true;

            client.UseDefaultCredentials = false;

            client.Credentials = networkCredential;

            try
            {
                client.Send(message);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
