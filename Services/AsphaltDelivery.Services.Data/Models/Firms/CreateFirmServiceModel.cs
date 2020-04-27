namespace AsphaltDelivery.Services.Data.Models.Firms
{
    using AsphaltDelivery.Data.Models;
    using AsphaltDelivery.Services.Mapping;

    public class CreateFirmServiceModel : IMapTo<Firm>
    {
        public string Name { get; set; }
    }
}
