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
            addressModel.Firstname = "Ranjitha";
            addressModel.Lastname = "Ranji";
            addressModel.Address = "GandhiChowk";
            addressModel.City = "Machilipatnam";
            addressModel.State = "AndhraPradesh";
            addressModel.Zip = 789021;
            addressModel.MobileNumber = "8328307888";
            addressModel.EmailId = "Ranjitha@gmail.com";
            bool result = addressBookRepo.InsertData(addressModel);
            Assert.IsTrue(result);
        }
    }
}
