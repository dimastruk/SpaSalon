namespace Spa_salon.DAL
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using DbModel;

    public partial class DataContext : DbContext
    {
        public DataContext()
            : base("name=DbConnect")
        {
        }

        public virtual DbSet<Calendar> Calendar { get; set; }
        public virtual DbSet<Clients> Clients { get; set; }
        public virtual DbSet<OrderDetails> OrderDetails { get; set; }
        public virtual DbSet<Orders> Orders { get; set; }
        public virtual DbSet<Positions> Positions { get; set; }
        public virtual DbSet<Salons> Salons { get; set; }
        public virtual DbSet<Services> Services { get; set; }
        public virtual DbSet<Specialities> Specialities { get; set; }
        public virtual DbSet<Workers> Workers { get; set; }
        public virtual DbSet<Workers_schedule> Workers_schedule { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Calendar>()
                .Property(e => e.DayName)
                .IsUnicode(false);

            modelBuilder.Entity<Calendar>()
                .Property(e => e.MonthName)
                .IsUnicode(false);

            modelBuilder.Entity<Calendar>()
                .Property(e => e.Date_Year)
                .IsUnicode(false);

            modelBuilder.Entity<Clients>()
                .Property(e => e.last_name)
                .IsFixedLength();

            modelBuilder.Entity<Clients>()
                .Property(e => e.first_name)
                .IsFixedLength();

            modelBuilder.Entity<Clients>()
                .HasMany(e => e.Orders)
                .WithRequired(e => e.Clients)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Orders>()
                .HasMany(e => e.OrderDetails)
                .WithRequired(e => e.Orders)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Positions>()
                .Property(e => e.position_name)
                .IsFixedLength();

            modelBuilder.Entity<Positions>()
                .HasMany(e => e.Workers)
                .WithRequired(e => e.Positions)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Salons>()
                .Property(e => e.address)
                .IsUnicode(false);

            modelBuilder.Entity<Salons>()
                .HasMany(e => e.Workers)
                .WithRequired(e => e.Salons)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Services>()
                .Property(e => e.service_name)
                .IsUnicode(false);

            modelBuilder.Entity<Services>()
                .HasMany(e => e.Specialities)
                .WithRequired(e => e.Services)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Specialities>()
                .HasMany(e => e.OrderDetails)
                .WithRequired(e => e.Specialities)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Workers>()
                .Property(e => e.last_name)
                .IsFixedLength();

            modelBuilder.Entity<Workers>()
                .Property(e => e.first_name)
                .IsFixedLength();

            modelBuilder.Entity<Workers>()
                .Property(e => e.middle_name)
                .IsFixedLength();

            modelBuilder.Entity<Workers>()
                .Property(e => e.passport_number)
                .IsFixedLength();

            modelBuilder.Entity<Workers>()
                .Property(e => e.address)
                .IsUnicode(false);

            modelBuilder.Entity<Workers>()
                .Property(e => e.login_name)
                .IsFixedLength();

            modelBuilder.Entity<Workers>()
                .HasMany(e => e.Specialities)
                .WithRequired(e => e.Workers)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Workers>()
                .HasMany(e => e.Workers_schedule)
                .WithRequired(e => e.Workers)
                .WillCascadeOnDelete(false);
        }
    }
}