
// Output types of sensor
export const outputTypes = new class OutputTypes {
    readonly Digital: number = 1;
    readonly Analog: number = 2;

    get outputTypes(){
        return [this.Digital, this.Analog];
    }

    getOutputTypesWithName(){
        return [
            {id: this.Digital, name: 'Cyfrowe'},
            {id: this.Analog, name: 'Analogowe'}
        ]
    }
};

// Input types of sensor
export const Input = 1;
export const Output = 2;
export const sensorTypes = new class SensorTypes {
    readonly input: number = 1;
    readonly output: number = 2;

    getSensorTypes() {
        return [Input, Output];
    }

    getSensorTypesWithName() {
        return [
            {id: 1, name: "Wejście"},
            {id: 2, name: "Wyjście"}
        ]
    }
};