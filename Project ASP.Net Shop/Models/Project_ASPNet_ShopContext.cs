using System.Data.Entity;

namespace Project_ASP.Net_Shop.Models
{
    public class Project_ASPNet_ShopContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public Project_ASPNet_ShopContext() : base("name=Project_ASPNet_ShopContext")
        {
        }

        public DbSet<Products> Products { get; set; }
        public DbSet<Contact> Contact { get; set; }
    }
}
