using Newtonsoft.Json;
using SwapiCL.Model;
using System;
using System.Net.Http;

namespace SwapiCL.Services
{
    public static class ShipsService
    {
        public static async System.Threading.Tasks.Task<RootObject> GetStarShipsAsync()
        {
            var _ships = new RootObject();

            try
            {
                using (var client = new HttpClient())
                {
                    var uri = SWApiResources.Starships1;

                    var response = await client.GetAsync(uri);

                    if (response.IsSuccessStatusCode)
                    {
                        var ships = await response.Content.ReadAsStringAsync();
                        _ships = JsonConvert.DeserializeObject<RootObject>(ships);

                        var next = _ships.next;

                        while (!string.IsNullOrEmpty(next))
                        {
                            // Check if there is more result page 
                            response = await client.GetAsync(next);

                            if (!response.IsSuccessStatusCode) continue;
                            ships = await response.Content.ReadAsStringAsync();
                            var rootPage = JsonConvert.DeserializeObject<RootObject>(ships);

                            _ships.results.AddRange(rootPage.results);

                            next = rootPage.next;
                        }

                        foreach (var item in _ships.results)
                        {
                            int.TryParse(item.MGLT, out var vMGLT);

                            var vAutonomy = Utils.GetAuthonomyByShip(item);

                            if (vAutonomy > 0 && vMGLT > 0)
                            {
                                item.autonomy = Convert.ToInt32(vMGLT * vAutonomy);
                            }
                            else
                            {
                                item.autonomy = null;
                            }
                        }
                    }
                    else
                        throw new Exception("Could not load StarShips, it looks like there is not an active internet connection.");
                }

                return _ships;
            }
            catch (Exception)
            {
                throw new System.Net.Http.HttpRequestException();
            }
            
        }
    }
}
