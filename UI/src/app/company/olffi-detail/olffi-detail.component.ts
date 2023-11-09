import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { CompanyService } from 'src/app/services/company.service';

@Component({
  selector: 'app-olffi-detail',
  templateUrl: './olffi-detail.component.html',
  styleUrls: ['./olffi-detail.component.scss']
})
export class CompanyOlffiDetailComponent implements OnInit {
  routerId: string | null = null
  company!: any;
  companyLoader!: boolean;

  showFavoriteDialog = false

  constructor(private companyService: CompanyService, private router: ActivatedRoute) { }

  ngOnInit(): void {
    this.routerId = this.router.snapshot.paramMap.get('id');

    this.companyService.company$.subscribe(data => {
      this.company = data;
    });
    this.companyService.companyLoader$.subscribe(loader => this.companyLoader = loader);

    if (this.routerId) {
      this.companyService.GetByIdWithProgram(Number(this.routerId));
    }
  }

  clickFavoriteBtn() {
    this.showFavoriteDialog = true
  }
  HTMLSerlizer(data: string) {
    if (!data) return
    return data.replace(/\n/g, '<br />')
  }
}
