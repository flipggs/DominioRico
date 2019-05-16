using System;
using Flunt.Validations;
using PaymentContext.Domain.ValueObjects;
using PaymentContext.Shared.Entities;

namespace PaymentContext.Domain.Entites
{
    public abstract class Payment : Entity
    {
        protected Payment(DateTime paidDate, 
        DateTime expireDate, 
        decimal total, 
        decimal totalPaid, 
        string payer, 
        Document document, 
        Adress adress, 
        Email email)
        {
            Number = Guid.NewGuid().ToString().Replace("-", "").Substring(0, 10).ToUpper();
            PaidDate = paidDate;
            ExpireDate = expireDate;
            Total = total;
            TotalPaid = totalPaid;
            Payer = payer;
            Document = document;
            Adress = adress;
            Email = email;

            AddNotifications(new Contract()
                .Requires()
                .IsGreaterThan(0, total, "Payment.Total", "O total não pode ser zero")
                .IsGreaterOrEqualsThan(total, totalPaid, "Payment.TotalPaid", "O valor pago é menor que o valor do pagamento")
            );
        }

        public string Number { get; set; }
        public DateTime PaidDate { get; set; }
        public DateTime ExpireDate { get; set; }
        public decimal Total { get; set; }
        public decimal TotalPaid { get; set; }
        public string Payer { get; set; }
        public Document Document { get; set; }
        public Adress Adress { get; set; }
        public Email Email { get; set; }
    }

}