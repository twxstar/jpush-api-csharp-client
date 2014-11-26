﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;
using cn.jpush.api.push.mode;


namespace cn.jpush.api.test
{
    [TestClass]
    public class PushClientTest:BaseTest
    {
        [TestMethod]
        public void test_invalid_json()
        {
            JPushClient pushClient = new JPushClient(APP_KEY, MASTER_SECRET);
            try
            {
                pushClient.SendPush("{aaa:'a}");
            }
            catch(ArgumentException e)
            {
                Debug.WriteLine(e.Message);
            }
            catch (Exception e)
            {
                Assert.AreEqual(e.GetType().ToString(), "Newtonsoft.Json.JsonReaderException");
            }

        }
        [TestMethod]
        public void test_empty_string()
        {
            JPushClient pushClient = new JPushClient(APP_KEY, MASTER_SECRET);
            try
            {
                pushClient.SendPush("");
            }
            catch (ArgumentException e)
            {
                Debug.WriteLine(e.Message);
            }
        }
        [TestMethod]
        public void test_validate()
        {
            JPushClient pushClient = new JPushClient(APP_KEY, MASTER_SECRET);
            try
            {
                var result = pushClient.SendPush(PushPayload.AlertAll("alert"));
                Assert.IsTrue(result.isResultOK());
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }
        }


    }
}
