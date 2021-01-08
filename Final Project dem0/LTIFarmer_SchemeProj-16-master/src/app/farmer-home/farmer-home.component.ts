import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { LoginService } from '../services/loginService';

@Component({
  selector: 'app-farmer-home',
  templateUrl: './farmer-home.component.html',
  styleUrls: ['./farmer-home.component.css']
})
export class FarmerHomeComponent implements OnInit {
  username=null;
  userdetails:any=[];
  uid=null;
  constructor(private log:LoginService,private router:Router) { }

  ngOnInit(): void {
    this.username=sessionStorage.getItem("email");
    if(this.username!=null){
      this.userdetails=this.log.getuid().subscribe((data)=>{
        console.log(data);
        this.uid=data;
        sessionStorage.setItem('fid',this.uid);
      });
    }
  }

  gotosalehistory(){
    this.router.navigate(['SaleHistory']);
  }

  GotoInsuranceApply(){
    this.router.navigate(['InsuranceApply'])
  }
  
  gotoCropRequest(){
      this.router.navigate(['ListCrop'])
  }

  gotoFarmerMaret(){
      this.router.navigate(['MarketFarmer'])
  }

  GotoClaimInsurance(){
      this.router.navigate(['InsuranceClaim']);
  }


}
