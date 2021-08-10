import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ClassNameListComponent } from './class-name-list.component';

describe('ClassNameListComponent', () => {
  let component: ClassNameListComponent;
  let fixture: ComponentFixture<ClassNameListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ClassNameListComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ClassNameListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
