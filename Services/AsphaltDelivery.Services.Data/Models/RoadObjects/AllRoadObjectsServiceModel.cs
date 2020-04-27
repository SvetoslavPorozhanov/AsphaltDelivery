namespace AsphaltDelivery.Services.Data.Models.RoadObjects
{
    using AsphaltDelivery.Data.Models;
    using AsphaltDelivery.Services.Mapping;

    public class AllRoadObjectsServiceModel : IMapFrom<RoadObject>
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
