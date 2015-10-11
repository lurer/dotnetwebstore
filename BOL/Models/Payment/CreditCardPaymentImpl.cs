using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOL.Models.Payment
{
    public class CreditCardPaymentImpl : IPayment
    {

        [RegularExpression(@"^[A-ZÆØÅa-zæøå\-]{3,30}$", ErrorMessage ="Please provide a valid name.")]
        public string CardHolderName { get; set; }

        [RegularExpression(@"^\d{11}$", ErrorMessage ="Credit card number is in 11 digits.")]
        public string CardNumber { get; set; }

        [RegularExpression(@"^\d{2}$", ErrorMessage = "Expiration month is in to digits 01-12.")]
        public string ExpMonth { get; set; }

        [RegularExpression(@"^\d{2}$", ErrorMessage = "Expiration year is in to digits.")]
        public string ExpYear { get; set; }

        [RegularExpression(@"^\d{3}$", ErrorMessage = "CSV code is in 3 digits and is found on the back side of the card.")]
        public string CSV { get; set; }


        public bool Pay(Order order)
        {
            return true;
        }

        public bool ExternalValidationToCreditCompany()
        {
            //Dummy implementasjon av en verifikasjon mot kreditkortselskapet
            return true;
        }
    }
}
