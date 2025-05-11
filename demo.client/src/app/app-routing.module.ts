import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { SqltotabledataComponent } from './sqltotabledata/sqltotabledata.component';
import { SqltotabledatawithparamsComponent } from './sqltotabledatawithparams/sqltotabledatawithparams.component';
import { ClassicComponent } from './classic/classic.component';

const routes: Routes = [
  { path: 'classic', component: ClassicComponent },
  { path: 'sqltotabledata', component: SqltotabledataComponent },
  { path: 'sqltotabledatawithparams', component: SqltotabledatawithparamsComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
