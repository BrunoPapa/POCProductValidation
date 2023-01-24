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

        public virtual DbSet<BaseProductEntity> BaseProduct { get; set; }
        public virtual DbSet<ConfigVersionEntity> ConfigVersion { get; set; }
        public virtual DbSet<ValidationMessageEntity> ValidationMessage { get; set; }
        public virtual DbSet<ValidationRuleEntity> ValidationRule { get; set; }
        public virtual DbSet<ValidationRuleLOVEntity> ValidationRuleLOV { get; set; }
        public virtual DbSet<ValidationEntity> Validation { get; set; }
        public virtual DbSet<OperatorEntity> Operators { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ConfigVersionEntity>()
                .Property(e => e.OfferName)
                .IsUnicode(false);

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
                .HasMany(e => e.ValidationRule)
                .WithRequired(e => e.Operator)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ValidationEntity>()
                .HasMany(e => e.ValidationMessage)
                .WithRequired(e => e.Validation)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ValidationEntity>()
                .HasMany(e => e.ValidationRule)
                .WithRequired(e => e.Validation)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ValidationMessageEntity>()
                .Property(e => e.Message)
                .IsUnicode(false);

            modelBuilder.Entity<ValidationRuleEntity>()
                .Property(e => e.RuleDescription)
                .IsUnicode(false);

            modelBuilder.Entity<ValidationRuleEntity>()
                .Property(e => e.ValueText)
                .IsUnicode(false);

            modelBuilder.Entity<ValidationRuleEntity>()
                .Property(e => e.ValueSelect)
                .IsUnicode(false);

            modelBuilder.Entity<ValidationRuleEntity>()
                .HasMany(e => e.ValidationRuleLOV)
                .WithRequired(e => e.ValidationRule)
                .WillCascadeOnDelete(false);
        }
    }
}
