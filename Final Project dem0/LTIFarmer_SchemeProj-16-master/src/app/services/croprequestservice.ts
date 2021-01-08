import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import {NgForm} from '@angular/forms';


@Injectable()
export class CropRequestService
{
  constructor(private http: HttpClient){}

  cropService(Croprequest:NgForm)
  {
     console.log(Croprequest.value);
     const httpheader={headers: new HttpHeaders({'Content-Type': 'application/json'})};
     return this.http.post("http://localhost:64756/list",JSON.stringify(Croprequest.value),httpheader);
  }

  postFile(CropType: string,CropName:string,Quantity:number,FertilizerType:string, fileToUpload: File) {
    const endpoint = 'http://localhost:64756/CropRequest';
    const formData: FormData = new FormData();
    formData.append('Image', fileToUpload, fileToUpload.name);
    formData.append('CropType', CropType);
    formData.append('CropName', CropName);
    formData.append('FertilizerType', FertilizerType);
    formData.append('Quantity', Quantity.toString());
    formData.append('FarmerID',sessionStorage.getItem("fid"));
    
    return this.http
      .post(endpoint, formData);
  }

}