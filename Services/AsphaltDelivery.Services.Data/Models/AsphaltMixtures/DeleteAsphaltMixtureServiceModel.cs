namespace AsphaltDelivery.Services.Data.Models.AsphaltMixtures
{
    using AsphaltDelivery.Data.Models;
    using AsphaltDelivery.Services.Mapping;

    public class DeleteAsphaltMixtureServiceModel : IMapFrom<AsphaltMixture>
    {
        public int Id { get; set; }

        public string Type { get; set; }
    }
}
