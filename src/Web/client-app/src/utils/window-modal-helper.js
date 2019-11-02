const updateSensorsList = function(sensors, value){
    let sensorsTemp = [];
    _.each(value, sensor => {
        let matchedSensor = _.find(sensors, {'id': sensor.id});
        if (!_.isNil(matchedSensor)) {
            sensorsTemp.push({
                id: matchedSensor.id,
                name: matchedSensor.name,
                type: matchedSensor.type,
                count: matchedSensor.count
            })
        }
        else{
            sensorsTemp.push({
                id: sensor.id,
                name: sensor.name,
                type: sensor.type,
                count: 1
            })
        }
    });

    return sensorsTemp;
};

export const windowModalHelper = {
    updateSensorsList
};
