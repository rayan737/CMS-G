using CMSG.DAL.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMSG.DAL.DataBase
{
    //public class dbContainer:DbContext
    public class dbContainer :IdentityDbContext
 
    {
        public dbContainer(DbContextOptions<dbContainer> opts) : base(opts)
        {

        }
        public DbSet<Department> Department { get; set; }
        public DbSet<Employee> Employee { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("server = . ; database = CMSG ; integrated security = true");
        //}
    }
}
