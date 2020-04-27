namespace AsphaltDelivery.Web.ViewModels.Drivers
{
    using System.ComponentModel.DataAnnotations;

    using AsphaltDelivery.Services.Data.Models.Drivers;
    using AsphaltDelivery.Services.Mapping;

    public class DriverDeleteViewModel : IMapFrom<DeleteDriverServiceModel>
    {
        public int Id { get; set; }

        [Display(Name = "Full Name")]
        public string FullName { get; set; }
    }
}
