using System;
using System.Collections.Generic;
using LiteDB;
using SolarSystemApi.Models;

namespace SolarSystemApi.Services
{
    public interface IServiceFactory
    {
        ILiteDatabase CreateDB();
    }

    public class ServiceFactory : IServiceFactory
    {
        public ILiteDatabase CreateDB() {
            return new DBProxy(@"Filename=SolarSystem.db;Mode=Exclusive");
        }
    }


}
