import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import {NgForm} from '@angular/forms';


@Injectable()
export class BidderService
{
  constructor(private http: HttpClient){}

  postFile(BidderName: string, BidderEmail:string, BidderContactNo:string,BidderAddress:string,BidderCity:string,BidderState:string,
    BidderPincocde:string,fileToUpload: File, fileToUpload1: File,BidderPassword:string,AccountNo:string,IFSC_Code:string) {
    
    const endpoint = 'http://localhost:64756/RegBidder';
    const formData: FormData = new FormData();
    formData.append('Image', fileToUpload, fileToUpload.name);
    formData.append('Image1', fileToUpload1, fileToUpload1.name);

    formData.append('BidderName', BidderName);
    formData.append('BidderEmail', BidderEmail);
    formData.append('BidderContactNo', BidderContactNo);
    formData.append('BidderAddress', BidderAddress);
    formData.append('BidderCity', BidderCity);
    formData.append('BidderState', BidderState);
    formData.append('BidderPincocde', BidderPincocde);
    
    formData.append('BidderPassword', BidderPassword);
    formData.append('AccountNo', AccountNo);
    formData.append('IFSC_Code', IFSC_Code);
    
    return this.http
      .post(endpoint, formData);
  }

}