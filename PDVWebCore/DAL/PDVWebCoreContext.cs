using PDVWebCore.Areas.Admin.Models.Customers;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace PDVWebCore.DAL
{
    public class PDVWebCoreContext : DbContext
    {
        public PDVWebCoreContext() : base("PDVWebCoreContext")
        { }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<CustomerRole> CustomerRoles { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Lệnh dùng để đổi tên bảng khi tạo trên DB
            //modelBuilder.Entity<Customer>().ToTable("User");
            //modelBuilder.Entity<IdentityUser>().ToTable("Users", "dbo").Property(p => p.Id).HasColumnName("User_Id");

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Entity<CustomerRole>().HasMany(c => c.Customers).WithMany(i => i.CustomerRoles)
                        .Map(t => t.MapLeftKey("CustomerRoleID")
                        .MapRightKey("Username")
                        .ToTable("CustomerCustomerRole"));
        } 
    }
}