
using lssWebApi2.EntityFramework;
using System.Threading.Tasks;

namespace lssWebApi2.TaxRatesByCodeDomain
{
    public interface ITaxRatesByCodeRepository
    {
        Task<TaxRatesByCode> GetEntityById(long ? TaxRatesByCodeId);
        Task<TaxRatesByCode> GetEntityByNumber(long TaxRatesByCodeNumber);
        Task<TaxRatesByCode> GetEntityByCode(string taxCode);

    }
}
