import { TestBed } from '@angular/core/testing';

import { EssayStudentAnswerService } from './essay-student-answer.service';

describe('EssayStudentAnswerService', () => {
  let service: EssayStudentAnswerService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(EssayStudentAnswerService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
