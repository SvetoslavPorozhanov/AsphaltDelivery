namespace AsphaltDelivery.Services.Data.Tests.Common
{
    using System.Reflection;

    using AsphaltDelivery.Data.Models;
    using AsphaltDelivery.Services.Data.Models.AsphaltBases;
    using AsphaltDelivery.Services.Mapping;

    public class MapperInitializer
    {
        public static void InitializeMapper()
        {
            AutoMapperConfig.RegisterMappings(
                typeof(AllAsphaltBasesServiceModel).GetTypeInfo().Assembly,
                typeof(AsphaltBase).GetTypeInfo().Assembly);
        }
    }
}
