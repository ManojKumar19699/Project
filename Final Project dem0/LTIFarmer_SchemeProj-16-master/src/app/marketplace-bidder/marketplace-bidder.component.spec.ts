import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MarketplaceBidderComponent } from './marketplace-bidder.component';

describe('MarketplaceBidderComponent', () => {
  let component: MarketplaceBidderComponent;
  let fixture: ComponentFixture<MarketplaceBidderComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ MarketplaceBidderComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(MarketplaceBidderComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
