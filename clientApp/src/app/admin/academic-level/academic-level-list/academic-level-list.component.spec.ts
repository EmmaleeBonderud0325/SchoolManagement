import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AcademicLevelListComponent } from './academic-level-list.component';

describe('AcademicLevelListComponent', () => {
  let component: AcademicLevelListComponent;
  let fixture: ComponentFixture<AcademicLevelListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AcademicLevelListComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AcademicLevelListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
