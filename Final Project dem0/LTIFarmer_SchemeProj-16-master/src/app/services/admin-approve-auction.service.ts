import  {HttpClient, HttpHeaders} from '@angular/common/http';
import {Injectable} from '@angular/core';
import { Observable } from 'rxjs/internal/Observable';

@Injectable()
export class AdminApproveAuctionService{
    url="http://localhost:64756/api/";
    constructor(private http: HttpClient) { }
    GetUnapprovedBids(){
        //debugger;
        return this.http.get(this.url+"GetUnapprovedBids/");
    }

    finaliseBid(eg){
        console.log(eg);
        return this.http.post(this.url+"ApproveAuctionAdmin/?Id="+ eg.Biddingid+"&adminId="+sessionStorage.getItem("aid"),"");
    }

    // updateBidder(eg){
    //     const httpHeaders = { headers:new HttpHeaders({'Content-Type': 'application/json'}) };
    //     eg.BidderApproved=true;
    //     eg.ApprovalAdminId=sessionStorage.getItem("aid");
    //     console.log(JSON.stringify(eg));
    //     //put
    //     return this.http.post(this.url+"ApproveBidderAdmin/?id="+ eg.Bidderid+"&adminid="+eg.ApprovalAdminId,"");        
    //   }
}