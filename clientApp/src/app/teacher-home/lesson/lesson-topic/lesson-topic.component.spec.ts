import { ComponentFixture, TestBed } from '@angular/core/testing';

import { LessonTopicComponent } from './lesson-topic.component';

describe('LessonTopicComponent', () => {
  let component: LessonTopicComponent;
  let fixture: ComponentFixture<LessonTopicComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ LessonTopicComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(LessonTopicComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
