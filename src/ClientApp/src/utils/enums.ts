
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
export const Read = 1;
export const Control = 2;
export const sensorTypes = new class SensorTypes {
    readonly read: number = 1;
    readonly control: number = 2;

    getSensorTypes() {
        return [Read, Control];
    }

    getSensorTypesWithName() {
        return [
            {id: 1, name: "Read"},
            {id: 2, name: "Control"}
        ]
    }
};
