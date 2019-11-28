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

interface TerraristicsWindowData {
    loading: boolean;
    error: string;
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