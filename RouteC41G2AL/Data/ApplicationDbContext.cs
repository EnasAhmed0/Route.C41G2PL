using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using RouteC41G2DAL.Data.Cofiguration;
using RouteC41G2DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace RouteC41G2DAL.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
       : base(options)
        {
        }
        //public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options) :base(options) 
        //{

        //}
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Server = .; Database= MVCApplicationG02; Trusted_Connection = True ; MultipleActiveResultsets = False");


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            // modelBuilder.ApplyConfiguration<Department>(new DeparmentConfigurations());
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }


        public  DbSet<Department> Departments { get; set; } 



    }
}
