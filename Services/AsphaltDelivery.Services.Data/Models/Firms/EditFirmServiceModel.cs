﻿namespace AsphaltDelivery.Services.Data.Models.Firms
{
    using AsphaltDelivery.Data.Models;
    using AsphaltDelivery.Services.Mapping;

    public class EditFirmServiceModel : IMapTo<Firm>, IMapFrom<Firm>
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
