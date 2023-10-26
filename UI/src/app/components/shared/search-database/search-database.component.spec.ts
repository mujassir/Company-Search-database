import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SearchDatabaseComponent } from './search-database.component';

describe('SearchDatabaseComponent', () => {
  let component: SearchDatabaseComponent;
  let fixture: ComponentFixture<SearchDatabaseComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [SearchDatabaseComponent]
    });
    fixture = TestBed.createComponent(SearchDatabaseComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
