namespace AsphaltDelivery.Services.Data.Models.Trucks
{
    using AsphaltDelivery.Data.Models;
    using AsphaltDelivery.Services.Mapping;

    public class CreateTruckServiceModel : IMapTo<Truck>
    {
        public string RegistrationNumber { get; set; }
    }
}
