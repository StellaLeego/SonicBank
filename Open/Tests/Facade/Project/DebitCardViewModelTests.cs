using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Facade.Project;

namespace Open.Tests.Facade.Project
{
    [TestClass]
    public class DebitCardViewModelTests : ObjectTests<DebitCardViewModel>
    {
        protected override DebitCardViewModel getRandomTestObject()
        {
            return GetRandom.Object<DebitCardViewModel>();
        }

        [TestMethod]
        public void IsPaymentViewModelTest()
        {
            Assert.AreEqual(obj.GetType().BaseType, typeof(PaymentViewModel));
        }

        [TestMethod]
        public void CardAssociationTest()
        {
            testReadWriteProperty(() => obj.CardAssociationName, x => obj.CardAssociationName = x);
        }
    }
}
