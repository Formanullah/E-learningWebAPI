import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css']
})
export class ProfileComponent implements OnInit {
  user: any = {
    name: '',
    classId: 0,
    id: 0,
    roleName: '',
    className: '',
    mobileNo: '',
  };

  constructor() { }

  ngOnInit(): void {
    this.user = JSON.parse(localStorage.getItem('user') || '');
  }

}
