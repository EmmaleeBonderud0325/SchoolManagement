import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ReportGenarateComponent } from './report-genarate.component';

describe('ReportGenarateComponent', () => {
  let component: ReportGenarateComponent;
  let fixture: ComponentFixture<ReportGenarateComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ReportGenarateComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ReportGenarateComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
