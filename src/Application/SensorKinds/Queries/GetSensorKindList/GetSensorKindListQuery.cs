using System.Collections.Generic;
using Application.Common.Models;
using MediatR;

namespace Application.SensorKinds.Queries.GetSensorKindList
{
    public class GetSensorKindListQuery : IRequest<List<SensorKindAm>>
    {
    }
}