interface SensorKindModel {
    SensorKindId: number;
    Name: string;
    ShortDescription: string;
    Description: string;
    Type: number;
}

interface SensorBlockModel {
    Id: number;
    Name: string;
    Description: string;
    PositionId: number;
    SensorKindApiModel: SensorKindModel
}

interface TerraristicsWindowModel {
    Id: number;
    Name: string;
    Description: string;
    CreationDate: Date;
    ApiKey: string;
}

//User
interface UserLoginModel {
    Email: string;
    Password: string;
}



interface TerraristicsWindowFormData {
    failedOnCreate: boolean;
    waitingForResponse: boolean;
    name: string;
    description: string;
}

interface SensorKindData {
    SensorKindId: number;
    Name: string;
    ShortDescription: string;
    Description: string;
    Type: number;
}