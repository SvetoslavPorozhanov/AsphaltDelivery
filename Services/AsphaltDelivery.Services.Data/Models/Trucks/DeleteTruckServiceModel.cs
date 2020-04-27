namespace AsphaltDelivery.Services.Data.Models.Trucks
{
    using AsphaltDelivery.Data.Models;
    using AsphaltDelivery.Services.Mapping;

    public class DeleteTruckServiceModel : IMapFrom<Truck>
    {
        public int Id { get; set; }

        public string RegistrationNumber { get; set; }
    }
}
