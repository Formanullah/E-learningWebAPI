import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  slideConfig = {slidesToShow: 4, slidesToScroll: 4, autoplay : true,
  autoplaySpeed : 3000};
  slides = [
    {img: '../../../assets/img/banner2.jpg'},
    {img: '../../../assets/img/banner2.jpg'},
    {img: '../../../assets/img/banner2.jpg'},
    {img: '../../../assets/img/banner2.jpg'},
    {img: '../../../assets/img/banner2.jpg'},
    {img: '../../../assets/img/banner2.jpg'},
    {img: '../../../assets/img/banner2.jpg'}
  ];

  constructor() { }

  ngOnInit() {
  }

}
