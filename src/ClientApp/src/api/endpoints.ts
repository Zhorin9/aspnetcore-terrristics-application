export const endpoints = {
    getJwtToken: "/account/createToken",

    getSensorKinds: "/api/dictionary/getSensorKinds",

    getSensorBlockData: "/api/sensorBlockData/getList",
    getSensorBlockDataOutputState: "/api/sensorBlockData/getOutputState",
    createOrUpdateSensorBlockData: "/api/sensorBlockData/createOrUpdate",
    removeSensorBlockAllInputData: "/api/sensorBlockData/removeAllInputData",

    getSensorBlocks: "/api/sensorBlock/getList",
    createNewSensorBlock: "/api/sensorBlock/create",
    updateSensorBlock: "/api/sensorBlock/update",

    getTerraristicsWindows: "api/terraristicsWindow/getList",
    createNewTerraristicsWindow: "api/terraristicsWindow/create",
    updateTerraristicsWindow: "api/terraristicsWindow/update",
    deleteTerraristicsWindow: "api/terraristicsWindow/delete",
};