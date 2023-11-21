import { Component, OnInit, ViewChild } from '@angular/core';
import { FormControl, FormGroup, FormBuilder } from '@angular/forms';
import { Table } from 'primeng/table';
import { CompanyService } from '../services/company.service';
import { LovService } from '../services/lov.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss'],
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

  companyColumns: any = [
    { name: "CATEGORY", value: "categoryName" },
    { name: "COMPANY", value: "name" },
    { name: "COUNTRY", value: "country" },
    { name: "WEBSITE", value: "website" },
    { name: "TYPE", value: "type" },
    { name: "", value: "action" },
  ];

  constructor(
    private companyService: CompanyService,
    private lovService: LovService,
    private formBuilder: FormBuilder
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
      this.companies = data;
      if (data.length > 10) {

        setTimeout(() => {
          const rowNumber = this.companyService.searchFilter.rowNumber
          this.companyTable.first = rowNumber
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

  }

  clickFavoriteBtn(company: any) {
    this.SelectedCompany = company;
    this.showFavoriteDialog = true;
  }
  onChangePage(e: any) {
    this.companyService.searchFilter.rowNumber = e.first
  }
  // Fetch companies data
  getDataDetails() {
    this.filterForm.get("Company")?.setValue(this.searchValue)
    // Call the service to get the filtered data
    this.companyService.GetCompanies(this.filterForm.value);
  }
  GetDetailPageLink(company: any) {
    switch (company.companyType) {
      case "Olffi":
        return "/company/olffi-detail/" + company.id

      default:
        return "/company/detail/" + company.id
    }
  }
}

