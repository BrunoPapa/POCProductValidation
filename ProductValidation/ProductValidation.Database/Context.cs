using ProductValidation.IoC.Database;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace ProductValidation.Database
{
    public class Context : DbContext
    {
        public Context() : base("ProductValidationContext")
        {
        }

        public DbSet<BaseValidationEntity> BaseValidation { get; set; }
        public DbSet<ConfigValidationEntity> ConfigValidation { get; set; }
        public DbSet<ConfigValidationMessageEntity> ConfigValidationMessage { get; set; }
        public DbSet<ConfigValidationRuleEntity> ConfigValidationRule { get; set; }
        public DbSet<ConfigValidationRuleLOVEntity> ConfigValidationRuleLOV { get; set; }
        public DbSet<ContractEntity> Contract { get; set; }
        public DbSet<FieldEntity> Field { get; set; }
        public DbSet<FieldContractEntity> FieldContract { get; set; }
        public DbSet<FieldProductEntity> FieldProduct { get; set; }
        public DbSet<OfferEntity> Offer { get; set; }
        public DbSet<OperatorEntity> Operator { get; set; }
        public DbSet<ProductEntity> Product { get; set; }        


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();            
        }
    }
}
