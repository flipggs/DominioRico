using System;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Domain.Entites
{
    public class PayPalPayment : Payment
    {
        public PayPalPayment(string transactionCode, 
        DateTime paidDate, 
        DateTime expireDate, 
        decimal total, 
        decimal totalPaid, 
        string payer, 
        Document document, 
        Adress adress, 
        Email email):base(paidDate, expireDate, total, totalPaid, payer, document, adress, email)
        {
            TransactionCode = transactionCode;
        }

        public string TransactionCode { get; set; }
    }

}