import { ComponentFixture, TestBed } from '@angular/core/testing';

import { LessonAssignmentSubmissionListComponent } from './lesson-assignment-submission-list.component';

describe('LessonAssignmentSubmissionListComponent', () => {
  let component: LessonAssignmentSubmissionListComponent;
  let fixture: ComponentFixture<LessonAssignmentSubmissionListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ LessonAssignmentSubmissionListComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(LessonAssignmentSubmissionListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
