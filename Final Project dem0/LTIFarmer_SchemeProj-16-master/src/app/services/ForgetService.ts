import { Injectable } from '@angular/core';
import {HttpClient, HttpHeaders} from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ForgotserviceService {

  url : string = "http://localhost:64756/";

  constructor(private http : HttpClient ) { }

  sendOTP(email: string) : Observable<any>{
    const httpheader={headers:new HttpHeaders({'Content-Type':'text/html'})};
    //const httpOption = {headers:new HttpHeaders({'Content-Type':'text/html'})}
    console.log(email);
    console.log(this.url+email);
    return this.http.get<any>(this.url+"send-email?to="+email);
  }

  updateUser(email:string, password:string):Observable<any>{
    const httpheader={headers:new HttpHeaders({'Content-Type':'text/html'})};
    console.log(email);
    console.log(password);
    return this.http.put<any>(this.url+"update-password?email="+email+"&password="+password,httpheader);
  }
}