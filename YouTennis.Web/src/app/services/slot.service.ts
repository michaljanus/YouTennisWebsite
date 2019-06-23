import { Injectable } from '@angular/core';
import { Slot } from '../models/slot';
import { Observable, of } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { ConfigService } from './config.service';
import { retry, map, catchError } from 'rxjs/operators';
import { element } from '@angular/core/src/render3';
import { BaseService } from './base.service';

@Injectable({
  providedIn: 'root'
})
export class SlotService extends BaseService {
  private baseUrl;

  private data: Slot[] = [
    {time: "18:00", timeAsNumber: 18, isAvailable: true} as Slot,
    {time: "19:00", timeAsNumber: 19, isAvailable: true} as Slot,
    {time: "20:00", timeAsNumber: 20, isAvailable: false} as Slot,
    {time: "21:00", timeAsNumber: 21, isAvailable: true} as Slot
  ]

  constructor(private httpClient: HttpClient, private configService: ConfigService) {
    super();
    this.baseUrl = this.configService.getApiURI() + "api/booking";
    
   }

   

  public getSlotForDate(date: any): Observable<Slot[]> {
    return of (this.data);
  }

  public bookSlot(courtId: string, date: any, time: string){
    return 
  }

  private mapCollection(data: any[]) {
    const result = new Array();
    data.forEach(element => {
      result.push({
        time: element.time,
        isAvailable: element.isAvailable,
        timeAsNumber: element.number
      } as Slot)
    });
    return result;
  }

  getByCourtId(courtId, date): Observable<Slot[]> {
    return this.httpClient
      .get(`${this.baseUrl}/GetSlots/${courtId}/${date}/`)
      .pipe(
        map((data: any) => this.mapCollection(data) as Slot[]),
        retry(1),
        catchError(this.handleError));
  }


}
