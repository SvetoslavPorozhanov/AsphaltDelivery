namespace AsphaltDelivery.Services.Data.Models.Drivers
{
    using AsphaltDelivery.Data.Models;
    using AsphaltDelivery.Services.Mapping;

    public class EditDriverServiceModel : IMapTo<Driver>, IMapFrom<Driver>
    {
        public int Id { get; set; }

        public string FullName { get; set; }
    }
}
