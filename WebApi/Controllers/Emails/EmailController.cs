/*using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers.Emails
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {


        private readonly IWebHostEnvironment _webHostEnvironment;

        public EmailController(IWebHostEnvironment webHostEnvironment)
        {

            _webHostEnvironment = webHostEnvironment;
        }

        [HttpGet("SendEmail")]
        public IActionResult SendEmail()
        {
            // Input parameters (recipientEmail and subject) to be determined at runtime
            string recipientEmail = "vickyverma.cm7@gmail.com"; // You can change this as needed
            string subject = "Payment Confirmation"; // You can change this as needed

            // Path to the HTML email template
            string templatePath = Path.Combine(_webHostEnvironment.WebRootPath, "mails/mail6.html");

            // Read the HTML template from the file
            string htmlBody = System.IO.File.ReadAllText(templatePath);

            // You can use your EmailService to send the email with the recipientEmail and subject
            EmailService emailService = new EmailService();
            emailService.SendEmail(recipientEmail, subject, htmlBody);

            return Ok("Email sent successfully!");
        }

    }
}

*/