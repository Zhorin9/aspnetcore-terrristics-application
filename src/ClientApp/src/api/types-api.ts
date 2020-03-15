interface UserApi {
    login(email: string, password: string): Promise<any>;
}

interface DictionaryApi {
    getSensorKindsDict(): Promise<any>;
}

interface TerraristicsWindowApi {
    createNewTerraristicsWindow(request: any): Promise<any>;
    getTerraristicsWindows(id: string): Promise<any>;
}

interface SensorBlockApi {
    getSensorBlocks(windowId: string): Promise<any>;
}

interface SensorBlockDataApi {
    getData(sensorBlockId: number): Promise<any>;
}