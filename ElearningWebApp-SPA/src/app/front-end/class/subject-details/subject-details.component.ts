import { Chapter } from 'src/app/_models/chapter';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Video } from 'src/app/_models/video';
import { Topic } from 'src/app/_models/topic';

@Component({
  selector: 'app-subject-details',
  templateUrl: './subject-details.component.html',
  styleUrls: ['./subject-details.component.css']
})
export class SubjectDetailsComponent implements OnInit {
  topics: Topic[] = [];
  slideConfig = {slidesToShow: 1, slidesToScroll: 1, autoplay : true,
    autoplaySpeed : 2000};

  constructor(private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.route.data.subscribe( data => {
      // tslint:disable-next-line:no-string-literal
      this.topics = data['topics'];
    });

  }

}
