namespace AsphaltDelivery.Web.ViewModels.AsphaltMixtures
{
    using System.ComponentModel.DataAnnotations;

    using AsphaltDelivery.Common;
    using AsphaltDelivery.Services.Data.Models.AsphaltMixtures;
    using AsphaltDelivery.Services.Mapping;

    public class AsphaltMixtureEditInputModel : IMapTo<EditAsphaltMixtureServiceModel>, IMapFrom<EditAsphaltMixtureServiceModel>
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(AttributesConstraints.AsphaltMixtureTypeMaxLength, ErrorMessage = AttributesErrorMessages.MaxLengthErrorMessage)]
        public string Type { get; set; }
    }
}
