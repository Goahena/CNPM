using LiveDinner.Areas.Admin.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace LiveDinner.Models
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        { }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<AdminMenu> AdminMenus { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Inventory> Inventories { get; set; }
        public DbSet<Gallery> galleries { get; set; }
        public DbSet<Category> categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<view_Pro_Cate> view_Pro_Cates { get; set; }
    }
}
