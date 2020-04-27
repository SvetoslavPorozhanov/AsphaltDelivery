namespace AsphaltDelivery.Services.Data.Models.AsphaltBases
{
    using AsphaltDelivery.Data.Models;
    using AsphaltDelivery.Services.Mapping;

    public class CreateAsphaltBaseServiceModel : IMapTo<AsphaltBase>, IMapFrom<AsphaltBase>
    {
        public string Name { get; set; }
    }
}
