using MailKit.Net.Smtp;
using MimeKit;
using MimeKit.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailSender
{
    public static class Sender
    {
        // Here you declare your email and your password to use it for send an Email.
        private readonly static string email = "example@gmail.com";
        private readonly static string password = "example password";

        // Here is an Email sender method.
        public static void SendEmail(string to, string subject, string body)
        {
            // Here is a Mime Message. It Allows us to create our message.
            MimeMessage message = new MimeMessage();

            // We are adding the sender info.
            message.From.Add(new MailboxAddress("Test", email));

            // Receiver email address
            message.To.Add(MailboxAddress.Parse(to));

            // Message Subject
            message.Subject = subject;

            // Add the message body which can be text, html body or... (For example we chose text)
            message.Body = new TextPart(TextFormat.Text) { Text = body };


            // Creating new smtp client
            SmtpClient client = new SmtpClient();

            try
            {
                // Connecting to the smtp server with port 465. SSL also enabled.
                client.Connect("smtp.gmail.com", 465, true);

                // Here we have to authenticate the sender's email informations And send email.
                client.Authenticate(email, password);

                client.Send(message);
            }
            catch (Exception ex)
            {
                // logging an error
                Console.WriteLine(ex.Message);
            }
            finally
            {
                // Finally we have to disconnect from the client and dispose of the client object
                client.Disconnect(true);

                client.Dispose();
            }
        }
    }
}
