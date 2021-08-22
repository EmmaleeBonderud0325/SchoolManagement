import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EssayAnswerDetailComponent } from './essay-answer-detail.component';

describe('EssayAnswerDetailComponent', () => {
  let component: EssayAnswerDetailComponent;
  let fixture: ComponentFixture<EssayAnswerDetailComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ EssayAnswerDetailComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(EssayAnswerDetailComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
