import { TestBed } from '@angular/core/testing';

import { McqQuestionAnswerService } from './mcq-question-answer.service';

describe('McqQuestionAnswerService', () => {
  let service: McqQuestionAnswerService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(McqQuestionAnswerService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
