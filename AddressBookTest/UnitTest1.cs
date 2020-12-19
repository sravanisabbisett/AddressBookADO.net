using AddressBookADO.net;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace AddressBookTest
{
    [TestClass]
    public class UnitTest1
    {
        AddressBookRepo addressBookRepo;
        /// <summary>
        /// Initializes a new instance of the <see cref="UnitTest1"/> class.
        /// </summary>
        public UnitTest1()
        {
            addressBookRepo = new AddressBookRepo();
        }


        /// <summary>
        /// Inserts the value into person table.
        /// </summary>
        [TestMethod]
        public void InsertValueIntoPersonTable()
        {
            AddressModel addressModel = new AddressModel();
            addressModel.Firstname = "Sravani";
            addressModel.Lastname = "Sabbisetti";
            addressModel.Address = "GandhiChowk";
            addressModel.City = "Bantumilli";
            addressModel.State = "AndhraPradesh";
            addressModel.Zip = 789021;
            addressModel.MobileNumber = "8712443378";
            addressModel.EmailId = "Sravani@gmail.com";
            bool result = addressBookRepo.InsertData(addressModel);
            Assert.IsTrue(result);
        }

        /// <summary>
        /// Updates the data.
        /// </summary>
        [TestMethod]
        public void UpdateData()
        {
            AddressModel addressModel = new AddressModel();
            addressModel.Firstname = "Ranjitha";
            addressModel.State = "Tamilnadu";
            bool result = addressBookRepo.UpdateData(addressModel);
            Assert.IsTrue(result);
        }

        /// <summary>
        /// Deletes the person.
        /// </summary>
        [TestMethod]
        public void DeletePerson()
        {
            AddressModel addressModel = new AddressModel();
            addressModel.Firstname = "Sravani";
            bool result = addressBookRepo.DeletePerson(addressModel);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void AddValueToAddressBookType()
        {
            AddressModel addressModel = new AddressModel();
            addressModel.PersonType = "Profession";
            addressModel.AddressBookName = "ProfessionAddressBook";
            bool result = addressBookRepo.AddRecordToAddressBookType(addressModel);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void AddPersonAddressBook()
        {
            AddressModel addressModel = new AddressModel();
            addressModel.PersonId = 8;
            addressModel.ABId = 1;
            bool result = addressBookRepo.AddDataToPersonAddressBook(addressModel);
            Assert.IsTrue(result);
        }

        /// <summary>
        /// Datas the list.
        /// </summary>
        /// <returns></returns>
        public List<AddressModel> DataList()
        {
            List<AddressModel> addressModels = new List<AddressModel>();
            addressModels.Add(new AddressModel { Firstname = "Manju", Lastname = "Chedhalla", Address = "Ponnur", City = "Guntur", State = "AndhraPradesh", Zip = 123456, MobileNumber = "9708654321", EmailId = "Manju@gmail.com", ABId = 1 });
            addressModels.Add(new AddressModel { Firstname = "Navya", Lastname = "Borra", Address = "Ponnur", City = "Eluru", State = "AndhraPradesh", Zip = 123456, MobileNumber = "9708654323", EmailId = "Navya@gmail.com", ABId = 2 });
            addressModels.Add(new AddressModel { Firstname = "Lipica", Lastname = "ChedhaCheerlla", Address = "Warangal", City = "Guntur", State = "Telangana", Zip = 123456, MobileNumber = "9708654326", EmailId = "Lipica@gmail.com", ABId = 2 });
            return addressModels;
        }

        /// <summary>
        /// Adds the data to tables with threading.
        /// </summary>
        [TestMethod]
        public void AddDataToTablesWithThreading()
        {        
            List<AddressModel> addressModels = DataList();
            bool expected = true;
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            bool actual=addressBookRepo.AddDataWithMultipleDataWithThreading(addressModels);
            stopwatch.Stop();
            Console.WriteLine("Time taken to add to db without threads is :{0} ms", stopwatch.ElapsedMilliseconds);
            Assert.AreEqual(expected, actual);
        }
    }
}
