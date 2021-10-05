import { TestBed } from '@angular/core/testing';

import { LessonAssignmentService } from './lesson-assignment.service';

describe('LessonAssignmentService', () => {
  let service: LessonAssignmentService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(LessonAssignmentService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
