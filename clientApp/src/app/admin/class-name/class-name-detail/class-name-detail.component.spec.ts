import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ClassNameDetailComponent } from './class-name-detail.component';

describe('ClassNameDetailComponent', () => {
  let component: ClassNameDetailComponent;
  let fixture: ComponentFixture<ClassNameDetailComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ClassNameDetailComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ClassNameDetailComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
