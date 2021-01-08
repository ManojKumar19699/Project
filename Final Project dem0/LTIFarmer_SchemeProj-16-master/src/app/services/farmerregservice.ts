import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import {NgForm} from '@angular/forms';


@Injectable()
export class RequestService
{
  constructor(private http: HttpClient){}

  
  postFile(FarmerName: string, FarmerEmail:string, FarmerContactNo:string,FarmerAddress:string,FarmerCity:string,FarmerState:string,
    FarmerPincocde:string,fileToUpload: File, fileToUpload1: File,FarmerPassword:string,FarmerLandArea:string,FarmerLandAddress:string, FarmerLandPincode:string,AccountNo:string
    ,IFSC_Code:string) {
    
    const endpoint = 'http://localhost:64756/Methodtwo';
    const formData: FormData = new FormData();
    formData.append('Image', fileToUpload, fileToUpload.name);
    formData.append('Image1', fileToUpload1, fileToUpload1.name);

    formData.append('FarmerName', FarmerName);
    formData.append('FarmerContactNo', FarmerContactNo);
    formData.append('FarmerAddress', FarmerAddress);
    formData.append('FarmerCity', FarmerCity);
    formData.append('FarmerState', FarmerState);
    formData.append('FarmerPincocde', FarmerPincocde);
    formData.append('FarmerEmail', FarmerEmail);
    
    formData.append('FarmerPassword', FarmerPassword);
    formData.append('FarmerLandArea', FarmerLandArea);
    formData.append('FarmerLandPincode', FarmerLandPincode);
    formData.append('AccountNo', AccountNo);
    formData.append('IFSC_Code', IFSC_Code);
    formData.append('FarmerLandAddress', FarmerLandAddress);
    
    return this.http
      .post(endpoint, formData);
  }

}