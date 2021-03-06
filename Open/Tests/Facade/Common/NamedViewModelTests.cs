﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Facade.Common;

namespace Open.Tests.Facade.Common {
    [TestClass]
    public class NamedViewModelTests : ViewModelTests<NamedViewModel, TemporalViewModel> {
        protected override NamedViewModel getRandomTestObject() {
            return GetRandom.Object<testClass>();
        }

        [TestMethod]
        public void NameTest() {
            testReadWriteProperty(() => obj.Name, x => obj.Name = x);
        }

        private class testClass : NamedViewModel { }
    }
}