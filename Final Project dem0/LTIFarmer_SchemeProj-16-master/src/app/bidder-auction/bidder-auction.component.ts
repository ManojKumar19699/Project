import { Component, OnInit } from '@angular/core';
import {BidderMarketPlaceService} from '../services/bidder-marketplace.service';
import { AuctionBid } from '../models/auctionbid.model';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-bidder-auction',
  templateUrl: './bidder-auction.component.html',
  styleUrls: ['./bidder-auction.component.css']
})
export class BidderAuctionComponent implements OnInit {


  imagetodisplay=null;

 auctionprice:AuctionBid;
  //currentcrops:any=[];
  currentcrop:any=[];
  constructor(private biddermarketplaceservice:BidderMarketPlaceService) { 
    this.auctionprice={
      BidPrice:0
    }
  }



  ngOnInit(): void {
    //debugger;
    this.fetchauctiondetails();
  }
  fetchauctiondetails(){
    //debugger;

    this.currentcrop=this.biddermarketplaceservice.getCurrentCropById().subscribe((data)=>{
      this.currentcrop=data;console.log(data);
      console.log(this.currentcrop);
    });
  }

  DataForm:any=[];

  onSubmit(formdata:NgForm){
    this.DataForm=formdata.value;
    console.log(formdata.value);
    if(this.DataForm.BidPrice<=this.currentcrop.CurrentBidPrice){
      alert("Value less than or equal to the current bid price");
    }
    else{
      this.biddermarketplaceservice.PlaceBid(this.DataForm.BidPrice).subscribe((data)=>{console.log(data);
      if(data=="OK") alert("Bid Successfully Placed");
      location.reload();
      });
    }
   // formdata.BidPrice
  }

}
