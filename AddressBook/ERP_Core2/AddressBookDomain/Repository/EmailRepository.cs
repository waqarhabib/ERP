﻿using ERP_Core2.AbstractFactory;
using ERP_Core2.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MillenniumERP.Services;

namespace MillenniumERP.AddressBookDomain
{


    public class EmailView
    {
        public EmailView() { }
        public EmailView(Email email)
        {
            this.AddressId = email.AddressId;
            this.EmailId = email.EmailId;
            this.EmailText = email.Email1;
            this.LoginEmail = email.LoginEmail ?? false;
            this.Password = email.Password;
        }
        public long AddressId { get; set; }
        public long EmailId { get; set; }
        public string EmailText { get; set; }
        public bool LoginEmail { get; set; }
        public string Password { get; set; }
    }

    public class EmailRepository : Repository<Email> {
        private ApplicationViewFactory applicationViewFactory;

        Entities _dbContext;
        public EmailRepository(DbContext db) : base(db)
        {
            _dbContext = (Entities)db;
            applicationViewFactory = new ApplicationViewFactory();
        }
        public async Task<bool> CreateEmail(EmailView emailView)
        {
            try
            {
                var query = await (from e in _dbContext.Emails
                                   where e.Email1 == emailView.EmailText
                                   select e).FirstOrDefaultAsync<Email>();
                if (query == null)
                {
                    Email email = new Email();
                    applicationViewFactory.MapEmailEntity(ref email, emailView);
                    AddObject(email);
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            { throw new Exception(GetMyMethodName(), ex); }
        }

    }
}