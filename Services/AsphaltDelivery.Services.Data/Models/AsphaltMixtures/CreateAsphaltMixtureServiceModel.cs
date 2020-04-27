namespace AsphaltDelivery.Services.Data.Models.AsphaltMixtures
{
    using AsphaltDelivery.Data.Models;
    using AsphaltDelivery.Services.Mapping;

    public class CreateAsphaltMixtureServiceModel : IMapTo<AsphaltMixture>
    {
        public string Type { get; set; }
    }
}
