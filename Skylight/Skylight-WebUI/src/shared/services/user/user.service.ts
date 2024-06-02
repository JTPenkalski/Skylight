import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable, Subject, map, tap } from 'rxjs';
import { RegisterNewUserCommand, SignInRequest, SkylightClient } from 'web/clients';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  private authStateChangedSubject: Subject<boolean> = new BehaviorSubject<boolean>(false);

  constructor(private readonly client: SkylightClient) { }

  public get authStateChanged(): Observable<boolean> { return this.authStateChangedSubject.asObservable(); }

  public isSignedIn(): Observable<boolean> {
    return this.client.isSignedIn();
  }

  public register(firstName: string, lastName: string, email: string, password: string): Observable<void> {
    const request: RegisterNewUserCommand = {
      firstName: firstName,
      lastName: lastName,
      email: email,
      password: password,
    };

    return this.client.register(request);
  }

  public signIn(email: string, password: string): Observable<boolean> {
    const request: SignInRequest = {
      email: email,
      password: password,
    }

    return this.client.signIn(request).pipe(
      map(result => !!result.accessToken),
      tap({
        next: result => this.authStateChangedSubject.next(result)
      })
    );
  }

  public signOut(): Observable<void> {
    return this.client.signOut().pipe(
      tap({
        next: () => this.authStateChangedSubject.next(false)
      })
    );
  }
}
