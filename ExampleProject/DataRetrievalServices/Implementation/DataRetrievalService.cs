using System;
using System.Collections.Generic;
using System.Linq;
using ExampleProject.Database;
using ExampleProject.Domain;

namespace DataRetrievalServices.Implementation
{
    public class DataRetrievalService : IDataRetrievalService
    {
        private readonly ExampleProjectDbContext _dbContext;

        public DataRetrievalService(ExampleProjectDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public string GetString()
        {
            return "Hello, World";
        }

        public Vehicle GetVehicle(Guid id)
        {
            var vehicleThatICareAbout = _dbContext.Vehicles.SingleOrDefault(v => v.Id == id);

            if (vehicleThatICareAbout != null)
            {
                var vehicleToReturn = new Vehicle
                {
                    Color = vehicleThatICareAbout.Color,
                    Model = vehicleThatICareAbout.Model,
                    EngineSize = vehicleThatICareAbout.EngineSize,
                    Registration = vehicleThatICareAbout.Registration,
                    EngineIsBig = vehicleThatICareAbout.EngineSize > 1500,
                    Make = vehicleThatICareAbout.Make
                };

                return vehicleToReturn;
            }

            return null;
        }

        public IEnumerable<Vehicle> GetVehicles()
        {
            var vehiclesFromDatabase = _dbContext.Vehicles.ToList();

            var vehiclesFromDomain = new List<Vehicle>();

            foreach (var vehicleFromDb in vehiclesFromDatabase)
            {
                vehiclesFromDomain.Add(new Vehicle
                {
                    Color = vehicleFromDb.Color,
                    EngineIsBig = vehicleFromDb.EngineSize > 1500,
                    EngineSize = vehicleFromDb.EngineSize,
                    Model = vehicleFromDb.Model,
                    Make = vehicleFromDb.Make,
                    Registration = vehicleFromDb.Registration
                });
            }

            return vehiclesFromDomain;
        }
    }
}