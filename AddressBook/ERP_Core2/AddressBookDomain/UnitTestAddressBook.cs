﻿using MillenniumERP.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using ERP_Core2.EntityFramework;
using Xunit.Abstractions;
using MillenniumERP.AddressBookDomain;

namespace ERP_Core2.AddressBookDomain
{
    public class UnitTestAddressBook
    {
        private UnitOfWork unitOfWork = new UnitOfWork();
        private readonly ITestOutputHelper output;

        public UnitTestAddressBook(ITestOutputHelper output)
        {
            this.output = output;

        }
        [Fact]
        void TestGetBuyerByBuyerId()
        {
            int buyerId = 1;

            UnitOfWork unitOfWork = new UnitOfWork();
            BuyerView buyerView = unitOfWork.buyerRepository.GetBuyerViewByBuyerId(buyerId);
            Assert.Equal("Regional Purchasing Clerk",buyerView.BuyerTitle);
        }
        [Fact]
        void TestGetCarrierByCarrierId()
        {
            int carrierId = 1;

            UnitOfWork unitOfWork = new UnitOfWork();
            CarrierView carrierView = unitOfWork.carrierRepository.GetCarrierViewByCarrierId(carrierId);
            Assert.Equal("United Parcel Service",carrierView.CarrierName.ToString());
        }

        [Fact]
        void   TestGetSupplierBySupplierId()
        {
            int supplierId = 1;
            UnitOfWork unitOfWork = new UnitOfWork();
            SupplierView supplierView = unitOfWork.supplierRepository.GetSupplierViewBySupplierId(supplierId);
            Assert.True(supplierView.SupplierId != null);

        }
        [Fact]
        public void TestGetEmployeeByEmployeeId()
        {
            int employeeId = 3;
            UnitOfWork unitOfWork = new UnitOfWork();
            EmployeeView employeeView = unitOfWork.employeeRepository.GetEmployeeViewByEmployeeId(employeeId);
            Assert.True(employeeView.EmployeeId != null);
        }
        [Fact]
        public void TestGetEmployeesBySupervisorId()
        {
            
            int supervisorId = 1;
            UnitOfWork unitOfWork = new UnitOfWork();
            List<EmployeeView>list = unitOfWork.supervisorRepository.GetEmployeesBySupervisorId(supervisorId);

            int count = 0;
            foreach (var item in list)
            {
                output.WriteLine($"{item.EmployeeId} {item.EmployeeName}");
                count++;
            }
            Assert.True(count>0);
            
        }
        [Fact]
        public void TestGetSupervisor()
        {
            int supervisorId = 1;
            UnitOfWork unitOfWork = new UnitOfWork();
            SupervisorView view = unitOfWork.supervisorRepository.GetSupervisorBySupervisorId(supervisorId);
            Assert.Equal(view.ParentSupervisorName.ToUpper().ToString() , "PAM NISHIMOTO".ToString());
        }
        [Fact]
        public void TestAddressBookPhones()
        {
            
            List<Phone> resultTask = unitOfWork.addressBookRepository.GetPhonesByAddressId(1);

            List<string> intCollection = new List<string>();
            foreach (var item in resultTask)
            {
                output.WriteLine($"{item.PhoneNumber}");
                intCollection.Add(item.PhoneNumber);

            }
            bool results = intCollection.Any(s => s.Contains("401-4333"));
            Assert.True(results);

        }
        [Fact]
        public void TestAddressBookEmails()
        {
            UnitOfWork unitOfWork = new UnitOfWork();
            List<Email> resultTask = unitOfWork.addressBookRepository.GetEmailsByAddressId(1);

            List<string> intCollection = new List<string>();
            foreach (var item in resultTask)
            {
                output.WriteLine($"{item.Email1}");
                intCollection.Add(item.Email1);
       
            }
            bool results = intCollection.Any(s => s.Contains("dnishimoto@listensoftware.com"));
            Assert.True(results);

        }
        
