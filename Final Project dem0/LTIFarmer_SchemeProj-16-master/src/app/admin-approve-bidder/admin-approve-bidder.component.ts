import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import {AdminApproveBidderService} from '../services/admin-approve-bidder.service';
import { MailService } from '../services/MailService';

@Component({
  selector: 'app-admin-approve-bidder',
  templateUrl: './admin-approve-bidder.component.html',
  styleUrls: ['./admin-approve-bidder.component.css']
})
export class AdminApproveBidderComponent implements OnInit {

  unapprovedbidders:any=[];
  constructor(private adminapprovebiddersService:AdminApproveBidderService,private mailservice:MailService) { }

  ngOnInit(): void {
    this.fetchUnapprovedBidders();
  }

  fetchUnapprovedBidders(){
    this.unapprovedbidders=this.adminapprovebiddersService.GetUnapprovedBidders().subscribe((data)=>{this.unapprovedbidders=data;console.log(data)});
    console.log(this.unapprovedbidders);
  }

  approveBidder(Id){
    let i;
    for(i=0;i<this.unapprovedbidders.length;i++){
      if(this.unapprovedbidders[i].BidderId==Id)
      {
        console.log(this.unapprovedbidders[i].BidderId);
        break;
      } 

    }
    // console.log(this.unapprovedbidders[i]);
    this.adminapprovebiddersService.updateBidder(this.unapprovedbidders[i]).subscribe((data)=>{console.log(data)});
    // this.mailservice.ApprovalMail(this.unapprovedbidders[i].BidderEmail).subscribe((data)=>{
    //   if(data=="mail sent"){
    //     alert("Bidder Approved!");
    //     location.reload();
    //   }
    //   else{
    //     alert("Error! Try again");
    //   }
    // });  

    
    this.ngOnInit();
    //location.reload();
  }

}
