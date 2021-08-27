import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EssayStudentAnswerListComponent } from './essay-student-answer-list.component';

describe('EssayStudentAnswerListComponent', () => {
  let component: EssayStudentAnswerListComponent;
  let fixture: ComponentFixture<EssayStudentAnswerListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ EssayStudentAnswerListComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(EssayStudentAnswerListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
