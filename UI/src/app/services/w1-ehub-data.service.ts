import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http'

@Injectable({
  providedIn: 'root'
})
export class W1EhubDataService {
  apiUrl = "https://localhost:7047";
  constructor(private http: HttpClient) { }

  data(payload: any) {
    return this.http.get(`${this.apiUrl}/project/search?Country=${payload.Country}&TypeOfCompany=${payload.TypeOfCompany}&Region=${payload.Region}`)
  }
}