        private void DoSomething1(int iterations)
        {
            for (int i = 0; i < iterations; i++)
            {
                output.WriteLine("Do Something one");
                Thread.Sleep(1);
            }

        }
        private void DoSomething2(int iterations)
        {
            for (int i = 0; i < iterations; i++)
            {
                output.WriteLine("Do Something two");
                Thread.Sleep(2);
            }
        }
        //The state.Break() exist out of the Parallel.ForEach loop when the 
        //application sets the cancelForEach boolean flag.
        private void ProcessUsingParallelForEach(List<string> intCollection)
        {

            Parallel.ForEach(intCollection, (integer, state) =>
            {
                output.WriteLine($"Parallel.Foreach={integer}");
                if (cancelForEach == true)
                {
                    output.WriteLine($"Exit Parallel.ForEach {integer}");
                    state.Break();

                }

            });

        }
        private bool cancelForEach = false;
        [Fact]
        public void TestThreadPooling()
        {
            int numberOfProcessors = Environment.ProcessorCount;

            Parallel.Invoke(() => DoSomething1(5)
                        , () => DoSomething2(10));

            List<string> intCollection = new List<string>();

            for (int i = 0; i < 500; i++)
            {
                intCollection.Add(i.ToString());
            }

            var TaskForEach = Task.Run(() => ProcessUsingParallelForEach(intCollection));

            Thread.Sleep(500);
            cancelForEach = true;

            Task.WaitAll(TaskForEach);

        }
        [Fact]
        public void TestGetAddressBooks()
        {
            int addressId = 1;

            UnitOfWork unitOfWork = new UnitOfWork();
            Task<List<AddressBook>> resultTask = Task.Run<List<AddressBook>>(async () => await unitOfWork.addressBookRepository.GetAddressBookByAddressId(addressId));

            IList<string> list = new List<string>();
            foreach (var item in resultTask.Result)
            {
                output.WriteLine($"{item.Name}");
                list.Add(item.Name.ToUpper());
            }
            Assert.True(list.Contains("DAVID NISHIMOTO") );
        }
        [Fact]
        public void TestGetAddressBook()
        {
            UnitOfWork unitOfWork = new UnitOfWork();
            Task<AddressBook> resultTask = Task.Run<AddressBook>(async () => await unitOfWork.addressBookRepository.GetObjectAsync(1));

            output.WriteLine($"{resultTask.Result.FirstName}");

            Assert.Equal("David",resultTask.Result.FirstName);
        }
        [Fact]
        public void TestUpdateAddressBook()
        {
            UnitOfWork unitOfWork = new UnitOfWork();
            Task<AddressBook> resultTask = Task.Run<AddressBook>(async () => await unitOfWork.addressBookRepository.GetObjectAsync(1));

            AddressBook addressBook = resultTask.Result;
            addressBook.FirstName = "David2";
            unitOfWork.addressBookRepository.UpdateObject(addressBook);
            unitOfWork.CommitChanges();

            var query = unitOfWork.addressBookRepository.GetObjectAsync(1);

            string name = query.Result.FirstName;

            Assert.Equal("David2",name );

            addressBook = resultTask.Result;
            addressBook.FirstName = "David";
            unitOfWork.addressBookRepository.UpdateObject(addressBook);
            unitOfWork.CommitChanges();

            query = unitOfWork.addressBookRepository.GetObjectAsync(1);

            name = query.Result.FirstName;

            Assert.Equal("David",name);
        }
        [Fact]
        public void TestAddandDeleteAddressBook()
        {
            UnitOfWork unitOfWork = new UnitOfWork();
            AddressBook addressBook = new AddressBook();
            addressBook.FirstName = "James";
            addressBook.LastName = "Dean";
            addressBook.Name = "James Dean";
            unitOfWork.addressBookRepository.AddObject(addressBook);
            unitOfWork.CommitChanges();

            IQueryable<AddressBook> query = unitOfWork.addressBookRepository.GetObjectsAsync(a => a.Name == "James Dean");

            foreach (var item in query)
            {
                Assert.Equal("James Dean",item.Name );

                unitOfWork.addressBookRepository.DeleteObject(item);
            }
            unitOfWork.CommitChanges();
           

        }
        [Fact]
        public void TestDeleteAddressBooks()
        {
            List<AddressBook> list = new List<AddressBook>();
            UnitOfWork unitOfWork = new UnitOfWork();

            for (int i = 1; i < 10; i++)
            {
                AddressBook addressBook = new AddressBook();
                addressBook.Name = "Test" + i.ToString();
                list.Add(addressBook);

            }
            unitOfWork.addressBookRepository.AddObjects(list);
            unitOfWork.CommitChanges();

            IQueryable<AddressBook> query = unitOfWork.addressBookRepository.GetObjectsAsync(a => a.Name.Contains("Test"));

            list.Clear();

            foreach (var item in query)
            {
                list.Add(item);
            }

            unitOfWork.addressBookRepository.DeleteObjects(list);
            unitOfWork.CommitChanges();
            Assert.True(true);

        }
    }
}
