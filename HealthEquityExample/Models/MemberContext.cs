using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace HealthEquityExample.Models
{
    public class MemberContext : DbContext //, IMemberContext
    {
        public MemberContext(DbContextOptions<MemberContext> options) : base(options)
        {
        }

        public DbSet<Member> Member { get; set; }
    }
}
