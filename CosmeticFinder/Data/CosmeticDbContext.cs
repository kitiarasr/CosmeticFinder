using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CosmeticFinder.Models;

namespace CosmeticFinder.Data
{
    public class CosmeticDbContext : DbContext
    {
        public DbSet<Cosmetic> Cosmetics { get; set; }
        public DbSet<CosmeticBag_Items> CosmeticBag_Items {get; set;}
        public DbSet<CosmeticBag> CosmeticBags { get; set; }

        public DbSet<Finish> Finishs { get; set; }
        public DbSet<Formulation> Formulations { get; set; }
        public DbSet<Rating> Ratings { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<SkinType> SkinTypes { get; set; }



        public CosmeticDbContext(DbContextOptions<CosmeticDbContext> options)
            : base(options)
        { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CosmeticBag_Items>()
                .HasKey(c => new { c.CosmeticID, c.CosmeticBagID });
            //onmodelcreating is essentially a constructor for the instance of a context class.
            //I am making a composite ID out of these two ids (my join class (the cosmetic_items one)
            //does not contain a primary key. I am making a combination of two keys called a composite key
            //to make ONE PRIMARY KEY
        }





    }  


}
