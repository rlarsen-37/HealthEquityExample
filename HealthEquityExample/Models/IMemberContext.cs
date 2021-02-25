using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace HealthEquityExample.Models
{
    public interface IMemberContext
    {
        DbSet<Member> Member { get; }
        int SaveChangesAsync();
    }
}
