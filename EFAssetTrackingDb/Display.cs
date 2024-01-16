using System;
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
        public ConsoleColor MenuColor { get; set; }

        public readonly ConsoleColor darkYelloe = ConsoleColor.DarkYellow;
        public readonly ConsoleColor red = ConsoleColor.Red;
        public readonly ConsoleColor green = ConsoleColor.Green;
        public readonly ConsoleColor blue = ConsoleColor.Blue;
        public readonly ConsoleColor yellow = ConsoleColor.Yellow;
        public readonly ConsoleColor black = ConsoleColor.Black;
        public readonly ConsoleColor white = ConsoleColor.White;

        // variables for writing background Position X
        public readonly int PosX1 = 0;
        public readonly int PosX2 = 24;
        public readonly int PosX3 = 50;
        public readonly int PosX4 = 85;
        public readonly int PosX5 = 119;

        // variables for writing background Position Y
        public readonly int PosY1 = 0;
        public readonly int PosY2 = 4;
        public readonly int PosY3 = 6;
        public readonly int PosY4 = 12;
        public readonly int PosY5 = 14;
        public readonly int PosY6 = 16;
        public readonly int PosY7 = 29;

        List<Display> StoreOutputList = new List<Display>();

        public Display()
        {
        }

        public Display(ConsoleColor menuColor, string outputString)
        {
            MenuColor = menuColor;
            OutputString = outputString;
            //PosX = posX;
            //PosY = posY;
        }

        // Printout errormessages
        public void ShowErrorMessages(string error, int posX, int posY, bool show)
        {
            if (show)
            {
                ConsoleColor currentFGColor = Console.ForegroundColor;
                Console.BackgroundColor = red;
                Console.ForegroundColor = white;
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
        //private void InitStoreOutputList()
        //{
        //    StoreOutputList.Clear();
        //}

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

        //// Method to clear specified lines on the console
        //public void ClearOutputScreenFromPosX(int posX, int posY, int lines = 128)
        //{
        //    for (int i = posX; i < lines + 1 + posX; i++)
        //    {
        //        ClearLine(i, posY);
        //    }
        //}

        public void ClearMenu()
        {
            for (int y = PosY3; y < PosY4 - 1; y++)
            {
                for (int x = PosX1 + 1; x < PosX2 - 1; x++)
                {
                    PrintOutputPos(black, " ", x, y);
                }
            }
        }

        public void ClearSubMenu()
        {
            for (int y = PosY3 + 1; y < PosY4 - 1; y++)
            {
                for (int x = PosX2 + 1; x < PosX3 - 1; x++)
                {
                    PrintOutputPos(black, " ", x, y);
                }
            }
        }

        public void ClearOutputScreen()
        {
            for (int y = PosY6 + 1; y < PosY7 - 1; y++)
            {
                for (int x = PosX1 + 1; x < PosX5 - 1; x++)
                {
                    PrintOutputPos(black, " ", x, y);
                }
            }
        }

        public void ClearInfoMenuTitle()
        {
            for (int x = PosX3 + 1; x < PosX5 - 1; x++)
            {
                PrintOutputPos(black, " ", x, PosY3 + 1);
            }
        }
        public void ClearInfoMenu()
        {
            for (int y = PosY3 + 1; y < PosY4 - 1; y++)
            {
                for (int x = PosX3 + 1; x < PosX4 - 1; x++)
                {
                    PrintOutputPos(black, " ", x, y);
                }
            }
        }

        // Metods for set the positions
        public void SetCursurPos(int posX, int posY)
        {
            Console.SetCursorPosition(posX, posY);
        }

        // Write the whole background
        public void WriteBackground()
        {
            for (int i = 1; i <= 118; i++)
            {
                PrintOutputPos(yellow, "═", i, PosY1);
                PrintOutputPos(yellow, "═", i, PosY2);
                PrintOutputPos(yellow, "═", i, PosY7);
                PrintOutputPos(yellow, "═", i, PosY5);
                PrintOutputPos(yellow, "═", i, PosY6);

                if (i < PosY7)
                {
                    PrintOutputPos(yellow, "║", PosX1, i);
                    PrintOutputPos(yellow, "║", PosX5, i);
                }

                if (i > 4 && i < PosY5)
                {
                    PrintOutputPos(yellow, "║", PosX2, i);
                    PrintOutputPos(yellow, "║", PosX3, i);
                    PrintOutputPos(yellow, "║", PosX4, i);

                }

                if (i > 0 && i < PosX2)
                {
                    PrintOutputPos(yellow, "═", i, PosY4);
                }

                if (i > PosX2)
                {
                    PrintOutputPos(yellow, "═", i, PosY3);
                }
            }

            PrintOutputPos(yellow, "╔", PosX1, PosY1);
            PrintOutputPos(yellow, "╚", PosX1, PosY7);
            PrintOutputPos(yellow, "╗", PosX5, PosY1);
            PrintOutputPos(yellow, "╝", PosX5, PosY7);
            PrintOutputPos(yellow, "╠", PosX1, PosY2);
            PrintOutputPos(yellow, "╣", PosX5, PosY2);
            PrintOutputPos(yellow, "╣", PosX5, PosY5);
            PrintOutputPos(yellow, "╣", PosX5, PosY6);
            PrintOutputPos(yellow, "╠", PosX1, PosY4);
            PrintOutputPos(yellow, "╣", PosX2, PosY4);
            PrintOutputPos(yellow, "╠", PosX1, PosY5);
            PrintOutputPos(yellow, "╠", PosX1, PosY6);
            PrintOutputPos(yellow, "╩", PosX2, PosY5);
            PrintOutputPos(yellow, "╦", PosX2, PosY2);

            PrintOutputPos(yellow, "╦", PosX3, PosY2);
            PrintOutputPos(yellow, "╩", PosX3, PosY5);

            PrintOutputPos(yellow, "╦", PosX3, PosY2);
            PrintOutputPos(yellow, "╠", PosX2, PosY3);
            PrintOutputPos(yellow, "╣", PosX5, PosY3);
            PrintOutputPos(yellow, "╬", PosX3, PosY3);

            PrintOutputPos(yellow, "╦", PosX4, PosY2);
            PrintOutputPos(yellow, "╬", PosX4, PosY3);
            PrintOutputPos(yellow, "╩", PosX4, PosY5);


            PrintOutputPos(green, "Sub menu", PosX2 + 2, PosY2 + 1);
            //PrintOutputPos(green, "Database changes", 53, PosY2 + 1);
            PrintOutputPos(green, "Output window", 53, PosY5 + 1);

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
            Console.ForegroundColor = yellow;
            Console.WriteLine("> [0] for showing menu");
            PrintOutputPos(blue, DbQuerys.getNumberOfHQsInDb().ToString(), 21, 1); // Desplays out haw many HQs there are
            PrintOutputPos(blue, DbQuerys.getNumberOfOfficesInDb().ToString(), 40, 1);
            PrintOutputPos(blue, DbQuerys.getnumberofUniqCountryIndb().ToString(), 63, 1);
            PrintOutputPos(blue, DbQuerys.getnumberofComputersIndb().ToString(), 21, 2);
            PrintOutputPos(blue, DbQuerys.getnumberofPhonesIndb().ToString(), 21, 3);
            PrintOutputPos(blue, DbQuerys.CountWarrentyYellow(0).ToString(), 40, 3); // Count number of phones within Warrent Yellow span 6 to 3 mount left on warrenty
            PrintOutputPos(blue, DbQuerys.CountWarrentyYellow(1).ToString(), 40, 2); // Count number of computers within Warrent Yellow span 6 to 3 mount left on warrenty
            PrintOutputPos(blue, DbQuerys.CountWarrentyRed(0).ToString(), 63, 3); // Count number of phones within Warrent Red span 3 mount left on warrenty
            PrintOutputPos(blue, DbQuerys.CountWarrentyRed(1).ToString(), 63, 2); // Count number of computers within Warrent Red span 3 mount left on warrenty
            PrintOutputPos(blue, DbQuerys.CountWarrentyBlue(0).ToString(), 95, 3); // Count number of phones without Warrent 
            PrintOutputPos(blue, DbQuerys.CountWarrentyBlue(1).ToString(), 95, 2); // Count number of computers without Warrent
            Console.ResetColor();

        }

        public void ShowMenu(int posX, int posY)
        {
            SetCursurPos(posX, posY);                    // Set Cursur to input line
            Console.WriteLine("> [1] List all assets:");
            Console.WriteLine("> [2] Add a new asset:");
            Console.WriteLine("> [3] Test a car   :");
            Console.WriteLine("> [4] Delete a car :");
            Console.WriteLine("> [5] Save to Db   :");
            Console.WriteLine("> [Q] Save and Quit:");
            ShowMakeYourChoiseMenu(true);
            //            ShowLine(green, "> Make your choise:", posX, posY + 7);
            //            SetCursurPos(posX + 19, posY + 13);                    // Set Cursur to input line

            Console.ResetColor();
        }

        public void ShowMakeYourChoiseMenu(bool show)
        {
            string outputText = "Make your choise: ";
            if (show)
            {
                PrintOutputPos(green, outputText, PosX1 + 2, PosY4 + 1);
            }
            else
            {
                ClearOutputScreenFromPosX(PosX1 + 1 + outputText.Length, PosY4 + 1, 2);
            }
        }


        public void ShowInsertInToDbMenu()
        {
            //            SetCursurPos(posX + 1, posY);                    // Set Cursur to input line
            PrintOutputPos(green, " Insert into database", PosX2 + 1, PosY3 + 1);
            PrintOutputPos(green, " [1] Insert Computer:", PosX2 + 1, PosY3 + 2);
            PrintOutputPos(green, " [2] Insert Phone:", PosX2 + 1, PosY3 + 3);
            //            SetCursurPos(PosX + 21, posY + 13);                    // Set Cursur to input line

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
        // Method to display a string at a specific position without clearing the line first
        //public void printOutput(ConsoleColor menuColor, string str, int posX, int posY)
        //{
        //    StoreOutputList.Add(new Display(menuColor, str));

        //    Console.ForegroundColor = menuColor;
        //    SetCursurPos(posX, posY);
        //    Console.Write(str);
        //}
        public void PrintOutputPos(ConsoleColor menuColor, string str, int posX, int posY)
        {
            Console.ForegroundColor = menuColor;
            SetCursurPos(posX, posY);
            Console.Write(str);
        }

        public void DeleteShowedString()
        {
            foreach (Display display in StoreOutputList)
            {
                ClearLine(display.PosX, display.PosY);
            }
        }

        public void ShowWarrentyInfo()
        {
            PrintOutputPos(blue, "Blue = Out of warrenty", PosX3 + 2, PosY3 + 1);
            PrintOutputPos(yellow, "Yellow = Warrenty between 6 Month and 3 Month left", PosX3 + 2, PosY3 + 2);
            PrintOutputPos(red, "Red = Warrenty 3 Month left", PosX3 + 2, PosY3 + 3);
            PrintOutputPos(green, "Green = In Warrenty", PosX3 + 2, PosY3 + 4);
        }

        // ShowAssets
        // Input List of assets
        // return row on last written line
        public List<Display> CollectAssetInfo(List<Asset> assets)
        {
            //int posX = 0;
            //int posY = 6;
            List<Display> outputList = new List<Display>();
            StringBuilder assetStr = new StringBuilder();
            ConsoleColor WarrentyColor = yellow;
            ClearInfoMenuTitle();
            PrintOutputPos(green, "Warrenty Info", PosX3 + 2, PosY2 + 1);

            //Console.Clear();
            //ShowHeader(0, 0);
            //ShowLine(blue, "Blue = Out of warrenty", posX, posY + 1);
            //ShowLine(yellow, "Yellow = Warrenty between 6 Month and 3 Month left", posX, posY + 2);
            //ShowLine(red, "Red = Warrenty 3 Month left", posX, posY + 3);
            //ShowLine(green, "Green = In Warrenty", posX, posY + 4);
            //            int count = posY + 6;
            foreach (var asset in assets)
            {
                switch (asset.Warrenty)
                {
                    case -1:
                        WarrentyColor = blue;
                        break;
                    case 0:
                        WarrentyColor = green;
                        break;
                    case 1:
                        WarrentyColor = yellow;
                        break;
                    case 2:
                        WarrentyColor = red;
                        break;
                    default:
                        break;
                };
                assetStr.Append($"{asset.Id.ToString().PadRight(2)}{asset.ComputerPhone.PadRight(9)}{asset.Brand.PadRight(8)}{asset.Model.PadRight(18)}{asset.Type.PadRight(13)}{asset.Price.ToString().PadRight(6)}");
                //                ShowLine(WarrentyColor, $"{asset.Id.ToString().PadRight(2)}{asset.ComputerPhone.PadRight(9)}{asset.Brand.PadRight(8)}{asset.Model.PadRight(18)}{asset.Type.PadRight(13)}{asset.Price.ToString().PadRight(6)}", posX, count);
                outputList = CreatePrintOutput(WarrentyColor, assetStr.ToString(), outputList);
                assetStr.Clear();
                //                count++;
            }
            ////            ShowLine(green, ">> Press 0 to show menu:", posX, count + 1); // Press 0 to show menu printout on screen
            return outputList;
        }

        public void PrintoutAssets(List<Display> DisplayList)
        {
            PrintOutputPos(green, DisplayList.Count().ToString(), PosX3 + 1, PosY3 + 1);
            int count = 0;
            foreach (var asset in DisplayList)
            {
                PrintOutputPos(asset.MenuColor, asset.OutputString, PosX1 + 1, PosY6 + 1 + count);
                count++;
            }

        }
        public List<Display> CreatePrintOutput(ConsoleColor menuColor, string assets, List<Display> outputList)
        {
            //            List<Display> outputList = new List<Display>();
            outputList.Add(new Display(menuColor, assets));
            return outputList;
        }

        // Metod to insert data to db
        public void ShowMenuIsertToDb(ConsoleColor menuColor, string computerPhone, int posX, int posY)
        {
            ClearOutputScreen();//           ClearOutputScreenFromPosY(6, 28 - posY);
            ClearSubMenu();
            ClearMenu();
            ShowInsertInToDbMenu();

            if (computerPhone.Contains("Computer") || computerPhone.Contains("Phone"))
            {
                PrintOutputPos(menuColor, computerPhone, PosX3 + 2, PosY2 + 1);
                PrintOutputPos(menuColor, "Brand            : ", PosX3 + 2, PosY2 + 3);
                PrintOutputPos(menuColor, "Model            : ", PosX3 + 2, PosY2 + 4);
                PrintOutputPos(menuColor, "Price            : ", PosX3 + 2, PosY2 + 6);
                PrintOutputPos(menuColor, "PurchaseDate     : " + DateTime.Now.Date.ToString("yyyy-MM-dd"), PosX3 + 2, PosY2 + 7);
                PrintOutputPos(menuColor, "Which Office     : ", PosX3 + 2, PosY2 + 8);
            }

            if (computerPhone.Contains("Computer"))
            {
                PrintOutputPos(menuColor, "Type of Computer : ", PosX3 + 2, PosY2 + 5);
            }
            else if (computerPhone.Contains("Phone"))
            {
                PrintOutputPos(menuColor, "Type of Phone    : ", PosX3 + 2, PosY2 + 5);
            }

        }
        public void ShowOffices(List<Office> offices)
        {
            int count = 1;
            foreach (Office office in offices)
            {
                PrintOutputPos(yellow, $"{count.ToString()} = {office.OfficeName} - {office.OfficeCountry} ", PosX4 + 2, PosY3 + count);
                count++;
            }
        }

    }
}
