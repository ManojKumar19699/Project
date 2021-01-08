import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { LoginService } from '../services/loginService';

@Component({
  selector: 'app-admin-home',
  templateUrl: './admin-home.component.html',
  styleUrls: ['./admin-home.component.css'] 
})
export class AdminHomeComponent implements OnInit {
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
        sessionStorage.setItem('aid',this.uid);
      });
    }
  }

  gotomsg(){
    this.router.navigate(['ViewMessage']);
  }
  gotoaprrovefarmer(){
    this.router.navigate(['ApproveFarmer']);
  }
  gotoaprrovebidder(){
    this.router.navigate(['ApproveBidder']);
  }
  gotoaprrovecrop(){
    this.router.navigate(['ApproveCrop']);
  }
  gotoaprroveclaim(){
    this.router.navigate(['ApproveClaim']);
  }
  gotoaprroveauction(){
    this.router.navigate(['ApproveAuction']);
  }
}
