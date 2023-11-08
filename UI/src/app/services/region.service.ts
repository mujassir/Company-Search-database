import { Injectable } from '@angular/core';
import { HttpService } from './http.service';
import { BehaviorSubject,Observable, catchError } from 'rxjs';
import { HttpErrorResponse } from '@angular/common/http';

@Injectable({
    providedIn: 'root'
})
export class RegionService {
  
    private _regions$ = new BehaviorSubject<any>([]);
  private _regionsLoader$ = new BehaviorSubject<boolean>(false);

  apiUrl = "https://localhost:7047";
  constructor(private http: HttpService) { }

  regions$ = this._regions$.asObservable();
  regionsLoader$ = this._regionsLoader$.asObservable();

  GetRegions(): Observable<any> {
    this._regionsLoader$.next(true);
    return this.http.SendRequest("get", `${this.apiUrl}/Region`).pipe(
      catchError((error: HttpErrorResponse) => {
        this._regions$.next([]);
        this._regionsLoader$.next(false);
        throw error;
      })
    );
  }
}
