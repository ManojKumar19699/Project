import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-registration-dashboard',
  templateUrl: './registration-dashboard.component.html',
  styleUrls: ['./registration-dashboard.component.css']
})
export class RegistrationDashboardComponent implements OnInit {

  constructor(private router: Router) { }

  gotoFarmer(){
    this.router.navigate(['FarmerRegistration'])
  }

  gotoBidder(){
    this.router.navigate(['BidderRegistration'])
  }

  gotoLogin(){
    this.router.navigate(['Login']);
  }
  ngOnInit(): void {
  }

}
