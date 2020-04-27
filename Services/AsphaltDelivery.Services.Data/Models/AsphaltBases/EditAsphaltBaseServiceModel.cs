namespace AsphaltDelivery.Services.Data.Models.AsphaltBases
{
    using AsphaltDelivery.Data.Models;
    using AsphaltDelivery.Services.Mapping;

    public class EditAsphaltBaseServiceModel : IMapTo<AsphaltBase>, IMapFrom<AsphaltBase>
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
