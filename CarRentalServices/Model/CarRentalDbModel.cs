namespace CarRentalServices
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class CarRentalDbModel : DbContext
    {
        public CarRentalDbModel()
            : base("name=CarRentalDbModel")
        {
        }

        public virtual DbSet<Car> Car { get; set; }
        public virtual DbSet<CarCategory> CarCategory { get; set; }
        public virtual DbSet<Client> Client { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<Location> Location { get; set; }
        public virtual DbSet<Rental> Rental { get; set; }
        public virtual DbSet<Reservation> Reservation { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Car>()
            //    .HasMany(e => e.Reservation)
            //    .WithRequired(e => e.Car)
            //    .WillCascadeOnDelete(false);

            //modelBuilder.Entity<CarCategory>()
            //    .HasMany(e => e.Car)
            //    .WithRequired(e => e.CarCategory)
            //    .WillCascadeOnDelete(false);

            modelBuilder.Entity<Client>()
                .Property(e => e.IdCardNumber)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Client>()
                .Property(e => e.ZipCode)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Client>()
                .Property(e => e.PhoneNumber)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Client>()
                .Property(e => e.PasswordHash)
                .IsFixedLength();

            modelBuilder.Entity<Client>()
                .HasMany(e => e.Reservation)
                .WithRequired(e => e.Client)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.PasswordHash)
                .IsFixedLength();

            modelBuilder.Entity<Employee>()
                .Property(e => e.PhoneNumber)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .HasMany(e => e.Rental)
                .WithRequired(e => e.Employee)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Location>()
                .Property(e => e.ZipCode)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Location>()
                .Property(e => e.PhoneNumber)
                .IsFixedLength()
                .IsUnicode(false);

            //modelBuilder.Entity<Location>()
            //    .HasMany(e => e.Car)
            //    .WithRequired(e => e.Location)
            //    .WillCascadeOnDelete(false);

            modelBuilder.Entity<Location>()
                .HasMany(e => e.Reservation)
                .WithRequired(e => e.Location)
                .HasForeignKey(e => e.DropOffLocationID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Location>()
                .HasMany(e => e.Reservation1)
                .WithRequired(e => e.Location1)
                .HasForeignKey(e => e.PickUpLocationID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Reservation>()
                .HasMany(e => e.Rental)
                .WithRequired(e => e.Reservation)
                .WillCascadeOnDelete(false);
        }
    }
}
