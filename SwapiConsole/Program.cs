using SwapiCL;
using SwapiCL.Services;
using System;

namespace SwapiConsole
{
    internal class Program
    {
        private static void GetShips()
        {
            var root = ShipsService.Get();

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
            var input = "";

            while (Utils.InputValidDade(input = Console.ReadLine()))
            {
                foreach (var starShip in root.results)
                {
                    Console.Write(starShip.name);
                    
                    if (starShip.autonomy == null)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(" - unknown");
                        Console.ResetColor();
                    }
                    else
                    {
                        var autonomy = Utils.CalculateShipStop(input, starShip);
                        Console.ForegroundColor = autonomy == 0 ? ConsoleColor.Green : ConsoleColor.Yellow;

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

        private static void Main()
        {
            try
            {
                GetShips();
            }
            catch (Exception ex)
            {
;               Console.WriteLine(ex.Message);
                Console.ReadKey();
            }
        }
    }
}
