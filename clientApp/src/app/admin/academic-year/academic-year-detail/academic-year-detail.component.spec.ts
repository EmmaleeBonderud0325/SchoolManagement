import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AcademicYearDetailComponent } from './academic-year-detail.component';

describe('AcademicYearDetailComponent', () => {
  let component: AcademicYearDetailComponent;
  let fixture: ComponentFixture<AcademicYearDetailComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AcademicYearDetailComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AcademicYearDetailComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
