﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Millennium.Services
{
    public class UnitOfWork
    {
        public AddressBookRepository addressBookRepository = new AddressBookRepository();
    }
}
