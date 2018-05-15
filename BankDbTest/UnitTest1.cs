using System;
using System.Linq;
using BankModel.Mappinds;
using Lesson4.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BankDbTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestClass]
        public class UnitTestService
        {
            [TestMethod]
            public void TestInsertInitialData()
            {
                var srv = new DbServices();
                srv.InsertInitialData();

                using (var ctx = new BankDbContext())
                {
                    var card = ctx.Cards.Single(c => c.CardId == "5111111111111111");
                }
            }

            [TestMethod]
            public void TestRecalculateBallance()
            {
                var srv = new DbServices();
                srv.RecalculateBallance("5111111111111111");
                srv.RecalculateBallance("5111111111111112");

                using (var ctx = new BankDbContext())
                {
                    var card1 = ctx.Cards.Single(c => c.CardId == "5111111111111111");
                    var card2 = ctx.Cards.Single(c => c.CardId == "5111111111111112");

                    Assert.AreEqual(0, card1.Ballance + card2.Ballance);
                }
            }

        }
    }
}
