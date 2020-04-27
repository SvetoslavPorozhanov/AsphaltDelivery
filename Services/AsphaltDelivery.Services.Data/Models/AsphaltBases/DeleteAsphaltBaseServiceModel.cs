namespace AsphaltDelivery.Services.Data.Models.AsphaltBases
{
    using AsphaltDelivery.Data.Models;
    using AsphaltDelivery.Services.Mapping;

    public class DeleteAsphaltBaseServiceModel : IMapFrom<AsphaltBase>
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
