using Newtonsoft.Json;
using SwapiCL.Model;
using System;
using System.Net.Http;

namespace SwapiCL.Services
{
    public static class ShipsService
    {
        public static RootObject<StarShip> Get()
        {
            using (var ships = BaseService<StarShip>.GetAsync())
            {
                try
                {
                    foreach (var item in ships.Result.results)
                    {
                        int.TryParse(item.MGLT, out var vMglt);

                        var vAutonomy = Utils.GetAuthonomyByShip(item);

                        if (vAutonomy > 0 && vMglt > 0)
                        {
                            item.autonomy = Convert.ToInt32(vMglt * vAutonomy);
                        }
                        else
                        {
                            item.autonomy = null;
                        }
                    }

                    return ships.Result;
                }
                catch (Exception)
                {
                    throw new System.Net.Http.HttpRequestException();
                }
            }
        }
    }
}
