import {HttpClient, HttpHeaders} from '@angular/common/http';
import {Injectable} from '@angular/core';
import { NgForm } from '@angular/forms';

@Injectable()
export class ContactService{
    url="http://localhost:64756/contact/";
    url1="http://localhost:64756/contactget/";
    constructor(private http:HttpClient){

    }
    sendMessage(contactform:NgForm){
        console.log(contactform.value);
        const httpheader={headers:new HttpHeaders({'Content-Type':'application/json'})};
        return this.http.post(this.url,JSON.stringify(contactform.value),httpheader);
    }

    getMessage(){
        return this.http.get(this.url1);
    }
}