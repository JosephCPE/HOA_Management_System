using System;
using System.Collections.Generic;

namespace HOA_Management_System
{
   
    class Household
    {
        public string HouseNumber { get; set; }
        public string OwnerName { get; set; }
        public int NumberOfResidents { get; set; }
        public string ContactNumber { get; set; }

        
        public void DisplayInfo()
        {
            Console.WriteLine($"House Number : {HouseNumber}");
            Console.WriteLine($"Owner Name   : {OwnerName}");
            Console.WriteLine($"Residents    : {NumberOfResidents}");
            Console.WriteLine($"Contact No.  : {ContactNumber}");
            Console.WriteLine("------------------------------");
        }
    }

    class Program
    {
       
        static List<Household> households = new List<Household>();

        static void Main(string[] args)
        {
            int choice;
            do
            {
                    
                Console.WriteLine("\nHomeowners Association Management System");
                Console.WriteLine("1. Add New Household");
                Console.WriteLine("2. View All Households");
                Console.WriteLine("3. Search Household by House Number");
                Console.WriteLine("4. Display Total Number of Households");
                Console.WriteLine("5. Display Total Number of Residents");
                Console.WriteLine("6. Exit");
                Console.Write("Enter your choice: ");

                if (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                    continue;
                }

                switch (choice)
                {
                    case 1: AddHousehold(); break;
                    case 2: ViewAllHouseholds(); break;
                    case 3: SearchHouseholdByNumber(); break;
                    case 4: DisplayTotalHouseholds(); break;
                    case 5: DisplayTotalResidents(); break;
                    case 6: Console.WriteLine("Exiting program..."); break;
                    default: Console.WriteLine("Invalid choice. Try again."); break;
                }

            } while (choice != 6);
        }

 
        static void AddHousehold()
        {
            Household newHousehold = new Household();

            Console.Write("Enter House Number: ");
            newHousehold.HouseNumber = Console.ReadLine();

            Console.Write("Enter Owner Name: ");
            newHousehold.OwnerName = Console.ReadLine();

            Console.Write("Enter Number of Residents: ");
            newHousehold.NumberOfResidents = int.Parse(Console.ReadLine());

            Console.Write("Enter Contact Number: ");
            newHousehold.ContactNumber = Console.ReadLine();

            households.Add(newHousehold);
            Console.WriteLine("Household added successfully!");
        }

 
        static void ViewAllHouseholds()
        {
            if (households.Count == 0)
            {
                Console.WriteLine("No households registered yet.");
                return;
            }

            Console.WriteLine("\n--- List of Households ---");
            foreach (var h in households)
            {
                h.DisplayInfo();
            }
        }

       
        static void SearchHouseholdByNumber()
        {
            Console.Write("Enter House Number to search: ");
            string houseNum = Console.ReadLine();

            Household found = households.Find(h => h.HouseNumber.Equals(houseNum, StringComparison.OrdinalIgnoreCase));

            if (found != null)
            {
                Console.WriteLine("\n--- Household Found ---");
                found.DisplayInfo();
            }
            else
            {
                Console.WriteLine("Household not found.");
            }
        }


        static void DisplayTotalHouseholds()
        {
            Console.WriteLine($"Total number of households: {households.Count}");
        }

        // Function to sum up all residents across households
        static void DisplayTotalResidents()
        {
            int total = 0;
            foreach (var h in households)
            {
                total += h.NumberOfResidents;
            }
            Console.WriteLine($"Total number of residents: {total}");
        }
    }
}
