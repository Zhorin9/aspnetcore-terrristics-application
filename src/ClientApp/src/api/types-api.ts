interface UserApi {
    login(email: string, password: string): Promise<any>;
}

interface DictionaryApi {
    getSensorKindsDict(): Promise<any>;
}

interface TerrariumApi {
    get(id: number): Promise<any>;
    getList(): Promise<any>;
    create(request: any): Promise<any>;
    update(request: TerrariumFormDialogModel): Promise<any>;
    delete(windowId: number): Promise<any>;
}

interface SensorApi {
    getSensor(id: number): Promise<any>;
    getSensors(windowId: number): Promise<any>;
    removeAllInputData(sensorBlockId: number): Promise<any>;
}

interface SensorBlockDataApi {
    getList(sensorBlockId: number): Promise<any>;
    getOutputState(sensorBlockId: number): Promise<any>;
    updateOutputData(request: any): Promise<any>;
}
