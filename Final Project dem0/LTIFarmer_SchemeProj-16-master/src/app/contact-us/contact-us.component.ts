import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Contactus } from '../models/contactusModel';
import { ContactService } from '../services/contactService';
import { Router } from '@angular/router';
@Component({
  selector: 'app-contact-us',
  templateUrl: './contact-us.component.html',
  styleUrls: ['./contact-us.component.css']
})
export class ContactUsComponent implements OnInit {
  res:any;
  contact:Contactus;
  request:string[]=["Enquiry","Complaint"];
  constructor(private cot:ContactService) {
    this.contact={
      Email:"",
      ContactName:"",
      RequestType:"",
      Message:"",
      Status:"Not Seen",
      ApprovalAdminId:null
    }
  }

  Oncontact(contactform:NgForm){
    this.cot.sendMessage(contactform)
    .subscribe((data)=>
     {if(data==null){
      alert("Message sent successfully!");
      contactform.reset();
      }
      else{
        alert("Some error occured try again later!");
      }
    });
     

    
  }


  ngOnInit(): void {
  }

}
