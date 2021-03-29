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
    createdDate: Date;
    name: string;
    description: string;
    positionId: number;
    sensorKind: SensorKindModel
}

interface TerrariumModel {
    id: number;
    name: string;
    description: string;
    createdDate: Date;
    modifiedDate: Date;
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

interface SensorFormDialogModel {
    id: number;
    name: string;
    description: string;
    windowId: number;
    type: number,
    sensorKindId: number | null;
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
