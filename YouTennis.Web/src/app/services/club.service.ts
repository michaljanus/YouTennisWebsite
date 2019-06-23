import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpErrorResponse } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { map, catchError, tap, retry } from 'rxjs/operators';
import { Club } from '../models/club';
import { ResourceService } from './resourceService';
import { ClubSerializer } from '../serializers/clubSerializer';
import { ConfigService } from './config.service';
import { InterceptorSkipHeader } from '../httpconfig.interceptor';

@Injectable({
  providedIn: 'root'
})
export class ClubService extends ResourceService<Club> {

  constructor(httpClient: HttpClient, private configService: ConfigService) {
    super(
      httpClient,
      configService.getApiURI() + "api/Club",
      new ClubSerializer());
  }

  getAll(): Observable<Club[]> {
    const headers = new HttpHeaders().set(InterceptorSkipHeader, '');
    return this.httpClient
      .get(`${this.baseUrl}/GetAll`, { headers })
      .pipe(
        map((data: any) => this.mapCollection(data) as Club[]),
        retry(1),
        catchError(this.handleError));
  }
}
