import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import {BidderMarketPlaceService} from '../services/bidder-marketplace.service';


@Component({
  selector: 'app-marketplace-bidder',
  templateUrl: './marketplace-bidder.component.html',
  styleUrls: ['./marketplace-bidder.component.css']
})
export class MarketplaceBidderComponent implements OnInit {

  currentbids:any=[];
  AppAdId:null;
  
  constructor(private biddermarketplaceservice:BidderMarketPlaceService,private router: Router) { }

  ngOnInit(): void {
    this.fetchCurrentBids();
    // this.fetchAllCrops();
  }

  fetchCurrentBids(){
    this.currentbids=this.biddermarketplaceservice.GetCurrentSales().subscribe((data)=>{this.currentbids=data;console.log(data)});
    console.log(this.currentbids[0]);
  }

  gotoauction(bidId){
    let i;
    for(i=0;i<this.currentbids.length;i++){
      if(this.currentbids[i].BiddingId==bidId) break;
    }
      sessionStorage.setItem('auctionId',this.currentbids[i].BiddingId);
      console.log(this.currentbids[i]);
      console.log(sessionStorage.getItem("auctionId"));
      this.router.navigate(['AuctionPage'])

    }
 
  }



  // fetchAllCrops(){
  //   this.allcrops=this.biddermarketplaceservice.GetAllCrops().subscribe((data)=>{this.allcrops=data;console.log(data)});
  //   console.log(this.allcrops);
  // }


