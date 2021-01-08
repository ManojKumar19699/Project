import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FarmermarketComponent } from './farmermarket.component';

describe('FarmermarketComponent', () => {
  let component: FarmermarketComponent;
  let fixture: ComponentFixture<FarmermarketComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ FarmermarketComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(FarmermarketComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
