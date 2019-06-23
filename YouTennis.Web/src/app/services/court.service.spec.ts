import { TestBed } from '@angular/core/testing';

import { CourtService } from './court.service';

describe('CourtService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: CourtService = TestBed.get(CourtService);
    expect(service).toBeTruthy();
  });
});
