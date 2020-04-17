using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IInputBlockDataRepository
    {
        Task<int> Add(Guid windowApiKey, int sensorBlockId, InputSensorData inputSensorData);
        Task<List<InputSensorData>> GetData(int sensorBlockId);
    }
}