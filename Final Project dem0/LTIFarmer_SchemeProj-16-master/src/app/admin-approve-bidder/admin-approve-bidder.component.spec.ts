import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AdminApproveBidderComponent } from './admin-approve-bidder.component';

describe('AdminApproveBidderComponent', () => {
  let component: AdminApproveBidderComponent;
  let fixture: ComponentFixture<AdminApproveBidderComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AdminApproveBidderComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AdminApproveBidderComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
