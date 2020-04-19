
// Output types of sensor
export const outputTypes = new class OutputTypes {
    readonly Digital: number = 1;
    readonly Analog: number = 2;

    get outputTypes(){
        return [this.Digital, this.Analog];
    }

    getOutputTypesWithName(){
        return [
            {Id: this.Digital, Name: 'Cyfrowe'},
            {Id: this.Analog, Name: 'Analogowe'}
        ]
    }
};

// Input types of sensor
export const Input = 1;
export const Output = 2;
export const sensorTypes = new class SensorTypes {
    readonly Input: number = 1;
    readonly Output: number = 2;

    getSensorTypes() {
        return [Input, Output];
    }

    getSensorTypesWithName() {
        return [
            {Id: 1, Name: "Wejście"},
            {Id: 2, Name: "Wyjście"}
        ]
    }
};