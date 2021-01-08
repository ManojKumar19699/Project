import { Component, OnInit } from '@angular/core';
import {AdminApproveCropService} from '../services/admin-approve-crop.service';

@Component({
  selector: 'app-admin-approve-crop',
  templateUrl: './admin-approve-crop.component.html',
  styleUrls: ['./admin-approve-crop.component.css']
})
export class AdminApproveCropComponent implements OnInit {

  unapprovedcrops:any=[];
  constructor(private adminapprovecropservice:AdminApproveCropService) { }



  ngOnInit(): void {
    this.fetchUnapprovedCrops();
  }
  fetchUnapprovedCrops(){
    this.unapprovedcrops=this.adminapprovecropservice.GetUnapprovedCrops().subscribe((data)=>{this.unapprovedcrops=data;console.log(data)});
    console.log(this.unapprovedcrops);
  }
  approveCrop(Id){
    let i;
    for(i=0;i<this.unapprovedcrops.length;i++){
      if(this.unapprovedcrops[i].RequestId==Id) break;
    }
    console.log(this.unapprovedcrops[i]);
    //this.adminapprovecropservice.updateCrop(this.unapprovedcrops[i]);
    this.adminapprovecropservice.updateCrop(this.unapprovedcrops[i]).subscribe((data)=>{console.log(data);
      if(data=="OK") alert("Crop sale Approved");
      location.reload();
    });
    this.ngOnInit();
    //location.reload();
  }

}
