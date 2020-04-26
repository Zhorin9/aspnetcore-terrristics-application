using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Enums;
using Domain.Exceptions;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories
{
    public class SensorBlockRepository : AppRepository<SensorBlock>, ISensorBlockRepository
    {
        private readonly IAppLogger<TerraristicWindowRepository> _logger;

        public SensorBlockRepository(AppDbContext context, IAppLogger<TerraristicWindowRepository> logger) :
            base(context)
        {
            _logger = logger;
        }

        public async Task<int> UpdateBaseParameters(SensorBlock sensorBlockToUpdate, string userId)
        {
            SensorBlock currentSensorBlock = await Context.SensorBlocks
                .FirstOrDefaultAsync(s => s.Id == sensorBlockToUpdate.Id && s.UserId == userId);

            if (currentSensorBlock == null)
            {
                throw new NotFoundException(nameof(sensorBlockToUpdate), sensorBlockToUpdate.Id);
            }

            currentSensorBlock.Name = sensorBlockToUpdate.Name;
            currentSensorBlock.Description = sensorBlockToUpdate.Description;

            int result = await Context.SaveChangesAsync();

            return result;
        }

        public async Task<int> CreateWithOutputData(SensorBlock sensorBlock)
        {
            await Context.SensorBlocks.AddAsync(sensorBlock);
            int result = await Context.SaveChangesAsync();

            return result;
        }

        public Task<List<SensorBlock>> GetAsync(int windowId, string userId)
        {
            return Context.SensorBlocks.AsNoTracking()
                .Include(sb => sb.SensorKind)
                .Where(sb => sb.ParentWindowId == windowId && sb.UserId == userId)
                .ToListAsync();
        }

        private static void UpdateChildEntitiesIfSensorKindChanged(SensorBlock currentSensorBlock, SensorKind sensorKindToUpdate)
        {
            if (currentSensorBlock.SensorKind.Type == sensorKindToUpdate.Type)
            {
                return;
            }

            if (currentSensorBlock.SensorKind.Type == SensorTypeEnum.Input)
            {
                ClearInputAndCreateOutputDataIfNull(currentSensorBlock);
            }
            else
            {
                ResetOutputDataIfNotNull(currentSensorBlock);
            }
        }

        private static void ClearInputAndCreateOutputDataIfNull(SensorBlock currentSensorBlock)
        {
            currentSensorBlock.Inputs.Clear();

            if (currentSensorBlock.OutputData == null)
            {
                currentSensorBlock.OutputData = new OutputSensorData
                {
                    Value = "",
                    State = false
                };
            }
        }

        private static void ResetOutputDataIfNotNull(SensorBlock currentSensorBlock)
        {
            if (currentSensorBlock.OutputData != null)
            {
                currentSensorBlock.OutputData = new OutputSensorData
                {
                    Value = "",
                    State = false
                };
            }
        }
    }
}