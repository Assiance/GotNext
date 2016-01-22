using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Reflection;
using GotNext.Data.Entities;
using GotNext.Data.Entities.User;
using Microsoft.AspNet.Identity.EntityFramework;

namespace GotNext.Data.Contexts
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUserEntity>
    {
        public DbSet<ExampleEntity> Examples { get; set; }
        public DbSet<LogActionEntity> Logs { get; set; }
        public DbSet<CourtEntity> Courts { get; set; }
        public DbSet<PlayerEntity> Players { get; set; }

        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }
        
        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            var typesToRegister = Assembly.GetExecutingAssembly().GetTypes()
             .Where(type => !String.IsNullOrEmpty(type.Namespace))
             .Where(type => type.BaseType != null && type.BaseType.IsGenericType
                  && type.BaseType.GetGenericTypeDefinition() == typeof(EntityTypeConfiguration<>));

            foreach (var type in typesToRegister)
            {
                dynamic configurationInstance = Activator.CreateInstance(type);
                modelBuilder.Configurations.Add(configurationInstance);
            }

            base.OnModelCreating(modelBuilder);
        }
    }
}