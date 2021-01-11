import { HttpClient, HttpHeaders } from '@angular/common/http';
import {Injectable} from '@angular/core'; 
import {NgForm} from '@angular/forms';
@Injectable()

export class FarmerMarketService
{
    constructor(private http: HttpClient)
    {

    }

    getfarmermarket()
    {
            return this.http.get("http://localhost:64756/Farmerplace");
    }
}

// return this.http.get("http://localhost:64756/Farmerplace/?Id="+sessionStorage.getItem('auctionId'));