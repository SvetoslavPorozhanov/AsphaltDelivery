﻿namespace AsphaltDelivery.Services.Data.Models.Trucks
{
    using AsphaltDelivery.Data.Models;
    using AsphaltDelivery.Services.Mapping;

    public class EditTruckServiceModel : IMapTo<Truck>, IMapFrom<Truck>
    {
        public int Id { get; set; }

        public string RegistrationNumber { get; set; }
    }
}
