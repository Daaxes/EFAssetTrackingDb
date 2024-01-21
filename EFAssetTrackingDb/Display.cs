using Azure;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFAssetTrackingDb
{
    internal class Display
    {
        public string OutputString { get; set; }
        public int PosX { get; set; }
        public int PosY { get; set; }
        public string ComputerPhone { get; set; }
        public int ComputerPhoneId { get; set; }

        public ConsoleColor MenuColor { get; set; }

        public readonly ConsoleColor DARKYELLOW = ConsoleColor.DarkYellow;
        public readonly ConsoleColor RED = ConsoleColor.Red;
        public readonly ConsoleColor GREEN = ConsoleColor.Green;
        public readonly ConsoleColor BLUE = ConsoleColor.Blue;
        public readonly ConsoleColor YELLOW = ConsoleColor.Yellow;
        public readonly ConsoleColor BLACK = ConsoleColor.Black;
        public readonly ConsoleColor WHITE = ConsoleColor.White;

//        public ConsoleColor DEFAULTBACKGROUND;

        // variables for writing background Position X
        public readonly int POSX1 = 0;
        public readonly int POSX2 = 24;
        public readonly int POSX3 = 47;
        public readonly int POSX4 = 88;
        public readonly int POSX5 = 119;

        // variables for writing background Position Y
        public readonly int POSY1 = 0;
        public readonly int POSY2 = 4;
        public readonly int POSY3 = 6;
        public readonly int POSY4 = 12;
        public readonly int POSY5 = 14;
        public readonly int POSY6 = 16;
        public readonly int POSY7 = 29;
        
        public readonly int MILLISECONDS = 2000;
        public readonly int OUTPUTMAXROW = 11;

        static List<Display> STOREOUTPUTLIST = new List<Display>();

        public Display()
        {
        }

        public Display(ConsoleColor menuColor, string outputString, string computerPhone, int id)
        {
            MenuColor = menuColor;
            OutputString = outputString;
            ComputerPhone = computerPhone;
            ComputerPhoneId = id;
        }

        // Write the whole background
        public void WriteBackground()
        {
            for (int i = 1; i <= 118; i++)
            {
                PrintOutputPos(YELLOW, "═", i, POSY1);
                PrintOutputPos(YELLOW, "═", i, POSY2);
                PrintOutputPos(YELLOW, "═", i, POSY7);
                PrintOutputPos(YELLOW, "═", i, POSY5);
                PrintOutputPos(YELLOW, "═", i, POSY6);

                if (i < POSY7)
                {
                    PrintOutputPos(YELLOW, "║", POSX1, i);
                    PrintOutputPos(YELLOW, "║", POSX5, i);
                }

                if (i > 4 && i < POSY5)
                {
                    PrintOutputPos(YELLOW, "║", POSX2, i);
                    PrintOutputPos(YELLOW, "║", POSX3, i);
                    PrintOutputPos(YELLOW, "║", POSX4, i);

                }

                if (i > 0 && i < POSX2)
                {
                    PrintOutputPos(YELLOW, "═", i, POSY4);
                }

                if (i > POSX2)
                {
                    PrintOutputPos(YELLOW, "═", i, POSY3);
                }
            }

            PrintOutputPos(YELLOW, "╔", POSX1, POSY1);
            PrintOutputPos(YELLOW, "╚", POSX1, POSY7);
            PrintOutputPos(YELLOW, "╗", POSX5, POSY1);
            PrintOutputPos(YELLOW, "╝", POSX5, POSY7);
            PrintOutputPos(YELLOW, "╠", POSX1, POSY2);
            PrintOutputPos(YELLOW, "╣", POSX5, POSY2);
            PrintOutputPos(YELLOW, "╣", POSX5, POSY5);
            PrintOutputPos(YELLOW, "╣", POSX5, POSY6);
            PrintOutputPos(YELLOW, "╠", POSX1, POSY4);
            PrintOutputPos(YELLOW, "╣", POSX2, POSY4);
            PrintOutputPos(YELLOW, "╠", POSX1, POSY5);
            PrintOutputPos(YELLOW, "╠", POSX1, POSY6);
            PrintOutputPos(YELLOW, "╩", POSX2, POSY5);
            PrintOutputPos(YELLOW, "╦", POSX2, POSY2);

            PrintOutputPos(YELLOW, "╦", POSX3, POSY2);
            PrintOutputPos(YELLOW, "╩", POSX3, POSY5);

            PrintOutputPos(YELLOW, "╦", POSX3, POSY2);
            PrintOutputPos(YELLOW, "╠", POSX2, POSY3);
            PrintOutputPos(YELLOW, "╣", POSX5, POSY3);
            PrintOutputPos(YELLOW, "╬", POSX3, POSY3);

            PrintOutputPos(YELLOW, "╦", POSX4, POSY2);
            PrintOutputPos(YELLOW, "╬", POSX4, POSY3);
            PrintOutputPos(YELLOW, "╩", POSX4, POSY5);


            PrintOutputPos(GREEN, "Sub menu", POSX2 + 2, POSY2 + 1);
            //PrintOutputPos(GREEN, "Database changes", 53, POSY2 + 1);
            PrintOutputPos(GREEN, "Output window", 53, POSY5 + 1);

        }

        // Printout errormessages
        public void ShowErrorMessages(string error, int posX, int posY, bool show)
        {
            if (show)
            {
                ConsoleColor currentFGColor = Console.ForegroundColor;
                Console.BackgroundColor = RED;
                Console.ForegroundColor = WHITE;
                SetCursurPos(posX, posY);
                Console.WriteLine(error);
                Console.ResetColor();
                Console.ForegroundColor = currentFGColor;
            }
            else
            {

                ClearOutputScreenFromPosX(posX, posY, error.Length);
            }
        }
 
        // Method to clear a specific line on the console
        public void ClearLine(int posX, int posY)
        {
            Console.SetCursorPosition(posX, posY);
            Console.Write(new String(' ', Console.BufferWidth));
        }

        // Method to clear the entire console screen
        public void ClearOutputOnScreen()
        {
            Console.Clear();
        }

        // Method to clear specified lines on the console
        public void ClearOutputScreenFromPosY(int posY, int lines = 28)
        {
            for (int i = posY; i < lines + 1 + posY; i++)
            {
                ClearLine(0, i);
            }
        }

        public void ClearOutputScreenFromPosX(int posX, int posY, int lines = 129)
        {
            SetCursurPos(posX, posY);
            for (int i = 0; i < lines; i++)
            {
                Console.Write(" ");
            }
        }

         public void ClearMenu()
        {
            for (int y = POSY3; y < POSY4 - 1; y++)
            {
                for (int x = POSX1 + 1; x < POSX2 - 1; x++)
                {
                    ClearOutputScreenFromPosX(x, y, 1);
                }
            }
        }

        public void ClearSubMenu()
        {
            for (int y = POSY3 + 1; y < POSY5; y++)
            {
                for (int x = POSX3 + 1; x < POSX4 - 1; x++)
                {
                    ClearOutputScreenFromPosX(x, y, 1);
                }
            }
        }
        public void ClearSubMenuTitle()
        {
            for (int x = POSX2 + 1; x < POSX3; x++)
            {
                ClearOutputScreenFromPosX(x, POSY2 + 1, 1);
            }
        }

        public void ClearOutputScreen()
        {
            for (int y = POSY6 + 1; y < POSY7; y++)
            {
                for (int x = POSX1 + 1; x < POSX5 - 1; x++)
                {
                    ClearOutputScreenFromPosX(x, y, 1);
                }
            }
        }

        public void ClearInfoMenuTitle()
        {
            for (int x = POSX4 + 1; x < POSX5 - 1; x++)
            {
                ClearOutputScreenFromPosX(x, POSY2 + 1, 1);
            }
        }
        public void ClearInfoMenu()
        {
            for (int y = POSY3 + 1; y < POSY5 - 1; y++)
            {
                for (int x = POSX4 + 1; x < POSX5 - 1; x++)
                {
                    ClearOutputScreenFromPosX(x, y, 1);
                }
            }
        }

        // Metods for set the positions
        public void SetCursurPos(int posX, int posY)
        {
            Console.SetCursorPosition(posX, posY);
        }


        // Method to display category information
        public void ShowHeader(int posX, int posY)
        {
            Console.SetCursorPosition(posX, posY);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("> Welcome to AssetTracking DB");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("> You have HQs    [   ] and total of [   ] offices in       [   ] Countrys");
            Console.WriteLine("> There are total [   ] Computers    [   ] are 3 month left [   ] are between 3 and 6 month [   ] are out of warrenty.");
            Console.WriteLine("> There are total [   ] Phones and   [   ] are 3 month left [   ] are between 3 and 6 month [   ] are out of warrenty.\n");
            Console.ForegroundColor = YELLOW;
            Console.WriteLine("> [0] for showing menu");
            PrintOutputPos(BLUE, DbQuerys.GetNumberOfHQsInDb().ToString(), 19, 1); // Desplays out haw many HQs there are
            PrintOutputPos(BLUE, DbQuerys.GetNumberOfOfficesInDb().ToString(), 39, 1);
            PrintOutputPos(BLUE, DbQuerys.GetNumberOfUniqCountrysInDb().ToString(), 62, 1);
            PrintOutputPos(BLUE, DbQuerys.GetNumberOfComputersInDb().ToString(), 19, 2);
            PrintOutputPos(BLUE, DbQuerys.GetNumberOfPhonesInDb().ToString(), 19, 3);
            PrintOutputPos(BLUE, DbQuerys.CountWarrentyYellow(0).ToString(), 39, 3); // Count number of phones within Warrent Yellow span 6 to 3 mount left on warrenty
            PrintOutputPos(BLUE, DbQuerys.CountWarrentyYellow(1).ToString(), 39, 2); // Count number of computers within Warrent Yellow span 6 to 3 mount left on warrenty
            PrintOutputPos(BLUE, DbQuerys.CountWarrentyRed(0).ToString(), 62, 3); // Count number of phones within Warrent Red span 3 mount left on warrenty
            PrintOutputPos(BLUE, DbQuerys.CountWarrentyRed(1).ToString(), 62, 2); // Count number of computers within Warrent Red span 3 mount left on warrenty
            PrintOutputPos(BLUE, DbQuerys.CountWarrentyBlue(0).ToString(), 94, 3); // Count number of phones without Warrent 
            PrintOutputPos(BLUE, DbQuerys.CountWarrentyBlue(1).ToString(), 94, 2); // Count number of computers without Warrent
            Console.ResetColor();

        }

        public void ShowMenu(int posX, int posY)
        {
            SetCursurPos(posX, posY);                    // Set Cursur to input line
            Console.WriteLine("> [1] List all assets:");
            Console.WriteLine("> [2] Add a new asset:");
            Console.WriteLine("> [3] Update a asset :");
            Console.WriteLine("> [4] Delete a asset :");
            Console.WriteLine("\n> [Q] Save and Quit :");
            ShowMakeYourChoiseMenu(true);
            Console.ResetColor();
        }

        public void ShowMakeYourChoiseMenu(bool show)
        {
            string outputText = "Make your choise: ";
            if (show)
            {
                PrintOutputPos(GREEN, outputText, POSX1 + 2, POSY4 + 1);
            }
            else
            {
                ClearOutputScreenFromPosX(POSX1 + 1 + outputText.Length, POSY4 + 1, 4);
            }
        }

        public int ShowUpdateSubMenu()
        {
            ClearSubMenuTitle();
            ClearSubMenu();
            PrintOutputPos(YELLOW, "Update database", POSX2 + 2, POSY2 + 1);
            PrintOutputPos(YELLOW, "Choose Index number", POSX2 + 2, POSY3 + 1);
            DbQuerys.ResetTrackingAsset();
            return 5;
        }

        // Printout Show insert menu
        public void ShowInsertInToDbMenu()
        {
            ClearSubMenuTitle();
            ClearInfoMenuTitle();
            PrintOutputPos(GREEN, " Insert into database", POSX2 + 1, POSY2 + 1);
            PrintOutputPos(GREEN, " [1] Insert Computer:", POSX2 + 1, POSY3 + 1);
            PrintOutputPos(GREEN, " [2] Insert Phone:", POSX2 + 1, POSY3 + 2);
            Console.ResetColor();
        }

        // Method to display a menu item at a specific position
        public void ShowLine(ConsoleColor menuColor, string menuText, int posX, int posY)
        {
            int len = menuText.Length;

            ClearLine(posX, posY);
            Console.ForegroundColor = menuColor;
            SetCursurPos(posX, posY);
            Console.WriteLine(menuText);
            Console.ResetColor();
            SetCursurPos(len + 1, posY);
        }
 
        public void PrintOutputPos(ConsoleColor menuColor, string str, int posX, int posY)
        {
            Console.ForegroundColor = menuColor;
            SetCursurPos(posX, posY);
            Console.Write(str);
        }

        public void ShowWarrentyInfo()
        {
            PrintOutputPos(BLUE, "Blue = Out of warrenty", POSX3 + 2, POSY3 + 1);
            PrintOutputPos(YELLOW, "Yellow = Between 3 and 6 Month left", POSX3 + 2, POSY3 + 2);
            PrintOutputPos(RED, "Red = Warrenty 3 Month left", POSX3 + 2, POSY3 + 3);
            PrintOutputPos(GREEN, "Green = In Warrenty", POSX3 + 2, POSY3 + 4);
        }

        // ShowAssets
        // Input List of assets
        // return row on last written line
        public List<Display> CombineWarrentyAssetInfo(List<Asset> assets)
        {
            List<Display> outputList = new List<Display>();
            StringBuilder assetStr = new StringBuilder();
            ConsoleColor WarrentyColor = YELLOW;
            ClearInfoMenuTitle();
            PrintOutputPos(GREEN, "Warrenty Info", POSX3 + 2, POSY2 + 1);

            foreach (var asset in assets)
            {
                switch (asset.Warrenty)
                {
                    case -1:
                        WarrentyColor = BLUE;
                        break;
                    case 0:
                        WarrentyColor = GREEN;
                        break;
                    case 1:
                        WarrentyColor = YELLOW;
                        break;
                    case 2:
                        WarrentyColor = RED;
                        break;
                    default:
                        break;
                };
                assetStr.Append($"{" ".PadRight(3 - (asset.Id.ToString().Length) + 1)}{asset.Id.ToString().PadRight(3 + asset.Id.ToString().Length)}{asset.ComputerPhone.PadRight(10)}{asset.Brand.PadRight(9)}{asset.Model.PadRight(14)}{asset.Type.PadRight(13)}{asset.Price.ToString().PadRight(7)}{asset.PurchaseDate.ToString("yyyy-MM-dd")}");
                outputList = CreatePrintOutput(WarrentyColor, assetStr.ToString(), outputList, asset.ComputerPhone, asset.Id);
                assetStr.Clear();
            }
            return outputList;
        }
        
        // Printout Output category on screen
        public void showOutputCategory()
        {
            ClearOutputScreen();
            string outputCategory = $" Index   Id   Asset     Brand    Model         Type         Price  Purchase date";
            PrintOutputPos(WHITE, outputCategory, POSX1 + 1, POSY6 + 1);
        }

        // Printout to next menu on screen
        public void ShowBrowseToNextMenu(int index)
        {   
            int numberOfAssets = DbQuerys.GetNumberOfComputersInDb() + DbQuerys.GetNumberOfPhonesInDb();
            int countOutputSide = (numberOfAssets / OUTPUTMAXROW) + 1;
            int showedSide = (index / OUTPUTMAXROW) + 1;
            PrintOutputPos(GREEN, $"[P] Previous [{showedSide} of {countOutputSide}] Next [N] ", POSX1 + 1, POSY5 + 1);
         }

        // CombineAssets(List<Display> displayList, int chooseDbFunc, int index)
        // chooseDbFunc 0 = Select
        // chooseDbFunc 1 = Update
        // chooseDbFunc 2 = Delete
        // Used for READ, UPDATE, DELETE in database
        // Input List of assets combined to displayList
        // Input int chooseDbFunc
        // Input index, Checks which side of printout is shown if output is 15 rows 1 - row is in first side (index) 
        public int CombineAssets(List<Display> displayList, int chooseDbFunc, int index)
        {
            List<Display> tempList = new List<Display>();
            int countComputers = DbQuerys.GetNumberOfComputersInDb();
            int countPhones = DbQuerys.GetNumberOfPhonesInDb();
            int sumOfComputerPhones = countComputers + countPhones;
            int assetNumber = 0;
            tempList = displayList;
            string input = string.Empty;
            Asset asset = null;

            showOutputCategory();
            ShowWarrentyInfo();
            while (true)
            { 
                if (displayList.Count > OUTPUTMAXROW)
                {
                    ShowBrowseToNextMenu(index);
                    tempList = displayList.GetRange(0, OUTPUTMAXROW).ToList();
                    displayList.RemoveRange(0, OUTPUTMAXROW);
                    index = PrintoutAssets(tempList, index); 
                }
                else
                {
                    ShowBrowseToNextMenu(index);
                    PrintoutAssets(tempList, index);
                }
                
                ShowMakeYourChoiseMenu(true);
                input = Console.ReadLine();

                if (input.ToUpper() == "Q")
                {
                    DbQuerys.QuitProgram(0);
                }
                else if (input.ToUpper() == "N")
                {
                    ClearOutputScreen();
                    ShowMakeYourChoiseMenu(false);
                    ShowMakeYourChoiseMenu(true);
                    CombineAssets(displayList, chooseDbFunc, index);
                }
                else if (input.ToUpper() == "P")
                {
                    ClearOutputScreen();
                    ShowMakeYourChoiseMenu(false);
                    ShowMakeYourChoiseMenu(true);
                    CombineAssets(displayList, chooseDbFunc, index - 1);
                }
                else if (input == "0")
                {
                    ClearOutputScreen();
                    return 0;
                }
                else
                {
                    try
                    {
                        assetNumber = Int32.Parse(input);
                    }
                    catch (FormatException)
                    {
                        PrintOutputPos(RED, $"{input} is not a number", POSX4 + 1, POSY4 + 1);
                        CombineAssets(displayList, chooseDbFunc, index);
                    }

                    if (assetNumber > 0 && assetNumber <= sumOfComputerPhones)
                    {
                        if (chooseDbFunc == 1)
                        {
                            ClearInfoMenuTitle();
                            ClearOutputScreen();
                            asset = DbQuerys.UpdateRecordInDb(STOREOUTPUTLIST.GetRange(assetNumber - 1, 1));
                            ShowSubMenuCollectToUpdateDb(GREEN, asset);
                        }
                        else if (chooseDbFunc == 2)
                        {
                            ClearOutputScreen();
                            ClearInfoMenuTitle();
                            int deleted = DbQuerys.DeleteRecordInDb(STOREOUTPUTLIST.GetRange(assetNumber - 1, 1));
                            if (deleted > 0)
                            {
                                PrintOutputPos(GREEN, "Delete successful", POSX4 + 1, POSY4 + 1);
                                Thread.Sleep(MILLISECONDS);
                                ClearInfoMenu();
                            }
                            else
                            {
                                PrintOutputPos(RED, "Delete faild", POSX4 + 1, POSY4 + 1);
                                Thread.Sleep(MILLISECONDS);
                                ClearInfoMenu();
                            }
                        }
                    }
                    else
                    {
                        PrintOutputPos(RED, $"{assetNumber} is not within index number", POSX4 + 1, POSY4 + 1);
                        CombineAssets(displayList, chooseDbFunc, index);
                    }

                }
                ShowMakeYourChoiseMenu(false);
                ShowMakeYourChoiseMenu(true);
            }
            return 0;
        }

        public int PrintoutAssets(List<Display> displayList, int index)
        {
            int count = 1;

            foreach (var asset in displayList)
            {
                PrintOutputPos(asset.MenuColor, $"{" ".ToString().PadRight(4 - (index.ToString().Length) + 1)}{index}: {asset.OutputString}", POSX1 + 1, POSY6 + 1 + count);
                index++;
                count++;
            }
            return index;
        }
        public List<Display> CreatePrintOutput(ConsoleColor menuColor, string assets, List<Display> outputList, string computerPhone, int id)
        {
            outputList.Add(new Display(menuColor, assets, computerPhone, id));
            STOREOUTPUTLIST = outputList.ToList();
            return outputList;
        }

        // Metod to insert data to db
        public void ShowSubMenuCollectToDb(ConsoleColor menuColor, string computerPhone)
        {
            ClearOutputScreen();//           ClearOutputScreenFromPosY(6, 28 - posY);
            ClearSubMenu();
            ClearMenu();
            ShowInsertInToDbMenu();

            if (computerPhone.Contains("Computer") || computerPhone.Contains("Phone"))
            {
                PrintOutputPos(menuColor, $"Create new {computerPhone.ToLower()}", POSX3 + 2, POSY2 + 1);
                PrintOutputPos(menuColor, "Brand         : ", POSX3 + 2, POSY2 + 3);
                PrintOutputPos(menuColor, "Model         : ", POSX3 + 2, POSY2 + 4);
                PrintOutputPos(menuColor, "Price (Dollar): ", POSX3 + 2, POSY2 + 6);
                PrintOutputPos(menuColor, "PurchaseDate  : " + DateTime.Now.Date.ToString("yyyy-MM-dd"), POSX3 + 2, POSY2 + 7);
                PrintOutputPos(menuColor, "Which Office  : ", POSX3 + 2, POSY2 + 8);
            }

            if (computerPhone.Contains("Computer"))
            {
                PrintOutputPos(menuColor, "Computer type : ", POSX3 + 2, POSY2 + 5);
            }
            else if (computerPhone.Contains("Phone"))
            {
                PrintOutputPos(menuColor, "Phone type    : ", POSX3 + 2, POSY2 + 5);
            }
        }

        public void ShowOffices(List<Office> offices)
        {
            int count = 1;
            foreach (Office office in offices)
            {
                PrintOutputPos(YELLOW, $"{count.ToString()}: {office.OfficeName} - {office.OfficeCountry} ", POSX4 + 2, POSY3 + count);
                count++;
            }
        }

        public void ShowSubMenuCollectToUpdateDb(ConsoleColor menuColor, Asset asset = null)
        {
            List<Asset> assetList = new List<Asset>();
            assetList.Add(asset);
            int startPosX = POSX3 + 18;
            int startPosY = POSY3 + 1;
            int outputRow = 5;

            ClearOutputScreen();//           ClearOutputScreenFromPosY(6, 28 - posY);
            ClearSubMenu();
            ClearMenu();
            ClearSubMenu();
            ClearSubMenuTitle();
            ClearInfoMenuTitle();
            PrintOutputPos(GREEN, " Update into Database", POSX2 + 2, POSY2 + 1);
            PrintOutputPos(YELLOW, "Yellow sign cant be changed", POSX4 + 2, POSY2 + 1);
            PrintOutputPos(menuColor, $"{asset.ComputerPhone} ", POSX3 + 2, POSY2 + 1);
            PrintOutputPos(menuColor, $"Brand         : {asset.Brand}", POSX3 + 2, POSY2 + 3);
            PrintOutputPos(menuColor, $"Model         : {asset.Model}", POSX3 + 2, POSY2 + 4);
            PrintOutputPos(menuColor, $"Computer type : {asset.Type}", POSX3 + 2, POSY2 + 5);
            PrintOutputPos(menuColor, $"Price (Dollar): {asset.Price}", POSX3 + 2, POSY2 + 6);
            PrintOutputPos(menuColor, $"PurchaseDate  : {asset.PurchaseDate.ToString("yyyy-MM-dd")}" , POSX3 + 2, POSY2 + 7);
            PrintOutputPos(YELLOW, $"Office        : {asset.OfficeName} in {asset.OfficeCountry}", POSX3 + 2, POSY2 + 8);
            PrintOutputPos(YELLOW, $"HQ            : {asset.HQName} in {asset.HQCountry}", POSX3 + 2, POSY2 + 9);

            asset = CollectAssetToUpdateDb(asset, startPosX, startPosY, outputRow, 0);
            DbQuerys.UpdateDataInDb(ComputerPhone, asset);
            ClearOutputScreen();
        }

        public Asset CollectAssetToUpdateDb(Asset asset, int posX, int posY, int row, int count)
        {
            do //for (int i = count; i < row ; i++)
            {
                SetCursurPos(posX, POSY3 + 1 + count);
                string input = Console.ReadLine();

                if (input.Length > 0)
                {
                    if (count == 3)
                    {
                        try
                        {
                            var intInput = Int32.Parse(input);
                        }
                        catch (FormatException)
                        {
                            PrintOutputPos(YELLOW, "The input is not a number", POSX4 + 1, POSY3 + 1 + count);
                            Thread.Sleep(MILLISECONDS);
                            ClearInfoMenu();
                            CollectAssetToUpdateDb(asset, posX, posY + count, row, count);
                        }
                        UpdateAsset(asset, input, count);
                    }
                    if (count == 4)
                    {
                        try
                        {
                            var dateInput = DateTime.Parse(input);
                        }
                        catch (FormatException)
                        {
                            PrintOutputPos(YELLOW, "The input is not a Date", POSX4 + 1, POSY3 + 1 + count);
                            Thread.Sleep(MILLISECONDS);
                            ClearInfoMenu();
                            CollectAssetToUpdateDb(asset, posX, posY + count, row, count);
                        }
                        UpdateAsset(asset, input, count);
                    }
                }

                asset = UpdateAsset(asset, input, count);
                count++;

                if (count >= row)
                {
                    return asset;
                }
            }
            while (true);
        }

        public Asset UpdateAsset(Asset asset, string input, int index)
        {
            if (input.Length > 0)
            {
                switch (index)
                {
                    case 0:
                        asset.Brand = input;
                        break;
                    case 1:
                        asset.Model = input;
                        break;
                    case 2:
                        asset.Type = input;
                        break;
                    case 3:
                        asset.Price = Int32.Parse(input);
                        break;
                    case 4:
                        asset.PurchaseDate = DateTime.Parse(input);
                        break;
                        //case 5:
                        //    asset.OfficeId = Int32.Parse(input);
                        //    break;
                }
            }
            return asset;
        }
    }
}
