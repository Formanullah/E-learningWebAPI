import { Chapter } from 'src/app/_models/chapter';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Class } from '../_models/class';
import { Subject } from '../_models/subject';
import { Video } from '../_models/video';
import { Topic } from '../_models/topic';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  baseUrl = environment.apiUrl;

constructor(private http: HttpClient) { }

getClasses(): Observable<Class[]> {
  return this.http.get<Class[]>(this.baseUrl + 'Home/GetAllClass');
}

getAllSubjects(): Observable<Subject[]> {
  return this.http.get<Subject[]>(this.baseUrl + 'Home/GetAllSubject');
}

getAllSubjectsByClassId(id: number): Observable<Subject[]> {
  return this.http.get<Subject[]>(this.baseUrl + 'User/AllSubject/' + id);
}

getVideosBySubjectId(id: number): Observable<Video[]> {
  return this.http.get<Video[]>(this.baseUrl + 'Home/GetVideos/' + id);
}

getAllChapterBySubjectId(id: number): Observable<Chapter[]> {
  return this.http.get<Chapter[]>(this.baseUrl + 'User/GetAllChapter/' + id);
}

getAllTopicsByChapterId(id: number): Observable<Topic[]> {
  return this.http.get<Topic[]>(this.baseUrl + 'User/GetAllTopics/' + id);
}

}
