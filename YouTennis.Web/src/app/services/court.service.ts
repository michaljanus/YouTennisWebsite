import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { ResourceService } from './resourceService';
import { Court } from '../models/court';
import { ConfigService } from './config.service';
import { CourtSerializer } from '../serializers/courtSerializer';
import { retry, map, catchError } from 'rxjs/operators';
import { Observable } from 'rxjs';
import { Slot } from '../models/slot';
import { InterceptorSkipHeader } from '../httpconfig.interceptor';

@Injectable({
  providedIn: 'root'
})
export class CourtService extends ResourceService<Court>{

  constructor(httpClient: HttpClient, private configService: ConfigService) {
    super(
      httpClient,
      configService.getApiURI() + "api/Court",
      new CourtSerializer());
  }

  getByCourtId(courtId): Observable<Court[]> {
    const headers = new HttpHeaders().set(InterceptorSkipHeader, '');
    return this.httpClient
      .get(`${this.baseUrl}/GetByClubId/${courtId}`, { headers })
      .pipe(
        map((data: any) => this.mapCollection(data) as Court[]),
        retry(1),
        catchError(this.handleError));
  }

  
}
