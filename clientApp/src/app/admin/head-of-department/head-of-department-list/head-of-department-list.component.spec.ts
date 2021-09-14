import { ComponentFixture, TestBed } from '@angular/core/testing';

import { HeadOfDepartmentListComponent } from './head-of-department-list.component';

describe('HeadOfDepartmentListComponent', () => {
  let component: HeadOfDepartmentListComponent;
  let fixture: ComponentFixture<HeadOfDepartmentListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ HeadOfDepartmentListComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(HeadOfDepartmentListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
