import { Resource } from '../models/resource';
import { ISerializer } from '../serializers/ISerializer';
import { HttpClient, HttpHeaders, HttpErrorResponse } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { map, retry, catchError } from 'rxjs/operators';
import { BaseService } from './base.service';

export class ResourceService<T extends Resource> extends BaseService {
  constructor(
    protected httpClient: HttpClient,
    protected baseUrl: string,
    private serializer: ISerializer) {
    super();
  }


  public create(item: T): Observable<T> {
    return this.httpClient
      .post<T>(`${this.baseUrl}/Add`, this.serializer.toJson(item)).pipe(
        map(data => this.serializer.fromJson(data) as T),
        retry(1),
        catchError(this.handleError)
      );
  }

  public update(item: T): Observable<T> {
    return this.httpClient
      .put<T>(`${this.baseUrl}/update/${item.id}`,
        this.serializer.toJson(item))
      .pipe(
        map(data => this.serializer.fromJson(data) as T),
        retry(1),
        catchError(this.handleError)
      );
  }

  read(id: number): Observable<T> {
    return this.httpClient
      .get(`${this.baseUrl}/Get/${id}`)
      .pipe(
        map((data: any) => this.serializer.fromJson(data) as T),
        retry(1),
        catchError(this.handleError));
  }

  getAll(): Observable<T[]> {
    return this.httpClient
      .get(`${this.baseUrl}/GetAll`)
      .pipe(
        map((data: any) => this.mapCollection(data) as T[]),
        retry(1),
        catchError(this.handleError));
  }

  delete(id: number): Observable<any> {
    return this.httpClient
      .delete(`${this.baseUrl}/Delete/${id}`).pipe(
        retry(1),
        catchError(this.handleError)
      );
  }

  protected mapCollection(data: any): T[] {
    const result = new Array();
    data.forEach(element => {
      result.push(this.serializer.fromJson(element));
    });
    return result;
  }

  protected convertData(data: any): T[] {
    return data.map(item => this.serializer.fromJson(item));
  }
}
