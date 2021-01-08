import {HttpClient, HttpHeaders} from '@angular/common/http';
import {Injectable} from '@angular/core';
import { NgForm } from '@angular/forms';

@Injectable()
export class ContactService{
    url="https://localhost:61737/api/contactus/";
    constructor(private http:HttpClient){

    }
    sendMessage(contactform:NgForm){
        console.log(contactform.value);
        const httpheader={headers:new HttpHeaders({'Content-Type':'application/json'})};
        return this.http.post(this.url,JSON.stringify(contactform.value),httpheader);
    }

    getMessage(){
        return this.http.get(this.url);
    }
}