using ProductValidation.IoC.Database;
using System.Data.Entity;

namespace ProductValidation.Database
{
    public partial class Context : DbContext
    {
        public Context()
            : base("ProductValidationContext")
        {
        }

        public virtual DbSet<BaseValidationEntity> BaseValidations { get; set; }
        public virtual DbSet<ConfigValidationEntity> ConfigValidations { get; set; }
        public virtual DbSet<ConfigValidationMessageEntity> ConfigValidationMessages { get; set; }
        public virtual DbSet<ConfigValidationRuleEntity> ConfigValidationRules { get; set; }
        public virtual DbSet<ConfigValidationRuleLOVEntity> ConfigValidationRuleLOVs { get; set; }
        public virtual DbSet<ContractEntity> Contracts { get; set; }
        public virtual DbSet<FieldEntity> Fields { get; set; }
        public virtual DbSet<FieldsContractEntity> FieldsContracts { get; set; }
        public virtual DbSet<FieldsOfferEntity> FieldsOffers { get; set; }
        public virtual DbSet<FieldsProductEntity> FieldsProducts { get; set; }
        public virtual DbSet<OfferEntity> Offers { get; set; }
        public virtual DbSet<OperatorEntity> Operators { get; set; }
        public virtual DbSet<ProductEntity> Products { get; set; }
        
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BaseValidationEntity>()
                .HasMany(e => e.ConfigValidationMessages)
                .WithRequired(e => e.BaseValidation)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<BaseValidationEntity>()
                .HasMany(e => e.ConfigValidationRules)
                .WithRequired(e => e.BaseValidation)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ConfigValidationEntity>()
                .HasMany(e => e.ConfigValidationMessages)
                .WithRequired(e => e.ConfigValidation)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ConfigValidationEntity>()
                .HasMany(e => e.ConfigValidationRules)
                .WithRequired(e => e.ConfigValidation)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ConfigValidationMessageEntity>()
                .Property(e => e.Message)
                .IsUnicode(false);

            modelBuilder.Entity<ConfigValidationRuleEntity>()
                .Property(e => e.RuleDescription)
                .IsUnicode(false);

            modelBuilder.Entity<ConfigValidationRuleEntity>()
                .Property(e => e.ValueText)
                .IsUnicode(false);

            modelBuilder.Entity<ConfigValidationRuleEntity>()
                .Property(e => e.ValueSelect)
                .IsUnicode(false);

            modelBuilder.Entity<ConfigValidationRuleEntity>()
                .HasMany(e => e.ConfigValidationRuleLOVs)
                .WithRequired(e => e.ConfigValidationRule)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ContractEntity>()
                .HasMany(e => e.FieldsContracts)
                .WithRequired(e => e.Contract)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<FieldEntity>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<FieldEntity>()
                .Property(e => e.Code)
                .IsUnicode(false);

            modelBuilder.Entity<FieldEntity>()
                .HasMany(e => e.FieldsOffers)
                .WithRequired(e => e.Field)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<FieldEntity>()
                .HasMany(e => e.FieldsProducts)
                .WithRequired(e => e.Field)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<FieldsProductEntity>()
                .Property(e => e.DefaultValue)
                .IsUnicode(false);

            modelBuilder.Entity<FieldsProductEntity>()
                .HasMany(e => e.FieldsContracts)
                .WithRequired(e => e.FieldsProduct)
                .HasForeignKey(e => e.FieldProductId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<OfferEntity>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<OfferEntity>()
                .HasMany(e => e.FieldsOffers)
                .WithRequired(e => e.Offer)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<OfferEntity>()
                .HasMany(e => e.Products)
                .WithRequired(e => e.Offer)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<OperatorEntity>()
                .Property(e => e.Code)
                .IsUnicode(false);

            modelBuilder.Entity<OperatorEntity>()
                .Property(e => e.Label)
                .IsUnicode(false);

            modelBuilder.Entity<OperatorEntity>()
                .Property(e => e.Message)
                .IsUnicode(false);

            modelBuilder.Entity<OperatorEntity>()
                .HasMany(e => e.ConfigValidationRules)
                .WithRequired(e => e.Operator)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ProductEntity>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<ProductEntity>()
                .HasMany(e => e.BaseValidations)
                .WithRequired(e => e.Product)
                .HasForeignKey(e => e.BaseProductId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ProductEntity>()
                .HasMany(e => e.Contracts)
                .WithRequired(e => e.Product)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ProductEntity>()
                .HasMany(e => e.FieldsProducts)
                .WithRequired(e => e.Product)
                .WillCascadeOnDelete(false);
        }
    }
}
