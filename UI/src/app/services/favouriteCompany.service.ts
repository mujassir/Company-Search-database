// favorite.service.ts
import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { HttpService } from './http.service';
import { BehaviorSubject, catchError, take } from 'rxjs';
import { AppConfig } from '../common/app-config';

@Injectable({
  providedIn: 'root',
})
export class FavoriteCompanyService {
  private _favorite$ = new BehaviorSubject<any>([]);
  private _companiesByFavoriteId$ = new BehaviorSubject<any>([]);
  private _companiesByFavoriteIdLoader$ = new BehaviorSubject<any>([]);
  private _favoriteLoader$ = new BehaviorSubject<boolean>(false);
  private _favoriteSaveLoader$ = new BehaviorSubject<boolean>(false);

  apiUrl = AppConfig.API_BASE_URL;
  constructor(private http: HttpService) { }

  favorites$ = this._favorite$.asObservable()
  companiesByFavoriteId$ = this._companiesByFavoriteId$.asObservable()
  favoriteLoader$ = this._favoriteLoader$.asObservable()
  companiesByFavoriteIdLoader$ = this._companiesByFavoriteIdLoader$.asObservable()
  favoriteSaveLoader$ = this._favoriteSaveLoader$.asObservable()

  GetFavorites(id: number, companyId: number) {
    this._favoriteLoader$.next(true)
    this.http.SendRequest("get", `${this.apiUrl}/FavoriteCompany?userId=${id}&companyId=${companyId}`)
      .pipe(
        catchError((error: HttpErrorResponse) => {
          this._favorite$.next([])
          this._favoriteLoader$.next(false);
          throw error;
        })
      )
      .subscribe(data => {
        this._favorite$.next(data)
        this._favoriteLoader$.next(false);
      })
  }
  GetCompaniesByFavId(favId: number) {
    this.http.SendRequest("get", `${this.apiUrl}/FavoriteCompany/CompanyByFavoriteId?favoriteId=${favId}`)
      .pipe(
        catchError((error: HttpErrorResponse) => {
          this._companiesByFavoriteId$.next([])
          this._companiesByFavoriteIdLoader$.next(false);
          throw error;
        })
      )
      .subscribe(data => {
        this._companiesByFavoriteId$.next(data)
        this._companiesByFavoriteIdLoader$.next(false);
      })
  }
  CreateFavorite(payload: any, userId: number, selectedFavId: number) {
    this._favoriteSaveLoader$.next(true)
    this.http.SendRequest("post", `${this.apiUrl}/FavoriteCompany`, payload)
      .pipe(
        catchError((error: HttpErrorResponse) => {
          this._favorite$.next([])
          this._favoriteSaveLoader$.next(false);
          throw error;
        })
      )
      .subscribe(data => {
        this.GetFavorites(userId, payload.companyId)
        this.GetCompaniesByFavId(selectedFavId)
        this._favoriteSaveLoader$.next(false);
      })
  }
  RemoveFavorite(payload: any, userId: number, selectedFavId: number) {
    this.http.SendRequest("delete", `${this.apiUrl}/FavoriteCompany?favoriteId=${payload.favoriteId}&companyId=${payload.companyId}`)
      .pipe(
        catchError((error: HttpErrorResponse) => {
          this._favorite$.next([])
          throw error;
        })
      )
      .subscribe(data => {
        this.GetFavorites(userId, payload.companyId)
        this.GetCompaniesByFavId(selectedFavId)
      })
  }
}
