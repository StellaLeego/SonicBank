﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Data.Location;
using Open.Domain.Location;

namespace Open.Tests.Domain.Location {
    [TestClass]
    public class AddressObjectTests : DomainObjectsTests<AddressObject<EmailAddressDbRecord>, EmailAddressDbRecord> {
        protected override AddressObject<EmailAddressDbRecord> getRandomTestObject() {
            createdWithNullArg = new testClass(null);
            dbRecordType = typeof(AddressDbRecord);
            return GetRandom.Object<testClass>();
        }

        [TestMethod]
        public void IsIAddressObjectTest() {
            Assert.IsInstanceOfType(obj, typeof(IAddressObject));
        }

        private class testClass : AddressObject<EmailAddressDbRecord> {
            public testClass(EmailAddressDbRecord r) : base(r) { }
        }
    }
}