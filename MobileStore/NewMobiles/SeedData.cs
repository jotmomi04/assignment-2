using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MobileStore.NewPhones;
using System;
using System.Linq;

namespace MobileStore.NewPhones
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new newMobilesContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<newMobilesContext>>()))
            {
                // Look for any movies.
                if (context.NewMobiles.Any())
                {
                    return;   // DB has been seeded
                }

                context.NewMobiles.AddRange(
                    new NewMobiles
                    {
                        Model = "Samsung A51",
                        ReleaseDate = DateTime.Parse("2020-2-12"),
                        Proccesor = "Quad core",
                        Price = 1500
                    },

                    new NewMobiles
                    {
                        Model = "Samsung A31 ",
                        ReleaseDate = DateTime.Parse("2021-3-13"),
                        Proccesor = "quad core",
                        Price = 1200
                    },

                    new NewMobiles
                    {
                        Model = "Samsung A12",
                        ReleaseDate = DateTime.Parse("2020-2-23"),
                        Proccesor = "dual core",
                        Price = 1100
                    }

                   
                );
                context.SaveChanges();
            }
        }
    }
}