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
        public virtual DbSet<OperatorEntity> Operators { get; set; }
        
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
        }
    }
}
