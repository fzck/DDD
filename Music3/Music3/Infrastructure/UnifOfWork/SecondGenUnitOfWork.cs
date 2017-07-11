using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;


using System.Data.Common;
using Music3.Domain.ArtistAgg;
using Music3.Domain.AlbumAgg;
using Music3.Domain.TrackAgg;
using Music3.Domain.PersonAgg;

namespace Music3.Infrastructure.UnitOfWork
{
    public class SecondGenUnitOfWork : DbContext, IUnitOfWork
    {
        public DbSet<Person> Persons { get; set; }

       
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
