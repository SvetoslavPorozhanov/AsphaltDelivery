namespace AsphaltDelivery.Web.Hubs
{
    using System;
    using System.Globalization;
    using System.Threading.Tasks;

    using AsphaltDelivery.Web.ViewModels.Comments;
    using Ganss.XSS;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.SignalR;

    [Authorize]
    public class ChatHub : Hub
    {
        public async Task Send(string message)
        {
            await this.Clients.All.SendAsync(
                "NewMessage",
                new MessageViewModel
                {
                    User = this.Context.User.Identity.Name,
                    SanitizedText = new HtmlSanitizer().Sanitize(message),
                    CreatedOn = DateTime.UtcNow.ToString("dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture),
                });
        }
    }
}
