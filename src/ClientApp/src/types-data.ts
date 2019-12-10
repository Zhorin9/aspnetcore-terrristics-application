interface SensorKindModel {
    SensorKindId: number;
    Name: string;
    ShortDescription: string;
    Description: string;
    Type: number;
}

//User
interface UserLoginModel {
    Email: string;
    Password: string;
}

interface TerraristicsWindow {
    Id: number;
    Name: string;
    Description: string;
    CreationDate: Date;
    ApiKey: string;
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