using ERP_Core2.AutoMapper;
using ERP_Core2.Services;
using lssWebApi2.EntityFramework;
using lssWebApi2.Enumerations;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ERP_Core2.PayRollDomain
{
public class FluentPayRollPaySequenceQuery:IFluentPayRollPaySequenceQuery
    {
        private UnitOfWork _unitOfWork = null;
        public FluentPayRollPaySequenceQuery() { }
        public FluentPayRollPaySequenceQuery(UnitOfWork unitOfWork) { _unitOfWork = unitOfWork; }

 public async Task<PayRollPaySequence> MapToEntity(PayRollPaySequenceView inputObject)
        {
            Mapper mapper = new Mapper();
            PayRollPaySequence outObject = mapper.Map<PayRollPaySequence>(inputObject);
            await Task.Yield();
            return outObject;
        }

  public async Task<List<PayRollPaySequence>> MapToEntity(List<PayRollPaySequenceView> inputObjects)
        {
            List<PayRollPaySequence> list = new List<PayRollPaySequence>();
            Mapper mapper = new Mapper();
            foreach (var item in inputObjects)
            {
                PayRollPaySequence outObject = mapper.Map<PayRollPaySequence>(item);
                list.Add(outObject);
            }
            await Task.Yield();
            return list;

        }

 public async Task<PayRollPaySequenceView> MapToView(PayRollPaySequence inputObject)
        {
            Mapper mapper = new Mapper();
            PayRollPaySequenceView outObject = mapper.Map<PayRollPaySequenceView>(inputObject);
            await Task.Yield();
            return outObject;
        }
      
        
  public async Task<NextNumber>GetNextNumber()
        {
            return await _unitOfWork.payRollPaySequenceRepository.GetNextNumber('PayRollPaySequenceNumber');
        }
 public async Task<PayRollPaySequenceView> GetViewById(long payRollPaySequenceId)
        {
            PayRollPaySequence detailItem = await _unitOfWork.payRollPaySequenceRepository.GetEntityById(payRollPaySequenceId);

            return await MapToView(detailItem);
        }
 public async Task<PayRollPaySequenceView> GetViewByNumber(long payRollPaySequenceNumber)
        {
            PayRollPaySequence detailItem = await _unitOfWork.payRollPaySequenceRepository.GetEntityByNumber(payRollPaySequenceNumber);

            return await MapToView(detailItem);
        }

public async Task<PayRollPaySequence> GetEntityById(long payRollPaySequenceId)
        {
            return await _unitOfWork.payRollPaySequenceRepository.GetEntityById(payRollPaySequenceId);

        }
 public async Task<PayRollPaySequenceView> GetEntityByNumber(long payRollPaySequenceNumber)
        {
            return _unitOfWork.payRollPaySequenceRepository.GetEntityByNumber(payRollPaySequenceNumber);
        }
}
}
