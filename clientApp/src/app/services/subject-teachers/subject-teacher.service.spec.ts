import { TestBed } from '@angular/core/testing';

import { SubjectTeacherService } from './subject-teacher.service';

describe('SubjectTeacherService', () => {
  let service: SubjectTeacherService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(SubjectTeacherService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
