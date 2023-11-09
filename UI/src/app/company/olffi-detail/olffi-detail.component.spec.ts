import { ComponentFixture, TestBed } from '@angular/core/testing';

import { OlffiDetailComponent } from './olffi-detail.component';

describe('OlffiDetailComponent', () => {
  let component: OlffiDetailComponent;
  let fixture: ComponentFixture<OlffiDetailComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [OlffiDetailComponent]
    });
    fixture = TestBed.createComponent(OlffiDetailComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
