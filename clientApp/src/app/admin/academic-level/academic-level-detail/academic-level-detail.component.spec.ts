import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AcademicLevelDetailComponent } from './academic-level-detail.component';

describe('AcademicLevelDetailComponent', () => {
  let component: AcademicLevelDetailComponent;
  let fixture: ComponentFixture<AcademicLevelDetailComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AcademicLevelDetailComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AcademicLevelDetailComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
