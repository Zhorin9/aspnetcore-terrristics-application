interface UserApi {
    login(email: string, password: string): Promise<any>;
}

interface DictionaryApi {
    getSensorKindsDict(): Promise<any>;
}

interface TerraristicsWindowApi {
    create(request: any): Promise<any>;
    getList(id: string): Promise<any>;
    update(request: TerraristicsWindowFormData): Promise<any>;
    delete(windowId: number): Promise<any>;
}

interface SensorBlockApi {
    getSensorBlock(sensorBlockId: number): Promise<any>;
    getSensorBlocks(windowId: string): Promise<any>;
}

interface SensorBlockDataApi {
    getList(sensorBlockId: number): Promise<any>;
    getOutputState(sensorBlockId: number): Promise<any>;
}