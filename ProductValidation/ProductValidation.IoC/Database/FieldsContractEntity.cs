namespace ProductValidation.IoC.Database
{
    using ProductValidation.IoC.Interface.Database;
    using System;
    using System.ComponentModel.DataAnnotations.Schema;
    
    [Table("FieldsContract")]
    public partial class FieldsContractEntity : IEntity
    {
        public int Id { get; set; }

        public int FieldProductId { get; set; }

        public int ContractId { get; set; }

        public string Value { get; set; }

        public bool Active { get; set; }

        public DateTime Created { get; set; }

        public virtual ContractEntity Contract { get; set; }

        public virtual FieldsProductEntity FieldsProduct { get; set; }
    }
}
