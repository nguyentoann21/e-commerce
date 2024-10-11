using e_commerce_server.DataAccess.OriginalData;
using e_commerce_server.Models;
using Microsoft.EntityFrameworkCore;

namespace e_commerce_server.DataAccess
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider service, ILogger _logger)
        {
            using(var context = new ApplicationDbContext(service.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {
                context.Database.EnsureCreated();

                try
                {
                    bool changeStatus = false;

                    if (!context.Categories.Any())
                    {
                        /*** Seed categories ***/
                        SeedCategories.SeedCategory(context);
                        changeStatus = true;
                    }

                    if (!context.Roles.Any())
                    {
                        /*** Seed roles ***/
                        SeedRoles.SeedRole(context);
                        changeStatus = true;
                    }

                    if (!context.ProductSizes.Any())
                    {
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
                        changeStatus = true;
                    }

                    if (!context.ProductColors.Any())
                    {
                        /*** Seed Color ***/
                        SeedColors.SeedColor(context);
                        changeStatus = true;
                    }

                    if(changeStatus)
                    {
                        // Save all changes at once
                        context.SaveChanges();
                        _logger.LogInformation("Seeding data completed successfully");
                    }
                }
                catch (Exception ex) 
                {
                    // Log error message with logger framework
                    _logger.LogError(ex, "An error occurred while seeding the database. Exception: {ExceptionMessage}", ex.Message);
                }
            }
        }
    }
}
