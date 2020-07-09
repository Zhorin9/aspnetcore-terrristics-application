using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.InputSensorDatas.Commands.CreateInputData
{
    public class CreateInputDataCommand : IRequest
    {
        public decimal Value { get; set; }
        public DateTime CreationDate { get; set; }
        public int SensorBlockId { get; set; }
        public string WindowApiKey { get; set; }
        
        public class CreateInputDataCommandHandler : IRequestHandler<CreateInputDataCommand>
        {
            private readonly IAppDbContext _context;

            public CreateInputDataCommandHandler(IAppDbContext context)
            {
                _context = context;
            }
            
            public async Task<Unit> Handle(CreateInputDataCommand request, CancellationToken cancellationToken)
            {
                TerraristicWindow terraristicWindow = await _context.TerraristicWindows
                    .Include(i => i.SensorBlocks)
                    .FirstOrDefaultAsync(t => t.ApiKey.ToString() == request.WindowApiKey, cancellationToken: cancellationToken);
                SensorBlock sensorBlock = terraristicWindow?.SensorBlocks.FirstOrDefault(s => s.Id == request.SensorBlockId);

                if (sensorBlock == null)
                {
                    throw new NotFoundException(nameof(sensorBlock), request.SensorBlockId);
                }
                
                var inputSensorData = new InputSensorData
                {
                    CreationDate = request.CreationDate == DateTime.MinValue ? DateTime.Now : request.CreationDate,
                    SensorBlockId = request.SensorBlockId,
                    Value = request.Value
                };

                await _context.InputSensorData.AddAsync(inputSensorData, cancellationToken);
                await _context.SaveChangesAsync(cancellationToken);
                
                return Unit.Value;
            }
        }
    }
}