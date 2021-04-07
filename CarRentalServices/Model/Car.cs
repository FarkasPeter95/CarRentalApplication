namespace CarRentalServices.Model
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
            Reservation = new HashSet<Reservation>();
        }

        public int Id { get; set; }

        [StringLength(50)]
        public string LicensePlate { get; set; }

        public int? CategoryId { get; set; }

        public int? LocationId { get; set; }

        [StringLength(128)]
        public string Brand { get; set; }

        [StringLength(128)]
        public string Model { get; set; }

        public int? ProductionYear { get; set; }

        public int? KmClock { get; set; }

        [StringLength(128)]
        public string Fuel { get; set; }

        [StringLength(128)]
        public string Color { get; set; }

        public int? Seats { get; set; }

        [StringLength(128)]
        public string Gearbox { get; set; }

        public int? Horsepower { get; set; }

        public string Image { get; set; }

        public string Remark { get; set; }

        public virtual CarCategory CarCategory { get; set; }

        public virtual Location Location { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Reservation> Reservation { get; set; }
    }
}
