using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOL.Models.Payment
{
    public interface IPayment
    {
        bool Pay(Order order);
        bool ExternalValidationToCreditCompany();

    }
}
