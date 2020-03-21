interface SensorKindModel {
    SensorKindId: number;
    Name: string;
    ShortDescription: string;
    Description: string;
    Type: number;
    OutputType: number;
}

interface SensorBlockModel {
    Id: number;
    Name: string;
    Description: string;
    PositionId: number;
    SensorKind: SensorKindModel
}

interface TerraristicsWindowModel {
    Id: number;
    Name: string;
    Description: string;
    CreationDate: Date;
    ModificationDate: Date;
    ApiKey: string;
}

//User
interface UserLoginModel {
    Email: string;
    Password: string;
}

interface TerraristicsWindowFormData {
    id: number;
    name: string;
    description: string;
}

interface SensorKindData {
    SensorKindId: number;
    Name: string;
    ShortDescription: string;
    Description: string;
    Type: number;
    OutputType: number;
}