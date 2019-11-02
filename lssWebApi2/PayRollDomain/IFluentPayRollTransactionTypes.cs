

using lssWebApi2.EntityFramework;
using System.Collections.Generic;

namespace ERP_Core2.PayRollDomain
{ 

public interface IFluentPayRollTransactionTypes
    {
        IFluentPayRollTransactionTypesQuery Query();
        IFluentPayRollTransactionTypes Apply();
        IFluentPayRollTransactionTypes AddPayRollTransactionTypes(PayRollTransactionTypes payRollTransactionTypes);
        IFluentPayRollTransactionTypes UpdatePayRollTransactionTypes(PayRollTransactionTypes payRollTransactionTypes);
        IFluentPayRollTransactionTypes DeletePayRollTransactionTypes(PayRollTransactionTypes payRollTransactionTypes);
     	IFluentPayRollTransactionTypes UpdatePayRollTransactionTypess(List<PayRollTransactionTypes> newObjects);
        IFluentPayRollTransactionTypes AddPayRollTransactionTypess(List<PayRollTransactionTypes> newObjects);
        IFluentPayRollTransactionTypes DeletePayRollTransactionTypess(List<PayRollTransactionTypes> deleteObjects);
    }
}