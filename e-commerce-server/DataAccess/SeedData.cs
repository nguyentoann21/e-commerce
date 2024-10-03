using e_commerce_server.DataAccess.OriginalData;
using e_commerce_server.Models;
using Microsoft.EntityFrameworkCore;

namespace e_commerce_server.DataAccess
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider service)
        {
            using(var context = new ApplicationDbContext(service.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {
                context.Database.EnsureCreated();

                if (context.Categories.Any() && context.Roles.Any() && context.ProductSizes.Any())
                {
                    return;
                }

                /*** Seed roles ***/
                SeedRoles.SeedRole(context);

                /*** Seed categories ***/
                SeedCategories.SeedCategory(context);

                /*** Seed Sizes ***/
                // Seed cloth sizes
                SeedClothSizes.SeedClothSize(context);
                // Seed None and One size
                NoneAndOneSize.NaOSize(context);
                // Seed Baby sizes
                BabySizes.BabySize(context);
                // Seed Volume sizes
                VolumeSizes.VolumeSize(context);
                // Seed engine motorlike volume sizes
                SeedMotorbikeEngineSizes.SeedMotorbikeEngineSize(context);
                // Seed engine car volume sizes
                SeedCarEngineSizes.SeedCarEngineSize(context);
                // Seed engine electric volume sizes
                SeedElectricEngineSizes.SeedElectricEngineSize(context);
                // Seed normal sizes
                NormalSizes.NormalSize(context);

                /*** Seed Color ***/
                SeedColors.SeedColor(context);

                context.SaveChanges();
            }
        }
    }
}
