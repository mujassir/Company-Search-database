import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http'

@Injectable({
  providedIn: 'root'
})
export class W1EhubDataService {
apiUrl="https://api.npoint.io/ab5d3170792a8d1e2bc6";
  constructor(private http:HttpClient) { }

  data(){
    return this.http.get(this.apiUrl)
  }
}
