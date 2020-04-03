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