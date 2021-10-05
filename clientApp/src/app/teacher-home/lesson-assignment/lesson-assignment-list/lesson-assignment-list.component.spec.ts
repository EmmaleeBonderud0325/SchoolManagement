import { ComponentFixture, TestBed } from '@angular/core/testing';

import { LessonAssignmentListComponent } from './lesson-assignment-list.component';

describe('LessonAssignmentListComponent', () => {
  let component: LessonAssignmentListComponent;
  let fixture: ComponentFixture<LessonAssignmentListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ LessonAssignmentListComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(LessonAssignmentListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
