import { ComponentFixture, TestBed } from '@angular/core/testing';

import { HeadOfDepartmentDetailComponent } from './head-of-department-detail.component';

describe('HeadOfDepartmentDetailComponent', () => {
  let component: HeadOfDepartmentDetailComponent;
  let fixture: ComponentFixture<HeadOfDepartmentDetailComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ HeadOfDepartmentDetailComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(HeadOfDepartmentDetailComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
