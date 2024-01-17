using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Numerics;
using System.Runtime.ConstrainedExecution;
using System.Runtime.Serialization.DataContracts;
using System.Text;
using System.Threading.Tasks;

namespace EFAssetTrackingDb
{
    internal class DbQuerys
    {
        private static MyDbContext Context = new MyDbContext();
        private static List<Computer> ComputerList = new List<Computer>();
        private static List<Phone> PhoneList = new List<Phone>();

        // Returns the amount of headquarters
        public static int getNumberOfHQsInDb()
        {
            return Context.HQs.Count(HQs => HQs.Id > 0);
        }

        // Returns the amount of office
        public static int getNumberOfOfficesInDb()
        {
            return Context.Offices.Count(Office => Office.Id > 0);
        }

        // Returns offices
        public static List<Office> getOfficesFromDb()
        {
            //            List<Office> list = new List<Office>();
            return Context.Offices.ToList();
        }

        // returns the amount of countrys for hq and office
        public static int getnumberofUniqCountryIndb()
        {
            return Context.HQs.Select(HQs => HQs.HQCountry)
            .Union(Context.Offices.Select(Offices => Offices.OfficeCountry))
            .Distinct()
            .Count();
        }

        // returns the amount of Computers
        public static int getnumberofComputersIndb()
        {
            return Context.Computers.Count(Computers => Computers.Id > 0);
        }

        // returns the amount of Phones in Database
        public static int getnumberofPhonesIndb()
        {
            return Context.Phones.Count(Phones => Phones.Id > 0);
        }

        // Output GetWarrenty 
        // 0: Within warrenty
        // -1: Outoff Warrenty
        // 1 Warrenty between 6 month left and 3 month left YELLOW
        // 2 Warrenty 3 month left RED
        public static int GetWarrenty(DateTime purchaseDate)
        {

            var today = Convert.ToDateTime("2024-01-20", CultureInfo.GetCultureInfo("sv-SE"));
            // Phones with 3 months or less remaining in warranty
            if (purchaseDate.AddYears(3).AddMonths(-3) <= today && purchaseDate.AddYears(3) > today)
            {
                return 2;
            }
            else if (purchaseDate.AddYears(3).AddMonths(-6) <= today && purchaseDate.AddYears(3).AddMonths(-3) > today)
            {
                return 1;
            }
            else if (purchaseDate.AddYears(3) < today)
            {
                return -1;
            }

            return 0;
        }

        // CountWarrentyYellow = warrenty between 3 to 6 month
        // input if 0 Phone
        // input if 1 Computer
        public static int CountWarrentyYellow(int computerOrPhone)
        {
            var today = DateTime.Now.Date;

            if (computerOrPhone == 0)
            {
                return Context.Phones
                    .Where(phone => phone.PurchaseDate.AddYears(3).AddMonths(-6) <= today && phone.PurchaseDate.AddYears(3).AddMonths(-3) > today)
                    .Count();
            }
            else
            {
                return Context.Computers
                    .Where(computer => computer.PurchaseDate.AddYears(3).AddMonths(-6) <= today && computer.PurchaseDate.AddYears(3).AddMonths(-3) > today)
                    .Count();
            }
        }

        // CountWarrentyRed = warrenty 3 month left
        // input if 0 Phone
        // input if 1 Computer
        public static int CountWarrentyRed(int computerOrPhone)
        {
            var today = DateTime.Now.Date;

            if (computerOrPhone == 0)
            {
                return Context.Phones
                    .Where(phone => phone.PurchaseDate.AddYears(3).AddMonths(-3) <= today && phone.PurchaseDate.AddYears(3) > today)
                    .Count();

            }
            else
            {
                return Context.Computers
                    .Where(computer => computer.PurchaseDate.AddYears(3).AddMonths(-3) <= today && computer.PurchaseDate.AddYears(3) > today)
                    .Count();
            }
        }

        // CountWarrentyBlue = Phones without warranty
        // input if 0 Phone
        // input if 1 Computer
        // CountWarrentyBlue = Without warrenty
        public static int CountWarrentyBlue(int computerOrPhone)
        {
            var today = DateTime.Now.Date;

            if (computerOrPhone == 0)
            {
                return Context.Phones
                    .Where(phone => phone.PurchaseDate.AddYears(3) < today)
                    .Count();
            }
            else
            {
                return Context.Computers
                    .Where(computer => computer.PurchaseDate.AddYears(3) < today)
                    .Count();
            }
        }

        public static List<Display> CombinePhoneAndComputerToAsset()
        {
            PhoneList = Context.Phones.ToList();
            ComputerList = Context.Computers.ToList();
            List<Asset> assetList = new List<Asset>();
            List<Display> displayList = new List<Display>();
            Display display = new Display();

            foreach (var phone in PhoneList)
            {
                int warrenty = GetWarrenty(phone.PurchaseDate);
                assetList.Add(new Asset(warrenty, "Phone", phone.Id, phone.Brand, phone.Model, phone.Type, phone.PurchaseDate, phone.Price));
            }

            foreach (var computer in ComputerList)
            {
                int warrenty = GetWarrenty(computer.PurchaseDate);
                assetList.Add(new Asset(warrenty, "Computer", computer.Id, computer.Brand, computer.Model, computer.Type, computer.PurchaseDate, computer.Price));
            }

            displayList = display.CombineWarrentyAssetInfo(assetList);
            return displayList;
        }

        // InsertDataToDb(int ComputerPhone, string brand, string model, string computerType, int price, DateTime date, int office)
        // ComputerPhone 0 = Computer
        // ComputerPhone 1 = Phone
        public static void InsertDataToDb(int ComputerPhone, string brand, string model, string computerType, int price, DateTime date, int officeId)
        {
            Display display = new Display();
            const int milliseconds = 2000;
            display.ClearInfoMenu();

            if (ComputerPhone == 0) 
            {
                int chkNumber = getnumberofComputersIndb();
                // Create a new Computer instance
                Computer newComputer = new Computer(brand, model, computerType, price, date, officeId);

                // Add the new Computer instance to the context
                Context.Computers.Add(newComputer);
                Context.SaveChanges();
                if (chkNumber < getnumberofComputersIndb()) 
                {
                    display.PrintOutputPos(display.yellow, "Update succsseful", display.PosX4 + 1, display.PosY3 + 1);
                    Thread.Sleep(milliseconds);
                 }
                else
                {
                    display.PrintOutputPos(display.yellow, "Update failed", display.PosX4 + 1, display.PosY3 + 1);
                    Thread.Sleep(milliseconds);
                }

                display.ClearInfoMenu();
            }
            else if (ComputerPhone == 1) 
            {
                // Create a new Phone instance
                Phone newPhone = new Phone(brand, model, computerType, price, date, officeId);

                // Add the new Phone instance to the context
                Context.Phones.Add(newPhone);
            }
            // Save changes to the database
            Context.SaveChanges();
        }

        public static void deletedataindb()
        {
            Display display = new Display();
        }
    }
}
