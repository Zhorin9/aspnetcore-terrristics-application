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
        sensors: Array(0)
    }
};

export {
    GetUserWindowData,
    GetWindowFormData,
}
