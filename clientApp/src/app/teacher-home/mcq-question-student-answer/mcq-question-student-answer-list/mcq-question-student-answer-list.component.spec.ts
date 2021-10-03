import { ComponentFixture, TestBed } from '@angular/core/testing';

import { McqQuestionStudentAnswerListComponent } from './mcq-question-student-answer-list.component';

describe('McqQuestionStudentAnswerListComponent', () => {
  let component: McqQuestionStudentAnswerListComponent;
  let fixture: ComponentFixture<McqQuestionStudentAnswerListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ McqQuestionStudentAnswerListComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(McqQuestionStudentAnswerListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
