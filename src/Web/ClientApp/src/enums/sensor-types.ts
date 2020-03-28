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

// export const sensorTypes = new SensorTypes();