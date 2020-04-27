namespace AsphaltDelivery.Web.ViewModels.Firms
{
    using System.ComponentModel.DataAnnotations;

    using AsphaltDelivery.Common;
    using AsphaltDelivery.Services.Data.Models.Firms;
    using AsphaltDelivery.Services.Mapping;

    public class FirmEditInputModel : IMapTo<EditFirmServiceModel>, IMapFrom<EditFirmServiceModel>
    {
        public int Id { get; set; }

        [Display(Name = "Name")]
        [Required]
        [MaxLength(AttributesConstraints.FirmNameMaxLength, ErrorMessage = AttributesErrorMessages.MaxLengthErrorMessage)]
        public string Name { get; set; }
    }
}
