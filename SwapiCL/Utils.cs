using SwapiCL.Model;
using System;

namespace SwapiCL
{
    public static class Utils
    {
        /// <summary>
        /// Use this method to get the Ship's autonomy
        /// </summary>
        /// <param name="ss">StarShip: With consumables attributes populated</param>
        /// <returns>Int: Return the amount of hours according of consumables period</returns>
        public static int GetAuthonomyByShip(StarShip ss)
        {
            int ret = 0, valueInput = 0;

            if (ss.consumables == "unknown") return ret * valueInput;

            var splitInput = ss.consumables.Split(' ');

            valueInput = Convert.ToInt32(splitInput[0]);

            var periodicy = splitInput[1].Replace("s", "").ToLowerInvariant();

            ret = (int)Enum.Parse(typeof(EConsumablePeriod), periodicy, true);

            return ret * valueInput;
        }

        /// <summary>
        /// Use this method to get the amount of stops required according parameters.
        /// </summary>
        /// <param name="mglt">String: Distance in mega lights (MGLT)</param>
        /// <param name="ship">StarShip: With autonomy attribute</param>
        /// <returns>Int: Amount stops required</returns>
        public static int CalculateShipStop(string mglt, StarShip ship)
        {
            int.TryParse(ship.autonomy.ToString(), out var autonomy);

            if (autonomy == 0)
                throw new DivideByZeroException();

            var megaLights = Convert.ToInt32(mglt);
            return megaLights / autonomy; 
        }

        /// <summary>
        /// Use this method to validate the MDLT param provided 
        /// </summary>
        /// <param name="input">String: Amount of Mega Lights</param>
        /// <returns>Boolean: False indicates an invalid number entered</returns>
        public static bool InputValidDade(string input)
        {
            long.TryParse(input, out var ret);
            return (ret > 0);
        }

    }
}
