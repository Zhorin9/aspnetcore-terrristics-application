const GetUserWindowData = function(){
    return {
        loading: Boolean(true),
        error: String(""),
    }
};

const GetTerraristicsWindowFormData = function(){
    return {
        failedOnCreate: Boolean(false),
        waitingForResponse: Boolean(false),
        name: String(),
        description: String()
    }
};

export {
    GetUserWindowData,
    GetTerraristicsWindowFormData,
}
