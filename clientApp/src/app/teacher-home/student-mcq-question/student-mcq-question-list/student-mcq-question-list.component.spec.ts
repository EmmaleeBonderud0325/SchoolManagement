import { ComponentFixture, TestBed } from '@angular/core/testing';

import { StudentMcqQuestionListComponent } from './student-mcq-question-list.component';

describe('StudentMcqQuestionListComponent', () => {
  let component: StudentMcqQuestionListComponent;
  let fixture: ComponentFixture<StudentMcqQuestionListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ StudentMcqQuestionListComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(StudentMcqQuestionListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
