﻿using System;
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
            var schoolEmail = "theeventprojectg259@gmail.com";
            var passowrd = "1qaz2wsx@";

            MailMessage message = new MailMessage(schoolEmail,registeredCustomerEmail);

            string mailBody = "User Name :-" + userName +" " + "Password:-" + password;

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
    }
}
