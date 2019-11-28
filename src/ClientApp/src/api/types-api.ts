interface UserApi {
    login(email: string, password: string): Promise<any>;
}

interface DictionaryApi {
    getSensorKindsDict(): Promise<any>;
}

interface TerraristicsWindowApi {
    addNewWindow(name: string, description: string): Promise<number>;
}