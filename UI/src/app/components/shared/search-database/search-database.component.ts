import { Component } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { TreeNode } from 'primeng/api';
import { W1EhubDataService } from 'src/app/services/w1-ehub-data.service';

interface Column {
  field: string;
  header: string;
}

@Component({
  selector: 'app-search-database',
  templateUrl: './search-database.component.html',
  styleUrls: ['./search-database.component.scss']
})
export class SearchDatabaseComponent {
  searchValue!: string;
  filterForm: FormGroup
  showDataTable: boolean = false;
  showFilter: boolean = false;
  dataTableDetails!: TreeNode[];
  cols = [
    { field: 'level', header: 'LEVEL' },
    { field: 'country', header: 'COUNTRY' },
    { field: 'description', header: 'FUNDING BODY' },
    { field: 'title', header: 'PROGRAMME' },
    { field: 'activity', header: 'ACTIVITY' },
    { field: 'type', header: 'PROJECT TYPES' },
    { field: 'nature', header: 'NATURE OF PROJECTS' },
  ];

  dataDetails: any;

  constructor(private W1EhubData: W1EhubDataService) {
    this.filterForm = new FormGroup({
      'Country': new FormControl(''),
      'TypeOfCompany': new FormControl(''),
      'Region': new FormControl('')
    });
  }

  ngOnInit() {

  }
  getDataDetails() {
    this.W1EhubData.data(this.filterForm?.value).subscribe((data: any) => {
      this.dataDetails = data;
      if (data.length > 0) {
        this.showDataTable = true
        this.dataTableDetails = this.dataDetails.map((item: any) => {
          return {
            level: item.level,
            country: item.country,
            description: item.description,
            title: item.title,
            activity: item.activity,
            type: item.type,
            nature: item.nature,
          };
        });
      } else {
        this.dataDetails = [];
        this.dataTableDetails = []
      }
    });
  }
}




































