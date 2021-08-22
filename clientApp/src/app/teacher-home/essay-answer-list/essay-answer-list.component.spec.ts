import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EssayAnswerListComponent } from './essay-answer-list.component';

describe('EssayAnswerListComponent', () => {
  let component: EssayAnswerListComponent;
  let fixture: ComponentFixture<EssayAnswerListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ EssayAnswerListComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(EssayAnswerListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
