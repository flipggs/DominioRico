using Flunt.Validations;
using PaymentContext.Shared.ValueObjects;

namespace PaymentContext.Domain.ValueObjects
{
    public class Name : ValueObject
    {
        public Name(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;

            AddNotifications(new Contract()
                .Requires()
                .HasMinLen(firstName, 3, "Name.FirstName", "O Nome deve conter pelo menos 3 caracteres.")
                .HasMinLen(lastName, 3, "Name.LastName", "O Sobrenome deve conter pelo menos 3 caracteres.")
                .HasMaxLen(firstName, 40, "Name.FirstName", "O Nome deve conter pelo menos 40 caracteres.")
            );
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}