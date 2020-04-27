namespace AsphaltDelivery.Web.ViewModels.RoadObjects
{
    using AsphaltDelivery.Services.Data.Models.RoadObjects;
    using AsphaltDelivery.Services.Mapping;

    public class RoadObjectsListingViewModel : IMapFrom<AllRoadObjectsServiceModel>
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
