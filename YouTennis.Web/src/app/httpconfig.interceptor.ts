import { Injectable } from '@angular/core';
import {
    HttpInterceptor,
    HttpRequest,
    HttpResponse,
    HttpHandler,
    HttpEvent,
    HttpErrorResponse
} from '@angular/common/http';

import { Observable, throwError } from 'rxjs';
import { map, catchError } from 'rxjs/operators';
import { Router } from '@angular/router';

export const InterceptorSkipHeader = 'X-Skip-Interceptor';

@Injectable()
export class HttpConfigInterceptor implements HttpInterceptor {
    constructor(
        private router: Router
    ) { }


    intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        const token: string = sessionStorage.getItem('auth_token');

        if (token && !request.headers.has(InterceptorSkipHeader)) {
            request = request.clone({ headers: request.headers.set('Authorization', 'Bearer ' + token) });
        }
        else if(!request.headers.has(InterceptorSkipHeader)) {
            this.router.navigate(['/login']);
        }
        else {
            request = request.clone({ headers: request.headers.delete(InterceptorSkipHeader) });
        }

        return next.handle(request).pipe(
            map((event: HttpEvent<any>) => {
                if (event instanceof HttpResponse) {
                    console.log('event--->>>', event);
                }
                return event;
            }));
    }
}
