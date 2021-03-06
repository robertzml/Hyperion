﻿using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Hyperion.UnitTest
{
    using Poseidon.Common;
    using Hyperion.ControlClient.Communication;
    using Hyperion.ControlClient.Protocol;

    /// <summary>
    /// 报文测试
    /// </summary>
    [TestClass]
    public class MessageTest
    {
        #region Constructor
        public MessageTest()
        {
            //string host = "http://192.168.0.116:8080/APP";
            string host = "http://121.41.32.14:8080/APP";
            Cache.Instance.Add("EquipmentHost", host);
        }
        #endregion //Constructor

        #region Test
        /// <summary>
        /// 组合报文测试
        /// </summary>
        [TestMethod]
        public void MakeMessageTest()
        {
            string userId = "gh-qc-ios";//Guid.NewGuid().ToString();
            string serialNumber = "G123456789";

            WebControlMessage message = new WebControlMessage(userId, serialNumber);

            var msg = message.GetMessage();

            Console.WriteLine(msg);

            Assert.AreEqual("Homeconsole01.00000000010030004F00060001200340001400010009gh-qc-ios0127000AG123456789001A0001100120009000100010", msg);
        }

        /// <summary>
        /// 注册测试
        /// </summary>
        [TestMethod]
        public void TestRegistration()
        {
            RegistrationMessage message = new RegistrationMessage(1, "admintest", 2334, 0, "1357924680");

            var msg = message.GetMessage();

            var task = Task.Run(() =>
            {
                Request request = new Request();
                var data = request.Post(msg);

                return data;
            });

            var result = task.Result;
            var response = result.Content.ReadAsStringAsync().Result;

            Console.WriteLine($"response message: {response}");

            RegistrationAckMessage ack = new RegistrationAckMessage();
            ack.ParseAck(response);

            Console.WriteLine($"ack result: {TLVCode.ServerReturnCode[ack.ServerResult.Value]}");

            Assert.AreEqual("F", ack.ServerResult.Value);
        }

        /// <summary>
        /// 测试登录
        /// </summary>
        [TestMethod]
        public void TestLogin()
        {
            LoginMessage message = new LoginMessage("123456aaa", 39, 1, "EFF17490-1D6E-41B0-BC12-ED8192A473B7", 1, 1);
            var msg = message.GetMessage();
            Console.WriteLine($"send message: {msg}");

            var task = Task.Run(() =>
            {
                Request request = new Request();
                var data = request.Post(msg);

                return data;
            });

            var result = task.Result;
            var response = result.Content.ReadAsStringAsync().Result;

            Console.WriteLine($"response message: {response}");
            Assert.IsTrue(response.Length > 0);

            LoginAckMessage ack = new LoginAckMessage();

            ack.ParseAck(response);

            Console.WriteLine($"ack result: {TLVCode.ServerReturnCode[ack.ServerResult.Value]}");
            Assert.AreEqual("0", ack.ServerResult.Value);
        }

        /// <summary>
        /// 注销测试
        /// </summary>
        [TestMethod]
        public void TestLogout()
        {
            LogoutMessage message = new LogoutMessage(0, "17858655030", "1234567890");
            var msg = message.GetMessage();
            Console.WriteLine($"send message: {msg}");

            var task = Task.Run(() =>
            {
                Request request = new Request();
                var data = request.Post(msg);

                return data;
            });

            var result = task.Result;
            var response = result.Content.ReadAsStringAsync().Result;

            Console.WriteLine($"response message: {response}");
            Assert.IsTrue(response.Length > 0);

            LogoutAckMessage ack = new LogoutAckMessage();

            ack.ParseAck(response);

            Console.WriteLine($"ack result: {TLVCode.ServerReturnCode[ack.ServerResult.Value]}");
            Assert.AreEqual("0", ack.ServerResult.Value);
        }

        /// <summary>
        /// 测试设备列表
        /// </summary>
        [TestMethod]
        public void TestDeviceList()
        {
            DeviceListMessage message = new DeviceListMessage(0, "17858655030", "1234567890", 4, 3, "roomstatus", 1);
            var msg = message.GetMessage();
            Console.WriteLine($"send message: {msg}");

            var task = Task.Run(() =>
            {
                Request request = new Request();
                var data = request.Post(msg);

                return data;
            });

            var result = task.Result;
            var response = result.Content.ReadAsStringAsync().Result;

            Console.WriteLine($"response message: {response}");
            Assert.IsTrue(response.Length > 0);

            DeviceListAckMessage ack = new DeviceListAckMessage();

            ack.ParseAck(response);

            Console.WriteLine($"ack result: {TLVCode.ServerReturnCode[ack.ServerResult.Value]}");
            Assert.AreEqual("0", ack.ServerResult.Value);

            Assert.AreEqual(1, ack.DeviceListNode.DeviceCount);
        }

        /// <summary>
        /// 测试增加设备
        /// </summary>
        [TestMethod]
        public void TestUnifiedAdd()
        {
            UnifiedMessage message = new UnifiedMessage("17858655030", "1234567890", 4, 3, "TEST", "0000", "qwerty", "");
            var msg = message.GetMessage();
            Console.WriteLine($"send message: {msg}");

            var task = Task.Run(() =>
            {
                Request request = new Request();
                var data = request.Post(msg);

                return data;
            });

            var result = task.Result;
            var response = result.Content.ReadAsStringAsync().Result;

            Console.WriteLine($"response message: {response}");
            Assert.IsTrue(response.Length > 0);

            UnifiedAckMessage ack = new UnifiedAckMessage();

            ack.ParseAck(response);

            Console.WriteLine($"ack result: {TLVCode.ServerReturnCode[ack.ServerResult.Value]}");
            Assert.AreEqual("0", ack.ServerResult.Value);

            Assert.AreEqual("qwerty", ack.UnifiedNode.SerialNumber);
        }

        /// <summary>
        /// 修改设备
        /// </summary>
        [TestMethod]
        public void TestUnifiedEdit()
        {
            UnifiedMessage message = new UnifiedMessage("17858655030", "1234567890", "TEST07123", "qwerty");
            var msg = message.GetMessage();
            Console.WriteLine($"send message: {msg}");

            var task = Task.Run(() =>
            {
                Request request = new Request();
                var data = request.Post(msg);

                return data;
            });

            var result = task.Result;
            var response = result.Content.ReadAsStringAsync().Result;

            Console.WriteLine($"response message: {response}");
            Assert.IsTrue(response.Length > 0);

            UnifiedAckMessage ack = new UnifiedAckMessage();

            ack.ParseAck(response);

            Console.WriteLine($"ack result: {TLVCode.ServerReturnCode[ack.ServerResult.Value]}");
            Assert.AreEqual("0", ack.ServerResult.Value);

            Assert.AreEqual(7, ack.UnifiedNode.UnifiedCode);
        }

        /// <summary>
        /// 删除设备
        /// </summary>
        [TestMethod]
        public void TestUnifiedDelete()
        {
            UnifiedMessage message = new UnifiedMessage("17858655030", "1234567890", "qwerty");
            var msg = message.GetMessage();
            Console.WriteLine($"send message: {msg}");

            var task = Task.Run(() =>
            {
                Request request = new Request();
                var data = request.Post(msg);

                return data;
            });

            var result = task.Result;
            var response = result.Content.ReadAsStringAsync().Result;

            Console.WriteLine($"response message: {response}");
            Assert.IsTrue(response.Length > 0);

            UnifiedAckMessage ack = new UnifiedAckMessage();

            ack.ParseAck(response);

            Console.WriteLine($"ack result: {TLVCode.ServerReturnCode[ack.ServerResult.Value]}");
            Assert.AreEqual("0", ack.ServerResult.Value);

            Assert.AreEqual(8, ack.UnifiedNode.UnifiedCode);
        }

        [TestMethod]
        public void TestLoginMessage()
        {
            string message = "Homeconsole01.00000000010003006500010006wxhcdz001B00080000004100070001100040024D10CB87E-8B67-46C3-B62E-C56597E6C505001A00011001C00011";
            var task = Task.Run(() =>
            {
                Request request = new Request();
                var data = request.Post(message);

                return data;
            });

            var result = task.Result;
            var content = result.Content.ReadAsStringAsync().Result;

            Console.WriteLine(content);
            Assert.AreNotEqual(0, content.Length);
        }
        #endregion //Test
    }
}
