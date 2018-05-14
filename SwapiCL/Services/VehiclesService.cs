using Newtonsoft.Json;
using SwapiCL.Model;
using System;
using System.Net.Http;
using FilmsModel = SwapiCL.Model.FilmsModel;

namespace SwapiCL.Services
{
    public static class VehiclesService
    {
        public static async System.Threading.Tasks.Task<RootObject<VehiclesModel>> GetAsync()
        {
            try
            {
                // You can implement some specifics responsibilities here that's the reason why I injected a specific Object
                var root = await BaseService<VehiclesModel>.GetAsync(SwApiResources.Vehicles);
                return root;
            }
            catch (Exception)
            {
                throw new System.Net.Http.HttpRequestException();
            }       
        }
    }
}
