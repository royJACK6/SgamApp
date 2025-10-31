using Microsoft.EntityFrameworkCore;
using SgamApp.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SgamApp.DAL
{
    public class SgamAppDbContext : DbContext
    {
        public SgamAppDbContext(DbContextOptions<SgamAppDbContext> options) : base(options)
        {
        }

        public DbSet<Glossary> Dictonaries { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
