using CsvHelper;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Formats.Asn1;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook
{
    internal class DataBase
    {
        List<Contact> details ;
        public Random R = new Random();

        public void CreateDataBase()
        {
            SqlConnection con = new SqlConnection("data source = (localdb)\\MSSQLLocalDB; initial catalog=master; integrated Security= true");
            try
            {
                string query = "Create Database AdvanceAddressBook";
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                cmd.ExecuteNonQuery();
                Console.WriteLine("DataBase Created Sucessfully");
            }
            catch (Exception ex)
            {
                Console.WriteLine("There is no database created ");
            }
            finally
            {
                con.Close();
            }
        }
        public static SqlConnection con = new SqlConnection("data source = (localdb)\\MSSQLLocalDB; initial catalog=AdvanceAddressBook; integrated Security= true");
        public void CreateTable()
        {
            try
            {
                string query = "Create table ContactDetails(id int primary key identity(1,1),firstName varchar(20),lastName varchar(20),address varchar(30),city varchar(20),state varchar(20),zip bigint,phonenumber bigint,email varchar(30),ContactTime datetime,OwnerName varchar(max));";
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                cmd.ExecuteNonQuery();
                Console.WriteLine("Table Created Sucessfully");
            }
            catch (Exception ex)
            {
                Console.WriteLine("There is no Table created " + ex);
            }
            finally
            {
                con.Close();
            }
        }
        public void AddDetails()
        {
            try
            {
                AddressBooks addressBooks = new AddressBooks(); 
                Dictionary<string, List<Contact>> dict = addressBooks.getDict();

                foreach (var contact in dict)
                {
                    foreach (var data in contact.Value)
                    {                     
                        DateTime randomDateTime = new DateTime(R.Next(1900, 2023), R.Next(12), R.Next(31));
                        SqlCommand com = new SqlCommand("AddContactDetails", con);
                        com.CommandType = CommandType.StoredProcedure;
                        com.Parameters.AddWithValue("@firstName", data.FirstName);
                        com.Parameters.AddWithValue("@lastName", data.LastName);
                        com.Parameters.AddWithValue("@address", data.Address);
                        com.Parameters.AddWithValue("@city", data.City);
                        com.Parameters.AddWithValue("@state", data.State);
                        com.Parameters.AddWithValue("@zip", data.Zip);
                        com.Parameters.AddWithValue("@phonenumber", data.PhoneNumber);
                        com.Parameters.AddWithValue("@email", data.Email);
                        com.Parameters.AddWithValue("@contact", randomDateTime);
                        com.Parameters.AddWithValue("@OwnerName", contact.Key);
                        con.Open();
                        com.ExecuteNonQuery();
                        Console.WriteLine("Contact Added");
                        con.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }
        public void GetAllDetails()
        {
            details = new List<Contact>();
            SqlCommand com = new SqlCommand("GetAllDetails", con);
            com.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            con.Open();
            da.Fill(dt);
            con.Close();
            foreach (DataRow dr in dt.Rows)
            {
                details.Add(
                    new Contact
                    {
                        Id = Convert.ToInt32(dr["id"]),
                        FirstName = Convert.ToString(dr["firstName"]),
                        LastName = Convert.ToString(dr["lastName"]),
                        ContactDate = Convert.ToDateTime(dr["ContactTime"]),
                        Address = Convert.ToString(dr["address"]),
                        City = Convert.ToString(dr["city"]),
                        State = Convert.ToString(dr["state"]),
                        Email = Convert.ToString(dr["email"]),
                        Zip = Convert.ToString(dr["zip"]),
                        PhoneNumber = Convert.ToString(dr["phonenumber"]),
                        OwnerName= Convert.ToString(dr["OwnerName"])
                    }
                    );
            }
            foreach (var data in details)
            {
                Console.WriteLine(data.Id + " " + data.FirstName + " " + data.LastName + " " + data.Address + " " + data.City + " " + data.State + " " + data.Zip + " " + data.PhoneNumber + " " + data.Email + " " + data.ContactDate+" "+data.OwnerName);
            }
        }
        public void UpdateDetails(Contact contact)
        {
            try
            {
                SqlCommand com = new SqlCommand("EditContactDetails", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@firstName", contact.FirstName);
                com.Parameters.AddWithValue("@lastName", contact.LastName);
                com.Parameters.AddWithValue("@address", contact.Address);
                com.Parameters.AddWithValue("@city", contact.City);
                com.Parameters.AddWithValue("@state", contact.State);
                com.Parameters.AddWithValue("@zip", contact.Zip);
                com.Parameters.AddWithValue("@phonenumber", contact.PhoneNumber);
                com.Parameters.AddWithValue("@email", contact.Email);
                com.Parameters.AddWithValue("@ContactDate", contact.ContactDate);
                com.Parameters.AddWithValue("@OwnerName", contact.OwnerName);
                con.Open();
                int i = com.ExecuteNonQuery();
                Console.WriteLine("DataBase Updated");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        internal void GetDetailsInTimeRange(DateTime start, DateTime end)
        {
            details = new List<Contact>();
            SqlCommand com = new SqlCommand("GetDetailsInTimeRange", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@startTime", start);
            com.Parameters.AddWithValue("@endTime", end);
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            con.Open();
            da.Fill(dt);
            con.Close();
            foreach (DataRow dr in dt.Rows)
            {
                details.Add(
                    new Contact
                    {
                        Id = Convert.ToInt32(dr["id"]),
                        FirstName = Convert.ToString(dr["firstName"]),
                        LastName = Convert.ToString(dr["lastName"]),
                        ContactDate = Convert.ToDateTime(dr["ContactTime"]),
                        Address = Convert.ToString(dr["address"]),
                        City = Convert.ToString(dr["city"]),
                        State = Convert.ToString(dr["state"]),
                        Email = Convert.ToString(dr["email"]),
                        Zip = Convert.ToString(dr["zip"]),
                        PhoneNumber = Convert.ToString(dr["phonenumber"]),
                        OwnerName = Convert.ToString(dr["OwnerName"])
                    }
                    );
            }
            foreach (var data in details)
            {
                Console.WriteLine(data.Id + " " + data.FirstName + " " + data.LastName + " " + data.Address + " " + data.City + " " + data.State + " " + data.Zip + " " + data.PhoneNumber + " " + data.Email + " " + data.ContactDate + " " + data.OwnerName);
            }
        }

        internal void GetUsingCityandstate(string City,string State)
        {
            details = new List<Contact>();
            SqlCommand com = new SqlCommand("GetDetailsUsingCityState", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@City", City);
            com.Parameters.AddWithValue("@State", State);
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            con.Open();
            da.Fill(dt);
            con.Close();
            foreach (DataRow dr in dt.Rows)
            {
                details.Add(
                    new Contact
                    {
                        Id = Convert.ToInt32(dr["id"]),
                        FirstName = Convert.ToString(dr["firstName"]),
                        LastName = Convert.ToString(dr["lastName"]),
                        ContactDate = Convert.ToDateTime(dr["ContactTime"]),
                        Address = Convert.ToString(dr["address"]),
                        City = Convert.ToString(dr["city"]),
                        State = Convert.ToString(dr["state"]),
                        Email = Convert.ToString(dr["email"]),
                        Zip = Convert.ToString(dr["zip"]),
                        PhoneNumber = Convert.ToString(dr["phonenumber"]),
                        OwnerName = Convert.ToString(dr["OwnerName"])
                    }
                    );
            }
            foreach (var data in details)
            {
                Console.WriteLine(data.Id + " " + data.FirstName + " " + data.LastName + " " + data.Address + " " + data.City + " " + data.State + " " + data.Zip + " " + data.PhoneNumber + " " + data.Email + " " + data.ContactDate + " " + data.OwnerName);
            }
        }
        public void AddUsingThreds()
        {
            DateTime start = DateTime.Now;
            AddressBooks addressBooks = new AddressBooks();
            Dictionary<string, List<Contact>> dict = addressBooks.getDict();
            Task thread = new Task(
            () =>
            {
                foreach (var contact in dict)
                {
                    foreach (var data in contact.Value)
                    {
                        DateTime randomDateTime = new DateTime(R.Next(1900, 2023), R.Next(12), R.Next(31));
                        SqlCommand com = new SqlCommand("AddContactDetails", con);
                        com.CommandType = CommandType.StoredProcedure;
                        com.Parameters.AddWithValue("@firstName", data.FirstName);
                        com.Parameters.AddWithValue("@lastName", data.LastName);
                        com.Parameters.AddWithValue("@address", data.Address);
                        com.Parameters.AddWithValue("@city", data.City);
                        com.Parameters.AddWithValue("@state", data.State);
                        com.Parameters.AddWithValue("@zip", data.Zip);
                        com.Parameters.AddWithValue("@phonenumber", data.PhoneNumber);
                        com.Parameters.AddWithValue("@email", data.Email);
                        com.Parameters.AddWithValue("@contact", randomDateTime);
                        com.Parameters.AddWithValue("@OwnerName", contact.Key);
                        con.Open();
                        com.ExecuteNonQuery();
                        Console.WriteLine("Contact Added");
                        con.Close();
                    }
                }
            });
            //thread.Start();
            //thread.Wait();
            DateTime end = DateTime.Now;
            Console.WriteLine("Duration with Thread " + (end - start));
        }
    }
}
