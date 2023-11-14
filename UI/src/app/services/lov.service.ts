import { Injectable } from '@angular/core';
import { HttpService } from './http.service';
import { BehaviorSubject, catchError } from 'rxjs';
import { HttpErrorResponse } from '@angular/common/http';
import { AppConfig } from '../common/app-config';

@Injectable({
  providedIn: 'root'
})
export class LovService {
  apiUrl = AppConfig.API_BASE_URL;

  private _categories$ = new BehaviorSubject<any>([]);
  private _categoryLoader$ = new BehaviorSubject<boolean>(false);

  private _countries$ = new BehaviorSubject<any>([]);
  private _countriesLoader$ = new BehaviorSubject<boolean>(false);

  private _regions$ = new BehaviorSubject<any>([]);
  private _regionsLoader$ = new BehaviorSubject<boolean>(false);

  constructor(private http: HttpService) { }

  categories$ = this._categories$.asObservable()
  categoryLoader$ = this._categoryLoader$.asObservable()

  countries$ = this._countries$.asObservable();
  countriesLoader$ = this._countriesLoader$.asObservable();

  regions$ = this._regions$.asObservable();
  regionsLoader$ = this._regionsLoader$.asObservable();

  GetCategories() {
    this._categoryLoader$.next(true)
    this.http.SendRequest("get", `${this.apiUrl}/Category`)
      .pipe(
        catchError((error: HttpErrorResponse) => {
          this._categories$.next([])
          this._categoryLoader$.next(false);
          throw error;
        })
      )
      .subscribe(data => {
        this._categories$.next(data)
        this._categoryLoader$.next(false);
      })
  }

  GetCountries() {
    this._countriesLoader$.next(true);
    return this.http.SendRequest("get", `${this.apiUrl}/Country`)
    .pipe(
      catchError((error: HttpErrorResponse) => {
        this._countries$.next([])
        this._countriesLoader$.next(false);
        throw error;
      })
    )
    .subscribe(data => {
      this._countries$.next(data)
      this._countriesLoader$.next(false);
    })
  }

  GetRegions() {
    this._regionsLoader$.next(true);
    return this.http.SendRequest("get", `${this.apiUrl}/Region`)
    .pipe(
      catchError((error: HttpErrorResponse) => {
        this._regions$.next([])
        this._regionsLoader$.next(false);
        throw error;
      })
    )
    .subscribe(data => {
      this._regions$.next(data)
      this._regionsLoader$.next(false);
    })
  }
}