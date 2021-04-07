namespace CarRentalServices.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Client")]
    public partial class Client
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Client()
        {
            Reservation = new HashSet<Reservation>();
        }

        public int Id { get; set; }

        [StringLength(50)]
        public string IdCardNumber { get; set; }

        [StringLength(128)]
        public string FirstName { get; set; }

        [StringLength(128)]
        public string SurName { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Birthdate { get; set; }

        [StringLength(50)]
        public string ZipCode { get; set; }

        [StringLength(128)]
        public string City { get; set; }

        [StringLength(128)]
        public string AdressLine1 { get; set; }

        [StringLength(128)]
        public string AdressLine2 { get; set; }

        [StringLength(50)]
        public string PhoneNumber { get; set; }

        [StringLength(50)]
        public string LicenseNumber { get; set; }

        [Column(TypeName = "date")]
        public DateTime? LicenseIssueDate { get; set; }

        [StringLength(50)]
        public string UserName { get; set; }

        [StringLength(128)]
        public string PasswordHash { get; set; }

        [StringLength(128)]
        public string Salt { get; set; }

        [StringLength(128)]
        public string EmailAdress { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Reservation> Reservation { get; set; }
    }
}
