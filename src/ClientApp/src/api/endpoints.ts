export const endpoints = {
    getJwtToken: "/account/createToken",

    getSensorKinds: "/api/dictionary/getSensorKinds",

    getSensorBlockData: "/api/sensorBlockData/getList",
    getSensorBlockDataOutputState: "/api/sensorBlockData/getOutputState",
    createOrUpdateSensorBlockData: "/api/sensorBlockData/createOrUpdate",
    
    getSensorBlocks: "/api/sensorBlock/getList",
    createNewSensorBlock: "/api/sensorBlock/create",
    
    getTerraristicsWindows: "api/terraristicsWindow/getList",
    createNewTerraristicsWindow: "api/terraristicsWindow/create",
    updateTerraristicsWindow: "api/terraristicsWindow/update",
    deleteTerraristicsWindow: "api/terraristicsWindow/delete",
};