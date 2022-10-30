using LoyallaApi.DBModels;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OnlineEnergyUtilityPlateformAPI.DBModels.Model;
using System.Collections.Generic;

namespace LoyallaApi.Context
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        { }

       
        
        public DbSet<UserDeviceMappingTbl> UserDeviceMappingTbls { get; set; }
        
        public DbSet<DeviceTbl> DeviceTbls { get; set; }
        public DbSet<AfterMappingStoredHourEnergy> AfterMappingStoredHourEnergy { get; set; }

    }
}
