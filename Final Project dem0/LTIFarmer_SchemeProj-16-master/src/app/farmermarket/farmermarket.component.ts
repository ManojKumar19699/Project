import { Component, OnInit } from '@angular/core';
import {NgForm} from '@angular/forms';
import {FarmerMarketPlaceModel} from '../models/farmermarketmodel'
import {FarmerMarketService} from '../services/farmermarketservice';

@Component({
  selector: 'app-farmermarket',
  templateUrl: './farmermarket.component.html',
  styleUrls: ['./farmermarket.component.css']
})
export class FarmermarketComponent implements OnInit {

  farmermarketdetails:any=[];
  constructor(private frmkt: FarmerMarketService) { }

  ngOnInit(): void {
    this.fetchDetails();
  }
  fetchDetails()
  {
    this.farmermarketdetails=this.frmkt.getfarmermarket().subscribe((data)=>
    {this.farmermarketdetails=data; console.log(data);});
    console.log(this.farmermarketdetails);
  }

}
