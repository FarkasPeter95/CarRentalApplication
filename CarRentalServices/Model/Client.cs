namespace CarRentalServices
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

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ClientID { get; set; }

        [Required]
        [StringLength(8)]
        public string IdCardNumber { get; set; }

        [Required]
        [StringLength(50)]
        public string FullName { get; set; }

        [Column(TypeName = "date")]
        public DateTime Birthdate { get; set; }

        [Required]
        [StringLength(10)]
        public string ZipCode { get; set; }

        [Required]
        [StringLength(30)]
        public string City { get; set; }

        [Required]
        [StringLength(50)]
        public string Adress { get; set; }

        [Required]
        [StringLength(12)]
        public string PhoneNumber { get; set; }

        [Required]
        [StringLength(50)]
        public string LicenseNumber { get; set; }

        [Column(TypeName = "date")]
        public DateTime LicenseIssueDate { get; set; }

        [StringLength(50)]
        public string UserName { get; set; }

        [MaxLength(64)]
        public byte[] PasswordHash { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Salt { get; set; }

        [Required]
        [StringLength(50)]
        public string EmailAdress { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Reservation> Reservation { get; set; }
    }
}
