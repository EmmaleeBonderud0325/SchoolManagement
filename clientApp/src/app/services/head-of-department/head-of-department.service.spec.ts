import { TestBed } from '@angular/core/testing';

import { HeadOfDepartmentService } from './head-of-department.service';

describe('HeadOfDepartmentService', () => {
  let service: HeadOfDepartmentService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(HeadOfDepartmentService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
