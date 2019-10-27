const GetUserWindowData = function(){
    return {
        loading: Boolean(true),
        error: String(""),
    }
};

const GetWindowFormData = function(){
    return {
        name: String(),
        description: String(),
        inputSensors: Array(0),
        outputSensors: Array(0)
    }
};

export {
    GetUserWindowData,
    GetWindowFormData,
}
