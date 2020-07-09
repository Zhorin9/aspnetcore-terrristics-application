using System.Collections.Generic;
using Application.InputSensorDatas.Queries.GetInputSensorDataList;

namespace Application.InputSensors.Queries.GetInputSensorDataList
{
    public class InputSensorDataListAm
    {
        public IList<InputSensorDataListDetailAm> SensorBlockData { get; set; }
    }
}