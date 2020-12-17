using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace AddressBookADO.net
{
    public class AddressBookRepo
    {
        public static string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=AddressBookService;Integrated Security=True";
        SqlConnection connection = new SqlConnection(connectionString);


        /// <summary>
        /// Gets all data.
        /// </summary>
        /// <exception cref="Exception"></exception>
        public void GetAllData()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                AddressModel addressModel = new AddressModel();
                using (connection)
                {
                    SqlCommand command = new SqlCommand("spRetriveData", this.connection);
                    command.CommandType = CommandType.StoredProcedure;
                    this.connection.Open();
                    SqlDataReader dr = command.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            addressModel.PersonId = dr.GetInt32(0);
                            addressModel.Firstname = dr.GetString(1);
                            addressModel.Lastname = dr.GetString(2);
                            addressModel.Address = dr.GetString(3);
                            addressModel.City = dr.GetString(4);
                            addressModel.State = dr.GetString(5);
                            addressModel.Zip = dr.GetInt32(6);
                            addressModel.MobileNumber = dr.GetString(7);
                            addressModel.EmailId = dr.GetString(8);
                            Console.WriteLine("{0},{1},{2},{3},{4},{5},{6},{7},{8}", addressModel.PersonId, addressModel.Firstname, addressModel.Lastname
                                , addressModel.Address, addressModel.City, addressModel.State, addressModel.Zip, addressModel.MobileNumber, addressModel.EmailId);

                        }
                        dr.Close();
                        this.connection.Close();
                    }
                    else
                    {
                        Console.WriteLine("No data found");
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                this.connection.Close();
            }

        }
    }
}
