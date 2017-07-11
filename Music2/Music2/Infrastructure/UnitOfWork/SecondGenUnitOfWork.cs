using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;


using System.Data.Common;
using Music2.Domain.ArtistAgg;
using Music2.Domain.AlbumAgg;
using Music2.Domain.TrackAgg;
using Music2.Domain.PersonAgg;

namespace Music2.Infrastructure.UnitOfWork
{
    public class SecondGenUnitOfWork : DbContext, IUnitOfWork
    {
        public DbSet<Person> Persons { get; set; }
        public DbSet<Album> Albums { get; set; }
        public DbSet <Track> Tracks { get; set; }
       
        public SecondGenUnitOfWork(DbContextOptions<SecondGenUnitOfWork> options):base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Person>(person =>
            {
                person.HasKey("Id");
                person.Property("Id").HasColumnName("id");
                person.Property("Firstname").HasColumnName("firstname");
                person.Property("Lastname").HasColumnName("lastname");
                person.Property(p => p.ConcurrencyStamp).ForNpgsqlHasColumnName("xmin").ForNpgsqlHasColumnType("xid").ValueGeneratedOnAddOrUpdate().IsConcurrencyToken();
                person.Ignore("DisplayName");
                person.ToTable("person");
            });

            builder.Entity<Album>(album =>
            {
                album.HasKey("Id");
                album.Property("Id").HasColumnName("id");
                album.Property("Title").HasColumnName("title");
                album.Property("YearReleased").HasColumnName("year_released");
                album.Property(p => p.ConcurrencyStamp).ForNpgsqlHasColumnName("xmin").ForNpgsqlHasColumnType("xid").ValueGeneratedOnAddOrUpdate().IsConcurrencyToken();
                album.ToTable("album");
            });

            builder.Entity<Track>(track =>
            {
                track.HasKey("Id");
                track.Property("Id").HasColumnName("id");
                track.Property("Title").HasColumnName("title");
                track.Property("DateReleased").HasColumnName("date_released");
                track.Property (p => p.ConcurrencyStamp).ForNpgsqlHasColumnName("xmin").ForNpgsqlHasColumnType("xid").ValueGeneratedOnAddOrUpdate().IsConcurrencyToken();
                track.ToTable("track");
            });
            
            base.OnModelCreating(builder);
        }

        public void Commit()
        {
            SaveChanges();
        }

        public void Rollback()
        {
            Dispose();
        }
    }
}
