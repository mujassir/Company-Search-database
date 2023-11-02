import { HttpClient, HttpErrorResponse } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable, catchError } from "rxjs";

@Injectable({
    providedIn: 'root'
})
export class HttpService {
    constructor(private http: HttpClient) { }

    SendRequest<T>(type: string, url: string, data?: any): Observable<T> {
        let request: Observable<any>;

        if (['get', 'delete', 'post', 'put', 'patch'].includes(type)) {
            request = this.http.request<T>(type, url, { body: data });
        } else {
            throw Error(`Invalid request type: ${type}`);
        }

        return request.pipe(
            catchError((error: HttpErrorResponse) => {
                console.error('Error occurred:', error);
                throw error;
            })
        );
    }
}