import { Component } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Login } from './models/loginModel';
import { Router } from '@angular/router';
import { LoginService } from './services/loginService';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'] 
})
export class AppComponent {
  title = 'AgriFarm';
  loginsessionuser=false;
  usertype=null;
  username=null;

  constructor(private router:Router) { 
  }

  ngDoCheck(){
    this.username=sessionStorage.getItem("email");
    if(this.username!=null){
      this.loginsessionuser=true;
      this.usertype=sessionStorage.getItem("user");
    }
    else{
      this.loginsessionuser=false;
      this.usertype=null;
    }
  }

  logout(){
    sessionStorage.clear();
    this.loginsessionuser=false;
    this.router.navigate(['Home']);
  }
  
  ngOnInit(){
    this.username=sessionStorage.getItem("email");
    if(this.username!=null){
      this.usertype=sessionStorage.getItem("user");
      if(this.usertype=="admin") this.router.navigate(['AdminHome']);
      else if(this.usertype=="farmer") this.router.navigate(['FarmerHome']);
      else this.router.navigate(['BidderHome']);
    }
    else this.router.navigate(['Home']);
  }
  
}
