using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.ConstrainedExecution;
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

        public static int chkWarrenty()
        {
            //var today = DateTime.Now;
            //var threeMonthsFromNow = today.AddMonths(-3);
            //var sixMonthsFromNow = today.AddMonths(-6);
            //var warrenty = 3;

            //var phonesInWarranty = Context.Phones
            //     .Where(phones => phones.PurchaseDate.AddYears(3).AddMonths(-6) >= today)
            //     .ToList();

            //var phonesWith3MonthsWarranty = Context.Phones
            //    .Where(phones => phones.PurchaseDate.AddYears(3).AddMonths(-6) <= today
            //        && phones.PurchaseDate.AddYears(3).AddMonths(-6) <= today)
            //    .ToList();

            //var phonesWith6MonthsWarranty = Context.Phones
            //    .Where(phones => phones.PurchaseDate <= today && phones.PurchaseDate.AddYears(3) <= today.AddMonths(-6) && phones.PurchaseDate.AddYears(3) >= today.AddMonths(-3))
            //    .ToList();

            // Phones purchased within the last 3 years

            var today = Convert.ToDateTime("2024-01-20", CultureInfo.GetCultureInfo("sv-SE"));//.ToString() //DateTime.Now.Date;

            // Phones purchased within the last 3 years
            // Phones purchased within the last 3 years
            // Phones purchased within the last 3 years
            // Phones purchased within the last 3 years
            var phonesInWarranty = Context.Phones
                .Where(phone => phone.PurchaseDate.AddYears(3) >= today && phone.PurchaseDate <= today)
                .ToList();

            // Phones with 3 months or less remaining in warranty
            var phonesWith3MonthsWarranty = Context.Phones
                .Where(phone => phone.PurchaseDate.AddYears(3).AddMonths(-3) <= today && phone.PurchaseDate.AddYears(3) > today)
                .ToList();

            // Phones with exactly 6 months remaining in warranty
            var phonesWith6MonthsWarranty = Context.Phones
                .Where(phone => phone.PurchaseDate.AddYears(3).AddMonths(-6) <= today && phone.PurchaseDate.AddYears(3).AddMonths(-3) > today)
                .ToList();

            // Phones without warranty
            var phonesWithoutWarranty = Context.Phones
                .Where(phone => phone.PurchaseDate.AddYears(3) < today)
                .ToList();

            // Print all phones
            List<Phone> phones = Context.Phones.ToList();
            foreach (var phone in phones)
            {
                Console.WriteLine($"\nBrand: {phone.Brand.PadRight(10)} Model: {phone.Model.PadRight(18)} PurchaseDate: {phone.PurchaseDate.ToString("yyyy-MM-dd")} med 3 år {phone.PurchaseDate.AddYears(3).ToString("yyyy-MM-dd")}");
            }

            // Print phones in warranty
            foreach (var phone in phonesInWarranty)
            {
                Console.WriteLine($"In warranty: {phone.Brand} {phone.Model}");
            }

            // Print phones with 3 months or less remaining in warranty
            foreach (var phone in phonesWith3MonthsWarranty)
            {
                Console.WriteLine($"3 Months left: {phone.Brand} {phone.Model}");
            }

            // Print phones with between 6 and 3 months remaining in warranty
            foreach (var phone in phonesWith6MonthsWarranty)
            {
                Console.WriteLine($"6 Months left: {phone.Brand} {phone.Model}");
            }

            foreach (var phone in phonesWithoutWarranty)
            {
                Console.WriteLine($"Out of warranty: {phone.Brand} {phone.Model}");
            }
            //List<Phone> phones = new List<Phone>();
            //phones=Context.Phones.ToList();

            //foreach (var phone in phones)
            //{
            //    Console.WriteLine($"\nBrand: {phone.Brand.PadRight(10)} Model: {phone.Model.PadRight(18)} PurchaseDate: {phone.PurchaseDate.ToString("yyyy-MM-dd")} med 3 år{phone.PurchaseDate.AddYears(3).ToString("yyyy-MM-dd")}"); //+ 3M: 
            //}

            //foreach (var phone in phonesInWarranty)
            //{
            //    Console.WriteLine($"In warenty: {phone.Brand} {phone.Model}");
            //}

            //foreach (var computer in phonesWith3MonthsWarranty)
            //{
            //    Console.WriteLine($"3 Month left:{computer.Brand} {computer.Model}");
            //}

            //foreach (var computer in phonesWith6MonthsWarranty)
            //{
            //    Console.WriteLine($"6 Month left:{computer.Brand} {computer.Model}");
            //}

            return 0;
        }

        // returns the amount of Computers
        public static int getnumberofPhonesIndb()
        {
            return Context.Phones.Count(Phones => Phones.Id > 0);
        }

    }
}
