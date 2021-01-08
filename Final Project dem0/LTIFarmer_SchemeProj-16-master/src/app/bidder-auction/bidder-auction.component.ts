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
      if(this.currentcrop.CropName=="Rice") this.imagetodisplay="https://external-content.duckduckgo.com/iu/?u=https%3A%2F%2Ftse4.mm.bing.net%2Fth%3Fid%3DOIP.yEHGAXlXb5cEtpN_r6teaAHaE8%26pid%3DApi&f=1";
      else if(this.currentcrop.CropName =="Cotton") this.imagetodisplay="https://external-content.duckduckgo.com/iu/?u=https%3A%2F%2Ftse1.mm.bing.net%2Fth%3Fid%3DOIP.vF-kIlVf1ekJ2e6ZxpByjQHaE6%26pid%3DApi&f=1";
      else if(this.currentcrop.CropName =="GroundNut") this.imagetodisplay="https://external-content.duckduckgo.com/iu/?u=https%3A%2F%2Ftse4.mm.bing.net%2Fth%3Fid%3DOIP.q1Vd-fG4MwH8i2jhhZoFjgHaE8%26pid%3DApi&f=1";
      else if(this.currentcrop.CropName =="SoyaBean") this.imagetodisplay="https://external-content.duckduckgo.com/iu/?u=https%3A%2F%2Ftse1.mm.bing.net%2Fth%3Fid%3DOIP.yxnDXSmKInso8gSqe-rm8AHaI8%26pid%3DApi&f=1";
      else if(this.currentcrop.CropName =="Wheat") this.imagetodisplay="https://external-content.duckduckgo.com/iu/?u=https%3A%2F%2Ftse2.mm.bing.net%2Fth%3Fid%3DOIP.Ym22T14TuJpD3DFQgHKjwgHaFL%26pid%3DApi&f=1";
      else if(this.currentcrop.CropName =="Barley") this.imagetodisplay="https://external-content.duckduckgo.com/iu/?u=https%3A%2F%2Ftse1.mm.bing.net%2Fth%3Fid%3DOIP.obUGrjcf7QllQ-kwgzdFsQHaEK%26pid%3DApi&f=1";
      else if(this.currentcrop.CropName =="Ginger") this.imagetodisplay="https://external-content.duckduckgo.com/iu/?u=https%3A%2F%2Ftse3.mm.bing.net%2Fth%3Fid%3DOIP.m-A98TZy1eoZouIbr0Hd2wHaET%26pid%3DApi&f=1";
      else if(this.currentcrop.CropName =="Pea") this.imagetodisplay="https://external-content.duckduckgo.com/iu/?u=https%3A%2F%2Ftse1.mm.bing.net%2Fth%3Fid%3DOIP.4lay8v6Gu1DUOVgIZoY6cwHaGg%26pid%3DApi&f=1";
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
