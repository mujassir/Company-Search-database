import { TestBed } from '@angular/core/testing';

import { W1EhubDataService } from './w1-ehub-data.service';

describe('W1EhubDataService', () => {
  let service: W1EhubDataService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(W1EhubDataService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
