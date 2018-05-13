using SwapiCL.Model;
using System;

namespace SwapiCL.Services
{
    public static class FilmsService
    {
        public static async System.Threading.Tasks.Task<RootObject<FilmsModel>> GetAsync()
        {
            try
            {
                // You can implement some specifics responsibilities here that's the reason why I injected a specific Object

                var root = await BaseService<FilmsModel>.GetAsync();
                return root;
            }
            catch (Exception)
            {
                throw new System.Net.Http.HttpRequestException();
            }       
        }
    }
}
