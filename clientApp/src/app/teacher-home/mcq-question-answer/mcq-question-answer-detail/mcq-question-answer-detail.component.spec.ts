import { ComponentFixture, TestBed } from '@angular/core/testing';

import { McqQuestionAnswerDetailComponent } from './mcq-question-answer-detail.component';

describe('McqQuestionAnswerDetailComponent', () => {
  let component: McqQuestionAnswerDetailComponent;
  let fixture: ComponentFixture<McqQuestionAnswerDetailComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ McqQuestionAnswerDetailComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(McqQuestionAnswerDetailComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
