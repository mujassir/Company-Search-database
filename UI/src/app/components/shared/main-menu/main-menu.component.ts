import { Component } from '@angular/core';
import { MenuItem } from 'primeng/api';

@Component({
  selector: 'app-main-menu',
  templateUrl: './main-menu.component.html',
  styleUrls: ['./main-menu.component.scss']
})
export class MainMenuComponent {
  items: MenuItem[];

  constructor() {
    this.items = [
      {
          label: 'Home',
          routerLink: '',
        //   icon: 'pi pi-fw pi-file',
          // items: [
          //     {
          //         label: 'New',
          //         icon: 'pi pi-fw pi-plus',
          //         items: [
          //             {
          //                 label: 'Bookmark',
          //                 icon: 'pi pi-fw pi-bookmark'
          //             },
          //             {
          //                 label: 'Video',
          //                 icon: 'pi pi-fw pi-video'
          //             }
          //         ]
          //     },
          //     {
          //         label: 'Delete',
          //         icon: 'pi pi-fw pi-trash'
          //     },
          //     {
          //         separator: true
          //     },
          //     {
          //         label: 'Export',
          //         icon: 'pi pi-fw pi-external-link'
          //     }
          // ]
      },
      {
          label: 'Production',
          routerLink:'/login',
        //   icon: 'pi pi-fw pi-pencil',
          items: [
              {
                  label: 'Scripted',
                  icon: 'pi pi-fw pi-align-left'
              },
              {
                  label: 'Non-Scripted',
                  icon: 'pi pi-fw pi-align-right'
              },
              // {
              //     label: 'Center',
              //     icon: 'pi pi-fw pi-align-center'
              // },
              // {
              //     label: 'Justify',
              //     icon: 'pi pi-fw pi-align-justify'
              // }
          ]
      },
      {
          label: 'Short Corner',
        //   icon: 'pi pi-fw pi-user',
          // items: [
          //     {
          //         label: 'New',
          //         icon: 'pi pi-fw pi-user-plus'
          //     },
          //     {
          //         label: 'Delete',
          //         icon: 'pi pi-fw pi-user-minus'
          //     },
          //     {
          //         label: 'W2E',
          //         icon: 'pi pi-fw pi-users',
          //         items: [
          //             {
          //                 label: 'Filter',
          //                 icon: 'pi pi-fw pi-filter',
          //                 items: [
          //                     {
          //                         label: 'Print',
          //                         icon: 'pi pi-fw pi-print'
          //                     }
          //                 ]
          //             },
          //             {
          //                 icon: 'pi pi-fw pi-bars',
          //                 label: 'List'
          //             }
          //         ]
          //     }
          // ]
      },
      {
        label: 'W2E',
        // icon: 'pi pi-fw pi-power-off'
      },
      {
          label: 'Tech',
        //   icon: 'pi pi-fw pi-calendar',
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
                //   icon: 'pi pi-fw pi-calendar-times',
                  // items: [
                  //     {
                  //         label: 'Remove',
                  //         icon: 'pi pi-fw pi-calendar-minus'
                  //     }
                  // ]
              }
          ]
      },
      {
        label: 'News',
        // icon: 'pi pi-fw pi-power-off'
    },
      {
          label: 'Abouts',
        //   icon: 'pi pi-fw pi-power-off'
      },
      {
        label: 'Contact us',
        // icon: 'pi pi-fw pi-power-off'
    }
  ];
  }
}
