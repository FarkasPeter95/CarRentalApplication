namespace CarRentalServices.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Rental")]
    public partial class Rental
    {
        public int Id { get; set; }

        public int? EmployeeId { get; set; }

        public int? ReservationId { get; set; }

        [Column(TypeName = "timestamp")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [MaxLength(8)]
        public byte[] RentalCreate { get; set; }

        public int? KmsDriven { get; set; }

        public decimal? Cost { get; set; }

        public decimal? Discount { get; set; }

        public decimal? Total { get; set; }

        public decimal? Advance { get; set; }

        public bool? Status { get; set; }

        public virtual Employee Employee { get; set; }

        public virtual Reservation Reservation { get; set; }
    }
}
