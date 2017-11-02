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
        public DbSet<Questions> Questions { get; set; }
        public DbSet <Answers> Answers { get; set; }

       // public DbSet <Responses> Responses { get; set; } //suggestions to answers



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

        public List<Cosmetic> FindByValue(string value)
        {
            var results = from j in Cosmetics.Include(c=> c.Color)
                          .Include(c => c.Formulation)
                          .Include(c => c.SkinType)
                          .Include(c => c.Rating)
                          .Include(c => c.Finish)
                          .ToList()
                          where j.Color.Contains(value)
                          || j.Finish.Contains(value)
                          || j.Name.ToLower().Contains(value.ToLower())
                          || j.Formulation.Contains(value)
                          || j.Rating.Contains(value)
                          || j.SkinType.Contains(value)
                          select j;

            return results.ToList();
        }


        /**
         * Returns results of search the jobs data by key/value, using
         * inclusion of the search term.
         */
        public List<Cosmetic> FindByColumnAndValue(CosmeticFieldType column, string value)
        {
           IList <Cosmetic> cosmetics = Cosmetics
                .Include(f => f.Finish)
                .Include(c => c.Color)
                .Include(c => c.Formulation)
                .Include(r => r.Rating)
                .Include(s => s.SkinType)
                .ToList();


            var results = from j in cosmetics
                          where GetFieldByType(j, column).Contains(value)
                          select j;

            return results.ToList();
        }

        /**
         * Returns the JobField of the given type from the Job object,
         * for all types other than JobFieldType.All. In this case, 
         * null is returned.
         */
        public static CosmeticField GetFieldByType(Cosmetic cosmetic, CosmeticFieldType type)
        {
            switch (type)
            {
                case CosmeticFieldType.Color:
                    return cosmetic.Color;
                case CosmeticFieldType.Finish:
                    return cosmetic.Finish;
                case CosmeticFieldType.Formulation:
                    return cosmetic.Formulation;
                case CosmeticFieldType.Rating:
                    return cosmetic.Rating;
                case CosmeticFieldType.SkinType:
                    return cosmetic.SkinType;
            }

            throw new ArgumentException("Cannot get field of type: " + type);
        }


        /**
         * Returns the Job with the given ID,
         * if it exists in the store
         */
        public Cosmetic Find(int id)
        {
            var results = from j in Cosmetics
                          where j.ID == id
                          select j;

            return results.Single();
        }



    }  


}
