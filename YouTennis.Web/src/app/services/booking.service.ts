import { Injectable } from '@angular/core';
import { ResourceService } from './resourceService';
import { Booking } from '../models/booking';
import { ConfigService } from './config.service';
import { HttpClient } from '@angular/common/http';
import { BookingSerializer } from '../serializers/bookingSerializer';
import { Observable } from 'rxjs';
import { map, retry, catchError } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class BookingService extends ResourceService<Booking> {

  constructor(httpClient: HttpClient, private configService: ConfigService) {
    super(
      httpClient,
      configService.getApiURI() + "api/Booking",
      new BookingSerializer());
  }

  book(courtId, date): Observable<number> {
    return this.httpClient
      .get(`${this.baseUrl}/Book/${courtId}/${date}/`)
      .pipe(
        map((data: any) => data as number),
        retry(1),
        catchError(this.handleError));
  }

  getBookings(): Observable<Booking[]> {
    return this.httpClient
      .get(`${this.baseUrl}/MyBookings`)
      .pipe(
        map((data: any) => this.mapCollection(data) as Booking[]),
        retry(1),
        catchError(this.handleError));
  }
}