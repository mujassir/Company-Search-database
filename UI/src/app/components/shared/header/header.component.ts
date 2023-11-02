import { Component } from '@angular/core';
import { MenuItem } from 'primeng/api';

@Component({
  selector: 'shared-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss']
})
export class SharedHeaderComponent {
  items: MenuItem[];

  constructor() {
    this.items = [
      {
        label: 'Home',
        routerLink: '',

      },
      {
        label: 'Production',
        routerLink: '/login',
        items: [
          {
            label: 'Scripted',
            icon: 'pi pi-fw pi-align-left'
          },
          {
            label: 'Non-Scripted',
            icon: 'pi pi-fw pi-align-right'
          },
        ]
      },
      {
        label: 'Short Corner',
      },
      {
        label: 'W2E',
      },
      {
        label: 'Tech',
        items: [
          {
            label: 'Film Tech Labs',
            icon: 'pi pi-fw pi-pencil',
            items: [
              {
                label: 'Save',
                icon: 'pi pi-fw pi-calendar-plus'
              },
              {
                label: 'Delete',
                icon: 'pi pi-fw pi-calendar-minus'
              }
            ]
          },
          {
            label: 'NFT',
          }
        ]
      },
      {
        label: 'News',
      },
      {
        label: 'Abouts',
      },
      {
        label: 'Contact us',
      }
    ];
  }
}
