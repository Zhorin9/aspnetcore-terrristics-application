export const Input = 1;
export const Output = 2;

class SensorTypes {
    readonly Input: number = 1;
    readonly Output: number = 2;
    
    getSensorTypes(){
        return [Input, Output];
    }
}

export const sensorTypes = new SensorTypes();