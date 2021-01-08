import { Component, OnInit } from '@angular/core';

import { NgForm, FormBuilder, FormGroup, Validators, FormControl } from '@angular/forms'; 
import {HttpClient, HttpHeaders} from '@angular/common/http';
import { Farmerdata } from '../models/Farmerdata';
import { RequestService } from '../services/farmerregservice';

@Component({
  selector: 'app-farmer-reg',
  templateUrl: './farmer-reg.component.html',
  styleUrls: ['./farmer-reg.component.css']
})
export class FarmerRegComponent implements OnInit {
  farmerdetails:Farmerdata
  imageUrl:string= "/assets/images/farmer.jpg";
  fileToUpload:File=null;

  //farmservice : RequestService;

  imageUrl1:string= "/assets/images/farmer.jpg";
  fileToUpload1:File=null;
  
  alert: boolean= false

  //farmerdetails:Farmer
  //farmerlanddetails : FarmerLand;
  //farmerbankdetails : FarmerBank;
  constructor(private http:HttpClient , private farmservice : RequestService ) {
    this.farmerdetails = {
      FarmerName: "",
      FarmerAadhar:"",
      FarmerAddress:"",
      FarmerCity:"",
      FarmerEmail:"",
      FarmerContactNo:"",
      FarmerState:"",
      FarmerCertificate:"",
      FarmerPassword:"",
      FarmerConfirmPassword:"",
      FarmerPincocde:"",

      FarmerLandAddress:"",
      FarmerLandArea:"",
      FarmerLandPincode:"",
      AccountNo:"",
      IFSC_Code:""
    }
    /*
    this.farmerlanddetails = {
      FarmerLandAddress:"",
      FarmerLandArea:"",
      FarmerLandPincode:""
    }

    this.farmerbankdetails = {
      AccountNo:"",
      IFSC_Code:""

    }*/

   }

  ngOnInit() :void{
    
  }

  handleFileInput(file: FileList) {
    this.fileToUpload=file.item(0);

    //shwing image preview 
    var reader = new FileReader();
    reader.onload=(event:any)=>{
      this.imageUrl=event.target.result;
    }
    reader.readAsDataURL(this.fileToUpload);
  }

  handleFileInput1(file: FileList) {
  this.fileToUpload1=file.item(0);

  //shwing image preview 
  var reader1 = new FileReader();
  reader1.onload=(event:any)=>{
    this.imageUrl1=event.target.result;
  }
  reader1.readAsDataURL(this.fileToUpload1);
}

OnSubmit(FarmerName,FarmerEmail,FarmerContactNo,FarmerAddress, FarmerCity
  ,FarmerState,FarmerPincocde,A,B, FarmerPassword,
  FarmerLandArea,FarmerLandAddress,FarmerLandPincode,AccountNo,IFSC_Code){


    if(FarmerName.value==null) console.log("Hello");

    if(FarmerName.value!=null,FarmerEmail.value!=null,FarmerContactNo.value!=null,FarmerAddress.value!=null, FarmerCity.value!=null
      ,FarmerState.value!=null,FarmerPincocde.value!=null,this.fileToUpload!=null,this.fileToUpload1!=null, FarmerPassword.value!=null,
      FarmerLandArea.value!=null,FarmerLandAddress.value!=null,FarmerLandPincode.value!=null,AccountNo.value!=null,IFSC_Code.value!=null){

  this.farmservice.postFile(FarmerName.value,FarmerEmail.value,FarmerContactNo.value,FarmerAddress.value, FarmerCity.value
    ,FarmerState.value,FarmerPincocde.value,this.fileToUpload,this.fileToUpload1, FarmerPassword.value,
    FarmerLandArea.value,FarmerLandAddress.value,FarmerLandPincode.value,AccountNo.value,IFSC_Code.value,
    ).subscribe(
    data =>{
      console.log(data);
      // alert("Data Added Successfully");
      // console.log('done');
      if(data=="Email") alert("This email is already registered with us");
      else if(data=="Account") alert("This bank account is already registered with us");
      else if(data=="Error") alert("Error in details.Please fill the details again");
      if(data=="OK"){
        alert("Data Added Successfully");
        console.log(data);
      
      this.imageUrl = "/assets/images/farmer.jpg";
      this.imageUrl1 = "/assets/images/farmer.jpg";
      }
      
      
    }
  );
      }
      else alert("Please fill the required details");
 }

}
