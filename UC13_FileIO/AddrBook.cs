using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace AddressBooks
{

    public class AddrBook
    {
        //Creating a dictionary for city and state
        public static Dictionary<string, List<AddrBook>> City = new Dictionary<string, List<AddrBook>>();
        public static Dictionary<string, List<AddrBook>> State = new Dictionary<string, List<AddrBook>>();
        //Creating a list for city and state
        public List<AddrBook> stateList;
        public List<AddrBook> cityList;
        public List<AddrBook> people;
        //Default constrcutor
        public AddrBook()
        {
            people = new List<AddrBook>();
        }
        //Instance Varaibles
        public string firstName;
        public string lastName;
        public string address;
        public string city;
        public string state;
        public string zipCode;
        public string phoneNum;
        public string emailId;
        //Parameterized Constructor
        public AddrBook(string firstName, string lastName, string phoneNum, string address, string city, string state, string zipCode, string emailId)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.phoneNum = phoneNum;
            this.address = address;
            this.city = city;
            this.state = state;
            this.zipCode = zipCode;
            this.emailId = emailId;

        }
        //ToString Method -to print the details
        public override string ToString()
        {
            return "FisrtName: " + this.firstName + " Last Name: " + this.lastName + " Address: " + this.address + "  City: " + this.city + " State: " + this.state + " Pincode: " + this.zipCode + " Phone Number: " + this.phoneNum + " Email Id: " + this.emailId;
        }
        //Getting the user details
        public void GetCustomer(string firstName, string lastName, string phoneNum, string address, string city, string state, string zipCode, string emailId)
        {
            int contact = 0;
            AddrBook person;
            if (contact == 0)
            {
                person = new AddrBook(firstName, lastName, phoneNum, address, city, state, zipCode, emailId);
                people.Add(person);
                if (State.ContainsKey(state))
                {
                    List<AddrBook> existing = State[state];
                    existing.Add(person);

                }
                else
                {
                    stateList = new List<AddrBook>();
                    stateList.Add(person);
                    State.Add(state, stateList);

                }
                if (City.ContainsKey(city))
                {
                    List<AddrBook> existing = City[city];
                    existing.Add(person);

                }
                else
                {
                    cityList = new List<AddrBook>();
                    cityList.Add(person);
                    City.Add(city, cityList);

                }
                contact++;

            else if (contact != 0)
                {
                    //Checking duplicates using lambda function-UC7
                    AddrBook addressBookSystems = people.Find(x => x.firstName.Equals(firstName));
                    if (addressBookSystems == null)
                    {
                        person = new AddrBook(firstName, lastName, address, city, state, zipCode, phoneNum, emailId);
                        people.Add(person);
                        if (State.ContainsKey(state))
                        {
                            List<AddrBook> existing = State[state];
                            existing.Add(person);

                        }
                        else
                        {
                            stateList = new List<AddrBook>();
                            stateList.Add(person);
                            State.Add(state, stateList);

                        }
                        if (City.ContainsKey(city))
                        {
                            List<AddrBook> existing = City[city];
                            existing.Add(person);

                        }
                        else
                        {
                            cityList = new List<AddrBook>();
                            cityList.Add(person);
                            City.Add(city, cityList);

                        }
                        contact++;
                    }
                    else
                    {
                        Console.WriteLine("This person already exists in your AddressBook!");
                    }

                }
            }
            //Print the details
            public void PrintCustomer(AddrBook person)
            {
                Console.WriteLine("First Name: " + person.firstName);
                Console.WriteLine("Last Name: " + person.lastName);
                Console.WriteLine("Phone Number: " + person.phoneNum);
                Console.WriteLine("Address : " + person.address);
                Console.WriteLine("City : " + person.city);
                Console.WriteLine("State : " + person.state);
                Console.WriteLine("ZipCode : " + person.zipCode);
                Console.WriteLine("Email Id: " + person.emailId);
                Console.WriteLine("-------------------------------------------");
            }
            //Modify the details
            public void Modify()
            {
                if (people.Count != 0)
                {
                    Console.WriteLine("Enter the contact to modify:");
                    string Modified = Console.ReadLine();
                    foreach (var person in people)
                    {
                        if (person.firstName.ToUpper() == Modified.ToUpper())
                        {
                            while (true)
                            {
                                Console.WriteLine("Enter the option to modify the property: ");
                                Console.WriteLine("Enter 1 to Change First name ");
                                Console.WriteLine("Enter 2 to Change Last name ");
                                Console.WriteLine("Enter 3 to Change Phone Number ");
                                Console.WriteLine("Enter 4 to Change Address ");
                                Console.WriteLine("Enter 5 to Change City ");
                                Console.WriteLine("Enter 6 to Change State ");
                                Console.WriteLine("Enter 7 to Change Pincode ");
                                Console.WriteLine("Enter 8 to Exit ");
                                int Check = Convert.ToInt32(Console.ReadLine());
                                switch (Check)
                                {
                                    case 1:
                                        Console.WriteLine("Enter the New First Name: ");
                                        person.firstName = Console.ReadLine();
                                        break;
                                    case 2:
                                        Console.WriteLine("Enter the New Last Name: ");
                                        person.lastName = Console.ReadLine();
                                        break;
                                    case 3:
                                        Console.WriteLine("Enter the New Phone Number: ");
                                        person.phoneNum = Console.ReadLine();
                                        break;
                                    case 4:
                                        Console.WriteLine("Enter the New Address: ");
                                        person.address = Console.ReadLine();
                                        break;
                                    case 5:
                                        Console.WriteLine("Enter the New City: ");
                                        person.city = Console.ReadLine();
                                        break;
                                    case 6:
                                        Console.WriteLine("Enter the New State: ");
                                        person.state = Console.ReadLine();
                                        break;
                                    case 7:
                                        Console.WriteLine("Enter the New Pin Code: ");
                                        person.zipCode = Console.ReadLine();
                                        break;
                                    case 8:
                                        return;

                                }

                            }

                        }
                        else
                        {
                            Console.WriteLine("Enter the valid name!");
                        }

                    }
                }
            }
            //Listing the user entered details or modified details
            public void ListingPeople()
            {
                if (people.Count == 0)
                {
                    Console.WriteLine("Your address book is empty.");
                    Console.ReadKey();
                    return;
                }
                Console.WriteLine("Here are the current people in your address book:\n");
                foreach (var person in people)
                {
                    PrintCustomer(person);
                }
                return;

            }
            //Removing the field using Lambda Function
            public void RemovePeople()
            {
                Console.WriteLine("Enter the first name of the person you would like to remove.");
                string firstName = Console.ReadLine();
                AddrBook person = people.FirstOrDefault(x => x.firstName.ToUpper() == firstName.ToUpper());
                if (person == null)
                {
                    Console.WriteLine("\nThat person could not be found..");

                    return;
                }
                Console.WriteLine("\nAre you sure you want to remove this person from your address book? (Y/N)");
                if (Console.ReadKey().Key == ConsoleKey.Y)
                {
                    people.Remove(person);
                    Console.WriteLine("\nPerson removed ");

                }
            }
            /// <summary>
            /// UC8-Ability to search a person in city or state
            /// </summary>
            /// <param name="key"></param>
            /// <param name="cityList"></param>
            /// <param name="city"></param>
            //Display Person names found in given City
            public static void StoreCityList(string key, List<AddrBook> cityList, string city)
            {
                List<AddrBook> CityList = cityList.FindAll(a => a.city.ToLower() == city);
                foreach (var i in CityList)
                {
                    Console.WriteLine("\nFound person \"{0}\" in Address Book \"{1}\" , residing in City {2}\n", i.firstName, key, i.city);
                }
            }
            //Display Person names found in given State
            public static void StoreStateList(string key, List<AddrBook> stateList, string state)
            {
                List<AddrBook> StateList = stateList.FindAll(x => x.state.ToLower() == state);
                foreach (var i in StateList)
                {
                    Console.WriteLine("\nFound person \"{0}\" in Address Book \"{1}\" , residing in State {2}\n", i.firstName, key, i.state);
                }
            }
            /// <summary>
            /// UC9-View Perons by city or state
            /// </summary>
            //Displaying city list or state list
            public static void DisplayCityorState()
            {
                Console.WriteLine("Enter 1-To view City list\n Enter 2-To view State list");
                int citystate = Convert.ToInt32(Console.ReadLine());
                if (citystate == 1)
                {
                    foreach (var i in City)
                    {
                        Console.WriteLine("\nDisplay List for City: {0}\n", i.Key);
                        foreach (var j in i.Value)
                        {
                            Console.WriteLine("\nFound person \"{0} {1}\" , residing in City {2}", j.firstName, j.lastName, j.city);
                        }

                        //Get no of count persons based on city
                        Console.WriteLine("\nCount of people in City is: {0}", i.Value.Count);
                    }
                }
                else
                {
                    foreach (var a in State)
                    {
                        Console.WriteLine("Display List for State: {0}\n", a.Key);
                        foreach (var b in a.Value)
                        {
                            Console.WriteLine("\nFound person \"{0} {1}\" , residing in State {2}\n", b.firstName, b.lastName, b.state);
                        }

                        //Get no of count persons based on state
                        Console.WriteLine("\nCount of people in State is: {0}\n", a.Value.Count);

                    }
                }

            }
            /// <summary>
            /// UC11-Sort Based on first name
            /// </summary>
            /// <param name="addressBook"></param>
            //Sort the contact details in address book based on firstname
            public static void SortContactPerson(Dictionary<string, List<AddrBook>> addressBook)
            {

                SortedList<string, AddrBook> sorted;
                foreach (KeyValuePair<string, List<AddrBook>> kvp in addressBook)
                {
                    Console.WriteLine("\n--------Displaying sorted Contact Person Details in address book: {0}-------\n", kvp.Key);
                    sorted = new SortedList<string, AddrBook>();
                    foreach (var member in kvp.Value)
                    {
                        sorted.Add(member.firstName, member);
                    }
                    foreach (var member in sorted)
                    {
                        Console.WriteLine(member.Value.ToString());

                    }
                }
            }
            /// <summary>
            /// UC12-SortBased On City,State or pincode
            /// </summary>
            /// <param name="addressbooknames"></param>
            //sorts based on city name
            public static void SortBasedOnCity(Dictionary<string, List<AddrBook>> addressBook)
            {

                SortedList<string, AddrBook> sorted;
                foreach (KeyValuePair<string, List<AddrBook>> kvp in addressBook)
                {
                    Console.WriteLine("\n--------Displaying Sorted contact based on city  in address book: {0}-------\n", kvp.Key);
                    sorted = new SortedList<string, AddrBook>();
                    foreach (var member in kvp.Value)
                    {
                        sorted.Add(member.city, member);
                    }
                    foreach (var member in sorted)
                    {
                        Console.WriteLine(member.Value.ToString());

                    }

                }
            }

            //sorts based on State name
            public static void SortBasedOnState(Dictionary<string, List<AddrBook>> addressBook)
            {

                SortedList<string, AddrBook> sorted;
                foreach (KeyValuePair<string, List<AddrBook>> kvp in addressBook)
                {
                    Console.WriteLine("\n--------Displaying Sorted contact based on State  in address book: {0}-------\n", kvp.Key);
                    sorted = new SortedList<string, AddrBook>();
                    foreach (var member in kvp.Value)
                    {
                        sorted.Add(member.state, member);
                    }
                    foreach (var member in sorted)
                    {
                        Console.WriteLine(member.Value.ToString());

                    }

                }
            }
            //sorts based on zipcode
            public static void SortBasedOnZipCode(Dictionary<string, List<AddrBook>> addressBook)
            {

                SortedList<string, AddrBook> sorted;
                foreach (KeyValuePair<string, List<AddrBook>> kvp in addressBook)
                {
                    Console.WriteLine("\n--------Displaying Sorted contact based on State  in address book: {0}-------\n", kvp.Key);
                    sorted = new SortedList<string, AddrBook>();
                    foreach (var member in kvp.Value)
                    {
                        sorted.Add(member.zipCode, member);
                    }
                    foreach (var member in sorted)
                    {
                        Console.WriteLine(member.Value.ToString());

                    }
                }
            }

        }


    }
    //sorts based on State name
    public static void SortBasedOnState(Dictionary<string, List<AddrBook>> addressBook)
    {

        SortedList<string, AddrBook> sorted;
        foreach (KeyValuePair<string, List<AddrBook>> kvp in addressBook)
        {
            Console.WriteLine("\n--------Displaying Sorted contact based on State  in address book: {0}-------\n", kvp.Key);
            sorted = new SortedList<string, AddrBook>();
            foreach (var member in kvp.Value)
            {
                sorted.Add(member.state, member);
            }
            foreach (var member in sorted)
            {
                Console.WriteLine(member.Value.ToString());

            }

        }
    }
    //sorts based on zipcode
    public static void SortBasedOnZipCode(Dictionary<string, List<AddrBook>> addressBook)
    {
        SortedList<string, AddrBook> sorted;
        foreach (KeyValuePair<string, List<AddrBook>> kvp in addressBook)
        {
            Console.WriteLine("\n--------Displaying Sorted contact based on State  in address book: {0}-------\n", kvp.Key);
            sorted = new SortedList<string, AddrBook>();
            foreach (var member in kvp.Value)
            {
                sorted.Add(member.zipCode, member);
            }
            foreach (var member in sorted)
            {
                Console.WriteLine(member.Value.ToString());

            }
        }
    }


}
}