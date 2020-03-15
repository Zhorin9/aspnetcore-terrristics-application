using System.Collections.Generic;
using System.Threading.Tasks;
using AppCore.Entities;

namespace AppCore.Interfaces
{
    public interface IInputBlockDataRepository
    {
        Task<List<InputSensorData>> GetData(int sensorBlockId);
    }
}