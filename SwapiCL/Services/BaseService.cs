using Newtonsoft.Json;
using SwapiCL.Model;
using System;
using System.Net.Http;

namespace SwapiCL.Services
{
    public static class BaseService<T>
    {
        // I am using generic methods to simplify the code implementation 
        public static async System.Threading.Tasks.Task<RootObject<T>> GetAsync()
        {
            try
            {
                RootObject<T> rootObject;

                using (var client = new HttpClient())
                {
                    var uri = SwApiResources.Starships;

                    var response = await client.GetAsync(uri);

                    if (response.IsSuccessStatusCode)
                    {
                        var returnObject = await response.Content.ReadAsStringAsync();
                        rootObject = JsonConvert.DeserializeObject<RootObject<T>>(returnObject);

                        var next = rootObject.next;

                        while (!string.IsNullOrEmpty(next))
                        {
                            // Check if there is more result page 
                            response = await client.GetAsync(next);

                            if (!response.IsSuccessStatusCode) continue;
                            returnObject = await response.Content.ReadAsStringAsync();
                            var rootPage = JsonConvert.DeserializeObject<RootObject<T>>(returnObject);

                            rootObject.results.AddRange(rootPage.results);

                            next = rootPage.next;
                        }
                    }
                    else
                        throw new Exception("Could not load data, it looks like there is not an active internet connection.");
                }

                return rootObject;
            }
            catch (Exception)
            {
                throw new System.Net.Http.HttpRequestException();
            }
        }
    }
}
