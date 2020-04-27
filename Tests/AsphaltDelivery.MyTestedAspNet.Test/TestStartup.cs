using AsphaltDelivery.Services.Data.Drivers;
using AsphaltDelivery.Web;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyTested.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace AsphaltDelivery.MyTestedAspNet.Test
{
    public class TestStartup : Startup
    {
        public TestStartup(IConfiguration configuration)
            : base(configuration)
        {
        }

        public void ConfigureTestServices(IServiceCollection services)
        {
            base.ConfigureServices(services);
            // services.Replace<IService, MockedService>();
        }
    }
}
