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

        public const ConsoleColor darkYelloe = ConsoleColor.DarkYellow;
        public const ConsoleColor red = ConsoleColor.Red;
        public const ConsoleColor green = ConsoleColor.Green;
        public const ConsoleColor blue = ConsoleColor.Blue;
        public const ConsoleColor yellow = ConsoleColor.Yellow;
        public const ConsoleColor black = ConsoleColor.Black;

        // variables for writing background Position X
        const int PosX1 = 0;
        const int PosX2 = 24;
        const int PosX3 = 50;
        const int PosX4 = 119;

        // variables for writing background Position Y
        const int PosY1 = 0;
        const int PosY2 = 4;
        const int PosY3 = 6;
        const int PosY4 = 12;
        const int PosY5 = 14;
        const int PosY6 = 16;
        const int PosY7 = 29;

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

        private void InitStoreOutputList()
        {
            StoreOutputList.Clear();
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

        //// Method to clear specified lines on the console
        //public void ClearOutputScreenFromPosX(int posX, int posY, int lines = 128)
        //{
        //    for (int i = posX; i < lines + 1 + posX; i++)
        //    {
        //        ClearLine(i, posY);
        //    }
        //}

        private void clearSubMenu()
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
                for (int x = PosX1 + 1; x < PosX4 - 1; x++)
                {
                    PrintOutputPos(black, " ", x, y);
                }
            }
        }
        
        public void ClearInfoMenuTitle()
        {
            for (int x = PosX3 + 1; x < PosX4 - 1; x++)
                {
                    PrintOutputPos(black, " ", x, PosY3 + 1);
                }
        }
        public void ClearInfoMenu()
        {
            for (int y = PosY3 + 1; y < PosY7 - 1; y++)
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
                    PrintOutputPos(yellow, "║", PosX4, i);
                }
                
                if (i > 4 && i < PosY5)
                {
                    PrintOutputPos(yellow, "║", PosX2, i);
                    PrintOutputPos(yellow, "║", PosX3, i);
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
            PrintOutputPos(yellow, "╗", PosX4, PosY1);
            PrintOutputPos(yellow, "╝", PosX4, PosY7);
            PrintOutputPos(yellow, "╠", PosX1, PosY2);
            PrintOutputPos(yellow, "╣", PosX4, PosY2);
            PrintOutputPos(yellow, "╣", PosX4, PosY5);
            PrintOutputPos(yellow, "╣", PosX4, PosY6);
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
            PrintOutputPos(yellow, "╣", PosX4, PosY3);
            PrintOutputPos(yellow, "╬", PosX3, PosY3);

            PrintOutputPos(green, "Sub menu", 27, PosY2 + 1);
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

        public void showMenu(int posX, int posY)
        {
            SetCursurPos(posX, posY);                    // Set Cursur to input line
            Console.WriteLine("> [1] List all assets:");
            Console.WriteLine("> [2] Add a new asset:");
            Console.WriteLine("> [3] Test a car   :");
            Console.WriteLine("> [4] Delete a car :");
            Console.WriteLine("> [5] Save to Db   :");
            Console.WriteLine("> [Q] Save and Quit:");
            ShowLine(green, ">> Make your choise:", posX, posY + 7);
            SetCursurPos(posX + 21, posY + 13);                    // Set Cursur to input line

            Console.ResetColor();
        }
        public void showInsertInToDbMenu()
        {
//            SetCursurPos(posX + 1, posY);                    // Set Cursur to input line
            PrintOutputPos(green, " Insert into database", PosX2 + 1, PosY3 + 1);
            PrintOutputPos(green, " [1] Insert Computer:", PosX2 + 1, PosY3 + 2);
            PrintOutputPos(green, " [2] Insert Phone:", PosX2 + 1, PosY3 + 3);
            ShowLine(red, ">> Make your choise:", PosX1 + 1, PosY5);
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

        public void showWarrentyInfo()
        {
            PrintOutputPos(blue, "Blue = Out of warrenty", PosX3 +2, PosY3 + 1);
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
                outputList = CreatePrintOutput(WarrentyColor, assetStr.ToString());
//                count++;
            }
                ////            ShowLine(green, ">> Press 0 to show menu:", posX, count + 1); // Press 0 to show menu printout on screen
            return outputList;
        }

        public List<Display> CreatePrintOutput(ConsoleColor menuColor, string assets)
        {
            List<Display> outputList = new List<Display>();
            outputList.Add(new Display(menuColor, assets));
            return outputList;
        }

        // Metod to insert data to db
        public void showMenuIsertToDb(int posX, int posY)
        {
            ClearOutputScreen();//           ClearOutputScreenFromPosY(6, 28 - posY);
            clearSubMenu();
            showInsertInToDbMenu();
        }
    }
}
