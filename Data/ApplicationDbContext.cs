using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Nhom15.Models;

namespace Nhom15.Data
{
    public class ApplicationDbcontext:DbContext
    {
        public ApplicationDbcontext (DbContextOptions<ApplicationDbcontext> options):base(options)
        {
        }
        public DbSet<Nhom15.Models.Customer>? Customer { get; set; } =default!;
        public DbSet<Nhom15.Models.TTNV>? TTNV { get; set; } =default!;
        public DbSet<Nhom15.Models.TTDC>? TTDC { get; set; }
        
    }
}
