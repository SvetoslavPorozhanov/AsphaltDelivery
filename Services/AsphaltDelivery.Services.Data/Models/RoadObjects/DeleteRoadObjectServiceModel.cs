namespace AsphaltDelivery.Services.Data.Models.RoadObjects
{
    using AsphaltDelivery.Data.Models;
    using AsphaltDelivery.Services.Mapping;

    public class DeleteRoadObjectServiceModel : IMapFrom<RoadObject>
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
