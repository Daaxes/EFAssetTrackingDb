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
        public static List<Computer> ComputerList = new List<Computer>();
        public static List<Phone> PhoneList = new List<Phone>();

        // Returns the amount of headquarters
        public static int GetNumberOfHQsInDb()
        {
            return Context.HQs.Count(HQs => HQs.Id > 0);
        }

        // Returns the amount of office
        public static int GetNumberOfOfficesInDb()
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
        public static int GetNumberOfUniqCountrysInDb()
        {
            return Context.HQs.Select(HQs => HQs.HQCountry)
            .Union(Context.Offices.Select(Offices => Offices.OfficeCountry))
            .Distinct()
            .Count();
        }

        // returns the amount of Computers
        public static int GetNumberOfComputersInDb()
        {
            return Context.Computers.Count(Computers => Computers.Id > 0);
        }

        // returns the amount of Phones in Database
        public static int GetNumberOfPhonesInDb()
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

            displayList = display.CombineWarrentyAssetInfo(assetList); // Compine warrenty with assetlist to creat displayList used for output with warrenty colors
            return displayList;
        }

        // InsertDataToDb(int ComputerPhone, string brand, string model, string computerType, int price, DateTime date, int office)
        // ComputerPhone 0 = Computer
        // ComputerPhone 1 = Phone
        public static void InsertDataToDb(int ComputerPhone, string brand, string model, string computerType, int price, DateTime date, int officeId)
        {
            Display display = new Display();
            int success = 0;
            display.ClearInfoMenu();
            
            if (ComputerPhone == 0) 
            {
                Computer newComputer = new Computer(brand, model, computerType, price, date, officeId);
                Context.Computers.Add(newComputer);
                success = Context.SaveChanges();
            }
            else if (ComputerPhone == 1) 
            {
                Phone newPhone = new Phone(brand, model, computerType, price, date, officeId);
                Context.Phones.Add(newPhone);
                success = Context.SaveChanges();
            }

            // Save changes to the database
            display.ClearInfoMenu();
            if (success > 0)
            {
                display.PrintOutputPos(display.YELLOW, "Update succsseful", display.POSX4 + 1, display.POSY3 + 1);
                Thread.Sleep(display.MILLISECONDS);
                display.ClearInfoMenu();
            }
            else
            {
                display.PrintOutputPos(display.RED, "Update failed", display.POSX4 + 1, display.POSY3 + 1);
                Thread.Sleep(display.MILLISECONDS);
                display.ClearInfoMenu();
            }
        }

        // public static int DeleteDataInDb(List<Display> asset)
        // Takes in AssetList
        // Return number of records deleted in database if 0 then it failed
        public static int UpdateRecordInDb(List<Display> asset)
        {
            Display display = new Display();

            string computerPhone = "";
            int assetId = 0;

            foreach (Display item in asset)
            {
                computerPhone = item.ComputerPhone.ToLower();
                assetId = item.ComputerPhoneId;
            }

            //var record = Context.Computers.FirstOrDefault(a => a.Id == assetId)
            //            .;
            //var record = Context.Computers.Select(a => a.Id == assetId)
            //            .Join(;

            var record = Context.Computers
                            .Where(computer => computer.Id == assetId)
                            .Join(Context.Offices, computer => computer.OfficeId, office => office.Id, (computer, office) => new { computer, office })
                            .Join(Context.HQs, result => result.office.HQId, hq => hq.Id, (result, hq) => new { result.computer, result.office, hq })
                            .Select(result => new
                            {
                                ComputerId = result.computer.Id,
                                ComputerType = result.computer.Type,
                                Brand = result.computer.Brand,
                                Model = result.computer.Model,
                                PurchaseDate = result.computer.PurchaseDate,
                                Price = result.computer.Price,
                                OfficeName = result.office.OfficeName,
                                OfficeCountry = result.office.OfficeCountry,
                                HQName = result.hq.HQName,
                                HQCountry = result.hq.HQCountry
                            })
                            .FirstOrDefault();

            int id = record.ComputerId;
            string brand = record.Brand;
            string model = record.Model;
            string type = record.ComputerType;
            int price = record.Price;
            DateTime purchaceDate = record.PurchaseDate;
            string officeName = $"{record.OfficeName} {record.OfficeCountry}";
            string hqName = $"HQ {record.HQName} in {record.HQCountry}";

            //if (computerPhone == "computer".ToLower())
            //{
            //    var record = Context.Computers.FirstOrDefault(a => a.Id == assetId);
            //    Context.Computers.Remove(record);
            //    return Context.SaveChanges();
            //}
            //else if (computerPhone == "phone".ToLower())
            //{
            //    var record = Context.Phones.FirstOrDefault(a => a.Id == assetId);
            //    Context.Phones.Remove(record);
            //    return Context.SaveChanges();
            //}
            return 0;
        }

        // public static int DeleteDataInDb(List<Display> asset)
        // Takes in AssetList
        // Return number of records deleted in database if 0 then it failed
        public static int DeleteRecordInDb(List<Display> asset)
        {
            Display display = new Display();

            string computerPhone = "";
            int assetId = 0;

            foreach (Display item in asset)
            {
                computerPhone = item.ComputerPhone.ToLower();
                assetId = item.ComputerPhoneId;
            }

            if (computerPhone == "computer".ToLower())
            {
                var record = Context.Computers.FirstOrDefault(a => a.Id == assetId);
                Context.Computers.Remove(record);
                return Context.SaveChanges();
            }
            else if (computerPhone == "phone".ToLower())
            {
                var record = Context.Phones.FirstOrDefault(a => a.Id == assetId);
                Context.Phones.Remove(record);
                return Context.SaveChanges();
            }
            return 0;
        }
    }
}
