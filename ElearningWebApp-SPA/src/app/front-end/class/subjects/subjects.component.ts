import { ActivatedRoute } from '@angular/router';
import { Component, OnInit } from '@angular/core';
import { Subject } from 'src/app/_models/subject';
import { Subjectforclass } from 'src/app/_models/subjectforclass';

@Component({
  selector: 'app-subjects',
  templateUrl: './subjects.component.html',
  styleUrls: ['./subjects.component.css']
})
export class SubjectsComponent implements OnInit {
  subjects: Subjectforclass[] = [];

  constructor(private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.route.data.subscribe( data => {
      // tslint:disable-next-line:no-string-literal
      this.subjects = data['subjects'];
      console.log(this.subjects);
    });
  }

}
