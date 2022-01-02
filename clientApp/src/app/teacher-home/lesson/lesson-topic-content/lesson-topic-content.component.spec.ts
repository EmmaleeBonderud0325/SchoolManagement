import { ComponentFixture, TestBed } from '@angular/core/testing';

import { LessonTopicContentComponent } from './lesson-topic-content.component';

describe('LessonTopicContentComponent', () => {
  let component: LessonTopicContentComponent;
  let fixture: ComponentFixture<LessonTopicContentComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ LessonTopicContentComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(LessonTopicContentComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
