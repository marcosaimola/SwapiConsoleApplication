using SwapiCL;
using SwapiCL.Model;
using SwapiCL.Services;
using System;
using System.Threading.Tasks;

namespace SwapiConsole
{
    class Program
    {
        static async Task GetShips()
        {
            RootObject root = await ShipsService.GetStarShipsAsync();

            #region StarWarsLogo
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine(@".      .     T h i s   i s   t h e   g a l a x y   o f   . . .             .    ");
            Console.WriteLine(@"                     .              .       .                    .      .       ");
            Console.WriteLine(@".        .               .       .     .            .                           ");
            Console.WriteLine(@"   .           .        .                     .        .            .           ");
            Console.WriteLine(@"             .               .    .          .              .   .         .     ");
            Console.WriteLine(@"               _________________      ____         __________                   ");
            Console.WriteLine(@" .       .    /                 |    /    \    .  |          \                  ");
            Console.WriteLine(@"     .       /    ______   _____| . /      \      |    ___    |     .     .     ");
            Console.WriteLine(@"             \    \    |   |       /   /\   \     |   |___)   |                 ");
            Console.WriteLine(@"           .  \    \   |   |      /   /__\   \  . |         _/               .  ");
            Console.WriteLine(@" .     ________>    |  |   | .   /            \   |   |\    \_______    .       ");
            Console.WriteLine(@"      |            /   |   |    /    ______    \  |   | \           |           ");
            Console.WriteLine(@"      |___________/    |___|   /____/      \____\ |___|  \__________|    .      ");
            Console.WriteLine(@"  .     ____    __  . _____   ____      .  __________   .  _________            ");
            Console.WriteLine(@"       \    \  /  \  /    /  /    \       |          \    /         |      .    ");
            Console.WriteLine(@"        \    \/    \/    /  /      \      |    ___    |  /    ______|  .        ");
            Console.WriteLine(@"         \              /  /   /\   \ .   |   |___)   |  \    \                 ");
            Console.WriteLine(@"   .      \            /  /   /__\   \    |         _/.   \    \            +   ");
            Console.WriteLine(@"           \    /\    /  /            \   |   |\    \______)    |   .           ");
            Console.WriteLine(@"            \  /  \  /  /    ______    \  |   | \              /          .     ");
            Console.WriteLine(@" .       .   \/    \/  /____/      \____\ |___|  \____________/  LS             ");
            Console.WriteLine(@"                               .                                        .       ");
            Console.WriteLine(@"     .                           .         .               .                 .  ");
            Console.WriteLine(@"                .                                   .            .              ");
            Console.WriteLine("*********************************************************************************");
            Console.ResetColor();

            Console.WriteLine();

            #endregion

            Console.Write("Please enter a distance in mega lights (MGLT): ");
            string input = "";

            while (Utils.InputValidDade(input = Console.ReadLine()))
            {
                foreach (var StarShip in root.results)
                {
                    Console.Write(StarShip.name);

                    if (StarShip.autonomy == null)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(" - unknown");
                        Console.ResetColor();
                    }
                    else
                    {
                        int autonomy = Utils.CalculateShipStop(input, StarShip);
                        if (autonomy == 0)
                            Console.ForegroundColor = ConsoleColor.Green;
                        else
                            Console.ForegroundColor = ConsoleColor.Yellow;
                        
                        Console.Write(" - " + autonomy.ToString());
                        Console.ResetColor();
                    }

                    Console.WriteLine();
                }

                Console.WriteLine("");
                Console.WriteLine("*************************************************************");
                Console.WriteLine("");
                Console.Write("Please enter a distance in mega lights (MGLT): ");

            }
            
            Console.Read();
        }

        static void Main()
        {
            try
            {
                GetShips().GetAwaiter().GetResult();
            }
            catch (Exception ex)
            {
;               Console.WriteLine(ex.Message);
                Console.ReadKey();
            }
        }
    }
}
