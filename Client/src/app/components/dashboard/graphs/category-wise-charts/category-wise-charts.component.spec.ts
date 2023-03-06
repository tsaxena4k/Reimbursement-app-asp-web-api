import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CategoryWiseChartsComponent } from './category-wise-charts.component';

describe('CategoryWiseChartsComponent', () => {
  let component: CategoryWiseChartsComponent;
  let fixture: ComponentFixture<CategoryWiseChartsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CategoryWiseChartsComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CategoryWiseChartsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
