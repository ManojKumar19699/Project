import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import {AdminApproveFarmerService} from '../services/admin-approve-farmer.service';
import { MailService } from '../services/MailService';

@Component({
  selector: 'app-admin-approve-farmer',
  templateUrl: './admin-approve-farmer.component.html',
  styleUrls: ['./admin-approve-farmer.component.css']
})
export class AdminApproveFarmerComponent implements OnInit {

  unapprovedfarmers:any=[];
  constructor(private adminapprovefarmerservice: AdminApproveFarmerService,private router: Router
    ,private mailservice:MailService) { }

  ngOnInit(): void {
    this.fetchUnapprovedFarmers();
  }

  fetchUnapprovedFarmers(){
    this.unapprovedfarmers=this.adminapprovefarmerservice.GetUnapprovedFarmers().subscribe((data)=>{this.unapprovedfarmers=data;console.log(data)});
    console.log(this.unapprovedfarmers);
  }
  approveFarmer(Id){
    let i;
    for(i=0;i<this.unapprovedfarmers.length;i++){
      if(this.unapprovedfarmers[i].FarmerId==Id) break;
    }
    console.log(this.unapprovedfarmers[i]);
    this.adminapprovefarmerservice.updateFarmer(this.unapprovedfarmers[i]).subscribe((data)=>{console.log(data)});
    location.reload();
    // this.mailservice.ApprovalMail(this.unapprovedfarmers[i].FarmerEmail).subscribe((data)=>{
    //   if(data=="mail sent"){
    //     alert("Farmer Approved!");
    //     location.reload();
    //   }
    //   else{
    //     alert("Error! Try again");
    //   }
    // });
  
    
    //this.router.navigate(['ApproveFarmer']);
  }


  




}
