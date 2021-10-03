import { ComponentFixture, TestBed } from '@angular/core/testing';

import { McqQuestionStudentAnswerDetailsComponent } from './mcq-question-student-answer-details.component';

describe('McqQuestionStudentAnswerDetailsComponent', () => {
  let component: McqQuestionStudentAnswerDetailsComponent;
  let fixture: ComponentFixture<McqQuestionStudentAnswerDetailsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ McqQuestionStudentAnswerDetailsComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(McqQuestionStudentAnswerDetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
