export const endpoints = {
    getJwtToken: "/api/Account/createToken",

    getSensorKinds: "/api/dictionary/getSensorKinds",

    getSensorBlockData: "/api/sensorBlockData/getList",
    getSensorBlockDataOutputState: "/api/sensorBlockData/getOutputState",
    createOrUpdateSensorBlockData: "/api/sensorBlockData/createOrUpdate",
    removeSensorBlockAllInputData: "/api/sensorBlockData/removeAllInputData",

    getSensor: "/api/sensor",
    getSensors: "/api/sensor/getList",
    createNewSensor: "/api/sensor",
    updateSensor: "/api/sensor/update",

    getTerrarium: "api/terrarium/get",
    getTerrariumList: "api/terrarium/getList",
    createNewTerrarium: "api/terrarium/create",
    updateTerrarium: "api/terrarium/update",
    deleteTerrarium: "api/terrarium/delete",
};
