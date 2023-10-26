import { Component } from '@angular/core';
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

  showFilter: boolean = false;

  toggleFilterDiv() {
    this.showFilter = !this.showFilter;
  }
  
  value: string | undefined;
  value2: string | undefined;
  files!: TreeNode[];
  cols!: Column[];
  dataDetails: any;

  constructor(private W1EhubData: W1EhubDataService) {}

  ngOnInit() {
    this.W1EhubData.data().subscribe((data: any) => {
      this.dataDetails = data;

      console.log("Data from Api:", this.dataDetails )

      if (this.dataDetails && Array.isArray(this.dataDetails)) {
        this.files = this.dataDetails.map((item: any) => {
          return {
            data: {
              level: item.level,
              country: item.country,
              description:item.description,
              title:item.title,
              activity:item.activity,
              type:item.type,
              nature: item.nature,
            },
          };
        });
      }

      this.cols = [
        { field: 'level', header: 'LEVEL' },
        { field: 'country', header: 'COUNTRY' },
        { field: 'description', header: 'FUNDING BODY' },
        { field: 'title', header: 'PROGRAMME' },
        { field: 'activity', header: 'ACTIVITY' },
        { field: 'type', header: 'PROJECT TYPES' },
        { field: 'nature', header: 'NATURE OF PROJECTS' },
      ];
    });
  }
}




































