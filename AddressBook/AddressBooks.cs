using System.Runtime.InteropServices;
using System.Threading.Channels;

namespace AddressBook
{
    internal class AddressBooks
    {
            List<Contact> addressBook = new List<Contact>();
        public void CreateContact()
        {
                Console.WriteLine("Enter Firstname, Last Name , address , city, state , zip , Email, PhoneNumber :");
            Contact contact = new Contact()
            { 
                FirstName = Console.ReadLine(),
                LastName = Console.ReadLine(),
                Address  = Console.ReadLine(),
                City= Console.ReadLine(),
                State = Console.ReadLine(),
                Zip = Console.ReadLine(),
                Email = Console.ReadLine(),
                PhoneNumber = Console.ReadLine(),
            };
        }
    }
}