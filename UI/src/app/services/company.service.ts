import { Injectable } from '@angular/core';
import { HttpService } from './http.service';
import { BehaviorSubject, Observable, catchError, lastValueFrom } from 'rxjs';
import { HttpErrorResponse } from '@angular/common/http';
import { AppConfig } from '../common/app-config';

@Injectable({
  providedIn: 'root'
})
export class CompanyService {
  private _companies$ = new BehaviorSubject<any>([]);
  private _companyLoader$ = new BehaviorSubject<boolean>(false);

  private _linkedByProjectCompanies$ = new BehaviorSubject<any>([]);
  private _linkedByProjectCompaniesLoader$ = new BehaviorSubject<boolean>(false);

  private _company$ = new BehaviorSubject<any>([]);

  apiUrl = AppConfig.API_BASE_URL;
  constructor(private http: HttpService) { }

  companies$ = this._companies$.asObservable()
  companyLoader$ = this._companyLoader$.asObservable()

  linkedByProjectCompanies$ = this._linkedByProjectCompanies$.asObservable()
  linkedByProjectCompaniesLoader$ = this._linkedByProjectCompaniesLoader$.asObservable()

  company$ = this._company$.asObservable()

  GetCompanies(payload: any) {
    this._companyLoader$.next(true)
    this.http.SendRequest("get", `${this.apiUrl}/Company/Search?country=${payload.Country || ''}&company=${payload.Company || ''}&website=${payload.Website || ''}&categoryId=${payload.CategoryId || ''}&region=${payload.Region || ''}`)
      .pipe(
        catchError((error: HttpErrorResponse) => {
          this._companies$.next([])
          this._companyLoader$.next(false);
          throw error;
        })
      )
      .subscribe(data => {
        this._companies$.next(data)
        this._companyLoader$.next(false);
      })
  }
  GetById(id: number) {
    this._companyLoader$.next(true)
    this.http.SendRequest("get", `${this.apiUrl}/Company/${id}`)
      .pipe(
        catchError((error: HttpErrorResponse) => {
          this._company$.next({})
          this._companyLoader$.next(false);
          throw error;
        })
      )
      .subscribe(data => {
        this._company$.next(data)
        this._companyLoader$.next(false);
      })
  }
  GetLinkedCompaniesBasedOnProject(id: number) {
    this._linkedByProjectCompaniesLoader$.next(true)
    this.http.SendRequest("get", `${this.apiUrl}/Company/LinkedCompaniesBasedOnProject/${id}`)
      .pipe(
        catchError((error: HttpErrorResponse) => {
          this._linkedByProjectCompanies$.next({})
          this._linkedByProjectCompaniesLoader$.next(false);
          throw error;
        })
      )
      .subscribe(data => {
        this._linkedByProjectCompanies$.next(data)
        this._linkedByProjectCompaniesLoader$.next(false);
      })
  }
  GetByIdWithProgram(id: number) {
    this._companyLoader$.next(true)
    this.http.SendRequest("get", `${this.apiUrl}/Company/WithPrograms/${id}`)
      .pipe(
        catchError((error: HttpErrorResponse) => {
          this._company$.next({})
          this._companyLoader$.next(false);
          throw error;
        })
      )
      .subscribe(data => {
        this._company$.next(data)
        this._companyLoader$.next(false);
      })
  }
}
