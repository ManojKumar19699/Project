import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CroprequestComponent } from './croprequest.component';

describe('CroprequestComponent', () => {
  let component: CroprequestComponent;
  let fixture: ComponentFixture<CroprequestComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CroprequestComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CroprequestComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
