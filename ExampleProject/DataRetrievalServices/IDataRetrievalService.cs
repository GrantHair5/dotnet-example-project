using System;
using System.Collections.Generic;
using ExampleProject.Domain;

namespace DataRetrievalServices
{
    public interface IDataRetrievalService
    {
        string GetString();

        Vehicle GetVehicle(Guid id);

        IEnumerable<Vehicle> GetVehicles();
    }
}