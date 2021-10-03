import { TestBed } from '@angular/core/testing';

import { StudentMcqQuestionAnswerService } from './student-mcq-question-answer.service';

describe('StudentMcqQuestionAnswerService', () => {
  let service: StudentMcqQuestionAnswerService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(StudentMcqQuestionAnswerService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
