import { Component, OnInit } from '@angular/core';
import { ContactService } from '../services/contactService';
import { Router } from '@angular/router';
import { EmailReply } from '../models/emailreplyModel';
import { NgForm } from '@angular/forms';
import { MailService } from '../services/MailService';

@Component({
  selector: 'app-view-message',
  templateUrl: './view-message.component.html',
  styleUrls: ['./view-message.component.css']
})
export class ViewMessageComponent implements OnInit {
  msg:any=[];
  reply:any={};
  btndisable=false;
  mail:EmailReply;
  test:boolean=false;
  sentemail:string=null;
  adminid=sessionStorage.getItem("aid");
  constructor(private cot:ContactService,private router:Router,private mailservice:MailService) {
    this.mail={
      From:"",
      To:"",
      Subject:"",
      Body:""
    }
   }

  ngOnInit(): void {
    this.FetchMsg();
  }

  FetchMsg(){
    this.msg=this.cot.getMessage().subscribe((data)=>{this.msg=data;});
  }

  Reply(tomail:string,request:string){
    this.reply.To=tomail;
    this.reply.From=sessionStorage.getItem("email");
    this.reply.Subject="Regarding your "+request;
    this.reply.Body="";
  }
 
  SendMail(replyform:NgForm){
    console.log(replyform.value);
    this.mailservice.sendMail(replyform).subscribe((data)=>{
      console.log(data);
      if(data["Item1"]=="mail sent"){ 
        this.test=true;
        this.sentemail=data["Item2"];
        //this.mailservice.changestatus(data["Item2"]).subscribe((data)=>{console.log(data);})
        // debugger;
        //alert("Mail sent!");
        //window.location.reload();
      }
      else{
        alert("Error");
      }
      if(this.test) {
        this.mailservice.changestatus(this.sentemail).subscribe((data)=>{console.log(data);})

        console.log(this.sentemail);
      }
        alert("Mail sent!");
    })
  }
}
