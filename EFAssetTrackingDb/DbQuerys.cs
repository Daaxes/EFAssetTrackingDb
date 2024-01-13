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

        //public static bool updateDb(List<Car> cars)
        //{
        //    int dbChkBefore = getNumberOfCarsInDb();
        //    int count = 0;


        //    foreach (Car car in cars)
        //    {
        //        count++;
        //        Context.cars.Add(car);
        //        Context.SaveChanges();
        //    }


        //    if (dbChkBefore + count == getNumberOfCarsInDb())
        //    {
        //        return true;
        //    }
        //    return false;
        //}

        //private static List<Car> initCarsList(List<Car> cars)
        //{
        //    cars.Clear();
        //    return cars;
        //}

        //public static List<Car> GetCarsFromDb()
        //{
        //    List<Car> result = new List<Car>();
        //    result = initCarsList(result);
        //    result = Context.cars.ToList();

        //    //foreach (Car car in result)
        //    //{
        //    //    Console.WriteLine($"Id: {car.Id} Brand: {car.Brand} Model: {car.Model} Year: {car.Year}");
        //    //}
        //    return result;
        //}

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

        // Output GetWarrenty 
        // 0: Within warrenty
        // -1: Outoff Warrenty
        // 1 Warrenty between 6 month left and 3 month left YELLOW
        // 2 Warrenty 3 month left RED
        public static int GetWarrenty(DateTime purchaseDate)
        {

            var today = Convert.ToDateTime("2024-01-20", CultureInfo.GetCultureInfo("sv-SE"));//.ToString() //DateTime.Now.Date;
                                                                                              //            var today = DateTime.Now.Date;
            //ShowLine(blue, "Blue = Out of warrenty", 6, 0);
            //ShowLine(yellow, "Yellow = Warrenty between 6 Month and 3 Month left", 7, 0);
            //ShowLine(red, "Red = Warrenty 3 Month left", 8, 0);
            //ShowLine(green, "Green = In Warrenty", 9, 0);
            ////var phonesInWarranty = Context.Phones
            //    .Where(phone => phone.PurchaseDate.AddYears(3) >= today && phone.PurchaseDate <= today)
            //    .Count();

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

            //var phonesWith3MonthsWarranty = Context.Phones
            //    .Where(phone => phone.PurchaseDate.AddYears(3).AddMonths(-3) <= today && phone.PurchaseDate.AddYears(3) > today)
            //    .ToList();

            //// Phones with exactly 6 months remaining in warranty
            //var phonesWith6MonthsWarranty = Context.Phones
            //    .Where(phone => phone.PurchaseDate.AddYears(3).AddMonths(-6) <= today && phone.PurchaseDate.AddYears(3).AddMonths(-3) > today)
            //    .ToList();

            //// Phones without warranty
            //var phonesWithoutWarranty = Context.Phones
            //    .Where(phone => phone.PurchaseDate.AddYears(3) < today)
            //    .ToList();


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

        public static void CombinePhoneAndComputerToAsset()
        {
            List<Phone> phoneList = Context.Phones.ToList();
            List<Computer> computerList = Context.Computers.ToList();
            List<Asset> assetList = new List<Asset>();
            List<Display> displayList = new List<Display>();
            Display display = new Display();

            foreach (var phone in phoneList)
            {
                int warrenty = GetWarrenty(phone.PurchaseDate);
                assetList.Add(new Asset(warrenty, "Phone", phone.Id, phone.Brand, phone.Model, phone.Type, phone.PurchaseDate, phone.Price));
            }

            foreach (var computer in computerList)
            {
                int warrenty = GetWarrenty(computer.PurchaseDate);
                assetList.Add(new Asset(warrenty, "Computer", computer.Id, computer.Brand, computer.Model, computer.Type, computer.PurchaseDate, computer.Price));
            }

            displayList = display.CollectAssetInfo(assetList);
        }

        // returns the amount of Computers
        public static int getnumberofPhonesIndb()
        {
            return Context.Phones.Count(Phones => Phones.Id > 0);
        }

        public static void insertdataindb()
        {
        Display display = new Display();
        display.showMenuIsertToDb(0, 6);
        }

    }
}
