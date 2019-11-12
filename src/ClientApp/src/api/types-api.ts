interface DictionaryApi {
    getSensorKindsDict() : Promise<SensorKind>    
}

interface SensorKind {
    SensorKindId: number;
    Name: string;
    ShortDescription: string;
    Description: string;
    Type: number;
}