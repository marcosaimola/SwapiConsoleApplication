using SwapiCL.Model;
using System;

namespace SwapiCL.Services
{
    public static class PeopleService
    {
        public static async System.Threading.Tasks.Task<RootObject<PeopleModel>> GetAsync()
        {
            try
            {
                // You can implement some specifics responsibilities here that's the reason why I injected a specific Object

                var root = await BaseService<PeopleModel>.GetAsync(SwApiResources.People);
                return root;
            }
            catch (Exception)
            {
                throw new System.Net.Http.HttpRequestException();
            }       
        }
    }
}
