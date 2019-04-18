import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import { HttpClientModule } from '@angular/common/http';
import { DataService } from './shared/dataService';
import { RouterModule } from '@angular/router';
import { TerraristicWindowComponent } from './terraristicWindow/terraristic.window.component';

let routes = [
  {path: "", component: WelcomeComponent},
  { path: "/windows", component: TerraristicWindowComponent}
]

@NgModule({
  declarations: [
    AppComponent,
    TerraristicWindowComponent
  ],
  imports: [
      BrowserModule,
      HttpClientModule,
      RouterModule.forRoot(routes, {
        useHash: true,
        enableTracing: false
      })
  ],
    providers: [
        DataService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
