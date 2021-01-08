import { Component, OnInit } from '@angular/core';
import { SaleHistoryService } from '../services/salehistoryService';

@Component({
  selector: 'app-sale-history',
  templateUrl: './sale-history.component.html',
  styleUrls: ['./sale-history.component.css']
})
export class SaleHistoryComponent implements OnInit {
  sale:any=[];
  user=sessionStorage.getItem("user");

  constructor(private saleservice:SaleHistoryService) { }

  ngOnInit(): void {
    if(this.user=="farmer"){
      this.getSaleHistory(sessionStorage.getItem("fid"));
    }
    else if(this.user=="bidder"){
      this.getSaleHistory(sessionStorage.getItem("bid"));
    }
    
  }

  getSaleHistory(id:string){
    this.saleservice.getHistory(id).subscribe((data)=>{
    this.sale=data;})
  }
}
