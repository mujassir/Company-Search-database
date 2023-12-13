import { Injectable } from '@angular/core';
import { HttpService } from './http.service';
import { BehaviorSubject, catchError, take } from 'rxjs';
import { HttpErrorResponse } from '@angular/common/http';
import { AppConfig } from '../common/app-config';

@Injectable({
    providedIn: 'root'
})
export class FavoriteService {
    private _favorite$ = new BehaviorSubject<any>([]);
    private _favoriteLoader$ = new BehaviorSubject<boolean>(false);
    private _favoriteSaveLoader$ = new BehaviorSubject<boolean>(false);

    apiUrl = AppConfig.API_BASE_URL;
    constructor(private http: HttpService) { }

    favorites$ = this._favorite$.asObservable()
    favoriteLoader$ = this._favoriteLoader$.asObservable()
    favoriteSaveLoader$ = this._favoriteSaveLoader$.asObservable()

    GetFavorites(id: number) {
        this._favoriteLoader$.next(true)
        this.http.SendRequest("get", `${this.apiUrl}/Favorite?userId=${id}`)
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

    CreateFavorite(payload: any) {
        this._favoriteSaveLoader$.next(true)
        this.http.SendRequest("post", `${this.apiUrl}/Favorite`, payload)
            .pipe(
                catchError((error: HttpErrorResponse) => {
                    this._favorite$.next([])
                    this._favoriteSaveLoader$.next(false);
                    throw error;
                })
            )
            .subscribe(data => {
                let allFav: any = []
                this.favorites$.pipe(take(1)).subscribe(value => allFav = value);
                allFav.push(data)
                this._favorite$.next(allFav)
                this._favoriteSaveLoader$.next(false);
            })
    }

    DeleteFavorite(id: number, userId: number) {
        this.http.SendRequest("delete", `${this.apiUrl}/Favorite?id=${id}`)
            .pipe(
                catchError((error: HttpErrorResponse) => {
                    console.error(error.message)
                    throw error;
                })
            )
            .subscribe(data => {
                this.GetFavorites(userId)
            })
    }
}
