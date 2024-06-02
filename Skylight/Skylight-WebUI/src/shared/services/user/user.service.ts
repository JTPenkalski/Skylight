import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable, Subject } from 'rxjs';
import { RegisterNewUserCommand, SkylightClient } from 'web/clients';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  private authStateChangedSubject: Subject<boolean> = new BehaviorSubject<boolean>(false);

  constructor(private readonly client: SkylightClient) { }

  public get authStateChanged(): Observable<boolean> { return this.authStateChangedSubject.asObservable(); }

  public register(firstName: string, lastName: string, email: string, password: string): Observable<void> {
    const request: RegisterNewUserCommand = {
      firstName: firstName,
      lastName: lastName,
      email: email,
      password: password
    };

    return this.client.register(request);
  }

  public signIn(email: string, password: string): Observable<void> {
    throw 'Not implemented.';
  }

  public signOut(): Observable<void> {
    throw 'Not implemented.';
  }

  public isSignedIn(): Observable<boolean> {
    throw 'Not implemented.';
  }
}
