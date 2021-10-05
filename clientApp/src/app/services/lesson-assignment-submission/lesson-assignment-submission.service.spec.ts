import { TestBed } from '@angular/core/testing';

import { LessonAssignmentSubmissionService } from './lesson-assignment-submission.service';

describe('LessonAssignmentSubmissionService', () => {
  let service: LessonAssignmentSubmissionService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(LessonAssignmentSubmissionService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
