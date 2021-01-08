import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import {NgForm} from '@angular/forms';

@Injectable()

export class ClaimRequestService {
    constructor(private http: HttpClient){}

    claiminsurance(Claimrequest:NgForm) {

        console.log(Claimrequest.value);
        const httpheader={headers: new HttpHeaders({'Content-Type': 'application/json'})};
        return this.http.post("http://localhost:64756/api/IsuranceList",JSON.stringify(Claimrequest.value),httpheader);
    } 

    listInsurance()
    {
        //formData.append('FarmerID',sessionStorage.getItem("fid"));
        return this.http.get("http://localhost:64756/Specific/?id="+sessionStorage.getItem("fid"));
    }

}