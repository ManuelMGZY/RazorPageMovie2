using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RazorPageMovie2.Models;

namespace RazorPageMovie2.Data
{
    public class RazorPageMovie2Context : DbContext
    {
        public RazorPageMovie2Context (DbContextOptions<RazorPageMovie2Context> options)
            : base(options)
        {
        }

        public DbSet<RazorPageMovie2.Models.Movie> Movie { get; set; } = default!;
    }
}
