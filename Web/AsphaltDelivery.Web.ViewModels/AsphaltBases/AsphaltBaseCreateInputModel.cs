namespace AsphaltDelivery.Web.ViewModels.AsphaltBases
{
    using System.ComponentModel.DataAnnotations;

    using AsphaltDelivery.Common;
    using AsphaltDelivery.Services.Data.Models.AsphaltBases;
    using AsphaltDelivery.Services.Mapping;

    public class AsphaltBaseCreateInputModel : IMapTo<CreateAsphaltBaseServiceModel>
    {
        [Required]
        [MaxLength(AttributesConstraints.AsphaltBaseNameMaxLength, ErrorMessage = AttributesErrorMessages.MaxLengthErrorMessage)]
        public string Name { get; set; }
    }
}
