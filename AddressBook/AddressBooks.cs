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
            addressBook.Add(contact);
            Console.WriteLine(contact.FirstName+"\n"+contact.LastName+"\n"+contact.Address+"\n"+contact.City+"\n"+contact.State+"\n"+contact.Zip
                +"\n"+contact.Email+"\n"+contact.PhoneNumber);
        }

        public void EditContact(String name)
        {
            foreach (var contact in addressBook)
            {
                if (contact.FirstName.Equals(name) || contact.LastName.Equals(name))
                {
                    Console.WriteLine("Enter option to edit 1. Last Name 2. Address");
                    int option = Convert.ToInt32(Console.ReadLine());
                    switch (option)
                    {
                        case 1: contact.LastName = Console.ReadLine();
                            break;
                        case 2:
                            contact.Address = Console.ReadLine();
                            break;
                    }
                    
                }
            }

        }

        public void Display()
        {
            foreach (var contact in addressBook)
            {
                Console.WriteLine(contact.FirstName + "\n" + contact.LastName + "\n" + contact.Address + "\n" + contact.City + "\n" + contact.State + "\n" + contact.Zip
                + "\n" + contact.Email + "\n" + contact.PhoneNumber);
            }
        }
    }
}