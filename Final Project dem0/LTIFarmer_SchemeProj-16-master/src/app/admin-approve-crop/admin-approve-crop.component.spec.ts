import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AdminApproveCropComponent } from './admin-approve-crop.component';

describe('AdminApproveCropComponent', () => {
  let component: AdminApproveCropComponent;
  let fixture: ComponentFixture<AdminApproveCropComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AdminApproveCropComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AdminApproveCropComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
