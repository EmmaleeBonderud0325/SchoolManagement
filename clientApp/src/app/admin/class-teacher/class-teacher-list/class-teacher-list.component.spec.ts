import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ClassTeacherListComponent } from './class-teacher-list.component';

describe('ClassTeacherListComponent', () => {
  let component: ClassTeacherListComponent;
  let fixture: ComponentFixture<ClassTeacherListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ClassTeacherListComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ClassTeacherListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
