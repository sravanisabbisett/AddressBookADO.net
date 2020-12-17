using System;

namespace AddressBookADO.net
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to addressBook");
            AddressBookRepo addressBookRepo = new AddressBookRepo();
            addressBookRepo.GetAllData();
            Console.ReadKey();
        }
    }
}
