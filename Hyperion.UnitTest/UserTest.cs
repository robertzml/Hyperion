using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Hyperion.UnitTest
{
    using Poseidon.Base.Framework;
    using Poseidon.Base.System;
    using Poseidon.Common;
    using Hyperion.Core.BL;
    using Hyperion.Core.DL;

    [TestClass]
    public class UserTest
    {
        public UserTest()
        {
            GlobalAction.Initialize();
        }

        [TestMethod]
        public void TestFind()
        {
            var user = BusinessFactory<UserInfoBusiness>.Instance.FindById(19);

            Assert.AreEqual("admin", user.UserName);
            Assert.AreEqual("AUPU", user.Vendor);
            Assert.IsTrue(string.IsNullOrEmpty(user.ParentUserName));
        }

        /// <summary>
        /// 测试null字段
        /// </summary>
        [TestMethod]
        public void TestFindNullField()
        {
            var user = BusinessFactory<UserInfoBusiness>.Instance.FindById(19);
            Assert.IsNull(user.Email);
        }

        [TestMethod]
        public void TestChangePassword()
        {
            int id = 19;
            string old = Hasher.MD5Encrypt("123").ToUpper();
            string newpass = Hasher.MD5Encrypt("123").ToUpper();

            bool result = BusinessFactory<UserInfoBusiness>.Instance.ChangePassword(id, old, newpass);

            Assert.AreEqual(true, result);

            var user = BusinessFactory<UserInfoBusiness>.Instance.FindById(id);
            Assert.AreEqual(newpass, user.Password);
        }

        [TestMethod]
        public void TestEdit()
        {
            int id = 19;
            var user = BusinessFactory<UserInfoBusiness>.Instance.FindById(id);

            user.PhoneNumber = "139123456";
            bool result = BusinessFactory<UserInfoBusiness>.Instance.Update(user);
            Assert.AreEqual(true, result);

            var user2 = BusinessFactory<UserInfoBusiness>.Instance.FindById(id);

            Assert.AreEqual("139123456", user2.PhoneNumber);
        }

        [TestMethod]
        public void TestDelete()
        {
            int id = 20;

            var user = BusinessFactory<UserInfoBusiness>.Instance.FindById(id);
            if (user != null)
            {
                bool result = BusinessFactory<UserInfoBusiness>.Instance.Delete(user);
                Assert.IsTrue(result);

                var user2 = BusinessFactory<UserInfoBusiness>.Instance.FindById(id);
                Assert.IsNull(user2);
            }
        }
    }
}
