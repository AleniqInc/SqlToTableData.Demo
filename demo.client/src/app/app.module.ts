import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { SqltotabledataComponent } from './sqltotabledata/sqltotabledata.component';
import { SqltotabledatawithparamsComponent } from './sqltotabledatawithparams/sqltotabledatawithparams.component';
import { ClassicComponent } from './classic/classic.component';

@NgModule({
  declarations: [
    AppComponent,
    SqltotabledataComponent,
    SqltotabledatawithparamsComponent,
    ClassicComponent
  ],
  imports: [
    BrowserModule, HttpClientModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
