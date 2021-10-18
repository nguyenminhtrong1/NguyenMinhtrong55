using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NMT853.Models;

    public class applicationContext : DbContext
    {
        public applicationContext (DbContextOptions<applicationContext> options)
            : base(options)
        {
        }

        public DbSet<NMT853.Models.NMT853> NMT853 { get; set; }
    }
