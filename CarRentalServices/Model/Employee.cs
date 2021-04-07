namespace CarRentalServices.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Employee")]
    public partial class Employee
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Employee()
        {
            Rental = new HashSet<Rental>();
        }

        public int Id { get; set; }

        [StringLength(128)]
        public string FirstName { get; set; }

        [StringLength(128)]
        public string SurName { get; set; }

        [StringLength(128)]
        public string UserName { get; set; }

        [StringLength(128)]
        public string PasswordHash { get; set; }

        [StringLength(128)]
        public string Salt { get; set; }

        [StringLength(50)]
        public string PhoneNumber { get; set; }

        [StringLength(128)]
        public string EmailAdress { get; set; }

        public bool? AdminStatus { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Rental> Rental { get; set; }
    }
}
