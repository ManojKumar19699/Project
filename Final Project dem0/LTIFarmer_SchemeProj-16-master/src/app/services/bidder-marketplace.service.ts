import  {HttpClient, HttpHeaders} from '@angular/common/http';
import {Injectable} from '@angular/core';
import {NgForm} from '@angular/forms';
// import { Observable } from 'rxjs/internal/Observable';
import {FarmerApproval} from '../models/cropbidding.model';

@Injectable()
export class BidderMarketPlaceService{
    constructor(private http: HttpClient) { }

    GetCurrentSales(){
        
        return this.http.get('http://localhost:64756/api/GetCurrentSales/')
    }
 

    getCurrentCropById(){
        
        return this.http.get('http://localhost:64756/api/GetCropById/?Id='+sessionStorage.getItem('auctionId'));
    }

    PlaceBid(latestbid){
        return this.http.post('http://localhost:64756/api/PlaceBid/?Id='+sessionStorage.getItem('auctionId')+"&bidderID="+sessionStorage.getItem('bid')+'&latestbid='+latestbid,'');
    }

}