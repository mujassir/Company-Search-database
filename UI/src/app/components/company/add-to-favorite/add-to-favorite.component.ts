import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FavoriteService } from 'src/app/services/favorite.service';
import { FavoriteCompanyService } from 'src/app/services/favouriteCompany.service';

@Component({
  selector: 'app-add-to-favorite',
  templateUrl: './add-to-favorite.component.html',
  styleUrls: ['./add-to-favorite.component.scss']
})
export class AddToFavoriteComponent implements OnInit {
  @Input() company: any = {}
  @Input() favorite: any = {}
  @Output() close = new EventEmitter();

  favorites!: any;
  favoriteLoader!: boolean;
  favoriteSaveLoader!: boolean;

  selectedItems: any[] = []
  CompanySelectedItems: any[] = []
  AddTitleArea = false;
  title: string = ""
  user: any
  constructor(private favoriteService: FavoriteService, private favoriteCompanyService: FavoriteCompanyService) { }

  ngOnInit(): void {

    this.user = JSON.parse(localStorage.getItem('user') || '{}');
    this.favoriteService.favorites$.subscribe(data => {
      this.favorites = data;
      this.title = ""
    });
    this.favoriteService.favoriteLoader$.subscribe(data => {
      this.favoriteLoader = data;
    });
    this.favoriteService.favoriteSaveLoader$.subscribe(data => {
      this.favoriteSaveLoader = data;
    });
    this.favoriteService.GetFavorites(this.user.userId);

    this.favoriteCompanyService.favorites$.subscribe(data => {
      this.selectedItems = this.favorites.filter((fav: any) => data.map((item: any) => item.favoriteId).includes(fav.id));
      this.CompanySelectedItems = JSON.parse(JSON.stringify(this.selectedItems))
    });
    this.favoriteCompanyService.GetFavorites(this.user.userId, this.company.id)
  }

  createFavorite() {
    if (!this.title) return
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
    if (this.CompanySelectedItems.map(e => e.id).includes(item.id)) {
      this.favoriteCompanyService.RemoveFavorite(payload, this.user.userId, this.favorite["id"])
    } else {
      this.favoriteCompanyService.CreateFavorite(payload, this.user.userId, this.favorite["id"])
    }

  }
}
