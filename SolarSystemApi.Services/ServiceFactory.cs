using System;
using System.Collections.Generic;
using LiteDB;
using SolarSystemApi.Services;

namespace SolarSystemApi.Services
{
    public interface IServiceFactory
    {
        ILiteDatabase CreateDB();
    }

    public class ServiceFactory : IServiceFactory
    {
        private static ILiteDatabase _db;
        public ILiteDatabase CreateDB() {
            return _db ?? (_db = new DBProxy(@"Filename=SolarSystem.db;Mode=Exclusive")); 
        }
    }
}
