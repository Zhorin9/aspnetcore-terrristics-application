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