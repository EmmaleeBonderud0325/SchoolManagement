import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ClassTeacherDetailComponent } from './class-teacher-detail.component';

describe('ClassTeacherDetailComponent', () => {
  let component: ClassTeacherDetailComponent;
  let fixture: ComponentFixture<ClassTeacherDetailComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ClassTeacherDetailComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ClassTeacherDetailComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
