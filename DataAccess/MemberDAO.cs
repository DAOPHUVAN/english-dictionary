using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using BusinessObject;
namespace DataAccess
{
    public partial class MemberDAO : DbContext
    {
        public MemberDAO() { }
        public MemberDAO(DbContextOptions<MemberDAO> options) : base(options) { }
        public virtual DbSet<Member> Member { get; set; }
        public virtual DbSet<Order1> IOrder { get; set; }
        public virtual DbSet<OrderDetail> OrderDetail { get; set; }
        public virtual DbSet<Product> Product { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            IConfigurationRoot configuration = builder.Build();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("FstoreCompanyDB"));
        }


    }
}
