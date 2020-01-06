using lssWebApi2.AccountPayableDomain;
using lssWebApi2.Services;
using lssWebApi2.EntityFramework;
using lssWebApi2.Enumerations;
using System.Collections.Generic;

namespace lssWebApi2.TaxRatesByCodeDomain
{
    public class FluentTaxRatesByCode : IFluentTaxRatesByCode
    {
        private UnitOfWork unitOfWork = new UnitOfWork();
        private CreateProcessStatus processStatus;

        public FluentTaxRatesByCode() { }
        public IFluentTaxRatesByCodeQuery Query()
        {
            return new FluentTaxRatesByCodeQuery(unitOfWork) as IFluentTaxRatesByCodeQuery;
        }
        public IFluentTaxRatesByCode Apply()
        {
            if (this.processStatus == CreateProcessStatus.Insert || this.processStatus == CreateProcessStatus.Update || this.processStatus == CreateProcessStatus.Delete)
            { unitOfWork.CommitChanges(); }
            return this as IFluentTaxRatesByCode;
        }
        public IFluentTaxRatesByCode AddTaxRatesByCodes(List<TaxRatesByCode> newObjects)
        {
            unitOfWork.taxRatesByCodeRepository.AddObjects(newObjects);
            this.processStatus = CreateProcessStatus.Insert;
            return this as IFluentTaxRatesByCode;
        }
        public IFluentTaxRatesByCode UpdateTaxRatesByCodes(IList<TaxRatesByCode> newObjects)
        {
            foreach (var item in newObjects)
            {
                unitOfWork.taxRatesByCodeRepository.UpdateObject(item);
            }
            this.processStatus = CreateProcessStatus.Update;
            return this as IFluentTaxRatesByCode;
        }
        public IFluentTaxRatesByCode AddTaxRatesByCode(TaxRatesByCode newObject)
        {
            unitOfWork.taxRatesByCodeRepository.AddObject(newObject);
            this.processStatus = CreateProcessStatus.Insert;
            return this as IFluentTaxRatesByCode;
        }
        public IFluentTaxRatesByCode UpdateTaxRatesByCode(TaxRatesByCode updateObject)
        {
            unitOfWork.taxRatesByCodeRepository.UpdateObject(updateObject);
            this.processStatus = CreateProcessStatus.Update;
            return this as IFluentTaxRatesByCode;

        }
        public IFluentTaxRatesByCode DeleteTaxRatesByCode(TaxRatesByCode deleteObject)
        {
            unitOfWork.taxRatesByCodeRepository.DeleteObject(deleteObject);
            this.processStatus = CreateProcessStatus.Delete;
            return this as IFluentTaxRatesByCode;
        }
        public IFluentTaxRatesByCode DeleteTaxRatesByCodes(List<TaxRatesByCode> deleteObjects)
        {
            unitOfWork.taxRatesByCodeRepository.DeleteObjects(deleteObjects);
            this.processStatus = CreateProcessStatus.Delete;
            return this as IFluentTaxRatesByCode;
        }
    }
}