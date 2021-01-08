import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import {CropRequestModel} from '../models/cropRequestModel';
import {CropRequestService} from '../services/croprequestservice';

@Component({
  selector: 'app-croprequest',
  templateUrl: './croprequest.component.html',
  styleUrls: ['./croprequest.component.css']
})
export class CroprequestComponent implements OnInit {

  response: any;
  constructor(private crservice: CropRequestService) { }
  CrpReq:CropRequestModel={
    CropName:null,
    CropType:null,
    Quantity:0,
    FertilizerType:null,
    SoilPhCertificate:null
  };

  ngOnInit(): void {
  }
  drpCropType =['Kharif','Rabi','Hoticulture'];
  drpCropName=['Rice','Dal','SoyaBean','Cotton','GroundNut'];
  drpFertilizeType=['Organic','Non-Organic'];
  imageUrl:string= "/assets/img/portfolio-1.jpg";
  fileToUpload:File=null;
  dummyrequest:any={};
 
 /* addRequest(container:NgForm)
  {
    //this.CrpReq.push(this.dummyrequest);
    //this.dummyrequest={};
    this.response=this.crservice.cropService(container)
    .subscribe((data) => {console.log(data);});
    container.reset();
    alert("Request Updated")

  }*/

  handleFileInput(file: FileList) {
    this.fileToUpload=file.item(0);

    //shwing image preview 
    var reader = new FileReader();
    reader.onload=(event:any)=>{
      this.imageUrl=event.target.result;
    }
    reader.readAsDataURL(this.fileToUpload);
}

OnSubmit(CropType,CropName,Quantity,FertilizerType,Image){
  if(CropType.value!=null && CropName.value!=null && FertilizerType!=null && Quantity.value!=0){
  console.log(sessionStorage.getItem("fid"));
  this.crservice.postFile(CropType.value,CropName.value,Quantity.value,FertilizerType.value,this.fileToUpload).subscribe(
    data =>{
      alert("Crop Request Submitted Successfully!");
      console.log('done');
      CropType.value = null;
      CropName.value = null;
      FertilizerType=null;
      Quantity=0;
      Image.value = null;
      this.imageUrl = "/assets/image/default-image.png";
      alert("Crop Request Submitted Successfully!");
    }
  );
  }
  else alert("Please fill the required details");
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
