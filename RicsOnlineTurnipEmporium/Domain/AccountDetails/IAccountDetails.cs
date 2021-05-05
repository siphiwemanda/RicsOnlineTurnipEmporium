using System.Collections.Generic;

namespace RicsOnlineTurnipEmporium.Domain.AccountDetails
{
    public interface IAccountDetails
    {
        bool CanHandle(PaymentType paymentType);

        Dictionary<string,string> AcountDetails(IAccountDetails accountDetails);



    }
}