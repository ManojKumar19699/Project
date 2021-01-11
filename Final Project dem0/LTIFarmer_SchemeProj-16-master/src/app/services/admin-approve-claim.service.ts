import  {HttpClient, HttpHeaders} from '@angular/common/http';
import {Injectable} from '@angular/core';
import { Observable } from 'rxjs/internal/Observable';


@Injectable()
export class AdminApproveClaimService{
    url="http://localhost:64756/api/";
    constructor(private http: HttpClient) { }
    GetUnapprovedClaims(){
        //debugger;
        return this.http.get(this.url+"GetUnapprovedClaims/");
    }

    updateClaim(eg){
        const httpHeaders = { headers:new HttpHeaders({'Content-Type': 'application/json'}) };
        eg.ApprovalStatus="Approved";
        eg.ApprovalAdminId=sessionStorage.getItem("aid");
        console.log(JSON.stringify(eg));
        //put
        return this.http.post(this.url+'ApproveClaimAdmin/?Id='+ eg.CliamId+'&adminId='+eg.ApprovalAdminId,'');
        
        
      }


      
}