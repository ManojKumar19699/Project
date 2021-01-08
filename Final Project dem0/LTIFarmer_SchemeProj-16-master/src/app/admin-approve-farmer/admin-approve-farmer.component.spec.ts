import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AdminApproveFarmerComponent } from './admin-approve-farmer.component';

describe('AdminApproveFarmerComponent', () => {
  let component: AdminApproveFarmerComponent;
  let fixture: ComponentFixture<AdminApproveFarmerComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AdminApproveFarmerComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AdminApproveFarmerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
