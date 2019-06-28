﻿using lssWebApi2.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lssWebApi2.Interfaces
{
    public interface IFluentSalesOrder
    {
        IFluentSalesOrderQuery Query();
        IFluentSalesOrder Apply();
        IFluentSalesOrder AddSalesOrder(SalesOrder salesOrder);
        IFluentSalesOrder UpdateSalesOrder(SalesOrder salesOrder);
        IFluentSalesOrder DeleteSalesOrder(SalesOrder salesOrder);
        IFluentSalesOrder UpdateSalesOrderAmountByShipmentsDetail(Shipments shipments, decimal? amount);
    }
}
