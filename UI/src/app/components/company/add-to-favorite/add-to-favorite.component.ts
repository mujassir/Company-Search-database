import { Component, Input, OnInit } from '@angular/core';
import { FavoriteService } from 'src/app/services/favorite.service';
import { FavoriteCompanyService } from 'src/app/services/favouriteCompany.service';

@Component({
  selector: 'app-add-to-favorite',
  templateUrl: './add-to-favorite.component.html',
  styleUrls: ['./add-to-favorite.component.scss']
})
export class AddToFavoriteComponent implements OnInit {
  @Input() company: any = {}
  favorites!: any;
  favoriteLoader!: boolean;

  selectedItems: any[] = []
  AddTitleArea = false;
  title: string = ""
  user: any
  constructor(private favoriteService: FavoriteService, private favoriteCompanyService: FavoriteCompanyService) { }

  ngOnInit(): void {
    
    this.user = JSON.parse(localStorage.getItem('user') || '{}');
    this.favoriteService.favorites$.subscribe(data => {
      this.favorites = data;
      this.selectedItems = this.favorites.filter((e: any) => data.map((item: any) => item.favoriteId).includes(e.id));
      this.title = ""
    });
    this.favoriteService.favoriteLoader$.subscribe(data => {
      this.favoriteLoader = data;
    });
    this.favoriteService.GetFavorites(this.user.userId);

    this.favoriteCompanyService.favorites$.subscribe(data => {
      this.selectedItems = this.favorites.filter((e: any) => data.map((item: any) => item.favoriteId).includes(e.id));
    });
    this.favoriteCompanyService.GetFavorites(this.user.userId, this.company.id)
  }

  createFavorite() {
    const payload = {
      title: this.title,
      userId: this.user.userId
    }
    this.favoriteService.CreateFavorite(payload)
  }
  AddToFavorite(item: any) {
    const payload = {
      favoriteId: item.id,
      companyId: this.company.id
    }
    this.favoriteCompanyService.CreateFavorite(payload, this.user.userId)
  }
}
