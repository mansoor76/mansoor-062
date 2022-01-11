using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
namespace _062_Mansoor_Crud.Models
{
    public class StoreDB : DbContext
    {
        public StoreDB(DbContextOptions<StoreDB> options) : base(options)
        {
        }
        public DbSet<Orderclass> order_table { get; set; }
    }
}
