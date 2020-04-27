namespace AsphaltDelivery.Web.ViewModels.Firms
{
    using System.ComponentModel.DataAnnotations;

    using AsphaltDelivery.Services.Data.Models.Firms;
    using AsphaltDelivery.Services.Mapping;

    public class FirmDeleteViewModel : IMapFrom<DeleteFirmServiceModel>
    {
        public int Id { get; set; }

        [Display(Name = "Name")]
        public string Name { get; set; }
    }
}
