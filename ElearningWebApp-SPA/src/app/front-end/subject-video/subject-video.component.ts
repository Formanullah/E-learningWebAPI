import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Video } from 'src/app/_models/video';

@Component({
  selector: 'app-subject-video',
  templateUrl: './subject-video.component.html',
  styleUrls: ['./subject-video.component.css']
})
export class SubjectVideoComponent implements OnInit {

  videos: Video[] = [];
  slideConfig = {slidesToShow: 2, slidesToScroll: 2, autoplay : true,
    autoplaySpeed : 2000};

  constructor(private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.route.data.subscribe( data => {
      // tslint:disable-next-line:no-string-literal
      this.videos = data['videos'];
    });

  }
}
