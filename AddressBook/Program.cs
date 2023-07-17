using System;
namespace AddressBook
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to address book problem statement");
            bool flag = true;
            AddressBooks address = new AddressBooks();
            
            while (flag) {
            Console.WriteLine("1.create new contact \n2.edit contact \n3.Display");
                int option = Convert.ToInt32(Console.ReadLine());
                switch (option)
                {
                    case 1:
                        address.CreateContact();
                        break;
                    case 2:
                        Console.WriteLine("Enter first name or last name");
                        string name = Console.ReadLine();
                        address.EditContact(name);
                        break;
                    case 3:
                        address.Display();
                        break;
                    default:
                        flag=false;
                        break;
                }            
            }

            address.Display();

        }
    }
}