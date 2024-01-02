import { Component, OnInit, ViewChild } from '@angular/core';
import { FormControl, FormGroup, FormBuilder } from '@angular/forms';
import { Table } from 'primeng/table';
import { CompanyService } from '../services/company.service';
import { LovService } from '../services/lov.service';
import { FavoriteService } from '../services/favorite.service';
import { FavoriteCompanyService } from '../services/favouriteCompany.service';
import { ConfirmationService } from 'primeng/api';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss'],
  providers: [ConfirmationService]
})
export class HomeComponent implements OnInit {
  @ViewChild('companyTable') companyTable!: Table;
  companies!: any;
  companyLoader!: boolean;

  categories: any;
  categoriesLoader!: boolean;

  countries: any;
  countriesLoader!: boolean;

  regions: any;
  regionsLoader!: boolean;

  showFilter: boolean = false;
  searchValue: string = "";
  filterForm!: FormGroup;
  showFavoriteDialog = false;
  SelectedCompany: any = {};

  favorites!: any;
  selectedFavoriteList = null
  isFavoriteSelected = false

  user: any


  companyColumns: any = [
    { name: "CATEGORY", value: "categoryName" },
    { name: "COMPANY", value: "name" },
    { name: "COUNTRY", value: "country" },
    { name: "REGION", value: "region" },
    { name: "WEBSITE", value: "website" },
    { name: "TYPE", value: "type" },
    { name: "", value: "action" },
  ];

  constructor(
    private companyService: CompanyService,
    private lovService: LovService,
    private formBuilder: FormBuilder,
    private favoriteService: FavoriteService,
    private favoriteCompanyService: FavoriteCompanyService,
    private confirmationService: ConfirmationService
  ) {
    this.filterForm = this.formBuilder.group({
      CategoryId: [],
      Country: [],
      Region: []
    });
  }
  ngOnInit(): void {
    const existingValue = this.companyService.searchFilter
    this.searchValue = existingValue.Company;
    this.filterForm = new FormGroup({
      "Country": new FormControl(existingValue.Country),
      "Company": new FormControl(existingValue.Company),
      "Website": new FormControl(existingValue.Website),
      "CategoryId": new FormControl(existingValue.CategoryId),
      "Region": new FormControl(existingValue.Region),
    });

    this.companyService.companies$.subscribe(data => {
      const searchFilter = this.companyService.searchFilter
      if (!searchFilter.isFavoriteSelected) {
        this.companies = data;
      } else {
        this.isFavoriteSelected = true
      }

      if (data.length > 10) {

        setTimeout(() => {
          const rowNumber = searchFilter.rowNumber
          const rows = searchFilter.rows
          this.companyTable.first = rowNumber
          this.companyTable.rows = rows
        }, 100);
      }
    });

    this.companyService.companyLoader$.subscribe(loader => this.companyLoader = loader);
    this.lovService.countriesLoader$.subscribe(loader => this.countriesLoader = loader);
    this.lovService.regionsLoader$.subscribe(loader => this.regionsLoader = loader);

    this.lovService.categories$.subscribe(data => {
      // Get Categories if not exist
      if (!data || data.length === 0) {
        this.lovService.GetCategories();
      }
      this.categories = data;
    });

    this.lovService.countries$.subscribe(data => {
      // Get Categories if not exist
      if (!data || data.length === 0) {
        this.lovService.GetCountries();
      }
      this.countries = data;
    });
    this.lovService.regions$.subscribe(data => {
      // Get Categories if not exist
      if (!data || data.length === 0) {
        this.lovService.GetRegions();
      }
      this.regions = data;
    });

    this.favoriteService.favorites$.subscribe(data => {
      this.favorites = data;
    });
    this.favoriteCompanyService.companiesByFavoriteId$.subscribe(data => {
      if (this.isFavoriteSelected) {
        this.companies = data;
      }
    });
    this.favoriteCompanyService.companiesByFavoriteIdLoader$.subscribe(data => {
      this.companyLoader = false;
    });

    this.user = JSON.parse(localStorage.getItem('user') || '{}');
    this.favoriteService.GetFavorites(this.user.userId);

  }
  ModifyUrl(url: string) {
    if (!url) return false
    if (url === "No Website") return false
    if (!url.startsWith("http")) return `https://${url}`
    return url;

  }
  clickFavoriteBtn(company: any) {
    this.SelectedCompany = company;
    this.showFavoriteDialog = true;
  }
  FilterChanged() {
    if (!this.selectedFavoriteList) {
      this.companies = []
      return
    };
    this.companyLoader = true
    this.getCompaniesByFavoriteId(this.selectedFavoriteList["id"]);
  }
  onChangePage(e: any) {
    this.companyService.searchFilter.rowNumber = e.first
    this.companyService.searchFilter.rows = e.rows
  }
  // Fetch companies data
  getDataDetails() {
    this.filterForm.get("Company")?.setValue(this.searchValue)
    if (!this.searchValue) {
      this.companies = []
      return
    }
    this.getCompanies()
  }
  getCompanies() {
    this.selectedFavoriteList = null
    this.companyService.GetCompanies(this.filterForm.value);
  }
  getCompaniesByFavoriteId(id: number) {
    this.isFavoriteSelected = true
    this.companyService.searchFilter.isFavoriteSelected = true
    this.favoriteCompanyService.GetCompaniesByFavId(id)
  }
  GetDetailPageLink(company: any) {
    switch (company.companyType) {
      case "Olffi":
        return "/company/olffi-detail/" + company.id

      default:
        return "/company/detail/" + company.id
    }
  }
  favoriteSuccess(status: boolean) {
    if (this.selectedFavoriteList) {
      this.getCompaniesByFavoriteId(this.selectedFavoriteList["id"]);
    } else {
      this.getCompanies()
    }
  }
  deleteFavorite(id: number) {
    this.confirmationService.confirm({
      accept: () => {
        this.favoriteService.DeleteFavorite(id, this.user.userId)
      },
      reject: () => { },
    });

  }
}

