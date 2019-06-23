import { Injectable } from '@angular/core';
import { BaseService } from './base.service';
import { BehaviorSubject, Observable, config, observable } from 'rxjs';
import { HttpClient, HttpHeaders, HttpErrorResponse } from '@angular/common/http';
import { ConfigService } from './config.service';
import { UserRegistration } from '../models/userRegistration';
import { map, catchError, retry, tap } from 'rxjs/operators';
import { Token } from '../models/token';
import { InterceptorSkipHeader } from '../httpconfig.interceptor';

@Injectable({
  providedIn: 'root'
})
export class UserService extends BaseService {
  private baseUrl: string = this.configService.getApiURI();
  public authNavStatusSource = new BehaviorSubject<boolean>(false);
  private authNavStatus$ = this.authNavStatusSource.asObservable();
  private loggedIn = false;
  private _isAdmin = false;

  private logged: Observable<boolean>;

  constructor(private http: HttpClient, private configService: ConfigService) {
    super();
    this.loggedIn = !!sessionStorage.getItem('auth_token');
    this._isAdmin = !!sessionStorage.getItem('isAdmin');
    this.authNavStatusSource.next(this.loggedIn);
    this.baseUrl = configService.getApiURI();
  }

  public register(email: string, password: string, confirmPassword: string, firstName: string, lastName: string, userName: string): Observable<UserRegistration> {
    const body = JSON.stringify({ email, password, confirmPassword, firstName, lastName, userName });
    const headers = new HttpHeaders({ 'Content-Type': 'application/json' });
    const options = { headers };

    return this.http.post<UserRegistration>(this.baseUrl + 'api/Account/Register', body, options)
      .pipe(
        retry(1),
        catchError(this.handleError)
      );
  }

  public login(userName, password): Observable<Token> {

    const headers = new HttpHeaders().set(InterceptorSkipHeader, '');

    const formData: FormData = new FormData();
    formData.append('grant_type', 'password');
    formData.append('username', userName);
    formData.append('password', password);
    formData.append('scope', this.configService.getScope());
    formData.append('client_id', this.configService.getClientId());
    formData.append('client_secret', this.configService.getClientSecret());

    return this.http.post<Token>(this.baseUrl + 'connect/token', formData, { headers })
      .pipe(
        retry(1),
        catchError(this.handleError),
        tap(res => {
          sessionStorage.setItem('auth_token', res.access_token);
          this.loggedIn = true;
          this.authNavStatusSource.next(true);
          this.adminCheck().subscribe(() => {

          });
          return true;
        })
      );
  }

  public logout() {
    sessionStorage.removeItem('auth_token');
    sessionStorage.removeItem('isAdmin');

    this.loggedIn = false;
    this._isAdmin = false;
    this.authNavStatusSource.next(false);
  }

  public isLoggedIn(): boolean {
    if (sessionStorage.getItem('auth_token')) {
      return true;
    } else { return false; }
  }

  public isAdmin(): boolean {
    if (sessionStorage.getItem('isAdmin')) {
      return sessionStorage.getItem('isAdmin') === 'true';
    } else { return false; }
  }

  private adminCheck(): Observable<boolean> {
    const headers = new HttpHeaders({ 'Authorization': 'Bearer ' + sessionStorage.getItem('auth_token') });
    return this.http.get<boolean>(this.baseUrl + 'api/Account/IsAdmin', { headers })
      .pipe(
        retry(1),
        catchError(this.handleError),
        tap(res => {
          sessionStorage.setItem('isAdmin', res.toString());
          return true;
        })
      );

  }
}
