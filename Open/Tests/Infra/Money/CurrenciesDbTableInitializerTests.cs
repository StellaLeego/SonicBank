﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Infra.Money;

namespace Open.Tests.Infra.Money
{
    [TestClass]
    public class CurrenciesDbTableInitializerTests : BaseTests
    {
        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            type = typeof(CurrenciesDbTableInitializer);
        }

        [TestMethod]
        public void CantInitializeTest()
        {
            Assert.Inconclusive();
        }

        [TestMethod]
        public void InitializeTest()
        {
            Assert.Inconclusive();
        }
    }
}
