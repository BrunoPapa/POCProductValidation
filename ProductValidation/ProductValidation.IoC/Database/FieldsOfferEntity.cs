namespace ProductValidation.IoC.Database
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    
    [Table("FieldsOffer")]
    public partial class FieldsOfferEntity
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int FieldId { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int OfferId { get; set; }

        public bool Active { get; set; }

        public DateTime Created { get; set; }

        public virtual FieldEntity Field { get; set; }

        public virtual OfferEntity Offer { get; set; }
    }
}
