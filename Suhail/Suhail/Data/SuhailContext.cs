using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Suhail.Models
{
    public class SuhailContext : DbContext
    {
        public SuhailContext (DbContextOptions<SuhailContext> options)
            : base(options)
        {
        }

        public DbSet<Suhail.Models.Parcel> Parcel { get; set; }
    }
}
