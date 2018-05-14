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
                var root = await BaseService<SpeciesModel>.GetAsync(SwApiResources.Species);
                return root;
            }
            catch (Exception)
            {
                throw new System.Net.Http.HttpRequestException();
            }       
        }
    }
}
