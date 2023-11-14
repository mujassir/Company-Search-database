import { Injectable } from '@angular/core';
import { HttpService } from './http.service';
import { AppConfig } from '../common/app-config';

@Injectable({
  providedIn: 'root'
})
export class CommonService {
  apiUrl = AppConfig.API_BASE_URL;
  constructor(private http: HttpService) { }
  
  GetStaffMembers(payload: any) {
    return this.http.SendRequest("get", `${this.apiUrl}/StaffMember/Search?role=${payload.Role}&country=${payload.Country}&company=${payload.Company}&website=${payload.Website}&categoryId=${payload.CategoryId}`)
  }
}
