import { ComponentFixture, TestBed } from '@angular/core/testing';

import { McqQuestionAnswerListComponent } from './mcq-question-answer-list.component';

describe('McqQuestionAnswerListComponent', () => {
  let component: McqQuestionAnswerListComponent;
  let fixture: ComponentFixture<McqQuestionAnswerListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ McqQuestionAnswerListComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(McqQuestionAnswerListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
