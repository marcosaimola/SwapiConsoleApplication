using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace SwapiCL
{
    internal enum EConsumablePeriod
    {
        hour = 1,
        day = 24,
        week = 168,
        month = 720,
        year = 8760
    }

    public static class SWApiResources
    {
        public static readonly string Films = "https://swapi.co/api/films/";
        public static readonly string People = "https://swapi.co/api/people/";
        public static readonly string Planets = "https://swapi.co/api/planets/";
        public static readonly string Species = "https://swapi.co/api/species/";
        public static readonly string Starships1 = "https://swapi.co/api/starships/?page=1";
        public static readonly string Starships2 = "https://swapi.co/api/starships/?page=2";
        public static readonly string Vehicles = "https://swapi.co/api/vehicles/";

    }
}
