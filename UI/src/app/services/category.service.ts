import { Injectable } from '@angular/core';
import { HttpService } from './http.service';
import { BehaviorSubject, catchError } from 'rxjs';
import { HttpErrorResponse } from '@angular/common/http';

@Injectable({
    providedIn: 'root'
})
export class CategoryService {
    private _categories$ = new BehaviorSubject<any>([]);
    private _categoryLoader$ = new BehaviorSubject<boolean>(false);

    apiUrl = "https://localhost:7047";
    constructor(private http: HttpService) { }

    categories$ = this._categories$.asObservable()
    categoryLoader$ = this._categoryLoader$.asObservable()

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
}
