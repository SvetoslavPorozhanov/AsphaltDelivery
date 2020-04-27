namespace AsphaltDelivery.Web.Controllers
{
    using System.Threading.Tasks;

    using AsphaltDelivery.Data.Models;
    using AsphaltDelivery.Services.Messaging;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    public class EmailsController : BaseController
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IEmailSender emailSender;

        public EmailsController(UserManager<ApplicationUser> userManager, IEmailSender emailSender)
        {
            this.userManager = userManager;
            this.emailSender = emailSender;
        }

        [Authorize]
        [HttpGet]
        public IActionResult Email()
        {
            return this.View();
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> SendEmail()
        {
            var from = "svetoslav_porozhanov@abv.bg";
            var fromName = "AsphaltDelivery";
            var user = await this.userManager.GetUserAsync(this.User);
            var to = user.UserName;
            var subject = "Register";
            var htmlContent = "You have successfully registered to AsphaltDelevery!";
            await this.emailSender.SendEmailAsync(from, fromName, to, subject, htmlContent);
            return this.RedirectToAction("Index", "Home");
        }
    }
}
