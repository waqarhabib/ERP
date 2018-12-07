﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ERP_Core2.GeneralLedgerDomain;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace lssAngular2.Controllers
{
    [Route("api/[controller]")]
    public class GeneralLedgerController : Controller
    {
        // GET: api/<controller>
        /*
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }
        */
        /*
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }
        */

        // GET api/<controller>/5
        //[HttpGet("{fiscalYear}")]
        [Route("IncomeShortView")]
        [HttpPost]
        public async Task PostIncomeView([FromBody]IncomeShortView income)
        {
            DataService ds = new DataService();
            await ds.PostAsync<IncomeShortView>("api/GeneralLedger/IncomeShortView", income);
        }
        [Route("IncomeViews")]
        [HttpGet]
        public async Task<IEnumerable<IncomeView>> GetIncomeViews()
        {
            DataService ds = new DataService();
            IEnumerable<IncomeView> views = await ds.GetAsync<List<IncomeView>>("api/GeneralLedger/IncomeViews");
            return views;
        }
        
        [Route("BySummary")]
        [HttpGet]
        public async Task<IEnumerable<AccountSummaryView>> GetSummary()
        {
            DataService ds = new DataService();
            IEnumerable<AccountSummaryView> views = await ds.GetAsync<List<AccountSummaryView>>("api/GeneralLedger/BySummary/" + DateTime.Now.Year.ToString());
            return views;
        }
        
        
        [Route("ById/{generalLedgerId}")]
        [HttpGet]
        public async Task<GeneralLedgerView> Get(long generalLedgerId)
        {
            DataService ds = new DataService();
            GeneralLedgerView view = await ds.GetAsync<GeneralLedgerView>("api/GeneralLedger/ById/" + generalLedgerId.ToString());
            
            return view;
        }
        // POST api/<controller>
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
