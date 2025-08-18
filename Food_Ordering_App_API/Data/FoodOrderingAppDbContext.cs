namespace Food_Ordering_App_API.Data
{
    using global::Food_Ordering_App_API.Models;
    using Microsoft.EntityFrameworkCore;

    namespace Food_Ordering_App_API.Models
    {
        public class FoodOrderingAppDbContext : DbContext
        {
            public FoodOrderingAppDbContext(DbContextOptions<FoodOrderingAppDbContext> options)
                : base(options)
            {
            }

            public virtual DbSet<User> Users { get; set; }
            public virtual DbSet<UserRole> UserRoles { get; set; }
            public virtual DbSet<Menu> Menus { get; set; }
            public virtual DbSet<MenuItem> MenuItems { get; set; }
            public virtual DbSet<Order> Orders { get; set; }
            public virtual DbSet<OrderItem> OrderItems { get; set; }
            public virtual DbSet<DeliveryPartner> DeliveryPartners { get; set; }
            public virtual DbSet<DiscountRule> DiscountRules { get; set; }

            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                modelBuilder.Entity<UserRole>()
                    .HasData(new UserRole { RoleId = 1, Role = Role.ADMIN },
                    new UserRole { RoleId = 2, Role = Role.MEMBER });
            }
        }
    }

}
