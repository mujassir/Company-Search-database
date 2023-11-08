import { Component, OnInit, ViewChild } from '@angular/core';
import { FormControl, FormGroup,FormBuilder } from '@angular/forms';
import { Table } from 'primeng/table';
import { CompanyService } from '../services/company.service';
import { CategoryService } from '../services/category.service';
import { RegionService } from '../services/region.service';
import { CountryService } from '../services/country.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss'],
  providers: [CountryService]
})
export class HomeComponent implements OnInit {
  @ViewChild('companyTable') companyTable!: Table;
  companies!: any;
  companyLoader!: boolean;
  categories: any;
  countries: any;
  regions: any[] = [];

  showFilter: boolean = false;
  searchValue: string = "";
  filterForm!: FormGroup;
  originalCompanies: any[] = [];
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
    private categoryService: CategoryService,
    private companyService: CompanyService,
    private regionService: RegionService,
    private countryService: CountryService,
    private formBuilder: FormBuilder
  ) {
    this.filterForm = this.formBuilder.group({
      CategoryId: [],
      Country: [],
      Region: [[]]
    });
  }
  updateRegionSelection(event: any) {
    this.filterForm.get('Region')?.setValue(event.value);
  }
  ngOnInit(): void {
    this.filterForm = new FormGroup({
      "Country": new FormControl(''),
      "Company": new FormControl(''),
      "Website": new FormControl(''),
      "CategoryId": new FormControl([]),
      "Region": new FormControl(''),
    });

    this.companyService.companies$.subscribe(data => {
      this.companies = data;
      if (data.length > 10) {
        setTimeout(() => {
          this.companyTable.first = 1;
        }, 100);
      }
    });

    this.companyService.companyLoader$.subscribe(loader => this.companyLoader = loader);

    this.categoryService.categories$.subscribe(data => {
      // Get Categories if not exist
      if (!data || data.length === 0) {
        this.getCategories();
      }
      this.categories = data;
    });

    // this.regionService.GetRegions().subscribe((response: any) => {
    //   this.regions = response.map((region: any) => {
    //     console.log(region.name)
    //     return {
    //       value: region.regionId, 
    //       label: region.name
    //     };
    //   });
    // });
    this.regionService.GetRegions().subscribe((response: any) => {
      this.regions = response.map((region: any) => {
        return {
          value: region.name,
          label: region.name
        };
      });
  
      // Update the selected region values in the form control
      const selectedRegions = this.filterForm.get('Region')?.value || [];
      this.filterForm.get('Region')?.setValue(selectedRegions);
    });

    this.countryService.getCountries().subscribe((data: any) => {
      this.countries = data.map((country: any) => {
        console.log(country.name)
        return {
          value: country.name,
          label: country.name
        };
      });
    });
    
  }

  getCategories() {
    this.categoryService.GetCategories();
  }

  clickFavoriteBtn(company: any) {
    this.SelectedCompany = company;
    this.showFavoriteDialog = true;
  }

  // Fetch companies data
  getDataDetails() {
    const filters = this.filterForm.value;
  
    if (!filters.CategoryId && !filters.Country && !filters.Region) {
      this.companies = this.originalCompanies;
      return;
    }
  
    this.companies = this.originalCompanies.filter((company: any) => {
      let matchCategory = true;
      let matchCountry = true;
      let matchRegion = true;
  
      if (filters.CategoryId && filters.CategoryId.length > 0) {
        matchCategory = filters.CategoryId.includes(company.categoryId);
      }
  
      if (filters.Country && filters.Country.length > 0) {
        matchCountry = filters.Country.includes(company.country);
      }
  
      if (filters.Region && filters.Region.length > 0) {
        matchRegion = filters.Region.some((regionId: number) =>
          company.regions.some((companyRegion: any) => companyRegion.id === regionId)
        );
      }
  
      return matchCategory && matchCountry && matchRegion;
    });
  }
}
    