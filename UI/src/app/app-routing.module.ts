import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { LoginComponent } from './login/login.component';
import { CompanyDetailComponent } from './company/detail/detail.component';
import { CompanyOlffiDetailComponent } from './company/olffi-detail/olffi-detail.component';
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
    path: 'company/olffi-detail/:id',
    component: CompanyOlffiDetailComponent,
  },
  {
    path: 'login',
    component: LoginComponent,
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
