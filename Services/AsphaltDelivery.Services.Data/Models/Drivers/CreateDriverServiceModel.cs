namespace AsphaltDelivery.Services.Data.Models.Drivers
{
    using System;

    using AsphaltDelivery.Data.Models;
    using AsphaltDelivery.Services.Mapping;

    public class CreateDriverServiceModel : IMapTo<Driver>
    {
        public string FullName { get; set; }
    }
}
