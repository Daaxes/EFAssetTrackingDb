
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

while (true)
{
    input.Clear();
    display.ShowHeader(0, 0);                     // Write out ToDo List graphics
                                                  //   display.ShowString(blue, Car.getNumberOfCarsInDb().ToString(), 14, 1);
    display.showMenu(10, 0);
    display.printOutputPos(blue, DbQuerys.getNumberOfHQsInDb().ToString(), 22, 1); // Desplays out haw many HQs there are
    display.printOutputPos(blue, DbQuerys.getNumberOfOfficesInDb().ToString(), 42, 1);
    display.printOutputPos(blue, DbQuerys.getnumberofUniqCountryIndb().ToString(), 66, 1);
    display.printOutputPos(blue, DbQuerys.getnumberofComputersIndb().ToString(), 22, 2);
    display.printOutputPos(blue, DbQuerys.getnumberofPhonesIndb().ToString(), 22, 3);

    display.SetCursurPos(21, 13);                    // Set Cursur to input line
     DbQuerys.chkWarrenty();
   Console.ResetColor();                           // Resets forground color
    input.Append(Console.ReadLine());               // Read input to StringBuilder input


    //switch (input.ToString())
    //{
    //    case "1":
    //        listCarFromDb();    // Write out Cars from Db
    //        break;
    //    case "2":
    //        newCar();      // Write newCar
    //        break;
    //    case "3":
    //        test();               // Edit Project list if task is done
    //        break;
    //    //    case "4":
    //    //        project.SaveToFile(projectList);        // Save projectlist to file in Current working directory
    //    //        break;
    //    case "5":
    //        Car.updateDb(cars);
    //        break;
    //    default:
    //        break;
    //}
}


//    Bus MyBus = Context.Busses.Include(x => x.PassengersList).FirstOrDefault(x => x.Id == 2);

//foreach (var item in MyBus.PassengersList)
//{
//    Console.WriteLine(item.Name);
//} 