import { TestBed } from '@angular/core/testing';

import { AcademicLevelService } from './academic-level.service';

describe('AcademicLevelService', () => {
  let service: AcademicLevelService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(AcademicLevelService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
