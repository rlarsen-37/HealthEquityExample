using HealthEquityExample.Models;
using System.Linq;

namespace HealthEquityExampleTests.Models
{
    class TestMemberDbSet : TestDbSet<Member>
    {
        public override Member Find(params object[] keyValues)
        {
            return this.SingleOrDefault(member => member.MemberId == (int)keyValues.Single());
        }
    }
}
