﻿using ERP_Core2.AbstractFactory;
using ERP_Core2.AccountPayableDomain;
using ERP_Core2.Interfaces;
using ERP_Core2.AccountsReceivableDomain;
using ERP_Core2.GeneralLedgerDomain;
using ERP_Core2.InvoicesDomain;
using ERP_Core2.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ERP_Core2.AccountPayableDomain.AccountPayableModule;

namespace ERP_Core2.FluentAPI
{
   
    public class FluentGeneralLedger : AbstractErrorHandling, IFluentGeneralLedger
    {
        public UnitOfWork unitOfWork = new UnitOfWork();
        public AccountReceiveableView lastAccountReceivableView;
        public CreateProcessStatus processStatus;

        private FluentGeneralLedgerQuery _query = null;

        public IFluentGeneralLedgerQuery Query()
       {
            if (_query == null) { _query = new FluentGeneralLedgerQuery(unitOfWork); }

            return _query as IFluentGeneralLedgerQuery;
        }
        public FluentGeneralLedger() { }
        public IFluentGeneralLedger UpdateAccountBalances(GeneralLedgerView ledgerView)
        {
            Task<bool> resultTask = Task.Run(() => unitOfWork.generalLedgerRepository.UpdateBalanceByAccountId(ledgerView.AccountId, ledgerView.FiscalYear, ledgerView.FiscalPeriod,ledgerView.DocType));
            Task.WaitAll(resultTask);
            return this as IFluentGeneralLedger;
        }
        public IFluentGeneralLedger UpdateLedgerBalances()
        {

            Task<GeneralLedgerView> ledgerTask = Task.Run(() => unitOfWork.generalLedgerRepository.GetLedgerByDocNumber(lastAccountReceivableView.DocNumber, "OV"));
            Task.WaitAll(ledgerTask);
            Task<bool> resultTask = Task.Run(() => unitOfWork.generalLedgerRepository.UpdateBalanceByAccountId(ledgerTask.Result.AccountId, ledgerTask.Result.FiscalYear, ledgerTask.Result.FiscalPeriod,ledgerTask.Result.DocType));
            Task.WaitAll(resultTask);
            return this as IFluentGeneralLedger;
        }
        public IFluentGeneralLedger CreateGeneralLedger(GeneralLedgerView ledgerView)
        {
            try
            {
                Task<CreateProcessStatus> statusTask = Task.Run(() => unitOfWork.generalLedgerRepository.CreateLedgerFromView(ledgerView));
                Task.WaitAll(statusTask);
                processStatus = statusTask.Result;

                return this as IFluentGeneralLedger;
            }
            catch (Exception ex)
            {
                throw new Exception(GetMyMethodName(), ex);
            }
        }
        public IFluentGeneralLedger CreateGeneralLedger(InvoiceView invoiceView)
        {
            try
            {

                Task<AccountReceiveableView> acctRecViewTask = Task.Run(() => unitOfWork.accountReceiveableRepository.GetAccountReceivableViewByInvoiceId(invoiceView.InvoiceId));
                Task.WaitAll(acctRecViewTask);
                if (acctRecViewTask.Result != null)
                {
                    Task<CreateProcessStatus> resultTask = Task.Run(() => unitOfWork.generalLedgerRepository.CreateLedgerFromReceiveable(acctRecViewTask.Result));
                    Task.WaitAll(resultTask);
                   
                    processStatus = resultTask.Result;
                    return this as IFluentGeneralLedger;
  
                }
                processStatus = CreateProcessStatus.AlreadyExists;
                return this as IFluentGeneralLedger;

            }
            catch (Exception ex)
            {
                throw new Exception(GetMyMethodName(), ex);
            }

        }



        public IFluentGeneralLedger Apply()
        {
            if (processStatus == CreateProcessStatus.Insert || processStatus == CreateProcessStatus.Update || processStatus == CreateProcessStatus.Delete)
            { unitOfWork.CommitChanges(); }
            return this as IFluentGeneralLedger;
        }
    }
}