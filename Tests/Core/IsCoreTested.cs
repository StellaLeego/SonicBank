﻿using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Open.Tests.Core
{
    [TestClass]
    public class IsCoreTested : AssemblyTests
    {
        [TestMethod]
        public void IsTested()
        {
            isAllClassesTested(Namespace("Core"));
        }
    }
}
