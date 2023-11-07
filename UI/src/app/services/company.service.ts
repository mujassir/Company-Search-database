import { Injectable } from '@angular/core';
import { HttpService } from './http.service';
import { BehaviorSubject, Observable, catchError, lastValueFrom } from 'rxjs';
import { HttpErrorResponse } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class CompanyService {
  private _companies$ = new BehaviorSubject<any>([]);
  private _companyLoader$ = new BehaviorSubject<boolean>(false);
  
  private _company$ = new BehaviorSubject<any>([]);

  apiUrl = "https://localhost:7047";
  constructor(private http: HttpService) { }

  companies$ = this._companies$.asObservable()
  companyLoader$ = this._companyLoader$.asObservable()
  
  company$ = this._company$.asObservable()

  GetCompanies(payload: any) {
    this._companyLoader$.next(true)
    this.http.SendRequest("get", `${this.apiUrl}/Company/Search?country=${payload.Country}&company=${payload.Company}&website=${payload.Website}&categoryId=${payload.CategoryId}`)
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
}
