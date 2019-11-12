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


//Helpers
interface Header {
    readonly header: object;
    GetHeader() : object;
    GetHeaderWithJwtToken(): object;
}