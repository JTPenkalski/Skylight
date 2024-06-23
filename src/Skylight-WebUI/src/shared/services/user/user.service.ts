import { Injectable } from '@angular/core';
import {
  BehaviorSubject,
  Observable,
  Subject,
  map,
  tap,
} from 'rxjs';
import { AUTH_TOKEN } from 'shared/models';
import {
  RegisterNewUserCommand,
  SignInRequest,
  SkylightClient,
} from 'web/clients';

/**
 * Basic information about a user.
 */
export class User {
  constructor(
    public stormTrackerId: string,
    public email: string,
    public firstName: string,
    public lastName: string,
  ) {}

  public static Unknown: string = 'Unknown';

  public get fullName(): string {
    return `${this.firstName} ${this.lastName}`;
  }
}

/**
 * Handles user state and authentication.
 */
@Injectable({
  providedIn: 'root',
})
export class UserService {
  private currentUserChangedSubject: Subject<User | undefined> =
    new BehaviorSubject<User | undefined>(undefined);

  constructor(private readonly client: SkylightClient) {}

  public get authToken(): string {
    return localStorage.getItem(AUTH_TOKEN) ?? '';
  }

  public get currentUserChanged(): Observable<
    User | undefined
  > {
    return this.currentUserChangedSubject.asObservable();
  }

  public trySignIn(): void {
    if (this.authToken !== '') {
      this.onCurrentUserChanged(this.authToken);
    }
  }

  public getCurrentUser(): Observable<User> {
    return this.client
      .getCurrentUser()
      .pipe(
        map(
          (result) =>
            new User(
              result.stormTrackerId!,
              result.email!,
              result.firstName!,
              result.lastName!,
            ),
        ),
      );
  }

  public isSignedIn(): Observable<boolean> {
    return this.client.isSignedIn();
  }

  public register(
    firstName: string,
    lastName: string,
    email: string,
    password: string,
  ): Observable<void> {
    const request: RegisterNewUserCommand = {
      firstName: firstName,
      lastName: lastName,
      email: email,
      password: password,
    };

    return this.client.register(request);
  }

  public signIn(
    email: string,
    password: string,
  ): Observable<boolean> {
    const request: SignInRequest = {
      email: email,
      password: password,
    };

    return this.client.signIn(request).pipe(
      tap((result) =>
        this.onCurrentUserChanged(result.accessToken),
      ),
      map((result) => !!result.accessToken),
    );
  }

  public signOut(): Observable<void> {
    return this.client
      .signOut()
      .pipe(tap(() => this.onCurrentUserChanged()));
  }

  private onCurrentUserChanged(authToken?: string): void {
    localStorage.setItem(AUTH_TOKEN, authToken ?? '');

    if (authToken) {
      this.getCurrentUser().subscribe((result) =>
        this.currentUserChangedSubject.next(result),
      );
    } else {
      this.currentUserChangedSubject.next(undefined);
    }
  }
}
