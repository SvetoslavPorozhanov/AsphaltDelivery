namespace AsphaltDelivery.Web.ViewModels.Trucks
{
    using System.ComponentModel.DataAnnotations;

    using AsphaltDelivery.Common;
    using AsphaltDelivery.Services.Data.Models.Trucks;
    using AsphaltDelivery.Services.Mapping;

    public class TruckCreateInputModel : IMapTo<CreateTruckServiceModel>
    {
        [Required]
        [Display(Name = "Registration Number")]
        [MaxLength(AttributesConstraints.TruckRegistrationNumberMaxLength, ErrorMessage = AttributesErrorMessages.MaxLengthErrorMessage)]
        public string RegistrationNumber { get; set; }
    }
}
