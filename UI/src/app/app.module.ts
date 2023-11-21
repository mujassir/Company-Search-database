import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule,ReactiveFormsModule } from '@angular/forms'; // Import ReactiveFormsModule

import { PanelModule } from 'primeng/panel';
import { ButtonModule } from 'primeng/button';
import { InputTextModule } from 'primeng/inputtext';
import { MenubarModule } from 'primeng/menubar';
import { TreeTableModule } from 'primeng/treetable';
import { TableModule } from 'primeng/table';
import { DropdownModule } from 'primeng/dropdown';
import { PasswordModule } from 'primeng/password';
import { ProgressSpinnerModule } from 'primeng/progressspinner';
import { DialogModule } from 'primeng/dialog';
import { CheckboxModule } from 'primeng/checkbox';
import { MultiSelectModule } from 'primeng/multiselect';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';
import { LoginComponent } from './login/login.component';
import { SharedHeaderComponent } from './components/shared/header/header.component';
import { SharedFooterComponent } from './components/shared/footer/footer.component';
import { CompanyDetailComponent } from './company/detail/detail.component';
import { AddToFavoriteComponent } from './components/company/add-to-favorite/add-to-favorite.component';
import { CompanyOlffiDetailComponent } from './company/olffi-detail/olffi-detail.component';
import { ReadmoreContentComponent } from './components/readmore-content/readmore-content.component';


@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    LoginComponent,
    SharedHeaderComponent,
    SharedFooterComponent,
    CompanyDetailComponent,
    AddToFavoriteComponent,
    CompanyOlffiDetailComponent,
    ReadmoreContentComponent,
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    AppRoutingModule,
    ReactiveFormsModule,
    HttpClientModule,
    FormsModule,
    CheckboxModule,
    DialogModule,
    PanelModule,
    InputTextModule,
    ButtonModule,
    MenubarModule,
    TreeTableModule,
    TableModule,
    DropdownModule,
    PasswordModule,
    ProgressSpinnerModule,
    MultiSelectModule,
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
