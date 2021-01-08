import { Component, OnInit } from '@angular/core';
import { InsuranceApp } from '../models/insurance';
import { NgForm, FormBuilder, FormGroup, Validators, FormControl } from '@angular/forms'; 
import {HttpClient, HttpHeaders} from '@angular/common/http';
import { ConvertActionBindingResult } from '@angular/compiler/src/compiler_util/expression_converter';



@Component({
  selector: 'app-insurance-application',
  templateUrl: './insurance-application.component.html',
  styleUrls: ['./insurance-application.component.css']
})
export class InsuranceApplicationComponent implements OnInit {
insurancedetails: InsuranceApp

isVisible:boolean=false;
  constructor(private http:HttpClient) { 
    this.insurancedetails={
      Farmerid:"0",
      CropName:"",
      Season:"",
      CompanyName:"",
      Year:"",
      SumAssured:0,
      SumAssuredPerHec:0,
      Premium:0,
     // DateOfInsurance:"2012-04-20",
      Area:0
    }
  }

  DataForm:any=[];
  DetailsOfInsurance: InsuranceApp[]=[];
  onSubmit(formdata:NgForm){
    this.DataForm=formdata.value;
    console.log(this.DataForm);
    if(this.DataForm.CropName!=null && this.DataForm.Area!=0 && this.DataForm.Year!=null && this.DataForm.Season!=null){
    this.isVisible=true;
    
    console.log(this.DataForm);
    if( this.DataForm.CropName=="Rice"){
      console.log(this.DataForm.Crop);
      this.DetailsOfInsurance.push(
        {
          Farmerid:sessionStorage.getItem("fid"),
          CompanyName:"Reliance Inc",
          SumAssuredPerHec:84015,
          Premium:8401*this.DataForm.Area,
          SumAssured:84015*this.DataForm.Area,
          CropName:this.DataForm.CropName,
          Area:this.DataForm.Area,
          Year:this.DataForm.Year,
          Season:this.DataForm.Season
        }
      );

      console.log(this.DetailsOfInsurance[0]);
      
    }
    
    else if(this.DataForm.CropName=="Cotton"){
      this.DetailsOfInsurance.push(
        {
          Farmerid:sessionStorage.getItem("fid"),
          CompanyName:"HDFC Inc",
          SumAssuredPerHec:43000,
          Premium:2150*this.DataForm.Area,
          SumAssured:43000*this.DataForm.Area,
          CropName:this.DataForm.CropName,
          Area:this.DataForm.Area,
          Season:this.DataForm.Season,
          Year:this.DataForm.Year
        }
      );
      console.log(this.DetailsOfInsurance);
    }
    else if(this.DataForm.CropName=="GroundNut"){
      this.DetailsOfInsurance.push(
        {
          Farmerid:sessionStorage.getItem("fid"),
          CompanyName:"HDFC Inc",
          SumAssuredPerHec:35000,
          Premium:700*this.DataForm.Area,
          SumAssured:35000*this.DataForm.Area,
          CropName:this.DataForm.CropName,
          Area:this.DataForm.Area,
          Season:this.DataForm.Season,
          Year:this.DataForm.Year,
        }
      );
      console.log(this.DetailsOfInsurance);
    }
    else if(this.DataForm.CropName=="SoyaBean"){
      this.DetailsOfInsurance.push(
        {
          Farmerid:sessionStorage.getItem("fid"),
          CompanyName:"Reliance Inc",
          SumAssuredPerHec:45000,
          Premium:900*this.DataForm.Area,
          SumAssured:45000*this.DataForm.Area,
          CropName:this.DataForm.CropName,
          Area:this.DataForm.Area,
          Season:this.DataForm.Season,
          Year:this.DataForm.Year,
        }
      );
      console.log(this.DetailsOfInsurance);
    }
    else if(this.DataForm.CropName=="Wheat"){
      this.DetailsOfInsurance.push(
        {
          Farmerid:sessionStorage.getItem("fid"),
          CompanyName:"Universal SOMPO",
          SumAssuredPerHec:48753,
          Premium:731*this.DataForm.Area,
          SumAssured:48753*this.DataForm.Area,
          CropName:this.DataForm.CropName,
          Area:this.DataForm.Area,
          Season:this.DataForm.Season,
          Year:this.DataForm.Year,
        }
      );
      console.log(this.DetailsOfInsurance);
    }
    
    else if(this.DataForm.CropName=="Barley"){
      this.DetailsOfInsurance.push(
        {
          Farmerid:sessionStorage.getItem("fid"),
          CompanyName:"HDFC Inc",
          SumAssuredPerHec:42000,
          Premium:630*this.DataForm.Area,
          SumAssured:42000*this.DataForm.Area,
          CropName:this.DataForm.CropName,
          Area:this.DataForm.Area,
          Season:this.DataForm.Season,
          Year:this.DataForm.Year,
        }
      );
      console.log(this.DetailsOfInsurance);
    }
    
    else if(this.DataForm.CropName=="Ginger"){
      this.DetailsOfInsurance.push(
        {
          Farmerid:sessionStorage.getItem("fid"),
          CompanyName:"Bharti AXA",
          SumAssuredPerHec:25000,
          Premium:1250*this.DataForm.Area,
          SumAssured:25000*this.DataForm.Area,
          CropName:this.DataForm.CropName,
          Area:this.DataForm.Area,
          Season:this.DataForm.Season,
          Year:this.DataForm.Year,
        }
      );
      console.log(this.DetailsOfInsurance);
    }
    
    else if(this.DataForm.CropName=="Peas"){
      this.DetailsOfInsurance.push(
        {
          Farmerid:sessionStorage.getItem("fid"),
          CompanyName:"SBI Inc",
          SumAssuredPerHec:30000,
          Premium:1500*this.DataForm.Area,
          SumAssured:30000*this.DataForm.Area,
          CropName:this.DataForm.CropName,
          Area:this.DataForm.Area,
          Season:this.DataForm.Season,
          Year:this.DataForm.Year,
        }
      );
      console.log(this.DetailsOfInsurance);
    }
  }
    else alert("Please fill the required details");
    
    
  }

  InsuranceData(){
    const httpheader={headers:new HttpHeaders({'Content-Type':'application/json'})};
    this.http.post('https://localhost:44365/api/ApplyInsurance/',JSON.stringify(this.DetailsOfInsurance[0]),httpheader)
    .subscribe((data)=>
    {console.log(data);
      if(data=="OK") alert('Insurance applied successfully');
    })    
  }

  ngOnInit(): void {
  }
  dataSource=   [
    {
          group: 'Kharif',
          items: [
              {id: 'Cotton', name: 'Cotton'},
              {id: 'GroundNut', name: 'GroundNut'},
              {id: 'Rice', name: 'Rice'},
              {id: 'SoyaBean', name: 'SoyaBean'}
          ]
      },
      {
          group: 'Rabi',
          items: [
              {id: 'Wheat', name: 'Wheat'},
              {id: 'Barley', name: 'Barley'},
          ]
      },
      {
          group: 'Hoticulture',
          items: [
              {id: 'Ginger', name: 'Ginger'},
              {id: 'Pea', name: 'Pea'},
  
          ]
      }
  ]
}
