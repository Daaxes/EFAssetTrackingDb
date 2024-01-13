using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFAssetTrackingDb
{
    internal class Display
    {
        public string OutputSring { get; set; }
        public int PosX { get; set; }
        public int PosY { get; set; }
        public ConsoleColor MenuColor { get; set; }

        public const ConsoleColor darkYelloe = ConsoleColor.DarkYellow;
        public const ConsoleColor red = ConsoleColor.Red;
        public const ConsoleColor green = ConsoleColor.Green;
        public const ConsoleColor blue = ConsoleColor.Blue;
        public const ConsoleColor yellow = ConsoleColor.Yellow;


        List<Display> StoreOutputList = new List<Display>();

        public Display()
        {
        }

        public Display(ConsoleColor menuColor, string outputSring, int posX, int posY)
        {
            OutputSring = outputSring;
            PosX = posX;
            PosY = posY;
            MenuColor = menuColor;
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
        public void ClearOutputScreenFromPosY(int posY, int lines)
        {
            for (int i = posY; i < lines + 1 + posY; i++)
            {
                ClearLine(0, i);
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
            Console.WriteLine(">> Welcome to AssetTracking DB");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(">> You have HQs    [   ] and total of [   ] offices in       [   ] Countrys");
            Console.WriteLine(">> There are total [   ] Computers    [   ] are 3 month left [   ] are between 3 and 6 month [   ] are out of warrenty.");
            Console.WriteLine(">> There are total [   ] Phones and   [   ] are 3 month left [   ] are between 3 and 6 month [   ] are out of warrenty.\n");
            Console.ForegroundColor = yellow;
            Console.WriteLine(">> [0] for showing menu");
            printOutputPos(blue, DbQuerys.getNumberOfHQsInDb().ToString(), 22, 1); // Desplays out haw many HQs there are
            printOutputPos(blue, DbQuerys.getNumberOfOfficesInDb().ToString(), 41, 1);
            printOutputPos(blue, DbQuerys.getnumberofUniqCountryIndb().ToString(), 64, 1);
            printOutputPos(blue, DbQuerys.getnumberofComputersIndb().ToString(), 22, 2);
            printOutputPos(blue, DbQuerys.getnumberofPhonesIndb().ToString(), 22, 3);
            printOutputPos(blue, DbQuerys.CountWarrentyYellow(0).ToString(), 41, 3); // Count number of phones within Warrent Yellow span 6 to 3 mount left on warrenty
            printOutputPos(blue, DbQuerys.CountWarrentyYellow(1).ToString(), 41, 2); // Count number of computers within Warrent Yellow span 6 to 3 mount left on warrenty
            printOutputPos(blue, DbQuerys.CountWarrentyRed(0).ToString(), 64, 3); // Count number of phones within Warrent Red span 3 mount left on warrenty
            printOutputPos(blue, DbQuerys.CountWarrentyRed(1).ToString(), 64, 2); // Count number of computers within Warrent Red span 3 mount left on warrenty
            printOutputPos(blue, DbQuerys.CountWarrentyBlue(0).ToString(), 96, 3); // Count number of phones without Warrent 
            printOutputPos(blue, DbQuerys.CountWarrentyBlue(1).ToString(), 96, 2); // Count number of computers without Warrent
            Console.ResetColor();

        }

        public void showMenu(int posX, int posY)
        {
            SetCursurPos(posX, posY);                    // Set Cursur to input line
//            Console.WriteLine();
            Console.WriteLine(">> [1] List all assets:");
            Console.WriteLine(">> [2] Add a new asset:");
            Console.WriteLine(">> [3] Test a car   :");
            Console.WriteLine(">> [4] Delete a car :");
            Console.WriteLine(">> [5] Save to Db   :");
            Console.WriteLine(">> [Q] Save and Quit:");
            ShowLine(green, ">> Make your choise:", posX, posY + 7);
//            SetCursurPos(posX + 21, posY + 13);                    // Set Cursur to input line

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
        public void printOutput(ConsoleColor menuColor, string str, int posX, int posY)
        {
            StoreOutputList.Add(new Display(menuColor, str, posX, posY));

            Console.ForegroundColor = menuColor;
            SetCursurPos(posX, posY);
            Console.Write(str);
        }
        public void printOutputPos(ConsoleColor menuColor, string str, int posX, int posY)
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

        // ShowAssets
        // Input List of assets
        // return row on last written line
        public int ShowAssets(List<Asset> assets)
        {
            int posX = 0;
            int posY = 6;
            Console.Clear();
            ShowHeader(0, 0);
            ConsoleColor WarrentyColor = yellow;
            ShowLine(blue, "Blue = Out of warrenty", posX, posY + 1);
            ShowLine(yellow, "Yellow = Warrenty between 6 Month and 3 Month left", posX, posY + 2);
            ShowLine(red, "Red = Warrenty 3 Month left", posX, posY + 3);
            ShowLine(green, "Green = In Warrenty", posX, posY + 4);
            int count = posY + 6;
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

                ShowLine(WarrentyColor, $"{asset.Id.ToString().PadRight(2)}{asset.ComputerPhone.PadRight(9)}{asset.Brand.PadRight(8)}{asset.Model.PadRight(18)}{asset.Type.PadRight(13)}{asset.Price.ToString().PadRight(6)}", posX, count);
                count++;
            }
            //            ShowLine(green, ">> Press 0 to show menu:", posX, count + 1); // Press 0 to show menu printout on screen
            return count;
        }

        // Metod to insert data to db
        public void showMenuIsertToDb(int posX, int posY)
        {
            ClearOutputScreenFromPosY(7, 28 - posY);
        }
    }
}
