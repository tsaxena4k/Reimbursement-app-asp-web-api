import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MonthWiseChartsComponent } from './month-wise-charts.component';

describe('MonthWiseChartsComponent', () => {
  let component: MonthWiseChartsComponent;
  let fixture: ComponentFixture<MonthWiseChartsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ MonthWiseChartsComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(MonthWiseChartsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
