using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.Net.Mail;

namespace BackendDisneyApi.Controllers
{
    [ApiController]
    [Route(template: "aí/[controller]")]
    public class SendGridTestController : ControllerBase
    {
        public SendGridTestController()
        {


        }

        [HttpGet]
        public async Task<IActionResult> PruebaEmail()
        {

            var apiKey = "Poner api key aquí";
            var client = new SendGridClient(apiKey); //crea una instancia del send grid
            var from = new EmailAddress("facundoromani90@gmail.com", "Example User"); //origen- emisor
            var subject = "Sending with Twilio SendGrid is Fun";
            var to = new EmailAddress("facundoromani90@gmail.com", "Example User"); //destino- receptor
            var plainTextContent = "and easy to do anywhere, even with C#"; //contenido
            var htmlContent = "<strong>and easy to do anywhere, even with C#</strong>";
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            var response = await client.SendEmailAsync(msg);

            return Ok();
        }
    }


}