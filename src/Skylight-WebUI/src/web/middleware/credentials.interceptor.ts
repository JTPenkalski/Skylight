import { HttpEvent, HttpHandlerFn, HttpRequest } from '@angular/common/http';
import { Observable } from 'rxjs';
import { AUTH_TOKEN } from 'shared/models';

export function credentialsInterceptor(req: HttpRequest<unknown>, next: HttpHandlerFn): Observable<HttpEvent<unknown>> {
  const authToken: string = localStorage.getItem(AUTH_TOKEN) ?? '';

  const newReq = req.clone({
    withCredentials: true,
    headers: req.headers.set('Authorization', `Bearer ${authToken}`)
  });

  return next(newReq);
}
