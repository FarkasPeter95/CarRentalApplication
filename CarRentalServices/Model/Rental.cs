namespace CarRentalServices
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Rental")]
    public partial class Rental
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int RentalID { get; set; }

        public int EmployeeID { get; set; }

        public int ReservationID { get; set; }

        [Column(TypeName = "date")]
        public DateTime RentalDate { get; set; }

        public int KmsDriven { get; set; }

        public int Cost { get; set; }

        public int Discount { get; set; }

        public int Total { get; set; }

        public int Advance { get; set; }

        public int Balance { get; set; }

        public int Status { get; set; }

        public virtual Employee Employee { get; set; }

        public virtual Reservation Reservation { get; set; }
    }
}
