const groupSensors = function (sensors) {
    let groups = Array(0);
    _.each(sensors, sensors => {
        if (groups.length === 0) {
            groups.push(
                {
                    id: sensors.id,
                    name: sensors.name,
                    count: 1
                });
        } else {
            let groupToUpdate = _.find(groups, {'id': sensors.id});
            if (groupToUpdate) {
                groupToUpdate.count++;
            } else {
                groups.push({
                    id: sensors.id,
                    name: sensors.name,
                    count: 1
                })
            }
        }
    });
    return groups;
};

export const windowModalHelper = {
    groupSensors
};
