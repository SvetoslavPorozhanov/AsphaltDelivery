namespace AsphaltDelivery.Web.ViewModels.RoadObjects
{
    using System.ComponentModel.DataAnnotations;

    using AsphaltDelivery.Common;
    using AsphaltDelivery.Services.Data.Models.RoadObjects;
    using AsphaltDelivery.Services.Mapping;

    public class RoadObjectCreateInputModel : IMapTo<CreateRoadObjectServiceModel>
    {
        [Required]
        [MaxLength(AttributesConstraints.RoadObjectNameMaxLength, ErrorMessage = AttributesErrorMessages.MaxLengthErrorMessage)]
        public string Name { get; set; }
    }
}
