

using lssWebApi2.EntityFramework;
using System.Collections.Generic;

namespace ERP_Core2.PayRollDomain
{ 

public interface IFluentPayRollEarnings
    {
        IFluentPayRollEarningsQuery Query();
        IFluentPayRollEarnings Apply();
        IFluentPayRollEarnings AddPayRollEarnings(PayRollEarnings payRollEarnings);
        IFluentPayRollEarnings UpdatePayRollEarnings(PayRollEarnings payRollEarnings);
        IFluentPayRollEarnings DeletePayRollEarnings(PayRollEarnings payRollEarnings);
     	IFluentPayRollEarnings UpdatePayRollEarningss(List<PayRollEarnings> newObjects);
        IFluentPayRollEarnings AddPayRollEarningss(List<PayRollEarnings> newObjects);
        IFluentPayRollEarnings DeletePayRollEarningss(List<PayRollEarnings> deleteObjects);
    }
}
