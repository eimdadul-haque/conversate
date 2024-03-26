import {
  HttpEvent,
  HttpHandler,
  HttpInterceptor,
  HttpRequest,
} from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { baseUrl } from 'src/environments/environments';

@Injectable({
  providedIn: 'root',
})
export class TokenInterceptorService implements HttpInterceptor {
  constructor() {}

  intercept(
    req: HttpRequest<any>,
    next: HttpHandler
  ): Observable<HttpEvent<any>> {
    const url = `${baseUrl}${req.url}`;
    if (req.url == '/api/Account/Login') {
      return next.handle(req.clone({ url: url }));
    } else {
      const token = localStorage.getItem('token');
      if (token) {
        req.clone({
          setHeaders: {
            Authorization: `Bearer ${token}`,
          },
        });
      } else {
        throw new Error('token not exist');
      }
      return next.handle(req.clone({ url: url }));
    }
  }
}
