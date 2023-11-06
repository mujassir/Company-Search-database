import { Injectable } from "@angular/core";
import { HttpService } from "./http.service";
import { Router } from "@angular/router";
import { BehaviorSubject, Observable } from "rxjs";

@Injectable({
    providedIn: 'root'
})
export class AuthService {
    private _isLoggedIn = new BehaviorSubject<boolean>(false);
    apiUrl = "https://localhost:7047";

    constructor(private http: HttpService, private router: Router) { }

    get isLoggedIn$(): Observable<boolean> {
        return this._isLoggedIn.asObservable();
    }

    AutoLogedIn() {
        const user = localStorage.getItem('user')
        this._isLoggedIn.next(user ? true : false)
    }

    async LogIn(user: any) {
        this.http.SendRequest('post', this.apiUrl + '/login', user).subscribe((response) => {
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