import {HttpClient, HttpHeaders} from '@angular/common/http';
import {Injectable} from '@angular/core';
import { NgForm } from '@angular/forms';

@Injectable()
export class SaleHistoryService{
    url="http://localhost:64756/api/salehistory/";
    user=sessionStorage.getItem("user");
    constructor(private http:HttpClient){

    }

    getHistory(Id:string){
        return this.http.get(this.url+"?Id="+Id+"&usertype="+sessionStorage.getItem("user"));
    }
}