using System;
namespace AddressBook
{
    class Program
    {
        static string filePath = @"E:\BridgeGateProblems\AddressBook\AddressBook\AddressBookData.json";
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to address book problem statement");
            bool flag = true;
            AddressBooks address = new AddressBooks();
            while (flag) 
            {
                Console.WriteLine("1.create new contact \n2.edit contact \n3.Display\n4.Delete contact\n5.add To Dictonary\n6.Add To JsonFile\n7.Read From Dictonary\n8.search using" +
                    "city");
                int option = Convert.ToInt32(Console.ReadLine());
                switch (option)
                {
                    case 1:address.CreateContact();break;
                    case 2:address.EditContact();break;
                    case 3:address.Display();break;
                    case 4:address.DeleteContact();break;
                    case 5:address.AddAddressBookToDictonary();break;
                    case 6:address.AddToJsonFile(filePath);break;
                    case 7:address.ReadInventoryJson(filePath); break;
                    case 8:address.SearchUsingCity();break;
                    case 9:address.SearchUsingState();break;
                    default:flag=false;break;
                }            
            }
        }
    }
}