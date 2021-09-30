import { ComponentFixture, TestBed } from '@angular/core/testing';

import { LessonContainerComponent } from './lesson-container.component';

describe('LessonContainerComponent', () => {
  let component: LessonContainerComponent;
  let fixture: ComponentFixture<LessonContainerComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ LessonContainerComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(LessonContainerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
