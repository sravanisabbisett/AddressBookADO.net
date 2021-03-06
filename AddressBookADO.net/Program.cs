﻿using System;

namespace AddressBookADO.net
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to addressBook");
            AddressBookRepo addressBookRepo = new AddressBookRepo();
            AddressModel addressModel = new AddressModel();
            while (true)
            {
                Console.WriteLine("1)GetAllData\n" + "2)Retrive person by city or state\n"+"3)Retrive person city And Person\n"
                                    +"4)Order by firstname\n"+"5)View PersonAddressBookdata\n"+"6)CountBy type\n"+"7)Count by city or state");

                try
                {
                    var choice = Convert.ToInt32(Console.ReadLine());
                    switch (choice)
                    {
                        case 1:
                            addressBookRepo.GetAllData();
                            break;
                        case 2:
                            Console.WriteLine("Enter your city");
                            addressModel.City = Console.ReadLine();
                            Console.WriteLine("Enter your state");
                            addressModel.State = Console.ReadLine();
                            addressBookRepo.RetrivePersonsCityOrState(addressModel);
                            break;
                        case 3:
                            Console.WriteLine("Enter your city");
                            addressModel.City = Console.ReadLine();
                            Console.WriteLine("Enter your state");
                            addressModel.State = Console.ReadLine();
                            addressBookRepo.RetrivePersonsCityAndState(addressModel);
                            break;
                        case 4:
                            Console.WriteLine("Enter your city name to get the persons alphabetically");
                            addressModel.City = Console.ReadLine();
                            addressBookRepo.OrderByFirstName(addressModel);
                            break;
                         case 5:
                            addressBookRepo.RetriveDataFromPersonAddressBook();
                            break;
                        case 6:
                            addressBookRepo.CountByType();
                            break;
                        case 7:;
                            Console.WriteLine("Enter your city");
                            addressModel.City = Console.ReadLine();
                            Console.WriteLine("Enter your state");
                            addressModel.State = Console.ReadLine();
                            addressBookRepo.CountByCityOrState(addressModel);
                            break;
                        default:
                            Console.WriteLine("Please Enter correct option");
                            break;
                    }
                    Console.WriteLine("Do you want to continue(Y / N) ? ");
                    var variable = Console.ReadLine();
                    if (variable.Equals("y"))
                    {
                        continue;
                    }
                    else
                    {
                        break;
                    }
                }
                catch (System.FormatException formatException)
                {
                    Console.WriteLine(formatException.Message);
                }

            }
            Console.ReadKey();
        }
    }
}

