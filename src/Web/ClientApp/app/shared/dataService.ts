import { Injectable } from "@angular/core";
import { HttpClient, HttpErrorResponse } from "@angular/common/http";
import { Observable, throwError } from "rxjs";
import { map } from "rxjs/operators";
import { ITerraristicWindow } from "../core/models/terraristicWindow.model";
import { catchError } from "rxjs/operators";

@Injectable({
    //Service injectable for all application
    providedIn: 'root',
})
export class DataService{
  private token: string = "";
  private tokenExpiration: Date;

    constructor(private http: HttpClient) {}

    getTerraristicWindows() : Observable<ITerraristicWindow[]> {
        return this.http.get("/api/products")
            .pipe(
                map((data: ITerraristicWindow[]) => {
                    return data;
            },
            catchError(this.handleError)));
    };

    public get loginRequired(): boolean{
      return this.token.length  == 0 || this.tokenExpiration > new Date();
    }

    private handleError(err: HttpErrorResponse) {
        // in a real world app, we may send the server to some remote logging infrastructure
        // instead of just logging it to the console
        let errorMessage = '';
        if (err.error instanceof ErrorEvent) {
          // A client-side or network error occurred. Handle it accordingly.
          errorMessage = `An error occurred: ${err.error.message}`;
        } else {
          // The backend returned an unsuccessful response code.
          // The response body may contain clues as to what went wrong,
          errorMessage = `Server returned code: ${err.status}, error message is: ${err.message}`;
        }
        console.error(errorMessage);
        return throwError(errorMessage);
      }
}