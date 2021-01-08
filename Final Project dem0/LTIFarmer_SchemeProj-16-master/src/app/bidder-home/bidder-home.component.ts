import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { LoginService } from '../services/loginService';

@Component({
  selector: 'app-bidder-home',
  templateUrl: './bidder-home.component.html',
  styleUrls: ['./bidder-home.component.css']
})
export class BidderHomeComponent implements OnInit {
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
        sessionStorage.setItem('bid',this.uid);
      });
    }
  }

  gotosalehistory(){
    this.router.navigate(['SaleHistory']);
  }
  gotomarket(){
    this.router.navigate(['BidderMarketplace']);
  }
}
