#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace REDar.Models
{
    public class REDarDataContext : DbContext
    {
        public REDarDataContext (DbContextOptions<REDarDataContext> options)
            : base(options)
        {
        }

        public DbSet<REDar.Models.UserMeasurement> UserMeasurement { get; set; }
    }
}
