import { Injectable } from "@angular/core";
import { HttpService } from "./http.service";
import { Router } from "@angular/router";
import { BehaviorSubject, Observable } from "rxjs";

@Injectable({
    providedIn: 'root'
})
export class AuthService {
    private _isLoggedIn = new BehaviorSubject<boolean>(false);

    constructor(private http: HttpService, private router: Router) { }

    get isLoggedIn$(): Observable<boolean> {
        return this._isLoggedIn.asObservable();
    }

    AutoLogedIn() {
        const user = localStorage.getItem('user')
        this._isLoggedIn.next(user ? true : false)
    }

    async LogIn(user: any) {
        this.http.SendRequest('get', "https://api.npoint.io/63b43a77637fa1a39b57").subscribe((response) => {
            localStorage.setItem('user', JSON.stringify(response))
            this._isLoggedIn.next(true)
            this.router.navigate(['/'])
        })
    }

    LogOut() {
        localStorage.removeItem('user')
        this._isLoggedIn.next(false)
    }
}