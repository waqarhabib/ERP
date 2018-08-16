﻿using ERP_Core2.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MillenniumERP.Services;

namespace MillenniumERP.ScheduleEventsDomain
{

    public class UDCRepository : Repository<UDC>
    {
        Entities _dbContext;
        public UDCRepository(DbContext db) : base(db)
        {
            _dbContext = (Entities)db;
        }
        public async Task<IQueryable<UDC>> GetUDCValuesByProductCode(string productCode)
        {
            try
            {
                var list = await base.GetObjectsQueryable(e => e.ProductCode == productCode, "").ToListAsync();

                return list.AsQueryable<UDC>();
            }
            catch (Exception ex)
            {
                throw new Exception(GetMyMethodName(), ex);
            }
           
        }
    }
}
