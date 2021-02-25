using HealthEquityExample.Models;
using HealthEquityExampleTests.Models;
using Microsoft.EntityFrameworkCore;

namespace HealthEquityExampleTests.Models
{
    class TestMemberContext : IMemberContext
    {
        public TestMemberContext() 
        {
            this.Member = new TestMemberDbSet();
        }
        public DbSet<Member> Member { get; set; }
        public int SaveChangesAsync() { return 0; }
    }
}
