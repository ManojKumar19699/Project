import {HttpClient, HttpHeaders} from '@angular/common/http';
import {Injectable} from '@angular/core';
import { NgForm } from '@angular/forms';

@Injectable()
export class LoginService{
    url="http://localhost:64756/";
    uemail=null;
    utype=null;
    constructor(private http:HttpClient){

    }
    checkLogin(loginform:NgForm){
        const httpheader={headers:new HttpHeaders({'Content-Type':'application/json'})};
        //debugger;
        JSON.stringify(loginform.value);
        return this.http.post(this.url+"checkLogin/",JSON.stringify(loginform.value),httpheader);
    }

    getuid(){
        this.uemail=sessionStorage.getItem("email");
        this.utype=sessionStorage.getItem('user');
        return this.http.get(this.url+'api/GetId/?email='+this.uemail+"&user="+this.utype);
    }
}