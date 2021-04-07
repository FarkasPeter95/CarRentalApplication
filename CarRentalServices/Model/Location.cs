namespace CarRentalServices.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Location")]
    public partial class Location
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Location()
        {
            Car = new HashSet<Car>();
            Reservation = new HashSet<Reservation>();
            Reservation1 = new HashSet<Reservation>();
        }

        public int Id { get; set; }

        [StringLength(128)]
        public string LocationName { get; set; }

        [StringLength(50)]
        public string ZipCode { get; set; }

        [StringLength(30)]
        public string City { get; set; }

        [StringLength(128)]
        public string AdressLine1 { get; set; }

        [StringLength(128)]
        public string AdressLine2 { get; set; }

        [StringLength(50)]
        public string PhoneNumber { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Car> Car { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Reservation> Reservation { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Reservation> Reservation1 { get; set; }
    }
}
