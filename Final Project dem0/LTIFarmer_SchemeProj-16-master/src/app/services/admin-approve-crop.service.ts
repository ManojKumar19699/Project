import  {HttpClient, HttpHeaders} from '@angular/common/http';
import {Injectable} from '@angular/core';
import { Observable } from 'rxjs/internal/Observable';
//import {BidderApproval} from '../models/bidderapproval.model';

@Injectable()
export class AdminApproveCropService{
    url="http://localhost:64756/api/";
    constructor(private http: HttpClient) { }
    GetUnapprovedCrops(){
        //debugger;
        console.log(new Date().toISOString())
        return this.http.get(this.url+'GetUnapprovedCrops/');
    }

    RiceMSP:number=1868;
    UraddalMSP:number=6000;
    SoyaBeanMSP:number=3880;
    GroundnutMSP:number=5275;
    CottonMSP:number=5515;


    updateCrop(eg){
        const httpHeaders = { headers:new HttpHeaders({'Content-Type': 'application/json'}) };
        eg.CropApproved=true;
        eg.ApprovalAdminId=sessionStorage.getItem("aid");
        eg.InitialPrice=2000*eg.Quantity;
        if(eg.CropName=="Rice") eg.InitialPrice=this.RiceMSP*eg.Quantity;
        else if(eg.CropName=="Dal") eg.InitialPrice=this.UraddalMSP*eg.Quantity;
        else if(eg.CropName=="SoyaBean") eg.InitialPrice=this.SoyaBeanMSP*eg.Quantity;
        else if(eg.CropName=="GroundNut") eg.InitialPrice=this.GroundnutMSP*eg.Quantity;
        else if(eg.CropName=="Cotton") eg.InitialPrice=this.CottonMSP*eg.Quantity;
        else if(eg.CropName=="test") eg.InitialPrice=1111*eg.Quantity*eg.Quantity;

        //eg.date=new Date().toISOString();
        console.log(JSON.stringify(eg));
        //put
        return this.http.post(this.url+'ApproveCropAdmin/?Id='+ eg.RequestId+'&adminId='+eg.ApprovalAdminId+'&initprice='+eg.InitialPrice,'');        
      }
}