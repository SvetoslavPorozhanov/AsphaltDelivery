namespace AsphaltDelivery.Web.ViewModels.Firms
{
    using System.ComponentModel.DataAnnotations;

    using AsphaltDelivery.Common;
    using AsphaltDelivery.Services.Data.Models.Firms;
    using AsphaltDelivery.Services.Mapping;

    public class FirmCreateInputModel : IMapTo<CreateFirmServiceModel>
    {
        [Required]
        [Display(Name = "Name")]
        [MaxLength(AttributesConstraints.FirmNameMaxLength, ErrorMessage = AttributesErrorMessages.MaxLengthErrorMessage)]
        public string Name { get; set; }
    }
}
