import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import {AdminApproveAuctionService} from '../services/admin-approve-auction.service';

@Component({
  selector: 'app-admin-approve-auction',
  templateUrl: './admin-approve-auction.component.html',
  styleUrls: ['./admin-approve-auction.component.css']
})
export class AdminApproveAuctionComponent implements OnInit {

  unapprovedbids:any=[];
  constructor(private adminapproveauctionservice:AdminApproveAuctionService,private router: Router) { }

  ngOnInit(): void {
    this.fetchUnapprovedBids();
  }

  fetchUnapprovedBids(){
    this.unapprovedbids=this.adminapproveauctionservice.GetUnapprovedBids().subscribe((data)=>{this.unapprovedbids=data;console.log(data)});
    console.log(this.unapprovedbids);
  }

  approveauction(id){
    let i;
    for(i=0;i<this.unapprovedbids.length;i++){
      if(this.unapprovedbids[i].Biddingid==id) break;
    }
    console.log(this.unapprovedbids[i]);
    //this.adminapproveclaimservice.updateClaim(this.unapprovedclaims[i]);
    //this.router.navigate(['ApproveClaim']);
    this.adminapproveauctionservice.finaliseBid(this.unapprovedbids[i]).subscribe((data)=>{console.log(data);
    if(data=="OK") alert("Auction Approved");
    location.reload();
    });
  }


}
