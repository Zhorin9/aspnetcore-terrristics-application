using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Exceptions;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories
{
    public class OutputBlockDataRepository : AppRepository<OutputSensorData>, IOutputBlockDataRepository
    {
        public OutputBlockDataRepository(AppDbContext context) : base(context)
        {
        }

        public Task<OutputSensorData> Get(int sensorBlockId)
        {
            return Context.OutputSensorData.Where(d => d.SensorBlockId == sensorBlockId)
                .AsNoTracking()
                .FirstOrDefaultAsync();
        }

        public async Task<int> Update(OutputSensorData outputSensorData)
        {
            SensorBlock outputSensor = await Context.SensorBlocks
                .Include(i => i.OutputData)
                .FirstOrDefaultAsync(sb => sb.Id == outputSensorData.SensorBlockId);

            if (outputSensor == null)
            {
                throw new NotFoundException(nameof(outputSensorData), outputSensorData.SensorBlockId);
            }

            if (outputSensor.OutputData == null)
            {
                throw new NotFoundException(nameof(outputSensor.OutputData), outputSensorData.SensorBlockId);
            }

            outputSensor.OutputData.State = outputSensorData.State;
            outputSensor.OutputData.Value = outputSensorData.Value;
            
            int result = await Context.SaveChangesAsync();
            return result;
        }
    }
}