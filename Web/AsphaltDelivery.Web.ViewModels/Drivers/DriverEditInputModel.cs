namespace AsphaltDelivery.Web.ViewModels.Drivers
{
    using System.ComponentModel.DataAnnotations;

    using AsphaltDelivery.Common;
    using AsphaltDelivery.Services.Data.Models.Drivers;
    using AsphaltDelivery.Services.Mapping;

    public class DriverEditInputModel : IMapTo<EditDriverServiceModel>, IMapFrom<EditDriverServiceModel>
    {
        public int Id { get; set; }

        [Display(Name = "Full Name")]
        [Required]
        [MaxLength(AttributesConstraints.DriverFullNameMaxLength, ErrorMessage = AttributesErrorMessages.MaxLengthErrorMessage)]
        public string FullName { get; set; }
    }
}
