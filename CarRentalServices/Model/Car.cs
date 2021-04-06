namespace CarRentalServices
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Car")]
    public partial class Car
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Car()
        {
            //Reservation = new HashSet<Reservation>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CarID { get; set; }

        [Required]
        [StringLength(10)]
        public string LicensePlate { get; set; }

        public int CategoryID { get; set; }

        public int LocationID { get; set; }

        [Required]
        [StringLength(50)]
        public string Brand { get; set; }

        [Required]
        [StringLength(50)]
        public string Model { get; set; }

        public int ProductionYear { get; set; }

        public int KmClock { get; set; }

        [Required]
        [StringLength(20)]
        public string Fuel { get; set; }

        [Required]
        [StringLength(50)]
        public string Color { get; set; }

        public int Seats { get; set; }

        [Required]
        [StringLength(20)]
        public string Gearbox { get; set; }

        public int Horsepower { get; set; }

        [Required]
        public string Image { get; set; }

        //public virtual CarCategory CarCategory { get; set; }

        //public virtual Location Location { get; set; }

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<Reservation> Reservation { get; set; }
    }
}
