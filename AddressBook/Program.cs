using System;
namespace AddressBook
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to address book problem statement");
            AddressBooks address = new AddressBooks();
            address.CreateContact();

        }
    }
}