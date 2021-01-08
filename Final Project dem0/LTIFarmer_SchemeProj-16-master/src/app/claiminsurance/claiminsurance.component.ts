import { Component, OnInit } from '@angular/core';
import { NgForm,FormBuilder,FormControl,FormGroup,Validators } from '@angular/forms';
import {InsuranceClaim} from '../models/claimrequestmodel';
import {HttpClient,HttpHeaders} from '@angular/common/http';
import { ClaimRequestService } from '../services/claimrequestservice';

@Component({
  selector: 'app-claiminsurance',
  templateUrl: './claiminsurance.component.html',
  styleUrls: ['./claiminsurance.component.css']
})
export class ClaiminsuranceComponent implements OnInit {
  response: any;
  listinsurance: any=[];
  
  constructor(private inservice:ClaimRequestService) 
  {
   }

  insclaim :InsuranceClaim=
  {
     AmountClaimed:0,
     DateOfClaim:null,
     DateOfLoss:null,
     CauseOfClaim:null,
     PolicyNo:null,
  };
  ldate =new Date(this.insclaim.DateOfLoss);
  submitted =false;
  currentdate = new Date();
  ngOnInit(): void {
    this.showinsurance();
  }

showinsurance()
{
  this.listinsurance=this.inservice.listInsurance().subscribe((data)=>
  {this.listinsurance=data; console.log(data);});
  console.log(this.listinsurance);
  
}

claimRequest(container :NgForm)
  {
    console.log(this.insclaim);
    if(this.insclaim.DateOfClaim<this.insclaim.DateOfLoss || this.ldate>this.currentdate){
      alert("Invalid dates ");
      alert(" Date of Loss Must be less than Date of Claim");
      container.reset();
      
  }else{
    this.response=this.inservice.claiminsurance(container)
    .subscribe((data)=>{console.log(data);});
    container.reset();
    alert("Claim Request Send");
    location.reload();
  }
  }  
}
