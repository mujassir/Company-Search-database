// favorite.service.ts
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root',
})
export class FavoriteService {
  private apiUrl = 'https://localhost:7047';

  constructor(private http: HttpClient) {}

  saveFavorite(data: any) {
    return this.http.post(`${this.apiUrl}/favoriteCompany`, data);
  }

  // You can also add a method to fetch the user's favorites
  getFavorites() {
    return this.http.get(`${this.apiUrl}/favoriteCompany`);
  }
}
