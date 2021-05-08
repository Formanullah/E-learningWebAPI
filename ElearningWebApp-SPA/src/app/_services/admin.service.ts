import { Topic } from './../_models/topic';
import { Subject } from './../_models/subject';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Class } from '../_models/class';
import { Subjectforclass } from '../_models/subjectforclass';
import { Chapter } from '../_models/chapter';
import { Video } from '../_models/video';
import { EditableSubject } from '../_models/editable-subject';

@Injectable({
  providedIn: 'root'
})
export class AdminService {
  baseUrl = environment.apiUrl + 'Admin/';

constructor(private http: HttpClient) { }

getClasses(): Observable<Class[]> {
  return this.http.get<Class[]>(this.baseUrl + 'GetAllClass');
}

getAllSubjects(): Observable<Subject[]> {
  return this.http.get<Subject[]>(this.baseUrl + 'GetAllSubjects');
}


// tslint:disable-next-line:typedef
getSubjectByClassId(id: number): Observable<Subjectforclass[]> {
  return this.http.get<Subjectforclass[]>(this.baseUrl + 'GetAllSubjectsByClassId/' + id);
}

getChapterBySubjectForClassId(id: number): Observable<Chapter[]>{
  return this.http.get<Chapter[]>(this.baseUrl + 'GetAllChaptersBySubjectId/' + id);
}
getAllChapters(): Observable<Chapter[]> {
  return this.http.get<Chapter[]>(this.baseUrl + 'GetAllChapters/');
}

getAllTopics(): Observable<Topic[]> {
  return this.http.get<Topic[]>(this.baseUrl + 'GetAllTopics/');
}

getAllTopicsByChapterId(id: number): Observable<Topic[]> {
  return this.http.get<Topic[]>(this.baseUrl + 'GetAllTopicsByChapterId/' + id);
}

getAllVideos(): Observable<Video[]> {
  return this.http.get<Video[]>(this.baseUrl + 'GetAllVideos');
}

// tslint:disable-next-line:typedef
create(suffixUrl: string, model: any) {
  return this.http.post(this.baseUrl + suffixUrl, model);
}

// tslint:disable-next-line:typedef
delete(suffixUrl: string, id: number) {
  return this.http.delete(this.baseUrl + suffixUrl + id);
}

// tslint:disable-next-line:typedef
updateSubejcet(subject: EditableSubject) {
  return this.http.put(this.baseUrl + 'UpdateSubject', subject);
}
}
