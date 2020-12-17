using AddressBookADO.net;
using Microsoft.VisualStudio.TestTools.UnitTesting;

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
    }
}
