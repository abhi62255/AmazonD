using AmazonDream.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace AmazonDream.DAL
{
    public class AmazonDreamDbContext : DbContext
    {
        public AmazonDreamDbContext():base()
        {

        }
        public AmazonDreamDbContext(DbContextOptions<AmazonDreamDbContext> options) : base(options) { }
      
        public virtual DbSet<Seller> Seller { get; set; }
        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<Admin> Admin { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<ProductPicture> ProductPicture { get; set; }
        public virtual DbSet<Entities.Kart> Kart { get; set; }
        public virtual DbSet<Address> Address { get; set; }
        public virtual DbSet<PlacedOrder> PlacedOrder { get; set; }
        public virtual DbSet<City> City { get; set; }
        public virtual DbSet<State> State { get; set; }
        public virtual DbSet<Wishlist> Wishlist { get; set; }
        public virtual DbSet<Feedback> Feedback { get; set; }
        public virtual DbSet<PreVisit> PreVisit { get; set; }
        public virtual DbSet<SearchHistory> SearchHistory { get; set; }











        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseSqlServer(@"Server=XIPL9378\SQLEXPRESS;Database=AmazonDreamDatabase;Trusted_Connection=True;");
    }
}
