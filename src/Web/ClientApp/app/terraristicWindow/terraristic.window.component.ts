import { Component, OnInit } from "@angular/core";
import { DataService } from "../shared/dataService";
import { ITerraristicWindow } from "../core/models/terraristicWindow.model";

@Component({
    selector: "terraristic-window",
    templateUrl: "terraristic.window.component.html",
    styleUrls: ["terraristic.window.component.css"]
})
export class TerraristicWindowComponent implements OnInit{
    public terraristicWindows: ITerraristicWindow[];
    errorMessage: any;

    constructor(private data: DataService){}


    ngOnInit(): void {
        this.data.getTerraristicWindows().subscribe(
            windows => {
                this.terraristicWindows = windows;
            },
            error => this.errorMessage = <any>error
            

        );
    } 
}