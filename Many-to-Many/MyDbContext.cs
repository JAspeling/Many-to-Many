using ManytoMany.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManytoMany
{
    public class MyDbContext : DbContext
    {
        
        public DbSet<Person> People { get; set; }
        public DbSet<PersonPerson> PersonPerson { get; set; }
        public IConfiguration Configuration { get; }

        public MyDbContext(IConfiguration configuration) {
            Configuration = configuration;
        }

        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            if (!optionsBuilder.IsConfigured) {
                optionsBuilder.UseSqlServer(Configuration.GetConnectionString("Default"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<PersonPerson>().HasKey(pp => new { pp.PersonID, pp.FriendID });

            modelBuilder.Entity<PersonPerson>()
                .HasOne<Person>(pp => pp.Person)
                .WithMany(p => p.PersonPerson)
                .HasForeignKey(pp => pp.PersonID);

            modelBuilder.Entity<PersonPerson>()
                .HasOne<Person>(pp => pp.Friend)
                .WithMany(p => p.PersonPerson)
                .HasForeignKey(pp => pp.FriendID);
        }
    }
}
