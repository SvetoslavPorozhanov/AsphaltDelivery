namespace AsphaltDelivery.Web.ViewModels.RoadObjects
{
    using System.ComponentModel.DataAnnotations;

    using AsphaltDelivery.Common;
    using AsphaltDelivery.Services.Data.Models.RoadObjects;
    using AsphaltDelivery.Services.Mapping;

    public class RoadObjectEditInputModel : IMapTo<EditRoadObjectServiceModel>, IMapFrom<EditRoadObjectServiceModel>
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(AttributesConstraints.RoadObjectNameMaxLength, ErrorMessage = AttributesErrorMessages.MaxLengthErrorMessage)]
        public string Name { get; set; }
    }
}
