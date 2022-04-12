using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using REDar.Data;
using System;
using System.Linq;

namespace REDar.Models
{
    public static class SeedData
    {

        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new REDarDataContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<REDarDataContext>>()))
            {
                // Look for any movies.
                if (context.UserMeasurement.Any())
                {
                    return;   // DB has been seeded
                }
                context.UserMeasurement.AddRange(
                        new UserMeasurement
                        {
                            
                            UserId = 1,
                            TimeStamp = DateTime.Today,
                            type = Enum.MeasType.volume,
                            val = 10

                        },
                        new UserMeasurement
                        {
                            
                            UserId = 1,
                            TimeStamp = DateTime.Now,
                            type = Enum.MeasType.volume,
                            val = 20
                        },
                        new UserMeasurement
                        {
                            
                            UserId = 1,
                            TimeStamp = DateTime.Today,
                            type = Enum.MeasType.pain,
                            val = 5

                        },
                        new UserMeasurement
                        {
                            
                            UserId = 1,
                            TimeStamp = DateTime.Now,
                            type = Enum.MeasType.pain,
                            val = 1
                        }
                    );
                context.SaveChanges();
            }
        }
    }
}