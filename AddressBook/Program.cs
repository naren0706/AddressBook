﻿using System;
namespace AddressBook
{
    class Program
    {
        static string filePath = @"E:\BridgeGateProblems\AddressBook\AddressBook\AddressBookData.json";
        static string contactCsvfilePath = @"E:\BridgeGateProblems\AddressBook\AddressBook\contacts.csv";
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to address book problem statement");
            bool flag = true;
            AddressBooks address = new AddressBooks();
            while (flag) 
            {
                Console.WriteLine("1.create new contact \n2.edit contact \n3.Display\n4.Delete contact\n5.add To Dictonary\n6.Add To JsonFile\n7.Read From Json to dictonary\n8.search using" +
                    "city\n9.Search contact using State\n10.City Contact Count\n11.State Contact Count\n12.sort using name\n13.sort using state\n14.sort using City\n15.write to csv file");
                int option = Convert.ToInt32(Console.ReadLine());
                switch (option)
                {
                    case 1:  address.CreateContact();break;
                    case 2:  address.EditContact();break;
                    case 3:  address.Display();break;
                    case 4:  address.DeleteContact();break;
                    case 5:  address.AddAddressBookToDictonary();break;
                    case 6:  address.AddToJsonFile(filePath);break;
                    case 7:  address.ReadInventoryJson(filePath); break;
                    case 8:  address.SearchUsingCity();break;
                    case 9:  address.SearchUsingState();break;
                    case 10: address.getCityContactsCount();break;
                    case 11: address.getStateContactsCount();break;
                    case 12: address.SortUsingName();break;
                    case 13: address.SortUsingState();break;
                    case 14: address.SortUsingCity();break;
                    case 15: address.WriteContactsToFile(contactCsvfilePath);break;
                    case 16: address.ReadContactsFromFile(contactCsvfilePath);break;
                    default: flag=false;break;
                }            
            }
        }
    }
}