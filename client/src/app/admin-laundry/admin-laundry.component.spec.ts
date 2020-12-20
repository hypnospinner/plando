import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AdminLaundryComponent } from './admin-laundry.component';

describe('AdminLaundryComponent', () => {
  let component: AdminLaundryComponent;
  let fixture: ComponentFixture<AdminLaundryComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AdminLaundryComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AdminLaundryComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
