using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.Entites;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Tests.Entites
{
    [TestClass]
    public class StudentTests
    {
        private readonly Name _name;
        private readonly Document _document;
        private readonly Email _email;
        private readonly Adress _adress;
        private readonly Student _student;
        private readonly Subscription _subscription;
        private readonly PayPalPayment _payment;

        public StudentTests()
        {
            _name = new Name("Bruce", "Wayne");
            _document = new Document("34225545806", EDocumentType.CPF);
            _email = new Email("batman@dc.com");
            _adress = new Adress("Rua 1", "1234", "Bairro legal", "Gotam", "MG", "EUA", "12547652");
            _student = new Student(_name, _document, _email);
            _subscription = new Subscription(null);
            _payment = new PayPalPayment("12345678",
                DateTime.Now,
                DateTime.Now.AddDays(5),
                10,
                10,
                "WAYNE CORP",
                _document,
                _adress, _email);

        }

        [TestMethod]
        public void ShouldReturnErrorWhenHadActiveSubscription()
        {
            var payment = new PayPalPayment("12345678",
                            DateTime.Now,
                            DateTime.Now.AddDays(5),
                            10,
                            10,
                            "WAYNE CORP",
                            _document,
                            _adress, _email);

            _subscription.AddPayment(payment);
            _student.AddSubscription(_subscription);
            _student.AddSubscription(_subscription);

            Assert.IsTrue(_student.Invalid);
        }

        [TestMethod]
        public void ShouldReturnErrorWhenHadSubscriptionHansNoPayment()
        {
            _student.AddSubscription(_subscription);

            Assert.IsTrue(_student.Invalid);
        }

        [TestMethod]
        public void ShouldReturnSuccessWhenHadNoActiveSubscription()
        {
            var payment = new PayPalPayment("12345678",
                           DateTime.Now,
                           DateTime.Now.AddDays(5),
                           10,
                           10,
                           "WAYNE CORP",
                           _document,
                           _adress, _email);

            _subscription.AddPayment(payment);
            _student.AddSubscription(_subscription);

            Assert.IsTrue(_student.Valid);
        }
    }
}