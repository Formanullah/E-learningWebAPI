import { Subject } from './../../_models/subject';
import { Component, OnInit } from '@angular/core';
import { Class } from 'src/app/_models/class';
import { UserService } from 'src/app/_services/user.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  slideConfig = {slidesToShow: 4, slidesToScroll: 2, autoplay : true,
  autoplaySpeed : 2000};
  slides = [
    {img: '../../../assets/img/banner2.jpg'},
    {img: '../../../assets/img/banner2.jpg'},
    {img: '../../../assets/img/banner2.jpg'},
    {img: '../../../assets/img/banner2.jpg'},
    {img: '../../../assets/img/banner2.jpg'},
    {img: '../../../assets/img/banner2.jpg'},
    {img: '../../../assets/img/banner2.jpg'}
  ];


  classes: Class[] = [];
  subjects: Subject[] = [];


  constructor(private userService: UserService) { }

  // tslint:disable-next-line:typedef
  ngOnInit() {
    this.getAllSubjects();
    this.getAllClasses();
  }

  getAllClasses(): void {
    this.userService.getClasses().subscribe( res => {
      this.classes = res;
    }, error => {
      console.log('Problem in retrive class');
    });
  }
  getAllSubjects(): void {
    this.userService.getAllSubjects().subscribe( res => {
      this.subjects = res;
    }, error => {
      console.log(error);
    });
  }

}
