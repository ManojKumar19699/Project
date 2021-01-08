import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-main-home',
  templateUrl: './main-home.component.html',
  styleUrls: ['./main-home.component.css']
})
export class MainHomeComponent implements OnInit {

  imageObject = [{
    image: '../assets/images/farm1.jpeg',
    thumbImage: '../assets/images/farm1.jpeg',
    //title: 'Hummingbirds are amazing creatures'
}, {
    image: '../assets/images/farm2.jpeg',
    thumbImage: '../assets/images/farm2.jpeg'
}, {
    image: '../assets/images/farm3.jpeg',
    thumbImage: '../assets/images/farm3.jpeg',
   // title: 'Example with title.'
},{
    image: '../assets/images/farm4.jpeg',
    thumbImage: '../assets/images/farm4.jpeg',
 //   title: 'Hummingbirds are amazing creatures'
}, {
    image: '../assets/images/farm5.jpeg',
    thumbImage: '../assets/images/farm5.jpeg'
},
{
  image: '../assets/images/farm6.jpg',
  thumbImage: '../assets/images/farm6.jpg'
},
{
  image: '../assets/images/farm7.jpg',
  thumbImage: '../assets/images/farm7.jpg'
}];
  constructor() { }

  ngOnInit(): void {
  }

}
