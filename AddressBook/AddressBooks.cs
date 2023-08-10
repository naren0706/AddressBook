using Newtonsoft.Json;
using System.Collections.Generic;

namespace AddressBook
{
    internal class AddressBooks
    {
        List<Contact> addressBook = new List<Contact>();
        Dictionary<string, List<Contact>> dict = new Dictionary<string, List<Contact>>();

        public void AddToJsonFile(string filePath)
        {
            var json = JsonConvert.SerializeObject(dict);
            File.WriteAllText(filePath, json);
        }
        public void ReadInventoryJson(string filePath)
        {
            var json = File.ReadAllText(filePath);            
            dict = JsonConvert.DeserializeObject<Dictionary<string, List<Contact>>>(json);
        }
        public void CreateContact()
        {
            Console.WriteLine("Enter Firstname, Last Name , address , city, state , zip , Email, PhoneNumber :");
            Contact contact = new Contact()
            {
                FirstName = Console.ReadLine(),
                LastName = Console.ReadLine(),
                Address = Console.ReadLine(),
                City = Console.ReadLine(),
                State = Console.ReadLine(),
                Zip = Console.ReadLine(),
                Email = Console.ReadLine(),
                PhoneNumber = Console.ReadLine(),

            };
            Console.WriteLine("_______________");
            bool isPresent = false;
            foreach (var li in dict)
            {
                foreach (var item1 in li.Value)
                {
                    if (item1.FirstName.Equals(contact.FirstName))
                    {
                        isPresent = true;
                        break;
                    }
                }
            }
            Console.WriteLine("_______________");
            if (isPresent)
            {
                Console.WriteLine("Name is already in the address book");
            }
            else
            {
                addressBook.Add(contact);
                Console.WriteLine(contact.FirstName + " | " + contact.LastName + " | " + contact.Address + " | " + contact.City + " | " + contact.State + " | " + contact.Zip
                    + " | " + contact.Email + " | " + contact.PhoneNumber);
            }
        }
        public void AddAddressBookToDictonary()
        {
            Console.WriteLine("Enter unique name");
            string uniqueName = Console.ReadLine();
            dict.Add(uniqueName, addressBook);
            addressBook = new List<Contact>();
        }
        public void EditContact(string name, string contactName)
        {
            foreach (var data in dict)
            {
                if (data.Key.Equals(name))
                {
                    foreach (var contact in data.Value)
                    {
                        if (contact.FirstName.Equals(contactName) || contact.LastName.Equals(contactName))
                        {
                            Console.WriteLine("Enter option to edit 1. Last Name 2. Address");
                            int option = Convert.ToInt32(Console.ReadLine());
                            switch (option)
                            {
                                case 1:
                                    contact.LastName = Console.ReadLine();
                                    break;
                                case 2:
                                    contact.Address = Console.ReadLine();
                                    break;
                            }
                        }
                    }
                }
            }
        }
        public void Display()
        {
            foreach (var data in dict)
            {
                Console.WriteLine("Key : "+data.Key);
                List<Contact> val = data.Value;
                foreach (var contact in val)
                {
                    Console.WriteLine(contact.FirstName + " | " + contact.LastName + " | " + contact.Address + " | " + contact.City + " | " + contact.State + " | " + contact.Zip
                    + " | " + contact.Email + " | " + contact.PhoneNumber);
                }
            }
        }
        public void DeleteContact(String name, string contactName)
        {
            Contact contact = new Contact();
            foreach (var data in dict)
            {
                if (data.Key.Equals(name))
                {
                    foreach (var item in data.Value)
                    {
                        if (item.FirstName.Equals(contactName) || item.LastName.Equals(contactName))
                            contact = item;
                    }
                    data.Value.Remove(contact);
                }
            }
        }

        internal void SearchUsingCity()
        {
            Console.WriteLine("Enter the city name to search");
            string city = Console.ReadLine();
            bool isPresent = false;
            List<Contact> result = new List<Contact>();
            foreach (var item in dict)
            {
                 result = item.Value.Where(x => x.City == city).ToList();
            }
            foreach (var contact in result)
            {
                Console.WriteLine(contact.FirstName + " | " + contact.LastName + " | " + contact.Address + " | " + contact.City + " | " + contact.State + " | " + contact.Zip
                + " | " + contact.Email + " | " + contact.PhoneNumber);
                isPresent = true;
            }
            if (!isPresent)
            {
                Console.WriteLine("no contacts found");
            }
        }
    }
}