namespace AsphaltDelivery.Web.ViewModels.Drivers
{
    using System.ComponentModel.DataAnnotations;

    using AsphaltDelivery.Common;
    using AsphaltDelivery.Services.Data.Models.Drivers;
    using AsphaltDelivery.Services.Mapping;

    public class DriverCreateInputModel : IMapTo<CreateDriverServiceModel>
    {
        [Required]
        [Display(Name = "Full Name")]
        [MaxLength(AttributesConstraints.DriverFullNameMaxLength, ErrorMessage = AttributesErrorMessages.MaxLengthErrorMessage)]
        public string FullName { get; set; }
    }
}
