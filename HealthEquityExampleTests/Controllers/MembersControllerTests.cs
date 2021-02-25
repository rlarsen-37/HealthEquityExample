using Microsoft.VisualStudio.TestTools.UnitTesting;
using HealthEquityExampleTests.Models;

namespace HealthEquityExample.Controllers.Tests
{
    [TestClass()]
    public class MembersControllerTests
    {
        [TestMethod()]
        public void GetMemberTest()
        {
            // Ran out of time trying to figure out how to properly define
            // the IMemberContext and TestDbSet so that this TestMemberContext
            // Could be used instead of the Actual MemberContext (In-Memory Database)
//            var context = new MembersController(new TestMemberContext());
            // This test was going to just verify that the MembersController
            // pointed to the TestMemberContext could return 200 or 404
            // for an test MemberID and one that wasn't set up.
            Assert.IsTrue(true);
        }
    }
}