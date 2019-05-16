using Flunt.Validations;
using PaymentContext.Shared.ValueObjects;

namespace PaymentContext.Domain.ValueObjects
{
    public class Email : ValueObject
    {
        public Email(string adress)
        {
            Adress = adress;

            AddNotifications(new Contract()
            .Requires()
            .IsEmail(Adress, "Email.Adress", "E-mail inváldio"));
        }

        public string Adress { get; set; }
    }
}