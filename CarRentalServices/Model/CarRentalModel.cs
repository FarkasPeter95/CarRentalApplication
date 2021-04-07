namespace CarRentalServices.Model
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class CarRentalModel : DbContext
    {
        public CarRentalModel()
            : base("name=CarRentalModel")
        {
        }

        public virtual DbSet<Car> Car { get; set; }
        public virtual DbSet<CarCategory> CarCategory { get; set; }
        public virtual DbSet<Client> Client { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<Location> Location { get; set; }
        public virtual DbSet<Rental> Rental { get; set; }
        public virtual DbSet<Reservation> Reservation { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CarCategory>()
                .HasMany(e => e.Car)
                .WithOptional(e => e.CarCategory)
                .HasForeignKey(e => e.CategoryId);

            modelBuilder.Entity<Client>()
                .Property(e => e.IdCardNumber)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Client>()
                .Property(e => e.ZipCode)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Location>()
                .Property(e => e.ZipCode)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Location>()
                .HasMany(e => e.Reservation)
                .WithOptional(e => e.Location)
                .HasForeignKey(e => e.DropOffLocationId);

            modelBuilder.Entity<Location>()
                .HasMany(e => e.Reservation1)
                .WithOptional(e => e.Location1)
                .HasForeignKey(e => e.PickUpLocationId);

            modelBuilder.Entity<Rental>()
                .Property(e => e.RentalCreate)
                .IsFixedLength();

            modelBuilder.Entity<Rental>()
                .Property(e => e.Discount)
                .HasPrecision(5, 2);
        }
    }
}
