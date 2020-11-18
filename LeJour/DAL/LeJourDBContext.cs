using System;
using System.IO;
using LeJour.DataModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

namespace LeJour.DAL
{
    public partial class LeJourDBContext : DbContext
    {
        public LeJourDBContext()
        {

        }

        public LeJourDBContext(DbContextOptions<LeJourDBContext> options) : base(options)
        {

        }

        public virtual DbSet<TbAppointment> TbAppointment { get; set; }
        public virtual DbSet<TbInvoice> TbInvoice { get; set; }
        public virtual DbSet<TbUser> TbUser { get; set; }
        public virtual DbSet<TbWedding> TbWedding { get; set; }
        public virtual DbSet<TbWeddingFavorites> TbWeddingFavorites { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                   .SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("appsettings.json")
                   .Build();
                var connectionString = configuration.GetConnectionString("lejourAzure");
                optionsBuilder.UseSqlServer(connectionString);
            }
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TbAppointment>(entity =>
            {
                entity.Property(e => e.idAppointment)
                    .HasColumnName("idAppointment")
                    .HasMaxLength(10);

                entity.Property(e => e.idWedding)
                    .HasColumnName("idWedding")
                    .HasMaxLength(10);

                entity.Property(e => e.idVendor)
                    .HasColumnName("idVendor")
                    .HasMaxLength(10);

                entity.Property(e => e.dsCategoryVendor)
                    .HasColumnName("dsCategoryVendor")
                    .HasMaxLength(100);

                entity.Property(e => e.dtAppointment)
                    .HasColumnName("dtAppointment")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<TbInvoice>(entity =>
            {
                entity.Property(e => e.idInvoice)
                    .HasColumnName("idInvoice")
                    .HasMaxLength(10);

                entity.Property(e => e.idWedding)
                    .HasColumnName("idWedding")
                    .HasMaxLength(10);

                entity.Property(e => e.idVendor)
                    .HasColumnName("idVendor")
                    .HasMaxLength(10);

                entity.Property(e => e.vlAmount)
                    .HasColumnName("vlAmount")
                    .HasMaxLength(100);

                entity.Property(e => e.vlAmountVendor)
                    .HasColumnName("vlAmountVendor")
                    .HasMaxLength(50);

                entity.Property(e => e.dtCreated)
                    .HasColumnName("dtCreated")
                    .HasMaxLength(10);

                entity.Property(e => e.dsAccepted)
                    .HasColumnName("dsAccepted")
                    .HasMaxLength(100);

                entity.Property(e => e.dsCategoryVendor)
                    .HasColumnName("dsCategoryVendor")
                    .HasMaxLength(50);
            });


            modelBuilder.Entity<TbUser>(entity =>
            {
                entity.Property(e => e.idUser)
                    .HasColumnName("idUser")
                    .HasMaxLength(100);

                entity.Property(e => e.dtCreated)
                    .HasColumnName("dtCreated")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<TbWedding>(entity =>
            {
                entity.Property(e => e.idWedding)
                    .HasColumnName("idWedding")
                    .HasMaxLength(10);

                entity.Property(e => e.idUser)
                    .HasColumnName("idUser")
                    .HasMaxLength(10);

                entity.Property(e => e.vlBudget)
                    .HasColumnName("vlBudget")
                    .HasMaxLength(100);

                entity.Property(e => e.dtWedding)
                    .HasColumnName("dtWedding")
                    .HasMaxLength(50);

                entity.Property(e => e.nmGuests)
                    .HasColumnName("nmGuests")
                    .HasMaxLength(10);

                entity.Property(e => e.dsStyle)
                    .HasColumnName("dsStyle")
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<TbWeddingFavorites>(entity =>
            {
                entity.Property(e => e.idWedding)
                    .HasColumnName("idWedding")
                    .HasMaxLength(10);

                entity.Property(e => e.idVendor)
                    .HasColumnName("idVendor")
                    .HasMaxLength(100);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}