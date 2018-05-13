using Newtonsoft.Json;
using SwapiCL.Model;
using System;
using System.Net.Http;
using FilmsModel = SwapiCL.Model.FilmsModel;

namespace SwapiCL.Services
{
    public static class SpeciesService
    {
        public static async System.Threading.Tasks.Task<RootObject<SpeciesModel>> GetAsync()
        {
            try
            {
                // You can implement some specifics responsibilities here

                var root = await BaseService<SpeciesModel>.GetAsync();
                return root;
            }
            catch (Exception)
            {
                throw new System.Net.Http.HttpRequestException();
            }       
        }
    }
}
