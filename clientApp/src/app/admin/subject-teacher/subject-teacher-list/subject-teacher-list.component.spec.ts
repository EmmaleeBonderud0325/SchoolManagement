import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SubjectTeacherListComponent } from './subject-teacher-list.component';

describe('SubjectTeacherListComponent', () => {
  let component: SubjectTeacherListComponent;
  let fixture: ComponentFixture<SubjectTeacherListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SubjectTeacherListComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(SubjectTeacherListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
