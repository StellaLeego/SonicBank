using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Core;
using Open.Data.Project;
using Open.Domain.Project;
using Open.Facade.Project;

namespace Open.Tests.Facade.Project {
    [TestClass]
    public class PaymentViewModelsListTests : ObjectTests<PaymentViewModelsList> {
        protected override PaymentViewModelsList getRandomTestObject() {
            var l = new PaymentObjectsList(getRandomAddressDbRecordsList(),
                GetRandom.Object<RepositoryPage>());
            SetRandom.Values(l);
            return new PaymentViewModelsList(l);
        }

        private IEnumerable<PaymentDbRecord> getRandomAddressDbRecordsList() {
            var l = new List<PaymentDbRecord>();
            for (var i = 0; i < GetRandom.UInt8(5, 10); i++) {
                var x = i % 4;
                if (x == 0) l.Add(GetRandom.Object<CashDbRecord>());
                if (x == 1) l.Add(GetRandom.Object<CheckDbRecord>());
                if (x == 2) l.Add(GetRandom.Object<DebitCardDbRecord>());
                if (x == 3) l.Add(GetRandom.Object<CreditCardDbRecord>());
            }

            return l;
        }

        [TestMethod]
        public void CanCreateWithNullArgumentTest() {
            Assert.IsNotNull(new PaymentViewModelsList(null));
        }
    }
}