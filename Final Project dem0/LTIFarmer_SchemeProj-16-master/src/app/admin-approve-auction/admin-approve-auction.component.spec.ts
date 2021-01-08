import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AdminApproveAuctionComponent } from './admin-approve-auction.component';

describe('AdminApproveAuctionComponent', () => {
  let component: AdminApproveAuctionComponent;
  let fixture: ComponentFixture<AdminApproveAuctionComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AdminApproveAuctionComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AdminApproveAuctionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
