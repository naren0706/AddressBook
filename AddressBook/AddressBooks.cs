namespace AddressBook
{
    internal class AddressBooks
    {
        List<Contact> addressBook = new List<Contact>();
        Dictionary<string, List<Contact>> dict = new Dictionary<string, List<Contact>>();

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
            addressBook.Add(contact);
            Console.WriteLine(contact.FirstName + " | " + contact.LastName + " | " + contact.Address + " | " + contact.City + " | " + contact.State + " | " + contact.Zip
                + " | " + contact.Email + " | " + contact.PhoneNumber);
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
                Console.WriteLine(data.Key);
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
    }
}