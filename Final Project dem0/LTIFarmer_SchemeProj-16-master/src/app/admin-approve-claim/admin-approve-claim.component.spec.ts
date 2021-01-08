import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AdminApproveClaimComponent } from './admin-approve-claim.component';

describe('AdminApproveClaimComponent', () => {
  let component: AdminApproveClaimComponent;
  let fixture: ComponentFixture<AdminApproveClaimComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AdminApproveClaimComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AdminApproveClaimComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
