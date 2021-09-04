import { TestBed } from '@angular/core/testing';

import { McqQuestionStudentAnswerService } from './mcq-question-student-answer.service';

describe('McqQuestionStudentAnswerService', () => {
  let service: McqQuestionStudentAnswerService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(McqQuestionStudentAnswerService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
