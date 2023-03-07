using EmailSender;

// Here is the main project

Console.WriteLine("Enter the email address that you want to send an email to :");
string email = Console.ReadLine();

Console.WriteLine("Enter the subject :");
string subject = Console.ReadLine();

Console.WriteLine("Enter the text :");
string body = Console.ReadLine();

try
{
    // Send an email
    Sender.SendEmail(email, subject, body);

    Console.WriteLine("Email sent");
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}