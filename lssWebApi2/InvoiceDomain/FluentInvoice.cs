﻿using ERP_Core2.AbstractFactory;
using ERP_Core2.AccountPayableDomain;
using ERP_Core2.Interfaces;
using ERP_Core2.InvoicesDomain;
using ERP_Core2.Services;
using lssWebApi2.EntityFramework;
using lssWebApi2.FluentAPI;
using lssWebApi2.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ERP_Core2.FluentAPI
{
 
 
    public class FluentInvoice : AbstractErrorHandling, IFluentInvoice
    {
        public UnitOfWork unitOfWork = new UnitOfWork();
        public CreateProcessStatus processStatus;

        private FluentInvoiceQuery _query = null;

        public FluentInvoice() { }

        public IFluentInvoiceQuery Query()
        {
            if (_query == null) { _query = new FluentInvoiceQuery(unitOfWork); }

            return _query as IFluentInvoiceQuery;

        }



        public IFluentInvoice Apply()
        {
            if (processStatus == CreateProcessStatus.Insert || processStatus == CreateProcessStatus.Update || processStatus == CreateProcessStatus.Delete)
            { unitOfWork.CommitChanges(); }
            return this as IFluentInvoice;
        }
        public IFluentInvoice CreateInvoice(InvoiceView invoiceView)
        {

            Task<CreateProcessStatus> resultTask = Task.Run(() => unitOfWork.invoiceRepository.CreateInvoiceByView(invoiceView));
            Task.WaitAll(resultTask);
            processStatus = resultTask.Result;
            return this as IFluentInvoice;

        }
        public IFluentInvoice MergeWithInvoiceNumber(ref InvoiceView invoiceView)
        {

            string invoiceNumber = invoiceView.InvoiceNumber;

            Task<Invoice> viewTask = Task.Run(() => unitOfWork.invoiceRepository.GetInvoiceByInvoiceNumber(invoiceNumber));
            Task.WaitAll(viewTask);

            //TODO applicationFactory needs to have a merge feature created
            invoiceView.InvoiceId = viewTask.Result.InvoiceId;
            invoiceView.InvoiceNumber = viewTask.Result.InvoiceNumber;
            invoiceView.InvoiceDate = viewTask.Result.InvoiceDate;
            invoiceView.Amount = viewTask.Result.Amount;
            invoiceView.CustomerId = viewTask.Result.Customer.CustomerId;
            invoiceView.CustomerName = viewTask.Result.Customer.Address.Name;
            invoiceView.Description = viewTask.Result.Description;
            invoiceView.TaxAmount = viewTask.Result.TaxAmount;
            invoiceView.PaymentDueDate = viewTask.Result.PaymentDueDate;
            invoiceView.DiscountAmount = viewTask.Result.DiscountAmount;
            invoiceView.PaymentTerms = viewTask.Result.PaymentTerms;
            invoiceView.CompanyId = viewTask.Result.Company.CompanyId;
            invoiceView.CompanyName = viewTask.Result.Company.CompanyName;
            invoiceView.CompanyStreet = viewTask.Result.Company.CompanyStreet;
            invoiceView.CompanyCity = viewTask.Result.Company.CompanyCity;
            invoiceView.CompanyZipcode = viewTask.Result.Company.CompanyZipcode;
            invoiceView.DiscountDueDate = viewTask.Result.DiscountDueDate;
            invoiceView.FreightCost = viewTask.Result.FreightCost;

            return this as IFluentInvoice;
        }

      

    }
}