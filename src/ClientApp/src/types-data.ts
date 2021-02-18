interface SensorKindModel {
    sensorKindId: number;
    name: string;
    shortDescription: string;
    description: string;
    type: number;
    outputType: number;
}

interface SensorModel {
    id: number;
    name: string;
    description: string;
    positionId: number;
    sensorKind: SensorKindModel
}

interface TerrariumModel {
    id: number;
    name: string;
    description: string;
    creationDate: Date;
    modificationDate: Date;
    apiKey: string;
    isPublic: boolean;
}

//User
interface UserLoginModel {
    email: string;
    password: string;
}

interface TerrariumFormDialogModel {
    id: number;
    name: string;
    description: string;
    isPublic: boolean;
}

interface SensorKindData {
    sensorKindId: number;
    name: string;
    shortDescription: string;
    description: string;
    type: number;
    outputType: number;
}

interface InputSensorData {
    value: number;
    creationDate: Date;
}
