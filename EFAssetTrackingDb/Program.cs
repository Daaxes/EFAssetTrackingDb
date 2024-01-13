
using EFAssetTrackingDb;
using System.Globalization;
using System.Text;

MyDbContext Context = new MyDbContext();
DbQuerys querys = new DbQuerys();
Display display = new Display();

StringBuilder input = new StringBuilder();
const ConsoleColor darkYelloe = ConsoleColor.DarkYellow;
const ConsoleColor red = ConsoleColor.Red;
const ConsoleColor green = ConsoleColor.Green;
const ConsoleColor blue = ConsoleColor.Blue;
const ConsoleColor yellow = ConsoleColor.Yellow;
const int milliseconds = 2000;

display.ShowHeader(0, 0); // Shows header with info about headquaters, Offices, Computers and warrenty, phones and warrenty 
display.showMenu(0, 6);   // Shows menu
display.WriteBackground();


while (true)
{
    input.Clear();                      // Clear screen
    Console.ResetColor();               // Resets forground color
    display.SetCursurPos(21, 13);
    input.Append(Console.ReadLine());   // Read input to StringBuilder input


    switch (input.ToString())
    {
        case "0":
            Console.Clear();
            display.ShowHeader(0, 0);
            display.showMenu(0, 6);
            break;
        case "1":
            DbQuerys.CombinePhoneAndComputerToAsset();
 
            break;
        case "2":
            DbQuerys.insertdataindb();
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