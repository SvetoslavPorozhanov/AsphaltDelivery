using AsphaltDelivery.Data.Models;
using MyTested.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AsphaltDelivery.MyTestedAspNet.Test
{
    public class DriversTestData
    {
        public static class ArticleTestData
        {
            public static List<Driver> GetDrivers(int count)
            {
                var user = new ApplicationUser
                {
                    Id = TestUser.Identifier,
                    UserName = TestUser.Username
                };

                var drivers = Enumerable
                    .Range(1, count)
                    .Select(i => new Driver
                    {
                        Id = i,
                        FullName = $"DFN {i}",
                    })
                    .ToList();

                return drivers;
            }
        }
    }
}
