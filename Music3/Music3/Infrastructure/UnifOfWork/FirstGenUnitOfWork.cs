using Music3.Domain.PartyAgg;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;


namespace Music3.Infrastructure.UnitOfWork
{
    public class FirstGenUnitOfWork : DbContext, IUnitOfWork
    {
        
        public DbSet<Party> Parties { get; set; }
        

        public FirstGenUnitOfWork(DbContextOptions<FirstGenUnitOfWork> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
           

            builder.Entity<Party>(party =>
            {
                party.HasKey("Id");
                party.Property("Id").HasColumnName("id");
                party.Property("DisplayName").HasColumnName("display_name");
                party.ToTable("party");
                party.Property(p => p.ConcurrencyStamp).ForNpgsqlHasColumnName("xmin").ForNpgsqlHasColumnType("xid").ValueGeneratedOnAddOrUpdate().IsConcurrencyToken();
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
