using System;
using System.Net;
using System.Net.Mail;

public class EmailService
{
    public void SendEmail(string recipientEmail, string subject, string htmlBody)
    {
        string senderEmail = "mukesh@codedonor.in";
        string senderPassword = "ZN6q4tYLtkyZ";

        SmtpClient smtpClient = new SmtpClient("smtp.gmail.com")
        {
            Port = 587,
            Credentials = new NetworkCredential(senderEmail, senderPassword),
            EnableSsl = true,
        };

        MailMessage mailMessage = new MailMessage(senderEmail, recipientEmail)
        {
            Subject = subject,
            IsBodyHtml = true,
            Body = htmlBody
        };

        try
        {
            smtpClient.Send(mailMessage);
            Console.WriteLine("Email sent successfully");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Email could not be sent: " + ex.Message);
        }
    }
}
