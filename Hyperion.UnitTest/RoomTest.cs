using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Hyperion.UnitTest
{
    using Poseidon.Base.Framework;
    using Poseidon.Base.System;
    using Poseidon.Common;
    using Hyperion.Core.BL;
    using Hyperion.Core.DL;

    [TestClass]
    public class RoomTest
    {
        public RoomTest()
        {
            GlobalAction.Initialize();
        }

        [TestMethod]
        public void TestFindOne()
        {
            int userid = 12;
            int homeid = 1;
            int roomid = 1;

            var room = BusinessFactory<RoomBusiness>.Instance.FindOne(userid, homeid, roomid);

            Assert.AreEqual(5, room.RoomType);
        }

        [TestMethod]
        public void TestFindInHome()
        {
            int userid = 283;
            int homeid = 1;

            var rooms = BusinessFactory<RoomBusiness>.Instance.FindInHome(userid, homeid).ToList();
            Assert.AreEqual(5, rooms.Count);
        }

        [TestMethod]
        public void TestFindByUser()
        {
            int userid = 251;

            var rooms = BusinessFactory<RoomBusiness>.Instance.FindByUser(userid).ToList();
            Assert.AreEqual(5, rooms.Count);
        }
    }
}
