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
        //public void ShowCategory(int posX, int posY)
        //{
        //    Console.SetCursorPosition(posX, posY);
        //    Console.ForegroundColor = ConsoleColor.Yellow;
        //    Console.WriteLine(">> Welcome to Cars database");
        //    Console.ForegroundColor = ConsoleColor.Green;
        //    Console.WriteLine(">> You have [  ] Cars in database");
        //    Console.WriteLine(">> [1] List all cars:");
        //    Console.WriteLine(">> [2] Add a new car:");
        //    Console.WriteLine(">> [3] Test a car   :");
        //    Console.WriteLine(">> [4] Delete a car :");
        //    Console.WriteLine(">> [5] Save to Db   :");
        //    Console.WriteLine(">> [Q] Save and Quit:");
        //    ShowMenu(ConsoleColor.Green, ">> Make your choise:", 0, 8);
        //    Console.ResetColor();
        //}

        // Method to display category information
        public void ShowHeader(int posX, int posY)
        {
            Console.SetCursorPosition(posX, posY);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(">> Welcome to AssetTracking DB");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(">> You have HQs    [   ] and total of  [   ] offices in        [   ] Countrys");
            Console.WriteLine(">> There are total [   ] Computers and [   ] are Level Red and [   ] are level Yellow.");
            Console.WriteLine(">> There are total [   ] Phones and    [   ] are Level Red and [   ] are level Yellow.\n");
        }

        public void showMenu(int posX, int posY)
        {
            Console.WriteLine();
            Console.WriteLine(">> [1] List all assets:");
            Console.WriteLine(">> [2] Add a new car:");
            Console.WriteLine(">> [3] Test a car   :");
            Console.WriteLine(">> [4] Delete a car :");
            Console.WriteLine(">> [5] Save to Db   :");
            Console.WriteLine(">> [Q] Save and Quit:");
            ShowLine(ConsoleColor.Green, ">> Make your choise:", 0, 13);
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

    }
}
