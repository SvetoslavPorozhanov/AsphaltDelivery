namespace AsphaltDelivery.Services.Data.Models.RoadObjects
{
    using AsphaltDelivery.Data.Models;
    using AsphaltDelivery.Services.Mapping;

    public class CreateRoadObjectServiceModel : IMapTo<RoadObject>
    {
        public string Name { get; set; }
    }
}
