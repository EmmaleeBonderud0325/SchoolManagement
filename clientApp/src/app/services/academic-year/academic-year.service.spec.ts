import { TestBed } from '@angular/core/testing';

import { AcademicYearService } from './academic-year.service';

describe('AcademicYearService', () => {
  let service: AcademicYearService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(AcademicYearService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
