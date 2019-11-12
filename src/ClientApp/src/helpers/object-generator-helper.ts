
export class TerraristicsWindowDataImpl implements TerraristicsWindowData {
    loading: boolean = false;
    error: string = "";
}  

export class TerraristicsWindowFormDataImpl implements TerraristicsWindowFormData {
    description: string = "";
    failedOnCreate: boolean = false;
    name: string = "";
    waitingForResponse: boolean = false;
    
}