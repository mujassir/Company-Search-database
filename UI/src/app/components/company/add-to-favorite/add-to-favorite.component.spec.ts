import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddToFavoriteComponent } from './add-to-favorite.component';

describe('AddToFavoriteComponent', () => {
  let component: AddToFavoriteComponent;
  let fixture: ComponentFixture<AddToFavoriteComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [AddToFavoriteComponent]
    });
    fixture = TestBed.createComponent(AddToFavoriteComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
