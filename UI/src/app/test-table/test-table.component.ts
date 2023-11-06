import { Component, OnInit } from '@angular/core';
import { Product } from '../domain/product';
import { ProductService } from '../services/productservice';
import { FavoriteService } from '../services/favouriteCompany.service';

@Component({
  selector: 'app-test-table',
  templateUrl: './test-table.component.html',
  styleUrls: ['./test-table.component.scss']
})
export class TestTableComponent implements OnInit {
  visible: boolean = false;
  products: Product[] = [];
  selectedCategories: { [productId: string]: { [categoryKey: string]: boolean } } = {};
  categories: any[] = [
    { name: 'Company', key: 'A' },
    { name: 'Country', key: 'M' },
  ];
  selectedProduct: Product | null = null;
  customName: string = '';
  creatingNew: boolean = false; // Property to control input field visibility

  constructor(private productService: ProductService, private favoriteService: FavoriteService) {}

  ngOnInit(): void {
    this.productService.getProductsMini().then((data) => {
      if (data) {
        this.products = data;
      }
    });
  }

  showDialog(product: Product) {
    this.visible = true;
    this.selectedProduct = product;
  }

  onCheckboxChange(productId: string, categoryKey: string, event: any) {
    if (!this.selectedCategories[productId]) {
      this.selectedCategories[productId] = {};
    }
    this.selectedCategories[productId][categoryKey] = event;
  }

  saveFavoriteData(productId: string) {
    if (this.selectedCategories[productId] || this.customName) {
      const selectedCategories = this.selectedCategories[productId];
      const dataToSave = Object.keys(selectedCategories || {})
        .filter((categoryKey) => selectedCategories[categoryKey])
        .map((categoryKey) => ({
          category: categoryKey,
          value: this.customName || 'Your Value Here',
        }));
      this.favoriteService.saveFavorite(dataToSave).subscribe((response) => {
        console.log('Data saved successfully:', response);
      });
    }
    this.customName = ''; // Reset customName
    this.visible = false;
  }

  toggleInputField() {
    this.creatingNew = !this.creatingNew;
  }
}
