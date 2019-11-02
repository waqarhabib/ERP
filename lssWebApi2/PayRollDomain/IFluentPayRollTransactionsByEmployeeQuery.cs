using ERP_Core2.AutoMapper;
using ERP_Core2.Services;
using lssWebApi2.EntityFramework;
using lssWebApi2.Enumerations;
using System.Collections.Generic;
using System.Threading.Tasks;
using ERP_Core2.PayRollDomain;


public interface IFluentPayRollTransactionsByEmployeeQuery
{
        Task<PayRollTransactionsByEmployee> MapToEntity(PayRollTransactionsByEmployeeView inputObject);
        Task<List<PayRollTransactionsByEmployee>> MapToEntity(List<PayRollTransactionsByEmployeeView> inputObjects);
    
        Task<PayRollTransactionsByEmployeeView> MapToView(PayRollTransactionsByEmployee inputObject);
        Task<NextNumber> GetNextNumber();
	Task<PayRollTransactionsByEmployee> GetEntityById(long payRollTransactionsByEmployeeId);
	  Task<PayRollTransactionsByEmployee> GetEntityByNumber(long payRollTransactionsByEmployeeNumber);
	Task<PayRollTransactionsByEmployeeView> GetViewById(long payRollTransactionsByEmployeeId);
	Task<PayRollTransactionsByEmployeeView> GetViewByNumber(long payRollTransactionsByEmployeeNumber);
    Task<List<PayRollTransactionsByEmployeeView>> GetTransactionsByEmployeeViews(long employee);
}