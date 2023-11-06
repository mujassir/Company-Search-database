import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { LoginComponent } from './login/login.component';
import { CompanyDetailComponent } from './company/detail/detail.component';
import {TestTableComponent} from './test-table/test-table.component'
const routes: Routes = [
  {
    path: '',
    component: HomeComponent,
  },
  {
    path: 'company/detail/:id',
    component: CompanyDetailComponent,
  },
  {
    path: 'login',
    component: LoginComponent,
  },
  {
    path: 'testingTable',
    component:TestTableComponent 

  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
