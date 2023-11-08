import { Injectable } from '@angular/core';
import { HttpService } from './http.service';
import { BehaviorSubject, Observable, catchError } from 'rxjs';
import { HttpErrorResponse } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class CountryService {
  private _countries$ = new BehaviorSubject<any>([]);
  private _countriesLoader$ = new BehaviorSubject<boolean>(false);

  apiUrl = "https://localhost:7047";
  constructor(private http: HttpService) { }

  countries$ = this._countries$.asObservable();
  countriesLoader$ = this._countriesLoader$.asObservable();

  getCountries(): Observable<any> {
    this._countriesLoader$.next(true);
    return this.http.SendRequest("get", `${this.apiUrl}/Country`).pipe(
      catchError((error: HttpErrorResponse) => {
        this._countries$.next([]);
        this._countriesLoader$.next(false);
        throw error;
      })
    );
  }
}