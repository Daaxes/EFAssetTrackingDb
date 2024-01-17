
using Azure;
using EFAssetTrackingDb;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Globalization;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Windows.Forms;

MyDbContext Context = new MyDbContext();
DbQuerys querys = new DbQuerys();
Display display = new Display();

StringBuilder input = new StringBuilder();
//const ConsoleColor darkYelloe = ConsoleColor.DarkYellow;
//const ConsoleColor red = ConsoleColor.Red;
//const ConsoleColor green = ConsoleColor.Green;
//const ConsoleColor blue = ConsoleColor.Blue;
//const ConsoleColor yellow = ConsoleColor.Yellow;
const int milliseconds = 2000;

display.ShowHeader(0, 0); // Shows header with info about headquaters, Offices, Computers and warrenty, phones and warrenty 
display.ShowMenu(0, 6);   // Shows menu
display.WriteBackground();

void CollectInsertToDB()
{
    int done = 0;
    display.ClearInfoMenu();
    display.ClearSubMenu();
    display.ShowInsertInToDbMenu();
    display.ShowMakeYourChoiseMenu(true);
    input.Clear();
    input.Append(Console.ReadLine());   // Read input to StringBuilder input
    display.ShowMakeYourChoiseMenu(false);
    switch (input.ToString())
    {
        case "0":
            display.ClearSubMenu();
            display.ShowHeader(0, 0);
            display.ShowMenu(0, 6);
            display.WriteBackground();
            break;
        case "1":
            display.ShowSubMenuCollectToDb(display.yellow, "Computer");
            done = CollectDataForDb(0);
            if (done == 0)
            {
                CollectInsertToDB();
            }
            break;
        case "2":
            display.ShowSubMenuCollectToDb(display.yellow, "Phone");
            done = CollectDataForDb(0);
            if (done == 0)
            {
                CollectInsertToDB();
            }
            break;
        case "Q":

            break;
    }
    
}

int CollectDataForDb(int computerPhone)
{
    int posX = display.PosX3 + 18;

    while (true)
    {
        string brand = InputValue(posX, display.PosY3 + 1, 0);
        string model = InputValue(posX, display.PosY3 + 2, 0);
        string type = InputValue(posX, display.PosY3 + 3, 0);
        int price = Int32.Parse(InputValue(posX, display.PosY3 + 4, 1));
        DateTime purchaseDate = DateTime.Parse(InputValue(posX, display.PosY3 + 5, 2));
        List<Office> offices = DbQuerys.getOfficesFromDb();
        display.ShowOffices(offices);
        int officeId = Int32.Parse(InputValue(posX, display.PosY3 + 6, 1));
        var oneOffice = offices.FirstOrDefault(o => o.Id == officeId);
        display.PrintOutputPos(display.yellow, $"{oneOffice.OfficeName} {oneOffice.OfficeCountry}", posX, display.PosY3 + 6);
        display.ClearInfoMenu();
        display.PrintOutputPos(display.yellow, "Save to Database? [Y/N] ", display.PosX3 + 2, display.PosY3 + 7);
        input.Clear();
        input.Append(Console.ReadLine());

        if (input.ToString().ToLower() == "y")
        {
            DbQuerys.InsertDataToDb(computerPhone, brand, model, type, price, purchaseDate, officeId);
            display.ClearSubMenu();
            display.PrintOutputPos(display.yellow, "Insert more items? [Y/N] ", display.PosX3 + 2, display.PosY3 + 1);
            input.Clear();
            input.Append(Console.ReadLine());

            if (input.ToString().ToLower() == "y")
            {
                return 0;
            }
        }
        else if (input.ToString().ToLower() == "n" || input.ToString().ToLower() == "0")
        {
            input.Clear();
            return 1;
        }
        else if (input.ToString().ToLower() == "q")
        {
        Environment.Exit(0);
        }
        return 0;        
    }
}

    // 0 = String
    // 1 = Integer
    // 2 = DateTime
    string InputValue(int posX, int posY, int varType)
    {
        //       StringBuilder input = new StringBuilder();
        display.SetCursurPos(posX, posY);
        string inputStr = Console.ReadLine().ToString();   // Read input to StringBuilder input

        if (varType == 0)
        {
            return inputStr;
        }
        else if (varType == 1)
        {
            try
            {
                int price = Int32.Parse(inputStr);
            }
            catch (FormatException)
            {
                display.ShowErrorMessages("You must write a number", posX, posY, true);
                
                Thread.Sleep(milliseconds);
                display.ShowErrorMessages("You must write a number", posX, posY, false);
                InputValue(posX, posY, varType);
            }
        }
        else if (varType == 2 && inputStr.Length > 0)
        {
            try
            {
                DateTime dateTime = DateTime.Parse(inputStr);
                return inputStr;
            }
            catch (FormatException)
            {
                display.ShowErrorMessages("You must write a Date (yyyy-MM-dd)", posX, posY, true);
                Thread.Sleep(milliseconds);
                display.ShowErrorMessages("You must write a Date (yyyy-MM-dd)", posX, posY, false);
                InputValue(posX, posY, varType);
            }
        }
        else if (varType == 2 && inputStr.Length == 0)
        {
            return DateTime.Now.Date.ToString();
        }
        return inputStr;

    }




while (true)
{
    input.Clear();                      // Clear screen
    Console.ResetColor();               // Resets forground color
                                        //    display.SetCursurPos(21, 13);
    display.ShowMakeYourChoiseMenu(true);
    input.Append(Console.ReadLine());   // Read input to StringBuilder input
    display.ShowMakeYourChoiseMenu(false);
    List<Display> displayList = new List<Display>();

    switch (input.ToString())
    {
        case "0":
            //            Console.Clear();
            display.ClearSubMenu();
            display.ShowHeader(0, 0);
            display.ShowMenu(0, 6);
            display.WriteBackground();
            break;
        case "1":
            displayList = DbQuerys.CombinePhoneAndComputerToAsset();
            display.CombineAssets(displayList, false, 1);
            break;
        case "2":
            display.ClearMenu();
            display.ClearOutputScreen();
            CollectInsertToDB();
            break;
        case "4":
            display.ClearMenu();
            display.ClearOutputScreen();
            displayList = DbQuerys.CombinePhoneAndComputerToAsset();
            display.CombineAssets(displayList, true, 1);
            break;

        case "6":
            display.SetCursurPos(0, 0);
            for (int i = 0; i < Console.LargestWindowHeight; i++)
                Console.WriteLine(i); ;      // Write newCar
            break;
        case "7":
            display.SetCursurPos(0, 0);
            for (int i = 0; i < 120; i++)
                Console.Write("X");      // Write newCar
            break;

        case "8":
            display.WriteBackground();
            break;
        //    case "3":
        //        test();               // Edit Project list if task is done
        //        break;
        //    //    case "4":
        //    //        project.SaveToFile(projectList);        // Save projectlist to file in Current working directory
        //    //        break;
        //    case "5":
        //        Car.updateDb(cars);
        //        break;
        default:
            break;
    }
}


//    Bus MyBus = Context.Busses.Include(x => x.PassengersList).FirstOrDefault(x => x.Id == 2);

//foreach (var item in MyBus.PassengersList)
//{
//    Console.WriteLine(item.Name);
//} 