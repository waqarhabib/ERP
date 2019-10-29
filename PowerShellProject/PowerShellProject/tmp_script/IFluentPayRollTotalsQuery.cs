using ERP_Core2.AutoMapper;
using ERP_Core2.Services;
using lssWebApi2.EntityFramework;
using lssWebApi2.Enumerations;
using System.Collections.Generic;
using System.Threading.Tasks;


public interface IFluentPayRollTotalsQuery
{
        Task<PayRollTotals> MapToEntity(PayRollTotalsView inputObject);
        Task<List<PayRollTotals>> MapToEntity(List<PayRollTotalsView> inputObjects);
    
        Task<PayRollTotalsView> MapToView(PayRollTotals inputObject);
        Task<NextNumber> GetNextNumber();
	Task<PayRollTotals> GetEntityById(long payRollTotalsId);
	  Task<PayRollTotals> GetEntityByNumber(long payRollTotalsNumber);
	Task<PayRollTotalsView> GetViewById(long payRollTotalsId);
	Task<PayRollTotalsView> GetViewByNumber(long payRollTotalsNumber);
}