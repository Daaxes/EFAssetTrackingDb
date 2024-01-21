
using Azure;
using EFAssetTrackingDb;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Globalization;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

MyDbContext Context = new MyDbContext();
DbQuerys querys = new DbQuerys();
Display display = new Display();
StringBuilder input = new StringBuilder();

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
            display.ClearSubMenuTitle();
            display.ClearSubMenu();
            break;
        case "1":
            display.ShowSubMenuCollectToDb(display.YELLOW, "Computer");
            done = CollectDataForDb(0);
            if (done == 0)
            {
                CollectInsertToDB();
            }
            break;
        case "2":
            display.ShowSubMenuCollectToDb(display.YELLOW, "Phone");
            done = CollectDataForDb(1);
            if (done == 0)
            {
                CollectInsertToDB();
            }
            break;
        case "Q":
        case "q":
            DbQuerys.QuitProgram(0);
            break;
    }
    
}

// int CollectDataForDb(int computerPhone) 
// computerPhone 0 = Computer
// computerPhone 1 = Phone
int CollectDataForDb(int computerPhone)
{
    int posX = display.POSX3 + 18;

    while (true)
    {
        string brand = InputValue(posX, display.POSY3 + 1, 0);
        string model = InputValue(posX, display.POSY3 + 2, 0);
        string type = InputValue(posX, display.POSY3 + 3, 0);
        int price = Int32.Parse(InputValue(posX, display.POSY3 + 4, 1));
        DateTime purchaseDate = DateTime.Parse(InputValue(posX, display.POSY3 + 5, 2));
        List<Office> offices = DbQuerys.getOfficesFromDb();
        display.ShowOffices(offices);
        int officeId = Int32.Parse(InputValue(posX, display.POSY3 + 6, 1));
        var oneOffice = offices.FirstOrDefault(o => o.Id == officeId);
        display.PrintOutputPos(display.YELLOW, $"{oneOffice.OfficeName} {oneOffice.OfficeCountry}", posX, display.POSY3 + 6);
        display.ClearInfoMenu();
        display.PrintOutputPos(display.YELLOW, "Save to Database? [Y/N] ", display.POSX3 + 2, display.POSY3 + 7);

        input.Clear();
        input.Append(Console.ReadLine());

        if (input.ToString().ToLower() == "y")
        {
            DbQuerys.InsertDataToDb(computerPhone, brand, model, type, price, purchaseDate, officeId); 
            display.ClearSubMenu();
            display.PrintOutputPos(display.YELLOW, "Insert more items? [Y/N] ", display.POSX3 + 2, display.POSY3 + 1);

            while(true)
            {
                input.Clear();
                input.Append(Console.ReadLine());

                if (input.ToString().ToLower() == "y")
                {
                    return 0;
                }
                else if (input.ToString().ToLower() == "n")
                {
                    DbQuerys.ResetTrackingAsset();
                    return 1;
                }
                else
                {
                    display.ClearSubMenu();
                    display.PrintOutputPos(display.YELLOW, "Wrong input Must be [Y/N] ", display.POSX3 + 2, display.POSY3 + 1);
                }
            }
        }
        else if (input.ToString().ToLower() == "n" || input.ToString().ToLower() == "0")
        {
            input.Clear();
            DbQuerys.ResetTrackingAsset();
            return 1;
        }
        else if (input.ToString().ToLower() == "q")
        {
            DbQuerys.QuitProgram(0);
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
                
                Thread.Sleep(display.MILLISECONDS);
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
                Thread.Sleep(display.MILLISECONDS);
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
            display.ClearSubMenu();
            display.ShowHeader(0, 0);
            display.ShowMenu(0, 6);
            display.WriteBackground();
            display.ClearSubMenuTitle();
            display.ClearSubMenu();
            break;
        case "1":
            displayList = DbQuerys.CombinePhoneAndComputerToAsset(); // Compine Phone and Computer from DB to AssetList then Combine Warrenty info to a DisplayList
            display.CombineAssets(displayList, 0, 1);   // CombineAssets(displayList, [0], 1) For READ asset from DB
            break;
        case "2":
            display.ClearMenu();
            display.ClearSubMenuTitle();
            display.ClearOutputScreen();
            CollectInsertToDB();                        // CollectInsertToDB() For CREATE asset to DB
            break;
        case "3":
            display.ClearMenu();
            display.ClearSubMenuTitle();
            display.ClearOutputScreen();
            display.ShowUpdateSubMenu();
            displayList = DbQuerys.CombinePhoneAndComputerToAsset(); // Compine Phone and Computer from DB to AssetList then Combine Warrenty info to a DisplayList
            display.CombineAssets(displayList, 1, 1); // CombineAssets(displayList, [1], 1) For UPDATE asset in DB
            break;
        case "4":
            display.ClearMenu();
            display.ClearOutputScreen();
            display.ClearInfoMenuTitle();
            displayList = DbQuerys.CombinePhoneAndComputerToAsset(); // Compine Phone and Computer from DB to AssetList then Combine Warrenty info to a DisplayList
            display.CombineAssets(displayList, 2, 1); // CombineAssets(displayList, [2], 1) for DELETE asset in DB
            break;
        case "q":
        case "Q":
            DbQuerys.QuitProgram(0);
            break;
        default:
            break;
    }
}


//    Bus MyBus = Context.Busses.Include(x => x.PassengersList).FirstOrDefault(x => x.Id == 2);

//foreach (var item in MyBus.PassengersList)
//{
//    Console.WriteLine(item.Name);
//} 