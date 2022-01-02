import { ComponentFixture, TestBed } from '@angular/core/testing';

import { StudentMcqQuestionDetailsComponent } from './student-mcq-question-details.component';

describe('StudentMcqQuestionDetailsComponent', () => {
  let component: StudentMcqQuestionDetailsComponent;
  let fixture: ComponentFixture<StudentMcqQuestionDetailsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ StudentMcqQuestionDetailsComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(StudentMcqQuestionDetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
