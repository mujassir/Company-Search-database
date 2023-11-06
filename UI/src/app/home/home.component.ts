import { Component, OnInit, ViewChild } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { CommonService } from '../services/common.service';
import { Observable, catchError } from 'rxjs';
import { HttpErrorResponse } from '@angular/common/http';
import { Table } from 'primeng/table';
import { CompanyService } from '../services/company.service';
import { CategoryService } from '../services/category.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {
  @ViewChild('companyTable') companyTable!: Table;
  companies!: any;
  companyLoader!: boolean;

  categories: any;
  countries: any; // Add this
  regions: any; // Add this

  showFilter: boolean = false;
  searchValue: string = "";
  filterForm!: FormGroup;

  companyColumns: any = [
    { name: "CATEGORY", value: "categoryName" },
    { name: "COMPANY", value: "name" },
    { name: "COUNTRY", value: "country" },
    { name: "WEBSITE", value: "website" },
    { name: "TYPE", value: "type" },
  ];

  constructor(private categoryService: CategoryService, private companyService: CompanyService) { }

  ngOnInit(): void {
    this.filterForm = new FormGroup({
      "Country": new FormControl(''),
      "Company": new FormControl(''),
      "Website": new FormControl(''),
      "CategoryId": new FormControl(''),
      "Region": new FormControl(''),
    })
  
    this.companyService.companies$.subscribe(data => this.companies = data);
    this.companyService.companyLoader$.subscribe(loader => this.companyLoader = loader);
  
    this.categoryService.categories$.subscribe(data => {
      // Get Categories if not exist
      if (!data || data?.length === 0) return this.getCategories()
      this.categories = data || []
      if (data.length > 0) {
        this.filterForm.get("CategoryId")?.setValue(data[0].id)
        this.categories.unshift({ id: '', name: 'All' })
      }
      
    });
       // Populate countries and regions with dummy data for testing
      //  this.categories = [
      //   { id: 1, name: 'Company 1' },
      //   { id: 2, name: 'Company 2' },
      //   { id: 3, name: 'Company 3' },
      // ];  
      this.countries = [
        { id: 1, name: 'Country 1' },
        { id: 2, name: 'Country 2' },
        { id: 3, name: 'Country 3' },
      ];
    
      this.regions = [
        { id: 1, name: 'Region 1' },
        { id: 2, name: 'Region 2' },
        { id: 3, name: 'Region 3' },
      ]
  
  }
  getCategories() {
    this.categoryService.GetCategories()
  }
  // Fetch countries data
  getCountries() {
   
  }
  
  // Fetch regions data
  getRegions() {
 
  }
 // Fetch companies data
  getDataDetails() {
    console.log("Marvel Studio")
    // Create a copy of the filter form value
  const filterFormValue = { ...this.filterForm.value };

  // Modify the filter value to include only the company name
  filterFormValue.Company = this.searchValue;

  // Call the service to get the filtered data
  this.companyService.GetCompanies(filterFormValue);
  }
}
